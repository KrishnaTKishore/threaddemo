using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace threaddemo
{


    // Simple threading scenario:  Start a static method running
    // on a second thread.
    public class ThreadExample1
    {
        static int sum = 0; 
           // int sum1, sum2, sum3;
        // The ThreadProc method is called when the thread starts.
        // It loops ten times, writing to the console and yielding 
        // the rest of its time slice each time, and then ends.
        public static void ThreadProc1()
        {
            int sum1 = 0;
            for (int i = 0; i <= 10; i++)
            {
              
                sum1=sum1 +i ;

            }
            Console.WriteLine("TreadProc1: Sum: {0}", sum1);
            sum = sum + sum1;
            // Yield the rest of the time slice.
          
            Thread.Sleep(0);
            
        }
        
            // The ThreadProc method is called when the thread starts.
            // It loops ten times, writing to the console and yielding 
            // the rest of its time slice each time, and then ends.
            public static void ThreadProc2()
            {
               int sum2 = 0;

                for (int i = 11; i <= 30; i++)
                {

                    sum2 = sum2 + i;
                  
                }
                  Console.WriteLine("ThreadProc2: Sum: {0}", sum2);
            sum = sum + sum2;
                    // Yield the rest of the time slice.
                    Thread.Sleep(0);
           
            }
        
          // The ThreadProc method is called when the thread starts.
            // It loops ten times, writing to the console and yielding 
            // the rest of its time slice each time, and then ends.
            public static void ThreadProc3()
            {
                int sum3 = 0;
                for (int i = 31; i <= 50; i++)
                {

                    sum3 = sum3 + i;

                   
                }
            Console.WriteLine("ThreadProc3: Sum: {0}", sum3);
            sum = sum + sum3;
            // Yield the rest of the time slice.
          
            Thread.Sleep(0);
        }
        

                public static void Main()
                {
                    //  Console.WriteLine("Main thread: Start a second thread.");
                    // The constructor for the Thread class requires a ThreadStart 
                    // delegate that represents the method to be executed on the 
                    // thread.  C# simplifies the creation of this delegate.
                    Thread t1 = new Thread(new ThreadStart(ThreadProc1));
                    Thread t2 = new Thread(new ThreadStart(ThreadProc2));
                    Thread t3 = new Thread(new ThreadStart(ThreadProc3));

            // Start ThreadProc.  Note that on a uniprocessor, the new 
            // thread does not get any processor time until the main thread 
            // is preempted or yields.  Uncomment the Thread.Sleep that 
            // follows t.Start() to see the difference.
                    t1.Start();
                    t2.Start();
                    t3.Start();
                    //Thread.Sleep(0);

              

                   /* for (int i = 0; i < 4; i++)
                    {

                        Console.WriteLine("Main thread: Do some work.");
                        Thread.Sleep(0);
                    }*/

                    Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
                    t1.Join();
                    t2.Join();
                    t3.Join();
                    Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            Console.WriteLine("Total = {0}", sum);
            Console.ReadLine();

                }
            }
        }
    
