using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Lab_16_OOP
{
    class Task56
    {
        int[] mas = new int[10];
        public void ParallelInizMass()
        {
            int count = 0;
            int i = 0;
            ParallelLoopResult res = Parallel.For(1, 10, z =>
              {
                  mas[i] = i*2;
                  i++;
              });
            if(res.IsCompleted)
                Console.WriteLine("Stop");
        }
        public void SortedMass()
        {
              ParallelLoopResult plr =Parallel.ForEach(mas,(ch)=> Array.Sort(mas));
        }
        static void MyMethod()
        {
            for(int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Задача 1 запущена ");
            }
            Console.WriteLine("Задача 1 заверешена");
        }
        static void MyMethod2()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Задача 2 запущена");
            }
            Console.WriteLine("Задача 2 заверешена");
        }
        public void CallMethod()
        {
            Parallel.Invoke(MyMethod, MyMethod2);
        }
    }
}
