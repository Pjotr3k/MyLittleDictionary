using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLittleDic.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IO;

namespace MyLittleDic.Pages
{
    public class AddEntriesModel : PageModel
    {
        public List<Language> Langs = new List<Language>();
        public List<PartOfSpeech> Parts = new List<PartOfSpeech>();
        public List<Form> forms = new List<Form>();
        public List<Definition> Defs = new List<Definition>();

        public void OnPost()
        {
            int entryId;
            int lang = Convert.ToInt32(Request.Form["language"]);
            int pos = Convert.ToInt32(Request.Form["pos"]);
            string word = Request.Form["lemma"];
            string definition = Request.Form["definition"];

            Word lemma = new Word();
            Entry entry = new Entry();
            Form formLemma = new Form();
            Definition def = new Definition();
            ConnectEntryDef ced = new ConnectEntryDef();


            entryId = entry.AddEntry(lang, pos, word);

            forms = formLemma.GetPosFormsByLang(lang, pos, true);

            foreach(var forma in forms)
            {
                lemma.AddWord(forma.idForm, entryId, word);
            }

            Defs = def.GetDefinitionByDescr(definition);

            if (Defs.Count == 0)
            {
                def.AddDefinition(definition);
                Defs = def.GetDefinitionByDescr(definition);
            }

            ced.ConnectEntryMeaning(Defs.First().idDef, entryId);



            //lemma.AddWord();


        }

        public void OnGet()
        {
            Language lang = new Language();
            Langs = lang.GetLanguages();

            PartOfSpeech pos = new PartOfSpeech();
            Parts = pos.GetPartsOfSpeech();

            Definition def = new Definition();
            Defs = def.GetDefinitions();
        }
    }
}
