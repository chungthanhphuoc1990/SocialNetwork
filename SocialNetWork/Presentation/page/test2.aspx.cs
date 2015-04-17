using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation.page
{
    public partial class test2 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region--Show/hide language link
            if (!string.IsNullOrEmpty(Convert.ToString(Session["lang"])))
            {
                if (Convert.ToString(Session["lang"]) == "en")
                {
                    linkVietnameseLang.Visible = true;
                    linkEnglishLang.Visible = false;
                }
                else
                {
                    linkEnglishLang.Visible = true;
                    linkVietnameseLang.Visible = false;
                }
            }
            else
            {
                linkVietnameseLang.Visible = false;
                linkEnglishLang.Visible = true;
            }
            #endregion--
        }
    }
}