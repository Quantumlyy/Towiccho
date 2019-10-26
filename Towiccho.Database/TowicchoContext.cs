using Microsoft.EntityFrameworkCore;

namespace Towiccho.Database
{
    class TowicchoContext : DbContext
    {
        public TowicchoContext(DbContextOptions options) : base(options)
        {
        }
    }
}
