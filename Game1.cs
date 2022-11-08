using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.CompilerServices;

namespace Monogame_Assignment_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D background;
        private Texture2D image1;
        private Texture2D image2;
        private Texture2D image3;
        private Texture2D image4;
        private Texture2D image5;
        private Texture2D imageFly;
        private static Random rand = new Random();
        private int bg = rand.Next(1, 4);
        private Vector2 location;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "Rainy Day with Annoying Fly";
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 400;
            _graphics.ApplyChanges();
            location = new Vector2(rand.Next(0, 700), rand.Next(0, 318));
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            if (bg == 1)
                background = Content.Load<Texture2D>("bg-1");
            else if (bg == 2)
                background = Content.Load<Texture2D>("bg-2");
            else if (bg == 3)
                background = Content.Load<Texture2D>("bg-3");
            image1 = Content.Load<Texture2D>("light");
            image2 = Content.Load<Texture2D>("rain");
            image3 = Content.Load<Texture2D>("cloud");
            image4 = Content.Load<Texture2D>("tree2");
            image5 = Content.Load<Texture2D>("person");
            imageFly = Content.Load<Texture2D>("fly");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            for (int j = 85; j<400; j+= 133)
            {
                for (int i = 0; i < 800; i += 200)
                {
                    _spriteBatch.Draw(image2, new Vector2(i, j), Color.White);
                }
            }
            for (int i = -30; i < 800; i += 180)
            {
                _spriteBatch.Draw(image3, new Vector2(i, -10), Color.White);
            }
            for (int i = 20; i < 800; i += 150)
            {
                _spriteBatch.Draw(image1, new Vector2(i, 85), Color.White);
            }
            _spriteBatch.Draw(image4, new Vector2(0, 200), Color.Blue);
            _spriteBatch.Draw(image5, new Vector2(500, 300), Color.White);
            _spriteBatch.Draw(imageFly, location, Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}