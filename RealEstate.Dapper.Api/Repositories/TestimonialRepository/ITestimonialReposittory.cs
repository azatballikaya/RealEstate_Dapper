using RealEstate_Dapper_UI.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public interface ITestimonialReposittory
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync();
        
    }
}
