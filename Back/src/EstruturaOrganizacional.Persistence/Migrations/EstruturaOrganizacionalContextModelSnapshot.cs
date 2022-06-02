﻿// <auto-generated />
using System;
using EstruturaOrganizacional.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstruturaOrganizacional.Persistence.Migrations
{
    [DbContext(typeof(EstruturaOrganizacionalContext))]
    partial class EstruturaOrganizacionalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("EstruturaOrganizacional.Domain.BusinessArea", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("codEMS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("BUSINESSAREA");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.MarketArea", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MARKETAREA");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.OperatingUnit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("codReduzido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("OPERATINGUNIT");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.OrganizationalStructure", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BusinessAreasid")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MarketAreasid")
                        .HasColumnType("int");

                    b.Property<int?>("OperatingUnitsid")
                        .HasColumnType("int");

                    b.Property<int?>("TchnologicalAreasid")
                        .HasColumnType("int");

                    b.Property<int>("ano")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BusinessAreasid");

                    b.HasIndex("MarketAreasid");

                    b.HasIndex("OperatingUnitsid");

                    b.HasIndex("TchnologicalAreasid");

                    b.ToTable("ORGANIZATIONALSTRUCTURE");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.TechnologicalArea", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unidadeVirtual")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TECHNOLOGICALAREA");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.OrganizationalStructure", b =>
                {
                    b.HasOne("EstruturaOrganizacional.Domain.BusinessArea", "BusinessAreas")
                        .WithMany()
                        .HasForeignKey("BusinessAreasid");

                    b.HasOne("EstruturaOrganizacional.Domain.MarketArea", "MarketAreas")
                        .WithMany()
                        .HasForeignKey("MarketAreasid");

                    b.HasOne("EstruturaOrganizacional.Domain.OperatingUnit", "OperatingUnits")
                        .WithMany()
                        .HasForeignKey("OperatingUnitsid");

                    b.HasOne("EstruturaOrganizacional.Domain.TechnologicalArea", "TchnologicalAreas")
                        .WithMany()
                        .HasForeignKey("TchnologicalAreasid");

                    b.Navigation("BusinessAreas");

                    b.Navigation("MarketAreas");

                    b.Navigation("OperatingUnits");

                    b.Navigation("TchnologicalAreas");
                });
#pragma warning restore 612, 618
        }
    }
}
