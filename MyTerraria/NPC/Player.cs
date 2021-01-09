using System;
using MyTerraria.NPC;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyTerraria.NPC
{
    class Player : Npc
    {
        public const float PLAYER_MOVE_SPEED = 4f;
        public const float PLAYER_MOVE_SPEED_ACCELERATION = 0.2f;
        public const float PLAYER_SPTITE_POSITION_Y = 25f;

        // Цвета
        public Color HairColor = new Color(255, 0, 0);      // Цвет волос
        public Color BodyColor = new Color(255, 229, 186);  // Цвет кожи
        public Color ShirtColor = new Color(255, 255, 0);   // Цвет куртки
        public Color LegsColor = new Color(255, 76, 135);   // Цвет штанов

        // Спрайты с анимацией
        AnimSprite asHair;         // Волосы
        AnimSprite asHead;         // Голова
        AnimSprite asShirt;        // Рубашка
        AnimSprite asUndershirt;   // Рукова
        AnimSprite asHands;        // Кисти
        AnimSprite asLegs;         // Ноги
        AnimSprite asShoes;        // Обувь



        public Player(World world) : base(world)
        {
            rect = new RectangleShape(new Vector2f(Tile.TILE_SIZE * 1.5f, Tile.TILE_SIZE * 2.8f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);
            isRectVisible = false;

            // Волосы
            asHair = new AnimSprite(Content.texPlayerHair,new SpriteSheet(1,14,0,(int)Content.texPlayerHair.Size.X, (int)Content.texPlayerHair.Size.Y));
            asHair.Position = new Vector2f(0, PLAYER_SPTITE_POSITION_Y);
            asHair.Color = HairColor;
            asHair.AddAnimation("idle", new Animation(      // Анимация ожидания
                new AnimtionFrame(0,0,0.1f)
            ));
            asHair.AddAnimation("run", new Animation(      // Анимация бега
                new AnimtionFrame(0, 0, 0.1f),
                new AnimtionFrame(0, 1, 0.1f),
                new AnimtionFrame(0, 2, 0.1f),
                new AnimtionFrame(0, 3, 0.1f),
                new AnimtionFrame(0, 4, 0.1f),
                new AnimtionFrame(0, 5, 0.1f),
                new AnimtionFrame(0, 6, 0.1f),
                new AnimtionFrame(0, 7, 0.1f),
                new AnimtionFrame(0, 8, 0.1f),
                new AnimtionFrame(0, 9, 0.1f),
                new AnimtionFrame(0, 10, 0.1f),
                new AnimtionFrame(0, 11, 0.1f),
                new AnimtionFrame(0, 12, 0.1f),
                new AnimtionFrame(0, 13, 0.1f)
            ));

            // Голова
            asHead = new AnimSprite(Content.texPlayerHead, new SpriteSheet(1, 20, 0, (int)Content.texPlayerHead.Size.X, (int)Content.texPlayerHead.Size.Y));
            asHead.Position = new Vector2f(0, PLAYER_SPTITE_POSITION_Y);
            asHead.Color = BodyColor;
            asHead.AddAnimation("idle", new Animation(      // Анимация ожидания
                new AnimtionFrame(0, 0, 0.1f)
            ));
            asHead.AddAnimation("run", new Animation(      // Анимация бега
                new AnimtionFrame(0, 6, 0.1f),
                new AnimtionFrame(0, 7, 0.1f),
                new AnimtionFrame(0, 8, 0.1f),
                new AnimtionFrame(0, 9, 0.1f),
                new AnimtionFrame(0, 10, 0.1f),
                new AnimtionFrame(0, 11, 0.1f),
                new AnimtionFrame(0, 12, 0.1f),
                new AnimtionFrame(0, 13, 0.1f),
                new AnimtionFrame(0, 14, 0.1f),
                new AnimtionFrame(0, 15, 0.1f),
                new AnimtionFrame(0, 16, 0.1f),
                new AnimtionFrame(0, 17, 0.1f),
                new AnimtionFrame(0, 18, 0.1f),
                new AnimtionFrame(0, 19, 0.1f)
            ));

            // Куртка
            asShirt = new AnimSprite(Content.texPlayerShirt,new SpriteSheet(1,20,0,(int)Content.texPlayerShirt.Size.X, (int)Content.texPlayerShirt.Size.Y));
            asShirt.Position = new Vector2f(0, PLAYER_SPTITE_POSITION_Y);
            asShirt.Color = ShirtColor;
            asShirt.AddAnimation("idle", new Animation(      // Анимация ожидания
                new AnimtionFrame(0,0,0.1f)
            ));
            asShirt.AddAnimation("run", new Animation(      // Анимация бега
                new AnimtionFrame(0, 6, 0.1f),
                new AnimtionFrame(0, 7, 0.1f),
                new AnimtionFrame(0, 8, 0.1f),
                new AnimtionFrame(0, 9, 0.1f),
                new AnimtionFrame(0, 10, 0.1f),
                new AnimtionFrame(0, 11, 0.1f),
                new AnimtionFrame(0, 12, 0.1f),
                new AnimtionFrame(0, 13, 0.1f),
                new AnimtionFrame(0, 14, 0.1f),
                new AnimtionFrame(0, 15, 0.1f),
                new AnimtionFrame(0, 16, 0.1f),
                new AnimtionFrame(0, 17, 0.1f),
                new AnimtionFrame(0, 18, 0.1f),
                new AnimtionFrame(0, 19, 0.1f)
            ));

            // Рукова
            asUndershirt = new AnimSprite(Content.texPlayerUndershirt,new SpriteSheet(1,20,0,(int)Content.texPlayerUndershirt.Size.X, (int)Content.texPlayerUndershirt.Size.Y));
            asUndershirt.Position = new Vector2f(0, PLAYER_SPTITE_POSITION_Y);
            asUndershirt.Color = ShirtColor;
            asUndershirt.AddAnimation("idle", new Animation(      // Анимация ожидания
                new AnimtionFrame(0,0,0.1f)
            ));
            asUndershirt.AddAnimation("run", new Animation(      // Анимация бега
                new AnimtionFrame(0, 6, 0.1f),
                new AnimtionFrame(0, 7, 0.1f),
                new AnimtionFrame(0, 8, 0.1f),
                new AnimtionFrame(0, 9, 0.1f),
                new AnimtionFrame(0, 10, 0.1f),
                new AnimtionFrame(0, 11, 0.1f),
                new AnimtionFrame(0, 12, 0.1f),
                new AnimtionFrame(0, 13, 0.1f),
                new AnimtionFrame(0, 14, 0.1f),
                new AnimtionFrame(0, 15, 0.1f),
                new AnimtionFrame(0, 16, 0.1f),
                new AnimtionFrame(0, 17, 0.1f),
                new AnimtionFrame(0, 18, 0.1f),
                new AnimtionFrame(0, 19, 0.1f)
            ));

            // Кисти рук
            asHands = new AnimSprite(Content.texPlayerHands,new SpriteSheet(1,20,0,(int)Content.texPlayerHands.Size.X, (int)Content.texPlayerHands.Size.Y));
            asHands.Position = new Vector2f(0, PLAYER_SPTITE_POSITION_Y);
            asHands.Color = BodyColor;
            asHands.AddAnimation("idle", new Animation(      // Анимация ожидания
                new AnimtionFrame(0,0,0.1f)
            ));
            asHands.AddAnimation("run", new Animation(      // Анимация бега
                new AnimtionFrame(0, 6, 0.1f),
                new AnimtionFrame(0, 7, 0.1f),
                new AnimtionFrame(0, 8, 0.1f),
                new AnimtionFrame(0, 9, 0.1f),
                new AnimtionFrame(0, 10, 0.1f),
                new AnimtionFrame(0, 11, 0.1f),
                new AnimtionFrame(0, 12, 0.1f),
                new AnimtionFrame(0, 13, 0.1f),
                new AnimtionFrame(0, 14, 0.1f),
                new AnimtionFrame(0, 15, 0.1f),
                new AnimtionFrame(0, 16, 0.1f),
                new AnimtionFrame(0, 17, 0.1f),
                new AnimtionFrame(0, 18, 0.1f),
                new AnimtionFrame(0, 19, 0.1f)
            ));

            // Ноги
            asLegs = new AnimSprite(Content.texPlayerLegs,new SpriteSheet(1,20,0,(int)Content.texPlayerLegs.Size.X, (int)Content.texPlayerLegs.Size.Y));
            asLegs.Position = new Vector2f(0, PLAYER_SPTITE_POSITION_Y);
            asLegs.Color = LegsColor;
            asLegs.AddAnimation("idle", new Animation(      // Анимация ожидания
                new AnimtionFrame(0,0,0.1f)
            ));
            asLegs.AddAnimation("run", new Animation(      // Анимация бега
                new AnimtionFrame(0, 6, 0.1f),
                new AnimtionFrame(0, 7, 0.1f),
                new AnimtionFrame(0, 8, 0.1f),
                new AnimtionFrame(0, 9, 0.1f),
                new AnimtionFrame(0, 10, 0.1f),
                new AnimtionFrame(0, 11, 0.1f),
                new AnimtionFrame(0, 12, 0.1f),
                new AnimtionFrame(0, 13, 0.1f),
                new AnimtionFrame(0, 14, 0.1f),
                new AnimtionFrame(0, 15, 0.1f),
                new AnimtionFrame(0, 16, 0.1f),
                new AnimtionFrame(0, 17, 0.1f),
                new AnimtionFrame(0, 18, 0.1f),
                new AnimtionFrame(0, 19, 0.1f)
            ));

            // Обувь
            asShoes = new AnimSprite(Content.texPlayerShoes,new SpriteSheet(1,20,0,(int)Content.texPlayerShoes.Size.X, (int)Content.texPlayerShoes.Size.Y));
            asShoes.Position = new Vector2f(0, PLAYER_SPTITE_POSITION_Y);
            asShoes.Color = Color.Black;
            asShoes.AddAnimation("idle", new Animation(      // Анимация ожидания
                new AnimtionFrame(0,0,0.1f)
            ));
            asShoes.AddAnimation("run", new Animation(      // Анимация бега
                new AnimtionFrame(0, 6, 0.1f),
                new AnimtionFrame(0, 7, 0.1f),
                new AnimtionFrame(0, 8, 0.1f),
                new AnimtionFrame(0, 9, 0.1f),
                new AnimtionFrame(0, 10, 0.1f),
                new AnimtionFrame(0, 11, 0.1f),
                new AnimtionFrame(0, 12, 0.1f),
                new AnimtionFrame(0, 13, 0.1f),
                new AnimtionFrame(0, 14, 0.1f),
                new AnimtionFrame(0, 15, 0.1f),
                new AnimtionFrame(0, 16, 0.1f),
                new AnimtionFrame(0, 17, 0.1f),
                new AnimtionFrame(0, 18, 0.1f),
                new AnimtionFrame(0, 19, 0.1f)
            ));
        }

        public override void OnKill()
        {
            Spawn();
        }

        // Обновление персонажа
        public override void UpdateNPC()
        {
            updateMovement();

            var mousePos = Mouse.GetPosition(Program.Window);
            var tile = world.GetTileByWorldPos(mousePos);
            if (tile != null)
            {
                FloatRect tileRect = tile.GetFloatRect();
                DebugRender.AddRectangle(tileRect, Color.Green);

                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    int i = (int)(mousePos.X / Tile.TILE_SIZE);
                    int j = (int)(mousePos.Y / Tile.TILE_SIZE);
                    world.SetTile(TileType.NONE, i, j);
                }
            }
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
            target.Draw(asHead, states);
            target.Draw(asHair, states);
            target.Draw(asShirt, states);
            target.Draw(asUndershirt, states);
            target.Draw(asHands, states);
            target.Draw(asLegs, states);
            target.Draw(asShoes, states);
        }




        private void updateMovement()
        {
            bool isMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool isMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool isJump = Keyboard.IsKeyPressed(Keyboard.Key.Space) || Keyboard.IsKeyPressed(Keyboard.Key.W) ;
            bool isMove = isMoveLeft || isMoveRight;

            // Прыжок
            if(isJump && !isFly)
            {
                velocity.Y = -10f;
            }

            if(isMove)
            {
                if(isMoveLeft)
                {
                    if (movement.X > 0)
                        movement.X = 0;

                    movement.X -= PLAYER_MOVE_SPEED_ACCELERATION;
                    Direction = -1;
                }
                else if(isMoveRight)
                {
                    if (movement.X < 0)
                        movement.X = 0;

                    movement.X += PLAYER_MOVE_SPEED_ACCELERATION;
                    Direction = 1;
                }

                if (movement.X > PLAYER_MOVE_SPEED)
                    movement.X = PLAYER_MOVE_SPEED;
                else if (movement.X < -PLAYER_MOVE_SPEED)
                    movement.X = -PLAYER_MOVE_SPEED;

                // Анимация
                asHair.Play("run");
                asHead.Play("run");
                asShirt.Play("run");
                asUndershirt.Play("run");
                asHands.Play("run");
                asLegs.Play("run");
                asShoes.Play("run");

            }
            else
            {
                movement = new Vector2f();

                // Анимация
                asHair.Play("idle");
                asHead.Play("idle");
                asShirt.Play("idle");
                asUndershirt.Play("idle");
                asHands.Play("idle");
                asLegs.Play("idle");
                asShoes.Play("idle");
            }
        }


        public override void OnWallCollided()
        {

        }


    }
}
