using System.ComponentModel.DataAnnotations;

namespace InventarioVeagroApi.Messages.Request
{
    public class ReportReqDTO
    {

        [Required(ErrorMessage ="El campo dateStart es obligatorio")]
        public string DateStart { set; get; }

        [Required(ErrorMessage ="El campo dateEnd es obligatorio")]
        public string DateEnd { set; get; }

        public string? PayForm { set; get; }

        public override string ToString()
        {

            return $"dateStart {DateStart}; dateEnd {DateEnd}; PayForm: {PayForm}";
        }
    }
}
