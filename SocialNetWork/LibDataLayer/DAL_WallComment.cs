using System;
using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalWallComment
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetWallComment(int Wall_ID, int TotalTop)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", Wall_ID);
            Cls.AddParameter("TotalTop", TotalTop);
            return Cls.GetData("sp_WallComment_Get");
        }
        public static DataTable GetWallCommentCount(int Wall_ID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", Wall_ID);
            return Cls.GetData("sp_WallComment_GetCount");
        }
        public static DataTable GetWallCommentEdit(int WallComment_ID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("WallComment_ID", WallComment_ID);
            return Cls.GetData("sp_WallComment_Get_Edit");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOWallComment obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", obj.Wall_ID);
            Cls.AddParameter("AccountID", obj.AccountID);
            Cls.AddParameter("Content", obj.Content);
            return Cls.ExecuteNonQuery("sp_WallComment_Insert");
        }
        public static bool Delete(DTOWallComment obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("WallComment_ID", obj.WallComment_ID);
            return Cls.ExecuteNonQuery("sp_WallComment_Delete");
        }
        #endregion
    }
    public class DTOWallComment
    {
        public int WallComment_ID { get; set; }
        public int Wall_ID { get; set; }
        public int AccountID { get; set; }
        public string Content { get; set; }
        public DateTime DateCreate { get; set; }
        public int Flag { get; set; }
    }
}