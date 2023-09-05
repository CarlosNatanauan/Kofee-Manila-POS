using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kofee_Manila.UserControls
{
    public partial class UC_Frape_Small : UserControl
    {
        public UC_Frape_Small()
        {
            InitializeComponent();
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
                Quantity = quantity;
                Cost = cost;
            }
        }




        private void UC_Frape_Small_Load(object sender, EventArgs e)
        {

        }

        private void bt_f_coffee_vanilla_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Coffee Vanilla", 1, 49));
        }

        private void bt_f_mocha_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Mocha", 1, 49));
        }

        private void bt_f_coffee_jelly_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Coffee Jelly", 1, 49));
        }

        private void bt_f_java_chip_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Java Chip", 1, 49));
        }

        private void bt_f_black_forest_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Black Forest", 1, 49));
        }

        private void bt_f_coffee_oreo_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Coffee Oreo", 1, 49));
        }

        private void bt_f_coffee_mint_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Coffee Mint", 1, 49));
        }

        private void bt_f_chocolate_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Chocolate", 1, 49));
        }

        private void bt_f_coockies_and_cream_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Cookies & Cream", 1, 49));
        }

        private void bt_f_vanilla_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Vanilla", 1, 49));
        }

        private void bt_f_strawberry_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Strawberry", 1, 49));
        }

        private void bt_f_blueberry_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Blueberry", 1, 49));
        }

        private void bt_f_choco_chip_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-S Choco Chip", 1, 49));
        }
    }
}
