using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Entities
{
    public class CompanyDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
#nullable enable
        public string? Id { get; set; }
#nullable disable
        public string CompanyCode { get; set; }

        //[BsonElement("Name")]
        public string? CompanyName { get; set; }

        public string? CompanyCEO { get; set; }

        public float? CompanyTurnOver { get; set; }

        public string? CompanyWebsite { get; set; }

        public string? StockExchange { get; set; }
    }
}
