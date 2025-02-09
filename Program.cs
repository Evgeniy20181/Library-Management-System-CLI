/*using System;
using System.Collections.Generic;
using System.Data.SQLite;

class Program
{
    static string connectionString = "Data Source=library.db;Version=3;";
    
    static void Main()
    {
        InitializeDatabase();
        
       while (true)
        {
            Console.WriteLine("\nBibliotekssystem:");
            Console.WriteLine("1. Legg til bok");
            Console.WriteLine("2. Søk etter bøker");
            Console.WriteLine("3. Slett bok");
            Console.WriteLine("4. Oppdater bok");
            Console.WriteLine("5. Opprett leseliste");
            Console.WriteLine("6. Vis leselister");
            Console.WriteLine("7. Avslutt");
            Console.Write("Velg et alternativ: ");
            
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddBook(); break;
                case "2": SearchBooks(); break;
                case "3": DeleteBook(); break;
                case "4": UpdateBook(); break;
                case "5": CreateReadingList(); break;
                case "6": ViewReadingLists(); break;
                case "7": return;
                default: Console.WriteLine("Ugyldig valg. Prøv igjen."); break;
            }
        }
    }

    static void InitializeDatabase()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = @"CREATE TABLE IF NOT EXISTS books (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                title TEXT NOT NULL,
                                genre TEXT NOT NULL,
                                keywords TEXT NOT NULL
                            );
                            CREATE TABLE IF NOT EXISTS reading_lists (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                name TEXT NOT NULL,
                                occasion TEXT NOT NULL
                            );
                            CREATE TABLE IF NOT EXISTS reading_list_books (
                                reading_list_id INTEGER,
                                book_id INTEGER,
                                FOREIGN KEY(reading_list_id) REFERENCES reading_lists(id),
                                FOREIGN KEY(book_id) REFERENCES books(id)
                            );";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Tittel: ");
        string? title = Console.ReadLine();
        Console.Write("Sjanger: ");
        string? genre = Console.ReadLine();
        Console.Write("Stikkord (kommaseparert): ");
        string? keywords = Console.ReadLine();
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO books (title, genre, keywords) VALUES (@title, @genre, @keywords)";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@genre", genre);
                command.Parameters.AddWithValue("@keywords", keywords);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Bok lagt til!");
    }

    static void CreateReadingList()
    {
        Console.Write("Navn på leseliste: ");
        string? name = Console.ReadLine();
        Console.Write("Anledning: ");
        string? occasion = Console.ReadLine();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO reading_lists (name, occasion) VALUES (@name, @occasion)";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@occasion", occasion);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Leseliste opprettet!");
    }

    static void ViewReadingLists()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM reading_lists";
            using (var command = new SQLiteCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}: {reader["name"]} - {reader["occasion"]}");
                    }
                }
            }
        }
    }

    static void SearchBooks()
    {
        Console.Write("Søk etter sjanger eller stikkord: ");
        string? search = Console.ReadLine();
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM books WHERE genre LIKE @search OR keywords LIKE @search";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@search", "%" + search + "%");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}: {reader["title"]} ({reader["genre"]}) - {reader["keywords"]}");
                    }
                }
            }
        }
    }

    static void DeleteBook()
    {
        Console.Write("Skriv inn ID på boken som skal slettes: ");
        int id = int.Parse(Console.ReadLine()??"");
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "DELETE FROM books WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Bok slettet!");
    }

    static void UpdateBook()
    {
        Console.Write("Skriv inn ID på boken som skal oppdateres: ");
        int id = int.Parse(Console.ReadLine()??"");
        Console.Write("Ny tittel: ");
        string? newTitle = Console.ReadLine();
        Console.Write("Ny sjanger: ");
        string? newGenre = Console.ReadLine();
        Console.Write("Nye stikkord (kommaseparert): ");
        string? newKeywords = Console.ReadLine();
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "UPDATE books SET title = @title, genre = @genre, keywords = @keywords WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@title", newTitle);
                command.Parameters.AddWithValue("@genre", newGenre);
                command.Parameters.AddWithValue("@keywords", newKeywords);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Bok oppdatert!");
    }
}
*/
using System.Data.SQLite;

