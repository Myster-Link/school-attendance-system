using AutoMapper;

namespace Mappers
{
    public class MapperAdapter : IMapperAdapter
    {
        private readonly IMapper _mapper;

        public MapperAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TOutput Map<TInput, TOutput>(TInput input)
            => _mapper.Map<TOutput>(input);

        public TOutput Map<TInput, TOutput>(TInput input, TOutput output)
            => _mapper.Map(input, output);

        public IEnumerable<TOutput> Map<TInput, TOutput>(IEnumerable<TInput> input)
            => _mapper.Map<IEnumerable<TOutput>>(input);

        public IEnumerable<TOutput> Map<TInput, TOutput>(List<TInput> input)
            => _mapper.Map<IEnumerable<TOutput>>(input);

        public List<TOutput> MapToList<TInput, TOutput>(IEnumerable<TInput> input)
            => _mapper.Map<List<TOutput>>(input);
    }
}
