using Microsoft.AspNetCore.Mvc;
using UOWW.Service.DTO.PMS;
using UOWW.Service.Service;

namespace UOW1
{

    public class ProjectController : Controller
    {
        private readonly ProjectService _service;

        public ProjectController(ProjectService service)
        {
            _service = service;
        }

        // GET: ProjectController
        public async Task<ActionResult> Index()
        {
            var projects = await _service.GetProjectsAsync();
            return View(projects);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(ProjectDTO project)
        {
            try
            {
                await _service.InsertAsync(project);
                await _service.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    }