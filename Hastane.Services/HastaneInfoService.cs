using Hastane.Model;
using Hastane.Repositories.Interfaces;
using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public class HastaneInfoService : IHastaneInfo
    {

        private IUnitOfWork _unitOfWork;

        public HastaneInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteHospitalInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<HastaneInfoo>().GetById(id);
            _unitOfWork.GenericRepository<HastaneInfoo>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<HastaneInfoViewModell> GetAll(int pageNumber, int pageSize)
        {
            var vm = new HastaneInfoViewModell();
            int totalCount;
            List<HastaneInfoViewModell> vmList = new List<HastaneInfoViewModell>();

            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<HastaneInfoo>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<HastaneInfoo>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<HastaneInfoViewModell>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public IEnumerable<HastaneInfoViewModell> GetAll()
        {
            var modelList = _unitOfWork.GenericRepository<HastaneInfoo>().GetAll().ToList();
            return ConvertModelToViewModelList(modelList);
        }

        public HastaneInfoViewModell GetHospitalById(int hastaneId)
        {
           var model = _unitOfWork.GenericRepository<HastaneInfoo>().GetById(hastaneId);
           var vm = new HastaneInfoViewModell(model);
           return vm;
        }

        public void InsertHospitalInfo(HastaneInfoViewModell hastaneInfoo)
        {
            var model = new HastaneInfoViewModell().ConvertViewModel(hastaneInfoo);
            _unitOfWork.GenericRepository<HastaneInfoo>().Add(model);
            _unitOfWork.Save();

        }

        public void UpdateHospitalInfo(HastaneInfoViewModell hastaneInfoo)
        {
            var model = new HastaneInfoViewModell().ConvertViewModel(hastaneInfoo);
            var ModelById = _unitOfWork.GenericRepository<HastaneInfoo>().GetById(model.Id);
            ModelById.Name = hastaneInfoo.Name;
            ModelById.City = hastaneInfoo.City;
            ModelById.PinCode = hastaneInfoo.PinCode;
            ModelById.Country = hastaneInfoo.Country;
            _unitOfWork.GenericRepository<HastaneInfoo>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<HastaneInfoViewModell> ConvertModelToViewModelList(List<HastaneInfoo> modelList) 
        {
            return modelList.Select(x => new HastaneInfoViewModell(x)).ToList();
        }
    }
}
