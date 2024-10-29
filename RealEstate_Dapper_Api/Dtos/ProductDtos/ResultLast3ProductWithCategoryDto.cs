namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultLast3ProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public DateTime AdvertiesmentDate { get; set; }
        public string CategoryName { get; set; }
        public bool DealOfTheDay { get; set; }
    }
}
