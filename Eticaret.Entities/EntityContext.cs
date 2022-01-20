using System.Data.Entity;


namespace Eticaret.Entities
{
    public class EntityContext : DbContext
    {
        public EntityContext()
        {

            //this.Database.Connection.ConnectionString = "Server=mssql10.trwww.com;Database=modu4094_modustoredb;User Id=modustr;Password=Tnwh00~0";  //  Hosting

            this.Database.Connection.ConnectionString = @"Server=SOFTEK-CENTER\MODSQL;Database=ModustoreDB;Trusted_Connection=true"; // Local DB

            // Lokalde 
            //"Server=localdb;Database=ModuEticaretDB;Trusted_Connection=true  Server'A atarken Username Şifre soracak şekilde ayarla
            // Hosting'e Atarken   user  : mod  Pass:Tnwh00~0   db:modu4094_modustoredb serveer :mssql10.trwww.com 



        }
        public DbSet<TBLCategory> TBLCategory { get; set; }
        public DbSet<TBLCookies> TBLCookies { get; set; }
        public DbSet<TBLCustomer> TBLCustomer { get; set; }
        public DbSet<TBLCustomerAddress> TBLCustomerAddress { get; set; }
        public DbSet<TBLImages> TBLImages { get; set; }
        public DbSet<TBLLog> TBLLog { get; set; }
        public DbSet<TBLNoMemberShip> TBLNoMemberShip { get; set; }
        public DbSet<TBLOrderCustomer> TBLOrderCustomer { get; set; }
        public DbSet<TBLOrder> TBLOrder { get; set; }
        public DbSet<TBLOrderDetail> TBLOrderDetail { get; set; }
        public DbSet<TBLOrderHistory> TBLOrderHistory { get; set; }
        public DbSet<TBLProduct> TBLProduct { get; set; }
        public DbSet<TBLTempBasket> TBLTempBasket { get; set; }
        public DbSet<TBLSettings> TBLSettings { get; set; }
        public DbSet<TBLBlog> TBLBlog { get; set; }
        public DbSet<TBLSupport> TBLSupport { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         // Database.SetInitializer<EntityContext>(new DropCreateDatabaseAlways<EntityContext>());
        }
    }
}
