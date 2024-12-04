using loc_api_crud.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace loc_api_crud.Data
{
    public class CountryRepository
    {
        private readonly IConfiguration _configuration;

        public CountryRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public List<CountryModel> GetAllCountry()
        {
            string str = this._configuration.GetConnectionString("myConnString");
            List<CountryModel> list = new List<CountryModel>();
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "loc_country_selectAll";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CountryModel country = new CountryModel();
                    country.CountryID = Convert.ToInt32(reader["CountryID"]);
                    country.CountryName = reader["CountryName"].ToString();
                    country.CountryCode = reader["CountryCode"].ToString();
                    list.Add(country);
                }
                conn.Close();
            }
            return list;
        }
    }
}
