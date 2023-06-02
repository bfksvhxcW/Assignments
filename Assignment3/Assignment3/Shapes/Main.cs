using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework3
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Shape> shapes = new List<Shape>();
                for (int i = 0; i < 10; i++)
                {
                    shapes.Add(ShapeFactory.CreateRandomShape());
                }

                shapes.ForEach(s =>
                  Console.WriteLine($"{s.Info}, area={s.Area}"));

                double total = shapes.Sum(s => s.Area);
                Console.WriteLine($"total={total}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
