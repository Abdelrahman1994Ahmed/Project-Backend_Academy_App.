using Microsoft.AspNetCore.Mvc;
using Academy.Data;
using Academy.Models;
using Academy.ViewModels;
using Microsoft.EntityFrameworkCore;
using Academy.Repos;

namespace Academy.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepo _instructorRepo;
        private readonly IDepartmentRepo _idepartmentRepo;
        private readonly ICourseRepo _icourseRepo;

        public InstructorController(IInstructorRepo iinstructorRepo, IDepartmentRepo idepartmentRepo, ICourseRepo icourseRepo)
        {
            _instructorRepo = iinstructorRepo;
            _idepartmentRepo = idepartmentRepo;
            _icourseRepo = icourseRepo;

        }

        public async Task<IActionResult> Index(string search, int? departmentFilter, int? courseFilter)
        {
            var departments = await _idepartmentRepo.GetAll();
            var courses = await _icourseRepo.GetAll();

            ViewData["Departments"] = departments;
            ViewData["Courses"] = courses;

            var instructors = await _instructorRepo.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                instructors = instructors.Where(i => i.Name.Contains(search));
            }

            if (departmentFilter.HasValue)
            {
                instructors = instructors.Where(i => i.DepId == departmentFilter);
            }

            if (courseFilter.HasValue)
            {
                instructors = instructors.Where(i => i.CourseId == courseFilter);
            }

            return View(instructors.ToList());
        }

        //public async Task<IActionResult> Index()
        //{
        //    var instList = await _instructorRepo.GetAll();
        //    return View(instList);
        //}



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Department> depList = await _idepartmentRepo.GetAll();
            IEnumerable<Course> crsList = await _icourseRepo.GetAll();
            var vm = new InstructorViewModel
            {
                Departments = depList.ToList(),
                Courses = crsList.ToList(),
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(InstructorViewModel VmInst)
        {
            await _instructorRepo.CreateInstructor(VmInst);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var curInst = await _instructorRepo.GetInstructorId(Id);
            if (curInst == null)
            {
                return View("Error");
            }

            IEnumerable<Department> depList = await _idepartmentRepo.GetAll();
            IEnumerable<Course> crsList = await _icourseRepo.GetAll();
            var vm = new InstructorViewModel
            {
                Name = curInst.Name,
                Salary = curInst.Salary,
                Address = curInst.Address,
                ImgURL = curInst.ImgURL,
                DepId = (int)curInst.DepId,
                CourseId = (int)curInst.CourseId,
                Departments = depList.ToList(),
                Courses = crsList.ToList(),
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InstructorViewModel instVM, int Id)
        {
            Instructor curInst = await _instructorRepo.GetInstructorId(Id);
            if (curInst == null)
            {
                return View("Error");
            }

            var isUpdated = await _instructorRepo.EditInstructor(instVM, Id);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(instVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var curInst = await _instructorRepo.GetInstructorId(Id);
            if (curInst == null)
            {
                return View("Error");
            }
            return View(curInst);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Instructor instructor)
        {
            await _instructorRepo.DeletInst(instructor);
            return RedirectToAction("Index");
        }

    }
}
