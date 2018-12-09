using PMS.Dtos;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PMS.Controllers.api
{
    public class PeopleController : ApiController
    {
        private ApplicationDbContext _context;

        public PeopleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<PersonDto> GetAllPeople()
        {

            //return _context.People;
            
        }

        public PersonDto GetPerson(int id)
        {
            
            var person = _context.People.SingleOrDefault(item => item.Id == id);

            if (person == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

           // return person;

        }

        public PersonDto Post(PersonDto person)
        {
            if(! ModelState.IsValid )
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
            _context.People.Add(person);
            _context.SaveChanges();
            return person;

        }


        public int Put(int id, PersonDto person)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var personInDb = _context.People.SingleOrDefault(it => it.Id == id);

            if (personInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            personInDb.Name = person.Name;
            personInDb.Mobile = person.Mobile;
            personInDb.Email = person.Email;
            personInDb.RelationTypeId= person.RelationTypeId;
            personInDb.State = person.State;
            personInDb.Address = person.Address;
            personInDb.Country = person.Country;
            _context.People.Add(person);
            _context.SaveChanges();
            return person.Id;

        }


        public int Delete(int id)
        {
            
            var personInDb = _context.People.SingleOrDefault(it => it.Id == id);

            if (personInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.People.Remove(personInDb);
            _context.SaveChanges();
            return personInDb.Id;

        }



    }
}
