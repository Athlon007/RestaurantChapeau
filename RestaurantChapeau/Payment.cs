using RestaurantChapeau.OrderViewUIController;
using RestaurantLogic;
using RestaurantModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        decimal subtotal = 0;
        decimal tax = 0;
        public Payment()
        {
            InitializeComponent();
            HideAllPanels();
            DPIScaler.Instance.UpdateToForm(this);
            valueTip.KeyPress += valueTip_KeyPress;
            this.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * WindowWidth);
            this.Height = Convert.ToInt32(DPIScaler.Instance.ScaleHeight * WindowHeight);
        }

        private async void Payment_Load(object sender, EventArgs e)
        {
            await Task.Run(ConnectToServer);
            this.bill = paymentService.GetBill(1); // CHANGE THIS 
            lblPaymentHeader.Text = $"Table {bill.Table.Id.ToString()}";
            valueInvoiceDate.Text = DateTime.Now.ToString();
            valueTip.Text = "0.00";
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

            subtotal = 0;
            tax = 0;
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

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            pnlPaymentType.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HideAllPanels();
        }

        private void HideAllPanels()
        {
            pnlPaymentType.Hide();
            pnlCardDetails.Hide();
            pnlCashPayment.Hide();
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            valueSubtotal2.Text = TotalValue.Text;
            valueTip2.Text = $"0,00 €";
            valueTotal2.Text = $"{Convert.ToDecimal(subtotal + tax, new CultureInfo("en-US")).ToString("#.##")} €";
            pnlCardDetails.Show();
        }

        private void paymentBackButton3_Click(object sender, EventArgs e)
        {
            pnlCardDetails.Hide();
        }

        private void btnTip_Click(object sender, EventArgs e)
        {
            decimal tip = Convert.ToDecimal(valueTip.Text, new CultureInfo("en-US"));
            valueTip2.Text = $"{tip} €";
            valueTotal2.Text = $"{Convert.ToDecimal(subtotal + tax + tip, new CultureInfo("en-US")).ToString("#.##")} €";
        }

        private void valueTip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            valueToPay.Text = $"{Convert.ToDecimal(subtotal + tax, new CultureInfo("en-US")).ToString("#.##")} €";
            pnlCashPayment.Show();
            
        }

        private void paymentBackButton4_Click(object sender, EventArgs e)
        {
            pnlCashPayment.Hide();
        }
    }
}
