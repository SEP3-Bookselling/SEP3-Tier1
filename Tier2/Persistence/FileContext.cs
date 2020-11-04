using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SEP3_Tier1.Models;

namespace FileData {
public class FileContext {
    public IList<BookSale> BookSales { get; private set; }

    
    private readonly string salesFile = "sales.json";

    public FileContext() {
        BookSales = File.Exists(salesFile) ? ReadData<BookSale>(salesFile) : new List<BookSale>();
    }

    private IList<T> ReadData<T>(string s) {
        using (var jsonReader = File.OpenText(s)) {
            return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
        }
    }

    public void SaveChanges() {
        string jsonFamilies = JsonSerializer.Serialize(BookSales, new JsonSerializerOptions {
            WriteIndented = true
        });

        
    }
}
}