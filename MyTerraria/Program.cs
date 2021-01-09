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
        

        public static RenderWindow Window { private set; get; }
        public static Game Game { private set; get; }
        


        static void Main(string[] args)
        {
            //создание параметров окна
            Window = new RenderWindow(new SFML.Window.VideoMode(800,600),"Моя Terraria!");
            //вертикальная синхронизация
            Window.SetVerticalSyncEnabled(true);

            //обработка закрытия окна
            Window.Closed += Win_Closed;
            //обработка при изменении размера окна
            Window.Resized += Win_Resized;

            //загрузка контента
            Content.Load();

            Game = new Game();      // Создаем новый объект класса игры
            

            // цыкл обработки окна
            while (Window.IsOpen)
            {
                //обработчик событий
                Window.DispatchEvents();

                //метод обновления игры
                Game.Update();

                //очистка экрана в черный цвет
                Window.Clear(Color.Black);

                //рисуем здесь!
                //метод для прорисовки игры
                Game.Draw();

                Window.Display();
            }
        }

        //обработка при изменении размера окна
        private static void Win_Resized(object sender, SizeEventArgs e)
        {
            Window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));        
        }

        //обработка закрытия окна
        private static void Win_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
