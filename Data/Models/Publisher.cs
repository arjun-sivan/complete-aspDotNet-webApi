namespace MyBooks.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //navigation Property
        public List<Book> Books { get; set; }
    }
}
