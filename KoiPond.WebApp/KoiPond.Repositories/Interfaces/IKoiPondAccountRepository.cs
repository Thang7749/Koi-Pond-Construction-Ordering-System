using KoiPond.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Repositories.Interfaces
{
    public interface IKoiPondAccountRepository
    {
        Task<List<TaiKhoanKhachHang>> GetAllTaiKhoanKhachHang();
    }
}
