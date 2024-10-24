namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Description { get; set; }

        public int ProductCategory { get; set; }
        public bool DealOfTheDay { get; set; }
    }
}
