using System.Windows.Forms;

namespace SpotDifferenceGame.UI
{
    partial class GameModeForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnTimeLimit;
        private Button btnLimitedAttempts;

        /// <summary>
        /// Clean up resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// UI Initialization
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTimeLimit = new System.Windows.Forms.Button();
            this.btnLimitedAttempts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTimeLimit
            // 
            this.btnTimeLimit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTimeLimit.Location = new System.Drawing.Point(50, 24);
            this.btnTimeLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimeLimit.Name = "btnTimeLimit";
            this.btnTimeLimit.Size = new System.Drawing.Size(200, 40);
            this.btnTimeLimit.TabIndex = 0;
            this.btnTimeLimit.Text = "⏱️ نمط المؤقت الزمني";
            this.btnTimeLimit.UseVisualStyleBackColor = true;
            // 
            // btnLimitedAttempts
            // 
            this.btnLimitedAttempts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimitedAttempts.Location = new System.Drawing.Point(50, 80);
            this.btnLimitedAttempts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimitedAttempts.Name = "btnLimitedAttempts";
            this.btnLimitedAttempts.Size = new System.Drawing.Size(200, 40);
            this.btnLimitedAttempts.TabIndex = 1;
            this.btnLimitedAttempts.Text = "🎯 نمط عدد المحاولات";
            this.btnLimitedAttempts.UseVisualStyleBackColor = true;
            // 
            // GameModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 144);
            this.Controls.Add(this.btnTimeLimit);
            this.Controls.Add(this.btnLimitedAttempts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameModeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اختر نمط اللعب";
            this.Load += new System.EventHandler(this.GameModeForm_Load);
            this.ResumeLayout(false);

        }
    }
}
