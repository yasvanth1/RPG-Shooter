using System;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sam
{


    //Decides what the player would do.
    class Player
    {

        //I've made these private so othe values can only be accessed inside the class

        private Vector2 position = new Vector2(100, 100);
        private int health = 3;
        private int speed = 200;

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
    
        public void setX(float newX){

            position.X = newX;

        }

        public void setY(float newY)
        {

            position.Y = newY;

        }




    }

}