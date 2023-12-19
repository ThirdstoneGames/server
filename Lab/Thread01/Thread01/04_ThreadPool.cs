//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Thread01
//{
//    internal class _04_ThreadPool
//    {
//        static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
//        static void SubThread(object? state)
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                Console.WriteLine("#Sub Thread!!");
//            }
//            manualResetEvent.Set();
//        }

//        static void Main(string[] args)
//        {
           


//            ThreadPool.QueueUserWorkItem(SubThread);
//            manualResetEvent.WaitOne();
//            Console.WriteLine("#Main Thread : Finish");
//        }

      
       
//    }
//}
