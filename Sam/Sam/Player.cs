using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sam.Desktop;

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
        private KeyboardState kStateOld = Keyboard.GetState(); // this stores the previous frames keyboard state.
        private int radius = 56;
        private float healthTimer = 0f;


        public AnimatedSprite anim;
        public AnimatedSprite[] animations = new AnimatedSprite[4];  // creating a array that stores animated sprite objects.



        public float HealthTimer
        {
            get { return healthTimer; }
            set { healthTimer = value; }
        }



        public int Radius
        {
            get { return radius; }
           
        }





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
            if (healthTimer > 0)
            {
                healthTimer -= dt; // the healthtimer will only count down if its value is greater than 0.
            }


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


            if (isMoving)
            {

                Vector2 tempPos = position;

                switch (direction)
                {

                    case Dir.Right:
                        tempPos.X += speed * dt;                    //if this is not true then move player
                        if (!Obstacle.didCollide(tempPos, radius)) // takes the next position the player will be, and tests to see if it collides with an obstacle
                        {
                            position.X += speed * dt;
                        }
                        break;

                    case Dir.Left:
                        tempPos.X -= speed * dt;
                        if (!Obstacle.didCollide(tempPos, radius))// to move left we subtract speed + dt
                        {
                            position.X -= speed * dt;
                        }
                             
                        break;

                    case Dir.Down:
                        tempPos.Y += speed * dt;
                        if (!Obstacle.didCollide(tempPos, radius))
                        {
                            position.Y += speed * dt;
                        }
                        break;

                    case Dir.Up:
                        tempPos.Y -= speed * dt;
                        if (!Obstacle.didCollide(tempPos, radius))
                        {
                            position.Y -= speed * dt; //WILL only move plyer when thee is no obstacles in the direction
                        }
                        break;

                    default:
                        break;

                }
            }


            if (kState.IsKeyDown(Keys.Space) && kStateOld.IsKeyUp(Keys.Space))
            {
                Projectile.projectiles.Add(new Projectile(position, direction));
            }

            kStateOld = kState;
        }

    }
}
