﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YCNBot.Data;

#nullable disable

namespace YCNBot.Data.Migrations
{
    [DbContext(typeof(YCNBotContext))]
    partial class YCNBotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YCNBot.Core.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UniqueIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Chat__3214EC07319C749B");

                    b.ToTable("Chat", (string)null);
                });

            modelBuilder.Entity("YCNBot.Core.Entities.FeedbackType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Feedback__3214EC079EB28446");

                    b.ToTable("FeedbackType", (string)null);
                });

            modelBuilder.Entity("YCNBot.Core.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UniqueIdentifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("Id")
                        .HasName("PK__Message__3214EC07474A5C6B");

                    b.HasIndex("ChatId");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("YCNBot.Core.Entities.UserAgreedTerms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Agreed")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__UserAgre__3214EC07282EF798");

                    b.ToTable("UserAgreedTerms", (string)null);
                });

            modelBuilder.Entity("YCNBot.Core.Entities.UserFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FeedbackTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__UserFeed__3214EC07A26182F4");

                    b.HasIndex("FeedbackTypeId");

                    b.ToTable("UserFeedback", (string)null);
                });

            modelBuilder.Entity("YCNBot.Core.Entities.Message", b =>
                {
                    b.HasOne("YCNBot.Core.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .IsRequired()
                        .HasConstraintName("FK_Chat_Message");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("YCNBot.Core.Entities.UserFeedback", b =>
                {
                    b.HasOne("YCNBot.Core.Entities.FeedbackType", "FeedbackType")
                        .WithMany("UserFeedbacks")
                        .HasForeignKey("FeedbackTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_FeedbackType_UserFeedback");

                    b.Navigation("FeedbackType");
                });

            modelBuilder.Entity("YCNBot.Core.Entities.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("YCNBot.Core.Entities.FeedbackType", b =>
                {
                    b.Navigation("UserFeedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
