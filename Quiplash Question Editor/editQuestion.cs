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
    public partial class editQuestion : Form
    {
        public Content qJetContent;
        private string rootPath;
        private string qPath;
        private dataJet questionData;
        private int HasJokeAudioIndex;
        private int KeywordsIndex;
        private int AuthorIndex;
        private int KeywordResponseTextIndex;
        private int PromptTextIndex;
        private int LocationIndex;
        private int KeywordResponseAudioIndex;
        private int PromptAudioIndex;
        private string NewPromptAudio = "";
        private string NewKeywordAudio = "";

        public editQuestion(Content c, string p)
        {
            InitializeComponent();
            qJetContent = c;
            rootPath = p;
            qPath = rootPath + "Question\\" + qJetContent.id + "\\";
            chkbxExplicit.Checked = qJetContent.x;
            txtId.Text = qJetContent.id+"";
            txtQuestionJetPrompt.Text = qJetContent.prompt;

            string dataJetFileContents = "";

            using (StreamReader sr = new StreamReader(qPath+"data.jet"))
            {
                dataJetFileContents = dataJetFileContents + sr.ReadToEnd() + " ";
            }

            questionData = JsonConvert.DeserializeObject<dataJet>(dataJetFileContents);

            getFieldIndexes();

            txtDataJetPrompt.Text = questionData.fields[PromptTextIndex].v;

            chkbxJoke.Checked = (questionData.fields[HasJokeAudioIndex].v == "true");
            toggleFormAvail();

            txtKeywords.Text = questionData.fields[KeywordsIndex].v;
            txtKeywordResponse.Text = questionData.fields[KeywordResponseTextIndex].v;

            chkbxMirrorPrompts.Checked = (txtDataJetPrompt.Text == txtQuestionJetPrompt.Text);
        }

        private void getFieldIndexes()
        {
            for (int i = 0; i < questionData.fields.Count; i++)
            {
                string name = questionData.fields[i].n;
                if (name == "HasJokeAudio")
                    HasJokeAudioIndex = i;
                else if (name == "Keywords")
                    KeywordsIndex = i;
                else if (name == "Author")
                    AuthorIndex = i;
                else if (name == "KeywordResponseText")
                    KeywordResponseTextIndex = i;
                else if (name == "PromptText")
                    PromptTextIndex = i;
                else if (name == "Location")
                    LocationIndex = i;
                else if (name == "KeywordResponseAudio")
                    KeywordResponseAudioIndex = i;
                else if (name == "PromptAudio")
                    PromptAudioIndex = i;
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            qJetContent.x = chkbxExplicit.Checked;
            qJetContent.prompt = txtQuestionJetPrompt.Text;
            questionData.fields[PromptTextIndex].v = txtDataJetPrompt.Text;
            questionData.fields[KeywordsIndex].v = txtKeywords.Text;
            questionData.fields[KeywordResponseTextIndex].v = txtKeywordResponse.Text;
            questionData.fields[HasJokeAudioIndex].v = boolText(chkbxJoke.Checked);

            if (NewPromptAudio != "")
                File.Copy(NewPromptAudio, qPath + questionData.fields[PromptAudioIndex].v + ".mp3",true);

            if(NewKeywordAudio != "")
            {
                if (questionData.fields[KeywordResponseAudioIndex].v == "" || questionData.fields[KeywordResponseAudioIndex].v == null)
                    questionData.fields[KeywordResponseAudioIndex].v = "kwresponse";
                File.Copy(NewKeywordAudio, qPath + questionData.fields[KeywordResponseAudioIndex].v + ".mp3", true);
            }

            string dataJet = JsonConvert.SerializeObject(questionData, Formatting.None);
            dataJet = unicodeInterface.replacePunctuation(dataJet);

            using (StreamWriter newTask = new StreamWriter(qPath + "data.jet", false))
            {
                newTask.WriteLine(dataJet);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private string boolText(bool b)
        {
            if (b)
                return "true";
            else
                return "false";
        }

        private void btnReplacePromptMP3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                NewPromptAudio = openFileDialog1.FileName;
                lblPromptAudioFName.Text = openFileDialog1.SafeFileName;
            }
        }

        private void btnReplaceKeywordMP3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                NewKeywordAudio = openFileDialog1.FileName;
                lblJokeAudioFName.Text = openFileDialog1.SafeFileName;
            }
        }

        private void chkbxJoke_CheckedChanged(object sender, EventArgs e)
        {
            toggleFormAvail();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void editQuestion_Load(object sender, EventArgs e)
        {

        }

        private void txtQuestionJetPrompt_TextChanged(object sender, EventArgs e)
        {
            if (chkbxMirrorPrompts.Checked)
                txtDataJetPrompt.Text = txtQuestionJetPrompt.Text;
        }

        private void txtDataJetPrompt_TextChanged(object sender, EventArgs e)
        {
            if (chkbxMirrorPrompts.Checked)
                txtQuestionJetPrompt.Text = txtDataJetPrompt.Text;
        }
    }
}
