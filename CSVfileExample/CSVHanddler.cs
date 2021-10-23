using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;

using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CSVfileExample
{
    public class CSVHanddler
    {
        public static void ImplementCSVDataHandler()
        {
            string importFilePath = @"E:\bidgelabz\CSVfileExample\CSVfileExample\NewFolder\address.csv";
            string exportFilePath = @"E:\bidgelabz\CSVfileExample\CSVfileExample\NewFolder\export.csv";
           // string exportJsonFilePath= @"E:\bidgelabz\CSVfileExample\CSVfileExample\NewFolder\expAdd.csv";


            using (var reader = new StreamReader(importFilePath))
            
            using(var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from Address.csv");

                foreach(AddressData addressData in records)
                {
                    Console.WriteLine(addressData.firstname);
                    Console.WriteLine(addressData.lastname);
                    Console.WriteLine(addressData.address);
                    Console.WriteLine(addressData.city);
                    Console.WriteLine(addressData.code);
                    Console.WriteLine("************************************");
                }



                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
                Console.WriteLine("Successfully Exported");

                //JsonSerializer serializer = new JsonSerializer();

                //using (StreamWriter sw= new StreamWriter(exportJsonFilePath))
                //    using(JsonWriter writer = new JsonTextWriter(sw))
                //{
                //    serializer.Serialize(writer, records);
                //}

            }
             
        }
    }
}
    