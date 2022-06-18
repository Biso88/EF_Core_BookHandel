using EF_Core_BookHandel.Models;
using static EF_Core_BookHandel.Methods;

class Program
{

    static async Task Main(string[] args)
    {
        
        bool isRunning = true;
        while (isRunning)
        {

            DiplayColoredMessage("Choose an alternative from the menu...", ConsoleColor.Yellow, ConsoleColor.Black);
            Console.WriteLine("\t1- Display books.");
            Console.WriteLine("\t2- Add book.");
            Console.WriteLine("\t3- Remove book. ");
            Console.WriteLine("\t4- Store's information. "); 
            Console.WriteLine("\t5- Exit the program. ");

            int.TryParse(Console.ReadLine(), out int menu);

            switch (menu)
            {
                case 1:
                    DiplayColoredMessage("Displaying books.");
                    var booksList = await EF_Core_BookHandel.Methods.GetAsync<Book>();
                    foreach (var book in booksList)
                        Console.WriteLine($"\t{book.Tittle}");
                    break;

                case 2:
                    Console.WriteLine("Add a book to the context.\n ");
                    await EF_Core_BookHandel.Methods.AddItemAsync();
                    break;

                case 3:
                    Console.WriteLine("Remove a book from the context. ");
                    await EF_Core_BookHandel.Methods.RemoveItem();
                    break;

                case 4:
                    Console.WriteLine("Show stores balance: ");
                    var storeBalance = await GetBalancesAsync();
                    foreach (var store in storeBalance)
                        Console.WriteLine($"{"\n Store's name:"} {store.Store.StoresName} " +
                            $"\n {"Book's title:"} {store.Isbn13Navigation.Tittle}" +
                            $"\n {"Price:"} {store.Isbn13Navigation.Price} " +
                            $"\n {"Quantity:"} {store.Quantity}");
                    break;
                case 5:
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Please choose from the menu!");
                    break;
            }
            
            Console.WriteLine();
            
        }
    }

    public static void DiplayColoredMessage(string message, ConsoleColor bg = ConsoleColor.Red, ConsoleColor fore = ConsoleColor.White)
    {
        Console.BackgroundColor = bg;
        Console.ForegroundColor = fore;
        Console.WriteLine(message);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }
}

