using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace Lab_16_OOP
{
    class Task7
    {
        BlockingCollection<string> blocking = new BlockingCollection<string>();
        public void Saller( string nameOfProdacts, int interval)
        {
            for(int i=0; i == 1;i++)
            {
                Thread.Sleep(interval);
                blocking.Add(nameOfProdacts);
            }
        }
        public void Customer()
        {
            foreach(var item in blocking.GetConsumingEnumerable())
            {
                Console.WriteLine(item);
            }
        }
        public void purchase()
        {
            Task task_1 = Task.Factory.StartNew(() => Saller("Banan", 500));
            Task task_2 = Task.Factory.StartNew(() => Saller("Voda", 700));
            Task task_3 = Task.Factory.StartNew(() => Saller("Apple", 100));
            Task task_4 = Task.Factory.StartNew(() => Saller("Hz", 200));
            Task task_5 = Task.Factory.StartNew(() => Saller("Hz", 800));
            Task task_6 = Task.Factory.StartNew(() => Customer());
      
        }
    }
}
