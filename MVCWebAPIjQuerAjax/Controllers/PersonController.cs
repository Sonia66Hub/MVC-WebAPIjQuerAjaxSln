using MVCWebAPIjQuerAjax.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebAPIjQuerAjax.Controllers
{
    public class PersonController : ApiController
    {
        private readonly AppDbContext db=new AppDbContext();
        public IQueryable<Person> GetPersonList()
        { 
            return db.Persons;
        }
        public IHttpActionResult GetPersonById (int id)
        {
            Person person=db.Persons.SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        public IHttpActionResult PostPerson(Person person)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           db.Persons.Add(person);
            db.SaveChanges();
            return Ok(person);
        }
        public IHttpActionResult DeletePerson(int id)
        {

            Person person = db.Persons.SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            db.Persons.Remove(person);
            db.SaveChanges();
            return Ok(person);
        }
        public IHttpActionResult PutPerson(int id, Person person)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != person.Id)
            {
                return BadRequest();
            }
            db.Entry(person).State=System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!PersonExists(id))
                {
                    return NotFound();
                }
            }
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        private bool PersonExists(int id)
        {
           return db.Persons.Count(p => p.Id == id) > 0;
        }
    }
}
