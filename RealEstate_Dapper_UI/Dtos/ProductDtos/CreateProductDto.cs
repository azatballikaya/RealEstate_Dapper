﻿namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {

        public string Title { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CoverImage { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime AdvertiesmentDate { get; set; }
        public bool ProductStatus { get; set; }
        public int EmployeeID { get; set; }
        public int ProductCategory { get; set; }
        public bool DealOfTheDay { get; set; }
    }
}
