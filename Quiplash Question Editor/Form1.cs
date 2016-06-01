using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quiplash_Question_Editor
{
    public partial class Form1 : Form
    {
        private string questionJetFilename;
        private string questionPath;
        private questionJet questionIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStrip1.ShowItemToolTips = false;
            this.Show();
            open();
        }

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

        private void saveQuestionJet()
        {
            string dataJet = JsonConvert.SerializeObject(questionIndex, Formatting.None);
            dataJet = unicodeInterface.replacePunctuation(dataJet);

            using (StreamWriter newTask = new StreamWriter(questionJetFilename, false))
            {
                newTask.WriteLine(dataJet);
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindQuestion finddialog = new FindQuestion();
            var result = finddialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string search = finddialog.findString;
                bool searching = true;
                for(int i = 0; (searching && i < ListQuestionJet.Items.Count); i++)
                {
                    if(ListQuestionJet.Items[i].ToString().Contains(search))
                    {
                        ListQuestionJet.SelectedIndex = i;
                        searching = false;
                    }
                }
            }
        }
    }
}
