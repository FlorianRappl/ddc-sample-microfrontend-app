using System.Collections.Generic;

namespace ddc_sample_app.Module.Discover
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();

        Game GetBy(int id);
    }
}
