using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace Quiplash_Question_Editor
{
    /// <summary>
    /// The main form that keeps everything together ♥
    /// </summary>
    public partial class Form1 : Form
    {
        private string questionJetFilename;
        private string questionPath;
        private questionJet questionIndex;
        private string lastSearchString = "";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Starts the open subprocedure immediately
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStrip1.ShowItemToolTips = false;
            this.Show();
            open();
        }

        /// <summary>
        /// Bring up the editQuestion form to edit the currently selected question
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i = ListQuestionJet.SelectedIndex;
            if (i != -1)
            {
                editQuestion editWindow = new editQuestion(questionIndex.content[i], questionPath);
                var result = editWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    questionIndex.content[i] = editWindow.qJetContent;
                    saveQuestionJet();
                }
            }
        }

        /// <summary>
        /// Prompt the user whether or not they want to delete the selected question.
        /// Then do what they want.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i = ListQuestionJet.SelectedIndex;
            if (i != -1)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to remove this question from Question.jet?","Confirm",MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    questionIndex.content.RemoveAt(i);
                    ListQuestionJet.Items.RemoveAt(i);
                    saveQuestionJet();
                }
            }
        }

        /// <summary>
        /// Creates a new Question.jet file, overwrites the old one
        /// </summary>
        private void saveQuestionJet()
        {
            string questionJet = JsonConvert.SerializeObject(questionIndex, Formatting.None);
            questionJet = unicodeInterface.replacePunctuation(questionJet);

            using (StreamWriter newTask = new StreamWriter(questionJetFilename, false))
            {
                newTask.WriteLine(questionJet);
            }
        }

        /// <summary>
        /// Calls the createNew subprocedure
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void BtnNew_Click(object sender, EventArgs e)
        {
            createNew();
        }

        /// <summary>
        /// Bring up the newQuestion form to create a new question
        /// </summary>
        private void createNew()
        {
            if (questionJetFilename != "")
            {
                newQuestion createWindow = new newQuestion(questionPath);
                var result = createWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    questionIndex.content.Add(createWindow.qJetContent);
                    ListQuestionJet.Items.Add(createWindow.qJetContent.prompt);
                    saveQuestionJet();
                }
            }
            else
                open();
        }

        /// <summary>
        /// Opens an open file dialog and prepares the form.
        /// </summary>
        private void open()
        {
            string questionJetFileContents = "";
            openFileDialog1.ShowDialog();
            questionJetFilename = openFileDialog1.FileName;
            questionPath = questionJetFilename.Replace(openFileDialog1.SafeFileName, "");

            try
            {
                using (StreamReader sr = new StreamReader(questionJetFilename))
                {
                    questionJetFileContents = questionJetFileContents + sr.ReadToEnd() + " ";
                }

                questionIndex = JsonConvert.DeserializeObject<questionJet>(questionJetFileContents);
                ListQuestionJet.Items.Clear();

                for (int i = 0; i < questionIndex.content.Count; i++)
                {
                    ListQuestionJet.Items.Add(questionIndex.content.ToArray()[i].prompt);
                }

                if(!File.Exists(questionJetFilename+".bak"))
                    File.Copy(questionJetFilename, questionJetFilename + ".bak");
            }
            catch
            {
                questionJetFilename = questionPath = "";
            }
        }

        /// <summary>
        /// Calls the open subprocedure
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        /// <summary>
        /// Exits the program
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens the about dialog
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        /// <summary>
        /// Starts the find subprocedure
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            find();
        }

        /// <summary>
        /// Prompts the user to input a string and then this form searches for the first instance of that string.
        /// </summary>
        private void find()
        {
            FindQuestion finddialog = new FindQuestion(lastSearchString);
            var result = finddialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lastSearchString = finddialog.findString;
                bool searching = true;
                int istart;
                if (finddialog.findFirstInstance)
                    istart = 0;
                else
                    istart = ListQuestionJet.SelectedIndex + 1;
                for (int i = istart; (searching && i < ListQuestionJet.Items.Count); i++)
                {
                    if (ListQuestionJet.Items[i].ToString().Contains(lastSearchString))
                    {
                        ListQuestionJet.SelectedIndex = i;
                        searching = false;
                    }
                }
            }
        }

        /// <summary>
        /// process keyboard shortcuts
        /// </summary>
        /// <param name="msg">message</param>
        /// <param name="keyData">Keys</param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                find();
                return true;
            }
            else if(keyData == (Keys.Control | Keys.O))
            {
                open();
                return true;
            }
            else if(keyData == (Keys.Control | Keys.N))
            {
                createNew();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
