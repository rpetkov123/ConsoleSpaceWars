using System;
using System.Collections.Generic;
using System.Threading;
using Academy.ConsoleSpaceWars;

internal class Program {

    private static bool isRunning = true;

    private static Player player;
    private static List<UpdatableAndRenderableGameObject> updatableAndRenderable;

    private static void Main(string[] args) {

        Init();

        while (isRunning) {
            CheckKeyboardInput();

            Update();

            Render();

            DelayGameLoop();
        }

        Console.Clear();
        Console.WriteLine("Game was closed.");
        Console.CursorVisible = true;
    }

    private static void Init() {
        //console setup
        if (OperatingSystem.IsWindows()) {
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;
        }
        Console.CursorVisible = false;
        Console.Clear();

        //updatableAndRenderable
        updatableAndRenderable = new List<UpdatableAndRenderableGameObject>();

        player = new Player(5, 2, 10);
        updatableAndRenderable.Add(player);
        updatableAndRenderable.Add(new EnemySpawner());
    }

    private static void CheckKeyboardInput() {      //TODO: some kind of service maybe
        if (Console.KeyAvailable) {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            switch (pressedKey) {
                case ConsoleKey.Escape:
                    player.OnInputReceived(null);
                    isRunning = false;
                    break;

                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                case ConsoleKey.Spacebar:
                    player.OnInputReceived(pressedKey);
                    break;
            }
        } else {
            player.OnInputReceived(null);
        }
    }

    private static void Update() {
        foreach (UpdatableAndRenderableGameObject e in updatableAndRenderable) {
            e.Update();
        }
    }

    private static void Render() {
        foreach (UpdatableAndRenderableGameObject e in updatableAndRenderable) {
            e.Render();
        }
    }

    private static void DelayGameLoop() {
        Thread.Sleep(17);
    }
}