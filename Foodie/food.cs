using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodie
{
    public partial class food : Form
    {
        public food()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtMiles.Text = "";
            txtTypes.Text = "";
            textBox1.Text = "";
        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            var response = await APIHelper.Get(txtCode.Text, txtTypes.Text);
            textBox1.Text = APIHelper.BeautifyJson(response);
        }
    }
}
