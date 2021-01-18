namespace Shopping_Mall_Management.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MallContext : DbContext
    {
        public MallContext()
            : base("name=Model1")
        {
        }

         public  DbSet<Shop_Owner>Shop_Owners { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Store> Stores { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}