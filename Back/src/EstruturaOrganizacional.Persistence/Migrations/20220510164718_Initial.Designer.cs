﻿// <auto-generated />
using System;
using EstruturaOrganizacional.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstruturaOrganizacional.Persistence.Migrations
{
    [DbContext(typeof(EstruturaOrganizacionalContext))]
    [Migration("20220510164718_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("OrganizationalStructureBusinessAreasID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureMarketAreasId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureOperatingUnitsID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureTchnologicalAreasID")
                        .HasColumnType("int");

                    b.Property<string>("codEMS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID");

                    b.ToTable("BUSINESSAREA");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.MarketArea", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("OrganizationalStructureBusinessAreasID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureMarketAreasId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureOperatingUnitsID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureTchnologicalAreasID")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID");

                    b.ToTable("MARKETAREA");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.OperatingUnit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("OrganizationalStructureBusinessAreasID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureMarketAreasId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureOperatingUnitsID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureTchnologicalAreasID")
                        .HasColumnType("int");

                    b.Property<string>("codReduzido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID");

                    b.ToTable("OPERATINGUNIT");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.OrganizationalStructure", b =>
                {
                    b.Property<int>("BusinessAreasID")
                        .HasColumnType("int");

                    b.Property<int>("MarketAreasId")
                        .HasColumnType("int");

                    b.Property<int>("OperatingUnitsID")
                        .HasColumnType("int");

                    b.Property<int>("TchnologicalAreasID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ano")
                        .HasColumnType("datetime2");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("BusinessAreasID", "MarketAreasId", "OperatingUnitsID", "TchnologicalAreasID");

                    b.ToTable("ORGANIZATIONALSTRUCTURE");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.TechnologicalArea", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("OrganizationalStructureBusinessAreasID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureMarketAreasId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureOperatingUnitsID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationalStructureTchnologicalAreasID")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unidadeVirtual")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID");

                    b.ToTable("TECHNOLOGICALAREA");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.BusinessArea", b =>
                {
                    b.HasOne("EstruturaOrganizacional.Domain.OrganizationalStructure", null)
                        .WithMany("BusinessArea")
                        .HasForeignKey("OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.MarketArea", b =>
                {
                    b.HasOne("EstruturaOrganizacional.Domain.OrganizationalStructure", null)
                        .WithMany("MarketArea")
                        .HasForeignKey("OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.OperatingUnit", b =>
                {
                    b.HasOne("EstruturaOrganizacional.Domain.OrganizationalStructure", null)
                        .WithMany("OperatingUnit")
                        .HasForeignKey("OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.TechnologicalArea", b =>
                {
                    b.HasOne("EstruturaOrganizacional.Domain.OrganizationalStructure", null)
                        .WithMany("TchnologicalArea")
                        .HasForeignKey("OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID");
                });

            modelBuilder.Entity("EstruturaOrganizacional.Domain.OrganizationalStructure", b =>
                {
                    b.Navigation("BusinessArea");

                    b.Navigation("MarketArea");

                    b.Navigation("OperatingUnit");

                    b.Navigation("TchnologicalArea");
                });
#pragma warning restore 612, 618
        }
    }
}
