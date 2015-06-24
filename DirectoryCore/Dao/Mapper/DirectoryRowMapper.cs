using DirectoryCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCore.Dao.Mapper
{
    class DirectoryRowMapper : IRowMapper<Directory>
    {
        public Directory MapRow(IDataReader dataReader, int rowNum)
        {
            Directory target = new Directory();

            target.FriendDirectory_id = dataReader.GetInt32(dataReader.GetOrdinal("FriendDirectory_id"));
            target.FriendDirectory_name = dataReader.GetString(dataReader.GetOrdinal("FriendDirectory_name"));
            target.FriendDirectory_gender = dataReader.GetString(dataReader.GetOrdinal("FriendDirectory_gender"));
            target.FriendDirectory_identity = dataReader.GetString(dataReader.GetOrdinal("FriendDirectory_identity"));
            target.FriendDirectory_tele = dataReader.GetInt32(dataReader.GetOrdinal("FriendDirectory_tele"));
            target.FriendDirectory_email = dataReader.GetString(dataReader.GetOrdinal("FriendDirectory_email"));
            target.FriendDirectory_lineId = dataReader.GetString(dataReader.GetOrdinal("FriendDirectory_lineId"));

            return target;
        }
    }
}
