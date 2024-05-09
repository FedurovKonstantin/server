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
    public class Portfolio
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Filter { get; set; }
    }
    public class Service
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }


    public interface IPortfolioService
    {
        List<Portfolio> GetPortfolios();
        List<Service> GetServices();
        List<testimonial> GetTestimonials();

    }



    public class PortfolioService : IPortfolioService
    {
        private readonly string _portfolioPath;
        private readonly string _servicePath;
        private readonly string _testimonialsPath;

        public PortfolioService(
            string portfolioPath,
            string servicePath,
            string testimonialsPath
        )
        {
            _portfolioPath = portfolioPath;
            _servicePath = servicePath;
            _testimonialsPath = testimonialsPath;
        }

        public List<Portfolio> GetPortfolios()
        {
            string json = File.ReadAllText(_portfolioPath);
            List<Portfolio> portfolios = JsonConvert.DeserializeObject<List<Portfolio>>(json);
            return portfolios;
        }
        public List<Service> GetServices()
        {
            string json = File.ReadAllText(_servicePath);
            List<Service> services = JsonConvert.DeserializeObject<List<Service>>(json);
            return services;
        }


        public List<testimonial> GetTestimonials()
        {
            string json = File.ReadAllText(_testimonialsPath);
            List<testimonial> testimonials = JsonConvert.DeserializeObject<List<testimonial>>(json);
            return testimonials;
        }

    }


    [IgnoreAntiforgeryToken]
    public class PortfolioModel : PageModel
    {

        private readonly IPortfolioService _portfiloService;
        private readonly TestimonialsDbContext _testimonialsDbContext;

        public List<Portfolio> Portfolios { get; set; }
        public List<testimonial> Testimonials { get; set; }
        public List<Service> Services { get; set; }

        public PortfolioModel(
            IPortfolioService portfiloService,
            TestimonialsDbContext testimonialsDbContext
        )
        {
            _portfiloService = portfiloService;
            _testimonialsDbContext = testimonialsDbContext;

        }

        public void OnGet()
        {
            Portfolios = _portfiloService.GetPortfolios();
            Testimonials = _testimonialsDbContext.testimonials.ToList();
            Services = _portfiloService.GetServices();
        }

    }

}
