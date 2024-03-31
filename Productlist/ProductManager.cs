using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductManager
{
    public List<Product> products = new List<Product>();

    public void AddProduct(string category, string name, double price)
    {
        products.Add(new Product { Category = category, Name = name, Price = price });
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product was succefully addet!");
        Console.ResetColor();
        Console.WriteLine("----------------------------------");
    }

    public void PresentProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products added yet.");
            return;
        }

        Console.WriteLine("--------------------");
        Console.WriteLine("Products - Sorted");

        var sortedProducts = products.OrderBy(p => p.Category).ThenBy(p => p.Price);

       
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Category".PadRight(10));
        Console.Write("Name".PadRight(10));
        Console.Write("Price".PadRight(10));
        Console.ResetColor();
        Console.WriteLine();

        foreach (var product in sortedProducts)
        {
            Console.Write(product.Category.PadRight(10));
            Console.Write(product.Name.PadRight(10));
            Console.WriteLine($"Sek {product.Price}".PadRight(10));
            Console.WriteLine();
        }

        double totalPrice = products.Sum(p => p.Price);
        Console.WriteLine($"Total Price: Sek {totalPrice}");
    }

    public void SearchProduct(string searchTerm)
    {
        var foundProducts = products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        if (foundProducts.Any())
        {
            Console.WriteLine("Search Results:");
            foreach (var product in foundProducts)
            {
                Console.WriteLine($"Category: {product.Category}, Name: {product.Name}, Price: Sek {product.Price}");
            }
        }
        else
        {
            Console.WriteLine("No products found.");
        }
    }
}