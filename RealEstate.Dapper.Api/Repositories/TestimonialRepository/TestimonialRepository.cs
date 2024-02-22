using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_UI.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public class TestimonialRepository : ITestimonialReposittory
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);

                return values.ToList();
            }
        }
    }
}
