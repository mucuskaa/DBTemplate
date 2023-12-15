using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DBTemplate.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Employee? Dean { get; set; }  //працівник який займає посаду Декану факультету, адже без нього факультет не може існувати
                                                     //(можливо ліпше зробити не клас Employee а клас Lecturer,
                                                     //адже інших робітників окрім викладачів не планую робити)

        public virtual ICollection<Chair>? Chairs { get; set; } // кафедри які належать до цього факультету, адже факультет обов'язково має мати кафедри 

        public Faculty()
        {
            Chairs = new List<Chair>();
        }
    }
}
