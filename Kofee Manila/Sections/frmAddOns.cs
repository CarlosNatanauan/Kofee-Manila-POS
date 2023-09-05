using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kofee_Manila.Sections
{
    public partial class frmAddOns : Form
    {
        private MainForm MainForm { get; set; }

        
        public frmAddOns(MainForm mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
        }

        private void btCloseVehicle_Click(object sender, EventArgs e)
        {
            MainForm.btAddOns.Enabled = true;  // Enable the button when this form is closed
            MainForm.CloseActiveForm();
            this.Close();
        }


        public event EventHandler<OrderEventArgs> OrderAdded;
        public class OrderEventArgs : EventArgs
        {
            public string ProductName { get; }
            public int Quantity { get; }
            public double Cost { get; }

            public OrderEventArgs(string productName, int quantity, double cost)
            {
                ProductName = productName;
                Quantity = quantity;
                Cost = cost;
            }
        }


        private void bt_pearl_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("AO Pearl", 1, 9));
        }

        private void bt_crystal_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("AO Crystal", 1, 9));
        }

        private void bt_coffee_jelly_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("AO Coffee Jelly", 1, 9));
        }

        private void bt_crushed_oreo_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("AO Crushed Oreo", 1, 9));
        }

        private void bt_whip_cream_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("AO Whip Cream", 1, 9));
        }
    }
}
