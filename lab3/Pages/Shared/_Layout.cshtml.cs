using CsvHelper.Configuration.Attributes;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace lab3.Pages
{
    public class testimonial
    {
        public testimonial(int id, string quote, string description, string author, string role, string image)
        {
            this.id = id;
            this.quote = quote;
            this.description = description;
            this.author = author;
            this.role = role;
            this.image = image;
        }
        public int id { get; set; }
        public string quote { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public string role { get; set; }
        public string image { get; set; }
    }

    public class TestimonialsDbContext : DbContext
    {

        public TestimonialsDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kostya;Username=kostya;Password=;");
        }


        public DbSet<testimonial> testimonials { get; set; }

        public List<testimonial> testimonialsList()
        {
            return testimonials.ToList();
        }
    }

}
