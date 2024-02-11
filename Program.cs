using System.Numerics;
using System;
using System.Text;
using static Raylib_cs.Raylib;
using Raylib_cs;
using FlappyBird.Game;

namespace Examples.Core;

public class BasicWindow
{
    public static void Main()
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        new GameWindow().Init();

    }
}