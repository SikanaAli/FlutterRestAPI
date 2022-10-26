using System;
namespace FlutterRestAPI.Models
{
    public class MongoDBSetings
    {

        public String ConnectionURI { get; set; } = null!;
        public String DatabaseName { get; set; } = null!;
        public String CollectionName { get; set; } = null!;

    }
}

