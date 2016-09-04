using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private string[] param;

        public Form1(string[] args)
        {
            InitializeComponent();
            param = args;
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
            string importFName = "";
            for (int i = 0; i < param.Length; i++)
            {
                try
                {
                    string ext = Path.GetExtension(param[i]);
                    if (ext == ".jet")
                        questionJetFilename = param[i];
                    else if (ext == ".qqp")
                        importFName = param[i];
                }
                catch
                {

                }
            }
            if (questionJetFilename == "" || questionJetFilename == null)
                open();
            else
            {
                questionPath = Path.GetDirectoryName(questionJetFilename);
                openFile();
            }

            if(questionJetFilename != "" && questionJetFilename != null && importFName != "")
            {
                importFile(importFName, Path.GetDirectoryName(importFName));
            }
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
            ListBox.SelectedIndexCollection indices = ListQuestionJet.SelectedIndices;
            if (indices.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to remove this question from Question.jet?", "Confirm", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    int count = indices.Count; //indices.Count goes down as items are removed.
                    for (int c = 0; c < count; c++)
                    {
                            questionIndex.content.RemoveAt(indices[0]);
                            ListQuestionJet.Items.RemoveAt(indices[0]);
                    }
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
                int num = ListQuestionJet.Items.Count - 1;
                int index = 3000;
                if (num >= 0)
                    index = questionIndex.content[num].id + 1;
                newQuestion createWindow = new newQuestion(questionPath, index);
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
            openFileDialog1.ShowDialog();
            questionJetFilename = openFileDialog1.FileName;
            questionPath = questionJetFilename.Replace(openFileDialog1.SafeFileName, "");
            openFile();
        }

        private void openFile()
        {
            string questionJetFileContents = "";
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

                if (!File.Exists(questionJetFilename + ".bak"))
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

        /// <summary>
        /// Makes the edit button available if and only if a single item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListQuestionJet_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = ListQuestionJet.SelectedIndices.Count == 1;
        }

        private void btnSelNone_Click(object sender, EventArgs e)
        {
            ListQuestionJet.SelectedIndex = -1;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (questionJetFilename != "")
            {
                importQQPDialog.ShowDialog();
                string QQPFilename = importQQPDialog.FileName;
                string QQPPath = QQPFilename.Replace(importQQPDialog.SafeFileName, "");
                importFile(QQPFilename, QQPPath);
            }
            else
                open();
        }

        private void importFile(string QQPFilename, string QQPPath)
        {
            string QQPFileContents = "";
            string QQDir = QQPPath + @"\" + "QQETEMP";
            try
            {
                //extracts the QQP
                using (ZipFile zip = ZipFile.Read(QQPFilename))
                {
                    zip.ExtractAll(QQDir);
                }
                //reads the main file
                using (StreamReader sr = new StreamReader(QQDir + @"\" + "QQP.jet"))
                {
                    QQPFileContents = QQPFileContents + sr.ReadToEnd() + " ";
                }

                QuiplashQuestionPack importQIndex = JsonConvert.DeserializeObject<QuiplashQuestionPack>(QQPFileContents);

                for (int i = 0; i < importQIndex.items.Count; i++)
                {
                    //finds the next available filder
                    int num = ListQuestionJet.Items.Count - 1;
                    int index = 3000;
                    if (num >= 0)
                        index = questionIndex.content[num].id + 1;
                    while (Directory.Exists(questionPath + "Question\\" + index))
                    {
                        index++;
                    }

                    //move audio files to the new folder
                    Directory.CreateDirectory(questionPath + "Question\\" + index);
                    File.Move(QQDir + @"\Question\" + i + @"\" + importQIndex.items[i].audio + ".mp3", questionPath + "Question\\" + index + @"\" + importQIndex.items[i].audio + ".mp3");
                    if (importQIndex.items[i].jokeaudio != "" && importQIndex.items[i].jokeaudio != null)
                        File.Move(QQDir + @"\Question\" + i + @"\" + importQIndex.items[i].jokeaudio + ".mp3", questionPath + "Question\\" + index + @"\" + importQIndex.items[i].jokeaudio + ".mp3");

                    //create the files necessary for a new data.jet and an updated question.jet
                    Content newContent = new Content();
                    newContent.id = index;
                    newContent.prompt = importQIndex.items[i].prompt;
                    newContent.x = importQIndex.items[i].explicitq;

                    bool hasjokeaudio = (importQIndex.items[i].jokekeys != "" && importQIndex.items[i].jokeaudio != "");

                    dataJet questionData = new dataJet();
                    questionData.fields = new List<Field>();
                    questionData.fields.Add(new Field() { t = "B", v = newQuestion.boolText(hasjokeaudio), n = "HasJokeAudio" });
                    questionData.fields.Add(new Field() { t = "S", v = importQIndex.items[i].jokekeys, n = "Keywords" });
                    questionData.fields.Add(new Field() { t = "S", v = "", n = "Author" });
                    questionData.fields.Add(new Field() { t = "S", v = importQIndex.items[i].jokeresponse, n = "KeywordResponseText" });
                    questionData.fields.Add(new Field() { t = "S", v = importQIndex.items[i].prompt, n = "PromptText" });
                    questionData.fields.Add(new Field() { t = "S", v = "", n = "Location" });
                    questionData.fields.Add(new Field() { t = "A", v = importQIndex.items[i].jokeaudio, n = "KeywordResponseAudio" });
                    questionData.fields.Add(new Field() { t = "A", v = importQIndex.items[i].audio, n = "PromptAudio" });
                    questionData.fields.Add(new Field() { t = "B", v = newQuestion.boolText(true), n = "Custom" });

                    string dataJet = JsonConvert.SerializeObject(questionData, Formatting.None);
                    dataJet = unicodeInterface.replacePunctuation(dataJet);

                    using (StreamWriter newTask = new StreamWriter(questionPath + "Question\\" + index + "\\data.jet", false))
                    {
                        newTask.WriteLine(dataJet);
                    }

                    questionIndex.content.Add(newContent);
                    ListQuestionJet.Items.Add(newContent.prompt);
                    saveQuestionJet();
                }
            }
            finally
            {
                Directory.Delete(QQDir, true);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = ListQuestionJet.SelectedIndex;
            ListBox.SelectedIndexCollection indices = ListQuestionJet.SelectedIndices;
            if (indices.Count > 0)
            {
                exportQQPDialog.ShowDialog();
                string qqpFilename = "";
                qqpFilename = exportQQPDialog.FileName;
                if (qqpFilename != "")
                {
                    string qqpPath = Path.GetDirectoryName(qqpFilename);
                    Directory.CreateDirectory(qqpPath + @"\QQETEMP");
                    Directory.CreateDirectory(qqpPath + @"\QQETEMP\Question");

                    QuiplashQuestionPack QQP = new QuiplashQuestionPack();
                    QQP.items = new List<items>();

                    ZipFile zip = new ZipFile();

                    for (int c = 0; c < indices.Count; c++)
                    {
                        Directory.CreateDirectory(qqpPath + @"\QQETEMP\Question\" + c);
                        items newitem = new items();
                        string dataJetFileContents = "";
                        string qPath = questionPath + "Question\\" + questionIndex.content[indices[c]].id + "\\";
                        using (StreamReader sr = new StreamReader(qPath + "data.jet"))
                        {
                            dataJetFileContents = dataJetFileContents + sr.ReadToEnd() + " ";
                        }

                        dataJet questionData = JsonConvert.DeserializeObject<dataJet>(dataJetFileContents);

                        int HasJokeAudioIndex = 0;
                        int KeywordsIndex = 0;
                        int AuthorIndex = 0;
                        int KeywordResponseTextIndex = 0;
                        int PromptTextIndex = 0;
                        int LocationIndex = 0;
                        int KeywordResponseAudioIndex = 0;
                        int PromptAudioIndex = 0;
                        int CustomFlagIndex = -1;
                        for (int n = 0; n < questionData.fields.Count; n++)
                        {
                            string name = questionData.fields[n].n;
                            if (name == "HasJokeAudio")
                                HasJokeAudioIndex = n;
                            else if (name == "Keywords")
                                KeywordsIndex = n;
                            else if (name == "Author")
                                AuthorIndex = n;
                            else if (name == "KeywordResponseText")
                                KeywordResponseTextIndex = n;
                            else if (name == "PromptText")
                                PromptTextIndex = n;
                            else if (name == "Location")
                                LocationIndex = n;
                            else if (name == "KeywordResponseAudio")
                                KeywordResponseAudioIndex = n;
                            else if (name == "PromptAudio")
                                PromptAudioIndex = n;
                            else if (name == "Custom")
                                CustomFlagIndex = n;
                        }

                        if (CustomFlagIndex >= 0)
                        {
                            newitem.explicitq = questionIndex.content[indices[c]].x;
                            newitem.prompt = questionData.fields[PromptTextIndex].v;
                            newitem.audio = questionData.fields[PromptAudioIndex].v;
                            newitem.jokekeys = questionData.fields[KeywordsIndex].v;
                            newitem.jokeresponse = questionData.fields[KeywordResponseTextIndex].v;
                            newitem.jokeaudio = questionData.fields[KeywordResponseAudioIndex].v;
                            if (!File.Exists(qPath + newitem.jokeaudio + ".mp3"))
                                newitem.jokeaudio = null;

                            File.Copy(qPath + newitem.audio + ".mp3", qqpPath + @"\QQETEMP\Question\" + c + @"\" + newitem.audio + ".mp3");
                            zip.AddFile(qqpPath + @"\QQETEMP\Question\" + c + @"\" + newitem.audio + ".mp3", @"Question\" + c);
                            if (newitem.jokeaudio != "" && newitem.jokeaudio != null)
                            {
                                File.Copy(qPath + newitem.jokeaudio + ".mp3", qqpPath + @"\QQETEMP\Question\" + c + @"\" + newitem.jokeaudio + ".mp3");
                                zip.AddFile(qqpPath + @"\QQETEMP\Question\" + c + @"\" + newitem.jokeaudio + ".mp3", @"Question\" + c);
                            }
                            QQP.items.Add(newitem);
                        }
                    }

                    string qqpJet = JsonConvert.SerializeObject(QQP, Formatting.None);
                    qqpJet = unicodeInterface.replacePunctuation(qqpJet);

                    using (StreamWriter newTask = new StreamWriter(qqpPath + @"\QQETEMP\" + "QQP.jet", false))
                    {
                        newTask.WriteLine(qqpJet);
                    }

                    zip.AddFile(qqpPath + @"\QQETEMP\" + "QQP.jet", "");
                    //zip.AddDirectory(qqpPath + @"\QQETEMP\");
                    zip.Save(qqpFilename);

                    Directory.Delete(qqpPath + @"\QQETEMP\", true);
                }
            }
        }
    }
}
