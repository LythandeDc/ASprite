using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASprite
{
    public class Sprite
    {
        private Texture2D _texture; //  sprite texture 
        public Vector2 Position; //  sprite position on screen
        public float Speed = 2f; // sprite speed

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            // Left
            if(Keyboard.GetState().IsKeyDown(Keys.Q) ||
               Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Position.X -= Speed;
            }

            // Right
            if (Keyboard.GetState().IsKeyDown(Keys.D) ||
               Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Position.X += Speed;
            }

            // Up
            if (Keyboard.GetState().IsKeyDown(Keys.Z) ||
               Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Position.Y -= Speed;
            }

            // Down
            if (Keyboard.GetState().IsKeyDown(Keys.S) ||
               Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Position.Y += Speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Adds a sprite to a batch of sprites for rendering using the specified texture, 
            // position, source rectangle, color, rotation, origin, scale, effects and layer.
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
