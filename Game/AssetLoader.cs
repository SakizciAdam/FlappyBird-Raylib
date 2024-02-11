using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    public static class AssetLoader
    {
        public static Texture2D pipe;
        public static Texture2D platformBase;
        public static Texture2D background;
        public static Texture2D player;
        public static Sound wingSound,hit;

        public static void Load()
        {
            pipe=Raylib.LoadTexture("Assets/pipe.png");
            platformBase = Raylib.LoadTexture("Assets/base.png");
            background = Raylib.LoadTexture("Assets/background-day.png");
            player = Raylib.LoadTexture("Assets/player.png");
            wingSound = Raylib.LoadSound("Assets/wing.wav");
            hit = Raylib.LoadSound("Assets/hit.wav");
        }
    }
}
