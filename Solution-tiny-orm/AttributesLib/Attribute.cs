namespace AttributesLib
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Table : Attribute
    {
        public string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Column : Attribute
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsPrimaryKey { get; set; } = false;
        public bool IsNullable { get; set; } = true;
        public bool IsUnique { get; set; } = false;
        public bool IsAutoIncrement { get; set; } = false;
        public int MaxLength { get; set; } = 0;
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKey : Attribute
    {
        public string ReferenceTable { get; set; }
        public string ReferenceColumn { get; set; }

        public ForeignKey(string referenceTable, string referenceColumn)
        {
            ReferenceTable = referenceTable;
            ReferenceColumn = referenceColumn;
        }
    }
}
