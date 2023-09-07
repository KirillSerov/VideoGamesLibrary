using VideoGames.DAL.EFramework.Context;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.DAL.EFramework.Repositories
{
    public class EFGenreRepository : BaseEFRepository<GenreEntity>
    {
        public EFGenreRepository(EFContext context) : base(context) { }
    }
}
