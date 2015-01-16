using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SpriteLib
{
    //Default Constructor
    public class Sprite
    {
        public Sprite()
        {
            startPos = Vector2.Zero;
            position = startPos;
            AnimCounter = 0;
            textureIndex = 0;
            texture = new Texture2D(null,0,0);

        }
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            // If parameter cannot be cast to Point return false.
            Sprite p = obj as Sprite;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this == p);

        }
        public override int GetHashCode()
        {
            
        }


        
        public Sprite(Vector2 startPosition)
        {
            startPos = startPosition;
            position = startPos;
            AnimCounter = 0;
            textureIndex = 0;
            texture = new Texture2D(null,0,0);

        }
        //Copy Constructor
        public Sprite(Sprite previousSprite)
        {
            this.textureIndex = previousSprite.textureIndex; 
            this.AnimCounter = previousSprite.AnimCounter; 
            this.texture = previousSprite.texture;
            this.startPos = previousSprite.startPos;
            this.speed = previousSprite.speed;
            this.position = previousSprite.position;

        }
        public static bool operator ==(Sprite one, Sprite two)
        {
            if (one.position == two.position){
            return(true);
            }
            return(false);
        }
        public static bool operator !=(Sprite one, Sprite two)
        {
            if (one.position != two.position)
            {
                return (true);
            }
            return (false);
        }


        public string Details
        {
            get
            {
                return "I am at " + position.ToString();
            }
        }


        public void Animate(ref Texture2D[] textureArray, int negativeSpeed)
        {
            //Lower speed value = faster animation
            if (textureArray != null)
            {
                if (AnimCounter == negativeSpeed)
                {
                    texture = textureArray[textureIndex];
                    textureIndex++;
                    if ((textureIndex + 1) == textureArray.Length)
                    {
                        textureIndex = 0;
                    }
                    AnimCounter = 0;
                }
                if (negativeSpeed != 0)
                {
                    AnimCounter++;
                }
            }
        }


        public void setTexture(Texture2D textureToSet)
        {
            texture = textureToSet;
        }
        public void setSpeed(Vector2 Speed)
        {
            speed = Speed;
        }
        public Texture2D getTexture()
        {
            return (texture);
        }
        public Vector2 getStartPos()
        {
            return (startPos);
        }
        public Vector2 getSpeed()
        {
            return (speed);
        }
        public void setPosition(Vector2 pos)
        {
            position = pos;
        }
        public Vector2 getPosition()
        {
            return (position);
        }
        public void bounceX(int max, int min)
        {
            if (position.X > max)
            {
                speed.X *= -1;
                position.X = max;
            }

            else if (position.X < min)
            {
                speed.X *= -1;
                position.X = min;
            }

        }
        public void bounceY(int max, int min)
        {
            if (position.Y > max)
            {
                speed.Y *= -1;
                position.Y = max;
            }

            else if (position.Y < min)
            {
                speed.Y *= -1;
                position.Y = min;
            }

        }

        private int textureIndex; //The current displayed Texture2D object
        private int AnimCounter; //Changes animation speed
        private Texture2D texture;
        private Vector2 startPos;
        private Vector2 speed;
        private Vector2 position;


    };
}
