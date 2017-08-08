using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ASprite
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Sprite _sprite1;
        private AnimatedSprite animSprite;
        Texture2D newtexture;
        Texture2D up;
        Texture2D right;
        Texture2D left;
        Texture2D down;

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
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var texture = Content.Load<Texture2D>("dead");
            _sprite1 = new Sprite(texture);
            _sprite1.Position = new Vector2(50, 50);

            newtexture = Content.Load<Texture2D>("images/Down");
            left = Content.Load<Texture2D>("images/Left");
            right = Content.Load<Texture2D>("images/Right");
            up = Content.Load<Texture2D>("images/Up");
            down = Content.Load<Texture2D>("images/Down");

            animSprite = new AnimatedSprite(newtexture, left, right, up, down, 1, 4);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _sprite1.Update();
            animSprite.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Q) ||
              Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                newtexture = Content.Load<Texture2D>("images/Left");
            }

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // spriteBatch.Begin();
            // _sprite1.Draw(spriteBatch);
            animSprite.Draw(spriteBatch, new Vector2(200, 200));
            // spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
