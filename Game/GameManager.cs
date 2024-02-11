using FlappyBird.Game.Objects;
using FlappyBird.Game.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace FlappyBird.Game
{
    public class GameManager
    {
        public Player player = new Player();
        public List<Block> blocks = new List<Block>();
        public Stopwatch stopwatch = new Stopwatch();
        public Stopwatch levelCounter = new Stopwatch();
        public Stopwatch updateCounter=new Stopwatch();
        public int nextWait = 400;


        public int GameHardness = 1;
        public int ticks = 0;

        public bool died;

        public void UpdateGame()
        {
            if (updateCounter.ElapsedMilliseconds < 5)
            {
                return;
            }
            updateCounter.Restart();
            if (died)
            {
                player.UpdateDied(this);
                return;
            }
            
     
            ticks+=(int) ((float)GameHardness * 0.05f + 2);
            
            //check for input
            player.Update(this);

            if(levelCounter.ElapsedMilliseconds > 1000)
            {
                
                GameHardness++;
                if (GameHardness > 100)
                {
                    GameHardness = 100;
                    levelCounter.Stop();
                }
                levelCounter.Restart();
            }

            if(stopwatch.ElapsedMilliseconds > nextWait)
            {
       
                blocks.Add(new Block(300- GameHardness*2, GameHardness+ RandomUtils.NextInt(60, 100)));
                nextWait = 700 - GameHardness * 2 + RandomUtils.NextInt(10,100);
                stopwatch.Restart();
            }
            foreach(var block in blocks)
            {
                block.Update(this);
            }
        }

        public void Restart()
        {
            stopwatch.Restart();
            levelCounter.Restart();
            updateCounter.Restart();
            blocks.Clear();
            ticks = 0;
            died=false;
            player = new Player();
        }

        public void RenderGame()
        {
            Raylib.DrawTexturePro(AssetLoader.background, new Rectangle(ticks, 0, GameWindow.screenWidth, GameWindow.screenHeight), new Rectangle(0, 0, GameWindow.screenWidth, GameWindow.screenHeight), new System.Numerics.Vector2(0, 0), 0, Color.White);
            player.Render(this);
            
            foreach (var block in blocks)
            {
                block.Render(this);
            }
            Raylib.DrawTexturePro(AssetLoader.platformBase, new Rectangle(ticks, 0, GameWindow.screenWidth, 112), new Rectangle(0, GameWindow.screenHeight - 60, GameWindow.screenWidth, 112), new System.Numerics.Vector2(0, 0), 0, Color.White);
            if (died)
            {
                player.RenderDied();
            }
        }
    }
}
