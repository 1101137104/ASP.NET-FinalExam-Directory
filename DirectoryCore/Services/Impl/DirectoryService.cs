using DirectoryCore.Dao;
using DirectoryCore.Dao.Impl;
using DirectoryCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCore.Services.Impl
{
    public class DirectoryService : IDirectoryService
    {
        public IDirectoryDao DirectoryDao { get; set; }

        public Directory AddDirectory(Directory directory)
        {
            DirectoryDao.AddDirectory(directory);
            return GetDirectoryByName(directory.FriendDirectory_name);
        }

        public void UpdateDirectory(Directory directory)
        {
            DirectoryDao.UpdateDirectory(directory);
        }

        public void DeleteDirectory(Directory directory)
        {
            directory = DirectoryDao.GetDirectoryByName(directory.FriendDirectory_name);

            if (directory != null)
            {
                DirectoryDao.DeleteDirectory(directory);
            }
        }

        public IList<Directory> GetAllDirectory()
        {
            return DirectoryDao.GetAllDirectory();
        }

        public Directory GetDirectoryByName(string name)
        {
            return DirectoryDao.GetDirectoryByName(name);
        }

        public Directory GetDirectoryById(Int64 id)
        {
            return DirectoryDao.GetDirectoryById(id);
        }
    }
}
