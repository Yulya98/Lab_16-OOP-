using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Lab_16_OOP
{
    class Task12
    {
        public int[] mas = new int[10];
        static bool flag = false;
        int count = 0;
        public void Task_1_1() {
            Task task1 = new Task(() =>
            {
                for (int i = 2; i < mas.Length; i++)
                {
                    for (int j = 2; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            if (i == j)
                                flag = true;
                            else
                                count++;
                        }
                    }
                    if (flag == true && count == 0)
                        Console.WriteLine(i);
                    count = 0;
                    flag = false;
                }
            });
            task1.Start();
            Console.WriteLine(Task.CurrentId);
            Console.WriteLine("Задача завершена? " + task1.IsCompleted);
            Console.WriteLine("Статус задачи: " + task1.Status);
        }
        public void Task_2()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task1 = new Task(() =>
            {
                for (int i = 2; i < mas.Length; i++)
                {
                    for (int j = 2; j <= i; j++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Операция прервана");
                            return;
                        }
                        if (i % j == 0)
                        {
                            if (i == j)
                                flag = true;
                            else
                                count++;
                        }
                    }
                    if (flag == true && count == 0)
                        Console.WriteLine(i);
                    count = 0;
                    flag = false;
                }
            });
            Console.WriteLine(Task.CurrentId);
            Console.WriteLine("Задача завершена? " + task1.IsCompleted);
            Console.WriteLine("Статус задачи: " + task1.Status);
            task1.Start();
            Console.WriteLine("Для завершения операции нажмите q");
            string forStop = Console.ReadLine();
            if (forStop == "q")
                cancellationTokenSource.Cancel();
        }
    }
}
