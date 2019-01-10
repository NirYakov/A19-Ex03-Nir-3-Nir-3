using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace FB_Logic
{
    public class ThemeColor
    {
        public Color BackColor { get; private set; } = Color.CornflowerBlue;
        public Color ForeColor { get; private set; } = Color.White;

        public event Action<Color, Color> ThemeChanged;

        private ThemeColor()
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
    }
}