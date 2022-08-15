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

        public async Task GetItemTableAsync(TableInformation tableInformation)
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
        }
    }
}
