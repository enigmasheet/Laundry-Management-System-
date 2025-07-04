﻿using Laundry.Api.Models;
using Laundry.Shared.Enums;
using Microsoft.EntityFrameworkCore;
namespace Laundry.Api.Data.Seed
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string hashedPassword = "$2a$11$wbiDSq0ImltzPEcBzbP/h.9Wl5Za3cwtxJbnTmh/h75rewphVaxhu"; // Password@123 example

            // Vendors
            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { Id = 1, Name = "Sparkle Laundry", Description = "Fast & reliable laundry service", Phone = "1234567890", Email = "contact@sparklelaundry.com", Address = "123 Main St", Latitude = 40.7128, Longitude = -74.0060, IsActive = true, AverageRating = 4.5, TotalReviews = 2 },
                new Vendor { Id = 2, Name = "Fresh Wash", Description = "Eco-friendly washing", Phone = "0987654321", Email = "info@freshwash.com", Address = "456 Elm St", Latitude = 34.0522, Longitude = -118.2437, IsActive = true, AverageRating = 4.7, TotalReviews = 3 }
            );

            // Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                    FullName = "Super Admin",
                    Email = "superadmin@laundry.com",
                    PasswordHash = hashedPassword,
                    Role = "SuperAdmin",
                    IsActive = true
                },
                new User
                {
                    UserId = new Guid("22222222-2222-2222-2222-222222222222"),
                    FullName = "Vendor Admin Sparkle",
                    Email = "admin@sparklelaundry.com",
                    PasswordHash = hashedPassword,
                    Role = "VendorAdmin",
                    VendorId = 1,
                    IsActive = true
                },
                new User
                {
                    UserId = new Guid("33333333-3333-3333-3333-333333333333"),
                    FullName = "Vendor Employee 1",
                    Email = "employee1@sparklelaundry.com",
                    PasswordHash = hashedPassword,
                    Role = "Employee",
                    VendorId = 1,
                    IsActive = true
                },
                new User
                {
                    UserId = new Guid("33333533-3353-3355-3533-335333333333"),
                    FullName = "Vendor Employee 2",
                    Email = "employee2@FreshWash.com",
                    PasswordHash = hashedPassword,
                    Role = "Employee",
                    VendorId = 2,
                    IsActive = true
                },
                new User
                {
                    UserId = new Guid("44444444-4444-4444-4444-444444444444"),
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    PasswordHash = hashedPassword,
                    Role = "Customer",
                    IsActive = true
                },
                new User
                {
                    UserId = new Guid("55555555-5555-5555-5555-555555555555"),
                    FullName = "Jane Smith",
                    Email = "jane.smith@example.com",
                    PasswordHash = hashedPassword,
                    Role = "Customer",
                    IsActive = true
                }
            );

            // Services
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Wash & Fold", Description = "Basic wash and fold service", Price = 5.00m, Unit = ServiceUnit.PerKg, VendorId = 1 },
                new Service { Id = 2, Name = "Dry Cleaning", Description = "Premium dry cleaning", Price = 15.00m, Unit = ServiceUnit.PerItem, VendorId = 1 },
                new Service { Id = 3, Name = "Wash & Iron", Description = "Wash and iron clothes", Price = 10.00m, Unit = ServiceUnit.PerKg, VendorId = 2 }
            );


            // Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerId = new Guid("44444444-4444-4444-4444-444444444444"),
                    VendorId = 1,
                    CreatedAt = new DateTime(2025, 6, 9),
                    PickupDate = new DateTime(2025, 6, 10),
                    DeliveryDate = new DateTime(2025, 6, 12),
                    Status = OrderStatus.Completed,
                    TotalAmount = 3 * 5.00m + 1 * 15.00m
                },
                new Order
                {
                    Id = 2,
                    CustomerId = new Guid("55555555-5555-5555-5555-555555555555"),
                    VendorId = 2,
                    CreatedAt = new DateTime(2025, 6, 11),
                    PickupDate = new DateTime(2025, 6, 12),
                    DeliveryDate = null,
                    Status = OrderStatus.Pending,
                    TotalAmount = 2 * 10.00m
                }
            );

            // OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ServiceId = 1,
                    Quantity     = 3,
                    Unit = ServiceUnit.PerKg,       // enum value included

                    UnitPrice = 5.00m,
                    TotalPrice = 3 * 5.00m
                },
                new OrderItem
                {
                    Id = 2,
                    OrderId = 1,
                    ServiceId = 2,
                    Quantity = 1,
                    Unit = ServiceUnit.PerKg,       // enum value included

                    UnitPrice = 15.00m,
                    TotalPrice = 1 * 15.00m
                },
                new OrderItem
                {
                    Id = 3,
                    OrderId = 2,
                    ServiceId = 3,
                    Quantity = 2,
                    Unit = ServiceUnit.PerKg,       // enum value included

                    UnitPrice = 10.00m,
                    TotalPrice = 2 * 10.00m
                }
            );

            // Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, CustomerId = new Guid("44444444-4444-4444-4444-444444444444"), VendorId = 1, Rating = 5, Comment = "Great service!", CreatedAt = new DateTime(2025, 6, 10) },
                new Review { Id = 2, CustomerId = new Guid("55555555-5555-5555-5555-555555555555"), VendorId = 2, Rating = 4, Comment = "Good but room for improvement.", CreatedAt = new DateTime(2025, 6, 11) }
            );

            // Vendor Inquiries
            modelBuilder.Entity<VendorInquiry>().HasData(
                new VendorInquiry { Id = 1, CustomerId = new Guid("44444444-4444-4444-4444-444444444444"), VendorId = 1, Message = "Do you offer express service?", SentAt = new DateTime(2025, 6, 8), IsResponded = false },
                new VendorInquiry { Id = 2, CustomerId = new Guid("55555555-5555-5555-5555-555555555555"), VendorId = 2, Message = "Can I schedule a pickup on weekends?", SentAt = new DateTime(2025, 6, 9), IsResponded = false }
            );
        }
    }
}