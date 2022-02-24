using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowsHelper.Repository
{
    internal class GeneralRepository : IGeneralRepository
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            AllowTrailingCommas = false,
            IgnoreNullValues = false,
            IgnoreReadOnlyProperties = true,
            WriteIndented = true
        };

        public async Task<T> SaveAsync<T>(T item)
        {
            using (FileStream stream = new FileStream($"{item}.json", FileMode.OpenOrCreate))
                await JsonSerializer.SerializeAsync(stream, item, options);

            return item;
        }

        //public List<T> GetAll()
        //{


        //    // чтение данных
        //    using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        //    {
        //        Person? person = await JsonSerializer.DeserializeAsync<Person>(fs);
        //        Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
        //    }
        //}
    }
}
