using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

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
}