using System.Data;
using LibDataLayer;


namespace LibBusinessLayer
{
    public class BllWall
    {
        #region[Get-Data]
        public DataTable GetWall(string UserName, int TotalTop)
        {
            return DalWall.GetWall(UserName, TotalTop);
        }
        public DataTable GetWallFollower(int AccountID, int TotalTop)
        {
            return DalWall.GetWallFollower(AccountID, TotalTop);
        }
        public DataTable GetWallCount(string UserName)
        {
            return DalWall.GetWallCount(UserName);
        }
        public DataTable GetWallEdit(int Wall_ID, int AccountID1)
        {
            return DalWall.GetWallEdit(Wall_ID, AccountID1);
        }
        public DataTable GetLikeWall()
        {
            return DalWall.GetLikeWall();
        }
        public DataTable GetCheckLike(int Wall_ID, int AccountID1)
        {
            return DalWall.GetCheckLike(Wall_ID, AccountID1);
        }
        public DataTable GetStatusLike(int AccountID2)
        {
            return DalWall.GetStatusLike(AccountID2);
        }
        public DataTable GetViewAllDetail(int Wall_ID)
        {
            return DalWall.GetViewAllDetail(Wall_ID);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOWall obj)
        {
            return DalWall.Insert(obj);
        }
        public static bool Update(DTOWall obj)
        {
            return DalWall.Update(obj);
        }
        public static bool Delete(DTOWall obj)
        {
            return DalWall.Delete(obj);
        }
        public static bool Like(DTOWall obj)
        {
            return DalWall.Like(obj);
        }
        public static bool UnLike(DTOWall obj)
        {
            return DalWall.UnLike(obj);
        }
        #endregion
    }
}