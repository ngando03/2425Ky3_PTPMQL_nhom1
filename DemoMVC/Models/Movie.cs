﻿namespace DemoMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseData { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
