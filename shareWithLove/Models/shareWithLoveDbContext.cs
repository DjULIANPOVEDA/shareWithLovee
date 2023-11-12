using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using shareWithLove.Controllers;

namespace shareWithLove.Models;

public partial class ShareWithLoveDbContext : DbContext
{
    public ShareWithLoveDbContext()
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Clothe> Clothes { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseNpgsql("Host=dpg-cl60qjl140uc73ersh7g-a.oregon-postgres.render.com;Database=sharewithlove;Username=sharewithlove_user;Password=QKpLxe1HD23Rh1iUFir7UXzksC8ux72f");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

