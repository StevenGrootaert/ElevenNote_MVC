using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class NoteService   // the service layer is how ou application interacts with the database -- the service here will oush and pull notes from the database
                               // we added references for the MOdels and the Data layers so that we can use models and properties from those projects
                               // ?? Is this the same thing as when we added the save changes and View _bd.Products.ToList and OrderBy prod Id in the database in the ProductController for general store ??
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate model) // this will create an instance of Note. 
        {
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =     //is this SQL?
                    ctx
                        .Notes      // e is for entity
                        .Where(e => e.OwnerId == _userId)
                        .Select(e => new NoteListItem
                        {
                            NoteId = e.NoteId,
                            Title = e.Title,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
