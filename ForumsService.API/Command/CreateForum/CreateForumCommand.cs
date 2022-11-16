using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForumsService.Application.Command.CreateForum
{
    public class CreateForumCommand : IRequest<ForumsDTO>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Ownership { get; set; }
        public DateTime DateOfAdded { get; set; }
        public bool Reported { get; set; }
        public int Amountoflikes { get; set; }
        public int MovieId { get; set; }

        [JsonConstructor]
        public CreateForumCommand(string title, string description, Guid ownership, DateTime dateofadded, bool reported, int amountoflikes, int movieId)
        {
            Title = title;
            Description = description;
            Ownership = ownership;
            DateOfAdded = dateofadded;
            Reported = reported;
            Amountoflikes = amountoflikes;
            MovieId = movieId;
        }
    }
}
