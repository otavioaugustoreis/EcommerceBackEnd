﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreinandoPráticasApi.Data.Context;

#nullable disable

namespace TreinandoPráticasApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TreinandoPráticasApi.Entities.CategoriaEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<string>("DsImagem")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_imagem");

                    b.Property<string>("DsNome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("ds_nome");

                    b.HasKey("Id");

                    b.ToTable("TB_CATEGORIA");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.PedidoEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("fk_usuario");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_PEDIDO");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.PedidoItemEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int")
                        .HasColumnName("fk_produto");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("nr_quantidade");

                    b.Property<double>("Valor")
                        .HasColumnType("double")
                        .HasColumnName("nr_valor");

                    b.Property<int>("pedidoId")
                        .HasColumnType("int")
                        .HasColumnName("fk_pedido");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("pedidoId");

                    b.ToTable("TB_PEDIDOITEM");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.ProdutoEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<string>("DsNome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_nome");

                    b.Property<int>("Fkcategoria")
                        .HasColumnType("int")
                        .HasColumnName("fk_categoria");

                    b.Property<int>("NrQuantidade")
                        .HasColumnType("int")
                        .HasColumnName("nr_quantidade");

                    b.HasKey("Id");

                    b.HasIndex("Fkcategoria");

                    b.ToTable("TB_PRODUTO");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.UsuarioEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<string>("DsCPF")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_cpf");

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_email");

                    b.Property<string>("DsNome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_nome");

                    b.Property<int>("NrIdade")
                        .HasColumnType("int")
                        .HasColumnName("nr_idade");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int")
                        .HasColumnName("fk_pedido");

                    b.HasKey("Id");

                    b.ToTable("TB_USUARIO");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.PedidoEntity", b =>
                {
                    b.HasOne("TreinandoPráticasApi.Entities.UsuarioEntity", "usuarioEntity")
                        .WithMany("pedidoEntities")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuarioEntity");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.PedidoItemEntity", b =>
                {
                    b.HasOne("TreinandoPráticasApi.Entities.ProdutoEntity", "produtoEntity")
                        .WithMany("pedidoItens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreinandoPráticasApi.Entities.PedidoEntity", "PedidoEntity")
                        .WithMany("pedidoItems")
                        .HasForeignKey("pedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PedidoEntity");

                    b.Navigation("produtoEntity");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.ProdutoEntity", b =>
                {
                    b.HasOne("TreinandoPráticasApi.Entities.CategoriaEntity", "categoriaEntity")
                        .WithMany("produtoEntity")
                        .HasForeignKey("Fkcategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoriaEntity");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.CategoriaEntity", b =>
                {
                    b.Navigation("produtoEntity");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.PedidoEntity", b =>
                {
                    b.Navigation("pedidoItems");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.ProdutoEntity", b =>
                {
                    b.Navigation("pedidoItens");
                });

            modelBuilder.Entity("TreinandoPráticasApi.Entities.UsuarioEntity", b =>
                {
                    b.Navigation("pedidoEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
