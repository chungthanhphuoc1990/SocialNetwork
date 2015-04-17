using System.Data;
using System.Linq;
using LibBusinessLayer;

namespace LibLang
{
    public class CheckLang
    {
        public static void CheckPageParrent(string Lang_Code, string sNameLanLang_Page)
        {
            var _clsGetLang= new BllLang();
            var _dtGetLang = _clsGetLang.GetLang(Lang_Code);
            if (_dtGetLang != null && _dtGetLang.Rows.Count > 0)
            {
                sNameLanLang_Page += _dtGetLang.Rows.Cast<DataRow>().Any(drUserGetLang => drUserGetLang["Lang_Code"].ToString() == Lang_Code);
            }
        }
    }
}