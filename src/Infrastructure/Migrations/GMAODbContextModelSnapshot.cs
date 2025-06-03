using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GMAO.Infrastructure.Data;

namespace GMAO.Infrastructure.Migrations;

[DbContext(typeof(GMAODbContext))]
partial class GMAODbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

        modelBuilder.Entity("GMAO.Domain.Entities.Asset", b =>
        {
            b.Property<Guid>("Id").ValueGeneratedOnAdd();
            b.Property<string>("Name");
            b.Property<string>("Site");
            b.Property<string>("Location");
            b.Property<int>("Status");
            b.HasKey("Id");
            b.ToTable("Assets");
        });
    }
}
