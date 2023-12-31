﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TazaFood_Core.Models;
using TazaFood_Core.Models.Order_Aggregate;

namespace TazaFood_Repository.Context
{
    public static class TazaContextSeed
    {
        public static async Task Dataseeding(TazaDbContext context)
        {
            //read data of category from category json file
            //first check if there is data in the category table or not 
            if (!context.Set<Category>().Any())
            {
                var categoryData = File.ReadAllText("../TazaFood-Repository/Context/DataSeed/category.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);


                if (categories?.Count > 0 && categories is not null)
                {
                    foreach (var category in categories)
                    {
                        await context.Set<Category>().AddAsync(category);
                    }
                    await context.SaveChangesAsync();
                }
            }

            //then add product data 
            //first check if there is data in the product table or not 
            if (!context.Set<Product>().Any())
            {
                var productdata = File.ReadAllText("../TazaFood-Repository/Context/DataSeed/Products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productdata);


                if (products?.Count > 0 && products is not null)
                {
                    foreach (var product in products)
                    {
                        await context.Set<Product>().AddAsync(product);
                    }
                    await context.SaveChangesAsync();
                }
            }

            //then add delivery,ethods data
            //first check if there is data in the deliverymethods table or not
            if (!context.Set<DeliveryMethod>().Any())
            {
                var Deliverydata = File.ReadAllText("../TazaFood-Repository/Context/DataSeed/delivery.json");
                var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(Deliverydata);


                if (methods?.Count > 0 && methods is not null)
                {
                    foreach (var method in methods)
                    {
                        await context.Set<DeliveryMethod>().AddAsync(method);
                    }
                    await context.SaveChangesAsync();
                }
            }

            //then add Reviews data
            //first check if there is data in the reviews table or not
            if (!context.Set<Review>().Any())
            {
                var reviewsData = File.ReadAllText("../TazaFood-Repository/Context/DataSeed/reviews.json");
                var reviews = JsonSerializer.Deserialize<List<Review>>(reviewsData);


                if (reviews?.Count > 0 && reviews is not null)
                {
                    foreach (var review in reviews)
                    {
                        await context.Set<Review>().AddAsync(review);
                    }
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
