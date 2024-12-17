using Microsoft.AspNetCore.Mvc;
using Academy.Data;
using Microsoft.EntityFrameworkCore;
using Academy.Models;
using Academy.ViewModels;
using Academy.Repos;
using Microsoft.AspNetCore.Authentication;

namespace Academy.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepo _itraineeRepo;
        private readonly IDepartmentRepo _idepartmentRepo;
        private readonly ICourseRepo _icourseRepo;


        public TraineeController(ITraineeRepo itraineeRepo, IDepartmentRepo idepartmentRepo, ICourseRepo icourseRepo)
        {
            _itraineeRepo = itraineeRepo;
            _idepartmentRepo = idepartmentRepo;
            _icourseRepo = icourseRepo;

        }
        public async Task<IActionResult> Index(string search, int? departmentFilter, int? courseFilter)
        {
            var departments = await _idepartmentRepo.GetAll();
            var courses = await _icourseRepo.GetAll();

            ViewData["Departments"] = departments;
            ViewData["Courses"] = courses;

            var trainees = await _itraineeRepo.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                trainees = trainees.Where(i => i.Name.Contains(search));
            }

            if (departmentFilter.HasValue)
            {
                trainees = trainees.Where(i => i.DepId == departmentFilter);
            }

            if (courseFilter.HasValue)
            {
                trainees = trainees.Where(i => i.CourseId == courseFilter);
            }

            return View(trainees.ToList());
        }


        //public async Task<IActionResult> Index()
        //{
        //    var traineeList = await _itraineeRepo.GetAll();
        //    return View(traineeList);
        //}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Department> depList = await _idepartmentRepo.GetAll();
            IEnumerable<Course> crsList = await _icourseRepo.GetAll();
            var vm = new TraineeViewModel
            {
                Departments = depList.ToList(),
                Courses = crsList.ToList(),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TraineeViewModel Vmtrainee)
        {
            await _itraineeRepo.CreateTrainee(Vmtrainee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var curTrainee = await _itraineeRepo.GetTraineeId(Id);
            if (curTrainee == null)
            {
                return View("Error");
            }

            IEnumerable<Department> depList = await _idepartmentRepo.GetAll();
            IEnumerable<Course> crsList = await _icourseRepo.GetAll();
            var vm = new TraineeViewModel
            {
                Name = curTrainee.Name,
                Grade = curTrainee.Grade,
                Address = curTrainee.Address,
                ImgURL = curTrainee.ImageURL,
                DepId = (int)curTrainee.DepId,
                CourseId = (int)curTrainee.CourseId,
                Departments = depList.ToList(),
                Courses = crsList.ToList(),
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var curTrainee = await _itraineeRepo.GetTraineeId(Id);
            if (curTrainee == null)
            {
                return View("Error");
            }

            IEnumerable<Department> depList = await _idepartmentRepo.GetAll();
            IEnumerable<Course> crsList = await _icourseRepo.GetAll();
            var vm = new TraineeViewModel
            {
                Name = curTrainee.Name,
                Grade = curTrainee.Grade,
                Address = curTrainee.Address,
                ImgURL = curTrainee.ImageURL,
                DepId = (int)curTrainee.DepId,
                CourseId = (int)curTrainee.CourseId,
                Departments = depList.ToList(),
                Courses = crsList.ToList(),
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TraineeViewModel traineeVM,int Id)
        {
            Trainee curTrainee = await _itraineeRepo.GetTraineeId(Id);
            if (curTrainee == null)
            {
                return View("Error");
            }

            var isUpdated = await _itraineeRepo.EditTrainee(traineeVM,Id);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(traineeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var curTrainee = await _itraineeRepo.GetTraineeId(Id);
            if (curTrainee == null)
            {
                return View("Error");
            }
            return View(curTrainee);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Trainee trainee)
        {
            await _itraineeRepo.DeletTrainee(trainee);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> logOut()
        {
            // here
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }
    }
}
