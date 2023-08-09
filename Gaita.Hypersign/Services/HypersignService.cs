using Gaita.Hypersign.Services.DTO;
using RestSharp;

namespace Gaita.Hypersign.Services
{
    public class HypersignService
    {
        private string _privateKey { get; set; }
        private string _baseUrl { get; set; }
        public HypersignService(IConfiguration configuration)
        {
            _privateKey = configuration["HypersignAPISecret"];
            _baseUrl = configuration["HypersignAPIUrl"];
        }

        public string GetAccessToken()
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("/api/v1/app/oauth", Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-Api-Secret-Key", _privateKey);
            RestResponse<OAuthDTO> response = client.Execute<OAuthDTO>(request);
            if (response.IsSuccessStatusCode)
            {
                return response.Data.access_token;
            }
            return null;
        }

        public DiDListDTO[] GetDiD()
        {
            string accessToken = GetAccessToken();
            if(accessToken != null)
            {
                var client = new RestClient(_baseUrl);
                var request = new RestRequest("/api/v1/did", Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                request.AddHeader("Authorization", "Bearer "+ accessToken);
                RestResponse<DiDListDTO[]> response = client.Execute<DiDListDTO[]>(request);
                if (response.IsSuccessStatusCode)
                {
                    return response.Data;
                }
            }
            return null;
        }

        public DiDListDTO[] RegisterDiD()
        {
            string accessToken = GetAccessToken();
            if (accessToken != null)
            {
                var client = new RestClient(_baseUrl);
                var request = new RestRequest("/api/v1/did", Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                request.AddHeader("Authorization", "Bearer " + accessToken);
                RestResponse<DiDListDTO[]> response = client.Execute<DiDListDTO[]>(request);
                if (response.IsSuccessStatusCode)
                {
                    return response.Data;
                }
            }
            return null;
        }
    }
}
