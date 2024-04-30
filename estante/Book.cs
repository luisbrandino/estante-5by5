public class Book
{
    string title;
    Author[] authors;
    DateOnly releaseDate;
    string publisher;
    string edition;
    string ISBN;
    int pages;

    public Book()
    {
        
    }
    public Book(string title, DateOnly releaseDate, string publisher, string edition, string ISBN, int pages)
    {
        this.title = title;
        this.releaseDate = releaseDate;
        this.publisher = publisher;
        this.edition = edition;
        this.ISBN = ISBN;
        this.pages = pages;
    }
    public void SetAuthors(string[] authors)
    {
        this.authors = new Author[authors.Length];

        for (int i = 0; i < authors.Length; i++)
            this.authors[i] = new Author(authors[i]);
    }

    public void SetTitle(string title) { this.title = title; }

    //public void SetAuthor(string  author) { this.author = author; }

    public void SetReleaseDate(DateOnly releaseDate) { this.releaseDate = releaseDate; }

    public void SetPublisher(string publisher) { this.publisher = publisher; }

    public void SetEdition(string edition) { this.edition = edition; }

    public void SetISBN(string ISBN) { this.ISBN = ISBN; }

    public void SetPages(int pages) { this.pages = pages; }

    public override string ToString()
    {
        string book = $"Título: {this.title}\nAutor{(this.authors.Length > 1 ? "es" : "")}: ";

        for (int i = 0; i < this.authors.Length; i++)
        {
            book += this.authors[i].GetName();

            if (i == this.authors.Length - 2)
                book += " e ";
            else if (i < this.authors.Length - 1)
                book += ", ";
        }

        book += $"\nData de lançamento: {this.releaseDate}\nEditora: {this.publisher}\nEdição: {this.edition}\nISBN: {this.ISBN}\nTotal de páginas: {this.pages}";

        return book;
    }
}