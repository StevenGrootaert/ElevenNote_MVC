using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
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
        public ActionResult Index() // right click to add a view -- click on Index and CTRL + M+G takes you to the thing
        {
            //var model = new NoteListItem[0]; //  we are initializing a new instance of the NoteListItem as an IEnumerable with the [0] syntax. -- ** we modified this with the following 3 lines of code in 6.02 when we added a service **
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new NoteService(userId);
            var service = CreateNoteService();
            // ^^then we refactored in step 7.01 ^^
            var model = service.GetNotes();
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
            if (!ModelState.IsValid) return View(model);       // I missed this exclimatin point ! and that turns it to a if modelstate is not valid -  save to DB We need a serivce? nope this code is for when the model view is NOT valid

            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                //ViewBag.SaveResult = "Your note ws created";
                TempData["SaveResult"] = "Your note was created."; // changed to a TempData in 7.02 TempData removes information after it's been accessed
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Note could not be created.");
                return View(model);
            
            // added in 6.02 -  method makes sure the model is valid, grabs the current userId, calls on CreateNote, and returns the user back to the index view.
            //var userId = Guid.Parse(User.Identity.GetUserId()); -- this gets refactored (edit>refactor>extract method)
            //var service = new NoteService(userId); -- this got refactored
            //var service = CreateNoteService();  // changed NoteService to var Do not try to instantiate a Service inside of the constructor. The MVC framework does not have the data available that may be needed.

            //service.CreateNote(model);

            //return RedirectToAction("Index");
        }

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            return service;
        }
    }
}