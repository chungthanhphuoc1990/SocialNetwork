using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllGetNews
    {
        #region[Get-Data]
        public DataTable GetNews(string keywords, int TotalTop)
        {
            return DalNews.GetNews(keywords, TotalTop);
        }
        public DataTable GetNewsCount()
        {
            return DalNews.GetNewsCount();
        }
        public DataTable GetLike()
        {
            return DalNews.GetLike();
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Like(DTOLikes obj)
        {
            return DalNews.Like(obj);
        }
        public static bool UnLike(DTOLikes obj)
        {
            return DalNews.UnLike(obj);
        }
        #endregion
    }
}