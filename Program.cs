using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15._10_ConsoleApp_usses_task
{
    class Program
    {
        static void Method()
        {
            Random rand = new Random();
            Console.WriteLine($"Method() CurrentId {Task.CurrentId} запущен.");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(rand.Next(100,1000));
                Console.WriteLine($"Method() # {Task.CurrentId} i = {i}");
            }
            Console.WriteLine($"Method() CurrentId {Task.CurrentId} окончен.");
        }

        static void Main(string[] args)
        {
            var taskFirst = Task.Factory.StartNew(Method);
            var taskSecond = Task.Factory.StartNew(Method);

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Main {Task.CurrentId} работает");
            }

            Task.WaitAll(taskFirst, taskSecond);
            //Task.WaitAny(taskFirst, taskSecond);

            Console.WriteLine("Main завершил работу");
            Console.ReadLine();
        }
    }
}
