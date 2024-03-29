namespace MyBooks.Data.Models
{
    public class AuthorVM
    {
        public string FullName { get; set; }

    }

    public class AuthorWithBooksVM
    {
        public string FullName { get; set; }

        public List<String> BookTitles { get; set; }

    }


}
