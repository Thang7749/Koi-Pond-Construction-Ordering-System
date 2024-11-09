using KoiPond.Repositories.Entities;
using KoiPond.Repositories.Interfaces;
using KoiPond.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Services
{
    public class KoiPondAccountService : IKoiPondAccountService
    {
        private readonly IKoiPondAccountRepository _repository;
        public KoiPondAccountService(IKoiPondAccountRepository repository) 
        { 
            _repository = repository;
        }

        public Task<List<TaiKhoanKhachHang>> TaiKhoanKhachHangs()
        {
            return _repository.GetAllTaiKhoanKhachHang();
        }
    }
}
