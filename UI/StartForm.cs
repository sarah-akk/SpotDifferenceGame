using SpotDifferenceGame.Managers;
using System;
using System.Windows.Forms;
namespace SpotDifferenceGame.UI
{
    public partial class StartForm : Form
    {
        private SoundPlayerManager soundManager;

        public StartForm()
        {
            InitializeComponent();
           soundManager = new SoundPlayerManager();

            // شغل الصوت الخلفي عند بداية اللعبة
            string soundPath = "C:\\Users\\Sarah\\Documents\\programing projects\\C#\\SpotDifferenceGame\\SpotDifferenceGame\\Assets\\Sounds\\background.mp3";
            soundManager.PlayBackgroundMusic(soundPath, 0.3f);

        }

        //=============================================================>
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            // 1. نفتح فورم اختيار الصعوبة أولاً
            DifficultyForm difficultyForm = new DifficultyForm();

            if (difficultyForm.ShowDialog() == DialogResult.OK)
            {
                // نحتفظ بالقيم المختارة
                int timeLimit = difficultyForm.SelectedTimeLimit;
                int maxAttempts = difficultyForm.SelectedMaxAttempts;

                // 2. بعد اختيار الصعوبة نفتح فورم اختيار وضع اللعبة (GameModeForm)
                GameModeForm gameModeForm = new GameModeForm();

                if (gameModeForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedMode = gameModeForm.SelectedMode;

                    // 3. نمرر كل القيم لـ MainForm (مثلاً بإضافة الكونستركتور المناسب)
                    MainForm mainForm = new MainForm(selectedMode, timeLimit, maxAttempts);

                    mainForm.Show();
                    this.Hide();
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
          //  soundManager.Stop();
            base.OnFormClosed(e);
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
