using System.Data;
using LibDataLayer;


namespace LibBusinessLayer
{
    public class BllUser
    {
        #region[Get-Data]
        public DataTable GetUser(string keywords)
        {
            return DalUser.GetUser(keywords);
        }
        public DataTable GetUserView(string UserName)
        {
            return DalUser.GetUserView(UserName);
        }
        public DataTable GetUserEdit(int AccountID)
        {
            return DalUser.GetUserEdit(AccountID);
        }
        public DataTable GetUserFollower(string keywords, string AccountID)
        {
            return DalUser.GetUserFollower(keywords, AccountID);
        }
        public DataTable GetUserLogin(string UserName, string Password)
        {
            return DalUser.GetUserLogin(UserName, Password);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOUser obj)
        {
            return DalUser.Insert(obj);
        }
        public static bool Update(DTOUser obj)
        {
            return DalUser.Update(obj);
        }
        public static bool UpdateAvatar(DTOUser obj)
        {
            return DalUser.UpdateAvatar(obj);
        }
        #endregion
    }
}