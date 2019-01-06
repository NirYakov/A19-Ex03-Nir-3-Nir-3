using System;

namespace FB_Logic
{
    public class Stars : IComparable<Stars>
    {
        public static int GoldStarBar { get; }

        public int GoldenStars { get; private set; } = 0;

        public int NormalStars { get; private set; } = 0;

        public IStratgyCalculateStars CalcStars { get; set; }

        static Stars()
        {
            GoldStarBar = 60;
        }

        public void CalulateStars(params int[] i_Pra)
        {
            int result = 0;

            foreach (int number in i_Pra)
            {
                result += number;
            }

            result = CalcStars.CalculateStars(result);

            NormalStars = result % GoldStarBar;
            GoldenStars = result / GoldStarBar;
        }

        private int calcolateOtherInteraction(int i_Result)
        {
            if (i_Result > GoldStarBar)
            {
                i_Result += 10;
                i_Result += i_Result % 10;
            }

            return i_Result;
        }

        public int CompareTo(Stars i_Other)
        {
            return i_Other.StarsToNumbers() - this.StarsToNumbers();
        }

        public int StarsToNumbers()
        {
            int result = 0;
            result += NormalStars;
            result += GoldenStars * GoldStarBar;
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0} gold and {1} stars", GoldenStars, NormalStars);
        }
    }
}
