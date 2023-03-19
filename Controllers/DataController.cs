﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Controllers
{
    public class DataController : Controller
    {

        public static IQueryable<Category> GetCategories()
        {
            using (var db = new ShopThoiTrangEntities3())
            {
                var query = from p in db.Categories
                            select p;
                return query.ToList().AsQueryable();
            }
        }

        public static IQueryable<Product> GetProducts(String tagname, String cate)
        {
            using (var db = new ShopThoiTrangEntities3())
            {
                var query = db.Products.AsQueryable();
                query = query.Where(p => p.active == true); // Chỉ lấy các sản phẩm có trường active bằng true
                if (!string.IsNullOrEmpty(tagname))
                {
                    query = query.Where(p => p.Tags.Any(t => t.TagName == tagname));
                }
                if (!string.IsNullOrEmpty(cate))
                {
                    query = query.Where(p => p.Category.CategoryName == cate);
                }
                return query.ToList().AsQueryable();
            }
        }
        public static IQueryable<Tag> GetTags()
        {
            using (var db= new ShopThoiTrangEntities3())
            {
                var query = from p in db.Tags
                            select p;

                return query.ToList().AsQueryable();
            }
        }
        public static IQueryable<Product> RandomProduct(IQueryable<Product> product,int n)
        {
            return product.OrderBy(x => Guid.NewGuid()).Take(n);
        }
        public static Product GetProduct(int n)
        {
            using (var db = new ShopThoiTrangEntities3())
            {
                return db.Products.SingleOrDefault(p => p.ProductID == n);
            }
        }
        public static IQueryable<ImageProduct> Image(int n)
        {
            using (var db = new ShopThoiTrangEntities3())
            {
                var query = db.ImageProducts.AsQueryable();
                query = query.Where(p => p.Product.ProductID == n);
                return query.ToList().AsQueryable();
            }
            
        }

    }
}