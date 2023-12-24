using Hastane.ViewModels;
using Hastane.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);

        PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize);

        PagedResult<ApplicationUserViewModel> GetAllPatient (int pageNumber , int pageSize);

        PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string Specility = null , string City = null);
    }
}
