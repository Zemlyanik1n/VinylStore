﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VinylStore.Persistence;

#nullable disable

namespace VinylStore.Persistence.Migrations
{
    [DbContext(typeof(VinylStoreDbContext))]
    [Migration("20250304195917_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:Tablespace", "vinylstore")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlbumGenre", b =>
                {
                    b.Property<long>("AlbumId")
                        .HasColumnType("bigint");

                    b.Property<long>("GenresId")
                        .HasColumnType("bigint");

                    b.HasKey("AlbumId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("AlbumGenre");
                });

            modelBuilder.Entity("DeliveryAddressUser", b =>
                {
                    b.Property<long>("DeliveryAddressesId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("DeliveryAddressesId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DeliveryAddressUser");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Album", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("ReleaseType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("VinylStore.Core.Models.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<long>("VinylPlateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("VinylPlateId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("VinylStore.Core.Models.DeliveryAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FlatNumber")
                        .HasColumnType("integer");

                    b.Property<int>("PostalCode")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("DeliveryAddresses");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("DeliveryAddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("VinylStore.Core.Models.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("VinylPlateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("VinylPlateId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Track", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AlbumId")
                        .HasColumnType("bigint");

                    b.Property<int>("DurationInSeconds")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("VinylStore.Core.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VinylStore.Core.Models.VinylPlate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AlbumId")
                        .HasColumnType("bigint");

                    b.Property<int>("Condition")
                        .HasColumnType("integer");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("PrintYear")
                        .HasColumnType("integer");

                    b.Property<int>("StockCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("VinylPlates");
                });

            modelBuilder.Entity("AlbumGenre", b =>
                {
                    b.HasOne("VinylStore.Core.Models.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VinylStore.Core.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryAddressUser", b =>
                {
                    b.HasOne("VinylStore.Core.Models.DeliveryAddress", null)
                        .WithMany()
                        .HasForeignKey("DeliveryAddressesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VinylStore.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VinylStore.Core.Models.Cart", b =>
                {
                    b.HasOne("VinylStore.Core.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("VinylStore.Core.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VinylStore.Core.Models.CartItem", b =>
                {
                    b.HasOne("VinylStore.Core.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VinylStore.Core.Models.VinylPlate", "VinylPlate")
                        .WithMany()
                        .HasForeignKey("VinylPlateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("VinylPlate");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Order", b =>
                {
                    b.HasOne("VinylStore.Core.Models.DeliveryAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VinylStore.Core.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAddress");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VinylStore.Core.Models.OrderItem", b =>
                {
                    b.HasOne("VinylStore.Core.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VinylStore.Core.Models.VinylPlate", "VinylPlate")
                        .WithMany()
                        .HasForeignKey("VinylPlateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("VinylPlate");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Track", b =>
                {
                    b.HasOne("VinylStore.Core.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("VinylStore.Core.Models.VinylPlate", b =>
                {
                    b.HasOne("VinylStore.Core.Models.Album", "Album")
                        .WithMany("VinylPlates")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Album", b =>
                {
                    b.Navigation("Tracks");

                    b.Navigation("VinylPlates");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("VinylStore.Core.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("VinylStore.Core.Models.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
