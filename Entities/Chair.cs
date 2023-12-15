using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTemplate.Entities
{
    public class Chair
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Employee? Head { get; set; } //працівник який займає посаду Завідувача кафедрою, адже без нього кафедра не може існувати
        public virtual Faculty? Faculty { get; set; }  //факультет до якого належить кафедра, обовязково має належати до якогось факультету

        public virtual ICollection<Speciality>? Specialities { get; set; } //Спеціальності з які належать до кафедри, кафедра обовязково має мати спеціальності

        public Chair()
        {
            Specialities = new List<Speciality>();
        }
    }
}
