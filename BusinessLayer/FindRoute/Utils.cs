using System;

namespace BusinessLayer
{
    public static class Utils
    {
        public static double Distance(double x1, double y1, double x2, double y2) => Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
    }
}
