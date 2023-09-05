using Kofee_Manila.User_Controls__Large_;
using Kofee_Manila.User_Controls__Small_;
using Kofee_Manila.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kofee_Manila.Sections
{
    public partial class frmMilktea : Form
    {
        private MainForm MainForm { get; set; }
        private UC_MilkTea_Small ucSmall;
        private UC_MilkTea_Large ucLarge;

        public frmMilktea(MainForm mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;

            ucSmall = new UC_MilkTea_Small();
            ucSmall.OrderAdded += (o, args) => MainForm.AddOrders(args.ProductName, args.Quantity, args.Cost);
            ucLarge = new UC_MilkTea_Large();
            ucLarge.OrderAdded += (o, args) => MainForm.AddOrders(args.ProductName, args.Quantity, args.Cost);

            addUserControl(ucSmall); // Set small as default
        }


        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            ucContainer.Controls.Clear();
            ucContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btSmall_Click(object sender, EventArgs e)
        {
            addUserControl(ucSmall);
        }

        private void btLarge_Click(object sender, EventArgs e)
        {
            addUserControl(ucLarge);
        }

        private void btCloseVehicle_Click(object sender, EventArgs e)
        {
            MainForm.btFruitTea.Enabled = true;  // Enable the button when this form is closed
            MainForm.CloseActiveForm();
            this.Close();
        }
    }
}
