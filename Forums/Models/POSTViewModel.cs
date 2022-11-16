namespace Forums.Models
{
    public class POSTViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Dateofadded { get; set; }
        public Guid OwnerId { get; set; }

        public bool Reported { get; set; }
        public int Amountoflikes { get; set; }
        public int MovieId { get; set; }

        public POSTViewModel(string title, string description, Guid ownership, DateTime dateofadded, bool reported, int amountoflikes, int movieId)
        {
            Title = title;
            Description = description;
            OwnerId = ownership;
            Dateofadded = dateofadded;
            Reported = reported;
            Amountoflikes = amountoflikes;
            MovieId = movieId;
        }
        public POSTViewModel()
        {

        }
    }
}
