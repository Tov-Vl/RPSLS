using RpslsServer.Models;

namespace RpslsServer.Mapper
{
    public class RandomNumberMapper: IMapper<int, Gesture>
    {
        public Gesture Map(int source)
        {
            var mappedRand = (int)((double)source / 100 * Enum.GetValues<Gesture>().Length);
            mappedRand = mappedRand == 0 ? 1 : mappedRand;

            return (Gesture)mappedRand;
        }
    }
}
