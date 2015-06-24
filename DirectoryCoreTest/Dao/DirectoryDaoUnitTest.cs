using DirectoryCore.Dao;
using DirectoryCore.Models;
using DirectoryCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCoreTests.Dao
{
    [TestClass]
    public class DirectoryDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/DirectoryCoreDatabase.xml",
                    "~/Config/DirectoryCorePointcut.xml",
                    "~/Config/DirectoryCoreTests.xml" 
                };
            }
        }

        #endregion

        public IDirectoryDao DirectoryDao { get; set; }


        [TestMethod]
        public void TestCourseDao_AddCourse()
        {
            Directory directory = new Directory();
            directory.FriendDirectory_id = 1;
            directory.FriendDirectory_name = "單元測試";
            directory.FriendDirectory_gender = "請做出單元測試";
            directory.FriendDirectory_identity = "請做出單元測試";
            directory.FriendDirectory_tele = 0921177608;
            directory.FriendDirectory_email = "請做出單元測試";
            directory.FriendDirectory_lineId = "請做出單元測試";
            DirectoryDao.AddDirectory(directory);

            Directory dbDirectory = DirectoryDao.GetDirectoryByName(directory.FriendDirectory_name);
            Assert.IsNotNull(dbDirectory);
            Assert.AreEqual(directory.FriendDirectory_name, dbDirectory.FriendDirectory_name);

            Console.WriteLine("聯絡人編號為 = " + dbDirectory.FriendDirectory_id);
            Console.WriteLine("聯絡人名稱為 = " + dbDirectory.FriendDirectory_name);
            Console.WriteLine("聯絡人性別為 = " + dbDirectory.FriendDirectory_gender);
            Console.WriteLine("聯絡人身分為 = " + dbDirectory.FriendDirectory_identity);
            Console.WriteLine("聯絡人電話為 = " + dbDirectory.FriendDirectory_tele);
            Console.WriteLine("聯絡人郵件為 = " + dbDirectory.FriendDirectory_email);
            Console.WriteLine("聯絡人LINE為 = " + dbDirectory.FriendDirectory_lineId);

            DirectoryDao.DeleteDirectory(dbDirectory);
            dbDirectory = DirectoryDao.GetDirectoryByName(directory.FriendDirectory_name);
            Assert.IsNull(dbDirectory);
        }

    }
}
