using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WorldFlags.Models;

namespace WorldFlags.Services
{
    public class JsonFileFlagService
    {
        public JsonFileFlagService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "AllFlags.json"); }
        }
        private readonly string RESTCountries = "https://restcountries.eu/rest/v2/all";
        //public IEnumerable<Country> GetCountries()
        //{
        //    using (var jsonFileReader = File.OpenText(JsonFileName))
        //    {
        //        return JsonSerializer.Deserialize<Country[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true
        //        });
        //    }
        //}
        public World GetCountries()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<World>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }
        public void UpdateData()
        {
            string jsonFileReader = (new WebClient()).DownloadString(RESTCountries);
            World world = new World(DateTime.Now.Date,
            JsonSerializer.Deserialize<List<Country>>(jsonFileReader, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }));
            //Debug.WriteLine(jsonFileReader);
            //Debug.WriteLine(world.ToString());

            //manual changes
            world.Countries.FirstOrDefault(x => x.Alpha2Code == "GB").RegionalBlocs = new List<RegionalBloc>();

            JsonDocument jdoc = JsonDocument.Parse(JsonSerializer.Serialize(world));


            using (FileStream fs = File.Create(JsonFileName))
            {

                using var writer = new Utf8JsonWriter(fs, new JsonWriterOptions { Indented = true });
                jdoc.WriteTo(writer);

            }
        }
    }
}
