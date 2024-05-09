using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab3.Pages
{
    public class IndexModel : PageModel
    {

        public List<testimonial> Testimonials;

        private TestimonialsDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, TestimonialsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Testimonials = _context.testimonialsList();
        }
    }

}
