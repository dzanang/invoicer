using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
    }
}
