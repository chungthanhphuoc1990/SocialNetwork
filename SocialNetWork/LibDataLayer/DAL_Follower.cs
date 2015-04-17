using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalFollower
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetUserFollower()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_Follower_Get");
        } 
        public static DataTable GetTopUserFollower()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_Follower_GetTop");
        }
        public static DataTable GetTopUserFollowerWithLogin(int AccountID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID", AccountID);
            return Cls.GetData("sp_Follower_GetTopWithLogin");
        }
        public static DataTable GetWallFollow(int AccountID1)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID1", AccountID1);
            return Cls.GetData("sp_Follower_GetUser");
        }
        public static DataTable GetWallFollowCount(int AccountID1)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID1", AccountID1);
            return Cls.GetData("sp_Follower_GetUserCount");
        }
        public static DataTable GetFollowerSendMessage(int AccountID1, int AccountID2)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID1", AccountID1);
            Cls.AddParameter("AccountID2", AccountID2);
            return Cls.GetData("sp_Follower_GetSendMessage");
        } 
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOFollower obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID1", obj.AccountID1);
            Cls.AddParameter("AccountID2", obj.AccountID2);
            return Cls.ExecuteNonQuery("sp_Follower_Insert");
        }
        #endregion
    }

    public class DTOFollower
    {
        public int FollowerID { get; set; }
        public int? AccountID1 { get; set; }
        public int? AccountID2 { get; set; }
    }
}