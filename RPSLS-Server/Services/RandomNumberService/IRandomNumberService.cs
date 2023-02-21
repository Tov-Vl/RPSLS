using RpslsServer.Models;

namespace RpslsServer.Services.RandomNumberService
{
    public interface IRandomNumberService
    {
        Task<Gesture> GetRandomNumberAsync();
    }
}
