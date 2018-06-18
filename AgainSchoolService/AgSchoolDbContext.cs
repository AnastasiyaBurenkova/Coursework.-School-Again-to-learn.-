using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgainSchoolModel;

namespace AgainSchoolService
{
    
    public class AgSchoolDbContext : DbContext
    {
        public AgSchoolDbContext() : base("AgaSchoolDatabase")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;          
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Section> Sections { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Entry> Entrys { get; set; }

        public virtual DbSet<EntrySection> EntrySections { get; set; }
        /// <summary>
        /// Перегружаем метод созранения изменений. Если возникла ошибка - очищаем все изменения
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception)
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
                throw;
            }
        }
    }
}