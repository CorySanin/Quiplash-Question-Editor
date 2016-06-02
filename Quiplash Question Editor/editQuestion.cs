using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace Quiplash_Question_Editor
{
    /// <summary>
    /// Form for editing an existing question
    /// </summary>
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

        /// <summary>
        /// Constructor gets information about the selected question
        /// </summary>
        /// <param name="c">The Content info from Question.jet about this question</param>
        /// <param name="p">Question.jet containing directory</param>
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

        /// <summary>
        /// Goes through the question's Data.jet to find the indexes for the difference types of variables
        /// There might be a better way of doing this, but I believe my way isn't bad
        /// </summary>
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
        /// Makes the necessary changes to Data.jet, moves audio files into place,
        /// and updates qJetContent so that the main form can update Question.jet
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
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
        /// Make sure the keyword-joke fields are correctly enabled or disabled
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void chkbxJoke_CheckedChanged(object sender, EventArgs e)
        {
            toggleFormAvail();
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
        /// Update the other textbox if chkbxMirrorPrompts is checked
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void txtQuestionJetPrompt_TextChanged(object sender, EventArgs e)
        {
            if (chkbxMirrorPrompts.Checked)
                txtDataJetPrompt.Text = txtQuestionJetPrompt.Text;
        }

        /// <summary>
        /// Update the other textbox if chkbxMirrorPrompts is checked
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void txtDataJetPrompt_TextChanged(object sender, EventArgs e)
        {
            if (chkbxMirrorPrompts.Checked)
                txtQuestionJetPrompt.Text = txtDataJetPrompt.Text;
        }
    }
}
