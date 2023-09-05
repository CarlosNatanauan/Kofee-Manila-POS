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
    public partial class UC_MilkTea_Large : UserControl
    {
        public UC_MilkTea_Large()
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

        private void bt_mt_okinawa_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Okinawa", 1, 39));
        }

        private void bt_mt_wintermelon_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Wintermelon", 1, 39));
        }

        private void bt_mt_red_velvet_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Red Velvet", 1, 39));
        }

        private void bt_mt_mango_cheesecake_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Mango Cheesecake", 1, 39));
        }

        private void bt_mt_matcha_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Matcha", 1, 39));
        }

        private void bt_mt_dark_choco_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Dark Choco", 1, 39));
        }

        private void bt_mt_taro_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Taro", 1, 39));
        }

        private void bt_mt_cookies_and_cream_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Cookies & Cream", 1, 39));
        }

        private void bt_mt_hazelnut_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Hazelnut", 1, 39));
        }

        private void bt_mt_hokkaido_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Hokkaido", 1, 39));
        }

        private void bt_mt_black_sugar_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Brown Sugar", 1, 39));
        }

        private void bt_mt_black_forest_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("MT-L Black Forest", 1, 39));
        }
    }
}
