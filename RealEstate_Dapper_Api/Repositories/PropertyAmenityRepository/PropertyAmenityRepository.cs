using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropertyAmenityStatusDto>> GetPropertyAmenityStatusByPropertyIdAsync(int propertyId)
        {
            string query = "Select * From PropertyAmenity inner join Amenity on PropertyAmenity.AmenityID=Amenity.AmenityID Where PropertyID=@propertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyID",propertyId);
            using (var connection=_context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityStatusDto>(query,parameters);
                return values.ToList();
            }
        }
    }
}