class Program
{
    static string connectionString = "Data Source=library.db;Version=3;";
    
    static void Main()
    {
        InitializeDatabase();
        
        while (true)
        {
            Console.WriteLine("\nBibliotekssystem:");
            Console.WriteLine("1. Legg til bok");
            Console.WriteLine("2. Søk etter bøker");
            Console.WriteLine("3. Slett bok");
            Console.WriteLine("4. Oppdater bok");
            Console.WriteLine("5. Opprett leseliste");
            Console.WriteLine("6. Legg bøker til i leseliste");
            Console.WriteLine("7. Vis leselister");
            Console.WriteLine("8. Vise bøker i leseliste");
            Console.WriteLine("9. Delete leseliste");
            Console.WriteLine("10. Avslutt");
            Console.Write("Velg et alternativ: ");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    try { AddBook(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "2":
                    try { SearchBooks(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "3":
                    try { DeleteBook(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "4":
                    try { UpdateBook(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "5":
                    try { CreateReadingList(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "6":
                    try { AddBooksToReadingList(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "7":
                    try { ViewReadingLists(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "8":
                    try { ViewBooksInReadingList(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "9":
                    try { DeleteReadingList(); } catch (Exception ex) { Console.WriteLine($"Feil: {ex.Message}"); }
                    break;
                case "10":
                    return;
                default:
                    Console.WriteLine("Ugyldig valg. Prøv igjen.");
                    break;
            }
    }
}

    static void InitializeDatabase()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = @"CREATE TABLE IF NOT EXISTS books (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                title TEXT NOT NULL,
                                genre TEXT NOT NULL,
                                keywords TEXT NOT NULL
                            );
                            CREATE TABLE IF NOT EXISTS reading_lists (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                name TEXT NOT NULL,
                                occasion TEXT NOT NULL
                            );
                            CREATE TABLE IF NOT EXISTS reading_list_books (
                                reading_list_id INTEGER,
                                book_id INTEGER,
                                FOREIGN KEY(reading_list_id) REFERENCES reading_lists(id),
                                FOREIGN KEY(book_id) REFERENCES books(id)
                            );";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Tittel: ");
        string? title = Console.ReadLine();
        Console.Write("Sjanger: ");
        string? genre = Console.ReadLine();
        Console.Write("Stikkord (kommaseparert): ");
        string? keywords = Console.ReadLine();
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO books (title, genre, keywords) VALUES (@title, @genre, @keywords)";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@genre", genre);
                command.Parameters.AddWithValue("@keywords", keywords);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Bok lagt til!");
    }

    static void CreateReadingList()
    {
        Console.Write("Navn på leseliste: ");
        string? name = Console.ReadLine();
        Console.Write("Anledning: ");
        string? occasion = Console.ReadLine();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO reading_lists (name, occasion) VALUES (@name, @occasion)";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@occasion", occasion);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Leseliste opprettet!");
    }

    static void ViewBooksInReadingList()
    {
        Console.Write("Skriv inn ID på leselisten du vil se bøker for: ");
        int readingListId = int.Parse(Console.ReadLine() ?? "");

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = @"SELECT books.id, books.title, books.genre, books.keywords 
                           FROM books 
                           JOIN reading_list_books ON books.id = reading_list_books.book_id 
                           WHERE reading_list_books.reading_list_id = @readingListId";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@readingListId", readingListId);
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("Bøker i leselisten:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}: {reader["title"]} ({reader["genre"]}) - {reader["keywords"]}");
                    }
                }
            }
        }
    }
    static void DeleteReadingList()
    {
        Console.Write("Skriv inn ID på leselisten som skal slettes: ");
        int id = int.Parse(Console.ReadLine() ?? "");

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "DELETE FROM reading_lists WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }

            // Slett også tilknyttede bøker i leselisten
            string deleteBooksSql = "DELETE FROM reading_list_books WHERE reading_list_id = @id";
            using (var command = new SQLiteCommand(deleteBooksSql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Leseliste slettet!");
    }
    static void AddBooksToReadingList()
    {
        Console.Write("Skriv inn ID på leselisten du vil legge bøker til: ");
        int readingListId = int.Parse(Console.ReadLine() ?? "");
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Hent alle bøker fra databasen
            string sql = "SELECT * FROM books";
            using (var command = new SQLiteCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("Bøker tilgjengelig:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}: {reader["title"]} ({reader["genre"]}) - {reader["keywords"]}");
                    }
                }
            }

            // Legg til bøker i leselisten
            List<int> bookIds = new List<int>();
            while (true)
            {
                Console.Write("Skriv inn bok-ID for å legge til i leselisten (eller 'done' for å fullføre): ");
                string? input = Console.ReadLine();
                if (input?.ToLower() == "done") break;

                if (int.TryParse(input, out int bookId))
                {
                    bookIds.Add(bookId);
                }
                else
                {
                    Console.WriteLine("Ugyldig bok-ID. Vennligst prøv igjen.");
                }
            }

            // Sjekk at sjangerne er unike og at det eksisterer felles stikkord
            var selectedBooks = new List<(int Id, string Genre, List<string> Keywords)>();
            foreach (var id in bookIds)
            {
                using (var cmd = new SQLiteCommand("SELECT genre, keywords FROM books WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string genre = reader["genre"]?.ToString() ?? string.Empty;
                            List<string> keywords = reader["keywords"]?.ToString()?.Split(',').ToList() ?? new List<string>();
                            selectedBooks.Add((id, genre, keywords));
                        }
                    }
                }
            }

            // Sjekk unike sjangre
            
            var uniqueGenres = selectedBooks.Select(b => b.Genre).Distinct().ToList();
            Console.WriteLine(string.Join(", ", uniqueGenres));
            if (uniqueGenres.Count != selectedBooks.Count)
            {
                Console.WriteLine("Feil: Alle bøker i leselisten må ha ulike sjangre.");
                return;
            }

            // Finn felles stikkord
            var commonKeywords = selectedBooks.Select(b => b.Keywords).Aggregate((prev, next) => new List<string>(prev.Intersect(next)));
            if (commonKeywords.Count == 0)
            {
                Console.WriteLine("Feil: Alle bøker må dele minst ett felles tematisk stikkord.");
                return;
            }

            // Legg bøker til i leselisten
            foreach (var bookId in bookIds)
            {
                string insertSql = "INSERT INTO reading_list_books (reading_list_id, book_id) VALUES (@readingListId, @bookId)";
                using (var cmd = new SQLiteCommand(insertSql, connection))
                {
                    cmd.Parameters.AddWithValue("@readingListId", readingListId);
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Bøker lagt til i leselisten!");
        }
    }

    static void ViewReadingLists()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM reading_lists";
            using (var command = new SQLiteCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}: {reader["name"]} - {reader["occasion"]}");
                    }
                }
            }
        }
    }

