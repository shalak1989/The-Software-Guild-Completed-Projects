using System.Collections.Generic;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public interface IDVDManager
    {
        List<DVD> AddDVD(DVD DVD);
        List<DVD> DeleteDVD(int DVDId);
        DVD GetDVD(int DVDId);
        List<DVD> GetDVDList();
    }
}