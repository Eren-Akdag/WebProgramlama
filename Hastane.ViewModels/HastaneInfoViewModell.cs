using Hastane.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hastane.ViewModels
{
    public class HastaneInfoViewModell
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string City { get; set; }

        public string PinCode { get; set; }

        public string Country { get; set; }

        public HastaneInfoViewModell()
        {

        }

        public HastaneInfoViewModell(HastaneInfoo model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;
        }

        public HastaneInfoo ConvertViewModel(HastaneInfoViewModell model)
        {
            return new HastaneInfoo
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Country = model.Country
            };
        }

    }

}
