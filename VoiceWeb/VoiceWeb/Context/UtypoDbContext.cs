using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceWeb.Context
{
    public class UtypoDbContext:IdentityDbContext
    {
        public UtypoDbContext(DbContextOptions<UtypoDbContext> options):base(options)
        {
            base.Database.EnsureCreated();
        }
    }
}
