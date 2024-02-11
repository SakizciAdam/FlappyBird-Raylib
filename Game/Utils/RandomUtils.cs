using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game.Utils
{
    public static class RandomUtils
    {
        public static readonly Random Random = new Random();    
        public static int NextInt(int min,int max)
        {
            return Random.Next(max - min) + min;
        }
    }
}
