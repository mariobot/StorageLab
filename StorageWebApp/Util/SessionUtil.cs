using StorageModels;

namespace StorageWebApp.Util
{
    public class SessionUtil
    {
        public const string SessionConnectionString = "_connstring";
        public const string SessionContainer = "_container";

        public static void SetSession(StorageInformation storageInformation, HttpContext httpContext)
        {
            httpContext.Session.SetString(SessionConnectionString, storageInformation.ConnectionString);
            httpContext.Session.SetString(SessionContainer, storageInformation.ContainerName);
        }

        public static StorageInformation GetSession(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(SessionConnectionString) != null
             && httpContext.Session.GetString(SessionContainer) != null)
            {
                StorageInformation storageInformation = new StorageInformation
                {
                    ConnectionString = httpContext.Session.GetString(SessionConnectionString),
                    ContainerName = httpContext.Session.GetString(SessionContainer)
                };

                return storageInformation;
            }
            else 
            {
                return null;
            }
        }
    }
}
