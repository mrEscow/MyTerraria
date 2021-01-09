using SFML.Graphics;
using SFML.System;

//плитки

namespace MyTerraria
{
    //перечисление типов плитки
    enum TileType 
    {
        NONE,      //пусто
        GROUND,    //почва
        GRASS      //земляной блок с травой
    }

    class Tile : Transformable, Drawable
    {
        //количество тайла по ширине и высоте 
        public const int TILE_SIZE = 16;

   
        TileType type = TileType.GROUND;      // Тип плиток
        RectangleShape rectShape;             // Объявим прямоугольную форму плиток
        SpriteSheet spriteSheet;              // Набор спрайта плитки

        //Соседи
        Tile upTile = null;       //Верхний сосед
        Tile downTile = null;     //Нижний сосед
        Tile leftTile = null;     //Левый сосед
        Tile rightTile = null;    //Правый сосед

        // Верхний сосед
        public Tile UpTile
        {
            set
            {
                upTile = value;
                UpdateView(); // Обновляем вид плитки

            }
            get
            {
                return upTile;
            }
        }
        // Нижний сосед
        public Tile DownTile
        {
            set
            {
                downTile = value;
                UpdateView(); // Обновляем вид плитки

            }
            get
            {
                return downTile;
            }
        }
        // Левый сосед
        public Tile LeftTile
        {
            set
            {
                leftTile = value;
                UpdateView(); // Обновляем вид плитки

            }
            get
            {
                return leftTile;
            }
        }
        // Правый сосед
        public Tile RightTile
        {
            set
            {
                rightTile = value;
                UpdateView(); // Обновляем вид плитки

            }
            get
            {
                return rightTile;
            }
        }


        //конструктор класса
        public Tile(TileType type, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            this.type = type;

            // Присваеваем соседий а соседям эту плитку
            if(upTile!=null)
            {
                this.upTile = upTile;
                this.upTile.DownTile = this; // Для верхнего соседа эта плитка будет нижним соседом
            }
            if (downTile != null)
            {
                this.downTile = downTile;
                this.downTile.UpTile = this; // Для нижнего соседа эта плитка будет верхним соседом
            }
            if (leftTile != null)
            {
                this.leftTile = leftTile;
                this.leftTile.RightTile = this; // Для левого соседа эта плитка будет правым соседом
            }
            if (rightTile != null)
            {
                this.rightTile = rightTile;
                this.rightTile.LeftTile = this; // Для правого соседа эта плитка будет левым соседом
            }

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));


            switch (type)
            {
               
                case TileType.GROUND:
                    rectShape.Texture = Content.texTile0;   //почва
                    break;
                case TileType.GRASS:
                    rectShape.Texture = Content.texTile1;   //земляной блок с травой
                    break;


            }

            // Объявляем набор спрайтов для плитки
            spriteSheet = new SpriteSheet(TILE_SIZE, TILE_SIZE, 1);

            // Обновляем внешний вид плитки в зависимости от соседий
            UpdateView();
        }

        // Обновляем внешний вид плитки в зависимости от соседий
        public void UpdateView()
        {
            // Если у плитки есть все соседи
            if(upTile != null && downTile != null && leftTile != null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(1 + i, 1);
            }
            // Если у плитки отсутствуют все соседи
            else if (upTile == null && downTile == null && leftTile == null && rightTile == null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(9 + i, 1);
            }

            //---------------------------------------------------------------------------------

            // Если у плитки отсутствует только верхний сосед
            else if (upTile == null && downTile != null && leftTile != null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(1 + i, 0);
            }
            // Если у плитки отсутствует только нижний сосед
            else if (upTile != null && downTile == null && leftTile != null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(1 + i, 2);
            }
            // Если у плитки отсутствует только левый сосед
            else if (upTile != null && downTile != null && leftTile == null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(0, i);
            }
            // Если у плитки отсутствует только правый сосед
            else if (upTile != null && downTile != null && leftTile != null && rightTile == null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(4, i);
            }

            //---------------------------------------------------------------------------------

            // Если у плитки отсутствует только верхний и левый сосед
            else if (upTile == null && downTile != null && leftTile == null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(0 + i*2, 3);
            } 
            // Если у плитки отсутствует только верхний и правый сосед
            else if (upTile == null && downTile != null && leftTile != null && rightTile == null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(1 + i*2, 3);
            }
            // Если у плитки отсутствует только левый и нижний сосед
            else if (upTile != null && downTile == null && leftTile == null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(0+i*2, 4);
            }
            // Если у плитки отсутствует только правый и нижний сосед
            else if (upTile != null && downTile == null && leftTile != null && rightTile == null)
            {
                int i = World.Rand.Next(0, 3); // Случайное число от 0 до 2
                rectShape.TextureRect = spriteSheet.GetTextureRect(1+ i*2,4);
            }  

        }

        // Рисуем плитку
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape, states);
        }

        public FloatRect GetFloatRect()
        {
            return new FloatRect(Position, new Vector2f(TILE_SIZE, TILE_SIZE));
        }
    }
}
