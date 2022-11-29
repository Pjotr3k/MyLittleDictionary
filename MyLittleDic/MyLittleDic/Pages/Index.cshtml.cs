using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLittleDic.Models;

namespace MyLittleDic.Pages
{
    public class IndexModel : PageModel
    {
        public Form form = new Form();
        public Word word = new Word();

        public List<Entry> entries = new List<Entry>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Entry entry = new Entry();
            entries = entry.GetEntries();

        }
    }
}