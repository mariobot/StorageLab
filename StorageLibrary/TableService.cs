namespace Library
{
    using Azure.Data.Tables;
    using StorageModels;
    using System.Threading.Tasks;

    public class TableService
    {
        public TableService()
        {

        }

        public async Task CreateTableAsync(TableInformation tableInformation)
        {
            // New instance of the TableClient class
            TableServiceClient tableServiceClient = new TableServiceClient(tableInformation.ConnectionString);

            // New instance of TableClient class referencing the server-side table
            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: tableInformation.TableName
            );

            await tableClient.CreateIfNotExistsAsync();
        }

        public async Task CreateItemTableAsync(TableInformation tableInformation)
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

            TableServiceClient tableServiceClient = new TableServiceClient(tableInformation.ConnectionString);

            // New instance of TableClient class referencing the server-side table
            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: tableInformation.TableName
            );

            // Add new item to server-side table
            await tableClient.AddEntityAsync<TableProduct>(prod1);
        }

        public async Task CreateItemsTableAsync(TableInformation tableInformation)
        {
            string[] maleNames = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };

            TableServiceClient tableServiceClient = new TableServiceClient(tableInformation.ConnectionString);

            // New instance of TableClient class referencing the server-side table
            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: tableInformation.TableName
            );

            for (int i = 0; i < 10; i++)
            {
                // Create new item using composite key constructor
                var prod = new TableProduct()
                {
                    RowKey = "68719518388",
                    PartitionKey = $"partition-{new Random().Next(0, 999999)}-",
                    Name = maleNames[new Random().Next(0, 10)],
                    Quantity = new Random().Next(0, 100),
                    Sale = true
                };

                // Add new item to server-side table
                await tableClient.AddEntityAsync<TableProduct>(prod);
            }
        }

        public async Task<TableProduct> GetItemTableAsync(TableInformation tableInformation)
        {
            TableServiceClient tableServiceClient = new TableServiceClient(tableInformation.ConnectionString);

            // New instance of TableClient class referencing the server-side table
            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: tableInformation.TableName
            );

            // Read a single item from container
            var product = await tableClient.GetEntityAsync<TableProduct>(
                rowKey: "68719518388",
                partitionKey: "gear-surf-surfboards"
            );

            return product.Value;
        }
    }
}
