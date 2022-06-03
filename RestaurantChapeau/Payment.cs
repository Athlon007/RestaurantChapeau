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
using System.Threading;
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
        decimal tip = 0;
        decimal totalPrice = 0;
        public Payment()
        {
            InitializeComponent();
            HideAllPanels();
            DPIScaler.Instance.UpdateToForm(this);
            valueTip.KeyPress += intInput_KeyPress;
            PaidValue.KeyPress += intInput_KeyPress;
            valueTipCash.KeyPress += intInput_KeyPress;
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
            valueTipCash.Text = "0.00";
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
            totalPrice = Convert.ToDecimal(subtotal + tax + tip, new CultureInfo("en-US"));
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
            pnlPaymentSucessful.Hide();
            pnlCardPay.Hide();
            pnlPaymentError.Hide();
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            valueSubtotal2.Text = TotalValue.Text;
            valueTip2.Text = $"0,00 €";
            valueTotal2.Text = $"{totalPrice.ToString("#.##")} €";
            pnlCardDetails.Show();
        }

        private void paymentBackButton3_Click(object sender, EventArgs e)
        {
            tip = 0;
            valueTip.Text = "0.00";
            pnlCardDetails.Hide();
        }

        private void intInput_KeyPress(object sender, KeyPressEventArgs e)
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
            tip = 0;
            valueToPay.Text = $"{totalPrice.ToString("#.##")} €";
            pnlCashPayment.Show();
            
        }

        private void paymentBackButton4_Click(object sender, EventArgs e)
        {
            tip = 0;
            valueTipCash.Text = "0.00";
            pnlCashPayment.Hide();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ValueReturn.Text = Convert.ToDecimal(Convert.ToDecimal(PaidValue.Text, new CultureInfo("en-US")) - totalPrice).ToString("#.##");
        }

        private void btnTip_Click(object sender, EventArgs e)
        {
            tip = Convert.ToDecimal(valueTip.Text, new CultureInfo("en-US"));
            totalPrice = Convert.ToDecimal(subtotal + tax + tip, new CultureInfo("en-US"));
            valueTip2.Text = $"{tip} €";
            valueTotal2.Text = $"{totalPrice.ToString("#.##")} €";
        }
        private void btnTipCash_Click(object sender, EventArgs e)
        {
            tip = Convert.ToDecimal(valueTipCash.Text, new CultureInfo("en-US"));
            totalPrice = Convert.ToDecimal(subtotal + tax + tip, new CultureInfo("en-US"));
            valueToPay.Text = $"{totalPrice.ToString("#.##")} €";
        }

      
        private async void btnConfirmCashPayment_Click(object sender, EventArgs e)
        {
            int billId = bill.Id;
            string comment = valueComment.Text;
            // paymentService.CreatePayment(billId, totalPrice, comment, tip);
            HideAllPanels();
            pnlPaymentSucessful.Show();
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
            pnlPaymentSucessful.Hide();
        }

        private async void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            finalValueCard.Text = $"€ {totalPrice.ToString("#.##")}";
            pnlCardPay.Show();
            Panel[] panels = new[] { pnlPaymentSucessful, pnlPaymentError };
            Random r = new Random();
            Panel result = panels[r.Next(panels.Length)];
            Thread.Sleep(1000);
            HideAllPanels();
            result.Show();
            await Task.Run(() =>
            {    
                Thread.Sleep(1000);
            });
            result.Hide();
            pnlPaymentType.Show();
        }
    }
}
