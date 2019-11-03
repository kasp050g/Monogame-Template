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
    public class Background : GameObject
    {
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Texture/Environment/Background/Preview1");
            layerDepth = 0.0f;
        }

        public override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
