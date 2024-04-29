using AutoMapper;
using PointOfSale.Models;
using PointOfSale.Request;
using PointOfSale.Resource;

namespace PointOfSale.Mapper
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {

            CreateMap<StoreProductRequest, Product> ();
            CreateMap<Product, ProductResource> ()
                .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.ProductCategory));

            CreateMap<StoreProductCategory, ProductCategory> ();
            CreateMap<ProductCategory, ProductCategoryResource>();
        }
    }
}