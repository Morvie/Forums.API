﻿namespace Forums.Models
{
    public class ForumsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public DateTime DateOfAdded { get; set; }
        public Guid Ownership { get; set; }
        
        public bool Reported { get; set; }
        public int Amountoflikes { get; set; }
        public int MovieId { get; set; }

        public ForumsViewModel(Guid id, string title, string description, Guid ownership, DateTime dateofadded, bool reported, int amountoflikes, int movieId)
        {
            Id = id;
            Title = title;
            Description = description;
            Ownership = ownership;
            DateOfAdded = dateofadded;
            Reported = reported;
            Amountoflikes = amountoflikes;
            MovieId = movieId;
        }
        public ForumsViewModel()
        {

        }

    }
}
