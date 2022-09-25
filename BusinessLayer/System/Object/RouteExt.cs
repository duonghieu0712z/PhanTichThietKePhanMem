namespace BusinessLayer.System.Object
{
    public class RouteExt : RouteFuncs
    {
        private static RouteExt instance = null;
        public static RouteExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new RouteExt();
                return instance;
            }
        }
    }
}
