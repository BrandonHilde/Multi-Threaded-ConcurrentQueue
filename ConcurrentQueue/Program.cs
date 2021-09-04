using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace ConcurrentQueue
{
    class Program
    {
        static ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        static void Main(string[] args)
        {
            Thread readThread = new Thread(ReadItAll);
            readThread.IsBackground = true;

            readThread.Start();

            while(true)
            {
                Console.Write("Send: ");
                string value = Console.ReadLine(); // read typed in value
                queue.Enqueue(value); // queue that value
                Thread.Sleep(1); // so the Console.Writes dont overlap
            } 
        }

        static void ReadItAll()
        {
           while(true)
            {
                string result;

                if(queue.TryDequeue(out result)) // try to get the queued value
                {
                    Console.WriteLine("Output: " + result); // output the queued value
                }

            }
        }
    }
}
