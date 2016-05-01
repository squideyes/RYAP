using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RYAP.Website.Models
{
    public class Joke
    {
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        [Index("IX_Joke_Question", IsUnique = true)]
        public string Question { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Answer { get; set; }

        [Required]
        [Index("IX_Joke_AddedOn")]
        public DateTime AddedOn { get; set; }

        [Required]
        public DateTime UpdatedOn { get; set; }

        [Required]
        public JokeStatus Status { get; set; }

        public virtual Author Author { get; set; }
    }
}