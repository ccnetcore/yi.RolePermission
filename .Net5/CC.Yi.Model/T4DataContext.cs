using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Model
{
    public partial class DataContext :DbContext
    {
        public DbSet<info_user> info_user { get; set; }
        public DbSet<info_role> info_role { get; set; }
        public DbSet<info_action> info_action { get; set; }
    }
}