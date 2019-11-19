using System;
using System.Threading;

namespace Singleton
{
    class Cache
    {
        private Cache() { }

        private static Cache _instance;

        private static readonly object _lock = new object();

        public static Cache GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Cache();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        public string Value { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("If you see the same value, then singleton was reused (yay!)");
            Console.WriteLine("If you see different values, then 2 singletons were created (boo!)");
            Console.WriteLine("Result:");
            Thread[] threadsArray = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                string str = "FOO_" + i;
                threadsArray[i] = new Thread(() => TestSingleton(str));
            }
            for (int i = 0; i < 10; i++)
            {
                threadsArray[i].Start();
            }
            for (int i = 0; i < 10; i++)
            {
                threadsArray[i].Join();
            }
        }

        public static void TestSingleton(string value)
        {
            Cache cache = Cache.GetInstance(value);
            Console.WriteLine(cache.Value);
        }
    }
}
