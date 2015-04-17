using System.Data;
using LibDataLayer;


namespace LibBusinessLayer
{
    public class BLLComment
    {
        #region[Get-Data]
        public DataTable GetComment(int ID_News)
        {
            return DalComment.GetComment(ID_News);
        }
        #endregion
    }
}