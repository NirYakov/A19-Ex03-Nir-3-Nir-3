using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Logic
{

    public class ThemeColorEvent
    {
        public Color BackColor { get; private set; } = Color.Red; // Color.CornflowerBlue;
        public Color ForeColor { get; private set; } = Color.White;

        public event Action<Color, Color> ThemeChanged;

        private ThemeColorEvent()
        {

        }

        private void NotifyAllThemeChanged(Color i_BackColor, Color i_ForeColor)
        {
            if (ThemeChanged != null)
            {
                ThemeChanged.Invoke(i_BackColor, i_ForeColor);
            }
        }

        public void ChangeTheme(Color i_BackColor, Color i_ForeColor)
        {
            BackColor = i_BackColor;
            ForeColor = i_ForeColor;

            NotifyAllThemeChanged(i_BackColor, i_ForeColor);
        }

        public void ChangeThemeReverseColor(Color i_BackColor, Color i_ForeColor)
        {
            BackColor = i_ForeColor;
            ForeColor = i_BackColor;

            NotifyAllThemeChanged(i_ForeColor, i_BackColor);
        }
    }

    public class ThemeColor : ISubjective<Color, Color>
    {// i_BackColor , i_ForeColor
        private readonly List<IObserver<Color, Color>> i_Observers;
        public Color BackColor { get; set; } = Color.CornflowerBlue;
        public Color ForeColor { get; set; } = Color.White;

        public ThemeColor()
        {
            i_Observers = new List<IObserver<Color, Color>>();
        }

        public virtual void NotifyallObservers(Color i_BackColor, Color i_ForeColor)
        {
            foreach (IObserver<Color, Color> item in i_Observers)
            {
                item.Update(i_BackColor, i_ForeColor);
            }
        }

        public void RegisterObserver(IObserver<Color, Color> i_NewObserver)
        {
            i_Observers.Add(i_NewObserver);
        }

        public void UnregisterObserver(IObserver<Color, Color> i_DelObserver)
        {
            i_Observers.Remove(i_DelObserver);
        }

        public void ColoredChanged(Color i_BackColor, Color i_ForeColor)
        {
            NotifyallObservers(i_BackColor, i_ForeColor);
        }
    }
}
