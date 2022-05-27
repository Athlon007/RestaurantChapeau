using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text;

namespace RestaurantChapeau
{
    class FontManager
    {
        private static FontManager instance;
        public static FontManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new FontManager();

                return instance;
            }
        }

        PrivateFontCollection pfc;

        private FontManager() 
        {
            pfc = new PrivateFontCollection();
            LoadFont(Properties.Resources.SCRIPTBL);
        }

        private void LoadFont(byte[] fontResource)
        {
            int fontLength = fontResource.Length;
            byte[] fontData = fontResource;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
        }

        public Font ScriptMT(float size)
        {
            return new Font(pfc.Families[0], size, FontStyle.Bold);
        }
    }
}
