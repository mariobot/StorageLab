using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using StorageModels;

namespace StorageLibrary
{
    public class StorageService
    {
        public StorageService()
        {
            // Check whether the connection string can be parsed.
            

        }

        public async Task CreateContainerAsync(StorageInformation storageInformation)
        {
            try
            {
                // Create the blobClient
                BlobServiceClient blobServiceClient = new BlobServiceClient(storageInformation.ConnectionString);

                // Create the container and return a container client object
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(storageInformation.ContainerName);

                if (!containerClient.Exists())
                {
                    // Create the container and return a container client object
                    containerClient = blobServiceClient.CreateBlobContainer(storageInformation.ContainerName);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task UploadAsync(StorageInformation storageInformation) 
        {
            // Create the blobClient
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageInformation.ConnectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(storageInformation.ContainerName);

            // Create a local file in the ./data/ directory for uploading and downloading
            string localPath = "./data/";
            string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
            string localFilePath = Path.Combine(localPath, fileName);

            // Write text to the file
            await File.WriteAllTextAsync(localFilePath, "This is random text!");

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Upload data from the local file
            await blobClient.UploadAsync(localFilePath, true);

        }
    }
}
