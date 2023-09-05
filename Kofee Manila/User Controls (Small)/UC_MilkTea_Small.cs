using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kofee_Manila.User_Controls__Small_
{
    public partial class UC_MilkTea_Small : UserControl
    {
        public UC_MilkTea_Small()
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

        private void bt_mt_okinawa_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Okinawa", 1, 29));
        }

        private void bt_mt_wintermelon_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Wintermelon", 1, 29));
        }

        private void bt_mt_red_velvet_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Red Velvet", 1, 29));
        }

        private void bt_mt_mango_cheesecake_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Mango Cheesecake", 1, 29));
        }

        private void bt_mt_matcha_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Matcha", 1, 29));
        }

        private void bt_mt_dark_choco_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Dark Choco", 1, 29));
        }

        private void bt_mt_taro_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Taro", 1, 29));
        }

        private void bt_mt_cookies_and_cream_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Cookies & Cream", 1, 29));
        }

        private void bt_mt_hazelnut_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Hazelnut", 1, 29));
        }

        private void bt_mt_hokkaido_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Hokkaido", 1, 29));
        }

        private void bt_mt_black_sugar_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Brown Sugar", 1, 29));
        }

        private void bt_mt_black_forest_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-S Black Forest", 1, 29));
        }
    }
}
