using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game.Objects
{
    public class Player : GameObject
    {

        public float posY =GameWindow.screenHeight/2;
        public const float posX=64;
        public float motionY = -3;
        public int noMotionChange = 0;
        public Rectangle Box=>new Rectangle(posX-8,posY-8,16,16);

        public override void Render(GameManager gameManager)
        {
            float rotation = motionY == 0 ? 0 : 0+motionY * -6;
            rotation=gameManager.died ? 90 : rotation;  
            Raylib.DrawTextureEx(AssetLoader.player, new System.Numerics.Vector2((int)posX-34/2+(gameManager.died ? 34/2 : 0), (int)posY-24/2), rotation, 1, Color.White);
            //Raylib.DrawCircleLines((int)posX, (int)posY, 16, Color.Red);
        }

        public int deathTick = 0;

        public void UpdateDied(GameManager gameManager)
        {
            deathTick++;
            if (deathTick > 50)
            {
                
                posY += 5;
                if (Raylib.IsKeyDown(KeyboardKey.Space))
                {
                    gameManager.Restart();
                }
            }
            
        }

        public void RenderDied()
        {
            if(deathTick > 50)
            {
                Raylib.DrawText("Restart?", GameWindow.screenWidth / 2 - (int)Raylib.MeasureTextEx(Raylib.GetFontDefault(), "Restart?", 48f, 4f).X / 2, GameWindow.screenHeight / 2, 48, new Color(255,255,255,deathTick>255 ? 255 : deathTick));
            }
            
        }

        public override void Update(GameManager gameManager)
        {
            if(noMotionChange == 0)
            {
                motionY = Math.Max(-3, motionY - 0.2f);
            } else
            {
                noMotionChange--;
            }
           
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                Raylib.PlaySound(AssetLoader.wingSound);
                noMotionChange=24;

                motionY = 3;
            }

            foreach(var block in gameManager.blocks)
            {
                if (Raylib.CheckCollisionRecs(Box, block.Box1)|| Raylib.CheckCollisionRecs(Box, block.Box2))
                {
                    Raylib.PlaySound(AssetLoader.hit);
                    gameManager.died = true;
                }
            }
            if (posY > GameWindow.screenHeight - 80||posY<0)
            {
                Raylib.PlaySound(AssetLoader.hit);
                gameManager.died = true;
            }
            posY -= motionY;
           
        }
    }
}
