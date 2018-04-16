using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_16_OOP
{
    class Task34
    {
        static int sum;
        public int Sum(object v)
        {
            int x = (int)v;
            for (; x > 0; x--)
                sum += x;
            return sum;
        }
        public void task_3()
        {
            Task<int> task_1 = Task<int>.Factory.StartNew(Sum, 4);
            Task<int> task_2 = Task<int>.Factory.StartNew(Sum, 5);
            Task<int> task_3 = Task<int>.Factory.StartNew(Sum, 1);
            Task task_4 = new Task(() => Console.WriteLine("Полученное в результате выполнения предыдущих задач значение = " + task_3.Result));
        }
        public void task_4()
        {
            DateTime thisDay = DateTime.Today;
            Console.WriteLine("Дату какого дня желаете получить? 1-сегодняшнего 2-завтрашнего 3-хз, иди нафиг со своими датами");
            int switchData = Convert.ToInt32(Console.ReadLine());
            switch (switchData)
            {
                case 1:
                    Task task_1 = Task.Run(() => Console.WriteLine("Сегодняшняя дата: "));
                    Task task_2 = task_1.ContinueWith(t => Console.Write(thisDay.ToString()));
                    break;
                case 2:
                    Task task_3 = Task.Run(() => Console.WriteLine("Завтрашняя дата: "));
                    Task task_4 = task_3.ContinueWith(t => Console.WriteLine(thisDay.AddDays(1).ToString()));
                    break;
                default:
                    break;
            }
        }

    }
}
