using StorageModels;

namespace StorageWebApp.Util
{
    public class SessionUtil
    {//
        public const string SessionConnectionString = "_connstring";//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public const string SessionContainer = "_container";//--------------------
        public const string SessionConnectionString2 = "_connstring2";//----------
        public const string SessionTable = "_container2";//----------------------
        public const string SessionConnectionString3 = "_connstring3";//--------------------
        public const string SessionFile = "_container3";//---------------------------------
        public const string SessionConnectionString4 = "_connstring4"; //----------------------------
        public const string SessionQueue = "_container4";
        public static void SetSessionStorage(StorageInformation storageInformation, HttpContext httpContext)
        {
            httpContext.Session.SetString(SessionConnectionString, storageInformation.ConnectionString);
            httpContext.Session.SetString(SessionContainer, storageInformation.ContainerName);
        }

        public static void SetSessionTable(TableInformation tableInformation, HttpContext httpContext)
        {
            httpContext.Session.SetString(SessionConnectionString2, tableInformation.ConnectionString);
            httpContext.Session.SetString(SessionTable, tableInformation.TableName);
        }

        public static void SetSessionFile(StorageInformation storageInformation, HttpContext httpContext)
        {
            httpContext.Session.SetString(SessionConnectionString, storageInformation.ConnectionString);
            httpContext.Session.SetString(SessionContainer, storageInformation.ContainerName);
        }

        public static void SetSessionQueue(StorageInformation storageInformation, HttpContext httpContext)
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

        public static StorageInformation GetSessionTable(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(SessionConnectionString2) != null
             && httpContext.Session.GetString(SessionContainer2) != null)
            {
                StorageInformation storageInformation = new StorageInformation
                {
                    ConnectionString = httpContext.Session.GetString(SessionConnectionString2),
                    ContainerName = httpContext.Session.GetString(SessionContainer2)
                };

                return storageInformation;
            }
            else
            {
                return null;
            }
        }

        public static StorageInformation GetSessionFile(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(SessionConnectionString3) != null
             && httpContext.Session.GetString(SessionContainer3) != null)
            {
                StorageInformation storageInformation = new StorageInformation
                {
                    ConnectionString = httpContext.Session.GetString(SessionConnectionString3),
                    ContainerName = httpContext.Session.GetString(SessionContainer3)
                };

                return storageInformation;
            }
            else
            {
                return null;
            }
        }

        public static StorageInformation GetSessionQueue(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(SessionConnectionString4) != null
             && httpContext.Session.GetString(SessionContainer24) != null)
            {
                StorageInformation storageInformation = new StorageInformation
                {
                    ConnectionString = httpContext.Session.GetString(SessionConnectionString4),
                    ContainerName = httpContext.Session.GetString(SessionContainer24)
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
