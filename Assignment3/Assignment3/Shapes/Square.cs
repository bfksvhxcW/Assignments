using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3 {

  public class Square : Shape {

    public Square(double side) {
      Side = side;
    }

    public double Side { get; set; }

    public string Info => $"正方形:side={Side}.";

    public double Area {
      get {
        if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
        return Side* Side;
      }
  }

    public bool IsValid() {
      return Side > 0;
    }
  }
}
