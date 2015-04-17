using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllConutry
    {
        #region[Get-Data]
        public DataTable GetConutry(string keywords)
        {
            return DalCountry.GetCountry(keywords);
        }
        #endregion
    }
}