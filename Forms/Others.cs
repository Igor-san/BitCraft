using BitCraft.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCraft.Forms
{
    public partial class Others : Form
    {
        public Others()
        {
            InitializeComponent();
        }

        private void buttonConvertToRipemde160_Click(object sender, EventArgs e)
        {
            textBoxRipemde160.Text = BitcoinAddressConverter.ToRipemd160(textBoxBtcAddress.Text);
        }

        private void buttonToAddress_Click(object sender, EventArgs e)
        {
            //С сегвит пока не разобрался как преобразовывать
            textBoxToAddress.Text = BitcoinAddressConverter.FromRipemd160(textBoxRipemde160.Text);
        }
  
    }
}
