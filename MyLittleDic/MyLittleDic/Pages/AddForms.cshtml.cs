using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLittleDic.Models;
using MySql.Data.MySqlClient;
using System.Web;

namespace MyLittleDic.Pages
{
    public class AddFormsModel : PageModel
    {
        Language lang = new Language();
        PartOfSpeech pos = new PartOfSpeech();
        Entry entry = new Entry();
        
        public List<Language> Langs = new List<Language>();
        public List<PartOfSpeech> Parts = new List<PartOfSpeech>();
        public List<Word> Words = new List<Word>();
        public List<Form> Forms = new List<Form>();


        public void OnPost()
        {
            int lang = Convert.ToInt32(Request.Form["language"]);
            int pos = Convert.ToInt32(Request.Form["pos"]);
            string formName = Request.Form["form"];

            Form form = new Form();

            form.AddForm(lang, pos, formName);



        }

        public void OnGet()
        {
            Form form = new Form();
            Word word = new Word();

            try {
                entry = entry.GetEntryById(Convert.ToInt32(Request.Query["entryId"])).First();
            }
            catch (System.InvalidOperationException)
            {
                Redirect("Index");
            }
            Forms = form.GetPosFormsByLang(entry.idLanguage, entry.idPos);
            Words = word.GetWordsByEntry(entry.idEntry);
            
 
            
        }
    }
}
