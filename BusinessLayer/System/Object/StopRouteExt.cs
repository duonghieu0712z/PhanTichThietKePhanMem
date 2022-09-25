namespace BusinessLayer.System.Object
{
    public class StopRouteExt : StopRouteFuncs
    {
        private static StopRouteExt instance = null;
        public static StopRouteExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new StopRouteExt();
                return instance;
            }
        }
    }
}
