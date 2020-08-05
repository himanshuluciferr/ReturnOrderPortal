﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReturnOrderPortal.DataContext;

namespace ReturnOrderPortal.Migrations
{
    [DbContext(typeof(ProcessContext))]
    partial class ProcessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReturnOrderPortal.Models.ProcessResponse", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfDelivery")
                        .HasColumnType("datetime2");

                    b.Property<int>("PackagingAndDeliveryCharge")
                        .HasColumnType("int");

                    b.Property<int>("ProcessingCharge")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.ToTable("ProcessDb");
                });
#pragma warning restore 612, 618
        }
    }
}
