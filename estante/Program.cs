int inputPositiveInteger(string message, int? max = int.MaxValue, int? min = 1)
{
    Console.Write(message);
    int value = int.Parse(Console.ReadLine());

    while (value < min || value > max)
    {
        Console.Write($"Valor inválido, tente um valor maior que {min} {(max != int.MaxValue ? $"e menor que {max}" : "")}: ");
        value = int.Parse(Console.ReadLine());
    }

    return value;
}

int BOOKCASE_SIZE = 10;
Book[] bookcase = new Book[BOOKCASE_SIZE];

Book createBook()
{
    Book book = new Book();

    Console.Write("\nInforme o título do livro: ");
    book.SetTitle(Console.ReadLine());

    Console.Write("Informe o autor do livro: ");
    book.SetAuthor(Console.ReadLine());

    Console.Write("Informe a data de lançamento do livro: ");
    book.SetReleaseDate(DateOnly.Parse(Console.ReadLine()));

    Console.Write("Informe a editora do livro: ");
    book.SetPublisher(Console.ReadLine());

    Console.Write("Informe a edição do livro: ");
    book.SetEdition(Console.ReadLine());

    Console.Write("Informe o código ISBN do livro: ");
    book.SetISBN(Console.ReadLine());

    book.SetPages(inputPositiveInteger("Informe a quantidade de páginas do livro: ", min: 1));

    Console.WriteLine();

    return book;
}

void displayAllBooks()
{
    for (int i = 0; i < BOOKCASE_SIZE; i++)
        if (bookExists(i))
            displayBook(i);
}

void displayBook(int bookIndex)
{
    Console.WriteLine($"\n{bookIndex + 1}º LIVRO:\n{bookcase[bookIndex]}\n");
}

bool bookExists(int bookIndex)
{
    return bookcase[bookIndex] != null;
}

int quantityOfBooksToRegister = inputPositiveInteger("Digite a quantidade de livros que deseja registrar (no máximo 10): ", BOOKCASE_SIZE);

for (int i = 0; i < quantityOfBooksToRegister; i++)
    bookcase[i] = createBook();

int index = inputPositiveInteger("Digite zero para imprimir todos os livros ou o índice para imprimir um livro específico: ", BOOKCASE_SIZE, 0);

while (index > 0 && !bookExists(index - 1))
    index = inputPositiveInteger("Livro inexistente, tente outro índice ou digite 0 para imprimir todos: ", BOOKCASE_SIZE, 0);

Console.WriteLine();

if (index == 0)
    displayAllBooks();
else
    displayBook(index - 1);