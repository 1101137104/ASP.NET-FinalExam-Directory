using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCore.Models  //11
{
    public class Directory
    {
        public Int64 FriendDirectory_id { get; set; }

        public string FriendDirectory_name { get; set; }

        public string FriendDirectory_gender { get; set; }

        public string FriendDirectory_identity { get; set; }

        public Int64 FriendDirectory_tele { get; set; }

        public string FriendDirectory_email { get; set; }

        public string FriendDirectory_lineId { get; set; }

        public override string ToString()
        {
            return "Directory: FriendDirectory_id = " + FriendDirectory_id + ", FriendDirectory_name = " + FriendDirectory_name + ", FriendDirectory_gender = " + FriendDirectory_gender + ", FriendDirectory_identity = " + FriendDirectory_identity + ", FriendDirectory_tele = " + FriendDirectory_tele + ", FriendDirectory_email = " + FriendDirectory_email + ", FriendDirectory_lineId = " + FriendDirectory_lineId + ".";
        }

    }
}
