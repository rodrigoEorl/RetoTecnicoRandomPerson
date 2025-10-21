using WebApiNTT.Models;

namespace WebApiNTT.Services
{
    public class PersonaService
    {
        private readonly HttpClient _httpClient;

        public PersonaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonasAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse>("https://randomuser.me/api/?results=10");

            if (response?.Results == null)
                return Enumerable.Empty<Persona>();

            return response.Results.Select(r => new Persona
            {
                Nombre = $"{r.Name?.First} {r.Name?.Last}",
                Genero = r.Gender,
                Ubicacion = r.Location?.Country,
                Correo = r.Email,
                FechaNacimiento = r.Dob?.Date ?? DateTime.MinValue,
                Foto = r.Picture?.Large
            });
        }
    }
}
