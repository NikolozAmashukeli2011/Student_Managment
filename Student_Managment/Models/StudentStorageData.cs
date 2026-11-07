using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Managment.Models
{
    internal class StudentStorageData
    {
        public IEnumerable<Student> Students { get; set; } = new List<Student>();
        public int IdCount { get; set; }

        public StudentStorageData() { }

        public StudentStorageData(IEnumerable<Student> students, int idCount)
        {
            Students = students;
            IdCount = idCount;
        }
    }
}
