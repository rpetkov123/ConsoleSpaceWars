using System;
using System.Collections.Generic;
using System.Threading;
using Academy.ConsoleSpaceWars;

internal class Program {

    private static bool isRunning = true;

    private static List<Entity> entities;

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

        //entities
        entities = new List<Entity>();
        entities.Add(new Player(5, 2, 10));
        entities.Add(new Enemy(100, 10, 10));
    }

    private static void CheckKeyboardInput() {
        if (Console.KeyAvailable) {
            switch (Console.ReadKey(true).Key) {
                case ConsoleKey.Escape:
                    isRunning = false;
                    return;
            }
        }
    }

    private static void Update() {
        foreach (Entity e in entities) {
            e.Update();
        }
    }

    private static void Render() {
        foreach (Entity e in entities) {
            e.Render();
        }
    }

    private static void DelayGameLoop() {
        Thread.Sleep(17);
    }
}