using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvoicesProject.Models {

    [Index("NWC_Default_Slice_ValueID", IsUnique = true)]
    public class NWC_Default_Slice_Value {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar(1)")]
        [StringLength(1)]
        [Unicode(false)]
        [Display(Name = "رمز الشريحة")]
        public string NWC_Default_Slice_ValueID { get; set; }

        [StringLength(50)]
        [Display(Name ="وصف الشريحة")]
        public string? NWC_Default_Slice_Value_Name { get; set; }
        [Display(Name ="كمية استهلاك الشريحة")]
        public short? NWC_Default_Slice_Value_Condtion { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "سعر المتر المكعب من المياه")]
        public decimal? NWC_Default_Slice_Value_Water_Price { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "سعر خدمة الصرف الصحى")]
        public decimal? NWC_Default_Slice_Value_Sanitation_Price { get; set; }

        [StringLength(100)]
        [Display(Name = "ملاحظات")]
        public string? NWC_Default_Slice_Values_Reason { get; set; }
    }
}
