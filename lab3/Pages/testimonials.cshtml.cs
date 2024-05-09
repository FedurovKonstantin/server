using CsvHelper.Configuration.Attributes;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;
using System.Threading.Tasks;

namespace lab3.Pages
{
    [IgnoreAntiforgeryToken]
    public class TestimonialsModel : PageModel
    {

        public TestimonialsModel(TestimonialsDbContext context)
        {
            _context = context;
        }
        public List<testimonial> Testimonials;

        private TestimonialsDbContext _context;

        [BindProperty]
        public TestimonialsFormModel TestimonialsForm { get; set; }

        public void OnGet()
        {
            Testimonials = _context.testimonialsList();
        }

        public async Task<IActionResult> OnPostAsync()
        {


            _context.Add<testimonial>(
                new testimonial(Guid.NewGuid().GetHashCode(),
                TestimonialsForm.Quote,
                TestimonialsForm.Description,
                TestimonialsForm.Author,
                TestimonialsForm.Role,
                "uploads/testi_01.png")
            );
            _context.SaveChanges();

            return RedirectToPage("/index");
        }

        public class TestimonialsFormModel
        {
            public string Author { get; set; }

            public string Role { get; set; }

            public string Quote { get; set; }

            public string Description { get; set; }

        }
    }

}
