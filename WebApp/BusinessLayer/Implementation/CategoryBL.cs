using BusinessLayer.Abstraction;
using Repositories.Implementation;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLayer.Implementation
{
    public class CategoryBL : ICategoryBL
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryBL(ICategoryRepository categoryRepository)
        {
            _categoryRepo = categoryRepository;
        }
        public IEnumerable<CategoryViewModel> GetActiveCategories()
        {
            var categories = _categoryRepo.GetAll();
            List<CategoryViewModel> categoriesVM = new();
            foreach (var item in categories)
            {
                categoriesVM.Add(new CategoryViewModel()
                {
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName
                });
            }
            return categoriesVM;
        }
    }
}
