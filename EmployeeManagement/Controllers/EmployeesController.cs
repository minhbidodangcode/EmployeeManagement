using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        // Danh sách nhân viên mẫu (lưu trong bộ nhớ)
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FullName = "Nguyen Van A", Gender = "Male", Phone="0123456789", Email="a@gmail.com", Salary=1000, Status=true },
            new Employee { Id = 2, FullName = "Tran Thi B", Gender = "Female", Phone="0987654321", Email="b@gmail.com", Salary=1200, Status=false }
        };

        // GET: Employees
        public IActionResult Index()
        {
            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
                employees.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var index = employees.FindIndex(e => e.Id == id);
                if (index >= 0)
                {
                    employees[index] = employee;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Details/5
        public IActionResult Details(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }
    }
}
