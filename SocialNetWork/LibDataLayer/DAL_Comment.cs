using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalComment
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetComment(int ID_News)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", ID_News);
            return Cls.GetData("sp_Comment_Get");
        }
        #endregion
    }
}