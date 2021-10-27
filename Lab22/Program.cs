using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22
{
    
    class Program
    {
        static int[] array;
        static int Sum()
        {
            int s = 0;
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i];
            }
            return s;
        }

        static int Max(Task t)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                max= array[i];
            }
            return max;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            Func<int> func = new Func<int>(Sum);
            Task<int> task1 = new Task<int>(func);
            Func<Task,int> funcTask = new Func<Task,int>(Max);
            Task<int> task2 = task1.ContinueWith(funcTask); 
            task1.Start();
            Console.WriteLine(task1.Result);
            Console.WriteLine(task2.Result);
            Console.ReadKey();
        }
    }
}
