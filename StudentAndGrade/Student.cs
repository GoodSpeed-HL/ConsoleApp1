using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAndGrade
{
    class Student
    {
        public int StudnetId { get; set; }

        public IList<Grade> Grades { get; set; } = new List<Grade>();

        public void ShowGrades()
        {
            foreach(Grade g in this.Grades){
                g.Show();
            }
        }

        public void ShowAvgGrade()
        {
            double total = 0d;
            foreach (Grade g in this.Grades)
            {
                total += g.Score;
            }
            Console.WriteLine(total / this.Grades.Count);
        }

        public void Sync()
        {
            //save to db
        }
    }
}
