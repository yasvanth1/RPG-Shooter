using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sam.MacOS
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;



        Texture2D player_Sprite;
        Texture2D player_Down;
        Texture2D player_Up;
        Texture2D player_Right;
        Texture2D Player_Left;
        //Loading the assets into my code
        //These are also the different sprite sheets for the player animation
        //different frames of him walking

        Texture2D eyeEnemy_Sprite;
        Texture2D snakeEnemy_Sprite;
        Texture2D bush_Sprite;
        Texture2D tree_Sprite;

        Texture2D bullet_Sprite;
        Texture2D heart_Sprite;

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
            Player_Left = Content.Load<Texture2D>("Player/playerLeft");

            eyeEnemy_Sprite = Content.Load<Texture2D>("Enemies/eyeEnemy");
            snakeEnemy_Sprite = Content.Load<Texture2D>("Enemies/snakeEnemy");
            bush_Sprite = Content.Load<Texture2D>("Obstacles/bush");
            tree_Sprite = Content.Load<Texture2D>("Obstacles/tree");

            bullet_Sprite = Content.Load<Texture2D>("Misc/bullet");
            heart_Sprite = Content.Load<Texture2D>("Misc/heart");

            //All assets are loaded here
        }

    
        protected override void Update(GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.ForestGreen);

            //TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
