using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllFollower
    {
        #region[Get-Data]
        public DataTable GetUserFollower()
        {
            return DalFollower.GetUserFollower();
        }
        public DataTable GetTopUserFollower()
        {
            return DalFollower.GetTopUserFollower();
        }
        public DataTable GetTopUserFollowerWithLogin(int AccountID)
        {
            return DalFollower.GetTopUserFollowerWithLogin(AccountID);
        }
        public DataTable GetWallFollow(int AccountID1)
        {
            return DalFollower.GetWallFollow(AccountID1);
        }
        public DataTable GetWallFollowCount(int AccountID1)
        {
            return DalFollower.GetWallFollowCount(AccountID1);
        }
        public DataTable GetFollowerSendMessage(int AccountID1, int AccountID2)
        {
            return DalFollower.GetFollowerSendMessage(AccountID1, AccountID2);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOFollower obj)
        {
            return DalFollower.Insert(obj);
        }
        #endregion
    }
}