using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LibBusinessLayer;
using LibDataLayer;

namespace Presentation.page
{
    public partial class page_child : System.Web.UI.MasterPage
    {
        #region[Define]
        protected string _htmlFullName = string.Empty;
        protected string _htmlAvatarMain = string.Empty;
        protected string _ErrorMessages = string.Empty;
        protected string _ErrorPostMessageRequest = string.Empty;
        protected string _CountMessage = string.Empty;
        protected string _htmlLinkProfice = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            formPageChlid.Action = Request.RawUrl;
            if (Session["login"] == null && Session["UserName"] == null)
            {
                navRightLogin.Visible = false;
                nvaRightSigin.Visible = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                Response.Cache.SetNoStore();
            }
            else
            {
                if ((bool)Session["login"] == false)
                {
                    navRightLogin.Visible = false;
                    nvaRightSigin.Visible = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                    Response.Cache.SetNoStore();
                }
                else
                {
                    navRightLogin.Visible = true;
                    nvaRightSigin.Visible = false;
                    lbUserName.Text = Session["FullName"].ToString();
                }
            }
            if (Request.Params["username"] != null)
            {
                if (!IsPostBack)
                {
                    GetUserView(Request.Params["username"]);
                    GetMessage();
                    GetNewStatus();
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["login"];
            if (cookie != null)
            {
                Session["login"] = false;
                Session.RemoveAll();
                Session.Abandon();

                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                Response.Redirect("/");
                navRightLogin.Visible = false;
                nvaRightSigin.Visible = true;
            }
            else
            {
                Session["login"] = false;
                Session.RemoveAll();
                Session.Abandon();
                Response.Redirect(@"/");
                navRightLogin.Visible = false;
                nvaRightSigin.Visible = true;
            }
        }
        protected void btnProfice_Click(object sender, EventArgs e)
        {
            if (Session["login"] != null && Session["FullName1"] != null)
            {
                Response.Redirect(@"/profice/" + Session["FullName1"]);
            }
        }
        protected void btnAboutTop_Click(object sender, EventArgs e)
        {
            if (Session["login"] != null && Session["FullName1"] != null)
            {
                Response.Redirect(@"/about-p/" + Session["FullName1"]);
            }
        }
        protected void btnTimeLine_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/profice/" + lbUserNameMain.Text);
        }
        protected void btnAbout_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/about-p/" + Request.Params["username"]);
        }
        protected void btnSendMessageRequest_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lbAccountIDRequest.Text))
            {
                _ErrorPostMessageRequest = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình gửi tin nhắn !");
            }
            else if (String.IsNullOrEmpty(txtMessageRquest.Value))
            {
                _ErrorPostMessageRequest = LibAlert.Alert.AlertError("Vui lòng điền vào nội dung tin nhắn !");
            }
            else
            {
                PostMessage();
            }
        }
        protected void ListViewAll_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var SenderId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
            if (e.CommandName == "_sendMessagePopup")
            {
                GetMessageEdit(int.Parse(SenderId));
                GetMessage();
                LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalSendMessageRequest");
            }
            if (e.CommandName == "_delMessagePopup")
            {
                DeleteValue(int.Parse(SenderId));
            }
        }
        protected void ListViewAll_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var hiddenfalg = ((HtmlInputHidden)e.Item.FindControl("hiddenfalg")).Value;
                var iconNewMessage = ((HtmlImage)e.Item.FindControl("iconNewMessage"));
                if (hiddenfalg == "0")
                {
                    iconNewMessage.Visible = false;
                }
                else
                {
                    iconNewMessage.Visible = true;
                }
            }
        }
        protected void ListViewNewsStatus_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var SenderId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
            if (e.CommandName == "_newStatusPopup")
            {
                GetDetail(int.Parse(SenderId));
                LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalViewDetailNoImg");
            }
        }
        protected void ListViewNewsStatus_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        #endregion

        #region[Method]
        private void GetDetail(int Wall_ID)
        {
            var _clsGetWallDetail = new BllWall();
            var _dtGetWallDetail = _clsGetWallDetail.GetViewAllDetail(Wall_ID);
            if (_dtGetWallDetail != null && _dtGetWallDetail.Rows.Count > 0)
            {
                lb_lst_Wall_ID_ViewDetailNoImg.Text = _dtGetWallDetail.Rows[0]["Wall_ID"].ToString();
                _htmlLinkProfice = _dtGetWallDetail.Rows[0]["UserName"].ToString();
                imgAvatarNoImg.Src = _dtGetWallDetail.Rows[0]["User_Image"].ToString();
                lb_lst_UserName_ViewDetailNoImg.Text = _dtGetWallDetail.Rows[0]["FullName"].ToString();
                lb_lst_datetime_NoImages.Text = String.Format("{0:dd-MM}", _dtGetWallDetail.Rows[0]["DateBegin"]) + " lúc " +
                                                String.Format("{0:hh:mm}", _dtGetWallDetail.Rows[0]["DateBegin"]);
                lb_lst_titile_ViewDetailNoImg.Text = _dtGetWallDetail.Rows[0]["Wall_Titile"].ToString();
                lb_lst_content_ViewDetailNoImg.Text = _dtGetWallDetail.Rows[0]["Wall_Content"].ToString();
            }
        }
        private void GetNewStatus()
        {
            if (Session["login"] != null && Session["AccountID"] != null)
            {
                var _clsGetNewStatus = new BllWall();
                var _dtGetNewstatus = _clsGetNewStatus.GetStatusLike(int.Parse(Session["AccountID"].ToString()));
                if (_dtGetNewstatus != null && _dtGetNewstatus.Rows.Count > 0)
                {
                    ListViewNewsStatus.DataSource = _dtGetNewstatus;
                    ListViewNewsStatus.DataBind();
                    ListViewNewsStatus.Visible = true;
                    ddlNewStatus.Visible = true;
                }
                else
                {
                    ListViewNewsStatus.Visible = false;
                    ddlNewStatus.Visible = false;
                }
            }
        }
        private void GetMessage()
        {
            var _clsGetMessage = new BllTweet();
            if (Session["login"] != null && Session["UserName"] != null && Session["AccountID"] != null)
            {
                var _dtGetMessage = _clsGetMessage.GetTweetMessage(int.Parse(Session["AccountID"].ToString()));
                var _dtGetCountMessage = _clsGetMessage.GetTweetCountMessage(int.Parse(Session["AccountID"].ToString()));
                if (_dtGetMessage != null && _dtGetMessage.Rows.Count > 0 &&
                    _dtGetCountMessage != null && _dtGetCountMessage.Rows.Count > 0)
                {
                    if (int.Parse(_dtGetCountMessage.Rows[0]["CountMessage"].ToString()) > 0)
                    {
                        _CountMessage = "( " + _dtGetCountMessage.Rows[0]["CountMessage"] + " )";
                    }
                    ListViewAll.DataSource = _dtGetMessage;
                    ListViewAll.DataBind();
                    ListViewAll.Visible = true;
                    btnViewMessageAll.Visible = true;
                    drmsg.Visible = true;
                }
                else
                {
                    ListViewAll.Visible = false;
                    btnViewMessageAll.Visible = false;
                    drmsg.Visible = false;
                }
            }
        }
        private void GetMessageEdit(int TweetID)
        {
            var _clsGetMessageEdit = new BllTweet();
            var _dtGetMessageEdit = _clsGetMessageEdit.GetTweetMessageEdit(TweetID);
            if (_dtGetMessageEdit != null && _dtGetMessageEdit.Rows.Count > 0)
            {
                lbAccountIDRequest.Text = _dtGetMessageEdit.Rows[0]["AccountID"].ToString();
                lbFullNameMessageRequest.Text = _dtGetMessageEdit.Rows[0]["FullName"].ToString();
                lbMsgSendMessageRequest.Text = _dtGetMessageEdit.Rows[0]["Message"].ToString();
            }
        }
        private void GetUserView(string UserName)
        {
            var _clsGetUserView = new BllUser();
            var _dtGetUserView = _clsGetUserView.GetUserView(UserName);
            if (_dtGetUserView != null && _dtGetUserView.Rows.Count > 0)
            {
                _htmlFullName = _dtGetUserView.Rows[0]["FullName"].ToString();
                lbUserNameMain.Text = _dtGetUserView.Rows[0]["UserName"].ToString();
                if (String.IsNullOrEmpty(_dtGetUserView.Rows[0]["User_Image"].ToString()) ||
                    _dtGetUserView.Rows[0]["User_Image"] == DBNull.Value)
                {
                    _htmlAvatarMain = "../img/unnamed.png";
                }
                else
                {
                    _htmlAvatarMain = _dtGetUserView.Rows[0]["User_Image"].ToString();
                } 
            }
        }
        private void PostMessage()
        {
            try
            {
                var obj = new DTOTweet { AccountID = int.Parse(Session["AccountID"].ToString()), AccountID2 = int.Parse(lbAccountIDRequest.Text), Message = txtMessageRquest.Value };
                BllTweet.Insert(obj);
                _ErrorPostMessageRequest =
                    LibAlert.Alert.AlertSucess("Bạn đã gửi tin nhắn thành công đến <b style='color:black'>" + lbFullNameMessageRequest.Text +
                                               "</b>");
            }
            catch (Exception ex)
            {
                _ErrorPostMessageRequest =
                    LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình gửi tin nhắn <br/>" + ex.Message);
            }
        }
        private void DeleteValue(int TweetID)
        {
            try
            {
                var obj = new DTOTweet {TweetID = TweetID};
                BllTweet.Delete(obj);
                GetMessage();
                lbMsgShow.Text = LibAlert.Alert.AlertSucess("Xoá thành công tin nhắn !");
                LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalMsgShow");
            }
            catch (Exception ex)
            {
                lbMsgShow.Text = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình xoá <br/>" + ex.Message);
            }
        }
        #endregion
    }
}