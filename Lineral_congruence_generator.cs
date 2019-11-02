using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamming
{
    public static class Linear_congruential_generator
    {
        private static ulong seed = 1;
        private static ulong a 
        { 
            get 
            {
                return 16807;
            }
        }

        private static ulong m 
        {
            get
            {
                return 0x7fffffff;
            }
        }


        public static void SetSeed(uint seed_)
        {
            seed = seed_;
        }

        public static ulong Generate()
        {
            seed = seed * a % m;
            return seed;
        }

        public static IEnumerable<ulong> NextDouble()
        {
            while (true)
            {
                seed = seed * a % m;
                yield return seed;
            }
        }

        public static byte NextByte()
        {
            ulong a = 255;
            return (byte)(NextDouble().FirstOrDefault() % a);
        }
    }

    public class LCG
    {
        private int seed { get; set; }
        public LCG(int seed)
        {
            this.seed = seed;
        }

        public IEnumerable<byte> NextByte(int max)
        {
            var data = new
            {
                a = 16807,
                m = 0x7fffffff
            };

            while (true)
            {
                this.seed = seed * data.a % data.m;
                yield return (byte)((seed % 255) % max);
            }
        }
    }
}
