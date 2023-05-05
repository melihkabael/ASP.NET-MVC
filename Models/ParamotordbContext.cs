using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParamotorTurkey.Models;

public partial class ParamotordbContext : DbContext
{
    public ParamotordbContext()
    {
    }

    public ParamotordbContext(DbContextOptions<ParamotordbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Site> Sites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=paramotordb;Uid=root;Pwd=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("site");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Facebook)
                .HasMaxLength(250)
                .HasColumnName("facebook");
            entity.Property(e => e.Favicon)
                .HasMaxLength(250)
                .HasColumnName("favicon");
            entity.Property(e => e.Instagram)
                .HasMaxLength(250)
                .HasColumnName("instagram");
            entity.Property(e => e.Logo)
                .HasMaxLength(250)
                .HasColumnName("logo");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
            entity.Property(e => e.Twitter)
                .HasMaxLength(250)
                .HasColumnName("twitter");
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .HasColumnName("url");
            entity.Property(e => e.Youtube)
                .HasMaxLength(250)
                .HasColumnName("youtube");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
