using Microsoft.AspNetCore.Mvc;
using wallapop.AccessData.Repository.IRepository;

namespace wallapop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var catList = await _unitOfWork.CatRepo.GetAll();

            return View(catList);
        }       

        public IActionResult Create()
        {
            return View();
        }
    }
}
