using System;
using System.Windows.Forms;

namespace SpotDifferenceGame.UI
{
    public partial class GameModeForm : Form
    {
        public enum GameMode
        {
            TimeLimit,
            LimitedAttempts
        }

        public GameMode SelectedMode { get; private set; }

        public GameModeForm()
        {
            InitializeComponent();
            btnTimeLimit.Click += BtnTimeLimit_Click;
            btnLimitedAttempts.Click += BtnLimitedAttempts_Click;
        }

        private void BtnTimeLimit_Click(object sender, EventArgs e)
        {
            SelectedMode = GameMode.TimeLimit;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnLimitedAttempts_Click(object sender, EventArgs e)
        {
            SelectedMode = GameMode.LimitedAttempts;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void GameModeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
