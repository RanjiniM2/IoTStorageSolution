using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;



namespace IoT_Storage.Repository
{
    public class BlobStorage
    {
       public static string connectionString = "";

        public static async Task CreateBlob(string blobName)
        {
            if(string.IsNullOrEmpty(blobName))
            {
                throw new ArgumentNullException("Enter Blob Name: ");
            }
            try
            {
                BlobContainerClient container = new BlobContainerClient(connectionString, blobName);
                await container.CreateAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<string>> GetBlob(string blobName,string file)
        {
            if (string.IsNullOrEmpty(blobName))
            {
                throw new ArgumentNullException("Enter Blob Name: ");
            }
            try
            {
                BlobContainerClient container = new BlobContainerClient(connectionString, blobName);
                List<string> name = new List<string>();
                await foreach(BlobItem b in container.GetBlobsAsync())
                {
                    name.Add(b.Name);
                }
                return name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<BlobProperties> GetBlobContent(string blobName, string file)
        {
            if (string.IsNullOrEmpty(blobName))
            {
                throw new ArgumentNullException("Enter Blob Name: ");
            }
            try
            {
                BlobContainerClient container = new BlobContainerClient(connectionString, blobName);
                BlobClient blob = container.GetBlobClient(file);
                BlobProperties properties = await blob.GetPropertiesAsync();
                return properties;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public static async Task<BlobProperties> UpdateBlobContent(string blobName, string file)
        {
            if (string.IsNullOrEmpty(blobName))
            {
                throw new ArgumentNullException("Enter Blob Name: ");
            }
            try
            {
                string filename = Path.GetTempFileName();
                BlobContainerClient container = new BlobContainerClient(connectionString, blobName);
                BlobClient blob = container.GetBlobClient(file);
                await blob.UploadAsync(filename);
                BlobProperties properties = await blob.GetPropertiesAsync();
                return properties;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        public static async Task UpdateBlobContent(string blobName, string file)
        {
            if (string.IsNullOrEmpty(blobName))
            {
                throw new ArgumentNullException("Enter Blob Name: ");
            }
            try
            {
                
                BlobContainerClient container = new BlobContainerClient(connectionString, blobName);
                BlobClient blob = container.GetBlobClient(file);
                var filepath = @"C:\Users\vmadmin\Downloads\IoT_Storage_Solution\IoT_Storage_Solution\IoT_Storage\NewBlobTest\Dps.pdf";
                using FileStream uploadFileStream = File.OpenRead(filepath);
                await blob.UploadAsync(uploadFileStream,true);
                uploadFileStream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task DeleteBlob(string blobName)
        {
            if(string.IsNullOrEmpty(blobName))
            {
                throw new ArgumentNullException("Enter Blob Name: ");
            }
            try
            {
                BlobContainerClient container = new BlobContainerClient(connectionString, blobName);
                await container.DeleteAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static async Task DeleteBlobContent(string blobName,string file)
        {
            if (string.IsNullOrEmpty(blobName))
            {
                throw new ArgumentNullException("Enter Blob Name: ");
            }
            try
            {
                BlobContainerClient container = new BlobContainerClient(connectionString, blobName);
                await container.DeleteBlobAsync(file);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static async Task<BlobProperties> DownloadBlob(string blobName,string file)
        {
            try
            {
                string path = "";
                BlobContainerClient blobContainer = new BlobContainerClient(connectionString,blobName);
                BlobClient client = blobContainer.GetBlobClient(file);
                await client.DownloadToAsync(path);
                BlobProperties properties = await client.GetPropertiesAsync();
                return properties;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
