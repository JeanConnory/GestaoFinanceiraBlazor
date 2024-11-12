namespace Gestao.Libraries.Services
{
    public class CepService : ICepService
    {
        public async Task<LocalAddress?> SearchByPostalCode(string postalCode)
        {
            var http = new HttpClient();
            return await http.GetFromJsonAsync<LocalAddress>($"https://viacep.com.br/ws/{postalCode.Replace(".", string.Empty).Replace("-", string.Empty)}/json/");
        }
    }

    public class LocalAddress
    {
        public string Cep { get; set; } = string.Empty;

        public string Logradouro { get; set; } = string.Empty;

        public string Complemento { get; set; } = string.Empty;

        public string Bairro { get; set; } = string.Empty;

        public string Localidade { get; set; } = string.Empty;

        public string Uf { get; set; } = string.Empty;

        public string Ibge { get; set; } = string.Empty;

        public string Gia { get; set; } = string.Empty;

        public string Ddd { get; set; } = string.Empty;

        public string Siafi { get; set; } = string.Empty;
    }
}
