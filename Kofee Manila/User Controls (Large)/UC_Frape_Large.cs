using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kofee_Manila.User_Controls__Large_
{
    public partial class UC_Frape_Large : UserControl
    {
        public UC_Frape_Large()
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

        private void bt_f_coffee_vanilla_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Coffee Vanilla", 1, 59));
        }

        private void bt_f_mocha_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Mocha", 1, 59));
        }

        private void bt_f_coffee_jelly_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Coffee Jelly", 1, 59));
        }

        private void bt_f_java_chip_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Java Chip", 1, 59));
        }

        private void bt_f_black_forest_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Java Chip", 1, 59));
        }

        private void bt_f_coffee_oreo_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Coffee Oreo", 1, 59));
        }

        private void bt_f_coffee_mint_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Coffee Mint", 1, 59));
        }

        private void bt_f_chocolate_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Chocolate", 1, 59));
        }

        private void bt_f_coockies_and_cream_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Cookies & Cream", 1, 59));
        }

        private void bt_f_vanilla_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Vanilla", 1, 59));
        }

        private void bt_f_strawberry_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Strawberry", 1, 59));
        }

        private void bt_f_blueberry_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Blueberry", 1, 59));
        }

        private void bt_f_choco_chip_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("F-L Choco Chip", 1, 59));
        }

        private void guna2ImageButton15_Click(object sender, EventArgs e)
        {

        }
    }
}
