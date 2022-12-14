using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace mongoDBRestApi.Models
{
    public class Movie
    {

        public Movie()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string MovieName { get; set; } = null!;

        [BsonElement("Date")]
        [JsonPropertyName("Date")]
        public DateTime ReleaseDate { get; set; }

        [BsonElement("Synopsis")]
        [JsonPropertyName("Synopsis")]
        public string Description { get; set; } = null!;

        [BsonElement("liked")]
        [JsonPropertyName("liked")]
        public bool liked { get; set; }


        [BsonElement("watchlater")]
        [JsonPropertyName("watchlater")]
        public bool watchlater { get; set; }


    }
}

