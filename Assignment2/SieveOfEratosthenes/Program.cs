using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveOfEratosthenes {
    /// <summary>
    /// 用“埃氏筛法”（把不大于根号n的所有素数的倍数剔除，剩下的就是自然数n以内的素数），求 2~100 以内的素数
    /// </summary>
    internal class Program {
        static void Main(string[] args) {
            List<int> nums = new List<int>();
            for (int i = 2; i <= 100; i++) {
                nums.Add(i); // 将2到100一次添加到列表nums中
            }
            List<int> res = Sieve(nums);
            Console.Write("2~100内的素数为：");
            res.ForEach(r => Console.Write(r + " "));
            Console.ReadKey();
        }

        private static List<int> Sieve(List<int> nums) {
            for (int i = 2; i * i <= 100; i++) { // 遍历不大于根号n的所有素数
                for (int j = 2; j * i <= 100; j++) { // 遍历100以内所有不大于根号n的数的倍数
                    nums.Remove(i * j); // 经实操发现Remove的值可以是列表中没有的
                }
            }
            List<int> res = new List<int>();
            for (int i = 0; i < nums.Count; i++) {
                res.Add(nums[i]); // 将nums列表剩下的元素（都是素数）搬运到res列表中
            }
            return res;
        }
    }
}
