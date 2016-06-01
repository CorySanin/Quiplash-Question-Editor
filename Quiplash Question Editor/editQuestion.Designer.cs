namespace Quiplash_Question_Editor
{
    partial class editQuestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkbxExplicit = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuestionJetPrompt = new System.Windows.Forms.TextBox();
            this.txtDataJetPrompt = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnReplacePromptMP3 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkbxJoke = new System.Windows.Forms.CheckBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKeywordResponse = new System.Windows.Forms.TextBox();
            this.btnReplaceKeywordMP3 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkbxMirrorPrompts = new System.Windows.Forms.CheckBox();
            this.lblPromptAudioFName = new System.Windows.Forms.Label();
            this.lblJokeAudioFName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkbxExplicit
            // 
            this.chkbxExplicit.AutoSize = true;
            this.chkbxExplicit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkbxExplicit.Location = new System.Drawing.Point(72, 12);
            this.chkbxExplicit.Name = "chkbxExplicit";
            this.chkbxExplicit.Size = new System.Drawing.Size(59, 17);
            this.chkbxExplicit.TabIndex = 0;
            this.chkbxExplicit.Text = "Explicit";
            this.chkbxExplicit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(117, 35);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Question.jet Prompt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "data.jet Prompt";
            // 
            // txtQuestionJetPrompt
            // 
            this.txtQuestionJetPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuestionJetPrompt.Location = new System.Drawing.Point(117, 61);
            this.txtQuestionJetPrompt.Name = "txtQuestionJetPrompt";
            this.txtQuestionJetPrompt.Size = new System.Drawing.Size(307, 20);
            this.txtQuestionJetPrompt.TabIndex = 4;
            this.txtQuestionJetPrompt.TextChanged += new System.EventHandler(this.txtQuestionJetPrompt_TextChanged);
            // 
            // txtDataJetPrompt
            // 
            this.txtDataJetPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataJetPrompt.Location = new System.Drawing.Point(117, 87);
            this.txtDataJetPrompt.Name = "txtDataJetPrompt";
            this.txtDataJetPrompt.Size = new System.Drawing.Size(307, 20);
            this.txtDataJetPrompt.TabIndex = 6;
            this.txtDataJetPrompt.TextChanged += new System.EventHandler(this.txtDataJetPrompt_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mp3";
            this.openFileDialog1.FileName = ".mp3";
            this.openFileDialog1.Filter = "MP3 audio file|*.mp3";
            this.openFileDialog1.Title = "Replacement MP3";
            // 
            // btnReplacePromptMP3
            // 
            this.btnReplacePromptMP3.Location = new System.Drawing.Point(117, 136);
            this.btnReplacePromptMP3.Name = "btnReplacePromptMP3";
            this.btnReplacePromptMP3.Size = new System.Drawing.Size(100, 23);
            this.btnReplacePromptMP3.TabIndex = 7;
            this.btnReplacePromptMP3.Text = "Replace Audio...";
            this.btnReplacePromptMP3.UseVisualStyleBackColor = true;
            this.btnReplacePromptMP3.Click += new System.EventHandler(this.btnReplacePromptMP3_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(349, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkbxJoke
            // 
            this.chkbxJoke.AutoSize = true;
            this.chkbxJoke.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkbxJoke.Location = new System.Drawing.Point(52, 165);
            this.chkbxJoke.Name = "chkbxJoke";
            this.chkbxJoke.Size = new System.Drawing.Size(79, 17);
            this.chkbxJoke.TabIndex = 8;
            this.chkbxJoke.Text = "Joke Audio";
            this.chkbxJoke.UseVisualStyleBackColor = true;
            this.chkbxJoke.CheckedChanged += new System.EventHandler(this.chkbxJoke_CheckedChanged);
            // 
            // txtKeywords
            // 
            this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywords.Enabled = false;
            this.txtKeywords.Location = new System.Drawing.Point(117, 188);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(307, 20);
            this.txtKeywords.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Keywords";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Keyword Response";
            // 
            // txtKeywordResponse
            // 
            this.txtKeywordResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywordResponse.Enabled = false;
            this.txtKeywordResponse.Location = new System.Drawing.Point(117, 214);
            this.txtKeywordResponse.Name = "txtKeywordResponse";
            this.txtKeywordResponse.Size = new System.Drawing.Size(307, 20);
            this.txtKeywordResponse.TabIndex = 12;
            // 
            // btnReplaceKeywordMP3
            // 
            this.btnReplaceKeywordMP3.Enabled = false;
            this.btnReplaceKeywordMP3.Location = new System.Drawing.Point(117, 240);
            this.btnReplaceKeywordMP3.Name = "btnReplaceKeywordMP3";
            this.btnReplaceKeywordMP3.Size = new System.Drawing.Size(100, 23);
            this.btnReplaceKeywordMP3.TabIndex = 13;
            this.btnReplaceKeywordMP3.Text = "Replace Audio...";
            this.btnReplaceKeywordMP3.UseVisualStyleBackColor = true;
            this.btnReplaceKeywordMP3.Click += new System.EventHandler(this.btnReplaceKeywordMP3_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(268, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkbxMirrorPrompts
            // 
            this.chkbxMirrorPrompts.AutoSize = true;
            this.chkbxMirrorPrompts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkbxMirrorPrompts.Location = new System.Drawing.Point(10, 113);
            this.chkbxMirrorPrompts.Name = "chkbxMirrorPrompts";
            this.chkbxMirrorPrompts.Size = new System.Drawing.Size(121, 17);
            this.chkbxMirrorPrompts.TabIndex = 16;
            this.chkbxMirrorPrompts.Text = "Make prompts same";
            this.chkbxMirrorPrompts.UseVisualStyleBackColor = true;
            // 
            // lblPromptAudioFName
            // 
            this.lblPromptAudioFName.AutoSize = true;
            this.lblPromptAudioFName.Location = new System.Drawing.Point(223, 141);
            this.lblPromptAudioFName.Name = "lblPromptAudioFName";
            this.lblPromptAudioFName.Size = new System.Drawing.Size(85, 13);
            this.lblPromptAudioFName.TabIndex = 17;
            this.lblPromptAudioFName.Text = "No File Selected";
            // 
            // lblJokeAudioFName
            // 
            this.lblJokeAudioFName.AutoSize = true;
            this.lblJokeAudioFName.Location = new System.Drawing.Point(223, 245);
            this.lblJokeAudioFName.Name = "lblJokeAudioFName";
            this.lblJokeAudioFName.Size = new System.Drawing.Size(85, 13);
            this.lblJokeAudioFName.TabIndex = 18;
            this.lblJokeAudioFName.Text = "No File Selected";
            // 
            // editQuestion
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(436, 312);
            this.Controls.Add(this.lblJokeAudioFName);
            this.Controls.Add(this.lblPromptAudioFName);
            this.Controls.Add(this.chkbxMirrorPrompts);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReplaceKeywordMP3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKeywordResponse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.chkbxJoke);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReplacePromptMP3);
            this.Controls.Add(this.txtDataJetPrompt);
            this.Controls.Add(this.txtQuestionJetPrompt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkbxExplicit);
            this.Name = "editQuestion";
            this.ShowIcon = false;
            this.Text = "Edit Question";
            this.Load += new System.EventHandler(this.editQuestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbxExplicit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuestionJetPrompt;
        private System.Windows.Forms.TextBox txtDataJetPrompt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnReplacePromptMP3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkbxJoke;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKeywordResponse;
        private System.Windows.Forms.Button btnReplaceKeywordMP3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkbxMirrorPrompts;
        private System.Windows.Forms.Label lblPromptAudioFName;
        private System.Windows.Forms.Label lblJokeAudioFName;
    }
}