using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevenNote.Models
{
    public class NoteCreate // this allows us to have some validation for note properties -- These are the things that we'll need to capture when we create a note and save it to the database. nothing more and nothing less. Nothing else gets passed when creating a note
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}