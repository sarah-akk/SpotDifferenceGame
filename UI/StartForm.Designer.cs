using System.Drawing;
using System.Windows.Forms;

namespace SpotDifferenceGame.UI
{
    partial class StartForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnPlay;

        //=============================================================>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //=============================================================>


        private void InitializeComponent()
        {
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnPlay.Location = new System.Drawing.Point(350, 360);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(200, 50); 
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Start Game";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(0, 169, 110);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.FlatStyle = FlatStyle.Flat;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);

            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 460);
            this.Controls.Add(this.btnPlay);
            this.Name = "StartForm";
            this.Text = "لعبة الاختلافات";

            this.BackgroundImage = Image.FromFile("C:\\Users\\Sarah\\Documents\\programing projects\\C#\\SpotDifferenceGame\\SpotDifferenceGame\\Assets\\Images\\bg.png");
            this.BackgroundImageLayout = ImageLayout.Stretch; 

            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
        }


    }
}
