using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using StorageModels;

namespace LibraryModel
{
    public class TableService
    {
        const string TABLE_NAME = "";

        public TableService()
        {

        }

        public async Task CreateTable()
        {
            // New instance of the TableClient class
            TableServiceClient tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));

            // New instance of TableClient class referencing the server-side table
            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: "adventureworks"
            );

            await tableClient.CreateIfNotExistsAsync();
        }

        public async Task CreateItemTable()
        {
            // Create new item using composite key constructor
            var prod1 = new TableProduct()
            {
                RowKey = "68719518388",
                PartitionKey = "gear-surf-surfboards",
                Name = "Ocean Surfboard",
                Quantity = 8,
                Sale = true
            };

            TableServiceClient tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));

            // New instance of TableClient class referencing the server-side table
            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: "adventureworks"
            );

            // Add new item to server-side table
            await tableClient.AddEntityAsync<TableProduct>(prod1);


        }

        public async Task GetItemTableAsync()
        {
            TableServiceClient tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));

            // New instance of TableClient class referencing the server-side table
            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: "adventureworks"
            );

            // Read a single item from container
            var product = await tableClient.GetEntityAsync<TableProduct>(
                rowKey: "68719518388",
                partitionKey: "gear-surf-surfboards"
            );
            Console.WriteLine("Single product:");
            Console.WriteLine(product.Value.Name);

        }
    }
}
