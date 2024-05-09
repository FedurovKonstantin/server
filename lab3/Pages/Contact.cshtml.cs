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
    public class ContactModel : PageModel
    {

        [BindProperty]
        public ContactFormModel ContactForm { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string csvFilePath = "zayavki.csv";
            SaveFormDataToCsv(csvFilePath);

            return RedirectToPage("/index");
        }

        private void SaveFormDataToCsv(string filePath)
        {

            using (var writer = new StreamWriter(filePath, append: true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var isEmpty = new FileInfo(filePath).Length == 0;

                if (isEmpty)
                {
                    csv.WriteHeader<ContactFormModel>();
                    csv.NextRecord();
                }

                Console.WriteLine(ContactForm);

                csv.WriteRecord(ContactForm);
                csv.NextRecord();
            }
        }

        public class ContactFormModel
        {
            [Name("First Name")]
            public string FirstName { get; set; }

            [Name("Last Name")]
            public string LastName { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            public string Phone { get; set; }

            [Name("Select Service")]
            public string SelectService { get; set; }

            [Name("Select Price")]
            public string SelectPrice { get; set; }

            public string Comments { get; set; }
        }
    }

}
