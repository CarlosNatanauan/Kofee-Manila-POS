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
    public partial class UC_FruitTea_Small : UserControl
    {
        public UC_FruitTea_Small()
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



        private void UC_FruitTea_Small_Load(object sender, EventArgs e)
        {

        }

        private void bt_ft_green_apple_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("FT-S Green Apple", 1, 29));
        }

        private void bt_ft_blueberry_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("FT-S Blueberry", 1, 29));
        }

        private void bt_ft_strawberry_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("FT-S Strawberry", 1, 29));
        }

        private void bt_ft_lychie_small_Click(object sender, EventArgs e)
        {
            OrderAdded?.Invoke(this, new OrderEventArgs("FT-S Lychie", 1, 29));
        }
    }
}
