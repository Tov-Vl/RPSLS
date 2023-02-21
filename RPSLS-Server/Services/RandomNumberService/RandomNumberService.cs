using Microsoft.Extensions.Options;
using RpslsServer.Mapper;
using RpslsServer.Models;
using RpslsServer.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RpslsServer.Services.RandomNumberService
{
    public class RandomNumberService : IRandomNumberService
    {
        private readonly HttpClient _httpClient;
        private readonly string _randomNumberServiceBaseUrl;
        private readonly IMapper<int, Gesture> _randomNumberMapper;

        public RandomNumberService(
            HttpClient httpClient,
            IOptions<RandomNumberServiceOptions> options,
            IMapper<int, Gesture> randomNumberMapper)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
            _randomNumberServiceBaseUrl = options?.Value?.BaseUrl ?? throw new ArgumentNullException();
            _randomNumberMapper = randomNumberMapper ?? throw new ArgumentNullException();
        }

        public async Task<Gesture> GetRandomNumberAsync()
        {
            var response = await _httpClient.GetStringAsync(_randomNumberServiceBaseUrl);

            var responseDto = JsonSerializer.Deserialize<RandomNumberDto>(response);

            if (responseDto == null)
                throw new ArgumentException($"Can't get random number from {_randomNumberServiceBaseUrl}");

            var res = _randomNumberMapper.Map(responseDto.Number);

            return res;
        }

        private record class RandomNumberDto
        {
            [JsonPropertyName("random_number")]
            public int Number { get; init; }
        }
    }
}
