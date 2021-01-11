using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteEdit       // in this model we're only going to allow the following data to be passed around and is the only data that can be edited. 
        // we still need acces to the NoteId but we need to hide/remove this from the edit views beciase we don't want people to edit this number (Html.HiddenFor)
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
