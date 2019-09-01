using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;
using TShirtShop.Data.Models;
using TShirtShop.Services.Data;

namespace TShirtShop.Services
{
    public interface IProductService
    {
        ICollection<ProductDto> Products();
        ProductDto GetProductById(string productId);
        ICollection<ProductDto> NewestProducts();
        FileStreamResult ViewProduct(string imageId);
        void AddImage(ICollection<IFormFile> files, string name, string price,IList<string> colors, IList<string> tags, IList<string> sizes, string className);
        ICollection<TagDto> GetTags();
        void PostComment(string rating, string textAnswer, string Id,string userId);
      
    }
}
