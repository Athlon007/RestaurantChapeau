using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantChapeau.OrderViewUIController
{
    class DPIScaler
    {
        // There have been some problems with high-DPI displays and OrderVIewUIControls.
        // This class calculates form scaling for it.

        const float DefaultScaleWidth = 7f;
        const float DefaultScaleHeight = 15f;
        SizeF formAutoScale;

        private DPIScaler() { }

        private static DPIScaler instance;
        public static DPIScaler Instance
        {
            get
            {
                if (instance == null)
                    instance = new DPIScaler();
                return instance;
            }
        }

        public float ScaleWidth
        {
            get
            {
                return formAutoScale.Width / DefaultScaleWidth;
            }
        }

        public float ScaleHeight
        {
            get
            {
                return formAutoScale.Height / DefaultScaleHeight;
            }
        }

        public void UpdateToForm(Form form)
        {
            formAutoScale = form.AutoScaleDimensions;
        }
    }
}
