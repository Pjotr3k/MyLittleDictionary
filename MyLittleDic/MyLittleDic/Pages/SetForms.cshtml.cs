using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLittleDic.Models;
using System.Runtime.CompilerServices;

namespace MyLittleDic.Pages
{
    public class SetFormsModel : PageModel
    {
        public string idLanguage { get; set; }
        public string idPos { get; set; }
        public Language lang = new Language();
        public PartOfSpeech pos = new PartOfSpeech();
        Form forma = new Form();
        public List<Form> langForms = new List<Form>();
        public List<Word> wordList = new List<Word>();
        Entry entry = new Entry();
        string code;
        public int idEntry;
        public string urlControl = "AddWords?";


        public void OnGet()
        {
            idLanguage = Request.Query["idLang"];
            idPos = Request.Query["idPos"];

            lang = lang.GetLanguageById(Convert.ToInt32(idLanguage));
            pos = pos.GetPartOfSpeechById(Convert.ToInt32(idPos));

            langForms = forma.GetPosFormsByLang(Convert.ToInt32(idLanguage), Convert.ToInt32(idPos));

            urlControl += "usedForms=";

            foreach(var elem in langForms)
            {
                urlControl += elem.idForm.ToString() + "w";
            }
            //urlControl += ""


        }

        public void OnPost()
        {
            //string lemma //= langForms[0].ToString(); //Request.Form[langForms[0].idForm.ToString()];
            //code = GenerateCode(idLanguage, idPos, lemma);

            //idEntry = entry.AddEntry(5, 2, lemma);
            //idEntry = entry.AddEntry(Convert.ToInt32(idLanguage), Convert.ToInt32(idPos), code);

            foreach (var form in langForms)
            {
                Word word = new Word();
                word.idEntry = idEntry;
                word.idForm = form.idForm;
                word.word = Request.Form[form.idForm.ToString()];

                wordList.Add(word);
            }
        }

        /*public string GenerateCode(string langid, string posid, string form)
        {
            return langid + "." + posid + "." + form;
        }*/

      
    }

    /*public void ProcessData()
    {

    }*/
}
