using System;
using LibBusinessLayer;

namespace Presentation.page
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchGet();
        }
        #region[Search]
        private void SearchGet()
        {
            var _html = string.Empty;
            String sSearch = Request.Params[0];
            var _clsGetUser = new BllUser();
            var _dtGetUser = _clsGetUser.GetUser(sSearch);
            if (_dtGetUser != null && _dtGetUser.Rows.Count > 0)
            {
                for (int i = 0; i < _dtGetUser.Rows.Count; i++)
                {
                    string FullName = _dtGetUser.Rows[i]["FullName"].ToString();
                    string Email = _dtGetUser.Rows[i]["Email"].ToString();
                    string UserName = _dtGetUser.Rows[i]["UserName"].ToString();
                    string User_Image = _dtGetUser.Rows[i]["User_Image"].ToString();
                    _html += "<div class='display_box' align='left'>";
                        _html += "<img src='" + User_Image +
                                 "' style='width:50px; height:50px; float:left; margin-right:6px;' />";
                        _html += "<span class='name'>" + FullName + "</span>&nbsp;<br/>";
                        _html += "<span style='font-size:9px; color:#999999'>" + UserName + "</span>&nbsp;<br/>";
                        _html += "<span style='font-size:9px; color:#999999'>" + Email + "</span>";
                    _html += "</div>";
                    Response.Write(_html);
                    //Response.Write("<div class='display_box' align='left'><img src='" + media + "' style='width:50px; height:50px; float:left; margin-right:6px;' /><span class='name'>" + username + "</span>&nbsp;<br/>" + email + "<br/><span style='font-size:9px; color:#999999'>" + country + "</span></div>");
                }
            }
        }
        #endregion
    }
}