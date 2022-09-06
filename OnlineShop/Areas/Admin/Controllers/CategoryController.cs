using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess.Repositories;
using ShoppingCart.DataAccess.ViewModels;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();

            categoryVM.categories = _unitOfWork.Category.GetAll();

            return View(categoryVM);
        }

        [HttpGet]

        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();

            if(id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Category = _unitOfWork.Category.GetT(x => x.Id == id);

                if(vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }
    }
}
