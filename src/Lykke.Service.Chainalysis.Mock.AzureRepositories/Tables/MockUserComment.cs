using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Tables
{
    public class MockUserComment : TableEntity
    {

        public MockUserComment()
        {
            ETag = "*";
        }

        public string Token
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        public string UserId
        {
            get => RowKey;
            set => RowKey = value;
        }

     
        public string Comment { get; set; }

    }
}
