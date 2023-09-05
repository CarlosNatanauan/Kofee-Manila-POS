using Guna.UI2.WinForms;
using Kofee_Manila.Sections;
using Kofee_Manila.User_Controls__Large_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kofee_Manila
{
    public partial class MainForm : Form
    {

        bool sidebarExpand;
        Guna2Button lastClickedButton = null;
        private Form activeForm = null;


        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();


        public MainForm()
        {
            InitializeComponent();
            sidebarExpand = true;
            ClearData();
            LoadData();
            PaperSize receiptPaperSize = new PaperSize("Receipt", ConvertMillimetersToPixels(56), ConvertMillimetersToPixels(300));
            // Set the paper size to your print document.
            printDocument1.DefaultPageSettings.PaperSize = receiptPaperSize;
        }


        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(childForm);
            mainContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        public void CloseActiveForm()
        {
            if (activeForm != null)
            {
                // Check if the active form is of type frmVehicle
                if (activeForm is frmIcedCoffee)
                {
                    // Enable the gunaBTvehicle button
                    btIcedCoffee.Enabled = true;
                }
                else if (activeForm is frmFrape)
                {
                    btFrape.Enabled = true;
                }
                else if (activeForm is frmFruitTea)
                {
                    btFruitTea.Enabled = true;
                }
                else if (activeForm is frmMilktea)
                {
                    btMilkTea.Enabled = true;
                }
                else if (activeForm is frmAddOns)
                {
                    btAddOns.Enabled = true;
                }

                activeForm.Close();
                activeForm = null;
            }

        }

        

        private void menuButton1_Click(object sender, EventArgs e)
        {
            // If the sidebar is minimized, set sidebarExpand to false to start maximizing it
            if (sidebar.Width == sidebar.MinimumSize.Width)
            {
                sidebarExpand = false;
                sidebarTimer.Start();
            }
            // If the sidebar is maximized, set sidebarExpand to true to start minimizing it
            else if (sidebar.Width == sidebar.MaximumSize.Width)
            {
                sidebarExpand = true;
                sidebarTimer.Start();
            }
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void mainContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            // Assign the ButtonClick method to the Click event of each button
            btIcedCoffee.Click += ButtonClick;
            btFrape.Click += ButtonClick;
            btMilkTea.Click += ButtonClick;
            btFruitTea.Click += ButtonClick;
            btAddOns.Click += ButtonClick;
        }


        // Create a single Click event handler for all buttons
        private void ButtonClick(object sender, EventArgs e)
        {
            // Then cast sender to Guna2Button so we can access the clicked button
            var clickedButton = (Guna2Button)sender;

            // Enable the last clicked button if it exists
            if (lastClickedButton != null)
            {
                lastClickedButton.Enabled = true;
            }

            // Disable the clicked button and store it as the last clicked button
            clickedButton.Enabled = false;
            lastClickedButton = clickedButton;

            // If the sidebar is maximized, set sidebarExpand to true to start minimizing it
            if (sidebar.Width == sidebar.MaximumSize.Width)
            {
                sidebarExpand = true;
                sidebarTimer.Start();
            }
        }

        private void btIcedCoffee_Click(object sender, EventArgs e)
        {
            frmIcedCoffee f = new frmIcedCoffee(this); // pass this form as argument
            openChildForm(f);
            f.TopLevel = false;
            mainContainer.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void btFrape_Click(object sender, EventArgs e)
        {
            frmFrape f = new frmFrape(this); // pass this form as argument
            openChildForm(f);
            f.TopLevel = false;
            mainContainer.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void btMilkTea_Click(object sender, EventArgs e)
        {
            frmMilktea f = new frmMilktea(this); // pass this form as argument
            openChildForm(f);
            f.TopLevel = false;
            mainContainer.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void btFruitTea_Click(object sender, EventArgs e)
        {
            frmFruitTea f = new frmFruitTea(this); // pass this form as argument
            openChildForm(f);
            f.TopLevel = false;
            mainContainer.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void btAddOns_Click(object sender, EventArgs e)
        {
            frmAddOns f = new frmAddOns(this); // pass this form as argument
            f.OrderAdded += (o, args) => AddOrders(args.ProductName, args.Quantity, args.Cost); // Subscribe to event here
            openChildForm(f);
            f.TopLevel = false;
            mainContainer.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        public void AddOrders(string productName, int quantity, double cost)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.AddOrders(productName, quantity, cost);
            LoadData();
        }

        private void LoadData()
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            DataTable orders = dbHandler.GetOrders();

            dgvOrders.AutoGenerateColumns = false;

            dgvOrders.Columns["product"].DataPropertyName = "Product";
            dgvOrders.Columns["qty"].DataPropertyName = "Qty";
            dgvOrders.Columns["cost"].DataPropertyName = "Cost";
            dgvOrders.Columns["Id"].DataPropertyName = "Id";
            dgvOrders.Columns["Id"].Visible = false;

            orders.DefaultView.Sort = "Id DESC";
            dgvOrders.DataSource = orders.DefaultView;

            double totalAmount = dbHandler.GetTotalAmount();
            tb_total_amount.Text = "P" + totalAmount.ToString();
        }


        private void ClearData()
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.ClearOrders();
            LoadData(); // Refresh the DataGridView
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            int id = (int)((DataRowView)dgvOrders.Rows[e.RowIndex].DataBoundItem).Row["Id"];
            double unitCost = (double)((DataRowView)dgvOrders.Rows[e.RowIndex].DataBoundItem).Row["Cost"] / Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["qty"].Value);

            if (e.ColumnIndex == dgvOrders.Columns["rem"].Index)
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                dbHandler.RemoveOrder(id);
                LoadData();
            }
            else if (e.ColumnIndex == dgvOrders.Columns["sub"].Index)
            {
                int quantity = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["qty"].Value) - 1;
                double cost = unitCost * quantity;
                DatabaseHandler dbHandler = new DatabaseHandler();
                dbHandler.UpdateQuantityAndCost(id, quantity, cost); // Make sure to call the correct method

                if (quantity == 0)
                {
                    dbHandler.RemoveOrder(id);
                }
                LoadData();
            }
            else if (e.ColumnIndex == dgvOrders.Columns["add"].Index)
            {
                int quantity = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["qty"].Value) + 1;
                double cost = unitCost * quantity;

                DatabaseHandler dbHandler = new DatabaseHandler();
                dbHandler.UpdateQuantityAndCost(id, quantity, cost); // Make sure to call the correct method
                LoadData();
            }
        }

        private void tb_total_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btClearOrder_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            tb_cash.Text += button.Text;
        }

        private void tb_cash_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt1_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender; 
            tb_cash.Text += button.Text;
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;  
            tb_cash.Text += button.Text;
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            tb_cash.Text += button.Text;
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            tb_cash.Text += button.Text;
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            tb_cash.Text += button.Text;
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            tb_cash.Text += button.Text;
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            tb_cash.Text += button.Text;
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            tb_cash.Text += button.Text;
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender; 
            tb_cash.Text += button.Text;
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            tb_cash.Text = "";
        }




        private void PrintReceipt()
        {
            printDocument1.PrinterSettings.PrinterName = "XP-58IID";
            printDocument1.Print();
        }



        private void ShowPrintPreview()
        {
            printPreviewDialog1.ShowDialog();
        }


        private void bt_pay_Click(object sender, EventArgs e)
        {
            ShowPrintPreview();
            ClearData();
            tb_cash.Text = "";
        }


        private int ConvertMillimetersToPixels(float millimeters)
        {
            return (int)(millimeters * 3.937); // Assumes 100 DPI, which is default for many printers. This can be adjusted if required.
        }



        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // Set up font sizes - adjust these as needed
            Font headerFont = new Font("Courier New", 9, FontStyle.Bold); // For the title
            Font orderFont = new Font("Courier New", 7); // For order details
            Font footerFont = new Font("Courier New", 8, FontStyle.Italic); // For footer

            float yPos = 10;
            float leftMargin = 0;

            // Centered Header
            SizeF stringSize = graphics.MeasureString("KOFEE MANILA", headerFont);
            float center = (e.PageBounds.Width - stringSize.Width) / 2;
            graphics.DrawString("KOFEE MANILA", headerFont, Brushes.Black, center, yPos);
            yPos += 15; // move down 15 units

            // Centered Subheader
            stringSize = graphics.MeasureString("SANTO DOMINGO", headerFont);
            center = (e.PageBounds.Width - stringSize.Width) / 2;
            graphics.DrawString("SANTO DOMINGO", headerFont, Brushes.Black, center, yPos);
            yPos += 15;

            graphics.DrawString("ORDERS:", orderFont, Brushes.Black, leftMargin, yPos);
            yPos += 15;

            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                string product = row.Cells["product"].Value.ToString();
                string qty = row.Cells["qty"].Value.ToString();
                string cost = row.Cells["cost"].Value.ToString();
                string orderLine = $"{product}";
                float costPosition = e.PageBounds.Width - graphics.MeasureString($" x{qty} = {cost}", orderFont).Width;

                graphics.DrawString(orderLine, orderFont, Brushes.Black, leftMargin, yPos);
                graphics.DrawString($" x{qty} = {cost}", orderFont, Brushes.Black, costPosition, yPos);

                yPos += 15; // adjust this value based on how much space you want between lines
            }

            // Drawing a separator line
            graphics.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width, yPos);
            yPos += 10;

            DatabaseHandler dbHandler = new DatabaseHandler();
            double totalAmount = dbHandler.GetTotalAmount();

            float totalAmountPosition = e.PageBounds.Width - graphics.MeasureString($"P{totalAmount}", orderFont).Width;
            graphics.DrawString("TOTAL:", orderFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString($"P{totalAmount}", orderFont, Brushes.Black, totalAmountPosition, yPos);
            yPos += 15;

            float cashPosition = e.PageBounds.Width - graphics.MeasureString($"{tb_cash.Text}", orderFont).Width;
            graphics.DrawString("PAYMENT:", orderFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString($"{tb_cash.Text}", orderFont, Brushes.Black, cashPosition, yPos);
            yPos += 15;

            // Drawing a separator line
            graphics.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width, yPos);
            yPos += 10;

            stringSize = graphics.MeasureString("Thank you for purchasing!", footerFont);
            center = (e.PageBounds.Width - stringSize.Width) / 2;
            graphics.DrawString("Thank you for purchasing!", footerFont, Brushes.Black, center, yPos);
            yPos += 15;

            // Clean up
            headerFont.Dispose();
            orderFont.Dispose();
            footerFont.Dispose();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

    }
}
