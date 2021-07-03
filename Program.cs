using System;
using System.Collections.Generic;
using System.Linq;

namespace SockSorter
{
    public class Sock
    {
        public SockColor Color { get; set; }
    }


    public enum SockColor
    {
        Red,
        Blue,
        Green,
        Black,
        White
    }

    public class SockGenerator
    {
        public static List<Sock> GenerateSocks(int max)
        {
            int count = 0;

            List<Sock> socks = new List<Sock>(max);

            while (count < max)
            {
                var pair = GeneratePair();
                socks.Add(pair[0]);
                socks.Add(pair[1]);
                count = count + 2;
            }

            return socks.OrderBy(x => Guid.NewGuid()).ToList();
        }

        private static List<Sock> GeneratePair()
        {
            List<Sock> pair = new List<Sock>();

            Random random = new Random();

            var sockColor = random.Next(0, 5);

            var sock = new Sock()
            {
                Color = (SockColor)sockColor,
            };

            pair.Add(sock);

            pair.Add(sock);

            return pair;
        }



        public bool AreMatched(List<Sock> socks)
        {
            bool areMatched = true;
            for (int i = 0; i < socks.Count; i = i + 2)
            {
                var firstSock = socks[i];
                var secondSock = socks[i + 1];

                areMatched = areMatched
                                && firstSock.Color == secondSock.Color;

                if (areMatched == false) break;
            }

            return areMatched;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SockGenerator S = new SockGenerator();

            Console.WriteLine("How many socks are there: ");
            Console.ReadLine();


            Console.Write("There're: ", S, " Socks mathced");
        }
    }
}

  
   

