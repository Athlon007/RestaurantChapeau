using System.Drawing;
using System.Windows.Forms;

namespace RestaurantChapeau.OrderViewUIController
{
    class CategorySeparatorUI : OrderViewUIControlBase
    {
        private Font separatorFont = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Italic);

        public CategorySeparatorUI(FlowLayoutPanel flow, string text) : base (flow)
        {
            Label label = AddLabelWithoutPanel(text, flow.Width / 2);
            label.Font = separatorFont;
            SetLineBreak(label);
        }
    }
}
