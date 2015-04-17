using System;
using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalUser
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetUser(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_User_Get");
        }
        public static DataTable GetUserView(string UserName)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("UserName", UserName);
            return Cls.GetData("sp_User_Get_View");
        }
        public static DataTable GetUserEdit(int AccountID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID", AccountID);
            return Cls.GetData("sp_User_Get_Edit");
        }
        public static DataTable GetUserFollower(string keywords, string AccountID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("AccountID", AccountID);
            return Cls.GetData("sp_UserFollower_GetLogin");
        }
        public static DataTable GetUserLogin(string UserName, string Password)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("UserName", UserName);
            Cls.AddParameter("Password", Password);
            return Cls.GetData("sp_User_Login");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Email", obj.Email);
            Cls.AddParameter("FullName", obj.FullName);
            Cls.AddParameter("Password", obj.Password);
            Cls.AddParameter("UserName", obj.UserName);
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("Gender", obj.Gender);
            Cls.AddParameter("Birthday", obj.Birthday);
            Cls.AddParameter("Country_ID", obj.Country_ID);
            Cls.AddParameter("Language_ID", obj.Language_ID);
            Cls.AddParameter("User_Image", obj.User_Image);
            Cls.AddParameter("DateBegin", obj.DateBegin);
            return Cls.ExecuteNonQuery("sp_User_Insert");
        }
        public static bool Update(DTOUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID", obj.AccountID);
            Cls.AddParameter("Email", obj.Email);
            Cls.AddParameter("FullName", obj.FullName);
            Cls.AddParameter("CellPhone", obj.CellPhone);
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("Gender", obj.Gender);
            Cls.AddParameter("Birthday", obj.Birthday);
            Cls.AddParameter("Country_ID", obj.Country_ID);
            Cls.AddParameter("Language_ID", obj.Language_ID);
            Cls.AddParameter("DateBegin", obj.DateBegin);
            return Cls.ExecuteNonQuery("sp_User_Update");
        }
        public static bool UpdateAvatar(DTOUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID", obj.AccountID);
            Cls.AddParameter("User_Image", obj.User_Image);
            return Cls.ExecuteNonQuery("sp_User_Update_Avatar");
        }
        #endregion
    }

    public class DTOUser
    {
        public int AccountID { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int ? Group_Id { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int ? Country_ID { get; set; }
        public int ? Language_ID { get; set; }
        public string User_Image { get; set; }
        public DateTime Last_Login { get; set; }
        public DateTime DateBegin { get; set; }
        public int FollowerCount { get; set; }
        public string Last_Ip_Address { get; set; }
        public int FollowingCount { get; set; }
        public int TweetCount { get; set; }
        public string CellPhone { get; set; }
    }
}