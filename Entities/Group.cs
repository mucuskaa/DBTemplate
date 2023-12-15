using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTemplate.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Employee? Supervisor { get; set; } // посилання на працівника який є куратором групи
        public virtual ICollection<Student>? Students { get; set; } //посилання на студентів

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
