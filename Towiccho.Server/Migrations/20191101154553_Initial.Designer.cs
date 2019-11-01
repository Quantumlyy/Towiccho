﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notifi.NET.DatabaseContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Towiccho.Server.Migrations
{
    [DbContext(typeof(NotifiDatabaseContext))]
    [Migration("20191101154553_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Notifi.NET.DatabaseContext.Models.Towiccho.TowicchoSubscriberGuild", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChannelID")
                        .IsRequired()
                        .HasColumnName("channel_id")
                        .HasColumnType("text");

                    b.Property<string>("EmbedHash")
                        .IsRequired()
                        .HasColumnName("embed_hash")
                        .HasColumnType("text");

                    b.Property<List<string>>("GameBlacklist")
                        .IsRequired()
                        .HasColumnName("game_blacklist")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("GameWhitelist")
                        .IsRequired()
                        .HasColumnName("game_whitelist")
                        .HasColumnType("text[]");

                    b.Property<string>("GuildID")
                        .IsRequired()
                        .HasColumnName("guild_id")
                        .HasColumnType("text");

                    b.Property<int>("Language")
                        .HasColumnName("language")
                        .HasColumnType("integer");

                    b.Property<bool>("NotificationOffline")
                        .HasColumnName("notification_offline")
                        .HasColumnType("boolean");

                    b.Property<string>("SubscribingUserID")
                        .IsRequired()
                        .HasColumnName("subscribing_user_id")
                        .HasColumnType("text");

                    b.Property<long?>("TowicchoSubscriptionID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("TowicchoSubscriptionID");

                    b.ToTable("TowicchoSubscriberGuild");
                });

            modelBuilder.Entity("Notifi.NET.DatabaseContext.Models.Towiccho.TowicchoSubscription", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("at_create")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ExpireAt")
                        .HasColumnName("at_expire")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FetchedAt")
                        .HasColumnName("at_fetch")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsStreaming")
                        .HasColumnName("streaming_status")
                        .HasColumnType("boolean");

                    b.Property<string>("TwitchID")
                        .IsRequired()
                        .HasColumnName("twitch_id")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("TowicchoSubscriptions");
                });

            modelBuilder.Entity("Notifi.NET.DatabaseContext.Models.Yotubii.YotubiiSubscriberGuild", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChannelID")
                        .IsRequired()
                        .HasColumnName("channel_id")
                        .HasColumnType("text");

                    b.Property<string>("EmbedHash")
                        .IsRequired()
                        .HasColumnName("embed_hash")
                        .HasColumnType("text");

                    b.Property<string>("GuildID")
                        .IsRequired()
                        .HasColumnName("guild_id")
                        .HasColumnType("text");

                    b.Property<int>("Language")
                        .HasColumnName("language")
                        .HasColumnType("integer");

                    b.Property<string>("SubscribingUserID")
                        .IsRequired()
                        .HasColumnName("subscribing_user_id")
                        .HasColumnType("text");

                    b.Property<long?>("YotubiiSubscriptionID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("YotubiiSubscriptionID");

                    b.ToTable("YotubiiSubscriberGuild");
                });

            modelBuilder.Entity("Notifi.NET.DatabaseContext.Models.Yotubii.YotubiiSubscription", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("at_create")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("YotubiiSubscriptions");
                });

            modelBuilder.Entity("Notifi.NET.DatabaseContext.Models.Towiccho.TowicchoSubscriberGuild", b =>
                {
                    b.HasOne("Notifi.NET.DatabaseContext.Models.Towiccho.TowicchoSubscription", null)
                        .WithMany("Guilds")
                        .HasForeignKey("TowicchoSubscriptionID");
                });

            modelBuilder.Entity("Notifi.NET.DatabaseContext.Models.Yotubii.YotubiiSubscriberGuild", b =>
                {
                    b.HasOne("Notifi.NET.DatabaseContext.Models.Yotubii.YotubiiSubscription", null)
                        .WithMany("Guilds")
                        .HasForeignKey("YotubiiSubscriptionID");
                });
#pragma warning restore 612, 618
        }
    }
}
