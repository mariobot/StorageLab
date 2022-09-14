using StorageModels;

namespace StorageWebApp.Util
{
    public class SessionUtil
    {//
        public const string SessionConnectionString = "_connstring";//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public const string SessionContainer = "_container";//--------------------
        public const string SessionConnectionString2 = "_connstring2";//----------
        public const string SessionTable = "_table";//----------------------
        public const string SessionConnectionString3 = "_connstring3";//--------------------
        public const string SessionFile = "_file";//---------------------------------
        public const string SessionConnectionString4 = "_connstring4"; //----------------------------
        public const string SessionQueue = "_queue";
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

        public static void SetSessionQueue(QueueInformation queueInformation, HttpContext httpContext)
        {
            httpContext.Session.SetString(SessionConnectionString3, queueInformation.ConnectionString);
            httpContext.Session.SetString(SessionQueue, queueInformation.QueueName);
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

        public static TableInformation GetSessionTable(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(SessionConnectionString2) != null
             && httpContext.Session.GetString(SessionTable) != null)
            {
                TableInformation tableInformation = new TableInformation
                {
                    ConnectionString = httpContext.Session.GetString(SessionConnectionString2),
                    TableName = httpContext.Session.GetString(SessionTable)
                };

                return tableInformation;
            }
            else
            {
                return null;
            }
        }

        public static StorageInformation GetSessionFile(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(SessionConnectionString3) != null
             && httpContext.Session.GetString(SessionFile) != null)
            {
                StorageInformation storageInformation = new StorageInformation
                {
                    ConnectionString = httpContext.Session.GetString(SessionConnectionString3),
                    ContainerName = httpContext.Session.GetString(SessionFile)
                };

                return storageInformation;
            }
            else
            {
                return null;
            }
        }

        public static QueueInformation GetSessionQueue(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(SessionConnectionString3) != null
             && httpContext.Session.GetString(SessionQueue) != null)
            {
                QueueInformation queueInformation = new QueueInformation
                {
                    ConnectionString = httpContext.Session.GetString(SessionConnectionString3),
                    Message = httpContext.Session.GetString(SessionQueue)
                };

                return queueInformation;
            }
            else
            {
                return null;
            }
        }
    }
}
