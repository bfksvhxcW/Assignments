using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3 {

  public class Circle : Shape {

    public Circle(double radius) {
      Radius = radius;
    }

    public double Radius { get; set; }

    public string Info => $"圆形:radius={Radius}";
    
    public double Area {
      get {
        if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
        return Math.PI * Radius * Radius;
      }
    }

    public bool IsValid() {
      return Radius > 0;
    }
  }
}
