using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpotDifferenceGame.Managers
{
    public class VisualEffectManager
    {
        private class Effect
        {
            public Point Location { get; set; }
            public bool IsCorrect { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        private static readonly List<Effect> effects = new List<Effect>();
        private readonly List<Effect> _effects = effects;
        private readonly int _effectDurationMs = 2000;
        private readonly string successSoundPath = "C:\\Users\\Sarah\\Documents\\programing projects\\C#\\SpotDifferenceGame\\SpotDifferenceGame\\Assets\\Sounds\\win.mp3";
        private readonly string failureSoundPath = "C:\\Users\\Sarah\\Documents\\programing projects\\C#\\SpotDifferenceGame\\SpotDifferenceGame\\Assets\\Sounds\\over.mp3";
        private readonly SoundManager _soundManager = new SoundManager();


        //=============================================================>

        public void ShowSuccess(Point location)
        {
            _effects.Add(new Effect { Location = location, IsCorrect = true, CreatedAt = DateTime.Now });
            _soundManager.PlaySoundEffect(successSoundPath, 0.8f);
        }

        //=============================================================>

        public void ShowFailure(Point location)
        {
            _effects.Add(new Effect { Location = location, IsCorrect = false, CreatedAt = DateTime.Now });
            _soundManager.PlaySoundEffect(failureSoundPath, 0.8f);
        }

        //=============================================================>

        public void Draw(Graphics g)
        {
            var now = DateTime.Now;

            var expiredEffects = new List<Effect>();

            foreach (var effect in _effects)
            {
                var age = (now - effect.CreatedAt).TotalMilliseconds;

                if (!effect.IsCorrect && age > _effectDurationMs)
                {
                    expiredEffects.Add(effect);
                    continue;
                }

                if (effect.IsCorrect)
                {
                    DrawSuccessEffect(g, effect.Location);
                }
                else
                {
                    DrawFailureEffect(g, effect.Location);
                }
            }

            foreach (var effect in expiredEffects)
                _effects.Remove(effect);
        }

        //=============================================================>

        private void DrawSuccessEffect(Graphics g, Point point)
        {
            using (var pen = new Pen(Color.LimeGreen, 3))
            {
                int radius = 20;
                g.DrawEllipse(pen, point.X - radius, point.Y - radius, radius * 2, radius * 2);
            }
        }
        //=============================================================>

        private void DrawFailureEffect(Graphics g, Point point)
        {
            using (var pen = new Pen(Color.Red, 3))
            {
                int size = 20;
                g.DrawLine(pen, point.X - size, point.Y - size, point.X + size, point.Y + size);
                g.DrawLine(pen, point.X - size, point.Y + size, point.X + size, point.Y - size);
            }
        }

        //=============================================================>

        public void Clear()
        {
            _effects.Clear();
        }
    }
}
