using System.Collections;

namespace MyLittleDic.Models
{
    public class EntryCollection : ICollection<Entry>
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Entry item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Entry item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Entry[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Entry item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
