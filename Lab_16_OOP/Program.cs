using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace Lab_16_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Task12 task12 = new Task12();
            task12.Task_1_1();
            task12.Task_2();
            Task34 task34 = new Task34();
            task34.task_3();
            task34.task_4();
            Task56 obj = new Task56();
            obj.ParallelInizMass();
            obj.SortedMass();
            obj.CallMethod();
            purchase();
            DisplayResultAsync();
            Console.ReadLine();
        }
        static BlockingCollection<string> blocking = new BlockingCollection<string>();
        static private void Saller(string nameOfProdacts, int interval)
        {
            for (int i = 0; i == 1; i++)
            {
                Thread.Sleep(interval);
                blocking.Add(nameOfProdacts);
            }
        }
        static public void Customer()
        {
            foreach (var item in blocking.GetConsumingEnumerable())
            {
                Console.WriteLine(item);
            }
            blocking.CompleteAdding();
        }
        static public void purchase()
        {
            Task task_1 = Task.Factory.StartNew(() => { for (int i = 0; i == 1; i++)
                {
                    Thread.Sleep(200);
                    blocking.Add("Banan");
                }
            });
            Task task_3 = Task.Factory.StartNew(() => Saller("Apple", 100));
            Task task_4 = Task.Factory.StartNew(() => Saller("Hz", 200));
            Task task_5 = Task.Factory.StartNew(() => Saller("Hz", 800));
            Task task_6 = Task.Factory.StartNew(() => Customer());
        }
        static async void DisplayResultAsync()
        {
            int num = 5;

            int result = await FactorialAsync(num);
            Thread.Sleep(3000);
            Console.WriteLine("Факториал числа {0} равен {1}", num, result);
        }

        static Task<int> FactorialAsync(int x)
        {
            int result = 1;

            return Task.Run(() =>
            {
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                return result;
            });
        }
    }
}

