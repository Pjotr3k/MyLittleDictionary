using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLittleDic.Models;

namespace MyLittleDic.Interfaces
{

    public interface IEntryRepository
    {
        ICollection<Entry> GetEntries();
    }
}
