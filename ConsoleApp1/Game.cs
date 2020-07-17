using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   

    class Game
    {
        private string Title { get; set; }
        private DateTime GameDate { get; set; }
        public string Name { get; set; }
        public Game(string title, DateTime date)
        {
            Title = title;
            GameDate = date;
        }
        
        public string Display()
        {
            return String.Format("game is {0} and start date is {1}", Title, GameDate);
        }
      
    }

    public class Car
    {
        private string _make;
        public string Make // Noncompliant
        {
            get { return _make; }
            set { _make = value; }
        }
    }

    public class Car1
    {
        public string Make { get; set; }
    }
}
