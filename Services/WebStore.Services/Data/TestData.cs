﻿using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.Domain.Models;

namespace WebStore.Services.Data
{
    public static class TestData
    {
        public static List<Employee> Employees { get; } = new()
        {
            new Employee
            {
                Id = 1,
                LastName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Age = 37,
                Sex = "Мужской",
                Citizenship = "Россия",
                Salary = 56000
            },
            new Employee
            {
                Id = 2,
                LastName = "Петров",
                FirstName = "Пётр",
                Patronymic = "Петрович",
                Age = 27,
                Sex = "Мужской",
                Citizenship = "Киргизия",
                Salary = 47000
            },
            new Employee
            {
                Id = 3,
                LastName = "Васечкина",
                FirstName = "Изольда",
                Patronymic = "Станиславовна",
                Age = 23,
                Sex = "Женский",
                Citizenship = "Россия",
                Salary = 45000
            },
            new Employee
            {
                Id = 4,
                LastName = "Васечкин",
                FirstName = "Василий",
                Patronymic = "Васильевич",
                Age = 25,
                Sex = "Мужской",
                Citizenship = "Россия",
                Salary = 38000
            }
        };

        public static IEnumerable<Section> Sections { get; } = new[]
        {
            new Section
            {
                Id = 1,
                Name = "Sportswear",
                Order = 0,
                ParentId = null
            },
            new Section
            {
                Id = 2,
                Name = "Nike",
                Order = 0,
                ParentId = 1
            },
            new Section
            {
                Id = 3,
                Name = "Under Armour",
                Order = 1,
                ParentId = 1
            },
            new Section
            {
                Id = 4,
                Name = "Adidas",
                Order = 2,
                ParentId = 1
            },
            new Section
            {
                Id = 5,
                Name = "Puma",
                Order = 3,
                ParentId = 1
            },
            new Section
            {
                Id = 6,
                Name = "ASICS",
                Order = 4,
                ParentId = 1
            },
            new Section
            {
                Id = 7,
                Name = "Mens",
                Order = 1,
                ParentId = null
            },
            new Section
            {
                Id = 8,
                Name = "Fendi",
                Order = 0,
                ParentId = 7
            },
            new Section
            {
                Id = 9,
                Name = "Guess",
                Order = 1,
                ParentId = 7
            },
            new Section
            {
                Id = 10,
                Name = "Valentino",
                Order = 2,
                ParentId = 7
            },
            new Section
            {
                Id = 11,
                Name = "Dior",
                Order = 3,
                ParentId = 7
            },
            new Section
            {
                Id = 12,
                Name = "Versace",
                Order = 4,
                ParentId = 7
            },
            new Section
            {
                Id = 13,
                Name = "Armani",
                Order = 5,
                ParentId = 7
            },
            new Section
            {
                Id = 14,
                Name = "Prada",
                Order = 6,
                ParentId = 7
            },
            new Section
            {
                Id = 15,
                Name = "Dolce and Gabbana",
                Order = 7,
                ParentId = 7
            },
            new Section
            {
                Id = 16,
                Name = "Chanel",
                Order = 8,
                ParentId = 7
            },
            new Section
            {
                Id = 17,
                Name = "Gucci",
                Order = 1,
                ParentId = 7
            },
            new Section
            {
                Id = 18,
                Name = "Womens",
                Order = 2,
                ParentId = null
            },
            new Section
            {
                Id = 19,
                Name = "Fendi",
                Order = 0,
                ParentId = 18
            },
            new Section
            {
                Id = 20,
                Name = "Guess",
                Order = 1,
                ParentId = 18
            },
            new Section
            {
                Id = 21,
                Name = "Valentino",
                Order = 2,
                ParentId = 18
            },
            new Section
            {
                Id = 22,
                Name = "Dior",
                Order = 3,
                ParentId = 18
            },
            new Section
            {
                Id = 23,
                Name = "Versace",
                Order = 4,
                ParentId = 18
            },
            new Section
            {
                Id = 24,
                Name = "Kids",
                Order = 3,
                ParentId = null
            },
            new Section
            {
                Id = 25,
                Name = "Fashion",
                Order = 4,
                ParentId = null
            },
            new Section
            {
                Id = 26,
                Name = "Households",
                Order = 5,
                ParentId = null
            },
            new Section
            {
                Id = 27,
                Name = "Interiors",
                Order = 6,
                ParentId = null
            },
            new Section
            {
                Id = 28,
                Name = "Clothing",
                Order = 7,
                ParentId = null
            },
            new Section
            {
                Id = 29,
                Name = "Bags",
                Order = 8,
                ParentId = null
            },
            new Section
            {
                Id = 30,
                Name = "Shoes",
                Order = 9,
                ParentId = null
            },
        };

        public static IEnumerable<Brand> Brands { get; } = new[]
        {
            new Brand()
            {
                Id = 1,
                Name = "Acne",
                Order = 0
            },
            new Brand()
            {
                Id = 2,
                Name = "Grüne Erde",
                Order = 1
            },
            new Brand()
            {
                Id = 3,
                Name = "Albiro",
                Order = 2
            },
            new Brand()
            {
                Id = 4,
                Name = "Ronhill",
                Order = 3
            },
            new Brand()
            {
                Id = 5,
                Name = "Oddmolly",
                Order = 4
            },
            new Brand()
            {
                Id = 6,
                Name = "Boudestijn",
                Order = 5
            },
            new Brand()
            {
                Id = 7,
                Name = "Rösch creative culture",
                Order = 6
            },
        };

        public static IEnumerable<Product> Products { get; } = new[]
        {
            new Product 
            {
                Id = 1,
                Name = "White Dress",
                Price = 29.99M,
                ImageUrl = "product1.jpg",
                Order = 0,
                SectionId = 2,
                BrandId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Pink Dress",
                Price = 49.99M,
                ImageUrl = "product2.jpg",
                Order = 1,
                SectionId = 2,
                BrandId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Red Dress",
                Price = 49.99M,
                ImageUrl = "product3.jpg",
                Order = 2,
                SectionId = 2,
                BrandId = 1
            },
            new Product
            {
                Id = 4,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product4.jpg",
                Order = 3,
                SectionId = 2,
                BrandId = 1
            },
            new Product
            {
                Id = 5,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product5.jpg",
                Order = 4,
                SectionId = 2,
                BrandId = 2
            },
            new Product
            {
                Id = 6,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product6.jpg",
                Order = 5,
                SectionId = 2,
                BrandId = 2
            },
            new Product
            {
                Id = 7,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product7.jpg",
                Order = 6,
                SectionId = 2,
                BrandId = 2
            },
            new Product
            {
                Id = 8,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product8.jpg",
                Order = 7,
                SectionId = 25,
                BrandId = 2
            },
            new Product
            {
                Id = 9,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product9.jpg",
                Order = 8,
                SectionId = 25,
                BrandId = 2
            },
            new Product
            {
                Id = 10,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product10.jpg",
                Order = 9,
                SectionId = 25,
                BrandId = 3
            },
            new Product
            {
                Id = 11,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product11.jpg",
                Order = 10,
                SectionId = 25,
                BrandId = 3
            },
            new Product
            {
                Id = 12,
                Name = "Easy Polo Black Edition",
                Price = 59.99M,
                ImageUrl = "product12.jpg",
                Order = 11,
                SectionId = 25,
                BrandId = 3
            },
        };
    }
}

