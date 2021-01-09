using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTerraria
{
    class Program
    {
        //создание окна
        static RenderWindow win;

        public static RenderWindow Window { get {return win;} }
        public static Game Game { private set; get; }
        public static Random Rand { private set; get; }


        static void Main(string[] args)
        {
            //создание параметров окна
            win = new RenderWindow(new SFML.Window.VideoMode(800,600),"Моя Terraria!");
            //вертикальная синхронизация
            win.SetVerticalSyncEnabled(true);

            //обработка закрытия окна
            win.Closed += Win_Closed;
            //обработка при изменении размера окна
            win.Resized += Win_Resized;

            //загрузка контента
            Content.Load();

            Rand = new Random();    // Создаем новый объект рандома 
            Game = new Game();      // Создаем новый объект класса игры
            

            // цыкл обработки окна
            while (win.IsOpen)
            {
                //обработчик событий
                win.DispatchEvents();

                //метод обновления игры
                Game.Update();

                //очистка экрана в черный цвет
                win.Clear(Color.Black);

                //рисуем здесь!
                //метод для прорисовки игры
                Game.Draw();

                win.Display();
            }
        }

        //обработка при изменении размера окна
        private static void Win_Resized(object sender, SizeEventArgs e)
        {
            win.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));        
        }

        //обработка закрытия окна
        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
