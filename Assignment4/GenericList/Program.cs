using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication
{
    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            for (Node<T> n = head; n != null; n = n.Next)
            {
                action(n.Data);
            }
        }

        public double Sum(Func<T, double> selector)
        {
            double sum = 0;
            for (Node<T> n = head; n != null; n = n.Next)
            {
                sum += selector(n.Data);
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(random.Next(1000));
            }

            intlist.ForEach(n => Console.Write(n + "\t"));

            double min = double.MaxValue;
            double max = double.MinValue;
            double sum = 0;
            intlist.ForEach(n =>
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
                sum += n;
            });
            Console.WriteLine();
            Console.WriteLine($"min={min},max={max},sum={sum}");

            //使用Sum方法求整数列表的元素和
            sum = intlist.Sum(n => n);
            Console.WriteLine("sum=" + sum);

            //使用Sum方法求字符串列表的所有字符串长度和
            GenericList<string> strlist = new GenericList<string>();
            strlist.Add("a");
            strlist.Add("bc");
            strlist.Add("def");
            int totalLen = (int)strlist.Sum(s => s.Length);
            Console.WriteLine("totalLen=" + totalLen);
        }
    }
}
