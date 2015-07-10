namespace EQIconExtractor
{
    partial class Form1
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
            this.labelInputPath = new System.Windows.Forms.Label();
            this.textInputPath = new System.Windows.Forms.TextBox();
            this.buttonInputPath = new System.Windows.Forms.Button();
            this.labelOutputPath = new System.Windows.Forms.Label();
            this.textOutputPath = new System.Windows.Forms.TextBox();
            this.buttonOutputPath = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressSpellIcons = new System.Windows.Forms.ProgressBar();
            this.progressItemIcons = new System.Windows.Forms.ProgressBar();
            this.threadSpellIcons = new System.ComponentModel.BackgroundWorker();
            this.threadItemIcons = new System.ComponentModel.BackgroundWorker();
            this.folderFinder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // labelInputPath
            // 
            this.labelInputPath.AutoSize = true;
            this.labelInputPath.Location = new System.Drawing.Point(12, 9);
            this.labelInputPath.Name = "labelInputPath";
            this.labelInputPath.Size = new System.Drawing.Size(186, 13);
            this.labelInputPath.TabIndex = 0;
            this.labelInputPath.Text = "&Input Path (EverQuest\\uifiles\\default):";
            // 
            // textInputPath
            // 
            this.textInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInputPath.Location = new System.Drawing.Point(15, 25);
            this.textInputPath.Name = "textInputPath";
            this.textInputPath.Size = new System.Drawing.Size(340, 20);
            this.textInputPath.TabIndex = 1;
            // 
            // buttonInputPath
            // 
            this.buttonInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInputPath.Location = new System.Drawing.Point(355, 24);
            this.buttonInputPath.Name = "buttonInputPath";
            this.buttonInputPath.Size = new System.Drawing.Size(47, 22);
            this.buttonInputPath.TabIndex = 2;
            this.buttonInputPath.Text = "...";
            this.buttonInputPath.UseVisualStyleBackColor = true;
            this.buttonInputPath.Click += new System.EventHandler(this.buttonInputPath_Click);
            // 
            // labelOutputPath
            // 
            this.labelOutputPath.AutoSize = true;
            this.labelOutputPath.Location = new System.Drawing.Point(12, 61);
            this.labelOutputPath.Name = "labelOutputPath";
            this.labelOutputPath.Size = new System.Drawing.Size(136, 13);
            this.labelOutputPath.TabIndex = 3;
            this.labelOutputPath.Text = "&Output Path for PNG icons:";
            // 
            // textOutputPath
            // 
            this.textOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOutputPath.Location = new System.Drawing.Point(15, 77);
            this.textOutputPath.Name = "textOutputPath";
            this.textOutputPath.Size = new System.Drawing.Size(340, 20);
            this.textOutputPath.TabIndex = 4;
            // 
            // buttonOutputPath
            // 
            this.buttonOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOutputPath.Location = new System.Drawing.Point(355, 76);
            this.buttonOutputPath.Name = "buttonOutputPath";
            this.buttonOutputPath.Size = new System.Drawing.Size(47, 22);
            this.buttonOutputPath.TabIndex = 5;
            this.buttonOutputPath.Text = "...";
            this.buttonOutputPath.UseVisualStyleBackColor = true;
            this.buttonOutputPath.Click += new System.EventHandler(this.buttonOutputPath_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(16, 110);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(185, 33);
            this.buttonConvert.TabIndex = 6;
            this.buttonConvert.Text = "&Begin Conversion";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Location = new System.Drawing.Point(231, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(171, 33);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Spell Icons:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Item Icons:";
            // 
            // progressSpellIcons
            // 
            this.progressSpellIcons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressSpellIcons.Location = new System.Drawing.Point(87, 165);
            this.progressSpellIcons.Name = "progressSpellIcons";
            this.progressSpellIcons.Size = new System.Drawing.Size(315, 23);
            this.progressSpellIcons.TabIndex = 10;
            // 
            // progressItemIcons
            // 
            this.progressItemIcons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressItemIcons.Location = new System.Drawing.Point(87, 195);
            this.progressItemIcons.Name = "progressItemIcons";
            this.progressItemIcons.Size = new System.Drawing.Size(315, 23);
            this.progressItemIcons.TabIndex = 11;
            // 
            // threadSpellIcons
            // 
            this.threadSpellIcons.WorkerReportsProgress = true;
            this.threadSpellIcons.WorkerSupportsCancellation = true;
            this.threadSpellIcons.DoWork += new System.ComponentModel.DoWorkEventHandler(this.threadSpellIcons_DoWork);
            this.threadSpellIcons.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.threadSpellIcons_ProgressChanged);
            this.threadSpellIcons.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.threadSpellIcons_RunWorkerCompleted);
            // 
            // threadItemIcons
            // 
            this.threadItemIcons.WorkerReportsProgress = true;
            this.threadItemIcons.WorkerSupportsCancellation = true;
            this.threadItemIcons.DoWork += new System.ComponentModel.DoWorkEventHandler(this.threadItemIcons_DoWork);
            this.threadItemIcons.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.threadItemIcons_ProgressChanged);
            this.threadItemIcons.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.threadItemIcons_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 234);
            this.Controls.Add(this.progressItemIcons);
            this.Controls.Add(this.progressSpellIcons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonOutputPath);
            this.Controls.Add(this.textOutputPath);
            this.Controls.Add(this.labelOutputPath);
            this.Controls.Add(this.buttonInputPath);
            this.Controls.Add(this.textInputPath);
            this.Controls.Add(this.labelInputPath);
            this.MinimumSize = new System.Drawing.Size(430, 200);
            this.Name = "Form1";
            this.Text = "EverQuest Icon Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInputPath;
        private System.Windows.Forms.TextBox textInputPath;
        private System.Windows.Forms.Button buttonInputPath;
        private System.Windows.Forms.Label labelOutputPath;
        private System.Windows.Forms.TextBox textOutputPath;
        private System.Windows.Forms.Button buttonOutputPath;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressSpellIcons;
        private System.Windows.Forms.ProgressBar progressItemIcons;
        private System.ComponentModel.BackgroundWorker threadSpellIcons;
        private System.ComponentModel.BackgroundWorker threadItemIcons;
        private System.Windows.Forms.FolderBrowserDialog folderFinder;
    }
}

