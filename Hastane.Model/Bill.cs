using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Model
{
    public class Bill
    {
        public int Id { get; set; }

        public int BillNumber { get; set; }

        public ApplicationUser Patient { get; set; }

        public decimal DoctorCharge { get; set; }

        public int MedicineCharge { get; set; }

        public decimal RoomCharge { get; set; }

        public decimal OperationCharge { get; set; }

        public int NoOfDays { get; set; }

        public int NursingCharge { get; set; }

        public int LabCharge { get; set; }

        public decimal Advance { get; set; }

        public decimal TotalBill { get; set; }

        public Insurance Insurance { get; set; }
    }
}
