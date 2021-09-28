using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Car
    {
        public string model;
        public string color;

        public Car(string model, string color)
        {
            this.model = model;
            this.color = color;
        }

        //public Car()
        //{
        //    outputInfo("Start", "working");
        //}

        public void outputInfo()
        {
            Console.WriteLine(color + " - " + model);
        }
    }
}
