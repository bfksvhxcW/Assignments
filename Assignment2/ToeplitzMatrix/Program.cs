using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToeplitzMatrix {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("矩阵的行数为：");
            try {
                int m = int.Parse(Console.ReadLine()); // 确定矩阵行数
                Console.Write("矩阵的列数为：");
                int n = int.Parse(Console.ReadLine()); // 确定矩阵列数
                int[,] matrix = new int[m, n]; // 用二维数组存放矩阵(二维List的赋值远比数组复杂）
                for (int i = 0; i < m; i++) {
                    Console.WriteLine($"输入第{i + 1}行的数据：");
                    for (int j = 0; j < n; j++) {
                        matrix[i, j] = int.Parse(Console.ReadLine()); // 赋值矩阵
                    }
                }
                Console.WriteLine("该矩阵是否为托普利茨矩阵：" + TMatrixOrNot(matrix));
            } catch (ArgumentException e) {
                Console.WriteLine("非法输入！退出程序");
            } catch {
                Console.WriteLine("出现错误！退出程序");
            }
            Console.ReadKey();
        }

        private static bool TMatrixOrNot(int[,] matrix) {
            bool b = true;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++) {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++) {
                    if (matrix[i, j] != matrix[i + 1, j + 1]) {
                        b = false;
                        return b;
                    }
                }
            }
            return b;
        }
    }
}
