using LearnFest2024BookStore.Data;
using LearnFest2024BookStore.Models;

using (var context = new BookStoreContext())
{
    Author Shakespeare = new Author
    {
        Name = "William Shakespeare"
    };
    Book Hamlet = new Book
    {
        Title = "Hamlet"
    };
    Book Othello = new Book
    {
        Title = "Othello"
    };

    Shakespeare.Books.Add(Hamlet);
    Shakespeare.Books.Add(Othello);
    context.Authors.Add(Shakespeare);

    Author Christie = new Author
    {
        Name = "Agatha Christie"
    };

    Book OrientExpress = new Book
    {
        Title = "Murder on the Orient Express"
    };

    Book MurderNile = new Book
    {
        Title = "Death on the Nile"
    };

    Christie.Books.Add(OrientExpress);
    Christie.Books.Add(MurderNile);

    context.Authors.Add(Christie);

    Book GreatestBookEver = new Book { Title = "Murder of Tragedy" };
    Shakespeare.Books.Add(GreatestBookEver);
    Christie.Books.Add(GreatestBookEver);


    context.SaveChanges();
    Console.WriteLine("done");
}