using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread01
{
    internal class _04_ThreadPool
    {
        static void MainThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main Thread!!");
            }
        }
    }
}
