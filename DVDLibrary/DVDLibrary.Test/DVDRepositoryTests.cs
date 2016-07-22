using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DVDLibrary.BLL;
using DVDLibrary.DLL;
using DVDLibrary.Models;

namespace DVDLibrary.Test
{
    [TestFixture]
    public class DVDRepositoryTests
    {
        [Test]
        public void DVDAddWorks()
        {
            
            var repo = new FakeDVDRepository();
            var mgr = new DVDManager(repo);

            DVD dvd = new DVD();

            dvd.Title = "test";

            var response = mgr.AddDVD(dvd);
            var dvdList = mgr.GetDVDList();

            Assert.AreEqual(dvd.DVDId, 4);
            Assert.AreEqual(dvdList.Count, 4);
        }

        [Test]
        public void DVDDeleteWorks()
        {

            var repo = new FakeDVDRepository();
            var mgr = new DVDManager(repo);

            var response = mgr.DeleteDVD(1);

            var dvdList = mgr.GetDVDList();

            Assert.AreEqual(2, dvdList.Count);
            Assert.AreEqual(2, dvdList.ElementAt(0).DVDId);
        }

        [Test]
        public void ListDVDWorks()
        {

            var repo = new FakeDVDRepository();
            var mgr = new DVDManager(repo);

            var response = mgr.GetDVDList();

            Assert.AreEqual(3, response.Count);
            Assert.AreEqual(1, response.ElementAt(0).DVDId);
        }

        [Test]
        public void GetIndividualDVD()
        {

            var repo = new FakeDVDRepository();
            var mgr = new DVDManager(repo);

            var response = mgr.GetDVD(2);

            Assert.AreEqual(2, response.DVDId);
        }

    }
}
