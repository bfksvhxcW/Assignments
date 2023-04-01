using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMinAvgSum {
    internal class Program {
        static void Main(string[] args) {
            List<double> nums = new List<double>();
            Console.Write("请输入实数数组长度："); // 用户确定数组长度
            try {
                int len = int.Parse(Console.ReadLine()); // 转换失败抛出FormatException异常
                if (len < 1) {
                    throw new ArgumentException("数组长度必须为正整数！\n退出程序");
                }
                Console.WriteLine($"请输入{len}个实数：");
                for (int i = 0; i < len; i++) { // 循环输入，赋值列表
                    double input = double.Parse(Console.ReadLine()); // 由于仍在try块中，不需要再try一次
                    nums.Add(input);
                }
                List<double> res = MaxMinAvgSum(nums);
                Console.Write($"数组中最大值为{res[0]}，最小值为{res[1]}，数据的平均值为{res[2]}，总和为{res[3]}");
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            } catch (FormatException e) {
                Console.WriteLine("请输入实数！\n退出程序");
            } catch {
                Console.WriteLine("发生错误！\n退出程序");
            }
            Console.ReadKey();
        }

        private static List<double> MaxMinAvgSum(List<double> nums) {
            double max = nums[0],
                min = nums[0],
                avg = nums[0],
                sum = nums[0]; // 注意初值对下面 for 循环中有关 sum 的计算的影响

            // 求 max、min、avg、sum
            for (int i = 0; i < nums.Count - 1; i++) {
                if (nums[i] <= nums[i + 1]) {
                    max = nums[i + 1];
                } else {
                    min = nums[i + 1];
                }
                sum += nums[i + 1];
            }
            avg = sum / nums.Count;

            // 将 max、min、avg、sum 放进列表 res 中
            List<double> res = new List<double>() {
                max, min, avg, sum
            };

            return res;
        }
    }
}
