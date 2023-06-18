using Newtonsoft.Json;
using TestTaskConsoleApp.Constants;
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

                BooksRootModel booksModel = await BookService.ExtractBooksData(Urls.Api);
                Console.WriteLine("Books data extracted successfully.");

                if (booksModel.Books != null && booksModel.Books != null)
                {
                    List<Book> filteredBooks = BookService.FilterBooksByStatesAndParent(booksModel.Books);

                    if(filteredBooks.Count > 0)
                    {
                        Console.WriteLine("Books from 'New Jersey' or 'Colorado' with 'parent name' value not null are filtered successfully.");

                        var groupedBooks = BookService.GroupAndOrderBooksByParentName(filteredBooks);
                        Console.WriteLine("Books grouped and ordered by 'parent name'.");

                        await BookService.SaveGroupedBooksToFile(groupedBooks, "result.txt");
                        Console.WriteLine("File 'result.txt' created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("There are no books matching criteria. Therefore no 'result.txt' file is created.");
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(booksModel));
                }

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"ArgumentNullException occured: {ane.Message}");
            }
            catch (JsonSerializationException jse)
            {
                Console.WriteLine($"JsonSerializationException occured: {jse.Message}");
            }
            catch (HttpRequestException he)
            {
                Console.WriteLine($"HttpRequestException occured: {he.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
            }
        }
    }
}