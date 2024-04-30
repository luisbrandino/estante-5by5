public class Book
{
    string title;
    string author;
    DateOnly releaseDate;
    string publisher;
    string edition;
    string ISBN;
    int pages;

    public Book()
    {
        
    }
    public Book(string title, string author, DateOnly releaseDate, string publisher, string edition, string ISBN, int pages)
    {
        this.title = title;
        this.author = author;
        this.releaseDate = releaseDate;
        this.publisher = publisher;
        this.edition = edition;
        this.ISBN = ISBN;
        this.pages = pages;
    }

    public void SetTitle(string title) { this.title = title; }

    public void SetAuthor(string  author) { this.author = author; }

    public void SetReleaseDate(DateOnly releaseDate) { this.releaseDate = releaseDate; }

    public void SetPublisher(string publisher) { this.publisher = publisher; }

    public void SetEdition(string edition) { this.edition = edition; }

    public void SetISBN(string ISBN) { this.ISBN = ISBN; }

    public void SetPages(int pages) { this.pages = pages; }

    public override string ToString()
    {
        return $"Título: {this.title}\nAutor: {this.author}\nData de lançamento: {this.releaseDate}\nEditora: {this.publisher}\nEdição: {this.edition}\nISBN: {this.ISBN}\nTotal de páginas: {this.pages}";
    }
}