using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlappyBird.Game.Utils;
using Raylib_cs;
namespace FlappyBird.Game.Objects
{
    public class Block : GameObject
    {


        public int gap;
        public float posX=GameWindow.screenWidth;
        public const int width = 16;

        public Rectangle Box1=> new Rectangle(posX - 52 / 2, 0, 52, UpHeight);
        public Rectangle Box2 => new Rectangle(posX - 52 / 2, GameWindow.screenHeight - 60 - DownHeight, 52, DownHeight);

        public Block(int gap,int height)
        {
            this.gap=gap;
            this.UpHeight = RandomUtils.NextInt(60, 300)-40;
            this.DownHeight = GameWindow.screenHeight - UpHeight - gap+90;
        }

        public int UpHeight;
        public int DownHeight;

        public override void Render(GameManager gameManager)
        {


            Raylib.DrawTextureEx(AssetLoader.pipe, new System.Numerics.Vector2(posX + 52 / 2, UpHeight), 180, 1f, Color.White);
            Raylib.DrawTextureEx(AssetLoader.pipe, new System.Numerics.Vector2(posX - 52 / 2, GameWindow.screenHeight -60 - DownHeight), 0, 1f, Color.White);
            //Raylib.DrawRectangleLines((int)Box1.X, (int)Box1.Y, (int)Box1.Width, (int)Box1.Height, Color.Red);
            //Raylib.DrawRectangleLines((int)Box2.X, (int)Box2.Y, (int)Box2.Width, (int)Box2.Height, Color.Red);
        }

        public override void Update(GameManager gameManager)
        {
            this.posX -= (float)gameManager.GameHardness*0.05f+2;
        }
    }
}
