using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sam.MacOS
{

    enum Dir{

        Down,
        Up,
        Left,
        Right,

    }



    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;



        Texture2D player_Sprite;
        Texture2D player_Down;
        Texture2D player_Up;
        Texture2D player_Right;
        Texture2D player_Left;
        //Loading the assets into my code
        //These are also the different sprite sheets for the player animation
        //different frames of him walking

        Texture2D eyeEnemy_Sprite;
        Texture2D snakeEnemy_Sprite;
        Texture2D bush_Sprite;
        Texture2D tree_Sprite;

        Texture2D bullet_Sprite;
        Texture2D heart_Sprite;


        Player player = new Player();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 600;

        }

    
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player_Sprite = Content.Load<Texture2D>("Player/player");
            player_Down = Content.Load<Texture2D>("Player/playerDown");
            player_Up = Content.Load<Texture2D>("Player/playerUp");
            player_Right = Content.Load<Texture2D>("Player/playerRight");
            player_Left = Content.Load<Texture2D>("Player/playerLeft");

            eyeEnemy_Sprite = Content.Load<Texture2D>("Enemies/eyeEnemy");
            snakeEnemy_Sprite = Content.Load<Texture2D>("Enemies/snakeEnemy");
            bush_Sprite = Content.Load<Texture2D>("Obstacles/bush");
            tree_Sprite = Content.Load<Texture2D>("Obstacles/tree");

            bullet_Sprite = Content.Load<Texture2D>("Misc/bullet");
            heart_Sprite = Content.Load<Texture2D>("Misc/heart");

            //All assets are loaded here

            player.animations[0] = new AnimatedSprite(player_Down, 1, 4);
            player.animations[1] = new AnimatedSprite(player_Up, 1, 4);
            player.animations[2] = new AnimatedSprite(player_Left, 1, 4);
            player.animations[3] = new AnimatedSprite(player_Right, 1, 4);

            Enemy.enemies.Add(new Snake(new Vector2(100, 400)));
            Enemy.enemies.Add(new Eye(new Vector2(300, 450)));



        }

    
        protected override void Update(GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            foreach (Projectile proj in Projectile.projectiles ){
                proj.Update(gameTime);   // looks at the current projectile in the projectiles list.
            }

            foreach (Enemy en in Enemy.enemies){
                 en.Update(gameTime, player.Position);
            }


            foreach (Projectile proj in Projectile.projectiles){   // If this is all true then there 
                foreach (Enemy en in Enemy.enemies){                // has been a collison between the current proj and Enemy
                    int sum = proj.Radius + en.Radius;
                    if (Vector2.Distance(proj.Position, en.Position) < sum){   // if that's the case the destroy the projectile
                                                                                // so it does't go through the enemy.

                    }
                }
            }
           
                    
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.ForestGreen);

            player.anim.Draw(spriteBatch, new Vector2(player.Position.X - 48, player.Position.Y -48));

            spriteBatch.Begin();

            foreach (Enemy en in Enemy.enemies){
                Texture2D spriteToDraw;
                int rad;

                if (en.GetType() == typeof(Snake)){
                    spriteToDraw = snakeEnemy_Sprite;
                    rad = 50;

                } else {
                    spriteToDraw = eyeEnemy_Sprite;
                    rad = 73;
                }
                spriteBatch.Draw(spriteToDraw, new Vector2(en.Position.X - rad, en.Position.Y - rad),Color.White); // makes enemy follow from center of sprite.
            }


            foreach (Projectile proj in Projectile.projectiles){
                spriteBatch.Draw(bullet_Sprite, new Vector2(proj.Position.X-proj.Radius, proj.Position.Y-proj.Radius), Color.White); // creating a vector so bullets are fired from the center of player.
            }

                spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
