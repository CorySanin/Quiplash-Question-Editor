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
    /// <summary>
    /// Find a question with a matching string
    /// </summary>
    public partial class FindQuestion : Form
    {
        public string findString = "";
        public bool findFirstInstance;

        public FindQuestion(string s)
        {
            InitializeComponent();
            txtFindText.Text = s;
        }

        /// <summary>
        /// Don't search, then close
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Tell the main form to start searching for FindQuestion.findString
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            findString = txtFindText.Text;
            findFirstInstance = true;
            this.Close();
        }

        /// <summary>
        /// Focus on the textbox immediately
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void FindQuestion_Load(object sender, EventArgs e)
        {
            txtFindText.Focus();
        }

        /// <summary>
        /// Searches for the next one instead of the first instance
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void btnFindNext_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            findString = txtFindText.Text;
            findFirstInstance = false;
            this.Close();
        }
    }
}
