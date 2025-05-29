using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpotDifferenceGame.UI
{
    partial class MainForm : Form
    {
        private System.Windows.Forms.Button btnLoadImage1;
        private System.Windows.Forms.Button btnLoadImage2;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Label labelFoundCount;
        private System.Windows.Forms.Label labelRemainingCount;
        private System.Windows.Forms.Label labelGameStatus;
        private System.Windows.Forms.Label labelAttempts;
        private System.Windows.Forms.Timer gameTimer;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLoadImage1 = new System.Windows.Forms.Button();
            this.btnLoadImage2 = new System.Windows.Forms.Button();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.labelFoundCount = new System.Windows.Forms.Label();
            this.labelRemainingCount = new System.Windows.Forms.Label();
            this.labelGameStatus = new System.Windows.Forms.Label();
            this.labelAttempts = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImage1
            // 
            this.btnLoadImage1.Location = new System.Drawing.Point(20, 400);
            this.btnLoadImage1.Name = "btnLoadImage1";
            this.btnLoadImage1.Size = new System.Drawing.Size(200, 40);
            this.btnLoadImage1.TabIndex = 0;
            this.btnLoadImage1.Text = "Load first image";
            // 
            // btnLoadImage2
            // 
            this.btnLoadImage2.Location = new System.Drawing.Point(440, 400);
            this.btnLoadImage2.Name = "btnLoadImage2";
            this.btnLoadImage2.Size = new System.Drawing.Size(200, 40);
            this.btnLoadImage2.TabIndex = 1;
            this.btnLoadImage2.Text = "Load second image";
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(20, 80);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 2;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Location = new System.Drawing.Point(440, 80);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 3;
            this.pictureBoxRight.TabStop = false;
            // 
            // labelFoundCount
            // 
            this.labelFoundCount.AutoSize = true;
            this.labelFoundCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelFoundCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelFoundCount.Location = new System.Drawing.Point(20, 20);
            this.labelFoundCount.Name = "labelFoundCount";
            this.labelFoundCount.Size = new System.Drawing.Size(197, 21);
            this.labelFoundCount.TabIndex = 4;
            this.labelFoundCount.Text = "???????? ????????: 0";
            // 
            // labelRemainingCount
            // 
            this.labelRemainingCount.AutoSize = true;
            this.labelRemainingCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelRemainingCount.ForeColor = System.Drawing.Color.DarkRed;
            this.labelRemainingCount.Location = new System.Drawing.Point(200, 20);
            this.labelRemainingCount.Name = "labelRemainingCount";
            this.labelRemainingCount.Size = new System.Drawing.Size(197, 21);
            this.labelRemainingCount.TabIndex = 5;
            this.labelRemainingCount.Text = "???????? ????????: 0";
            // 
            // labelGameStatus
            // 
            this.labelGameStatus.AutoSize = true;
            this.labelGameStatus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelGameStatus.ForeColor = System.Drawing.Color.Navy;
            this.labelGameStatus.Location = new System.Drawing.Point(400, 20);
            this.labelGameStatus.Name = "labelGameStatus";
            this.labelGameStatus.Size = new System.Drawing.Size(168, 21);
            this.labelGameStatus.TabIndex = 6;
            this.labelGameStatus.Text = "????? ???????: 00";
            // 
            // labelAttempts
            // 
            this.labelAttempts.AutoSize = true;
            this.labelAttempts.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelAttempts.ForeColor = System.Drawing.Color.Black;
            this.labelAttempts.Location = new System.Drawing.Point(600, 20);
            this.labelAttempts.Name = "labelAttempts";
            this.labelAttempts.Size = new System.Drawing.Size(157, 21);
            this.labelAttempts.TabIndex = 7;
            this.labelAttempts.Text = "??? ?????????: 0";
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRestart.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(770, 15);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(100, 35);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(880, 460);
            this.Controls.Add(this.btnLoadImage1);
            this.Controls.Add(this.btnLoadImage2);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.labelFoundCount);
            this.Controls.Add(this.labelRemainingCount);
            this.Controls.Add(this.labelGameStatus);
            this.Controls.Add(this.labelAttempts);
            this.Controls.Add(this.btnRestart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spot the Difference";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.ComponentModel.IContainer components;
    }
}
