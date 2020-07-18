using System;

namespace StudentAndGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.StudnetId = 1;

            Grade g1 = new Grade();
            g1.CoureseName = "c1";
            g1.Score = 90;

            Grade g2 = new Grade();
            g2.CoureseName = "c2";
            g2.Score = 95;

            Grade g3 = new Grade();
            g2.CoureseName = "c3";
            g3.Score = 80;
            
           // Grade g4 = new Grade {CoureseName = "test5", Score = 60};

            s1.Grades.Add(g1);
            s1.Grades.Add(g2);
            s1.Grades.Add(g3);
           // s1.Grades.Add(g4);

            s1.ShowGrades();
            s1.ShowAvgGrade();
        }
    }
}
