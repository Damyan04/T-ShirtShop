using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShirtShop.Data;
using TShirtShop.Data.Common.Models;
using TShirtShop.Data.Models;
using TShirtShop.Services.Data;

namespace TShirtShop.Services
{
   public class ProductService:IProductService
    {
        private readonly ApplicationDbContext _appDbContext;
        public ProductService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IAuditInfo GetProductById(string productId)
        {
            var data = _appDbContext.Products.FirstOrDefault(p => p.Id == productId);
            
            if (data != null)
            {
                var productDto = MapProduct(data);
                return productDto;
            }
            return null;
        }

        public IEnumerable<IAuditInfo> Products()
        {
            ICollection<Product> data = _appDbContext.Products.Include(c => c.Tags).ToList();
           var products= MapCollectionProducts(data);
                return products;
           
          
        }
        public IEnumerable<IAuditInfo> NewestProducts()
        {
            ICollection<Product> data = _appDbContext.Products.OrderByDescending(c=>c.CreatedOn).ToList();
            var products = MapCollectionProducts(data);
            return products;


        }

        private IEnumerable<ProductDto> MapCollectionProducts(ICollection<Product> data)
        {
            ICollection<ProductDto> productDtos = new HashSet<ProductDto>();
            foreach (var product in data)
            {
                
                var productDto = new ProductDto()
                {
                    Id = product.Id,
                    Color = product.Color,
                    Picture = product.Picture,
                    Price = product.Price,
                    Size = product.Size,
                    CreatedOn = product.CreatedOn,
                    ModifiedOn = product.ModifiedOn


                };

                foreach (var tag in product.Tags)
                {
                    var tagDto = new TagDto()
                    {

                        Id = tag.TagId,
                        Name = tag.Tag.Name,
                        CreatedOn =tag.Tag.CreatedOn,
                        ModifiedOn = tag.Tag.ModifiedOn


                       
                    };
                    productDto.Tags.Add(tagDto);

                }
                productDtos.Add(productDto);
            }
            return productDtos as IEnumerable<ProductDto>;
        }
        private IAuditInfo MapProduct(Product data)
        {
            var productDto = new ProductDto()
            {
                Id = data.Id,
                Color = data.Color,
                Picture = data.Picture,
                Price = data.Price,
                Size = data.Size,
                CreatedOn = data.CreatedOn,
                ModifiedOn = data.ModifiedOn


            };

            foreach (var tag in data.Tags)
            {
                var tagDto = new TagDto()
                {

                    Id = tag.TagId,
                    Name = tag.Tag.Name,
                    
                    CreatedOn = data.CreatedOn,
                    ModifiedOn = data.ModifiedOn
                };
                

                    
                productDto.Tags.Add(tagDto);

            }
            return productDto;
        }
    }
}
