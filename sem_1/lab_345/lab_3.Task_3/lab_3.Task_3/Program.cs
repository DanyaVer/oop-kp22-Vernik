using lab_3.Task_3.Data;

Book book = new Book(new BookData() { Content = "sdasdsd", Author = "asds" });

var book2 = book.ReleaseBooks(23);

foreach (var bo in book2)
{
	foreach (var page in bo.Pages)
	{
        Console.WriteLine(page.Content);
    }
}