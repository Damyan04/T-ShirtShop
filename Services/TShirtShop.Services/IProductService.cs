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
        IEnumerable<IAuditInfo> Products();
        IAuditInfo GetProductById(string productId);
        IEnumerable<IAuditInfo> NewestProducts();
        FileStreamResult ViewProduct(string imageId);
    }
}
