using TestTaskConsoleApp.Models;
using TestTaskConsoleApp.Services;

namespace TestTaskConsoleApp
{
    public class Program
    {
        static async Task Main()
        {
            try
            {
                Console.WriteLine("Application started.");
                BooksJsonModel booksModel = await BookService.ExtractBooksData();

                if (booksModel.Books != null && booksModel.Books != null)
                {
                    List<Book> filteredBooks = BookService.FilterBooksByStatesAndParent(booksModel.Books);

                    if(filteredBooks.Count > 0)
                    {
                        Console.WriteLine("Books filtered by New Jersey or Colorado with parent not null.");

                        var groupedBooks = BookService.GroupAndOrderBooksByParentName(filteredBooks);
                        Console.WriteLine("Books grouped by and ordered by parent name.");

                        await BookService.SaveGroupedBooksToFile(groupedBooks, "result.txt");
                        Console.WriteLine("File result.txt created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("There is no books matching criteria. Therefore no result.txt file is created.");
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(booksModel));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
                throw;
            }
        }
    }
}