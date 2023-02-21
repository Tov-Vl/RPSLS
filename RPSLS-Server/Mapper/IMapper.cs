namespace RpslsServer.Mapper
{
    public interface IMapper<TSource, TTarget>
    {
        TTarget Map(TSource source);
    }
}
