namespace BookStorage.Application.Dtos
{
    public class BookReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
