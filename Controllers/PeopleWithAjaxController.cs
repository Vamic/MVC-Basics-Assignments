using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class PeopleWithAjaxController : Controller
    {
        public ActionResult Index(string search = "", bool caseSensitive = false)
        {
            if (Person.PeopleList == null)
                Person.GenerateList();

            List<Person> model = Person.FilterList(Person.PeopleList, search, caseSensitive);

            if(Request.IsAjaxRequest())
            {
                return PartialView("_List", model);
            }

            return View(model);
        }

        public ActionResult Add(string name, string phone, string city)
        {
            if (Person.PeopleList != null)
            {
                if(name.Length < 2 || city.Length < 2) return new HttpStatusCodeResult(400);
                Person.PeopleList.Add(new Person(name, phone, city));
                return PartialView("_List", Person.PeopleList);
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
                return PartialView("_List", Person.PeopleList);
            }
            return new HttpStatusCodeResult(401);
        }

        public ActionResult EditStart(int ID)
        {
            if (Person.PeopleList != null)
            {
                Person found = Person.PeopleList.FirstOrDefault(item => item.ID == ID);
                if (found != null)
                {
                    return PartialView("_PartialPersonEdit", found);
                }
                return new HttpStatusCodeResult(404);
            }
            return new HttpStatusCodeResult(401);
        }

        public ActionResult Edit(Person edited)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }
            if (Person.PeopleList != null)
            {
                Person found = Person.PeopleList.FirstOrDefault(item => item.ID == edited.ID);
                if (found != null)
                {
                    found = edited;
                    return PartialView("_PartialPerson", found);
                }
                return new HttpStatusCodeResult(404);
            }
            return new HttpStatusCodeResult(401);
        }
    }
}