using System;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sam.MacOS;

namespace Sam
{


    //Decides what the player would do.
    class Player
    {

        //I've made these private so othe values can only be accessed inside the class

        private Vector2 position = new Vector2(100, 100);
        private int health = 3;
        private int speed = 200;
        private Dir direction = Dir.Down;
        private bool isMoving = false;


        public AnimatedSprite anim;
        public AnimatedSprite[] animations = new AnimatedSprite[4];  // creating a array that stores animated sprite objects.


        public int Health
        {  // so health can be accessed outside the class
            get
            {
                return health;
            }

            set
            {
                health = value;
            }

        }

        public Vector2 Position
        {
            get
            {

                return position;
            }

        }

        public void setX(float newX)
        {
            position.X = newX;
        }

        public void setY(float newY)
        {
            position.Y = newY;
        }

        public void Update(GameTime gameTime)
        {

            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;


            anim = animations[(int)direction]; // this can be used instead of a switch statement 

            if (isMoving)
                anim.Update(gameTime); // this allows animated sprite cycle between the frames
            else 
                anim.setFrame(1); //sets frame back to standing rather than it looking like player is taking a step.



            isMoving = false; // every frame will go back to false but if the keys are down then it will be true

            // Players direction will be updated depending on what key is pressed down.

            if (kState.IsKeyDown(Keys.Right))
            {
                direction = Dir.Right;
                isMoving = true;
            }

            if (kState.IsKeyDown(Keys.Left))
            {
                direction = Dir.Left;
                isMoving = true;
            }

            if (kState.IsKeyDown(Keys.Up))
            {
                direction = Dir.Up;
                isMoving = true;
            }

            if (kState.IsKeyDown(Keys.Down))
            {
                direction = Dir.Down;
                isMoving = true;
            }


            if (isMoving == true)
            {
                switch (direction)
                {

                    case Dir.Right:
                        position.X += speed * dt;
                        break;


                    case Dir.Left:
                        position.X -= speed * dt;      // to move left we subtract speed + dt
                        break;

                    case Dir.Down:
                        position.Y += speed * dt;
                        break;

                    case Dir.Up:
                        position.Y -= speed * dt;
                        break;

                    default:
                        break;

                }
            }


        }

    }
}