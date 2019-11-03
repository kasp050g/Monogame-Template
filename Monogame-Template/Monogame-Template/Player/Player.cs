using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Monogame_Template
{
    public class Player : Character
    {
          

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Texture/Player/playerImage");
            layerDepth = 0.5f;
        }

        public override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
            Move(gameTime);
        }

        public void HandleInput()
        {
            velocity = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, 1);
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
        }
    }
}
