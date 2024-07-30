using System;
using AttributesLib;

namespace TestingPOCO
{
    [Serializable]
    [Table(Name = "Employee")]
    public class Emp
    {
        [Column(Name = "id", DataType = "int", IsPrimaryKey = true, IsAutoIncrement = true)]
        public int ID { get; set; }

        [Column(Name = "name", DataType = "varchar(50)", IsNullable = false)]
        public string Name { get; set; }

        [Column(Name = "salary", DataType = "decimal(10,2)", IsNullable = false)]
        public double Salary { get; set; }

        [Column(Name = "department", DataType = "varchar(50)", IsNullable = false)]
        public string Department { get; set; }

        [ForeignKey("Department", "department_id")]
        public int DepartmentID { get; set; }
    }
}
