using CS68.Models;
using System.Collections.Generic;
namespace CS68.Service
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id = 1, Name = "Iphone X", Price = 1000},
                new ProductModel() {Id = 2, Name = "Iphone 11", Price = 1500},
                new ProductModel() {Id = 3, Name = "Iphone 12", Price = 1600},
                new ProductModel() {Id = 4, Name = "Iphone 13", Price = 1800}
            });
        }
    }
}