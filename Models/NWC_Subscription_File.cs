using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace InvoicesProject.Models {
    public class NWC_Subscription_File {
        [Key]
        //[Editable(false)]
        //[Column(TypeName = "varchar(10)")]
        //[StringLength(10)]
        //[Unicode(false)]
        [Display(Name = "رقم الاشتراك")]
        public int NWC_Subscription_FileID { get; set; }

        [StringLength(10)]
        [Unicode(false)]
        [Display(Name = "هوية المشترك")]
        public string? NWC_Subscription_File_SubscriberID { get; set; }
        [ForeignKey("NWC_Subscription_File_SubscriberID")]
        [Display(Name = "هوية المشترك")]
        public virtual NWC_Subscriber_File? NWC_Subscription_File_Subscriber { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Display(Name = "رمز العقار")]
        public string? NWC_Rreal_Estate_TypesID { get; set; }
        [ForeignKey("NWC_Rreal_Estate_TypesID")]
        [Display(Name = "رمز العقار")]
        public virtual NWC_Rreal_Estate_Type? NWC_Rreal_Estate_Types { get; set; }
        [Display(Name = "عدد الوحدات")]
        [Required]
        public byte NWC_Subscription_File_Unit_No { get; set; }
        [Display(Name = "هل يوجد صرف صحي")]
        public bool NWC_Subscription_File_Is_There_Sanitation { get; set; }
        [Display(Name = "اخر قراءة للعداد")]
        public int? NWC_Subscription_File_Last_Reading_Meter { get; set; } = new Random().Next(120);

        [StringLength(100)]
        [Display(Name = "ملاحظات")]
        public string? NWC_Subscription_File_Reasons { get; set; }

        public virtual ICollection<NWC_Invoice> NWC_Invoices { get; } = new List<NWC_Invoice>();
        
    }
}
