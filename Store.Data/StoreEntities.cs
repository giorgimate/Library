using Store.Data.Configuration;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Store.Data
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True") { }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<BookAuthors> BookAuthors { get; set; }
        public DbSet<BookGenres>  BookGenres { get; set; }
        public DbSet<BookLanguages> BookLanguages { get; set; }
        public DbSet<BookPublishers> BookPublishers { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookShalves> BookShalves { get; set; }
        public DbSet<EmployeePositions> EmployeePositions { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Penalties> Penalties { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Shalves> Shalves { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get;set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<Menu> menus { get; set; }









        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
