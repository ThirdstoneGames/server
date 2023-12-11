//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//// 코드 자동 정렬 ctrl+k+d
//namespace Thread01
//{
//    internal class ForeGround
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
//            t.IsBackground = false;
//            t.Start();
//        }
//    }
//}
