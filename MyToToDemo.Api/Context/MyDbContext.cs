using Microsoft.EntityFrameworkCore;
using MyToToDemo.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Context
{
   public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Memo> Memos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
