using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using StorageModels;

namespace Library
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

        public async Task Upload2Async(StorageInformation storageInformation)
        {
            try
            {
                // Create the blobClient
                BlobServiceClient blobServiceClient = new BlobServiceClient(storageInformation.ConnectionString);

                // Create the container and return a container client object
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(storageInformation.ContainerName);

                // Create a local file in the ./data/ directory for uploading and downloading
                byte[] byteArray = new byte[255];
                //File.WriteAllBytes(@"c:\folder\file.txt", byteArray);
                //string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
                //string localFilePath = Path.Combine(localPath, fileName);

                // Write text to the file
                //await File.WriteAllTextAsync(localFilePath, "This is random text!");

                // Get a reference to a blob
                MemoryStream ms = new MemoryStream(byteArray);
                BlobClient blobClient = containerClient.GetBlobClient($"myfile{Guid.NewGuid().ToString()}.txt");

                Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);


                // Set blob's content type
                BlobUploadOptions blobOptions = new BlobUploadOptions();
                BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders();
                blobHttpHeaders.ContentType = "application/json";
                blobClient.SetHttpHeaders(blobHttpHeaders);
                blobOptions.HttpHeaders = blobHttpHeaders;

                // Upload data from the local file
                await blobClient.UploadAsync(ms, blobOptions);
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

                await foreach (var item in containerClient.GetBlobsAsync())
                {
                    
                    var t = 2;
                }
                
                

                return null;
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


    }
}
