using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IoT_Storage.Repository;
using IoT_Storage.Models;
using System;
using Azure.Data.Tables;

namespace IoT_Storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableStorageController : ControllerBase
    {
        [HttpPost("AddTable")]
        public async Task<string> AddTable(string tableName)
        {
            await TableStorage.AddTable(tableName);
            return null;

        }

        [HttpPost("UpdateTable")]
        public async Task<Details> UpdateTable(Details student,string tableName)
        {
            await TableStorage.UpdateTable(student,tableName);
            return null;

        }


        [HttpGet("GetTableData")]
        public async Task<Details> GetTableData(string tableName, string partitionKey, string rowKey)
        {
            var data=await TableStorage.GetTableData(tableName, partitionKey, rowKey);
            return data;

        }

        [HttpGet("GetTable")]
        public async Task<TableClient> GetTable(string tableName)
        {
            var data = await TableStorage.GetTable(tableName);
            return data;

        }


        [HttpDelete("DeleteTableData")]
        public static async Task DeleteTableData(string tableName, string partitionKey, string rowKey)
        {
            await TableStorage.DeleteTableData(tableName, partitionKey, rowKey);
            return;

        }

        [HttpDelete("DeleteTable")]
        public static async Task DeleteTable(string tableName)
        {
            await TableStorage.DeleteTable( tableName);
            return;

        }

    }
}
