using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmNewChar : Form
    {
        public frmNewChar()
        {
            InitializeComponent();
        }

        public ushort AsciiCharWidth
        {
            get { return Convert.ToUInt16(numWidth.Value); }
        }

        public char AsciiChar
        {
            get { return txtChar.Text[0]; }
        }

        public ushort Kerning
        {
            get { return Convert.ToUInt16(txtKerning.Text); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtKerning_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
