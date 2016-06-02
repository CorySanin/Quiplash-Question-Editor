using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Quiplash_Question_Editor
{
    /// <summary>
    /// Form for creating a new question
    /// </summary>
    public partial class newQuestion : Form
    {
        public Content qJetContent;
        private string rootPath;
        private string NewPromptAudio = "";
        private string NewKeywordAudio = "";

        /// <summary>
        /// Constructor
        /// sets rootPath to p
        /// </summary>
        /// <param name="p">Question.jet containing directory</param>
        public newQuestion(string p)
        {
            InitializeComponent();

            rootPath = p;
        }

        /// <summary>
        /// Make sure the keyword-joke fields are correctly enabled or disabled
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void chkbxJoke_CheckedChanged(object sender, EventArgs e)
        {
            toggleFormAvail();
        }

        /// <summary>
        /// Make keyword-joke related fields enabled or disabled, depending on the state of chkbxJoke
        /// </summary>
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

        /// <summary>
        /// Opens a dialog for replacement prompt audio.
        /// If the user selects something, it stores the filename as a variable for later.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void btnReplacePromptMP3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                NewPromptAudio = openFileDialog1.FileName;
                lblPromptAudioFName.Text = openFileDialog1.SafeFileName;
            }
        }

        /// <summary>
        /// Opens a dialog for replacement keyword joke audio.
        /// If the user selects something, it stores the filename as a variable for later.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void btnReplaceKeywordMP3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                NewKeywordAudio = openFileDialog1.FileName;
                lblJokeAudioFName.Text = openFileDialog1.SafeFileName;
            }
        }

        /// <summary>
        /// Cancels all actions and closes the form
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Adds the question. Makes it exist.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
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

        /// <summary>
        /// Takes a bool value and spits out "true" or "false" (as a string)
        /// </summary>
        /// <param name="b">a boolean value</param>
        /// <returns>Wheter the input was "true" or "false" (as a string)</returns>
        private string boolText(bool b)
        {
            if (b)
                return "true";
            else
                return "false";
        }

        /// <summary>
        /// Checks to see if the ID is actually a number
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void txtPrompt_Leave(object sender, EventArgs e)
        {
            int i;
            int.TryParse(txtId.Text, out i);
            txtId.Text = i + "";
        }
    }
}
