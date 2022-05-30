using RestaurantModel;
using System.Windows.Forms;

namespace RestaurantChapeau.OrderViewUIController
{
    /// <summary>
    /// Used for Table Detail view for an item.
    /// </summary>
    internal class MenuItemTableDetailUI : OrderViewUIControlBase
    {
        public MenuItemTableDetailUI(FlowLayoutPanel flow, MenuItem item, int lblNameWidth) : base(flow)
        {
            // Item name
            AddLabel(item.Name, lblNameWidth);

            // Item Count
            Label lblCount = AddLabel(item.Quantity.ToString());

            SetLineBreak(lblCount);
        }
    }
}
