using System;
using System.Windows.Forms;

namespace SpotDifferenceGame.UI
{
    public partial class DifficultyForm : Form
    {
        public int SelectedTimeLimit { get; private set; }
        public int SelectedMaxAttempts { get; private set; }

        public DifficultyForm()
        {
            InitializeComponent();

            comboBoxLevel.Items.AddRange(new string[] { "سهل", "متوسط", "صعب" });
            comboBoxLevel.SelectedIndex = 0;

            comboBoxLevel.SelectedIndexChanged += ComboBoxLevel_SelectedIndexChanged;

            // تعيين القيم الأولية بناءً على "سهل"
            SetDifficultyValues("سهل");
        }

        private void ComboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDifficultyValues(comboBoxLevel.SelectedItem.ToString());
        }

        private void SetDifficultyValues(string level)
        {
            switch (level)
            {
                case "سهل":
                    SelectedTimeLimit = 120;
                    SelectedMaxAttempts = 15;
                    break;
                case "متوسط":
                    SelectedTimeLimit = 60;
                    SelectedMaxAttempts = 10;
                    break;
                case "صعب":
                    SelectedTimeLimit = 30;
                    SelectedMaxAttempts = 5;
                    break;
            }
            labelTimeLimit.Text = $"الوقت (ثواني): {SelectedTimeLimit}";
            labelMaxAttempts.Text = $"عدد المحاولات: {SelectedMaxAttempts}";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // فقط أغلق الفورم مع OK ليتم استخدام القيم المختارة في الفورم الرئيسي
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DifficultyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
