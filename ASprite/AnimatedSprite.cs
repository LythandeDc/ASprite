using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ASprite
{
    class AnimatedSprite
    {
        private Texture2D Texture { get; set; }  //  sprite texture 
        public Texture2D spriteLeft { set; get; }  //  sprite texture 
        public Texture2D spriteRight { set; get; }  //  sprite texture 
        public Texture2D spriteUp { set; get; }  //  sprite texture 
        public Texture2D spriteDown { set; get; }  //  sprite texture 
        private int TotalFrames;
        private int CurrentFrame;
        public int Rows { get; set; }
        public int Columns { get; set; }
        // Slow down frame animation
        private int TimeSinceLastFrame = 0;
        private int MillisecondsPerFrame = 200;
        public Vector2 spritePosition; //  sprite position on screen
        Vector2 origin = new Vector2(0, 0);
        public float spriteSpeed = 2f; // sprite speed
        private float Angle = 0f;

        public AnimatedSprite(Texture2D texture, Texture2D left, Texture2D right, 
                              Texture2D up, Texture2D down, int rows, int columns)
        {
            Texture = texture;
            spriteLeft = left;
            spriteRight = right;
            spriteUp = up;
            spriteDown = down;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
        }

        private void animateSprite(GameTime v)
        {
            TimeSinceLastFrame += v.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;

                // increment current frame
                CurrentFrame++;

                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            // Left
            if (Keyboard.GetState().IsKeyDown(Keys.Q) ||
               Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                animateSprite(gameTime);
                spritePosition.X -= spriteSpeed;
                Texture = spriteLeft;
            }

            // Right
            if (Keyboard.GetState().IsKeyDown(Keys.D) ||
               Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                animateSprite(gameTime);
                spritePosition.X += spriteSpeed;
                Texture = spriteRight;
            }

            // Up
            if (Keyboard.GetState().IsKeyDown(Keys.Z) ||
               Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                animateSprite(gameTime);
                spritePosition.Y -= spriteSpeed;
                Texture = spriteUp;
            }

            // Down
            if (Keyboard.GetState().IsKeyDown(Keys.S) ||
               Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                animateSprite(gameTime);
                spritePosition.Y += spriteSpeed;
                Texture = spriteDown;
            }           
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, spritePosition, sourceRectangle, Color.White, Angle, origin, 1.0f, SpriteEffects.None, 1);
            spriteBatch.End();
        }
    }
}
