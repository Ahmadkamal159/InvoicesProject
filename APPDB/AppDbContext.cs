using InvoicesProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicesProject.APPDB {
    public class AppDbContext:DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.HasSequence<int>("specialsequence",x=>x.StartsAt(1).IncrementsBy(1));
        //    modelBuilder.Entity<NWC_Subscription_File>()
        //    .Property(o => o.NWC_Subscription_FileID)
        //    .HasDefaultValueSql("NEXT VALUE FOR specialsequence");
        //}
        public virtual DbSet<NWC_Default_Slice_Value> NWC_Default_Slice_Values { get; set; }

        public virtual DbSet<NWC_Invoice> NWC_Invoices { get; set; }

        public virtual DbSet<NWC_Rreal_Estate_Type> NWC_Rreal_Estate_Types { get; set; }

        public virtual DbSet<NWC_Subscriber_File> NWC_Subscriber_Files { get; set; }

        public virtual DbSet<NWC_Subscription_File> NWC_Subscription_Files { get; set; }
    }
}
