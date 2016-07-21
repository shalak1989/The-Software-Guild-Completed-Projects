using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DLL;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public static class DVDManager
    {
        public static List<DVD> GetDVDList()
        {
            var dvdList = DVDRepository.GetAll();
            return dvdList;
        }

        public static DVD GetDVD(int DVDId)
        {
            var dvd = DVDRepository.Get(DVDId);
            return dvd;
        }

        public static List<DVD> DeleteDVD(int DVDId)
        {
            DVDRepository.Delete(DVDId);

            var newDVDList = DVDRepository.GetAll();

            return newDVDList;
            
        }

        public static List<DVD> AddDVD(DVD DVD)
        {
            var dvdListForCount = DVDRepository.GetAll();
            var dvdIdCount = dvdListForCount.Max(d => d.DVDId);

            var newDvdId = dvdIdCount + 1;

            DVD.DVDId = newDvdId;
            DVDRepository.Add(DVD);

            var newDVDList = DVDRepository.GetAll();

            return newDVDList;

        }
    }
}
