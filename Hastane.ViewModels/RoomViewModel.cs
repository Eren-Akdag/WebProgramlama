using Hastane.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int HastaneInfoId { get; set; }

        public HastaneInfoo HastaneInfoo { get; set; }

        public RoomViewModel() 
        {
            
        }

        public RoomViewModel(Room model)
        {
            Id = model.Id;
            RoomNumber = model.RoomNumber;
            Type = model.Type;
            Status = model.Status;
            HastaneInfoId = model.HospitalId;
            HastaneInfoo = model.Hastane;
        }

        public Room ConvertViewModel(RoomViewModel model)
        {
            return new Room  
            { 
                Id = model.Id,
                RoomNumber = model.RoomNumber,
                Type = model.Type,
                Status = model.Status,
                HospitalId = model.HastaneInfoId,
                Hastane = model.HastaneInfoo
            };
        }
    }
}
