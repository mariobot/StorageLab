using System; // Namespace for Console output
using System.Configuration; // Namespace for ConfigurationManager
using System.Threading.Tasks; // Namespace for Task
using Azure.Identity;
using Azure.Storage.Queues; // Namespace for Queue storage types
using Azure.Storage.Queues.Models; // Namespace for PeekedMessage
using StorageModels;

namespace Library
{
    public class QueueService
    {
        //-------------------------------------------------
        // Create a message queue
        //-------------------------------------------------
        public bool CreateQueue(QueueInformation queueInformation)
        {
            try
            {

                // Instantiate a QueueClient which will be used to create and manipulate the queue
                QueueClient queueClient = new QueueClient(queueInformation.ConnectionString, queueInformation.QueueName);

                // Create the queue
                queueClient.CreateIfNotExists();

                if (queueClient.Exists())
                {
                    Console.WriteLine($"Queue created: '{queueClient.Name}'");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n\n");
                Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }

        //-------------------------------------------------
        // Insert a message into a queue
        //-------------------------------------------------
        public void InsertMessage(QueueInformation queueInformation)
        {
            // Instantiate a QueueClient which will be used to create and manipulate the queue
            QueueClient queueClient = new QueueClient(queueInformation.ConnectionString, queueInformation.QueueName);

            // Create the queue if it doesn't already exist
            queueClient.CreateIfNotExists();

            if (queueClient.Exists())
            {
                // Send a message to the queue
                queueClient.SendMessage(queueInformation.Message);
            }

            Console.WriteLine($"Inserted: {queueInformation.Message}");
        }

        //-------------------------------------------------
        // Peek at a message in the queue
        //-------------------------------------------------
        public string PeekMessage(QueueInformation queueInformation)
        {
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(queueInformation.ConnectionString, queueInformation.QueueName);

            if (queueClient.Exists())
            {
                // Peek at the next message
                PeekedMessage[] peekedMessage = queueClient.PeekMessages();

                // Display the message
                Console.WriteLine($"Peeked message: '{peekedMessage[0].Body}'");

                return peekedMessage[0].Body.ToString();
            }

            return "No Queue";
        }

        //-------------------------------------------------
        // Update an existing message in the queue
        //-------------------------------------------------
        public void UpdateMessage(QueueInformation queueInformation)
        {
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(queueInformation.ConnectionString, queueInformation.QueueName);
            if (queueClient.Exists())
            {
                // Get the message from the queue
                QueueMessage[] message = queueClient.ReceiveMessages();

                // Update the message contents
                queueClient.UpdateMessage(message[0].MessageId,
                        message[0].PopReceipt,
                        "Updated contents",
                        TimeSpan.FromSeconds(60.0)  // Make it invisible for another 60 seconds
                    );
            }
        }

        //-------------------------------------------------
        // Process and remove a message from the queue
        //-------------------------------------------------
        public void DequeueMessage(QueueInformation queueInformation)
        {   
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(queueInformation.ConnectionString, queueInformation.QueueName);

            if (queueClient.Exists())
            {
                // Get the next message
                QueueMessage[] retrievedMessage = queueClient.ReceiveMessages();

                // Process (i.e. print) the message in less than 30 seconds
                Console.WriteLine($"Dequeued message: '{retrievedMessage[0].Body}'");

                // Delete the message
                queueClient.DeleteMessage(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
            }
        }
    }
}
