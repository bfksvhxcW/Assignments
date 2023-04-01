using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorization {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("请输入一个正整数：");
            try {
                int num = int.Parse(Console.ReadLine());
                List<int> res = PF(num);
                Console.WriteLine($"{num}分解质因数结果为：");
                res.ForEach(r => Console.WriteLine(r));
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        private static List<int> PF(int num) {
            // 检测输入是否为大于等于2的正整数
            if (num <= 1) {
                throw new ArgumentException("分解质因数只针对合数！\n退出程序");
            }
            
            // 用列表存放返回的质因数分解结果
            List<int> res = new List<int>();

            int i = 2;

            // 不断用 num 除以一个从2开始递增的整数 i，能整除则 i 是 num 的因数，令 num = num / i，重复 num 除以从2开始递增整数 i 的操作，直到 i = num
            while (i <= num) {  // i = 2, num = 6   i = 2, num = 3      i = 3, num = 3
                if (num % i == 0) {
                    num /= i;   // i = 2, num = 3                       i = 3, num = 1
                    res.Add(i); // res[0] = 2                           res[1] = 3
                    i = 1;      // i = 1, num = 3                       i = 1, num = 1
                }
                i++;            // i = 2, num = 3   i = 3, num = 3      i = 2, num = 1
            }
            
            if (res.Count == 1) {
                throw new ArgumentException("分解质因数只针对合数！\n退出程序");
            }
            
            return res;
        }
    }
}
