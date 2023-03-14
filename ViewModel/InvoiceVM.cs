using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvoicesProject.ViewModel {
    public class InvoiceVM {
        [StringLength(2)]
        [Display(Name = "تاريخ الفاتورة")]
        public string? NWC_Invoice_Year { get; set; }

        public byte NWC_Subscription_File_Unit_No { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Display(Name = " نوع العقار")]
        public string? NWC_Rreal_Estate_TypeID { get; set; }

        //[StringLength(10)]
        [Unicode(false)]
        [Display(Name = "كود الاشتراك")]
        public int? NWC_Subscription_FileID { get; set; }

        [Display(Name = "هوية المشترك")]
        public string NWC_Subscriber_FileID { get; set; }
        
        [Display(Name = "الاسم")]

        public string? NWC_Subscriber_File_Name { get; set; }

        [Display(Name = "تاريخ الفاتورة")]
        public DateTime? NWC_Invoice_Date { get; set; } = DateTime.Now;

        [Display(Name = "من تاريخ")]
        public DateTime? NWC_Invoice_From { get; set; }


        [Display(Name = "الكمية السابقة")]
        public int? NWC_Invoice_Previous_Consumption_Amount { get; set; }

        [Display(Name = "الكمية الحالية")]
        public int? NWC_Invoice_Current_Consumption_Amount { get; set; }

        [Display(Name = "الاستهلاك الكلى")]
        public int? NWC_Invoice_Amount_Consumption { get; set; }

        [Display(Name = "رسوم الخدمة")]
        public decimal? NWC_Invoice_Service_Fee { get; set; }

        [Display(Name = "نسبة الضريبة")]
        public decimal? NWC_Invoice_Tax_Rate { get; set; }
        [Display(Name = "يوجد صرف صحى")]
        public bool? NWC_Invoice_Is_There_Sanitation { get; set; }

        [Display(Name = "قيمة استهلاك المياه")]
        public decimal? NWC_Invoice_Consumption_Value { get; set; }

        [Display(Name = "قيمة استهلاك الصرف الصحي")]
        public decimal? NWC_Invoice_Wastewater_Consumption_Value { get; set; }

        [Display(Name = "قيمة الفاتورة")]
        public decimal? NWC_Invoice_Total_Invoice { get; set; }

        [Display(Name = "قيمة الضريبة")]
        public decimal? NWC_Invoice_Tax_Value { get; set; }

        [Display(Name = "اجمالى الفاتورة")]
        public decimal? NWC_Invoice_Total_Bill { get; set; }

        public string? NWC_Invoice_Total_Reasons { get; set; }

    }
}
