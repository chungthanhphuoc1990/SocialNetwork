using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllWallComment
    {
        #region[Get-Data]
        public DataTable GetWallComment(int Wall_ID, int TotalTop)
        {
            return DalWallComment.GetWallComment(Wall_ID, TotalTop);
        }
        public DataTable GetWallCommentCount(int Wall_ID)
        {
            return DalWallComment.GetWallCommentCount(Wall_ID);
        }
        public DataTable GetWallCommentEdit(int WallComment_ID)
        {
            return DalWallComment.GetWallCommentEdit(WallComment_ID);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOWallComment obj)
        {
            return DalWallComment.Insert(obj);
        }
        public static bool Delete(DTOWallComment obj)
        {
            return DalWallComment.Delete(obj);
        }
        #endregion
    }
}