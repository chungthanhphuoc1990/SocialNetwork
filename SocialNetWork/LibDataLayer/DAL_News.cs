using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalNews
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetNews(string keywords, int TotalTop)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("TotalTop", TotalTop);
            return Cls.GetData("sp_News_Get_HomePage");
        }
        public static DataTable GetNewsCount()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_News_Get_HomePageCount");
        }
        public static DataTable GetLike()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_Likes_Get");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Like(DTOLikes obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("Likes", obj.Likes);
            Cls.AddParameter("IP_User", obj.IP_User);
            return Cls.ExecuteNonQuery("sp_News_Like");
        }
        public static bool UnLike(DTOLikes obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("Likes", obj.Likes);
            Cls.AddParameter("IP_User", obj.IP_User);
            return Cls.ExecuteNonQuery("sp_News_UnLike");
        }
        #endregion
    }

    public class DTONews
    {
        public int ID_News { get; set; }
        public string Titile { get; set; }
        public string Img { get; set; }
        public string ShortContent { get; set; }
        public string Descriptions { get; set; }
        public int AccountID { get; set; }
        public int Likes { get; set; }
    }
    public class DTOLikes
    {
        public int ID_News { get; set; }
        public int Likes { get; set; }
        public string IP_User { get; set; }
    }
}