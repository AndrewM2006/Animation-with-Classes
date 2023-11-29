using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Animation_with_Classes
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Song bling;
        int amount;
        Texture2D tribbleGreyTexture;
        List <Tribble> tribbles = new List<Tribble> ();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            amount = 3;
            Random generator = new Random();
            this.bling = Content.Load<Song>("Bling");
            for (int i = 0; i < amount; i++)
            {
                tribbles.Add(new Tribble(tribbleGreyTexture, bling));
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            for (int i = 0; i < amount; i++)
            {
                tribbles[i].Move(_graphics);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            for (int i = 0;i < amount;i++)
            {
                _spriteBatch.Draw(tribbles[i].Texture, tribbles[i].Bounds, tribbles[i].Color);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}