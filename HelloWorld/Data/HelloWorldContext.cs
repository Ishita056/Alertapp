using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloWorld.Models;

namespace HelloWorld.Data
{
    public class HelloWorldContext : DbContext
    {
        public HelloWorldContext (DbContextOptions<HelloWorldContext> options)
            : base(options)
        {
        }

        public DbSet<HelloWorld.Models.Alert> Alert { get; set; } = default!;
    }
}
