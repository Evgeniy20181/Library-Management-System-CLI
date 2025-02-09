# Library Management System

This project is a simple Library Management System built using C#. The system allows users to manage books, including adding, searching, updating, and deleting books. It also provides a mechanism for creating reading lists, adding books to those lists, and ensuring the integrity of the lists with specific rules for book genres and keywords.

## Features

- **Add Book**: Users can add books with title, genre, and keywords.
- **Search Books**: Users can search for books by genre or keywords.
- **Update Book**: Users can update the details of existing books.
- **Delete Book**: Users can delete books from the library.
- **Create Reading List**: Users can create a reading list with an occasion.
- **Add Books to Reading List**: Users can manually add books to a reading list while ensuring all genres are different and that there’s at least one common keyword amongst the selected books.
- **View Reading Lists**: Users can view all created reading lists.

## Technologies Used

- C#
- SQLite for database management

## Getting Started

### Prerequisites

Make sure you have the following installed:

- .NET SDK
- SQLite

## Usage

After running the application, you will be presented with a simple command-line interface. Follow the prompts to:

- Add new books or reading lists.
- Search for books by genre or keywords.
- Update or delete existing books.
- Manage reading lists and add books to them.

## Contributing

Contributions are welcome! If you would like to contribute to this project, please fork the repository and create a pull request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/NewFeature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/NewFeature`)
5. Open a pull request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Thank you to everyone who contributed to the development of this project.
- Special thanks to the open-source community for their invaluable resources and support.
