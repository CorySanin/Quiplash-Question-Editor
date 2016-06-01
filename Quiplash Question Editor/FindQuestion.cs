using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quiplash_Question_Editor
{
    public partial class FindQuestion : Form
    {
        public string findString = "";
        public FindQuestion()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            findString = txtFindText.Text;
            this.Close();
        }

        private void FindQuestion_Load(object sender, EventArgs e)
        {
            txtFindText.Focus();
        }
    }
}
