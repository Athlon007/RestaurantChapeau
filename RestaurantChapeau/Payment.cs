using RestaurantChapeau.OrderViewUIController;
using RestaurantLogic;
using RestaurantModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
        private int tableId;
        private int startY;
        Color activeButtonColor = Color.FromArgb(255, 67, 179, 215);
        Color activeButtonTextColor = Color.FromArgb(255, 255, 255, 255);
        bool isChecked = false;
        const int WindowWidth = 651;
        const int WindowHeight = 830;
        decimal subtotal = 0;
        decimal tax = 0;
        decimal tip = 0;
        decimal totalPrice = 0;
        Label numberOfLoads  = new Label();
        ListView invoiceCopy = new ListView();
        public Payment(int tableId)
        {
            InitializeComponent();
            HideAllPanels();
            DPIScaler.Instance.UpdateToForm(this);
            valueTip.KeyPress += intInput_KeyPress;
            PaidValue.KeyPress += intInput_KeyPress;
            paymentNumber.KeyPress += intInput_KeyPress;
            pnlPaymentType.AutoScroll = true;
            this.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * WindowWidth);
            this.Height = Convert.ToInt32(DPIScaler.Instance.ScaleHeight * WindowHeight);
            this.tableId = tableId;
        }

        private async void Payment_Load(object sender, EventArgs e)
        {
            pnlBills.AutoScroll = false;
            pnlBills.HorizontalScroll.Enabled = false;
            pnlBills.HorizontalScroll.Visible = false;
            pnlBills.HorizontalScroll.Maximum = 0;
            pnlBills.AutoScroll = true;
            pnlBills.WrapContents = true;
            await Task.Run(ConnectToServer);
            this.bill = paymentService.GetBill(tableId);
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
                
                for (int i = 1; i <= item.Quantity; i++)
                {
                    invoiceCopy.Items.Add((ListViewItem)li.Clone());
                }

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
            SubtotalValue.Text = $"{subtotal - tax} €";
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
            startY = 50;
            numberOfLoads.Text = "1";
            startY = dynamicBillContainer(bill, startY, 1);
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
            cardDetails();
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

        private void btnCash_Click(object sender, EventArgs e, TextBox toPay)
        {
            pnlCashPayment.Show();
            pnlPaymentType.Hide();
            valueToPay.Text = $"{toPay.Text} €";
            
        }

        private void paymentBackButton4_Click(object sender, EventArgs e)
        {
            tip = 0;
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
            if (result == pnlPaymentSucessful)
            {
                
            }
            this.Close();
        }

        private void paymentBackButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPin_Click(object sender, EventArgs e)
        {
            cardDetails();

            pnlCardDetails.Show();
        }

        private void cardDetails()
        {
            valueSubtotal2.Text = TotalValue.Text;
            valueTip2.Text = $"0,00 €";
            valueTotal2.Text = $"{totalPrice.ToString("#.##")} €";
        }

       

        private int dynamicBillContainer(Bill bill, int startY, int payment)

        {
            Panel billContainer = new Panel();
            billContainer.Size = new Size(1135, 1512);
            billContainer.Name = $"billContainer{bill.Id}";
            billContainer.BackColor = Color.WhiteSmoke;
            billContainer.Location = new Point(0, startY);
            billContainer.Name = $"lblBillContainer{bill.Id}";
            billContainer.TabIndex = 0;
            billContainer.Text = "";
            billContainer.AutoSize = false;
            billContainer.Anchor = AnchorStyles.None;
            billContainer.BorderStyle = BorderStyle.FixedSingle;

            Label lblPayment = new Label();
            lblPayment.Location = new Point(50, 20);
            lblPayment.Name = $"payment{payment}";
            lblPayment.Text = $"Payment {payment}";
            lblPayment.AutoSize = true;
            lblPayment.TabIndex = 22;
            lblPayment.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);

            Label line = new Label();
            line.BorderStyle = BorderStyle.FixedSingle;
            line.Location = new Point(10, 90);
            line.Name = $"line{bill.Id}";
            line.Size = new Size(830, 1);

            RadioButton creditCard = new RadioButton();
            CheckBox cash = new CheckBox();
            RadioButton debitCard = new RadioButton();


            creditCard.Appearance = Appearance.Button;
            creditCard.AutoSize = true;
            creditCard.Location = new Point(250, 195);
            creditCard.Name = "radioBtnCredit";
            creditCard.Size = new Size(200, 72);
            creditCard.TabIndex = 0;
            creditCard.Text = "CREDIT CARD";
            creditCard.TextAlign = ContentAlignment.MiddleCenter;
            creditCard.BackColor = Color.White;

            debitCard.Appearance = Appearance.Button;
            debitCard.AutoSize = true;
            debitCard.Location = new Point(550, 195);
            debitCard.Name = "radioBtnDebit";
            debitCard.Size = new Size(350, 72);
            debitCard.TabIndex = 0;
            debitCard.Text = "DEBIT CARD";
            debitCard.TextAlign = ContentAlignment.MiddleCenter;
            debitCard.BackColor = Color.White;

            TextBox payByCash = new TextBox();
            payByCash.Name = $"payBtn";
            payByCash.KeyPress += intInput_KeyPress;

            cash.Appearance = Appearance.Button;
            cash.AutoSize = true;
            cash.Location = new Point(112, 195);
            cash.Name = "checkBoxCashh";
            cash.Size = new Size(200, 72);
            cash.TabIndex = 0;
            cash.Text = "CASH";
            cash.TextAlign = ContentAlignment.MiddleCenter;
            cash.BackColor = Color.White;

            TextBox addTipValue = new TextBox();
            addTipValue.KeyPress += intInput_KeyPress;

            Label lblAddTip = new Label();
            lblAddTip.Text = "Add tip";
            lblAddTip.BackColor = Color.SandyBrown;
            lblAddTip.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAddTip.ForeColor = SystemColors.ButtonHighlight;
            lblAddTip.Margin = new Padding(5);
            lblAddTip.Size = new Size(203, 93);
            lblAddTip.TabIndex = 26;

            TextBox addFeedbackValue = new TextBox();
            addFeedbackValue.AutoSize = false;
            addFeedbackValue.Height = 100;


            Label lblAddFeedback = new Label();
            lblAddFeedback.Text = "Add feedback";
            lblAddFeedback.BackColor = Color.SandyBrown;
            lblAddFeedback.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAddFeedback.ForeColor = SystemColors.ButtonHighlight;
            lblAddFeedback.Margin = new Padding(5);
            lblAddFeedback.Size = new Size(203, 93);
            lblAddFeedback.TabIndex = 26;

            Button load = new Button();
            load.Text = "Load menu items";
            load.BackColor = Color.Blue;
            load.ForeColor = Color.White;
            load.Location = new Point(10, 100);
            load.Name = $"load{bill.Id}";
            load.Size = new Size(116, 64);
            load.TabIndex = 21;
            load.Click += (sender, EventArgs) => { btn_loadItemsClicked(sender, EventArgs, billContainer, cash, creditCard, debitCard, lblAddTip, addTipValue, lblAddFeedback, addFeedbackValue, payment, payByCash); };


            if (Convert.ToUInt32(paymentNumber.Text) > 1)
            {
                billContainer.Controls.Add(load);

            } else
            {
                load.PerformClick();
                billContainer.Controls.Add(cash);
                billContainer.Controls.Add(creditCard);
                billContainer.Controls.Add(debitCard);
            }
            billContainer.Controls.Add(lblPayment);
            billContainer.Controls.Add(line);

            pnlBills.Controls.Add(billContainer);
            startY += billContainer.Height + 50;
            return startY;
        }

        private decimal AddTipValue_TextChanged(object sender, EventArgs e, Label TotalValue, Label SubTotalValue, Label TaxValue)
        {
            TextBox tip = sender as TextBox;
            if (tip.Text == "")
            {
                tip.Text = "0";
                TotalValue.Text = (Convert.ToDecimal(SubTotalValue.Text) + Convert.ToDecimal(TaxValue.Text)).ToString("#.##");
            }
            else
            {
                TotalValue.Text = (Convert.ToDecimal(SubTotalValue.Text) + Convert.ToDecimal(TaxValue.Text) + Convert.ToDecimal(tip.Text)).ToString("#.##");

            }
            return Convert.ToDecimal(TotalValue.Text);

        }

        private void paymentNumber_TextChanged(object sender, EventArgs e)
        {
            pnlBills.Controls.Clear();
            if (paymentNumber.Text == "" || paymentNumber.Text == "0")
            {
                paymentNumber.Text = "1";
            }
            numberOfLoads.Text = "1";
            int payments = Convert.ToInt32(paymentNumber.Text);
            startY = 50;
            invoiceCopy.Clear();
            foreach (ListViewItem item in listViewInvoice.Items)
            {
                for (int i = 1; i <= Convert.ToInt32(item.SubItems[2].Text); i++)
                {
                    invoiceCopy.Items.Add((ListViewItem)item.Clone());
                }
            }
            for (int i = 1; i <= payments; i++)
               {
                    startY = dynamicBillContainer(bill, startY, i);
               }
            
        }

        void btn_Checked(object sender, EventArgs e, RadioButton creditCard, RadioButton debitCard, Panel billContainer, TextBox payByCash, decimal totalPrice, Button pay)
        {
            CheckBox btn = sender as CheckBox;
            payByCash.Text = "0.00";

            payByCash.Location = new Point(btn.Location.X + btn.Width + 20, btn.Location.Y);
            pay.Location = new Point(payByCash.Location.X + payByCash.Width + 20, payByCash.Location.Y);
            pay.Height = payByCash.Height;

            if (btn.Checked)
            {
                billContainer.Controls.Add(payByCash);
                btn.BackColor = Color.Orange;
                if (!creditCard.Checked && !debitCard.Checked)
                {
                   payByCash.Text = totalPrice.ToString("#.##");
                }
                pay.Enabled = true;
                pay.BackColor = Color.Blue;
                billContainer.Controls.Add(pay);
               
            } else
            {
                billContainer.Controls.Remove(payByCash);
                btn.BackColor = Color.White;
                if (creditCard.Checked || debitCard.Checked)
                { 
                  payByCash.Text = "0.50";   
                }
                billContainer.Controls.Remove(pay);
            }

        }

        void btn_RadioChecked(object sender, EventArgs e, RadioButton otherRadioBtn, CheckBox cash)
        {
            RadioButton btn = sender as RadioButton;
            isChecked = btn.Checked;
            
            if (btn.Checked)
            {
                btn.BackColor = Color.Orange;

                //pay.Enabled = true;
                //pay.BackColor = Color.Blue
            }
            else
            {
                btn.BackColor = Color.White;
                if (!otherRadioBtn.Checked && !cash.Checked)
                {
                    //pay.Enabled = false;
                    //pay.BackColor = Color.Gray;
                }
            }
        }
        void btn_RadioClicked(object sender, EventArgs e, TextBox cashValue, Panel billContainer, decimal totalPrice, Label cardValue)
        {
            RadioButton btn = sender as RadioButton;
            
            cardValue.Text = (totalPrice - Convert.ToDecimal(cashValue.Text)).ToString();
            cardValue.Location = new Point(btn.Location.X + btn.Width + 20, btn.Location.Y);

            if (btn.Checked && !isChecked)
            {
                btn.Checked = false;
                billContainer.Controls.Remove(cardValue);
            }
            else
            {
                btn.Checked = true;
                isChecked = false;
                billContainer.Controls.Add(cardValue);
            }
        }
        void btn_saveSelectedOption(object sender, EventArgs e, CheckedListBox menuItems, Panel billContainer, Button saveSelected, CheckBox cash, RadioButton creditCard, RadioButton debitCard, Label lblAddTip, TextBox addTipValue,  Label lblAddFeedback, TextBox addFeedbackValue, int paymentNum, TextBox payByCash)
        {
            Label selectedOptions = new Label();
            selectedOptions.AutoSize = false;
            selectedOptions.Location = new Point(10, 150);
            selectedOptions.Size = new Size(700, 50);
            //selectedOptions.Height = menuItems.CheckedItems.Count * 70;
            selectedOptions.Name = $"optLabel{bill.Id}";
            if (menuItems.CheckedItems.Count > 0)
            {
                for (int i = 0; i < menuItems.CheckedItems.Count; i++)
                {
                    selectedOptions.Text += $"\n{menuItems.CheckedItems[i]}";
                }

                menuItems.Hide();
                
                billContainer.Controls.Remove(saveSelected);

                decimal finalSubtotal = 0;
                decimal finalTotal = 0;
                decimal finalTax = 0;
                decimal subtax = 0;
                List<ListViewItem> toDelete = new List<ListViewItem>();
                numberOfLoads.Text = (Convert.ToInt32(numberOfLoads.Text) + 1).ToString();
                for (int i = 0; i < invoiceCopy.Items.Count; i++) {
                    string stringToCompare = $"{i+1}.: 1x - {invoiceCopy.Items[i].SubItems[0].Text} ({invoiceCopy.Items[i].SubItems[1].Text})";
                    if (menuItems.CheckedItems.Contains(stringToCompare))
                    {
                        menuItems.SetItemChecked(menuItems.CheckedItems.IndexOf(stringToCompare), false);
                        subtax = Convert.ToDecimal(invoiceCopy.Items[i].SubItems[1].Text) * Convert.ToDecimal(invoiceCopy.Items[i].SubItems[4].Text);
                        finalTax += subtax;
                        finalSubtotal += (Convert.ToDecimal(invoiceCopy.Items[i].SubItems[1].Text) - subtax);
                        toDelete.Add(invoiceCopy.Items[i]);
                    } 
                }

                foreach (ListViewItem itemToDelete in toDelete)
                {
                    invoiceCopy.Items[invoiceCopy.Items.IndexOf(itemToDelete)].Remove();
                }
                finalTotal = finalSubtotal + finalTax;

                
                billContainer.Controls.Add(lblAddTip);

                lblAddTip.Location = new Point(112, selectedOptions.Location.Y + selectedOptions.Height + 50);

                billContainer.Controls.Add(addTipValue);
                addTipValue.Text = "0.00";
                addTipValue.Location = new Point(150 + lblAddTip.Width, lblAddTip.Location.Y);
                lblAddTip.Height = addTipValue.Height;

                billContainer.Controls.Add(lblAddFeedback);
                lblAddFeedback.Location = new Point(112, addTipValue.Location.Y + addTipValue.Height + 50);

                billContainer.Controls.Add(addFeedbackValue);
                addFeedbackValue.Location = new Point(112, lblAddFeedback.Location.Y + lblAddFeedback.Height + 20);
                addFeedbackValue.Width = 700;

                Button payCash = new Button();
                payCash.Text = "Pay";
                payCash.Enabled = true;
                payCash.BackColor = Color.Gray;
                payCash.ForeColor = Color.White;
                payCash.Click += (sender, EventArgs) => { btnCash_Click(sender, EventArgs, payByCash); };


                billContainer.Controls.Add(cash);
                payByCash.Text = "0.00";
                cash.Location = new Point(112, addFeedbackValue.Location.Y + addFeedbackValue.Height + 50);
                cash.CheckStateChanged += (sender, EventArgs) => { btn_Checked(sender, EventArgs, creditCard, debitCard, billContainer, payByCash, finalTotal, payCash); };

                Label creditCardValue = new Label();
                billContainer.Controls.Add(creditCard);
                creditCard.Location = new Point(112, cash.Location.Y + cash.Height + 20);
                creditCard.CheckedChanged += (sender, EventArgs) => { btn_RadioChecked(sender, EventArgs, debitCard, cash); };
                creditCard.Click += (sender, EventArgs) => { btn_RadioClicked(sender, EventArgs, payByCash, billContainer, finalTotal, creditCardValue); };
               
                Label debitCardValue = new Label();
                billContainer.Controls.Add(debitCard);
                debitCard.Location = new Point(112, creditCard.Location.Y + creditCard.Height + 20);
                debitCard.CheckedChanged += (sender, EventArgs) => { btn_RadioChecked(sender, EventArgs, creditCard, cash); };
                debitCard.Click += (sender, EventArgs) => { btn_RadioClicked(sender, EventArgs, payByCash, billContainer, finalTotal, debitCardValue); };


                List<Label> paymentSummaryValues = dynamicPaymentSummary(paymentNum, billContainer, 112, debitCard.Location.Y + debitCard.Height + 20);
                paymentSummaryValues[0].Text = finalTotal.ToString("#.##");
                paymentSummaryValues[1].Text = finalSubtotal.ToString("#.##");
                paymentSummaryValues[2].Text = finalTax.ToString("#.##");
                addTipValue.TextChanged += (sender, EventArgs) => { finalTotal = AddTipValue_TextChanged(sender, EventArgs, paymentSummaryValues[0], paymentSummaryValues[1], paymentSummaryValues[2]); };

                // billContainer.Controls.Add(selectedOptions);
            }
            else
            {
                MessageBox.Show("Please select items for this payment!");
            }

        }

        void btn_loadItemsClicked(object sender, EventArgs e, Panel billContainer, CheckBox cash, RadioButton creditCard, RadioButton debitCard, Label lblAddTip, TextBox addTipValue, Label lblAddFeedback, TextBox addFeedbackValue, int paymentNum, TextBox payByCash) {
            Button btn = sender as Button;
            CheckedListBox menuItems = new CheckedListBox();
            menuItems.Location = new Point(10, 110);
            menuItems.Size = new Size(700, 50);
            menuItems.Height = invoiceCopy.Items.Count * 40;
            menuItems.Name = $"selection{paymentNumber}";
            foreach (ListViewItem item in invoiceCopy.Items)
            {
                menuItems.Items.Add($"{invoiceCopy.Items.IndexOf(item)+1}.: 1x - {item.SubItems[0].Text} ({item.SubItems[1].Text})");
            }


            Button saveSelected = new Button();
            saveSelected.Text = "SAVE";
            saveSelected.BackColor = Color.Orange;
            saveSelected.ForeColor = Color.White;
            saveSelected.Location = new Point(10, 110 + invoiceCopy.Items.Count * 40 + 20);
            saveSelected.Name = $"save{bill.Id}";
            saveSelected.Size = new Size(116, 64);
            saveSelected.TabIndex = 21;
            saveSelected.Click += (sender, EventArgs) => { btn_saveSelectedOption(sender, EventArgs, menuItems, billContainer, saveSelected, cash, creditCard, debitCard, lblAddTip, addTipValue, lblAddFeedback, addFeedbackValue, paymentNum, payByCash); };
            btn.Enabled = false;

            billContainer.Controls.Add(saveSelected);

            if (Convert.ToUInt32(numberOfLoads.Text) == Convert.ToInt32(paymentNumber.Text))
            {
                for (int i = 0; i < menuItems.Items.Count; i++) menuItems.SetItemChecked(i, true);

                saveSelected.PerformClick();

            }
           
            billContainer.Controls.Add(menuItems);
            billContainer.Controls.Remove(btn);
        }

        private List<Label> dynamicPaymentSummary(int payment, Panel billContainer, int X, int Y)
        {
            // 
            // lblLine2
            // 
            Label dline2 = new Label();
            dline2.BorderStyle = BorderStyle.FixedSingle;
            dline2.Font = new Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dline2.Location = new Point(26, 216);
            dline2.Name = $"lblLine2{payment}";
            dline2.Size = new System.Drawing.Size(816, 2);
            dline2.TabIndex = 35;
            // 
            // TotalValue
            // 
            Label dtotalValue = new Label();
            dtotalValue.Font = new Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dtotalValue.Location = new Point(549, 175);
            dtotalValue.Name = $"TotalValue{payment}";
            dtotalValue.Size = new Size(293, 37);
            dtotalValue.TabIndex = 34;
            // 
            // TaxValue
            // 
            Label dTaxValue = new Label();
            dTaxValue.Font = new Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dTaxValue.Location = new Point(549, 127);
            dTaxValue.Name = $"TaxValue{payment}";
            dTaxValue.Size = new Size(293, 37);
            dTaxValue.TabIndex = 33;
            // 
            // SubtotalValue
            // 
            Label dSubtotalValue = new Label();
            dSubtotalValue.Font = new Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dSubtotalValue.Location = new Point(549, 81);
            dSubtotalValue.Name = $"SubtotalValue{payment}";
            dSubtotalValue.Size = new Size(293, 37);
            dSubtotalValue.TabIndex = 32;
            // 
            // lblTotal
            // 
            Label dLblTotal = new Label();
            dLblTotal.AutoSize = true;
            dLblTotal.Font = new Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dLblTotal.Location = new Point(29, 175);
            dLblTotal.Name = $"lblTotal{payment}";
            dLblTotal.Size = new Size(89, 37);
            dLblTotal.TabIndex = 31;
            dLblTotal.Text = "Total:";
            // 
            // lblTax
            // 
            Label dLblTax = new Label();
            dLblTax.AutoSize = true;
            dLblTax.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            dLblTax.Location = new Point(26, 127);
            dLblTax.Name = "lblTax";
            dLblTax.Size = new Size(60, 37);
            dLblTax.TabIndex = 30;
            dLblTax.Text = "Tax:";
            // 
            // lblSubtotal
            // 
            Label dLblSubtotal = new Label();
            dLblSubtotal.AutoSize = true;
            dLblSubtotal.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            dLblSubtotal.Location = new Point(26, 81);
            dLblSubtotal.Name = $"lblSubtotal{payment}";
            dLblSubtotal.Size = new Size(123, 37);
            dLblSubtotal.TabIndex = 27;
            dLblSubtotal.Text = "Subtotal:";
            // 
            // lblLine
            // 
            Label dLblLine = new Label();
            dLblLine.BorderStyle = BorderStyle.FixedSingle;
            dLblLine.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            dLblLine.Location = new Point(26, 64);
            dLblLine.Name = $"lblLine{payment}";
            dLblLine.Size = new Size(816, 2);
            dLblLine.TabIndex = 29;
            // 
            // lblTotals
            // 
            Label dLblTotals = new Label();
            dLblTotals.AutoSize = true;
            dLblTotals.Font = new Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dLblTotals.Location = new Point(748, 20);
            dLblTotals.Name = $"lblTotals{payment}";
            dLblTotals.Size = new Size(94, 37);
            dLblTotals.TabIndex = 28;
            dLblTotals.Text = "Totals";
            // 
            // lblInfo
            // 
            Label dLblInfo = new Label();
            dLblInfo.AutoSize = true;
            dLblInfo.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dLblInfo.Location = new System.Drawing.Point(26, 20);
            dLblInfo.Name = "lblInfo";
            dLblInfo.Size = new System.Drawing.Size(314, 37);
            dLblInfo.TabIndex = 27;
            dLblInfo.Text = "Additional information";

            GroupBox groupBoxMoreInfo2 = new GroupBox();
            groupBoxMoreInfo2.AccessibleRole = AccessibleRole.None;
            groupBoxMoreInfo2.BackColor = Color.Gainsboro;
            groupBoxMoreInfo2.Controls.Add(dline2);
            groupBoxMoreInfo2.Controls.Add(dtotalValue);
            groupBoxMoreInfo2.Controls.Add(dTaxValue);
            groupBoxMoreInfo2.Controls.Add(dSubtotalValue);
            groupBoxMoreInfo2.Controls.Add(dLblTotal);
            groupBoxMoreInfo2.Controls.Add(dLblTax);
            groupBoxMoreInfo2.Controls.Add(dLblSubtotal);
            groupBoxMoreInfo2.Controls.Add(dLblLine);
            groupBoxMoreInfo2.Controls.Add(dLblTotals);
            groupBoxMoreInfo2.Controls.Add(dLblInfo);
            groupBoxMoreInfo2.Location = new Point(130, 923);
            groupBoxMoreInfo2.Name = "groupBoxMoreInfo2";
            groupBoxMoreInfo2.Size = new Size(867, 264);
            groupBoxMoreInfo2.TabIndex = 26;
            groupBoxMoreInfo2.TabStop = false;
            groupBoxMoreInfo2.Location = new Point(X, Y);

            List<Label> values = new List<Label>();
            values.Add(dtotalValue);
            values.Add(dSubtotalValue);
            values.Add(dTaxValue);

            billContainer.Controls.Add(groupBoxMoreInfo2);
            return values;


        }
    }
}
