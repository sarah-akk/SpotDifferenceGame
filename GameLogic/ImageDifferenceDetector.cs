using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Collections.Generic;

namespace SpotDifferenceGame.Managers
{
    public class ImageDifferenceDetector
    {
        public static List<Rectangle> DetectDifferences(
            Bitmap image1,
            Bitmap image2,
            out Bitmap debugImage,
            double threshold = 30.0)
        {
            var differences = new List<Rectangle>();
            debugImage = null;

            Mat mat1 = null;
            Mat mat2 = null;
            Image<Gray, byte> img1 = null;
            Image<Gray, byte> img2 = null;
            Image<Gray, byte> diff = null;
            Image<Gray, byte> binary = null;
            Emgu.CV.Util.VectorOfVectorOfPoint contours = null;

            try
            {
                mat1 = BitmapToMat(image1);
                mat2 = BitmapToMat(image2);

                img1 = mat1.ToImage<Gray, byte>();
                img2 = mat2.ToImage<Gray, byte>();

             
                diff = img1.AbsDiff(img2);
                binary = diff.ThresholdBinary(new Gray(threshold), new Gray(255));

                CvInvoke.Dilate(binary, binary, null, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());

                contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
                CvInvoke.FindContours(binary, contours, null, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                //=============================================================>

                // Create a debug image from the original
                var debugMat = mat1.Clone();
                for (int i = 0; i < contours.Size; i++)
                {
                    var rect = CvInvoke.BoundingRectangle(contours[i]);
                    if (rect.Width > 10 && rect.Height > 10)
                    {
                        differences.Add(rect);
                        CvInvoke.Rectangle(debugMat, rect, new MCvScalar(0, 0, 255), 2); // red box
                    }
                }

                debugImage = debugMat.ToImage<Bgr, byte>().ToBitmap(); // ? works
            }
            finally
            {
                contours?.Dispose();
                binary?.Dispose();
                diff?.Dispose();
                img2?.Dispose();
                img1?.Dispose();
                mat2?.Dispose();
                mat1?.Dispose();
            }

            return differences;
        }

        //=============================================================>

        private static Mat BitmapToMat(Bitmap bmp)
        {
            return bmp.ToMat();
        }

    }
}
