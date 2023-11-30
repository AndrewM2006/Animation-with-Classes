using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Texture2D tribbleBGTexture;
        SpriteFont pressKey;
        Texture2D shipBGTexture;
        List <Tribble> tribbles = new List<Tribble> ();

        enum Screen
        {
            Intro,
            Tribbles
        }
        Screen screen;
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
            screen = Screen.Intro;
            amount = 20;
            Random generator = new Random();
            for (int i = 0; i < amount; i++)
            {
                tribbles.Add(new Tribble(tribbleGreyTexture, bling));
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleBGTexture = Content.Load<Texture2D>("TribblesBG");
            this.bling = Content.Load<Song>("Bling");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            shipBGTexture = Content.Load<Texture2D>("Ship");
            pressKey = Content.Load<SpriteFont>("PressKey");
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (screen == Screen.Intro)
            {
                var keys = Keyboard.GetState().GetPressedKeys();
                if (keys.Count() > 0)
                {
                    screen = Screen.Tribbles;
                }
            }
            else if (screen == Screen.Tribbles)
            {
                for (int i = 0; i < amount; i++)
                {
                    tribbles[i].Move(_graphics);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleBGTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                _spriteBatch.DrawString(pressKey,"Press any Key to Advance", new Vector2(20, 340), Color.Red);
            }
            else if (screen == Screen.Tribbles)
            {
                _spriteBatch.Draw(shipBGTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                for (int i = 0; i < amount; i++)
                {
                    tribbles[i].Draw(_spriteBatch);
                }
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}