using lab_3.Task_3.Data;
using lab_3.Task_3.Data2;


Book book = new Book(new BookData() { Content = "sdasdsd", Author = "asds" });

var book2 = book.ReleaseBooks(23);

foreach (var bo in book2)
{
	foreach (var page in bo.Pages)
	{
        Console.WriteLine(page.Content);
    }
}