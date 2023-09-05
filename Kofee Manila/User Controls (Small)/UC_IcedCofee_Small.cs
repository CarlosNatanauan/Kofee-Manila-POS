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
    public partial class UC_IcedCofee_Small : UserControl
    {
        public UC_IcedCofee_Small()
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

        private void UC_IcedCofee_Load(object sender, EventArgs e)
        {
            
        }

        private void bt_ic_iced_amerikano_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-S Iced Americano", 1, 29));
        }

        private void bt_ic_iced_cappuccino_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-S Iced Cappuccino", 1, 29));
        }

        private void bt_ic_iced_macchiato_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-S Iced Macchiato", 1, 29));
        }

        private void bt_ic_iced_coffee_vanilla_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-S Iced Coffee Vanilla", 1, 29));
        }

        private void bt_ic_iced_coffee_caramel_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-S Iced Coffee Caramel", 1, 29));
        }

        private void bt_ic_iced_coffee_mpcha_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-S Iced Coffee Mocha", 1, 29));
        }

        private void bt_ic_iced_dark_choco_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("IC-S Iced Dark Choco", 1, 29));
        }
    }
}
