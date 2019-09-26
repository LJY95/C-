using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Config
{
   public class usersConfig:EntityTypeConfiguration<users>
    {
        public usersConfig() {
            this.ToTable(nameof(users));
        }
    }
}
