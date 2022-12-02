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
        public Entry entry = new Entry();
        string code;
        public int idEntry;
        public string urlControl = "AddWords?";


        public void OnGet()
        {
            int idEntry = Convert.ToInt32(Request.Query["entry"]);
            Entry cEntr = new Entry();
            Form cForma = new Form();
            Word cWord = new Word();

            entry = cEntr.GetEntryById(idEntry).First();
            langForms = cForma.GetPosFormsByLang(entry.idLanguage, entry.idPos);
            wordList = cWord.GetWordsByEntry(entry.idEntry);

            


        }

        public void OnPost()
        {
            Word aWord = new Word();
            aWord.idEntry = Convert.ToInt32(Request.Form["AddWord"]);
            aWord.word = Request.Form["word"].ToString();
            aWord.idForm = Convert.ToInt32(Request.Form["form"]);

            Console.Write("idForm" + aWord.idForm);
            Console.Write("idEntry" + aWord.idEntry);
            Console.Write("word" + aWord.word);

            aWord.AddWord(aWord.idForm, aWord.idEntry, aWord.word);
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
