using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTemplate.Entities
{
    public class Student : Person
    {
        public Group? Group { get; set; }//посилання на групу до якої належить, обовязково має бути

        //public int? GroupId { get; set; }
        //на мій погляд варто було б додати але не впевнена

    }
}
