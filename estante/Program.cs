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

void waitForAnyKey()
{
    Console.WriteLine("Pressione qualquer tecla para continuar.");
    Console.ReadKey();
}

int MAX_BOOKS_AUTHOR = 3;
int BOOKCASE_SIZE = 10;
Book[] bookcase = new Book[BOOKCASE_SIZE];
int lastBookIndex = 0;

Book createBook()
{
    Book book = new Book();

    Console.Write("\nInforme o título do livro: ");
    book.SetTitle(Console.ReadLine());

    int totalAuthors = inputPositiveInteger("Informe a quantidade de autores (máximo 3): ", min: 1, max: MAX_BOOKS_AUTHOR);
    string[] authors = new string[totalAuthors];

    for (int i = 0; i < totalAuthors; i++)
    {
        Console.Write($"Informe o nome do {i + 1}º autor: ");
        authors[i] = Console.ReadLine();
    }

    book.SetAuthors(authors);

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

bool bookExists(int bookIndex)
{
    return bookcase[bookIndex] != null;
}

bool isBookcaseEmpty()
{
    return !bookExists(0);
}

void displayAllBooks()
{
    Console.Clear();

    if (isBookcaseEmpty())
    {
        Console.WriteLine("Estante está vazia.\n");
        waitForAnyKey();

        return;
    }

    for (int i = 0; i < BOOKCASE_SIZE; i++)
    {
        if (!bookExists(i))
            break;

        displayBook(i);
    }

    waitForAnyKey();
}

void displayBook(int bookIndex)
{
    Console.WriteLine($"\n{bookIndex + 1}º LIVRO:\n{bookcase[bookIndex]}\n");
}

void addBooksToBookcase()
{
    Console.Clear();

    int quantityOfBooksToRegister = inputPositiveInteger($"Digite a quantidade de livros que deseja registrar (espaço para mais {BOOKCASE_SIZE - lastBookIndex}): ", max: BOOKCASE_SIZE - lastBookIndex);

    for (int i = 0; i < quantityOfBooksToRegister; i++)
        bookcase[lastBookIndex++] = createBook();
}

void searchSpecificBook()
{
    Console.Clear();

    if (isBookcaseEmpty())
    {
        Console.WriteLine("Estante está vazia.\n");
        waitForAnyKey();

        return;
    }

    int index = inputPositiveInteger("Digite o índice para imprimir um livro específico: ", BOOKCASE_SIZE, 1);

    while (!bookExists(index - 1))
        index = inputPositiveInteger("Livro inexistente, tente outro índice para imprimir todos: ", BOOKCASE_SIZE, 1);

    displayBook(index - 1);
    waitForAnyKey();
}

int selectOperationMenu()
{
    Console.Clear();
    Console.WriteLine("[ 1 ] Adicionar livros à estante\n[ 2 ] Imprimir estante\n[ 3 ] Imprimir livro específico\n[ 4 ] Sair");
    return inputPositiveInteger("Escolha sua opção: ", max: 4, min: 1);
}

while (true)
{
    int operation = selectOperationMenu();

    if (operation == 1)
        addBooksToBookcase();
    else if (operation == 2)
        displayAllBooks();
    else if (operation == 3)
        searchSpecificBook();
    else
        break;
}