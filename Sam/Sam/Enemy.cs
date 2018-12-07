using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sam.Desktop;



namespace Sam
{
    class Enemy
    {

        private Vector2 position;
        protected int health; //protected means the child classes can apply their own custom values within their own class.
        protected int speed;
        protected int radius;

        public static List<Enemy> enemies = new List<Enemy>();



        public int Health
        {

            get { return health; }
            set { health = value; }

        }

        public Vector2 Position
        {
            get { return position; }
        }


        public int Radius
        {
            get { return radius; }
        }

        //public int Speed{
        //    get { return speed; }
        //}



        public Enemy(Vector2 newPos)
        { // base constructor 
            position = newPos;
        }



        public void Update(GameTime gameTime, Vector2 playerPos)
        {

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 moveDir = playerPos - position; // points from the enemy to the direction of the player
            moveDir.Normalize();
            position += moveDir * speed * dt; //position has x&y values of enemies and moveDir has the x&y values pointing towards the player
                                              // * dt will protect it from any frame rate drops or increases
        }
    }







    class Snake : Enemy
    {

        public Snake(Vector2 newPos) : base(newPos)
        {  // gets the newPos variable and passes it to the base contructor.

            speed = 110;
            radius = 42;
            health = 3;
        }

    }

    class Eye : Enemy
    {

        public Eye(Vector2 newPos) : base(newPos)
        {
            speed = 90;
            radius = 45;
            health = 5;

        }
    }
}
