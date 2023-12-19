using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread01
{
    internal class Class1
    {
       
        static void SubThread(object? state)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("#Sub Thread!!");
            }
           
        }

        static void LongTask()
        {
            while(true)
            {
                Console.WriteLine("!");
            }
        }

        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);

            Task t = new Task(LongTask, TaskCreationOptions.LongRunning);

            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(
                    (obj) =>
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            Console.WriteLine($"#Thread  : {j}");
                        }
                    });
            }


            ThreadPool.QueueUserWorkItem(SubThread);
      
        
        }



    }
}


