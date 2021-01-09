using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//тут все ресурсы игры

namespace MyTerraria
{
    class Content
    {
        public const string CONTENT_DIR = "..\\Content\\";

        public static Texture texTile0;  //земля ground
        public static Texture texTile1;  //трава grass

        // NPC
        public static Texture texNpcSlime;  // Cлизень

        // Игрок
        public static Texture texPlayerHair;            // Волосы
        public static Texture texPlayerHands;           // Кисти рук
        public static Texture texPlayerHead;            // Голова
        public static Texture texPlayerLegs;            // Ноги
        public static Texture texPlayerShirt;           // Рубашка
        public static Texture texPlayerShoes;           // Обувь
        public static Texture texPlayerUndershirt;      // Рукова

        public static void Load()
        {
            texTile0 = new Texture(CONTENT_DIR + "Textures\\Tiles_0.png");
            texTile1 = new Texture(CONTENT_DIR + "Textures\\Tiles_1.png");

            // NPC
            texNpcSlime = new Texture(CONTENT_DIR + "Textures\\npc\\slime.png");

            // Игрок
            texPlayerHair = new Texture(CONTENT_DIR + "Textures\\player\\hair.png");
            texPlayerHands = new Texture(CONTENT_DIR + "Textures\\player\\hands.png");
            texPlayerHead = new Texture(CONTENT_DIR + "Textures\\player\\head.png");
            texPlayerLegs = new Texture(CONTENT_DIR + "Textures\\player\\legs.png");
            texPlayerShirt = new Texture(CONTENT_DIR + "Textures\\player\\shirt.png");
            texPlayerShoes = new Texture(CONTENT_DIR + "Textures\\player\\shoes.png");
            texPlayerUndershirt = new Texture(CONTENT_DIR + "Textures\\player\\undershirt.png");
        }
    }
}
