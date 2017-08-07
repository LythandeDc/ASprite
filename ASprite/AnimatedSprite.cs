using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ASprite
{
    class AnimatedSprite : Sprite
    {
        private Texture2D Texture { get; set; }  //  sprite texture 
        private int TotalFrames;
        private int CurrentFrame;
        public Vector2 Position; //  sprite position on screen
        public float Speed = 2f; // sprite speed
        public int Rows { get; set; }
        public int Columns { get; set; }
        // Slow down frame animation
        private int TimeSinceLastFrame = 0;
        private int MillisecondsPerFrame = 200;

        public AnimatedSprite(Texture2D texture, int rows, int columns) : base(texture)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
        }

        public void Update(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if(TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;

                // increment current frame
                CurrentFrame++;

                if(CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int) ((float)CurrentFrame / Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
