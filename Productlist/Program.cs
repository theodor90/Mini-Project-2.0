class Program
{
    static void Main(string[] args)
    {
        ProductManager manager = new ProductManager();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("To enter a new product - follow the steps | To quit - enter: 'q'");
        Console.ResetColor();

        while (true)
        {
            Console.Write("Enter a Category:");
            string category = Console.ReadLine();
            if (category.ToLower() == "q")
                break;

            Console.Write("Enter product name:");
            string name = Console.ReadLine();

            Console.Write("Enter price:");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid price. Please enter a valid number:");
                Console.ResetColor();
            }

            manager.AddProduct(category, name, price);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("To enter a new product - follow the steps | To quit - enter: 'q'");
            Console.ResetColor();
        }

        manager.PresentProducts();

        //Console.WriteLine("Thank you for using this program");
        string searchInput = Console.ReadLine();
        if (searchInput.ToLower() != "q")
        {
            manager.SearchProduct(searchInput);
        }
    }
}