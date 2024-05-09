using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab3.Pages
{
    [IgnoreAntiforgeryToken]
    public class PricingModel : PageModel
    {
        public List<testimonial> Testimonials;

        private TestimonialsDbContext _context;
        public PricingModel(TestimonialsDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Testimonials = _context.testimonialsList();
        }

    }
}