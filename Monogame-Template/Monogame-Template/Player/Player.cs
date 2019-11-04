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
        bool isAttack;

        Facing facing = Facing.Down;

        public DoAnimate doAnimate = new DoAnimate(5);
        public AnimationContainer currentAnimate = new AnimationContainer(6, 6, 0, false);

        // Attack Animation
        public AnimationContainer attackDown = new AnimationContainer(7, 10, 0, true);
        public AnimationContainer attackRigth = new AnimationContainer(7, 10, 1, true);
        public AnimationContainer attackUp = new AnimationContainer(7, 10, 2, true);
        public AnimationContainer attackLeft = new AnimationContainer(7, 10, 3, true);

        // Run Animation
        public AnimationContainer runDown = new AnimationContainer(0, 6, 0, false);
        public AnimationContainer runRigth = new AnimationContainer(0, 6, 1, false);
        public AnimationContainer runUp = new AnimationContainer(0, 6, 2, false);
        public AnimationContainer runLeft = new AnimationContainer(0, 6, 3, false);

        // Idle Animation
        public AnimationContainer idleDown = new AnimationContainer(6, 6, 0, false);
        public AnimationContainer idleRigth = new AnimationContainer(6, 6, 1, false);
        public AnimationContainer idleUp = new AnimationContainer(6, 6, 2, false);
        public AnimationContainer idleLeft = new AnimationContainer(6, 6, 3, false);


        public override void Initialize()
        {
            base.Initialize();
            doAnimate.SetAnimate(currentAnimate);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Texture/Enemys/Goblin/goblinsword");
            layerDepth = 0.5f;
        }

        // do so we only see 1 Goblin
        public override Rectangle rectangle
        {
            get
            {
                return new Rectangle(
                    (sprite.Width + 20) / 11 * doAnimate.currentIndex,
                    sprite.Height / 5 * doAnimate.animationContainer.row,
                    sprite.Width / 11,
                    sprite.Height / 5
                    );
            }
        }

        public override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            isAttack = doAnimate.retrunToOldAnimation;

            HandleInput();
            Move(gameTime);
            // run the Animates
            doAnimate.Animate(gameTime);
        }

        public void HandleInput()
        {
            velocity = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();

            // make sure we cant start a new attack befor the old attack is done.
            if (isAttack == false)
            {
                // if we attack play attack Animate
                if (keyState.IsKeyDown(Keys.Space))
                {
                    if (facing == Facing.Up)
                    {
                        doAnimate.SetAnimate(attackUp);
                    }
                    if (facing == Facing.Down)
                    {
                        doAnimate.SetAnimate(attackDown);
                    }
                    if (facing == Facing.Left)
                    {
                        doAnimate.SetAnimate(attackLeft);
                    }
                    if (facing == Facing.Rigth)
                    {
                        doAnimate.SetAnimate(attackRigth);
                    }
                    isAttack = doAnimate.retrunToOldAnimation;
                }
            }

            // make sure we cant move befor the attack is done.
            if (isAttack == false)
            {
                // if we move, move player and play run Animate
                if (keyState.IsKeyDown(Keys.W))
                {
                    velocity += new Vector2(0, -1);
                    doAnimate.SetAnimate(runUp);
                    facing = Facing.Up;
                }
                if (keyState.IsKeyDown(Keys.S))
                {
                    velocity += new Vector2(0, 1);
                    doAnimate.SetAnimate(runDown);
                    facing = Facing.Down;
                }

                if (keyState.IsKeyDown(Keys.A))
                {
                    velocity += new Vector2(-1, 0);
                    // dont play if we move Up or Down
                    if (velocity.Y == 0)
                    {
                        doAnimate.SetAnimate(runLeft);
                    }
                    facing = Facing.Left;
                }
                if (keyState.IsKeyDown(Keys.D))
                {
                    velocity += new Vector2(1, 0);
                    // dont play if we move Up or Down
                    if (velocity.Y == 0)
                    {
                        doAnimate.SetAnimate(runRigth);
                    }
                    facing = Facing.Rigth;
                }

            }



            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            // if we dont move or isAttack we play the Idle Animate
            else if (isAttack == false)
            {
                // Idle Animate
                if (facing == Facing.Up)
                {
                    doAnimate.SetAnimate(idleUp);
                }
                if (facing == Facing.Down)
                {
                    doAnimate.SetAnimate(idleDown);
                }
                if (facing == Facing.Left)
                {
                    doAnimate.SetAnimate(idleLeft);
                }
                if (facing == Facing.Rigth)
                {
                    doAnimate.SetAnimate(idleRigth);
                }
            }
        }
    }
}
