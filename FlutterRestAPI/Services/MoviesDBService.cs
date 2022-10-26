using System;
using FlutterRestAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlutterRestAPI.Services
{
    public class MoviesDBService
    {

        private readonly IMongoCollection<Movie> _moviesCollection;
        
        public MoviesDBService(IOptions<MongoDBSetings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var monogoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _moviesCollection = monogoDatabase.GetCollection<Movie>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Movie>> GetMoviesAsync() => await _moviesCollection.Find(_ => true).ToListAsync();
        public async Task<Movie?> GetMoviesAsync(String id) => await _moviesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Movie newMovie) => await _moviesCollection.InsertOneAsync(newMovie);
        public async Task UpdateAsync(String id, Movie MovieUpdate) => await _moviesCollection.ReplaceOneAsync(x => x.Id == id, MovieUpdate);
        public async Task RemoveAsync(String id) => await _moviesCollection.DeleteOneAsync(x => x.Id == id);
    }
}

