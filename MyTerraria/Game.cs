using MyTerraria.NPC;
using SFML.System;
using System.Collections.Generic;

//тут обрабатывается вся логика игры

//Мир(World) делится на chunks а chunks на тайлы(tile)


namespace MyTerraria
{
    class Game
    {
        World world;       // Мир
        Player player;     // Игрок
        NpcFastSlime slime;    // Быстрый слизень


        // Слизни
        List<NpcSlime> slimes = new List<NpcSlime>();

        public Game()
        {
            // Создаем новый мир и выполняем его генерацию
            world = new World();
            world.GenerateWorld(555);

            // Создаем игрока
            player = new Player(world);
            player.StartPosition = new Vector2f(300,150);
            player.Spawn();

            // Создаем быстрого слизня
            slime = new NpcFastSlime(world);
            slime.StartPosition = new Vector2f(500, 150);
            slime.Spawn();

            // Создаем коллекцию из 50 слизней
            for (int i = 0; i < 5; i++)
            {
                var s = new NpcSlime(world);
                s.StartPosition = new Vector2f(World.Rand.Next(150, 600), 150);
                s.Direction = World.Rand.Next(0, 2) == 0 ? 1 : -1 ;
                s.Spawn();
                slimes.Add(s);
            }

            // Включаем прорисовку объектов для визуальной отладки
            DebugRender.Enabled = true;

        }

        // Обновление логики игры
        public void Update()
        {
            player.Update();
            slime.Update();

            foreach (var s in slimes)
                s.Update();
        }

        // Прорисовка игры
        public void Draw()
        {
            Program.Window.Draw(world);          // Рисуем мир 
            Program.Window.Draw(player);         // Рисуем игрока
            Program.Window.Draw(slime);          // Рисуем слизня

            foreach (var s in slimes)
                Program.Window.Draw(s);          // Рисуем слизней

            DebugRender.Draw(Program.Window);    // Рисуем объекты для визуальной отладки

        }
    }
}
