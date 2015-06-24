using Spring.Core;
using DirectoryCore.Core;
using NUnit.Core;
using Spring.Data.Core;


using DirectoryCore.Models;
using DirectoryCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Context;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCoreTests.Services.Impl
{
    [TestClass]
    public class DirectoryServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/DirectoryCoreDatabase.xml",
                    "~/Config/DirectoryCorePointcut.xml",
                    "~/Config/DirectoryCoreTests.xml" 
                };
            }
        }

        #endregion

        public IDirectoryService DirectoryService { get; set; }

        [TestMethod]
        public void TestDirectoryService_AddDirectory()
        {

            Directory directory = new Directory();
            directory.FriendDirectory_id = 1;
            directory.FriendDirectory_name = "單元測試";
            directory.FriendDirectory_gender = "請做出單元測試";
            DirectoryService.AddDirectory(directory);

            Directory dbDirectory = DirectoryService.GetDirectoryByName(directory.FriendDirectory_name);
            Assert.IsNotNull(dbDirectory);
            Assert.AreEqual(directory.FriendDirectory_name, dbDirectory.FriendDirectory_name);

            Console.WriteLine("聯絡人編號為 = " + dbDirectory.FriendDirectory_id);
            Console.WriteLine("聯絡人名稱為 = " + dbDirectory.FriendDirectory_name);
            Console.WriteLine("聯絡人性別為 = " + dbDirectory.FriendDirectory_gender);

            DirectoryService.DeleteDirectory(dbDirectory);
            dbDirectory = DirectoryService.GetDirectoryByName(directory.FriendDirectory_name);
            Assert.IsNull(dbDirectory);
        }

    }
}
