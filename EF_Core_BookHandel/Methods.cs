using Microsoft.EntityFrameworkCore;
using EF_Core_BookHandel.Models;
namespace EF_Core_BookHandel
{
    public class Methods
    {
        public static async Task<List<StoresBalance>> GetBalancesAsync()
        {
            using (var context = new BookHandelContext())
            {

                var balances = await context.StoresBalances
                    .OrderBy(x=>x.StoreId)
                    .Include(x => x.Store)
                    .Include(x => x.Isbn13Navigation)
                    .ToListAsync();
                return balances;
            }
        }

        public static async Task<IList<T>> GetAsync<T>() where T : class
        {
            using (var context = new BookHandelContext())
                return await context.Set<T>().ToListAsync();
        }

        public static async Task AddAsync<T>(T newEntity) where T : class
        {
            using (var context = new BookHandelContext())
            {
                context.Add(newEntity!);
                await context.SaveChangesAsync();
            }
        }

        public static async Task RemoveItemAsync<T>(T newEntity) where T : class
        {
            using (var context = new BookHandelContext())
            {
                context.Remove(newEntity!);
                await context.SaveChangesAsync();
                Console.WriteLine("\n\tDeleted!");
            }
        }

        public static async Task AddItemAsync()
        {
            var stores = await GetAsync<Store>();

            for (int i = 0; i < stores.Count; i++)
                Console.WriteLine($"{i} - {stores[i].StoresName}");

            Console.WriteLine("\nSelect Store: ");
            int.TryParse(Console.ReadLine(), out int storeIndex);

            Console.Write("Enter in books ISBN-number: *13 Digit \t");
            long.TryParse(Console.ReadLine(), out long isbn);
            Console.Write("Enter in books title: ");
            string title = Console.ReadLine();
            Console.Write("Enter in price: ");
            decimal.TryParse(Console.ReadLine(), out decimal price);
            Console.Write("Enter quantity: ");

            int.TryParse(Console.ReadLine(), out int quantity);

            await AddAsync(new Book()
            {
                Isbn13 = isbn,
                AuthorsId = 0,
                Price = price,
                Tittle = title,
                PublicationDate = DateTime.Now,
            });

            await AddAsync(new StoresBalance()
            {
                Isbn13 = isbn,
                Quantity = quantity,
                StoreId = stores[storeIndex].Id,
            });
        }

        internal static async Task RemoveItem()
        {
            Book selected = await displayBookSelectionOptions();
            await RemoveItemAsync(selected);
        }

        private static async Task<Book> displayBookSelectionOptions()
        {
            var books = await GetAsync<Book>();
            for (int i = 0; i < books.Count; i++)
                Console.WriteLine($"\t\t{i} - {books[i].Tittle}");
            int.TryParse(Console.ReadLine(), out int index);
            return books[index];
        }
    }

}


