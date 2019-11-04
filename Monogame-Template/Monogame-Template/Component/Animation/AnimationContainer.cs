using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Template
{
    public class AnimationContainer
    {
        public int start;
        public int end;
        public int row;
        public bool retrunToOldAnimation;

        /// <summary>
        /// Make your Animation Container
        /// </summary>
        /// <param name="start">start index of animation</param>
        /// <param name="end">end index of animation</param>
        /// <param name="row">row index of animation</param>
        /// <param name="retrunToOldAnimation">when animation is done return to the animation befor this one</param>
        public AnimationContainer(int start,int end,int row,bool retrunToOldAnimation)
        {
            this.start = start;
            this.end = end;
            this.row = row;
            this.retrunToOldAnimation = retrunToOldAnimation;
        }
    }
}
