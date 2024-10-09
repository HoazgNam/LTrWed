using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_03.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public string ContractName { get; set; }
        public DateTime SigningDate { get; set; }
        public string Customer { get; set; }
        public decimal ContractValue { get; set; }
    }
}
