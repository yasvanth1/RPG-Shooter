using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Sam
{
    class Obstacle
    {

        protected Vector2 position; //every object will have a position
        protected int radius; //they're all gonna have a hit box that you can walk into
        protected Vector2 hitPos;


        public static List<Obstacle> obstacles = new List<Obstacle>(); // we use this list to store all the obstacles in before I can spawn them


        public Vector2 HitPos
        {
            get { return hitPos; }

        }


        public Vector2 Position
        {
            get { return position; }
        }


        public int Radius
        {
            get { return radius; } // we are not giving a set because the radius wil not be changing
        }


        public Obstacle(Vector2 newPos)
        {
            position = newPos;      // these are all the parents 
        }

        public static bool didCollide(Vector2 otherPos, int otherRad)
        {
            foreach (Obstacle o in Obstacle.obstacles) //collison testing with obstacles
            {
                int sum = o.Radius + otherRad;
                if (Vector2.Distance(o.HitPos, otherPos) < sum)
                {
                    return true;
                }
            }
            return false;
        }


    }






        class Tree : Obstacle //child
        {
            public Tree(Vector2 newPos) : base(newPos)
            {radius = 20;
            hitPos = new Vector2(position.X + 64, position.Y + 150);
            }
        }


        class Bush : Obstacle
        {
            public Bush(Vector2 newPos) : base(newPos) 
            {radius = 32;
            hitPos = new Vector2(position.X + 56, position.Y + 57);
        }
        }



    }
