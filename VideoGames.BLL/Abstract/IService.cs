using VideoGames.BLL.Domain;
using VideoGames.BLL.Domain.Abstract;

namespace VideoGames.BLL.Abstract
{
    public interface IService<TRequest, TResponse> where TRequest : BaseRequestDTO where TResponse : BaseResponseDTO
    {
        Task<OperationResult> AddAsync(TRequest entity);
        Task<OperationResult> UpdateAsync(TRequest entity);
        Task<OperationResult> DeleteAsync(int id);
        Task<IEnumerable<TResponse>> GetAllAsync();
        Task<TResponse?> GetAsync(int id);
    }
}
