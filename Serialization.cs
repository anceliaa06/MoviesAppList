using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MoviesAppWithList
{
    internal class Serialization
    {
        private static readonly string filePath = "movies.json";

        public static void SerializeData(List<Movie> movies)
        {
            try
            {
                string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving data: " + ex.Message);
            }
        }

        public static List<Movie> DeserializeData()
        {
            try
            {
                if (!File.Exists(filePath))
                    return new List<Movie>();

                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Movie>>(jsonData) ?? new List<Movie>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading data: " + ex.Message);
                return new List<Movie>();
            }
        }
    }
}
