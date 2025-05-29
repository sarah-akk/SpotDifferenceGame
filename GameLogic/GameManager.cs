using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;

namespace SpotDifferenceGame.Managers
{
    public class GameManager
    {
        public Bitmap Image1 { get; private set; }
        public Bitmap Image2 { get; private set; }

        public List<Point> FoundDifferences { get; private set; } = new List<Point>();
        public List<Point> AllDifferences { get; private set; } = new List<Point>();

        public int MaxAttempts { get; set; } = 10;
        public int AttemptsLeft { get; private set; }
        public int TimeLimitInSeconds { get; set; } = 60;
        public bool UseTimeLimit { get; set; } = false;

        public event Action<Point, bool> OnPlayerClick;

        private const double AllowedDistance = 20;  // Allowed click radius

        //=============================================================>

        public Bitmap LoadImages(Bitmap img1, Bitmap img2)
        {
            Image1 = img1;
            Image2 = img2;

            FoundDifferences.Clear();
            AllDifferences.Clear();

            Bitmap debug;
            var resized1 = ResizeBitmap(Image1, 300, 300);
            var resized2 = ResizeBitmap(Image2, 300, 300);

            var rects = ImageDifferenceDetector.DetectDifferences(resized1, resized2, out debug);

            foreach (var rect in rects)
            {
                var center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                AllDifferences.Add(center);
            }

            return debug; // Return debug image to display elsewhere
        }

        //=============================================================>

        public bool IsGameOver
        {
            get
            {
                bool noAttemptsLeft = AttemptsLeft <= 0;
                bool allFound = FoundDifferences.Count == AllDifferences.Count;

                if (UseTimeLimit)
                {
                    // ?? ??? ?????? ?? ???? ?????? ????? ??? ?????????
                    return allFound;
                }
                else
                {
                    // ?? ??? ????????? ???? ??? ????? ????????? ?? ??? ??? ?? ????????
                    return allFound || noAttemptsLeft;
                }
            }
        }

        //=============================================================>

        public void HandleClick(Point clickLocation)
        {
            if (IsGameOver)
                return;

            bool isCorrect = false;

            foreach (var diff in AllDifferences)
            {
                if (FoundDifferences.Contains(diff))
                    continue;

                double distance = CalculateDistance(clickLocation, diff);
                if (distance < AllowedDistance)
                {
                    FoundDifferences.Add(diff);
                    isCorrect = true;
                    break;
                }
            }

            // ??? ????????? ??? ?? ?? ?????? ?????
            if (!UseTimeLimit)
            {
                AttemptsLeft--;
            }

            var handler = OnPlayerClick;
            if (handler != null)
                handler(clickLocation, isCorrect);
        }


        //=============================================================>

        private double CalculateDistance(Point p1, Point p2)
        {
            var v1 = Vector<double>.Build.DenseOfArray(new double[] { p1.X, p1.Y });
            var v2 = Vector<double>.Build.DenseOfArray(new double[] { p2.X, p2.Y });
            return (v1 - v2).L2Norm();
        }
        //=============================================================>

        public void ResetGame(int maxAttempts, int timeLimitSeconds, bool useTimeLimit)
        {
            FoundDifferences.Clear();

            if (maxAttempts > 0)
                MaxAttempts = maxAttempts;

            if (timeLimitSeconds > 0)
                TimeLimitInSeconds = timeLimitSeconds;

            UseTimeLimit = useTimeLimit;

            if (UseTimeLimit)
            {
                AttemptsLeft = 0;
            }
            else
            {
                AttemptsLeft = MaxAttempts;
                TimeLimitInSeconds = 0;
            }
        }



        //=============================================================>

        Bitmap ResizeBitmap(Bitmap source, int width, int height)
        {
            var dest = new Bitmap(width, height);
            using (var g = Graphics.FromImage(dest))
            {
                g.DrawImage(source, 0, 0, width, height);
            }
            return dest;
        }


    }
}
