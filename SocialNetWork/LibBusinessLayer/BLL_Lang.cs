using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllLang
    {
        #region[Get-Data]
        public DataTable GetLang(string Lang_Code)
        {
            return DalLang.GetLang(Lang_Code);
        }
        public DataTable GetLanguage(string Lang_Code)
        {
            return DalLang.GetLanguage(Lang_Code);
        }
        #endregion
    }
}