using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalCountry
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetCountry(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Country_Get");
        }
        #endregion
    }
}