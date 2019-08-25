using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Services
{
    public interface ICategoryService
    {
      IEnumerable< string >GetAllCategoryNames();
        IAuditInfo GetCategoryById(string Id);

        IAuditInfo GetCategoryTag(string categoryId);

    }
}
