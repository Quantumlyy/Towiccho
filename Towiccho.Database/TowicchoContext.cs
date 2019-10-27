using Microsoft.EntityFrameworkCore;

namespace Towiccho.Database
{
    class NotifiContext : DbContext
    {
        public NotifiContext(DbContextOptions options) : base(options)
        {
        }
    }
}
