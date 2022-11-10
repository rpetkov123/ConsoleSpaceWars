using System;
using System.Collections.Generic;
using System.Threading;
using Academy.ConsoleSpaceWars;

internal class Program {

    private static bool isRunning = true;
    private static int score = 0;

    private static Player player;
    private static EnemySpawner spawner;

    private static HealthBar healthbar;
    private static Score scoreGraphic;
    private static ExplosionManager explosionManager;

    private static List<UpdatableAndRenderableGameObject> updatableAndRenderable;

    private static void Main(string[] args) {

        Init();

        while (isRunning) {
            CheckKeyboardInput();

            CheckCollisions();

            Update();

            Render();

            DelayGameLoop();
        }

        Destroy();
    }

    private static void Init() {
        // console setup
        if (OperatingSystem.IsWindows()) {
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;
        }
        Console.CursorVisible = false;
        Console.Clear();

        // updatableAndRenderable
        updatableAndRenderable = new List<UpdatableAndRenderableGameObject>();

        player = new Player(Console.WindowHeight / 2, 5);
        updatableAndRenderable.Add(player);

        spawner = new EnemySpawner();
        updatableAndRenderable.Add(spawner);

        // UI
        healthbar = new HealthBar(0, 1, player.CurrentHealth, player.MaxHealth);
        player.OnHealthChanged += OnPlayerhealthChange;

        scoreGraphic = new Score(50, 1, score);
        spawner.OnEnemyDestroyed += OnEnemyDestroyed;

        explosionManager = new ExplosionManager();
        updatableAndRenderable.Add(explosionManager);
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

    private static void CheckCollisions() {
        CheckPlayerBulletsCollision();
        CheckEnemyPlayerCollision();
        CheckEnemyBulletsPlayerCollision();
    }

    private static void CheckPlayerBulletsCollision() {
        for (int i = 0; i < player.Bullets.Count; i++) {
            if (spawner.IsPlayerBulletCollidingWithEnemy(player.Bullets[i])) {
                player.Bullets[i].Destroy();
                player.Bullets.RemoveAt(i);

                i--;
            }
        }
    }

    private static void CheckEnemyPlayerCollision() {
        if (spawner.IsPlayerCollidingWithEnemy(player)) {
            player.ApplyDamage(1);
        }
    }

    private static void CheckEnemyBulletsPlayerCollision() {
        if (spawner.IsEnemyBulletsCollidingWithPlayer(player)) {
            player.ApplyDamage(1);
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

        RenderUi();     //call this method last to render the UI on top of everything else
    }

    private static void RenderUi() {
        healthbar.Render();
        scoreGraphic.Render();
    }

    private static void OnPlayerhealthChange(int value) {
        healthbar.SetHealth(value);
    }

    private static void OnEnemyDestroyed(EnemyDestroyedData data) {
        score += data.score;
        scoreGraphic.SetScore(score);

        explosionManager.SpawnExplosionAt(data.x, data.y);
    }

    private static void DelayGameLoop() {
        Thread.Sleep(17);
    }

    private static void Destroy() {
        player.OnHealthChanged -= OnPlayerhealthChange;
        spawner.OnEnemyDestroyed -= OnEnemyDestroyed;

        Console.Clear();
        Console.WriteLine("Game was closed.");
        Console.WriteLine("Score: " + scoreGraphic.CurrentScore);
        Console.CursorVisible = true;
    }
}