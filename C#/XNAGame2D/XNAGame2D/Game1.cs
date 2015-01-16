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
using SpriteLib;

namespace XNAGame2D
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        Model myModel;
        float aspectRatio;
        // Set the coordinates to draw the sprite at.
        Sprite Front = new Sprite(Vector2.Zero);
        Sprite Back = new Sprite(Vector2.Zero);
        Sprite Left = new Sprite(Vector2.Zero);
        Sprite Right = new Sprite(Vector2.Zero);

        //Sprite Sheet Array
        private Texture2D One;
        private Texture2D Two;
        private Texture2D Three;
        private Texture2D Four;
        private Texture2D Five;
        private Texture2D Six;

        private Texture2D[] FrontSprites;
        private Texture2D[] BackSprites;


        //Font Initialization
        private Vector2 loadingPosition = new Vector2(150, 120);
        private SpriteFont font;

        //Sprite Sort Mode
        private SpriteSortMode sortMode = SpriteSortMode.FrontToBack;
        //Sprite Blend Mode
        private SpriteBlendMode blendMode = SpriteBlendMode.AlphaBlend;

        protected override void LoadContent()
        {
            myModel = Content.Load<Model>("Models\\Helmet");
            aspectRatio = (float)graphics.GraphicsDevice.Viewport.Width /
            (float)graphics.GraphicsDevice.Viewport.Height;
            One = Content.Load<Texture2D>(@"Front\IMG00000");
            Two = Content.Load<Texture2D>(@"Front\IMG00001");
            Three = Content.Load<Texture2D>(@"Front\IMG00002");
            Four = Content.Load<Texture2D>(@"Front\IMG00003");
            Five = Content.Load<Texture2D>(@"Front\IMG00004");
            Six = Content.Load<Texture2D>(@"Front\IMG00005");

            FrontSprites = new Texture2D[6];
            FrontSprites[0] = One;
            FrontSprites[1] = Two;
            FrontSprites[2] = Three;
            FrontSprites[3] = Four;
            FrontSprites[4] = Five;
            FrontSprites[5] = Six;

            One = Content.Load<Texture2D>(@"Back\IMG00000");
            Two = Content.Load<Texture2D>(@"Back\IMG00001");
            Three = Content.Load<Texture2D>(@"Back\IMG00002");
            Four = Content.Load<Texture2D>(@"Back\IMG00003");
            Five = Content.Load<Texture2D>(@"Back\IMG00004");
            Six = Content.Load<Texture2D>(@"Back\IMG00005");

            BackSprites = new Texture2D[6];
            BackSprites[0] = One;
            BackSprites[1] = Two;
            BackSprites[2] = Three;
            BackSprites[3] = Four;
            BackSprites[4] = Five;
            BackSprites[5] = Six;



            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>(@"Fonts\Arial");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Front.setTexture(Content.Load<Texture2D>(@"Marle (Front)"));
            Front.setSpeed(new Vector2(150.0f, 150.0f));

            Back.setTexture(Content.Load<Texture2D>(@"Marle (Back)"));
            Back.setSpeed(new Vector2(44.0f, 44.0f));

            Left.setTexture(Content.Load<Texture2D>(@"Marle (Left)"));
            //Left.setSpeed(new Vector2(25.0f, 25.0f));

            Right.setTexture(Content.Load<Texture2D>(@"sonic"));
            Right.setSpeed(new Vector2(74.0f, 74.0f));


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        //private int frame = 0;

      

        protected override void Update(GameTime gameTime)
        {
            modelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds * MathHelper.ToRadians(0.1f);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape)){
                this.Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Left.setTexture(Content.Load<Texture2D>(@"Marle (Right)"));
                Left.setPosition(new Vector2((Left.getPosition().X + 1.0f), Left.getPosition().Y));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                    Left.Animate(ref FrontSprites, 10);
                    Left.setPosition(new Vector2(Left.getPosition().X, Left.getPosition().Y + 1.0f));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Left.setTexture(Content.Load<Texture2D>(@"Marle (Left)"));
                Left.setPosition(new Vector2((Left.getPosition().X - 1.0f), Left.getPosition().Y));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Left.Animate(ref BackSprites, 10);
                Left.setPosition(new Vector2((Left.getPosition().X), Left.getPosition().Y - 1.0f));
            }
            /*if (Left.getPosition().X == 0.0f)
            {
                Left.setTexture(Content.Load<Texture2D>(@"Marle (Front)"));
            }*/


            // Move the sprite around.
            UpdateSprite(gameTime);

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        Vector3 modelPosition = Vector3.Zero;
        float modelRotation = 0.0f;
        float wheelVal = 0.0f;
        float wheelVal2 = 0.0f;
        float oldValue = 0.0f;
        // Set the position of the camera in world space, for our view matrix.
        Vector3 cameraPosition = new Vector3(0.0f, 50.0f, 500.0f);
        protected override void Draw(GameTime gameTime)
        {
            wheelVal = (float)Mouse.GetState().ScrollWheelValue - oldValue;
            oldValue = wheelVal;
            //Display Font here
           
            GraphicsDevice.Clear(Color.White);
            Matrix[] transforms = new Matrix[myModel.Bones.Count];
            myModel.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in myModel.Meshes)
            {
                // This is where the mesh orientation is set, as well as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationY(modelRotation)
                        * Matrix.CreateTranslation(modelPosition);
                    effect.View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f),
                        aspectRatio, 1.0f, 10000.0f);
                }
                /*if (modelPosition.Y < (float)graphics.GraphicsDevice.Viewport.Height)
                {
                    modelPosition += new Vector3(0.0f, 1.0f, 0.0f);
                }
                else
                {
                    modelPosition -= new Vector3(0.0f, 1.0f, 0.0f);
                }*/
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }


            spriteBatch.Begin(blendMode, sortMode, SaveStateMode.None);
            spriteBatch.DrawString(font, "Val1: " + wheelVal.ToString() + " Val2: " + wheelVal2.ToString() + " ", loadingPosition, Color.Black);
            spriteBatch.Draw(Front.getTexture(), Front.getPosition(), Color.White);
            spriteBatch.Draw(Back.getTexture(), Back.getPosition(), Color.White);
            spriteBatch.Draw(Left.getTexture(), Left.getPosition(), Color.White);
            spriteBatch.Draw(Right.getTexture(), Right.getPosition(), Color.White);
            spriteBatch.End();

            if (wheelVal > wheelVal2)
            {
                cameraPosition.Z += (float)wheelVal;
            }
            if (wheelVal < wheelVal2)
            {
                cameraPosition.Z -= (float)wheelVal;
            }
            wheelVal2 = wheelVal;
           

            // Draw the sprite.
            //Begin must be called before anything is drawn
           

            //SpriteSortMode.FrontToBack

            //Draw Font
           


          

            base.Draw(gameTime);


            // TODO: Add your drawing code here

        }
        int EO = 0;

        void UpdateSprite(GameTime gameTime)
        {
            // Move the sprite by speed, scaled by elapsed time.
            Front.setPosition(Front.getPosition() + Front.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            Back.setPosition(Back.getPosition() + Back.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            //Left.setPosition(Left.getPosition() + Left.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            Right.setPosition(Right.getPosition() + Right.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);

            int MaxX = graphics.GraphicsDevice.Viewport.Width - Front.getTexture().Width;
            int MinX = 0;
            int MaxY = graphics.GraphicsDevice.Viewport.Height - Front.getTexture().Height;
            int MinY = 0;
           
            // Check for bounce.
            Front.bounceX(MaxX, MinX);
            Front.bounceY(MaxY, MinY);

            Back.bounceX(MaxX, MinX);
            Back.bounceY(MaxY, MinY);

            Left.bounceX(MaxX, MinX);
            Left.bounceY(MaxY, MinY);

            Right.bounceX(MaxX, MinX);
            Right.bounceY(MaxY, MinY);

           
            //Accel
            Vector2 Accel = new Vector2((float)50.0, (float)50.0);
            if (EO == 0)
            {
                Front.setSpeed(Front.getSpeed() + Accel);
                Back.setSpeed(Back.getSpeed() + Accel);
                //Left.setSpeed(Left.getSpeed() + Accel);
                Right.setSpeed(Right.getSpeed() + Accel);
                EO = 1;
            }
            //Deccel
            Vector2 Deccel = new Vector2((float)50.0, (float)50.0);
            if (EO == 1)
            {
                Front.setSpeed(Front.getSpeed() + Deccel);
                Back.setSpeed(Back.getSpeed() + Deccel);
                //Left.setSpeed(Left.getSpeed() + Deccel);
                Right.setSpeed(Right.getSpeed() + Deccel);
                EO = 0;
            }
        }

    }
}
