using DirectoryCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCore.Dao
{
    public interface IDirectoryDao
    {
        void AddDirectory(Directory directory);

        void UpdateDirectory(Directory directory);

        void DeleteDirectory(Directory directory);

        IList<Directory> GetAllDirectory();

        Directory GetDirectoryByName(string name);

        Directory GetDirectoryById(Int64 id);
    }
}
