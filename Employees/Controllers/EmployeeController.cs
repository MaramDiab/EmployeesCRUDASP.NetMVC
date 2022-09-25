using Employees.Data;
using Employees.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        //only get data no set
        private readonly ApplicationDBContext _db;
        public EmployeeController(ApplicationDBContext db) { _db = db; }
        //retrive list of employees
        public IActionResult Index()
        {
            //retrieve list of Employee
            IEnumerable<Employee> EmployeeList = _db.employees;



            //IEnumerable<Users> USers = _db.users;
            //ViewData["users"] = USers;
            return View(EmployeeList);



        }
        public IActionResult AddEmployee()
        {
            return View();
        }
    
        //post [create]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(Employee obj)

        {
           

            //check if our model is vaLid(name is required cant be null)
            if (ModelState.IsValid)
            {
                //add the category to our data base it wont be pushed untill we saved changes
                _db.employees.Add(obj);

                _db.SaveChanges();
                //redirect to the index action to view the category list
                TempData["success"] = "data created sucessfully";
                return RedirectToAction("Index", "Employee");
                //must add the controller name if we directed to an action within anothe controller
            }
            return View(obj);


        }

        public ActionResult ModalPopUp()
        {
            return View();
        }

        //post [create]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModalPopUp(Employee obj)

        {


            //check if our model is vaLid(name is required cant be null)
            if (ModelState.IsValid)
            {
                //add the category to our data base it wont be pushed untill we saved changes
                _db.employees.Add(obj);

                _db.SaveChanges();
                //redirect to the index action to view the category list
                TempData["success"] = "data created sucessfully";
                return RedirectToAction("Index", "Employee");
                //must add the controller name if we directed to an action within anothe controller
            }
            return View(obj);


        }




        //Get 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            //retrive records
            var CategoryfromDb = _db.employees.Find(id);//find the element based on the id

            //var  CategoryfromDbFirst= _db.Categories.FirstOrDefault(c => c.Id == id);//returns the default value for the type
            //var CategoryfromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);//returns the default value for the type (e.g. default for int is 0)
            if (CategoryfromDb == null)
            {
                return NotFound();
            }
            return View(CategoryfromDb);
            //If your result set returns many records:
            //SingleOrDefault throws an exception
            //FirstOrDefault returns the first record
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)

        {
            //check if our model is vaLid(name is required cant be null)
            if (ModelState.IsValid)
            {
                //update the category to our data base it wont be pushed untill we saved changes
                _db.employees.Update(obj);
                _db.SaveChanges();
                //redirect to the index action to view the category list
                TempData["success"] = "data updated sucessfully";
                return RedirectToAction("Index", "Employee");
                //must add the controller name if we directed to an action within anothe controller
            }
            return View(obj);


        }


        //Get 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            //retrive records
            var EmployeefromDb = _db.employees

                .Find(id);//find the element based on the id

            if (EmployeefromDb == null)
            {
                return NotFound();
            }
            return View(EmployeefromDb);

        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)

        {
            var deletedObj = _db.employees.Find(id);
            if (deletedObj == null)
            {
                return NotFound();
            }
            _db.employees
                .Remove(deletedObj);
            _db.SaveChanges();
            TempData["success"] = "data deleted sucessfully";
            return RedirectToAction("Index", "Category");




        }














    }
}
