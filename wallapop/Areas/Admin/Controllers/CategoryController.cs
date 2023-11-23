using Microsoft.AspNetCore.Mvc;
using wallapop.AccessData.Repository.IRepository;
using wallapop.Models;

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
            var categoryList = await _unitOfWork.CatRepo.GetAll();

            return View(categoryList);
        }
                
        public async Task<IActionResult> Upsert(int? id)
        {
            Category category = new Category();

            if(id == null)
            {
                // Crear
                return View(category);
            }

            category = await _unitOfWork.CatRepo.GetById(id.GetValueOrDefault());

            if(id == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if(ModelState.IsValid)
            {
                if(category.Id == 0)
                {
                    // Crear
                    await _unitOfWork.CatRepo.Insert(category);
                }
                else
                {
                    // Actualizar
                    _unitOfWork.CatRepo.Update(category);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _unitOfWork.CatRepo.GetById(id);

            if(category.Id == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
