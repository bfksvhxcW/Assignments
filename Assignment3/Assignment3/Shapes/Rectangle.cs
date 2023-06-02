using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3 {

  public class Rectangle : Shape {

    public Rectangle(double length, double width) {
      this.Length = length;
      this.Width = width;
    }

    public double Length { get; set; }

    public double Width { get; set; }

    public string Info => $"矩形:length={Length},width={Width}.";

    public double Area {
      get {
        if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
        return Length * Width;
      }
    }

    public bool IsValid() {
      return Length > 0 && Width > 0;
    }
  }
}
