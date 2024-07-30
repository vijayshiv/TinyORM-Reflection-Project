# Step to run the project

    - clone the project in the local machine
    - https://github.com/vijayshiv/TinyORM-Reflection-Project.git
    - Open Visual Studio and select open project or solution

## Step to create the .sql file

    - Add the AttributesLib.dll in your POCO(Plain old C# Object) dependencies by right-clicking -> Add Project Reference
    - After creating our POCO, run the ORM_Tool.exe in VS
    - It will ask the path of dll of you POCO it is something like ("..\Solution-tiny-orm\TestingPOCO\bin\Debug\net6.0\TestingPOCO.dll")
    - Give the database name.
    - The sql script is created in the project directory that you cloned.

### You can run the script in the database environment

# ORM_Tool

## Usage Instructions:

1. Extract the contents of the ORM_Tool.zip file to a directory on your machine.

2. Open a Command Prompt or Terminal window and navigate to the directory where you extracted the files.

3. Run the executable with the following command:

   ORM_Tool.exe

4. When prompted, enter the full path to your POCO library DLL. For example:

   D:\path\to\your\POCO\library\YourLibrary.dll

5. The tool will generate a SQL script based on the POCO library and save it as script.sql in the current directory.

Example:

Enter the POCO library path - D:\path\to\your\POCO\library\YourLibrary.dll

The SQL script will be created as script.sql in the same directory.

Contact Support:

If you encounter any issues or need further assistance, please contact [Your Contact Information].
