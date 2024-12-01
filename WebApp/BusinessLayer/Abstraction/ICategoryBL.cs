using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLayer.Abstraction
{
    public interface ICategoryBL
    {
        IEnumerable<CategoryViewModel> GetActiveCategories();
    }
}
