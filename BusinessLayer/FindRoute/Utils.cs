using System;

namespace BusinessLayer
{
    public static class Utils
    {
        public static double Distance(double x1, double y1, double x2, double y2) => Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

        public static double GeoDistance(double lat1, double long1, double lat2, double long2)
        {
            const double R = 6371;
            double phi1 = Deg2Rad(lat1);
            double phi2 = Deg2Rad(lat2);
            double dPhi = Deg2Rad(lat1 - lat2);
            double dTheta = Deg2Rad(long1 - long2);

            double a = Math.Sin(dPhi / 2) * Math.Sin(dPhi / 2) + Math.Cos(phi1) * Math.Cos(phi2) * Math.Sin(dTheta / 2) * Math.Sin(dTheta / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        public static double Deg2Rad(double deg) => deg * (Math.PI / 180.0);

        public static double Rad2Deg(double rad) => rad * (180.0 / Math.PI);
    }
}
