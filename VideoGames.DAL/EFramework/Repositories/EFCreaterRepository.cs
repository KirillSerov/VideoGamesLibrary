using VideoGames.DAL.EFramework.Context;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.DAL.EFramework.Repositories
{
    public class EFCreaterRepository : BaseEFRepository<CreaterEntity>
    {
        public EFCreaterRepository(EFContext context) : base(context) { }
    }
}
