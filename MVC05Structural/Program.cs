
using MVC05Structural;
using System.Text.Json;



List<Product> productsEntrance = new List<Product>();

for (int i = 1; i <= 10; i++)
{
    Product product = new Product(i, $"продукт{i}", i*2);

    productsEntrance.Add(product);
}
// сохранение данных json
using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
{
    
    await JsonSerializer.SerializeAsync<List<Product>>(fs, productsEntrance);
    Console.WriteLine("Данные были записаны в файл");
}

Console.WriteLine();
// чтение данных json
using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
{
    Console.WriteLine("Чтение данных из файла ...");
    Console.WriteLine();

    List<Product>? productsExit = await JsonSerializer.DeserializeAsync<List<Product>>(fs);
    foreach (var i in productsExit)
    {
        Console.WriteLine($"ProductID: {i.ProductID}, ProductName: {i.ProductName}, ProductPrice: {i.ProductPrice}");
    }
    
}


