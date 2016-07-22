using System.Collections.Generic;
using DVDLibrary.Models;

namespace DVDLibrary.DLL
{
    public interface IDVDRepository
    {
        void Add(DVD DVD);
        void Delete(int DVDId);
        DVD Get(int DVDId);
        List<DVD> GetAll();
    }
}