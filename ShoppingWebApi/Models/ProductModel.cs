﻿namespace ShoppingWebApi.Models
{
    public class ProductModel
    {

        public int id { get; set; }

        public string name { get; set; } = string.Empty;
        public string brand { get; set; } = string.Empty;
        public int Size { get; set; }

        public decimal price { get; set; }
    }
}
