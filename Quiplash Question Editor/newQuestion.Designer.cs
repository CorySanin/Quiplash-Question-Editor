namespace Quiplash_Question_Editor
{
    partial class newQuestion
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReplaceKeywordMP3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKeywordResponse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.chkbxJoke = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReplacePromptMP3 = new System.Windows.Forms.Button();
            this.txtPrompt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkbxExplicit = new System.Windows.Forms.CheckBox();
            this.lblPromptAudioFName = new System.Windows.Forms.Label();
            this.lblJokeAudioFName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(290, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReplaceKeywordMP3
            // 
            this.btnReplaceKeywordMP3.Enabled = false;
            this.btnReplaceKeywordMP3.Location = new System.Drawing.Point(117, 191);
            this.btnReplaceKeywordMP3.Name = "btnReplaceKeywordMP3";
            this.btnReplaceKeywordMP3.Size = new System.Drawing.Size(100, 23);
            this.btnReplaceKeywordMP3.TabIndex = 29;
            this.btnReplaceKeywordMP3.Text = "Replace Audio...";
            this.btnReplaceKeywordMP3.UseVisualStyleBackColor = true;
            this.btnReplaceKeywordMP3.Click += new System.EventHandler(this.btnReplaceKeywordMP3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Keyword Response";
            // 
            // txtKeywordResponse
            // 
            this.txtKeywordResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywordResponse.Enabled = false;
            this.txtKeywordResponse.Location = new System.Drawing.Point(117, 165);
            this.txtKeywordResponse.Name = "txtKeywordResponse";
            this.txtKeywordResponse.Size = new System.Drawing.Size(329, 20);
            this.txtKeywordResponse.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Keywords";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywords.Enabled = false;
            this.txtKeywords.Location = new System.Drawing.Point(117, 139);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(329, 20);
            this.txtKeywords.TabIndex = 26;
            // 
            // chkbxJoke
            // 
            this.chkbxJoke.AutoSize = true;
            this.chkbxJoke.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkbxJoke.Location = new System.Drawing.Point(52, 116);
            this.chkbxJoke.Name = "chkbxJoke";
            this.chkbxJoke.Size = new System.Drawing.Size(79, 17);
            this.chkbxJoke.TabIndex = 24;
            this.chkbxJoke.Text = "Joke Audio";
            this.chkbxJoke.UseVisualStyleBackColor = true;
            this.chkbxJoke.CheckedChanged += new System.EventHandler(this.chkbxJoke_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(371, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Crea&te";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReplacePromptMP3
            // 
            this.btnReplacePromptMP3.Location = new System.Drawing.Point(117, 87);
            this.btnReplacePromptMP3.Name = "btnReplacePromptMP3";
            this.btnReplacePromptMP3.Size = new System.Drawing.Size(100, 23);
            this.btnReplacePromptMP3.TabIndex = 23;
            this.btnReplacePromptMP3.Text = "Replace Audio...";
            this.btnReplacePromptMP3.UseVisualStyleBackColor = true;
            this.btnReplacePromptMP3.Click += new System.EventHandler(this.btnReplacePromptMP3_Click);
            // 
            // txtPrompt
            // 
            this.txtPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrompt.Location = new System.Drawing.Point(117, 61);
            this.txtPrompt.Name = "txtPrompt";
            this.txtPrompt.Size = new System.Drawing.Size(329, 20);
            this.txtPrompt.TabIndex = 20;
            this.txtPrompt.Leave += new System.EventHandler(this.txtPrompt_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Prompt";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(117, 35);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 18;
            this.txtId.Text = "30000";
            this.txtId.Leave += new System.EventHandler(this.txtPrompt_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "ID";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mp3";
            this.openFileDialog1.FileName = ".mp3";
            this.openFileDialog1.Filter = "MP3 audio file|*.mp3";
            this.openFileDialog1.Title = "Replacement MP3";
            // 
            // chkbxExplicit
            // 
            this.chkbxExplicit.AutoSize = true;
            this.chkbxExplicit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkbxExplicit.Location = new System.Drawing.Point(72, 12);
            this.chkbxExplicit.Name = "chkbxExplicit";
            this.chkbxExplicit.Size = new System.Drawing.Size(59, 17);
            this.chkbxExplicit.TabIndex = 16;
            this.chkbxExplicit.Text = "Explicit";
            this.chkbxExplicit.UseVisualStyleBackColor = true;
            // 
            // lblPromptAudioFName
            // 
            this.lblPromptAudioFName.AutoSize = true;
            this.lblPromptAudioFName.Location = new System.Drawing.Point(223, 92);
            this.lblPromptAudioFName.Name = "lblPromptAudioFName";
            this.lblPromptAudioFName.Size = new System.Drawing.Size(85, 13);
            this.lblPromptAudioFName.TabIndex = 32;
            this.lblPromptAudioFName.Text = "No File Selected";
            // 
            // lblJokeAudioFName
            // 
            this.lblJokeAudioFName.AutoSize = true;
            this.lblJokeAudioFName.Location = new System.Drawing.Point(223, 196);
            this.lblJokeAudioFName.Name = "lblJokeAudioFName";
            this.lblJokeAudioFName.Size = new System.Drawing.Size(85, 13);
            this.lblJokeAudioFName.TabIndex = 33;
            this.lblJokeAudioFName.Text = "No File Selected";
            // 
            // newQuestion
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(458, 262);
            this.Controls.Add(this.lblJokeAudioFName);
            this.Controls.Add(this.lblPromptAudioFName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReplaceKeywordMP3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKeywordResponse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.chkbxJoke);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReplacePromptMP3);
            this.Controls.Add(this.txtPrompt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkbxExplicit);
            this.Name = "newQuestion";
            this.ShowIcon = false;
            this.Text = "New Question";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReplaceKeywordMP3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKeywordResponse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.CheckBox chkbxJoke;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReplacePromptMP3;
        private System.Windows.Forms.TextBox txtPrompt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkbxExplicit;
        private System.Windows.Forms.Label lblPromptAudioFName;
        private System.Windows.Forms.Label lblJokeAudioFName;
    }
}