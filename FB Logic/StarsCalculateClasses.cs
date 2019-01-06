using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Logic
{
    public class StarsCalculateInteractions : IStratgyCalculateStars
    {
        public int CalculateStars(int i_Interaction)
        {
            if (i_Interaction > Stars.GoldStarBar)
            {
                i_Interaction += 10;
                i_Interaction += i_Interaction % 10;
            }

            return i_Interaction;
        }
    }

    public class StarsCalculatePictures : IStratgyCalculateStars
    {
        public int CalculateStars(int i_Interaction)
        {
            const float picStartsInterval = 1.5f;
            return (int)(i_Interaction * picStartsInterval);
        }
    }
}
