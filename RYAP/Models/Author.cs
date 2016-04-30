﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RYAP.Models
{
    public class Author
    {
        public Author()
        {
            Jokes = new HashSet<Joke>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index("IX_Author_Email", IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Index("IX_Author_Name", IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        public AuthorStatus Status { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }
    }
}