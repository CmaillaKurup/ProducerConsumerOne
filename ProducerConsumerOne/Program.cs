using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumerOne
{
    //this code produce up to 5 items and consume while posible
    class Program
    {
        private static int _itemsHolder;
        static int item = 0;
        static Random _random = new Random();

        static void Main(string[] args)
        {
            Program pg = new Program();

            Thread producer = new Thread(new ThreadStart(pg.Producer));
            Thread consumer = new Thread(new ThreadStart(pg.Consumer));
            
            producer.Start();
            consumer.Start();
        }
        public void Producer()
        {
            while (true)
            {
                if (_itemsHolder < 5)
                {
                    _itemsHolder ++;
                    Console.WriteLine(_itemsHolder + " producer");
                }
                else
                {
                    Console.WriteLine("Producer is wating");
                }
                Thread.Sleep(_random.Next(200, 1000));
            }
        }
        public void Consumer()
        {
            while (true)
            {
                if (_itemsHolder > 0)
                {
                    _itemsHolder --;
                    Console.WriteLine(_itemsHolder + " consumer");
                }
                else
                {
                    Console.WriteLine("Consumer is wating");
                }
                Thread.Sleep(_random.Next(200, 1000));
            }
        }
    }
}