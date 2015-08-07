namespace Dimensions
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        private static Size GetRotated(Size size, double angle)
        {
            var cosAngle = Math.Abs(Math.Cos(angle));
            var sinAngle = Math.Abs(Math.Sin(angle));
            var widthSize = (cosAngle * size.width) + (sinAngle * size.height);
            var heightSize = (sinAngle * size.width) + (cosAngle * size.height);

            return new Size(widthSize, heightSize);
        }
    }
}
