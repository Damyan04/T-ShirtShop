using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShirtShop.Data;
using TShirtShop.Data.Common.Models;
using TShirtShop.Services.Data;

namespace TShirtShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _appDbContext;
        public CategoryService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<string> GetAllCategoryNames()
        {
            return _appDbContext.Categories.Select(s => s.Name).OrderByDescending(a=>a).ToList();
            

        }

        public IAuditInfo GetCategoryById(string categoryId)
        {
          var data=  _appDbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            var categoryDto = new CategoryDto()
            {
                Id = data.Id,
                Name=data.Name,
                TagId=data.TagId,
                CreatedOn = data.CreatedOn,
                ModifiedOn = data.ModifiedOn

            };
            var tagDto = new TagDto()
            {
                Id = data.Id,
                Name = data.Tag.Name,
                CreatedOn = data.CreatedOn,
                ModifiedOn = data.ModifiedOn

            };
            return categoryDto;
        }

        public IAuditInfo GetCategoryTag(string categoryId)
        {
            var data = _appDbContext.Categories.Where(id => id.Id == categoryId).Select(s=>s.Tag).FirstOrDefault();
            var tagDto = new TagDto()
            {
                Name = data.Name,
                Id = data.Id,
                CreatedOn=data.CreatedOn,
                ModifiedOn=data.ModifiedOn
                //Products
            };
            return tagDto;

        }
    }
}
