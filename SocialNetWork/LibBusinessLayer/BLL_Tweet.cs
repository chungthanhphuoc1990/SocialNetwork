using System.Data;
using LibDataLayer;
namespace LibBusinessLayer
{
    public class BllTweet
    {
        #region[Get-Data]
        public DataTable GetTweet()
        {
            return DalTweet.GetTweet();
        }
        public DataTable GetTweetMessage(int AccountID)
        {
            return DalTweet.GetTweetMessage(AccountID);
        }
        public DataTable GetTweetCountMessage(int AccountID)
        {
            return DalTweet.GetTweetCountMessage(AccountID);
        }
        public DataTable GetTweetMessageEdit(int TweetID)
        {
            return DalTweet.GetTweetMessageEdit(TweetID);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOTweet obj)
        {
            return DalTweet.Insert(obj);
        }
        public static bool Delete(DTOTweet obj)
        {
            return DalTweet.Delete(obj);
        }
        #endregion
    }
}