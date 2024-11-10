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
        private readonly KoiPondDbContext _dbContext;
        public KoiPondAccountRepository(KoiPondDbContext dbContext)
        {
            _dbContext = dbContext; //xu ly du lieu
        }
        public async Task<List<TaiKhoanKhachHang>> GetAllTaiKhoanKhachHang()
        {
            return await _dbContext.TaiKhoanKhachHangs.ToListAsync();
        }

     
    }
}
