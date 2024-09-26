using app.Data;

namespace app.Controllers 
{
    public class DbRepository
    {
        protected readonly AppDbContext _context;

        public DbRepository() 
        {
            _context = new AppDbContext();
        }
    }
}
