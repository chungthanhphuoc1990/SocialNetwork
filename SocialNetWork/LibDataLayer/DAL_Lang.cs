using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalLang
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetLang(string Lang_Code)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Lang_Code", Lang_Code);
            return Cls.GetData("sp_LangFuncPage_Get");
        }
        public static DataTable GetLanguage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Languages_Get");
        }
        #endregion
    }
}