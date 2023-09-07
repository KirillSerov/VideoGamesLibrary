using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Api.Models.Abstract;

namespace VideoGames.Api.Models.Models
{
    public class NewGameModel:BaseModel
    {
        public string Title { get; set; } = null!;
        public int CreaterId { get; set; }
        public IEnumerable<int> GenresId { get; set; } = null!;

    }
}
