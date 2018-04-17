using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            if (Person.PeopleList == null)
                Person.GenerateList();

            return View(new Person());
        }

        public ActionResult Add(string name, string phone, string city)
        {
            if (Person.PeopleList != null)
            {
                if(name.Length < 2 || city.Length < 2) return new HttpStatusCodeResult(400);
                Person.PeopleList.Add(new Person(name, phone, city));
                return View("Index", new Person());
            }
            return new HttpStatusCodeResult(401);
        }

        public ActionResult Delete(int ID)
        {
            if (Person.PeopleList != null)
            {
                Person found = Person.PeopleList.FirstOrDefault(item => item.ID == ID);
                if (found != null)
                {
                    Person.PeopleList.Remove(found);
                }
                return View("Index", new Person());
            }
            return new HttpStatusCodeResult(401);
        }
    }
}