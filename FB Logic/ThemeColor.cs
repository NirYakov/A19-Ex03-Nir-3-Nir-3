using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace FB_Logic
{

    public class ThemeColorEvent
    {
        private static readonly string sr_FileName;

        public Color BackColor { get;  set; } = Color.Red; // Color.CornflowerBlue;
        public Color ForeColor { get;  set; } = Color.White;

        public event Action<Color, Color> ThemeChanged;

        private ThemeColorEvent()
        {
            FromFileOrDefault();
        }

        ~ ThemeColorEvent()
        {
            Save();
        }

        static ThemeColorEvent()
        {
            sr_FileName = Application.ExecutablePath + ".settings.xml";
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

        public void Save()
        {
            using (FileStream stream = new FileStream(sr_FileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ThemeColorEvent));
                serializer.Serialize(stream, this);
            }
        }

        private void FromFileOrDefault()
        {
            lock (sr_FileName)
            {
                if (File.Exists(sr_FileName))
                {
                    using (FileStream stream = new FileStream(sr_FileName, FileMode.OpenOrCreate))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ThemeColorEvent));
                        ThemeColorEvent tce = (ThemeColorEvent)serializer.Deserialize(stream);
                        BackColor = tce.BackColor;
                        ForeColor = tce.ForeColor;
                    }
                }
            }
        }
    }
}