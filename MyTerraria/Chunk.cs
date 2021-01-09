using SFML.Graphics;
using SFML.System;

//матрица состоящая из плиток

namespace MyTerraria
{
    class Chunk : Transformable, Drawable
    {
        //количество тайлов в одном чанге по ширине и высоте
        public const int CHUNK_SIZE = 25;

        //двумерный массив из плиток
        Tile[][] titels;
        // Позиция чанга в массиве мира
        Vector2i chunkPos;

        //конструктор класса
        public  Chunk(Vector2i chunkPos )
        {
            // Выставляем позицию чанга
            this.chunkPos = chunkPos;
            Position = new Vector2f(chunkPos.X * CHUNK_SIZE*Tile.TILE_SIZE, chunkPos.Y * CHUNK_SIZE*Tile.TILE_SIZE);

            // Создаем двумерный массив тайлов
            titels = new Tile[CHUNK_SIZE][];

            for (int i = 0; i < CHUNK_SIZE; i++)        
                titels[i] = new Tile[CHUNK_SIZE];

          
        }

        // Установить плитку в чанке
        public void SetTite(TileType type, int x, int y, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            titels[x][y] = new Tile(type, upTile, downTile, leftTile, rightTile);
            titels[x][y].Position = new Vector2f(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE) + Position;
        }

        // Получит плитку в чанке
        public Tile GetTite(int x, int y)
        {
            // Если позиция плитки выходит за границу цанка
            if (x < 0 || y < 0 || x >= CHUNK_SIZE || y >= CHUNK_SIZE)
                return null;  // то возвращаем null

            // Иначе возвращаем плитку даже если она равна null
            return titels[x][y];
        }

        // Рисуем чанг и его содержимое
        public void Draw(RenderTarget target, RenderStates states)
        {
            

            //рисуем тайлы
            for (int x = 0; x < CHUNK_SIZE; x++)
            {
                for (int y = 0; y < CHUNK_SIZE; y++)
                {
                    //если плитка не определена то пропускаем ее прорисовку
                    if (titels[x][y] == null) continue; 
                    

                    target.Draw(titels[x][y]);
                }
            }
        }
    }
}
