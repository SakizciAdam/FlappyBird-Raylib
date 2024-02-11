using System;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace FlappyBird.Game
{
    public class GameWindow
    {
        public static readonly int screenWidth = 800;
        public static readonly int screenHeight = 450;

        public GameManager gameManager = new GameManager();

        public void Init()
        {
            InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
            InitAudioDevice();
            Console.WriteLine("Loading");
            AssetLoader.Load();
            SetTargetFPS(144);
            gameManager.stopwatch.Start();
            gameManager.levelCounter.Start();
            gameManager.updateCounter.Start();
            while (!WindowShouldClose())
            {
                gameManager.UpdateGame();
                BeginDrawing();
                ClearBackground(Color.RayWhite);

                gameManager.RenderGame();

                EndDrawing();
            }
            CloseWindow();
        }
    }
}
