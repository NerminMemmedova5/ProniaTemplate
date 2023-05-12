namespace ProniaTemplate.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public List<Person> Persons { get; set; }

    }
}
