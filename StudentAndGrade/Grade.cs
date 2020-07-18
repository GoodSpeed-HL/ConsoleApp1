using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAndGrade
{
    class Grade
    {
        public string CoureseName { get; set; }
        public double Score { get; set; }
        public Student Student { get; set; }

        public void Show()
        {
            Console.WriteLine(string.Format("{0}    \t{1}", this.CoureseName, this.Score));
        }
    }
}
