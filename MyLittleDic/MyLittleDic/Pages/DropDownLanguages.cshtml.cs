using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLittleDic.Models;

using static MyLittleDic.Models.Language;

namespace MyLittleDic.Pages
{
    public class DropDownLanguages : PageModel
    {
        public List<Language> Langs = new List<Language>();

        public void OnGet()
        {

            Language lang = new Language();

            Langs = lang.GetLanguages();

        }
    }
}
