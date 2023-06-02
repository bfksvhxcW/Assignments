using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3{

    public interface Shape{
        //形状的面积
        double Area { get; }

        //形状的信息
        string Info { get; }

        //检查形状合法性
        bool IsValid();
    }
}
