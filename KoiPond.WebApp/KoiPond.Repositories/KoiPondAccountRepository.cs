using KoiPond.Repositories.Entities; //goi Entities
using KoiPond.Repositories.Interfaces; //goi Interfaces
using Microsoft.EntityFrameworkCore;// ho tro Async
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KoiPond.Repositories
{
    public class KoiPondAccountRepository : IKoiPondAccountRepository
    {
        private readonly KoiPond2024DbContext _dbContext;
        public KoiPondAccountRepository(KoiPond2024DbContext dbContext)
        {
            _dbContext = dbContext; //xu ly du lieu
        }
        public async Task<List<AccountKoiPond>> GetAllAccountKoiPond()
        {
            return await _dbContext.AccountKoiPonds.ToListAsync();
        }

     
    }
}
