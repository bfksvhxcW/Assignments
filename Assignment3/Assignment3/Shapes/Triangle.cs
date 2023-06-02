using System;

namespace Homework3
{
    public class Triangle : Shape
    {
        public Triangle(double a, double b, double c)
        {
            double[] newEdges = new double[3] { a, b, c };
            this.Edges = newEdges;
        }

        public double[] Edges { get; set; } = new double[3];

        public string Info
        {
            get => $"三角形:a={Edges[0]},b={Edges[1]},c={Edges[2]}.";
        }

        public double Area
        {
            get
            {
                if (!IsValid())
                    throw new InvalidOperationException("形状无效，无法计算面积");
                double p = (Edges[0] + Edges[1] + Edges[2]) / 2;
                return Math.Sqrt(p * (p - Edges[0]) * (p - Edges[1]) * (p - Edges[2]));
            }
        }

        public bool IsValid()
        {
            double a = Edges[0], b = Edges[1], c = Edges[2];
            return (a > 0 && b > 0 && c > 0 && a + b > c && b + c > a && a + c > b);
        }
    }
}
