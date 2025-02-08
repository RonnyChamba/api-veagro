
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioVeagroApi.Models
{
    /**
     * Clase que representa una entidad
     */
    public class Product
    {
        
        public int id { get; set; }
        public string name { get; set; }

        [Column("main_code")]
        public string mainCode { get; set; }

        [Column("auxiliary_code")]
        public string? auxiliaryCode { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public decimal amount { get; set; }

        [Column("stock_available")]
        public decimal stockAvailable { get; set; }

        [Column("measurement_unit")]
        public string measurementUnit { get; set; }

        [Column("record_status")]
        public string recordStatus { get; set; }

        [Column("create_date")]
        public DateTime createDate { get; set; }

        public override string ToString()
        {

            return $"Name: {this.name} , mainCode: {this.mainCode}, measurementUnit: {this.measurementUnit},  description: {this.description}, price: {this.price} , amount: {this.amount}, statusRecord: {this.recordStatus}";
        }
    }
}
