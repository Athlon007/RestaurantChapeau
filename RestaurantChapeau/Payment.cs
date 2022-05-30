using RestaurantChapeau.OrderViewUIController;
using RestaurantLogic;
using RestaurantModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantChapeau
{
    public partial class Payment : Form
    {
        PaymentService paymentService;
        Bill bill;
        Font fontMenuType = new Font("Segoe UI", 18);

        Color activeButtonColor = Color.FromArgb(255, 67, 179, 215);
        Color activeButtonTextColor = Color.FromArgb(255, 255, 255, 255);

        const int WindowWidth = 651;
        const int WindowHeight = 830;
        public Payment()
        {
            InitializeComponent();
            DPIScaler.Instance.UpdateToForm(this);

            this.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * WindowWidth);
            this.Height = Convert.ToInt32(DPIScaler.Instance.ScaleHeight * WindowHeight);
        }

        private async void Payment_Load(object sender, EventArgs e)
        {
            await Task.Run(ConnectToServer);
            this.bill = paymentService.GetBill(1); // CHANGE THIS 
            lblPaymentHeader.Text = $"Table {bill.Table.Id.ToString()}";
            valueInvoiceDate.Text = DateTime.Now.ToString();

            List<Order> orders = paymentService.GetAllOrdersInBill(bill.Id);
            List<MenuItem> items = new List<MenuItem>();
            foreach (Order order in orders)
            {
                items.AddRange(paymentService.GetAllItemsInOrder(order.Id));
            }

            foreach (MenuItem item in items)
            {
                ListViewItem li = new ListViewItem(item.Name.ToString());
                li.SubItems.Add(item.PriceBrutto.ToString());
                li.SubItems.Add(item.Quantity.ToString());
                li.SubItems.Add((item.PriceBrutto * item.Quantity).ToString());
                li.SubItems.Add(item.Vat.ToString());
                listViewInvoice.Items.Add(li);
            }

            decimal subtotal = 0;
            decimal tax = 0;
            foreach (ListViewItem listViewItem in listViewInvoice.Items)
            {
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.SubItems[0].Font = new Font(listViewInvoice.Font, FontStyle.Bold);
                decimal subtotalValue = Convert.ToDecimal(listViewItem.SubItems[3].Text);
                decimal taxValue = Convert.ToDecimal(listViewItem.SubItems[4].Text);
                subtotal += subtotalValue;
                tax += (subtotalValue * taxValue);
            }
            SubtotalValue.Text = $"{subtotal} €";
            TaxValue.Text = $"{tax.ToString("#.##")} €";
            TotalValue.Text = $"{(subtotal + tax).ToString("#.##")} €";
        }
        private async Task ConnectToServer()
        {
            paymentService = await Task.Run(() =>
            {
                return new PaymentService();
            });
        }
    }
}
