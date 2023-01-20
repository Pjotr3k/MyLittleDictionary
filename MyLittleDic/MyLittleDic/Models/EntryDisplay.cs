namespace MyLittleDic.Models
{
    public class EntryDisplay
    {
        public EntryDisplay(Entry entry)
        {
            Entry = entry;
        }

        private Entry Entry { get; set }
    }
}
