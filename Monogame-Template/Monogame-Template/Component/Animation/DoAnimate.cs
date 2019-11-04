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
    public class DoAnimate
    {
        float fps = 10;
        float timeElapsed;
        public int currentIndex;

        public bool retrunToOldAnimation = false;

        public AnimationContainer animationContainer;
        public AnimationContainer lastAnimationContainer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fps">how many frames per second will be shown</param>
        public DoAnimate(float fps)
        {
            this.fps = fps;
        }

        /// <summary>
        /// Set the current animation.
        /// </summary>
        /// <param name="animationContainer"></param>
        public void SetAnimate(AnimationContainer animationContainer)
        {
            // if it not the same AnimationContainer
            if (animationContainer != this.animationContainer)
            {
                // Make sure that we dont try to save a null.
                if (this.animationContainer != null)
                {
                    lastAnimationContainer = this.animationContainer;
                }

                this.animationContainer = animationContainer;                
                this.retrunToOldAnimation = animationContainer.retrunToOldAnimation;
                // set timeElapsed to where it will start the animation that AnimationContainer contains.
                timeElapsed = animationContainer.start / fps;
            }
        }

        public void Animate(GameTime gameTime)
        {
            // Adds time that has passed since last update.
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Calculates the curent index.
            currentIndex = (int)(timeElapsed * fps);

            //currentAnimationLength = currentIndex;

            // Check if we need to restart the animation
            if (currentIndex >= animationContainer.end)
            {
                if (retrunToOldAnimation == true)
                {
                    retrunToOldAnimation = false;
                    animationContainer = lastAnimationContainer;
                }
                // Resets the animation
                timeElapsed = animationContainer.start / fps;
                currentIndex = animationContainer.start;
            }
        }
    }
}
