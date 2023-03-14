using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvoicesProject.Models {
    public class NWC_Subscriber_File {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(10, ErrorMessage = "يجب ادخال رقم الهوية الصحيح",MinimumLength =10)]
        [Column(TypeName = "varchar(10)")]
        [Unicode(false)]
        [Display(Name = "رقم الهوية")]
        public string NWC_Subscriber_FileId { get; set; }

        [StringLength(100)]
        [Display(Name = "الاسم")]

        public string? NWC_Subscriber_File_Name { get; set; }

        [StringLength(50)]
        [Display(Name = "المدينة")]

        public string? NWC_Subscriber_File_City { get; set; }

        [StringLength(50)]
        [Display(Name = "الحى")]

        public string? NWC_Subscriber_File_Area { get; set; }

        [StringLength(20)]
        [Display(Name = "رقم الهاتف")]
        [RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessage = "رقم الهاتف غير صحيح")]

        public string? NWC_Subscriber_File_Mobile { get; set; }

        [StringLength(100)]
        [Display(Name = "ملاحظات")]

        public string? NWC_Subscriber_File_Reasons { get; set; }

        public virtual ICollection<NWC_Invoice> NWC_Invoices { get; } = new List<NWC_Invoice>();

        public virtual ICollection<NWC_Subscription_File> NWC_Subscription_Files { get; } = new List<NWC_Subscription_File>();
    }
}
