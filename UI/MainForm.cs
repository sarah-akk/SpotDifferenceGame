using SpotDifferenceGame.Managers;
using System;
using System.Drawing;
using System.Windows.Forms;
using static SpotDifferenceGame.UI.GameModeForm;

namespace SpotDifferenceGame.UI
{
    public partial class MainForm : Form

    {

        private Bitmap loadedImage1;
        private Bitmap loadedImage2;
        private GameManager gameManager = new GameManager();
        private VisualEffectManager visualEffect = new VisualEffectManager();
        private int secondsLeft = 60;
        private Button btnRestart;
        private PictureBox pictureBoxDebug;
        private GameMode _gameMode;
        private int TimeLimit;
        private int MaxAttempts;
        private SoundPlayerManager soundManager;

        //=============================================================>


        public MainForm(GameModeForm.GameMode selectedMode, int timeLimit, int maxAttempts , SoundPlayerManager manager)
        {
            InitializeComponent();
            _gameMode = selectedMode;
            this.TimeLimit = timeLimit;
            this.MaxAttempts = maxAttempts;
            soundManager = manager;

            ConfigureGameMode(_gameMode);
            InitializeGame();

            pictureBoxLeft.Paint += pictureBox_Paint;
            pictureBoxLeft.MouseClick += PictureBox_Click;
            btnRestart.Click += BtnRestart_Click;
            btnLoadImage1.Click += BtnLoadImage1_Click;
            btnLoadImage2.Click += BtnLoadImage2_Click;
            this.FormClosing += MainGameForm_FormClosing;

            UpdateLabels();

        }

        private void ConfigureGameMode(GameModeForm.GameMode mode)
        {
            if (mode == GameModeForm.GameMode.TimeLimit)
            {
                gameManager.ResetGame(maxAttempts: 0, timeLimitSeconds: TimeLimit, useTimeLimit: true);
            }
            else if (mode == GameModeForm.GameMode.LimitedAttempts)
            {
                gameManager.ResetGame(maxAttempts: MaxAttempts, timeLimitSeconds: 0, useTimeLimit: false);
            }
            UpdateLabels();

        }



        //=============================================================>

        private void InitializeGame()
        {

            if (loadedImage1 != null && loadedImage2 != null)
            {

                gameManager.OnPlayerClick += GameManager_OnPlayerClick;

                pictureBoxLeft.Image = loadedImage1;
                pictureBoxRight.Image = loadedImage2;

                secondsLeft = gameManager.TimeLimitInSeconds;
                gameTimer.Start();

                UpdateLabels();

                this.pictureBoxDebug = new PictureBox();
                this.pictureBoxDebug.Location = new Point(1000, 20);
                this.pictureBoxDebug.Size = new Size(300, 300);
                this.pictureBoxDebug.SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(this.pictureBoxDebug);

                var debugImage = gameManager.LoadImages(loadedImage1, loadedImage2);

                pictureBoxDebug.Image = debugImage;
            }


        }

        //=============================================================>

        private void PictureBox_Click(object sender, MouseEventArgs e)
        {
            gameManager.HandleClick(e.Location);
            pictureBoxLeft.Invalidate(); 
            UpdateLabels();
        }

        //=============================================================>

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            visualEffect.Draw(e.Graphics);
        }

        //=============================================================>

        private void GameManager_OnPlayerClick(Point point, bool isCorrect)
        {
            if (isCorrect)
            {
                visualEffect.ShowSuccess(point); 
            }
            else
            {
                visualEffect.ShowFailure(point);
            }

            if (gameManager.IsGameOver)
            {
                gameTimer.Stop();
                MessageBox.Show("GameManager Over!");
            }
        }

        //=============================================================>

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!gameManager.UseTimeLimit)
                return;  

            secondsLeft--;
            labelGameStatus.Text = $"time left : {secondsLeft}s";

            if (secondsLeft <= 0)
            {
                gameTimer.Stop();
                MessageBox.Show("Time over!");
            }
        }

        //=============================================================>

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            if (_gameMode == GameModeForm.GameMode.TimeLimit)
            {
                gameManager.ResetGame(maxAttempts: 0, timeLimitSeconds: 60, useTimeLimit: true);
            }
            else if (_gameMode == GameModeForm.GameMode.LimitedAttempts)
            {
                gameManager.ResetGame(maxAttempts: 10, timeLimitSeconds: 0, useTimeLimit: false);
            }

            visualEffect.Clear();
            secondsLeft = gameManager.TimeLimitInSeconds;
            gameTimer.Start();
            pictureBoxLeft.Invalidate();
            UpdateLabels();
        }

        //=============================================================>

        private void UpdateLabels()
        {
            int remainingDiffs = gameManager.AllDifferences.Count - gameManager.FoundDifferences.Count;
            int FoundDifferences = gameManager.FoundDifferences.Count;
            int AttemptsLeft = gameManager.AttemptsLeft;


            labelFoundCount.Text = $"الفروقات المكتشفة: {FoundDifferences}";

            labelRemainingCount.Text = $"الفروقات المتبقية: {remainingDiffs}";

            labelGameStatus.Text = $"الوقت المتبقي: {secondsLeft}s";

            labelAttempts.Text = $"المحاولات المتبقية: {AttemptsLeft}";
        }
        //=============================================================>


        private void BtnLoadImage1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadedImage1 = new Bitmap(openFileDialog.FileName);
                pictureBoxLeft.Image = loadedImage1;
                if (loadedImage2 != null)
                {
                    InitializeGame();
                }
            }
            UpdateLabels();

        }
        //=============================================================>

        private void BtnLoadImage2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadedImage2 = new Bitmap(openFileDialog.FileName);
                pictureBoxRight.Image = loadedImage2;
                if (loadedImage1 != null) 
                {
                    InitializeGame();
                }
            }
            UpdateLabels();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
 
        }

        private void MainGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            soundManager.Stop();
        }

    }
}
