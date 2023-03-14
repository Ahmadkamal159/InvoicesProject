using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicesProject.Models {
    [Index("NWC_Rreal_Estate_TypeID", IsUnique = true)]
    public class NWC_Rreal_Estate_Type {
        [DatabaseGenerated((DatabaseGeneratedOption.None))]
        [Column(TypeName = "varchar(1)")]
        [StringLength(1)]
        [Unicode(false)]
        [Display(Name ="رمز نوع العقار")]
        public string NWC_Rreal_Estate_TypeID { get; set; }

        [StringLength(15)]
        //[Unicode(false)]
        [Display(Name ="وصف نوع العقار")]
        public string? NWC_Rreal_Estate_Type_Name { get; set; }

        [StringLength(100)]
        //[Unicode(false)]
        [Display(Name = "ملاحظات")]
        public string? NWC_Rreal_Estate_Type_Reasons { get; set; }

        public virtual ICollection<NWC_Invoice> NWC_Invoices { get; } = new List<NWC_Invoice>();

        public virtual ICollection<NWC_Subscription_File> NWC_Subscription_Files { get; } = new List<NWC_Subscription_File>();
    }
}
