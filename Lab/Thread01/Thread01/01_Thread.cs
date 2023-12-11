//using System;

//namespace Thread01
//{
//    class Thread
//    {
//        static void MainThread()
//        {
//            for (int i = 0; i < 100; i++)
//            {
//                Console.WriteLine("Hello Thread!!!!" + i);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Thread t = new Thread(MainThread);
//            t.Name = "Test Thread";
//            t.IsBackground = true;
//            t.Start();
//        }
//    }
//}