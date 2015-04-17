using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalWall
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetWall(string UserName, int TotalTop)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("UserName", UserName);
            Cls.AddParameter("TotalTop", TotalTop);
            return Cls.GetData("sp_Wall_Get");
        }
        public static DataTable GetWallFollower(int AccountID, int TotalTop)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID", AccountID);
            Cls.AddParameter("TotalTop", TotalTop);
            return Cls.GetData("sp_Wall_GetFollower");
        }
        public static DataTable GetWallCount(string UserName)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("UserName", UserName);
            return Cls.GetData("sp_Wall_Get_Count");
        }
        public static DataTable GetWallEdit(int Wall_ID, int AccountID1)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", Wall_ID);
            Cls.AddParameter("AccountID1", AccountID1);
            return Cls.GetData("sp_Wall_Get_Edit");
        }
        public static DataTable GetLikeWall()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_LikesWall");
        }
        public static DataTable GetCheckLike(int Wall_ID, int AccountID1)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", Wall_ID);
            Cls.AddParameter("AccountID1", AccountID1);
            return Cls.GetData("sp_CheckLikes_Get");
        }
        public static DataTable GetStatusLike(int AccountID2)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("AccountID2", AccountID2);
            return Cls.GetData("sp_LikesWallToUser");
        }
        public static DataTable GetViewAllDetail(int Wall_ID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", Wall_ID);
            return Cls.GetData("sp_LikesWallViewDetail");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOWall obj)
        {
           Cls.CreateNewSqlCommand();
           Cls.AddParameter("AccountID1", obj.AccountID1);
           Cls.AddParameter("Wall_Titile", obj.Wall_Titile);
           Cls.AddParameter("Wall_Img", obj.Wall_Img);
           Cls.AddParameter("Wall_Content", obj.Wall_Content);
           return Cls.ExecuteNonQuery("sp_Wall_Insert");
        }
        public static bool Update(DTOWall obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", obj.Wall_ID);
            Cls.AddParameter("AccountID1", obj.AccountID1);
            Cls.AddParameter("Wall_Titile", obj.Wall_Titile);
            Cls.AddParameter("Wall_Img", obj.Wall_Img);
            Cls.AddParameter("Wall_Content", obj.Wall_Content);
            return Cls.ExecuteNonQuery("sp_Wall_Update");
        }
        public static bool Delete(DTOWall obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", obj.Wall_ID);
            Cls.AddParameter("AccountID1", obj.AccountID1);
            return Cls.ExecuteNonQuery("sp_Wall_Delete");
        }
        public static bool Like(DTOWall obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", obj.Wall_ID);
            Cls.AddParameter("Likes", obj.LikeCount);
            Cls.AddParameter("AccountID1", obj.AccountID1);
            Cls.AddParameter("AccountID2", obj.AccountID2);
            return Cls.ExecuteNonQuery("sp_Wall_Like");
        }
        public static bool UnLike(DTOWall obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Wall_ID", obj.Wall_ID);
            Cls.AddParameter("AccountID1", obj.AccountID1);
            Cls.AddParameter("Likes", obj.LikeCount);
            return Cls.ExecuteNonQuery("sp_Wall_UnLike");
        }
        #endregion
    }

    public class DTOWall
    {
        public int Wall_ID { get; set; }
        public int AccountID1 { get; set; }
        public int AccountID2 { get; set; }
        public string Wall_Titile { get; set; }
        public string Wall_Img { get; set; }
        public string Wall_Content { get; set; }
        public int LikeCount { get; set; }
    }
}