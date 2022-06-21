using System.Drawing;
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

        /// <summary>
        /// Returns a window scale width-wise.
        /// </summary>
        public float ScaleWidth
        {
            get
            {
                return formAutoScale.Width / DefaultScaleWidth;
            }
        }

        /// <summary>
        /// Returns a window scale height-wise.
        /// </summary>
        public float ScaleHeight
        {
            get
            {
                return formAutoScale.Height / DefaultScaleHeight;
            }
        }

        /// <summary>
        /// Assigns the base scaling to be taken from specified form.
        /// </summary>
        /// <param name="form"></param>
        public void UpdateToForm(Form form)
        {
            formAutoScale = form.AutoScaleDimensions;
        }
    }
}
