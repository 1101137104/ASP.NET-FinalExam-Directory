using DirectoryCore.Dao.Base;
using DirectoryCore.Dao.Mapper;
using DirectoryCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCore.Dao.Impl
{
    public class DirectoryDao : GenericDao<Directory>,IDirectoryDao
    {
        override protected IRowMapper<Directory> GetRowMapper()
        {
            return new DirectoryRowMapper();
        }

        public void AddDirectory(Directory directory)
        {
            string command = @"INSERT INTO FriendDirectory (FriendDirectory_name, FriendDirectory_gender, FriendDirectory_identity, FriendDirectory_tele, FriendDirectory_email, FriendDirectory_lineId) VALUES (@FriendDirectory_name,@FriendDirectory_gender,@FriendDirectory_identity,@FriendDirectory_tele,@FriendDirectory_email,@FriendDirectory_lineId);";

            IDbParameters parameters = CreateDbParameters();

            parameters.Add("FriendDirectory_name", DbType.String).Value = directory.FriendDirectory_name;
            parameters.Add("FriendDirectory_gender", DbType.String).Value = directory.FriendDirectory_gender;
            parameters.Add("FriendDirectory_identity", DbType.String).Value = directory.FriendDirectory_identity;
            parameters.Add("FriendDirectory_tele", DbType.Int64).Value = directory.FriendDirectory_tele;
            parameters.Add("FriendDirectory_email", DbType.String).Value = directory.FriendDirectory_email;
            parameters.Add("FriendDirectory_lineId", DbType.String).Value = directory.FriendDirectory_lineId;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateDirectory(Directory directory)
        {
            string command = @"UPDATE FriendDirectory SET FriendDirectory_name = @FriendDirectory_name, FriendDirectory_gender = @FriendDirectory_gender , FriendDirectory_identity = @FriendDirectory_identity, FriendDirectory_tele = @FriendDirectory_tele, FriendDirectory_email = @FriendDirectory_email, FriendDirectory_lineId = @FriendDirectory_lineId WHERE FriendDirectory_id  = @FriendDirectory_id ;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("FriendDirectory_id", DbType.Int64).Value = directory.FriendDirectory_id;
            parameters.Add("FriendDirectory_name", DbType.String).Value = directory.FriendDirectory_name;
            parameters.Add("FriendDirectory_gender", DbType.String).Value = directory.FriendDirectory_gender;
            parameters.Add("FriendDirectory_identity", DbType.String).Value = directory.FriendDirectory_identity;
            parameters.Add("FriendDirectory_tele", DbType.Int64).Value = directory.FriendDirectory_tele;
            parameters.Add("FriendDirectory_email", DbType.String).Value = directory.FriendDirectory_email;
            parameters.Add("FriendDirectory_lineId", DbType.String).Value = directory.FriendDirectory_lineId;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteDirectory(Directory directory)
        {
            string command = @"DELETE FROM FriendDirectory WHERE FriendDirectory_id = @FriendDirectory_id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("FriendDirectory_id", DbType.Int64).Value = directory.FriendDirectory_id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Directory> GetAllDirectory()
        {
            string command = @"SELECT * FROM FriendDirectory ORDER BY FriendDirectory_id ASC";
            IList<Directory> directory = ExecuteQueryWithRowMapper(command);
            return directory;
        }

        public Directory GetDirectoryByName(string name)
        {
            string command = @"SELECT * FROM FriendDirectory WHERE FriendDirectory_name = @FriendDirectory_name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("FriendDirectory_name", DbType.String).Value = name;

            IList<Directory> directory = ExecuteQueryWithRowMapper(command, parameters);
            if (directory.Count > 0)
            {
                return directory[0];
            }

            return null;
        }

        public Directory GetDirectoryById(Int64 id)
        {
            string command = @"SELECT * FROM FriendDirectory WHERE FriendDirectory_id = @FriendDirectory_id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("FriendDirectory_id", DbType.Int64).Value = id;

            IList<Directory> directory = ExecuteQueryWithRowMapper(command, parameters);
            if (directory.Count > 0)
            {
                return directory[0];
            }

            return null;
        }
    }
}
