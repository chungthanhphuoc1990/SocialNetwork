using System;
using System.Data;
using LibDBConnect;


namespace LibDataLayer
{
    public static class DalTweet
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetTweet()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_Tweet_Get");
        }
        public static DataTable GetTweetMessage(int AccountID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID", AccountID);
            return Cls.GetData("sp_Message_GetUser");
        }
        public static DataTable GetTweetCountMessage(int AccountID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID", AccountID);
            return Cls.GetData("sp_Message_GetUserCount");
        }
        public static DataTable GetTweetMessageEdit(int TweetID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("TweetID", TweetID);
            return Cls.GetData("sp_Message_GetUser_Edit");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOTweet obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID", obj.AccountID);
            Cls.AddParameter("AccountID2", obj.AccountID2);
            Cls.AddParameter("Message", obj.Message);
            return Cls.ExecuteNonQuery("sp_Tweet_Insert");
        }
        public static bool Delete(DTOTweet obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("TweetID", obj.TweetID);
            return Cls.ExecuteNonQuery("sp_Tweet_Delete");
        }
        #endregion
    }
    public class DTOTweet
    {
        public int TweetID { get; set; }
        public int? AccountID { get; set; }
        public int? AccountID2 { get; set; }
        public string Message { get; set; }
        public DateTime TweetDate { get; set; }
    }
}