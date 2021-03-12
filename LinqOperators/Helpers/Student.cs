using System;

namespace LinqOperators.Helpers
{
    /// <summary>
    /// Helper Class for testing LINQ Operators
    /// </summary>
    public class Student : IComparable<Student>
    {
        public int CompareTo(Student other)
        {
            if (this.StudentName.Length >= other.StudentName.Length)
                return 1;

            return 0;
        }

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}