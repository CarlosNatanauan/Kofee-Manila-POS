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
    public partial class UC_FruitTea_Large : UserControl
    {
        public UC_FruitTea_Large()
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

        private void bt_ft_green_apple_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("FT-L Green Apple", 1, 39));
        }

        private void bt_ft_blueberry_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("FT-L Blueberry", 1, 39));
        }

        private void bt_ft_strawberry_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("FT-L Strawberry", 1, 39));
        }

        private void bt_ft_lychie_large_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("FT-L Lychie", 1, 39));
        }
    }
}
