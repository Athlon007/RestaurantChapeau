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
        ListView invoiceCopy = new ListView();
        Panel tableViewDetail;
        List<MenuItem> items = new List<MenuItem>();
        private int tableId;
        private int startY;
        bool isChecked = false;
        const int WindowWidth = 651;
        const int WindowHeight = 830;
        decimal subtotal = 0;
        decimal tax = 0;
        decimal tip = 0;
        decimal totalPrice = 0;
        decimal totalUnitPrice = 0;
        decimal alreadyPaid = 0;
        int paymentNum = 1;
        int numberOfLoads = 0;
        private void HideAllPanels()
        {
            pnlPaymentType.Hide();
            pnlCashPayment.Hide();
            pnlPaymentSucessful.Hide();
            pnlCardPay.Hide();
            pnlPaymentError.Hide();
            pnlPin.Hide();
        }


        #region CONSTRUCTOR
        public Payment(int tableId, Panel tableViewDetail)
        {
            // Display setup
            InitializeComponent();
            HideAllPanels();
            DPIScaler.Instance.UpdateToForm(this);
            this.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * WindowWidth);
            this.Height = Convert.ToInt32(DPIScaler.Instance.ScaleHeight * WindowHeight);
            backInvoice.Font = FontManager.Instance.ScriptMT(backInvoice.Font.Size);
            headingPaymentType2.Font = FontManager.Instance.ScriptMT(headingPaymentType2.Font.Size);
            backInvoice.Font = FontManager.Instance.ScriptMT(backInvoice.Font.Size);
            lblPaymentTopBarText.Font = FontManager.Instance.ScriptMT(lblPaymentTopBarText.Font.Size);
            pnlPaymentType.AutoScroll = true;

            // Listeners
            valueTip.KeyPress += intInput_KeyPress;
            PaidValue.KeyPress += intInput_KeyPress;
            paymentNumber.KeyPress += intInput_KeyPress;

            // Assigning values
            this.tableId = tableId;
            this.tableViewDetail = tableViewDetail;
        }
        #endregion
        #region PAYMENT PANEL LOAD
        private async void Payment_Load(object sender, EventArgs e)
        {

            pnlBills.AutoScroll = false;
            pnlBills.HorizontalScroll.Enabled = false;
            pnlBills.HorizontalScroll.Visible = false;
            pnlBills.HorizontalScroll.Maximum = 0;
            pnlBills.AutoScroll = true;
            pnlBills.WrapContents = true;

            paymentService = new PaymentService();
            var dbdata = paymentService.GetBillAndOrders(tableId);
            this.bill = dbdata.Item1;
            lblPaymentHeader.Text = $"Table {bill.Table.Id.ToString()}";
            valueInvoiceDate.Text = DateTime.Now.ToString();
            valueTip.Text = "0.00";

            foreach (Order order in dbdata.Item2)
            {
                items.AddRange(paymentService.GetAllItemsInOrder(order.Id));
            }

            // Filling the listview
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
            // Assign labels

            SubtotalValue.Text = $"{(subtotal - tax).ToString("#.##")} €";
            TaxValue.Text = $"{tax.ToString("#.##")} €";
            TotalValue.Text = $"{subtotal.ToString("#.##")} €";
            totalPrice = Convert.ToDecimal(subtotal + tip);
            lblBillHeading.Text = $"Split the bill {bill.Id} to ";
        }
        #endregion


        #region PROCESS PAYMENT CLICK
        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            pnlBills.Controls.Clear();
            invoiceCopy.Items.Clear();
            foreach (ListViewItem item in listViewInvoice.Items)
            {
                for (int i = 1; i <= int.Parse(item.SubItems[2].Text); i++)
                {
                    invoiceCopy.Items.Add((ListViewItem)item.Clone());
                }
            }

            startY = 50;
            numberOfLoads = 1;
            startY = dynamicBillContainer(bill, startY, 1);
            pnlPaymentType.Show();
        }
        #endregion

        #region BACK BUTTONS

        // Back to Invoice
        private void btnBack_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            paymentNum = 1;
            paymentNumber.Text = "1";
        }

        // Back to payment Type
        private void paymentBackButton4_Click(object sender, EventArgs e)
        {
            tip = 0;
            pnlCashPayment.Hide();
        }

        // Close Payment section
        private void paymentBackButton1_Click(object sender, EventArgs e)
        {
            tableViewDetail.Hide();
            this.Close();
        }

        #endregion

        #region TEXTBOX LISTENER - KEY PRESSED
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
        #endregion

        #region PAY BY CASH
        private void btnCash_Click(object sender, EventArgs e, TextBox toPay, CheckBox btnCash, Button payCash, TextBox cashValue, RadioButton creditCard, RadioButton debitCard)
        {
            pnlCashPayment.Show();
            pnlPaymentType.Hide();
            creditCard.Enabled = false;
            debitCard.Enabled = false;
            btnCash.Enabled = false;
            btnConfirmCashPayment.Click += (sender, EventArgs) => { btnConfirmCashPayment_Click(sender, EventArgs, btnCash, payCash, cashValue, creditCard, debitCard); };
            valueToPay.Text = $"{toPay.Text} €";

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ValueReturn.Text = Convert.ToDecimal(Convert.ToDecimal(PaidValue.Text) - totalPrice).ToString("#.##");
        }

        private async void btnConfirmCashPayment_Click(object sender, EventArgs e, CheckBox btnCash, Button payCash, TextBox cashValue, RadioButton creditCard, RadioButton debitCard)
        {
            int billId = bill.Id;
            string comment = valueComment.Text;
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;

            decimal CashValue = Convert.ToDecimal(cashValue.Text);
            paymentService.CreatePayment(billId, CashValue, comment, tip, 0, paymentNum);
            alreadyPaid += CashValue + tip;

            if (alreadyPaid == totalPrice)
            {
                paymentService.UpdateBillStatus(bill.Id, 0);
                this.Close();
            }
            paymentNum += 1;
            HideAllPanels();
            pnlPaymentSucessful.Show();
            btnCash.Enabled = false;
            payCash.Enabled = false;
            cashValue.Enabled = false;
            paymentNumber.Enabled = false;
            if (CashValue == totalUnitPrice)
            {
                creditCard.Enabled = false;
                debitCard.Enabled = false;
            }
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
            pnlPaymentType.Show();
            pnlPaymentSucessful.Hide();

        }

        #endregion

        #region PAY BY  CARD

        // CREDIT CARD
        private async void btnCreditCard_Click(object sender, EventArgs e, TextBox payByCash, RadioButton creditCard, Button payCard, Label cardValue, CheckBox cash, RadioButton debitCard)
        {
            pnlPaymentType.Hide();
            finalValueCard.Text = $"€ {cardValue.Text}";
            pnlCardPay.Show();
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
            btnCredit_Click(payByCash, creditCard, payCard, cardValue, cash, debitCard);

        }



        // DEBIT CARD
        private async void btnDebitCard_Click(object sender, EventArgs e, TextBox payByCash, RadioButton debitCard, Button payCard, Label cardValue, CheckBox cash, RadioButton creditCard)
        {
            debitFinalPrice.Text = $"€ {cardValue.Text}";
            finalValueCard.Text = $"€ {cardValue.Text}";
            lblPin.Text = "";
            pnlPaymentType.Hide();
            btn1.Click += pinBtnClick;
            btn2.Click += pinBtnClick;
            btn3.Click += pinBtnClick;
            btn4.Click += pinBtnClick;
            btn5.Click += pinBtnClick;
            btn6.Click += pinBtnClick;
            btn7.Click += pinBtnClick;
            btn8.Click += pinBtnClick;
            btn9.Click += pinBtnClick;
            btn0.Click += pinBtnClick;
            btnSubmitPin.Enabled = false;
            btnClear.Enabled = false;
            pnlPin.Show();
            btnSubmitPin.Click += (sender, EventArgs) => { pinSubmit(sender, EventArgs, payByCash, debitCard, payCard, cardValue, cash, creditCard); };
            btnClear.Click += clearPin;
            lblPin.TextChanged += LblPin_TextChanged;
        }

        private void LblPin_TextChanged(object sender, EventArgs e)
        {
            if (lblPin.Text != "")
            {
                btnClear.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
            }

            if (lblPin.Text != "****")
            {
                btn1.Enabled = true;
                btn2.Enabled = true;
                btn3.Enabled = true;
                btn4.Enabled = true;
                btn5.Enabled = true;
                btn6.Enabled = true;
                btn7.Enabled = true;
                btn8.Enabled = true;
                btn9.Enabled = true;
                btn0.Enabled = true;
                btnSubmitPin.Enabled = false;
            }
            else
            {
                btnSubmitPin.Enabled = true;
                btn1.Enabled = false;
                btn2.Enabled = false;
                btn3.Enabled = false;
                btn4.Enabled = false;
                btn5.Enabled = false;
                btn6.Enabled = false;
                btn7.Enabled = false;
                btn8.Enabled = false;
                btn9.Enabled = false;
                btn0.Enabled = false;

            }

        }

        private void pinSubmit(object sender, EventArgs e, TextBox payByCash, RadioButton debitCard, Button payCard, Label cardValue, CheckBox cash, RadioButton creditCard)
        {
            pnlCardPay.Show();
            Thread.Sleep(1000);
            btnCredit_Click(payByCash, debitCard, payCard, cardValue, cash, creditCard);

        }
        private void clearPin(object sender, EventArgs e)
        {
            lblPin.Text = "";
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btn0.Enabled = true;
            btnSubmitPin.Enabled = false;
        }
        private void pinBtnClick(object sender, EventArgs e)
        {

            if (lblPin.Text != "****")
            {
                lblPin.Text += "*";

            }
        }


        private async void btnCredit_Click(TextBox toPay, RadioButton btnCard, Button payCard, Label cardValue, CheckBox cash, RadioButton debitCard)
        {
            Panel[] panels = new[] { pnlPaymentSucessful, pnlPaymentError };
            Random r = new Random();
            Panel result = panels[r.Next(panels.Length)];
            string comment = valueComment.Text;
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
                payCard.Enabled = false;
                btnCard.Enabled = false;
                debitCard.Enabled = false;
                cash.Enabled = false;

                btnCard.BackColor = btnCard.BackColor = Color.FromArgb(206, 206, 206);

                debitCard.BackColor = Color.DarkGray;
                cash.BackColor = Color.DarkGray;
                payCard.BackColor = Color.DarkGray;

                decimal CardValue = Convert.ToDecimal(cardValue.Text);
                paymentService.CreatePayment(bill.Id, CardValue, comment, tip, 0, paymentNum);
                alreadyPaid += CardValue + tip;
                if (alreadyPaid == totalPrice)
                {
                    paymentService.UpdateBillStatus(bill.Id, 0);
                    this.Close();
                }
                else
                {
                    pnlPaymentType.Show();

                }
                paymentNum += 1;

            }
            else
            {
                pnlPaymentType.Show();
            }
        }

        #endregion

        #region DYNAMIC BILL CONTAINER
        private int dynamicBillContainer(Bill bill, int startY, int payment)

        {
            Panel billContainer = new Panel();
            billContainer.Size = new Size(935, 50);
            billContainer.Name = $"billContainer{bill.Id}";
            billContainer.BackColor = ColorTranslator.FromHtml("#EFF0F3");
            billContainer.Location = new Point(0, startY);
            billContainer.Name = $"lblBillContainer{bill.Id}";
            billContainer.Text = "";
            billContainer.AutoSize = true;
            billContainer.Anchor = AnchorStyles.None;
            billContainer.BorderStyle = BorderStyle.None;

            Label lblPayment = new Label();
            lblPayment.Location = new Point(50, 20);
            lblPayment.Name = $"payment{payment}";
            lblPayment.Text = $"Payment {payment}";
            lblPayment.AutoSize = true;
            lblPayment.TabIndex = 22;
            lblPayment.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);


            Button line = new Button();
            line.Location = new Point(10, 90);
            line.Name = $"line{bill.Id}";
            line.Size = new Size(900, 1);
            line.Enabled = false;
            line.BackColor = Color.White;

            RadioButton creditCard = new RadioButton();
            CheckBox cash = new CheckBox();
            RadioButton debitCard = new RadioButton();


            creditCard.Appearance = Appearance.Button;
            creditCard.AutoSize = false;
            creditCard.Location = new Point(250, 195);
            creditCard.Name = "radioBtnCredit";
            creditCard.Size = new Size(350, 72);
            creditCard.TabIndex = 0;
            creditCard.Text = "CREDIT CARD";
            creditCard.TextAlign = ContentAlignment.MiddleCenter;
            creditCard.BackColor = Color.FromArgb(206, 206, 206);
            creditCard.ForeColor = Color.White;
            creditCard.FlatStyle = FlatStyle.Flat;
            creditCard.TabStop = false;
            creditCard.FlatAppearance.BorderSize = 0;
            creditCard.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            debitCard.Appearance = Appearance.Button;
            debitCard.AutoSize = false;
            debitCard.Location = new Point(550, 195);
            debitCard.Name = "radioBtnDebit";
            debitCard.Size = new Size(350, 72);
            debitCard.TabIndex = 0;
            debitCard.Text = "DEBIT CARD";
            debitCard.TextAlign = ContentAlignment.MiddleCenter;
            debitCard.BackColor = Color.FromArgb(206, 206, 206);
            debitCard.ForeColor = Color.White;
            debitCard.FlatStyle = FlatStyle.Flat;
            debitCard.TabStop = false;
            debitCard.FlatAppearance.BorderSize = 0;
            debitCard.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            TextBox payByCash = new TextBox();
            payByCash.Name = $"payBtn";
            payByCash.KeyPress += intInput_KeyPress;
            payByCash.Text = "0.00";
            cash.Appearance = Appearance.Button;
            cash.AutoSize = false;
            cash.Location = new Point(112, 195);
            cash.Name = "checkBoxCashh";
            cash.Size = new Size(350, 72);
            cash.TabIndex = 0;
            cash.Text = "CASH";
            cash.TextAlign = ContentAlignment.MiddleCenter;
            cash.BackColor = Color.FromArgb(206, 206, 206);
            cash.ForeColor = Color.White; debitCard.FlatStyle = FlatStyle.Flat;
            cash.FlatStyle = FlatStyle.Flat;
            cash.TabStop = false;
            cash.FlatAppearance.BorderSize = 0;
            cash.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            TextBox addTipValue = new TextBox();
            addTipValue.KeyPress += intInput_KeyPress;
            addTipValue.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            addTipValue.BorderStyle = BorderStyle.None;
            addTipValue.Padding = new Padding(4, 4, 4, 4);
            addTipValue.TextAlign = HorizontalAlignment.Center;


            Label lblAddTip = new Label();
            lblAddTip.Text = "Add tip";
            lblAddTip.ForeColor = Color.Black;
            lblAddTip.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAddTip.Margin = new Padding(5);
            lblAddTip.Size = new Size(220, 93);
            lblAddTip.TabIndex = 26;


            TextBox addFeedbackValue = new TextBox();
            addFeedbackValue.AutoSize = false;
            addFeedbackValue.Height = 150;
            addFeedbackValue.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            addFeedbackValue.BorderStyle = BorderStyle.None;
            addFeedbackValue.Padding = new Padding(4, 4, 4, 4);

            Label lblAddFeedback = new Label();
            lblAddFeedback.Text = "Add feedback";
            lblAddFeedback.ForeColor = Color.Black;
            lblAddFeedback.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAddFeedback.Margin = new Padding(5);
            lblAddFeedback.Size = new Size(220, 73);
            lblAddFeedback.TabIndex = 26;

            Button load = new Button();
            load.Text = "Load menu items";
            load.ForeColor = Color.White;
            load.Location = new Point(10, line.Location.Y + 2);
            load.Name = $"load{bill.Id}";
            load.Size = new Size(116, 64);
            load.AutoSize = true;
            load.TabIndex = 21;
            load.Click += (sender, EventArgs) => { btn_loadItemsClicked(sender, EventArgs, billContainer, cash, creditCard, debitCard, lblAddTip, addTipValue, lblAddFeedback, addFeedbackValue, payment, payByCash); };
            load.BackColor = Color.FromArgb(67, 179, 215);
            load.FlatStyle = FlatStyle.Flat;
            load.TabStop = false;
            load.FlatAppearance.BorderSize = 0;
            load.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            if (Convert.ToUInt32(paymentNumber.Text) > 1)
            {
                billContainer.Controls.Add(load);
                load.Left = ((billContainer.Width - load.Width) / 2);
            }
            else
            {
                load.PerformClick();
                billContainer.Controls.Add(cash);
                billContainer.Controls.Add(creditCard);
                billContainer.Controls.Add(debitCard);
            }
            billContainer.Controls.Add(lblPayment);
            lblPayment.Left = ((billContainer.Width - load.Width) / 2);
            billContainer.Controls.Add(line);

            pnlBills.Controls.Add(billContainer);
            startY += billContainer.Height + 50;
            return startY;
        }

        #endregion

        #region ADD TIP
        private decimal AddTipValue_TextChanged(object sender, EventArgs e, Label TotalValue, Label SubTotalValue, Label TaxValue)
        {
            TextBox tipValue = sender as TextBox;
            if (tipValue.Text == "")
            {
                tipValue.Text = "0";
                TotalValue.Text = (Convert.ToDecimal(SubTotalValue.Text) + Convert.ToDecimal(TaxValue.Text)).ToString("#.##");
                totalPrice = Convert.ToDecimal(subtotal + tip);

            }
            else
            {
                TotalValue.Text = (Convert.ToDecimal(SubTotalValue.Text) + Convert.ToDecimal(TaxValue.Text) + Convert.ToDecimal(tipValue.Text)).ToString("#.##");
                totalPrice += Convert.ToDecimal(tipValue.Text);
            }
            totalUnitPrice = Convert.ToDecimal(TotalValue.Text);
            return totalUnitPrice;

        }
        #endregion

        #region SPLIT THE BILL
        private void paymentNumber_TextChanged(object sender, EventArgs e)
        {
            pnlBills.Controls.Clear();
            if (paymentNumber.Text == "" || paymentNumber.Text == "0")
            {
                paymentNumber.Text = "1";
            }
            numberOfLoads = 1;
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
        #endregion

        #region PAYMENT METHOD
        void btn_Checked(object sender, EventArgs e, RadioButton creditCard, RadioButton debitCard, Panel billContainer, TextBox payByCash, decimal totalPrice, Button pay)
        {
            CheckBox btn = sender as CheckBox;
            payByCash.Text = "0.00";
            payByCash.Location = new Point(btn.Location.X + btn.Width + 20, btn.Location.Y);
            payByCash.AutoSize = false;
            payByCash.Height = btn.Height;
            payByCash.BackColor = Color.White;
            payByCash.BorderStyle = BorderStyle.None;
            payByCash.Padding = new Padding(4, 4, 4, 4);
            payByCash.TextAlign = HorizontalAlignment.Center;
            pay.Location = new Point(payByCash.Location.X + payByCash.Width + 20, payByCash.Location.Y);
            pay.Height = payByCash.Height;
            pay.BackColor = Color.White;

            if (btn.Checked)
            {
                billContainer.Controls.Add(payByCash);
                btn.BackColor = Color.SandyBrown;
                btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#fbc651");
                btn.FlatAppearance.CheckedBackColor = Color.SandyBrown;
                if (!creditCard.Checked && !debitCard.Checked)
                {
                    payByCash.Text = totalPrice.ToString("#.##");
                    payByCash.Enabled = false;
                }
                else
                {
                    payByCash.Enabled = true;
                    payByCash.Text = (totalPrice - 1).ToString("#.##");

                }
                pay.Enabled = true;
                pay.BackColor = Color.FromArgb(67, 179, 215);
                billContainer.Controls.Add(pay);

            }
            else
            {
                payByCash.Text = "0.00";
                billContainer.Controls.Remove(payByCash);
                btn.BackColor = Color.FromArgb(206, 206, 206);
                billContainer.Controls.Remove(pay);
            }

        }

        void btn_RadioChecked(object sender, EventArgs e, RadioButton otherRadioBtn, CheckBox cash, Label cardValue, TextBox cashValue, Panel billContainer, Button payBtn)
        {
            RadioButton btn = sender as RadioButton;
            isChecked = btn.Checked;

            if (btn.Checked)
            {
                btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#fbc651");
                btn.FlatAppearance.CheckedBackColor = Color.SandyBrown;
                if (!cash.Checked)
                {
                    cardValue.Text = totalUnitPrice.ToString("#.##");
                }
                else
                {
                    cashValue.Text = (totalUnitPrice - 1).ToString("#.##");
                    cardValue.Text = (totalUnitPrice - Convert.ToDecimal(cashValue.Text)).ToString("#.##");
                }
            }
            else
            {
                if (!otherRadioBtn.Checked)
                {
                    cashValue.Text = (totalUnitPrice).ToString("#.##");
                    cashValue.Enabled = false;
                }
                btn.BackColor = Color.FromArgb(206, 206, 206);
                cardValue.Text = "0.00";
                billContainer.Controls.Remove(cardValue);
                billContainer.Controls.Remove(payBtn);
            }
        }
        void btn_RadioClicked(object sender, EventArgs e, TextBox cashValue, Panel billContainer, decimal totalPrice, Label cardValue, Button payBtn)
        {
            RadioButton btn = sender as RadioButton;

            cardValue.Text = (totalPrice - Convert.ToDecimal(cashValue.Text)).ToString("#.##");
            cardValue.Location = new Point(btn.Location.X + btn.Width + 20, btn.Location.Y);
            cardValue.Height = btn.Height;
            cardValue.BackColor = Color.White;
            cardValue.TextAlign = ContentAlignment.MiddleCenter;
            cardValue.ForeColor = Color.Gray;

            payBtn.Location = new Point(cardValue.Location.X + cardValue.Width + 20, btn.Location.Y);
            payBtn.AutoSize = false;
            payBtn.Height = btn.Height;
            payBtn.Padding = new Padding(4, 4, 4, 4);


            if ((btn.Checked && !isChecked))
            {
                btn.Checked = false;
                billContainer.Controls.Remove(cardValue);
                billContainer.Controls.Remove(payBtn);
                cardValue.Text = "0.00";

            }
            else
            {
                cardValue.Text = (totalUnitPrice - Convert.ToDecimal(cashValue.Text)).ToString("#.##");

                btn.Checked = true;
                isChecked = false;
                billContainer.Controls.Add(cardValue);
                billContainer.Controls.Add(payBtn);
                cashValue.Enabled = true;

            }
        }

        void cashAmountChanged(object sender, EventArgs e, Label debitCardValue, Label creditCardValue)
        {
            TextBox cashValue = sender as TextBox;

            if (cashValue.Text == "" || cashValue.Text == "0")
            {
                cashValue.Text = "1";
            }

            if (Convert.ToDecimal(debitCardValue.Text) > 0)
            {
                debitCardValue.Text = (totalUnitPrice - Convert.ToDecimal(cashValue.Text)).ToString("#.##");
            }
            else if (Convert.ToDecimal(creditCardValue.Text) > 0)
            {
                creditCardValue.Text = (totalUnitPrice - Convert.ToDecimal(cashValue.Text)).ToString("#.##");
            }
        }

        #endregion

        #region CHOOSE ITEMS TO PAY FOR
        void btn_saveSelectedOption(object sender, EventArgs e, CheckedListBox menuItems, Panel billContainer, Button saveSelected, CheckBox cash, RadioButton creditCard, RadioButton debitCard, Label lblAddTip, TextBox addTipValue, Label lblAddFeedback, TextBox addFeedbackValue, int paymentNum, TextBox payByCash)
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
                numberOfLoads++;
                for (int i = 0; i < invoiceCopy.Items.Count; i++)
                {
                    string stringToCompare = $"{i + 1}.: 1x - {invoiceCopy.Items[i].SubItems[0].Text} ({invoiceCopy.Items[i].SubItems[1].Text})";
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

                lblAddTip.Location = new Point(112, selectedOptions.Location.Y + selectedOptions.Height);

                billContainer.Controls.Add(addTipValue);
                addTipValue.Text = "0.00";
                addTipValue.Location = new Point(150 + lblAddTip.Width, lblAddTip.Location.Y);
                lblAddTip.Height = addTipValue.Height;

                billContainer.Controls.Add(lblAddFeedback);
                lblAddFeedback.Location = new Point(112, addTipValue.Location.Y + addTipValue.Height + 20);

                billContainer.Controls.Add(addFeedbackValue);
                addFeedbackValue.Location = new Point(112, lblAddFeedback.Location.Y + lblAddFeedback.Height);
                addFeedbackValue.Width = 700;

                Button payCash = new Button();
                payCash.Text = "Pay";
                payCash.Enabled = true;
                payCash.BackColor = Color.Gray;
                payCash.ForeColor = Color.White;
                payCash.Click += (sender, EventArgs) => { btnCash_Click(sender, EventArgs, payByCash, cash, payCash, payByCash, creditCard, debitCard); };
                payCash.FlatStyle = FlatStyle.Flat;
                payCash.TabStop = false;
                payCash.FlatAppearance.BorderSize = 0;
                payCash.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                billContainer.Controls.Add(cash);
                payByCash.Text = "0.00";
                cash.Location = new Point(112, addFeedbackValue.Location.Y + addFeedbackValue.Height + 50);
                cash.CheckStateChanged += (sender, EventArgs) => { btn_Checked(sender, EventArgs, creditCard, debitCard, billContainer, payByCash, finalTotal, payCash); };

                Label creditCardValue = new Label();
                creditCardValue.Text = "0.00";
                billContainer.Controls.Add(creditCard);

                Button payCredit = new Button();
                payCredit.Text = "Pay";
                payCredit.Enabled = true;
                payCredit.BackColor = Color.FromArgb(67, 179, 215);
                payCredit.ForeColor = Color.White;
                payCredit.Click += (sender, EventArgs) => { btnCreditCard_Click(sender, EventArgs, payByCash, creditCard, payCredit, creditCardValue, cash, debitCard); };
                payCredit.FlatStyle = FlatStyle.Flat;
                payCredit.TabStop = false;
                payCredit.FlatAppearance.BorderSize = 0;
                payCredit.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent


                creditCard.Location = new Point(112, cash.Location.Y + cash.Height + 20);
                creditCard.CheckedChanged += (sender, EventArgs) => { btn_RadioChecked(sender, EventArgs, debitCard, cash, creditCardValue, payByCash, billContainer, payCredit); };
                creditCard.Click += (sender, EventArgs) => { btn_RadioClicked(sender, EventArgs, payByCash, billContainer, finalTotal, creditCardValue, payCredit); };


                Label debitCardValue = new Label();
                debitCardValue.Text = "0.00";
                billContainer.Controls.Add(debitCard);

                Button payDebit = new Button();
                payDebit.Text = "Pay";
                payDebit.Enabled = true;
                payDebit.BackColor = Color.FromArgb(67, 179, 215);
                payDebit.ForeColor = Color.White;
                payDebit.Click += (sender, EventArgs) => { btnDebitCard_Click(sender, EventArgs, payByCash, debitCard, payDebit, debitCardValue, cash, creditCard); };
                payDebit.FlatStyle = FlatStyle.Flat;
                payDebit.TabStop = false;
                payDebit.FlatAppearance.BorderSize = 0;
                payDebit.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

                debitCard.Location = new Point(112, creditCard.Location.Y + creditCard.Height + 20);
                debitCard.CheckedChanged += (sender, EventArgs) => { btn_RadioChecked(sender, EventArgs, creditCard, cash, debitCardValue, payByCash, billContainer, payDebit); };
                debitCard.Click += (sender, EventArgs) => { btn_RadioClicked(sender, EventArgs, payByCash, billContainer, finalTotal, debitCardValue, payDebit); };

                payByCash.TextChanged += (sender, EventArgs) => { cashAmountChanged(sender, EventArgs, debitCardValue, creditCardValue); };


                List<Label> paymentSummaryValues = dynamicPaymentSummary(paymentNum, billContainer, 0, debitCard.Location.Y + debitCard.Height + 40);
                paymentSummaryValues[0].Text = finalTotal.ToString("#.##");
                paymentSummaryValues[1].Text = finalSubtotal.ToString("#.##");
                paymentSummaryValues[2].Text = finalTax.ToString("#.##");
                totalUnitPrice = Convert.ToDecimal(paymentSummaryValues[0].Text);
                addTipValue.TextChanged += (sender, EventArgs) => { finalTotal = AddTipValue_TextChanged(sender, EventArgs, paymentSummaryValues[0], paymentSummaryValues[1], paymentSummaryValues[2]); };

                // billContainer.Controls.Add(selectedOptions);
            }
            else
            {
                MessageBox.Show("Please select items for this payment!");
            }
        }

        void btn_loadItemsClicked(object sender, EventArgs e, Panel billContainer, CheckBox cash, RadioButton creditCard, RadioButton debitCard, Label lblAddTip, TextBox addTipValue, Label lblAddFeedback, TextBox addFeedbackValue, int paymentNum, TextBox payByCash)
        {
            Button btn = sender as Button;
            CheckedListBox menuItems = new CheckedListBox();
            menuItems.Location = new Point(10, 110);
            menuItems.Size = new Size(billContainer.Width, 50);
            menuItems.Height = invoiceCopy.Items.Count * 40;
            menuItems.Name = $"selection{paymentNumber}";
            menuItems.AutoSize = true;

            foreach (ListViewItem item in invoiceCopy.Items)
            {
                menuItems.Items.Add($"{invoiceCopy.Items.IndexOf(item) + 1}.: 1x - {item.SubItems[0].Text} ({item.SubItems[1].Text})");
            }


            Button saveSelected = new Button();
            saveSelected.Text = "SAVE";
            saveSelected.BackColor = Color.SandyBrown;
            saveSelected.ForeColor = Color.White;
            saveSelected.Location = new Point(10, 110 + invoiceCopy.Items.Count * 40 + 20);
            saveSelected.Name = $"save{bill.Id}";
            saveSelected.Size = new Size(116, 64);
            saveSelected.TabIndex = 21;
            saveSelected.Click += (sender, EventArgs) => { btn_saveSelectedOption(sender, EventArgs, menuItems, billContainer, saveSelected, cash, creditCard, debitCard, lblAddTip, addTipValue, lblAddFeedback, addFeedbackValue, paymentNum, payByCash); };
            btn.Enabled = false;

            billContainer.Controls.Add(saveSelected);

            if (numberOfLoads == Convert.ToInt32(paymentNumber.Text))
            {

                for (int i = 0; i < menuItems.Items.Count; i++) menuItems.SetItemChecked(i, true);

                saveSelected.PerformClick();

            }

            billContainer.Controls.Add(menuItems);
            billContainer.Controls.Remove(btn);
        }
        #endregion

        #region PAYMENT SUMMARY DYNAMIC CONTAINER
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
            groupBoxMoreInfo2.Name = "groupBoxMoreInfo2";
            groupBoxMoreInfo2.Size = new Size(935, 264);
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
        #endregion
    }
}
