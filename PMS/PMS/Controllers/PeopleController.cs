using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.ViewModels;
using System.Data.Entity;

namespace PMS.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People

        ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }


        public ActionResult Index()
        {
            var list = new List<Person>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.People.Include( tt => tt.RelationType ).ToList();
            }
            return View(list);
        }




        public ActionResult CreateOrEdit(int? id)
        {
            var model = new CreateOrEditViewModel();
            if(id.HasValue)
            {
                model = new CreateOrEditViewModel
                {
                    Person = _context.People.SingleOrDefault( item => item.Id == id ),
                    RelationTypes = _context.relationTypes.ToList()
                };

            }
            else
            {
                model = new CreateOrEditViewModel
                {
                    Person = null,
                    RelationTypes = _context.relationTypes.ToList()
                };
            }
            
            return View(model);
        }



        [HttpPost]
        public ActionResult CreateOrEdit(CreateOrEditViewModel viewModel)
        {

            if (viewModel.Person.Id == 0 )
            {
               
                _context.People.Add(viewModel.Person);
                
            }
            else
                {
                _context.Entry(viewModel.Person).State = System.Data.Entity.EntityState.Modified;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "People", new { @q = "succcess" });
        }
    }
}