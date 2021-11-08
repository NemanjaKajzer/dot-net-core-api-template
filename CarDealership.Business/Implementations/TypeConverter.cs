using AutoMapper;
using CarDealership.Repositories.Interfaces;

namespace CarDealership.Business.Implementations
{
    public class TypeConverter<T> : ITypeConverter<int, T> where T : class, new()
    {

        private readonly IRepository<T> _repository;

        public TypeConverter(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Convert(int source, T destination, ResolutionContext context)
        {
            return _repository.GetByIdAsync(source).Result;
        }
    }

}