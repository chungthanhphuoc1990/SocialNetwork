using System;
using System.Web.UI.WebControls;
using LibBusinessLayer;


namespace Presentation.modules
{
    public partial class plugin_top_follower : System.Web.UI.UserControl
    {
        #region[Define]
        protected string _htmlGetUser = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserTopFollower();
            }
        }
        protected void ListViewAll_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
        protected void ListViewAll_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //var lbID = (Label)e.Item.FindControl("lbID");
                var lb_lst_Img = (Image)e.Item.FindControl("lb_lst_Img");
                var lbUrl = (Label)e.Item.FindControl("lbUrl");
                if (String.IsNullOrEmpty(lbUrl.Text))
                {
                    lb_lst_Img.ImageUrl = "../img/unnamed.png";
                }
            }
        }
        #endregion

        #region[Method]
        private void GetUserTopFollower()
        {
            if (Session["login"] == null && Session["UserName"] == null && Session["AccountID"] == null)
            {
                var _clsGetUserTopFollower = new BllFollower();
                var _dtGetUserTopFollower = _clsGetUserTopFollower.GetTopUserFollower();
                if (_dtGetUserTopFollower != null && _dtGetUserTopFollower.Rows.Count > 0)
                {

                    ListViewAll.DataSource = _dtGetUserTopFollower;
                    ListViewAll.DataBind();
                    ListViewAll.Visible = true;
                }
                else
                {
                    ListViewAll.Visible = false;
                }
            }
            else
            {
                var _clsGetUserTopFollower = new BllFollower();
                var _dtGetUserTopFollower = _clsGetUserTopFollower.GetTopUserFollowerWithLogin(int.Parse(Session["AccountID"].ToString()));
                if (_dtGetUserTopFollower != null && _dtGetUserTopFollower.Rows.Count > 0)
                {

                    ListViewAll.DataSource = _dtGetUserTopFollower;
                    ListViewAll.DataBind();
                    ListViewAll.Visible = true;
                }
                else
                {
                    ListViewAll.Visible = false;
                }
            }
        }
        #endregion
    }
}