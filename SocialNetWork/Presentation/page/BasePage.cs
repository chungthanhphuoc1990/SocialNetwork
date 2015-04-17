using System.Threading;
using System.Globalization;
using System.Web;

namespace Presentation.page
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            //if (!string.IsNullOrEmpty(Request["lang"]))
            //{
            //    Session["lang"] = Request["lang"];
            //}
            //string lang = Convert.ToString(Session["lang"]);
            //string culture = string.Empty;
            //* // In case, if you want to set vietnamese as default language, then removing this comment
            //if (lang.ToLower().CompareTo("vi") == 0 || string.IsNullOrEmpty(culture))
            //{
            //    culture = "vi-VN";
            //}
            // */
            //if (lang.ToLower().CompareTo("en") == 0 || string.IsNullOrEmpty(culture))
            //{
            //    culture = "en-US";
            //}
            //if (lang.ToLower().CompareTo("vi") == 0)
            //{
            //    culture = "vi-VN";
            //}
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            //base.InitializeCulture();

            string lang = string.Empty;
            HttpCookie cookie = Request.Cookies["CurrentLanguage"];

            if (cookie != null && cookie.Value != null)
            {
                lang = cookie.Value;
                CultureInfo Cul = CultureInfo.CreateSpecificCulture(lang);

                Thread.CurrentThread.CurrentUICulture = Cul;
                Thread.CurrentThread.CurrentCulture = Cul;
            }
            else
            {
                if (string.IsNullOrEmpty(lang)) lang = "vi-VN";
                CultureInfo Cul = CultureInfo.CreateSpecificCulture(lang);

                Thread.CurrentThread.CurrentUICulture = Cul;
                Thread.CurrentThread.CurrentCulture = Cul;

                var cookie_new = new HttpCookie("CurrentLanguage") {Value = lang};
                Response.SetCookie(cookie_new);
            }

            base.InitializeCulture();
        }
    }
}