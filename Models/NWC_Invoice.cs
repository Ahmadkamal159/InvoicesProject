using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvoicesProject.Models {
    public class NWC_Invoice {
        [Key]
        //[Column(TypeName = "varchar(10)")]
        //[StringLength(10)]
        //[Unicode(false)]
        [Display(Name = "رقم الفاتورة")]
        public int NWC_InvoiceID { get; set; }

        [StringLength(2)]
        [Display(Name = "السنة المالية")]
        public string? NWC_Invoice_Year { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Display(Name = " نوع العقار")]
        public string? NWC_Rreal_Estate_TypeID { get; set; }
        [ForeignKey("NWC_Rreal_Estate_TypesID")]
        public virtual NWC_Rreal_Estate_Type? NWC_Rreal_Estate_Type { get; set; }

        //[StringLength(10)]
        [Unicode(false)]
        [Display(Name = "كود الاشتراك")]
        public int? NWC_Subscription_FileID { get; set; }
        [ForeignKey("NWC_Subscription_FileID")]
        [Display(Name = "كود الاشتراك")]
        public virtual NWC_Subscription_File? NWC_Subscription { get; set; }

        [StringLength(10)]
        [Unicode(false)]
        [Display(Name = "هوية المشترك")]
        public string NWC_Subscriber_FileID { get; set; }
        [Display(Name = "هوية المشترك")]
        public virtual NWC_Subscriber_File? NWC_Invoices_Subscriber_file { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاريخ الفاتورة")]
        public DateTime? NWC_Invoice_Date { get; set; } = DateTime.Now;

        [Column(TypeName = "date")]
        [Display(Name = "من تاريخ")]
        public DateTime? NWC_Invoice_From { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "الى تاريخ")]
        public DateTime? NWC_Invoice_To { get; set; } = DateTime.Today;

        [Display(Name = "الكمية السابقة")]
        public int? NWC_Invoice_Previous_Consumption_Amount { get; set; }
        
        [Display(Name = "الكمية الحالية")]
        public int? NWC_Invoice_Current_Consumption_Amount { get; set; }
        
        [Display(Name = "الاستهلاك الكلى")]
        public int? NWC_Invoice_Amount_Consumption { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "رسوم الخدمة")]
        public decimal? NWC_Invoice_Service_Fee { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "نسبة الضريبة")]
        public decimal? NWC_Invoice_Tax_Rate { get; set; }
        [Display(Name = "يوجد صرف صحى")]
        public bool? NWC_Invoice_Is_There_Sanitation { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "قيمة استهلاك المياه")]
        public decimal? NWC_Invoice_Consumption_Value { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "قيمة استهلاك الصرف الصحي")]
        public decimal? NWC_Invoice_Wastewater_Consumption_Value { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "اجمالى الفاتورة")]
        public decimal? NWC_Invoice_Total_Invoice { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "قيمة الضريبة")]
        public decimal? NWC_Invoice_Tax_Value { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "قيمة الفاتورة")]
        public decimal? NWC_Invoice_Total_Bill { get; set; }

        [StringLength(100)]
        [Display(Name = "ملاحظات")]
        public string? NWC_Invoice_Total_Reasons { get; set; }

    }
}
