namespace SpotDifferenceGame.UI
{
    partial class DifficultyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.labelChoose = new System.Windows.Forms.Label();
            this.labelTimeLimit = new System.Windows.Forms.Label();
            this.labelMaxAttempts = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(140, 20);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(121, 24);
            this.comboBoxLevel.TabIndex = 0;
            // 
            // labelChoose
            // 
            this.labelChoose.AutoSize = true;
            this.labelChoose.Location = new System.Drawing.Point(20, 23);
            this.labelChoose.Name = "labelChoose";
            this.labelChoose.Size = new System.Drawing.Size(109, 16);
            this.labelChoose.TabIndex = 1;
            this.labelChoose.Text = "اختر مستوى الصعوبة:";
            // 
            // labelTimeLimit
            // 
            this.labelTimeLimit.AutoSize = true;
            this.labelTimeLimit.Location = new System.Drawing.Point(20, 60);
            this.labelTimeLimit.Name = "labelTimeLimit";
            this.labelTimeLimit.Size = new System.Drawing.Size(92, 16);
            this.labelTimeLimit.TabIndex = 2;
            this.labelTimeLimit.Text = "الوقت (ثواني): 60";
            // 
            // labelMaxAttempts
            // 
            this.labelMaxAttempts.AutoSize = true;
            this.labelMaxAttempts.Location = new System.Drawing.Point(20, 90);
            this.labelMaxAttempts.Name = "labelMaxAttempts";
            this.labelMaxAttempts.Size = new System.Drawing.Size(94, 16);
            this.labelMaxAttempts.TabIndex = 3;
            this.labelMaxAttempts.Text = "عدد المحاولات: 10";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(90, 130);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "ابدأ اللعبة";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // DifficultyForm
            // 
            this.AcceptButton = this.btnStart;
            this.ClientSize = new System.Drawing.Size(280, 180);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labelMaxAttempts);
            this.Controls.Add(this.labelTimeLimit);
            this.Controls.Add(this.labelChoose);
            this.Controls.Add(this.comboBoxLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DifficultyForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اختيار مستوى الصعوبة";
            this.Load += new System.EventHandler(this.DifficultyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Label labelChoose;
        private System.Windows.Forms.Label labelTimeLimit;
        private System.Windows.Forms.Label labelMaxAttempts;
        private System.Windows.Forms.Button btnStart;
    }
}
