namespace schoolattendance_api.Mapper
{
    public interface IMapperAdapter
    {
        TOutput Map<TInput, TOutput>(TInput input);
        TOutput Map<TInput, TOutput>(TInput input, TOutput output);
        IEnumerable<TOutput> Map<TInput, TOutput>(IEnumerable<TInput> input);
        IEnumerable<TOutput> Map<TInput, TOutput>(List<TInput> input);
        List<TOutput> MapToList<TInput, TOutput>(IEnumerable<TInput> input);
    }
}
