﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AttributesLib;

namespace ORM_Tool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the solution directory
            string solutionDirectory = GetSolutionDirectory();

            if (solutionDirectory == null)
            {
                Console.WriteLine("Solution directory not found.");
                return;
            }

            // Set the path for the script.sql file relative to the solution directory
            string path = Path.Combine(solutionDirectory, "script.sql");

            Console.WriteLine($"SQL script will be created at: {path}");

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter streamWriter = new StreamWriter(fs))
            {
                Console.Write("Enter the POCO library path - ");
                string poco_path = Console.ReadLine();

                Assembly assembly = Assembly.LoadFrom(poco_path);
                Type[] types = assembly.GetTypes();

                Console.Write("Enter the database name: ");
                string databaseName = Console.ReadLine();

                string createDatabaseQuery = $@"
                CREATE DATABASE IF NOT EXISTS {databaseName};
                USE {databaseName};";

                streamWriter.WriteLine(createDatabaseQuery);
                Console.WriteLine(createDatabaseQuery);

                foreach (Type t in types)
                {
                    if (!t.FullName.ToLower().Contains("attribute"))
                    {
                        Console.WriteLine("Class Name - " + t.FullName);
                        string query = "";

                        IEnumerable<Attribute> type_attributes = t.GetCustomAttributes();
                        foreach (Attribute attribute in type_attributes)
                        {
                            if (attribute is Table table)
                            {
                                Console.WriteLine(attribute.GetType().Name);
                                query = "CREATE TABLE " + table.Name + " ( ";
                                break;
                            }
                        }

                        PropertyInfo[] properties = t.GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            IEnumerable<Attribute> property_attributes = property.GetCustomAttributes();
                            foreach (Attribute attribute in property_attributes)
                            {
                                if (attribute is Column column)
                                {
                                    string columnDefinition = column.Name + " " + column.DataType;

                                    if (column.IsPrimaryKey)
                                        columnDefinition += " PRIMARY KEY";

                                    if (column.IsAutoIncrement)
                                        columnDefinition += " AUTO_INCREMENT";

                                    if (!column.IsNullable)
                                        columnDefinition += " NOT NULL";

                                    if (column.IsUnique)
                                        columnDefinition += " UNIQUE";

                                    if (column.MaxLength > 0)
                                        columnDefinition += $"({column.MaxLength})";

                                    query += columnDefinition + ", ";
                                    break;
                                }
                            }
                        }
                        query = query.TrimEnd(',', ' ');
                        query += " );";

                        Console.WriteLine(query);
                        streamWriter.WriteLine(query);
                    }
                }
            }

            Console.WriteLine("SQL script creation completed.");
            Console.ReadLine();
        }

        static string GetSolutionDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            while (directoryInfo != null)
            {
                Console.WriteLine($"Checking directory: {directoryInfo.FullName}");
                if (Directory.GetFiles(directoryInfo.FullName, "*.sln").Length > 0)
                {
                    return directoryInfo.FullName;
                }
                directoryInfo = directoryInfo.Parent;
            }

            return null;
        }
    }
}