    static void SearchBooks()
    {
        Console.Write("Søk etter sjanger eller stikkord: ");
        string? search = Console.ReadLine();
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM books WHERE genre LIKE @search OR keywords LIKE @search";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@search", "%" + search + "%");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}: {reader["title"]} ({reader["genre"]}) - {reader["keywords"]}");
                    }
                }
            }
        }
    }

    static void DeleteBook()
    {
        Console.Write("Skriv inn ID på boken som skal slettes: ");
        int id = int.Parse(Console.ReadLine()??"");
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "DELETE FROM books WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Bok slettet!");
    }

    static void UpdateBook()
    {
        Console.Write("Skriv inn ID på boken som skal oppdateres: ");
        int id = int.Parse(Console.ReadLine()??"");
        Console.Write("Ny tittel: ");
        string? newTitle = Console.ReadLine();
        Console.Write("Ny sjanger: ");
        string? newGenre = Console.ReadLine();
        Console.Write("Nye stikkord (kommaseparert): ");
        string? newKeywords = Console.ReadLine();
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "UPDATE books SET title = @title, genre = @genre, keywords = @keywords WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@title", newTitle);
                command.Parameters.AddWithValue("@genre", newGenre);
                command.Parameters.AddWithValue("@keywords", newKeywords);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Bok oppdatert!");
    }
}