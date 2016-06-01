using Newtonsoft.Json;
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
    public partial class newQuestion : Form
    {
        public Content qJetContent;
        private string rootPath;
        private string NewPromptAudio = "";
        private string NewKeywordAudio = "";

        public newQuestion(string p)
        {
            InitializeComponent();

            rootPath = p;
        }

        private void chkbxJoke_CheckedChanged(object sender, EventArgs e)
        {
            toggleFormAvail();
        }

        private void toggleFormAvail()
        {
            if (chkbxJoke.Checked)
            {
                txtKeywords.Enabled = true;
                txtKeywordResponse.Enabled = true;
                btnReplaceKeywordMP3.Enabled = true;
            }
            else
            {
                txtKeywords.Enabled = false;
                txtKeywordResponse.Enabled = false;
                btnReplaceKeywordMP3.Enabled = false;
            }
        }

        private void btnReplacePromptMP3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            NewPromptAudio = openFileDialog1.FileName;
        }

        private void btnReplaceKeywordMP3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            NewKeywordAudio = openFileDialog1.FileName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i;
            int.TryParse(txtId.Text, out i);
            txtId.Text = i + "";

            if (Directory.Exists(rootPath + "Question\\"+txtId.Text))
            {
                MessageBox.Show("A question with that ID already exists.", "Error", MessageBoxButtons.OK);
            }
            else if(NewPromptAudio == "")
            {
                MessageBox.Show("Prompt audio is missing.", "Error", MessageBoxButtons.OK);
            }
            else if(chkbxJoke.Checked && NewKeywordAudio == "")
            {
                MessageBox.Show("Keyword response audio is missing.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                dataJet questionData = new dataJet();
                questionData.fields = new List<Field>();
                questionData.fields.Add(new Field() { t = "B", v = boolText(chkbxJoke.Checked), n = "HasJokeAudio" });
                questionData.fields.Add(new Field() { t = "S", v = txtKeywords.Text, n = "Keywords" });
                questionData.fields.Add(new Field() { t = "S", v = "", n = "Author" });
                questionData.fields.Add(new Field() { t = "S", v = txtKeywordResponse.Text, n = "KeywordResponseText" });
                questionData.fields.Add(new Field() { t = "S", v = txtPrompt.Text, n = "PromptText" });
                questionData.fields.Add(new Field() { t = "S", v = "", n = "Location" });
                questionData.fields.Add(new Field() { t = "A", v = "kwresponse", n = "KeywordResponseAudio" });
                questionData.fields.Add(new Field() { t = "A", v = "prompt", n = "PromptAudio" });

                qJetContent = new Content() { x = chkbxExplicit.Checked, id = int.Parse(txtId.Text), prompt = txtPrompt.Text };

                Directory.CreateDirectory(rootPath + "Question\\" + txtId.Text);

                string dataJet = JsonConvert.SerializeObject(questionData, Formatting.None);
                dataJet = unicodeInterface.replacePunctuation(dataJet);

                using (StreamWriter newTask = new StreamWriter(rootPath + "Question\\" + txtId.Text + "\\data.jet", false))
                {
                    newTask.WriteLine(dataJet);
                }

                File.Copy(NewPromptAudio, rootPath + "Question\\" + txtId.Text + "\\prompt" + ".mp3", true);
                if(chkbxJoke.Checked)
                    File.Copy(NewKeywordAudio, rootPath + "Question\\" + txtId.Text + "\\kwresponse" + ".mp3", true);

                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private string boolText(bool b)
        {
            if (b)
                return "true";
            else
                return "false";
        }

        private void txtPrompt_Leave(object sender, EventArgs e)
        {
            int i;
            int.TryParse(txtId.Text, out i);
            txtId.Text = i + "";
        }
    }
}
