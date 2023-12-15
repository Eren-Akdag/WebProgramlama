using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public interface IHastaneInfo
    {
       PagedResult<HastaneInfoViewModell> GetAll(int pageNumber, int pageSize);

        HastaneInfoViewModell GetHospitalById(int hastaneId);

        void UpdateHospitalInfo(HastaneInfoViewModell hastaneInfoo);

        void InsertHospitalInfo(HastaneInfoViewModell hastaneInfoo);

        void DeleteHospitalInfo(int id);
    }
}
