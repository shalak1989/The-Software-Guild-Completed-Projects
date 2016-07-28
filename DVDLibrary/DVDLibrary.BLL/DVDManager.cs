using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DLL;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public class DVDManager : IDVDManager
    {
        private IDVDRepository _repo;

        public DVDManager(IDVDRepository repo)
        {
            _repo = repo;
        }

        public List<DVD> GetDVDList()
        {
            var dvdList = _repo.GetAll();
            return dvdList;
        }

        public DVD GetDVD(int DVDId)
        {
            var dvd = _repo.Get(DVDId);
            return dvd;
        }

        public List<DVD> DeleteDVD(int DVDId)
        {
            _repo.Delete(DVDId);

            var newDVDList = _repo.GetAll();

            return newDVDList;
            
        }

        public List<DVD> AddDVD(DVD DVD)
        {
            _repo.Add(DVD);

            var newDVDList = _repo.GetAll();

            return newDVDList;

        }
    }
}
