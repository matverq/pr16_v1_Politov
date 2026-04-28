using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr16_v1_Politov
{
    public class StudentReg
    {
        public List<Student> Students { get; set; }
        public StudentReg()
        {
            Students = new List<Student>();
        }
    }
}
