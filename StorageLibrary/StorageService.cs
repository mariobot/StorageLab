namespace Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using StorageModels;
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

        public async Task Upload2Async(StorageInformation storageInformation)
        {
            try
            {
                await CreateContainerAsync(storageInformation);

                // Create the blobClient
                BlobServiceClient blobServiceClient = new BlobServiceClient(storageInformation.ConnectionString);

                // Create the container and return a container client object
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(storageInformation.ContainerName);

                // create file from byteArray
                byte[] byteArray = new byte[255];

                // Get a reference to a blob
                MemoryStream ms = new MemoryStream(byteArray);
                BlobClient blobClient = containerClient.GetBlobClient($"myfile{Guid.NewGuid().ToString()}.txt");

                Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

                // Upload data from the local file
                await blobClient.UploadAsync(ms);
            }
            catch (Exception ex)
            {
                throw;
            }
            

        }

        public async Task<Azure.Pageable<BlobItem>> ListBlobsAsync(StorageInformation storageInformation)
        {
            try
            {
                // Create the blobClient
                BlobServiceClient blobServiceClient = new BlobServiceClient(storageInformation.ConnectionString);

                // Create the container and return a container client object
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(storageInformation.ContainerName);

                var result = containerClient.GetBlobs();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task DeleteContainerAsync(StorageInformation storageInformation)
        {   
            // Create the blobClient
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageInformation.ConnectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(storageInformation.ContainerName);

            await containerClient.DeleteAsync();
        }

        public async Task DeleteFileAsync(StorageInformation storageInformation, string filename)
        {
            // Create the blobClient
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageInformation.ConnectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(storageInformation.ContainerName);

            containerClient.GetBlobClient(filename).Delete();
        }

        public async Task<Stream> DownloadFileAsync(StorageInformation storageInformation, string filename)
        {
            // Create the blobClient
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageInformation.ConnectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(storageInformation.ContainerName);

            Stream file = containerClient.GetBlobClient(filename).OpenRead();

            return file;
        }
    }
}
