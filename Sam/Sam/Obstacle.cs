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
        public static List<Obstacle> obstacles = new List<Obstacle>(); // we use this list to store all the obstacles in before I can spawn them




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
    }

        class Tree : Obstacle //child
        {
            public Tree(Vector2 newPos) : base(newPos)
            {radius = 42;}
        }


        class Bush : Obstacle
        {
            public Bush(Vector2 newPos) : base(newPos) 
            {radius = 56;}
        }



    }
