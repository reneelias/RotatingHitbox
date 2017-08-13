using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace RotatingHitbox
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BouncingRectangle bouncingRect, bouncingRect2;
        List<BouncingRectangle> bouncingRects;
        Random random;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            random = new Random();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bouncingRects = new List<BouncingRectangle>();
            for(int i = 0; i < 2; i++)
            {
                int size = random.Next(20, 100);
                bouncingRects.Add(new BouncingRectangle(Content.Load<Texture2D>("WhitePixel"), new Vector2(random.Next(75, GraphicsDevice.Viewport.Width - 75), random.Next(75, GraphicsDevice.Viewport.Height - 75)), Color.IndianRed, new Vector2(size, size), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), .025f, new Vector2(random.Next(3, 6), random.Next(3, 6))));
            }
            //bouncingRect = new BouncingRectangle(Content.Load<Texture2D>("WhitePixel"), new Vector2(50, 50), Color.IndianRed, new Vector2(80, 80), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), .025f, new Vector2(5, 5));
            //bouncingRect2 = new BouncingRectangle(Content.Load<Texture2D>("WhitePixel"), new Vector2(200, 200), Color.Black, new Vector2(50, 50), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), .02f, new Vector2(5, 5));
        }

        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            //bouncingRect.Update(gameTime);
            //bouncingRect2.Update(gameTime);
            //bouncingRect.CollideWithRectangle(bouncingRect2);
            for (int i = 0; i < bouncingRects.Count; i++)
            {
                bouncingRects[i].Update(gameTime);
                for (int j = i + 1; j < bouncingRects.Count; j++)
                {
                    bouncingRects[i].CollideWithRectangle(bouncingRects[j]);
                }
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PapayaWhip);
            spriteBatch.Begin();
            //bouncingRect.Draw(spriteBatch);
            //bouncingRect2.Draw(spriteBatch);
            foreach(BouncingRectangle rect in bouncingRects)
            {
                rect.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
