using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.DataTransferObjects
{
    [BindProperties]
    public class ProductFilterData
    {
        public string? Name { get; set; }

        public int? CategoryId { get; set; }
    }
}