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
    public partial class UC_IcedCoffee_Large : UserControl
    {

        public UC_IcedCoffee_Large()
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

        private void bt_ic_iced_amerikano_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-L Iced Americano", 1, 39));
        }

        private void bt_ic_iced_cappuccino_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-L Iced Cappuccino", 1, 39));
        }

        private void bt_ic_iced_macchiato_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-L Iced Macchiato", 1, 39));
        }

        private void bt_ic_iced_coffee_vanilla_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-L Iced Coffee Vanilla", 1, 39));
        }

        private void bt_ic_iced_coffee_caramel_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-L Iced Coffee Caramel", 1, 39));
        }

        private void bt_ic_iced_coffee_mpcha_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-L Iced Coffee Mocha", 1, 39));
        }

        private void bt_ic_iced_dark_choco_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-L Iced Dark Choco", 1, 39));
        }
    }
}
