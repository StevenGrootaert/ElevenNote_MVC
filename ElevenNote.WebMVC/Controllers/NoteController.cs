using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        // GET: Note/index
        public ActionResult Index()
        {
            var model = new NoteListItem[0]; //  we are initializing a new instance of the NoteListItem as an IEnumerable with the [0] syntax.
            return View(model);
        }

        // GET: Note/Create
        public ActionResult Create()
        {
            return View(); // we're returning the view model that serves the create interface to input the information used to actually create the note
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (ModelState.IsValid)
            {
                // save to DB We need a serivce
            }
            return View(model);
        }
    }
}