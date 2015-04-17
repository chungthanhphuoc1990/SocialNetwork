using System;
using System.Data;
using System.Web.UI.WebControls;
using LibBusinessLayer;
using LibDataLayer;

namespace Presentation.modules
{
    public partial class plugin_follower : System.Web.UI.UserControl
    {
        #region[Define]
        protected string _htmlGetUser = string.Empty;
        protected string _ErrorFollower = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserFollower();
            }
        }
        protected void btnSearchFriend_Click(object sender, EventArgs e)
        {
            GetUserFollower();
        }
        protected void ListViewAll_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var lbID = ((Label)e.Item.FindControl("lbID"));
            if (e.CommandName == "_btnFollow")
            {
                GetUserFollowerView(int.Parse(lbID.Text));
                InsertFollower(int.Parse(lbID.Text));
                LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalFollower");
            }
        }
        protected void ListViewAll_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //var lbID = (Label)e.Item.FindControl("lbID");
                var btnFollow = (Button)e.Item.FindControl("btnFollow");
                var lb_lst_Img = (Image) e.Item.FindControl("lb_lst_Img");
                var lbUrl = (Label) e.Item.FindControl("lbUrl");
                if (Session["login"] != null && Session["FullName1"] != null && Session["FullName"] != null &&
                    Session["AccountID"] != null)
                {
                    btnFollow.Enabled = true;
                }
                else
                {
                    btnFollow.Enabled = false;
                }
            }
        }
        #endregion

        #region[Method]
        private void GetUserFollower()
        {
            if (Session["login"] == null && Session["UserName"] == null && Session["AccountID"] == null)
            {
                var _clsGetUserFollower = new BllUser();
                if (String.IsNullOrEmpty(txtSearchFriend.Value))
                {
                    var _dtGetUserFollower = _clsGetUserFollower.GetUser(string.Empty);
                    if (_dtGetUserFollower != null && _dtGetUserFollower.Rows.Count > 0)
                    {

                        ListViewAll.DataSource = _dtGetUserFollower;
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
                    var _dtGetUserFollower = _clsGetUserFollower.GetUser(txtSearchFriend.Value);
                    if (_dtGetUserFollower != null && _dtGetUserFollower.Rows.Count > 0)
                    {

                        ListViewAll.DataSource = _dtGetUserFollower;
                        ListViewAll.DataBind();
                        ListViewAll.Visible = true;
                    }
                    else
                    {
                        ListViewAll.Visible = false;
                    }
                }
            }
            else
            {
                var _clsGetUserFollower = new BllUser();
                if (String.IsNullOrEmpty(txtSearchFriend.Value))
                {
                    var _dtGetUserFollower = _clsGetUserFollower.GetUserFollower(string.Empty,
                        (Session["AccountID"].ToString()));
                    if (_dtGetUserFollower != null && _dtGetUserFollower.Rows.Count > 0)
                    {

                        ListViewAll.DataSource = _dtGetUserFollower;
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
                    var _dtGetUserFollower = _clsGetUserFollower.GetUserFollower(txtSearchFriend.Value,
                        (Session["AccountID"].ToString()));
                    if (_dtGetUserFollower != null && _dtGetUserFollower.Rows.Count > 0)
                    {

                        ListViewAll.DataSource = _dtGetUserFollower;
                        ListViewAll.DataBind();
                        ListViewAll.Visible = true;
                    }
                    else
                    {
                        ListViewAll.Visible = false;
                    }
                }
            }
        }
        private void GetUserFollowerView(int AccountID)
        {
            var _clsGetUserFollower = new BllUser();
            var _dtGetUserFollwer = _clsGetUserFollower.GetUserEdit(AccountID);
            if (_dtGetUserFollwer != null && _dtGetUserFollwer.Rows.Count > 0)
            {
                lbFullName.Text = _dtGetUserFollwer.Rows[0]["FullName"].ToString();
            }
        }
        private bool CheckInsert(int AccountID)
        {
            var check = false;
            var _clsCheck = new BllFollower();
            var dtCheck = _clsCheck.GetUserFollower();
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCheck.Rows)
                {
                    if (AccountID == int.Parse(dr["AccountID2"].ToString()) && Session["AccountID"].ToString() == dr["AccountID1"].ToString())
                    {
                        check = true;
                        _ErrorFollower =
                            LibAlert.Alert.AlertError("Người theo dõi này đã nằm trong danh sách của bạn");
                    }
                }
            }
            return check;
        }
        private void InsertFollower(int AccountID2)
        {
            try
            {
                if (Session["login"] != null && Session["FullName1"] != null && Session["FullName"] != null &&
                    Session["AccountID"] != null)
                {
                    if (!CheckInsert(AccountID2))
                    {

                    }
                    var obj = new DTOFollower
                    {
                        AccountID1 = int.Parse(Session["AccountID"].ToString()),
                        AccountID2 = AccountID2,
                    };
                    BllFollower.Insert(obj);
                    GetUserFollower();
                    _ErrorFollower =
                        LibAlert.Alert.AlertSucess("<b style='color:black'>" + Session["FullName"] + "</b> đã thêm <b style='color:black'>" + lbFullName.Text +
                                                   "</b> vào danh sách theo dõi !");
                }
                
            }
            catch (Exception ex)
            {
                _ErrorFollower =
                    LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình theo dõi <br/>" + ex.Message);
            }
        }
        #endregion
    }
}