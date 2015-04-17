using System;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using LibBusinessLayer;
using System.Web.UI.WebControls;
using LibDataLayer;
using System.Data;

namespace Presentation.modules
{
    public partial class plugin_pagechild_center : System.Web.UI.UserControl
    {
        #region[Define]
        private static bool _flag;
        protected string _Error = string.Empty;
        protected string _ErrorPost = string.Empty;
        protected string _ErrorPostEdit = string.Empty;
        protected string _ErrorDel = string.Empty;
        protected string _htmlGetUserFollower = string.Empty;
        protected string _ErrorPostMessage = string.Empty;
        protected string _ErrorComment = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null && Session["FullName1"] != null && Session["FullName"] != null && Session["AccountID"] != null)
            {
                lbIDUser.Text = Session["AccountID"].ToString();
                lbIDUserEdit.Text = Session["AccountID"].ToString();
                lbUserIDDel.Text = Session["AccountID"].ToString();
            }
            if (Request.Params["username"] != null)
            {
                if (!IsPostBack)
                {
                    GetWall(Request.Params["username"], int.Parse(WebConfigurationManager.AppSettings["pageSizeWall"]));
                    GetUserView(Request.Params["username"]);
                    GetUserID(Request.Params["username"]);
                    ((HtmlAnchor)Page.Master.FindControl("btnTimeLine")).Attributes["class"] = "navbar-brand";
                    if (Session["login"] != null && Session["FullName1"] != null && Session["FullName"] != null &&
                        Session["AccountID"] != null)
                    {
                        GetUserFollowerList();
                        if (lbUserMain.Text == Session["AccountID"].ToString())
                        {
                            PostStatusPanel.Visible = true;
                            _htmlGetUserFollower = GetUserFollow();
                        }
                        else
                        {
                            PostStatusPanel.Visible = false;
                        }
                    }
                    else
                    {
                        PostStatusPanel.Visible = false;
                    }
                }
            }
        }
        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txTitilePost.Value))
            {
                _ErrorPost = LibAlert.Alert.AlertError("Vui lòng điền vào tiêu đề mà bạn muốn đăng !");
            }
            else if (String.IsNullOrEmpty(txtContentPost.Value))
            {
                _ErrorPost = LibAlert.Alert.AlertError("Vui lòng điền vào nội dung mà bạn muốn đăng !");
            }
            else
            {
                InsertValue();
            }
        }
        protected void btnPostEdit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTitilePostEdit.Value))
            {
                _ErrorPost = LibAlert.Alert.AlertError("Vui lòng điền vào tiêu đề mà bạn muốn đăng !");
            }
            else if (String.IsNullOrEmpty(txtContentPostEdit.Value))
            {
                _ErrorPost = LibAlert.Alert.AlertError("Vui lòng điền vào nội dung mà bạn muốn đăng !");
            }
            else
            {
                UpdateValue();
            }
        }
        protected void btnDelStatus_Click(object sender, EventArgs e)
        {
            if (_flag)
            {
                Delete();
            }
            else
            {
                DeleteComment();
            }
        }
        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lbAccountID2.Text))
            {
                _ErrorPostMessage = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình gửi tin nhắn !");
            }
            else if (String.IsNullOrEmpty(txtMessage.Value))
            {
                _ErrorPostMessage = LibAlert.Alert.AlertError("Vui lòng điền vào nội dung tin nhắn !");
            }
            else
            {
                PostMessage();
            }
        }
        protected void btnSendMessageClick_Click(object sender, EventArgs e)
        {
            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalSendMessage");
        }
        protected void btnViewMore_Click(object sender, EventArgs e)
        {
            GetWall(Request.Params["username"], int.Parse(lbTotal.Text) + 10);
        }
        protected void ListViewComment_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (Session["login"] != null &&
                Session["AccountID"] != null)
            {
                //DelComment
                var lbCommentWall_ID = ((Label) e.Item.FindControl("lbCommentWall_ID"));
                var lbAccountID = ((Label)e.Item.FindControl("lbAccountID"));
                if (e.CommandName == "_DelComment")
                {
                    _flag = false;
                    btnDelStatus.InnerText = "Xoá bình luận";
                    if (lbUserMain.Text == Session["AccountID"].ToString())
                    {
                        GetWallCommentEdit(int.Parse(lbCommentWall_ID.Text));
                        lbMsgDel.Text = "Bạn có chắc chắn muốn xóa lời bình luận này không ?";
                        LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalDel");
                    }
                    else if (lbAccountID.Text == Session["AccountID"].ToString())
                    {
                        GetWallCommentEdit(int.Parse(lbCommentWall_ID.Text));
                        lbMsgDel.Text = "Bạn có chắc chắn muốn xóa lời bình luận này không ?";
                        LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalDel");
                    }
                    else
                    {
                        lbMsg.Text = "Bạn không được phép xoá lời bình luận của người khác của người khác !";
                        LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                    }
                }
            }
            else
            {
                lbMsg.Text = "<b>Chương trình bị ngắt quãng vì lý do an toàn</b><br/>Vui lòng thoát ra và đăng nhập lại !";
                LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
            }
        }
        protected void ListViewAll_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (Session["login"] != null &&
                    Session["AccountID"] != null)
                {
                    #region[Edit]
                    //--------Edit-------
                    var txtWallComment = (TextBox) e.Item.FindControl("txtWallComment");
                    var SenderId = ((HtmlInputHidden) e.Item.FindControl("hiddenId")).Value;
                    var lb_lst_account_ID = ((Label) e.Item.FindControl("lb_lst_account_ID"));
                    if (e.CommandName == "_EditPost")
                    {
                        if (lb_lst_account_ID.Text == Session["AccountID"].ToString())
                        {
                            GetWallEdit(int.Parse(SenderId));
                            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalStatusEdit");
                        }
                        else
                        {
                            lbMsg.Text = "Bạn không được phép thay đổi trạng thái của người khác !";
                            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                        }
                    }
                    #endregion

                    #region[DelPost]
                    if (e.CommandName == "_DelPost")
                    {
                        _flag = true;
                        btnDelStatus.InnerText = "Xoá bài viết";
                        if (lb_lst_account_ID.Text == Session["AccountID"].ToString())
                        {
                            GetWallEdit(int.Parse(SenderId));
                            lbMsgDel.Text = "Bạn có chắc chắn muốn xóa tin này không ?";
                            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalDel");
                        }
                        else
                        {
                            lbMsg.Text = "Bạn không được phép xoá trạng thái của người khác !";
                            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                        }
                    }
                    #endregion

                    #region[Like]
                    //-------Like----------
                    var lb_lst_like = ((Label) e.Item.FindControl("lb_lst_like"));
                    if (e.CommandName == "Like_lst")
                    {
                        if (Session["login"] != null &&
                            Session["AccountID"] != null)
                        {
                            if (
                                !CheckInsert(int.Parse(SenderId), int.Parse(Session["AccountID"].ToString()),
                                    "Bạn không thể Like hai lần trên cùng một mẫu tin !"))
                            {
                                var obj = new DTOWall
                                {
                                    Wall_ID = int.Parse(SenderId),
                                    LikeCount = int.Parse(lb_lst_like.Text) + 1,
                                    AccountID1 = int.Parse(Session["AccountID"].ToString()),
                                    AccountID2 = int.Parse(lb_lst_account_ID.Text),
                                };
                                BllWall.Like(obj);
                                if (Request.Params["username"] != null)
                                {
                                    GetWall(Request.Params["username"], int.Parse(WebConfigurationManager.AppSettings["pageSizeWall"]));
                                }
                            }
                        }
                    }
                    #endregion

                    #region[Unlike]
                    if (e.CommandName == "Unlike_lst")
                    {
                        if (int.Parse(lb_lst_like.Text) == 0)
                        {
                            lbMsg.Text = "Số lượt thích hiện tại là 0.Bạn không thể bỏ thích";
                            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                        }
                        else
                        {
                            if (CheckUnlike(int.Parse(SenderId), int.Parse(Session["AccountID"].ToString())))
                            {
                                var obj = new DTOWall
                                {
                                    Wall_ID = int.Parse(SenderId),
                                    LikeCount = int.Parse(lb_lst_like.Text) - 1,
                                    AccountID1 = int.Parse(Session["AccountID"].ToString()),
                                };
                                BllWall.UnLike(obj);
                                if (Request.Params["username"] != null)
                                {
                                    GetWall(Request.Params["username"], int.Parse(WebConfigurationManager.AppSettings["pageSizeWall"]));
                                }
                            }
                            else
                            {
                                lbMsg.Text = "Bạn không thể bỏ Like hai lần trên cùng một mẫu tin !";
                                LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                            }
                        }
                    }
                    #endregion

                    #region[PostComment]
                    if (e.CommandName == "_btnInsert")
                    {
                        if (String.IsNullOrEmpty(txtWallComment.Text))
                        {
                            lbMsg.Text = "Vui lòng điền vào nội dung Comment !";
                            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                        }
                        else
                        {
                            InsertValueComment(int.Parse(SenderId), txtWallComment.Text);
                            txtWallComment.Text = string.Empty;
                        }
                        //--------Get-Data---------
                        var PanelComment = ((HtmlGenericControl) e.Item.FindControl("PanelComment"));
                        var ListViewComment = (ListView) e.Item.FindControl("ListViewComment");
                        var lbTotalComment = (Label)e.Item.FindControl("lbTotalComment");
                        var btnViewMoreComment = (Button)e.Item.FindControl("btnViewMoreComment");
                        var _clsGetComment = new BllWallComment();
                        var _dtGetWallCount = _clsGetComment.GetWallCommentCount(int.Parse(SenderId));
                        var _dtGetComment = _clsGetComment.GetWallComment(int.Parse(SenderId), int.Parse(WebConfigurationManager.AppSettings["pageSizeWallComment"]));
                        if (_dtGetComment != null && _dtGetComment.Rows.Count > 0)
                        {
                            ListViewComment.DataSource = _dtGetComment;
                            ListViewComment.DataBind();
                            ListViewComment.Visible = true;
                            PanelComment.Visible = true;
                            lbTotalComment.Text = _dtGetComment.Rows.Count.ToString();
                            if (_dtGetWallCount != null && _dtGetWallCount.Rows.Count > 0)
                            {
                                if (int.Parse(lbTotalComment.Text) < int.Parse(WebConfigurationManager.AppSettings["pageSizeWallComment"]))
                                {
                                    btnViewMoreComment.Visible = false;
                                }
                                else if (int.Parse(lbTotalComment.Text) == int.Parse(_dtGetWallCount.Rows[0]["Total"].ToString()))
                                {
                                    btnViewMoreComment.Visible = false;
                                }
                                else
                                {
                                    btnViewMoreComment.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            PanelComment.Visible = false;
                            ListViewComment.Visible = false;
                            btnViewMoreComment.Visible = false;
                        }
                    }
                    #endregion

                    #region[ViewMore]
                    //------ViewMore---
                    if (e.CommandName == "_btnViewMoreComment")
                    {
                        //--------Get-Data---------
                        var PanelComment = ((HtmlGenericControl)e.Item.FindControl("PanelComment"));
                        var ListViewComment = (ListView)e.Item.FindControl("ListViewComment");
                        var lbTotalComment = (Label)e.Item.FindControl("lbTotalComment");
                        var btnViewMoreComment = (Button)e.Item.FindControl("btnViewMoreComment");
                        var _clsGetComment = new BllWallComment();
                        var _dtGetWallCount = _clsGetComment.GetWallCommentCount(int.Parse(SenderId));
                        var _dtGetComment = _clsGetComment.GetWallComment(int.Parse(SenderId), int.Parse(lbTotalComment.Text) + 10);
                        if (_dtGetComment != null && _dtGetComment.Rows.Count > 0)
                        {
                            ListViewComment.DataSource = _dtGetComment;
                            ListViewComment.DataBind();
                            ListViewComment.Visible = true;
                            PanelComment.Visible = true;
                            lbTotalComment.Text = _dtGetComment.Rows.Count.ToString();
                            if (_dtGetWallCount != null && _dtGetWallCount.Rows.Count > 0)
                            {
                                if (int.Parse(lbTotalComment.Text) < int.Parse(WebConfigurationManager.AppSettings["pageSizeWallComment"]))
                                {
                                    btnViewMoreComment.Visible = false;
                                }
                                else if (int.Parse(lbTotalComment.Text) == int.Parse(_dtGetWallCount.Rows[0]["Total"].ToString()))
                                {
                                    btnViewMoreComment.Visible = false;
                                }
                                else
                                {
                                    btnViewMoreComment.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            PanelComment.Visible = false;
                            ListViewComment.Visible = false;
                            btnViewMoreComment.Visible = false;
                        }
                    }
                    #endregion
                }
                else
                {
                    lbMsg.Text = "<b>Chương trình bị ngắt quãng vì lý do an toàn</b><br/>Vui lòng thoát ra và đăng nhập lại !";
                    LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                }
            }
            catch (Exception ex)
            {
                _Error = LibAlert.Alert.AlertError(ex.Message);
            }
        }
        protected void ListViewAll_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var SenderId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                var btngroup = ((HtmlGenericControl)e.Item.FindControl("btngroup"));
                var imgAvatarPost = ((HtmlImage)e.Item.FindControl("imgAvatarPost"));
                var iconDateUpdate = ((HtmlGenericControl)e.Item.FindControl("iconDateUpdate"));
                var lb_lst_dateupdatetext = ((Label)e.Item.FindControl("lb_lst_dateupdatetext"));
                var lb_lst_dateupdate = ((Label)e.Item.FindControl("lb_lst_dateupdate"));
                var btnLike = (Button)e.Item.FindControl("btnLike");
                var btnUnLike = (Button)e.Item.FindControl("btnUnLike");
                if (String.IsNullOrEmpty(imgAvatarPost.Src))
                {
                    imgAvatarPost.Src = "../img/unnamed.png";
                }
                if (lb_lst_dateupdate.Text != string.Empty)
                {
                    lb_lst_dateupdate.Visible = true;
                    iconDateUpdate.Visible = true;
                    lb_lst_dateupdatetext.Visible = true;
                }
                if (Session["login"] != null && Session["UserName"] != null && Session["AccountID"] != null)
                {
                    btnLike.Visible = true;
                    btnUnLike.Visible = true;
                    btngroup.Visible = true;
                }
                else
                {
                    btnLike.Visible = false;
                    btnUnLike.Visible = false;
                    btngroup.Visible = false;
                }
                if (Session["login"] != null && Session["AccountID"] != null)
                {
                    if (!CheckLike(int.Parse(SenderId), int.Parse(Session["AccountID"].ToString())))
                    {
                        btnLike.Visible = true;
                        btnUnLike.Visible = false;
                    }
                    else
                    {
                        btnLike.Visible = false;
                        btnUnLike.Visible = true;
                    }
                }
                //--------Get-Data---------
                var PanelComment = ((HtmlGenericControl)e.Item.FindControl("PanelComment"));
                var ListViewComment = (ListView)e.Item.FindControl("ListViewComment");
                var lbTotalComment = (Label)e.Item.FindControl("lbTotalComment");
                var btnViewMoreComment = (Button)e.Item.FindControl("btnViewMoreComment");
                var _clsGetComment = new BllWallComment();
                var _dtGetWallCount = _clsGetComment.GetWallCommentCount(int.Parse(SenderId));
                var _dtGetComment = _clsGetComment.GetWallComment(int.Parse(SenderId), int.Parse(WebConfigurationManager.AppSettings["pageSizeWallComment"]));
                if (_dtGetComment != null && _dtGetComment.Rows.Count > 0)
                {
                    ListViewComment.DataSource = _dtGetComment;
                    ListViewComment.DataBind();
                    ListViewComment.Visible = true;
                    PanelComment.Visible = true;
                    lbTotalComment.Text = _dtGetComment.Rows.Count.ToString();
                    if (_dtGetWallCount != null && _dtGetWallCount.Rows.Count > 0)
                    {
                        if (int.Parse(lbTotalComment.Text) < int.Parse(WebConfigurationManager.AppSettings["pageSizeWallComment"]))
                        {
                            btnViewMoreComment.Visible = false;
                        }
                        else if (int.Parse(lbTotalComment.Text) == int.Parse(_dtGetWallCount.Rows[0]["Total"].ToString()))
                        {
                            btnViewMoreComment.Visible = false;
                        }
                        else
                        {
                            btnViewMoreComment.Visible = true;
                        }
                    }
                }
                else
                {
                    PanelComment.Visible = false;
                    ListViewComment.Visible = false;
                    btnViewMoreComment.Visible = false;
                }
            }
        }
        protected void ListViewWallFollwer_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
        protected void ListViewWallFollwer_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var ListViewSubWallFollower = (ListView)e.Item.FindControl("ListViewSubWallFollower");
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var lbFollower = ((Label)e.Item.FindControl("lbFollower"));
                var _clsGetWall = new BllWall();
                var _dtGetWall = _clsGetWall.GetWallFollower(int.Parse(lbFollower.Text), 10);
                if (_dtGetWall != null && _dtGetWall.Rows.Count > 0)
                {
                    ListViewSubWallFollower.DataSource = _dtGetWall;
                    ListViewSubWallFollower.DataBind();
                    ListViewSubWallFollower.Visible = true;
                }
                else
                {
                    ListViewSubWallFollower.Visible = false;
                }

            }
        }
        protected void ListViewSubWallFollower_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                var SenderId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                var lb_lst_account_ID = ((Label)e.Item.FindControl("lb_lst_account_ID"));
                if (Session["login"] != null &&
                    Session["AccountID"] != null)
                {
                    #region[Like]
                    //-------Like----------
                    var lb_lst_like = ((Label)e.Item.FindControl("lb_lst_like"));
                    if (e.CommandName == "Like_lst")
                    {
                        if (Session["login"] != null &&
                            Session["AccountID"] != null)
                        {
                            if (
                                !CheckInsert(int.Parse(SenderId), int.Parse(Session["AccountID"].ToString()),
                                    "Bạn không thể Like hai lần trên cùng một mẫu tin !"))
                            {
                                var obj = new DTOWall
                                {
                                    Wall_ID = int.Parse(SenderId),
                                    LikeCount = int.Parse(lb_lst_like.Text) + 1,
                                    AccountID1 = int.Parse(Session["AccountID"].ToString()),
                                    AccountID2 = int.Parse(lb_lst_account_ID.Text),
                                };
                                BllWall.Like(obj);
                                GetUserFollowerList();
                            }
                        }
                    }
                    #endregion

                    #region[Unlike]
                    if (e.CommandName == "Unlike_lst")
                    {
                        if (int.Parse(lb_lst_like.Text) == 0)
                        {
                            lbMsg.Text = "Số lượt thích hiện tại là 0.Bạn không thể bỏ thích";
                            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                        }
                        else
                        {
                            if (CheckUnlike(int.Parse(SenderId), int.Parse(Session["AccountID"].ToString())))
                            {
                                var obj = new DTOWall
                                {
                                    Wall_ID = int.Parse(SenderId),
                                    LikeCount = int.Parse(lb_lst_like.Text) - 1,
                                    AccountID1 = int.Parse(Session["AccountID"].ToString()),
                                };
                                BllWall.UnLike(obj);
                                GetUserFollowerList();
                            }
                            else
                            {
                                lbMsg.Text = "Bạn không thể bỏ Like hai lần trên cùng một mẫu tin !";
                                LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                _Error = LibAlert.Alert.AlertError(ex.Message);
            }
        }
        protected void ListViewSubWallFollower_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                if (Session["login"] != null &&
                    Session["AccountID"] != null)
                {
                    var SenderId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                    var BodyWallFollower = ((HtmlGenericControl) e.Item.FindControl("BodyWallFollower"));
                    var lb_lst_ContentFollower = ((Label) e.Item.FindControl("lb_lst_ContentFollower"));
                    var lb_lst_account_ID = ((Label) e.Item.FindControl("lb_lst_account_ID"));
                    var btnLike = (Button)e.Item.FindControl("btnLike");
                    var btnUnLike = (Button)e.Item.FindControl("btnUnLike");
                    if (int.Parse(lbUserMain.Text) == int.Parse(lb_lst_account_ID.Text))
                    {
                        BodyWallFollower.Visible = false;
                    }
                    else if (String.IsNullOrEmpty(lb_lst_ContentFollower.Text))
                    {
                        BodyWallFollower.Visible = false;
                    }
                    else
                    {
                        BodyWallFollower.Visible = true;
                    }
                    #region[SetConditionLike]
                    if (Session["login"] != null && Session["UserName"] != null && Session["AccountID"] != null)
                    {
                        btnLike.Visible = true;
                        btnUnLike.Visible = true;
                    }
                    else
                    {
                        btnLike.Visible = false;
                        btnUnLike.Visible = false;
                    }
                    if (Session["login"] != null && Session["AccountID"] != null)
                    {
                        if (!CheckLike(int.Parse(SenderId), int.Parse(Session["AccountID"].ToString())))
                        {
                            btnLike.Visible = true;
                            btnUnLike.Visible = false;
                        }
                        else
                        {
                            btnLike.Visible = false;
                            btnUnLike.Visible = true;
                        }
                    }
                    #endregion
                }
                else
                {
                    lbMsg.Text = "<b>Chương trình bị ngắt quãng vì lý do an toàn</b><br/>Vui lòng thoát ra và đăng nhập lại !";
                    LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                }
            }
        }
        #endregion

        #region[Method]
        private void GetWallCommentEdit(int WallComment_ID)
        {
            var _clsGetWallCommentEdit = new BllWallComment();
            var _dtGetWallCommentEdit = _clsGetWallCommentEdit.GetWallCommentEdit(WallComment_ID);
            if (_dtGetWallCommentEdit != null && _dtGetWallCommentEdit.Rows.Count > 0)
            {
                lbWallIDDel.Text = _dtGetWallCommentEdit.Rows[0]["WallComment_ID"].ToString();
            }
        }
        private string GetUserFollow()
        {
            var _html = string.Empty;
            if (Session["login"] != null && Session["FullName1"] != null && Session["FullName"] != null &&
                Session["AccountID"] != null)
            {
                var _clsGetUserFollower = new BllFollower();
                var _dtGetCountUserFollower =
                    _clsGetUserFollower.GetWallFollowCount(int.Parse(Session["AccountID"].ToString()));
                var _dtGetUserFollower = _clsGetUserFollower.GetWallFollow(int.Parse(Session["AccountID"].ToString()));
                if (_dtGetUserFollower != null && _dtGetUserFollower.Rows.Count > 0)
                {
                    _html += "<div class='panel panel-danger'>";
                        _html += "<div class='panel-heading'>";
                            _html += "<h3 class='panel-title'>NHỮNG NGƯỜI BẠN THEO DÕI " + "(" +
                                _dtGetCountUserFollower.Rows[0]["Follower"] + ")" + " </h3>";
                        _html += "</div>";
                        _html += "<div class='panel-body' style='margin: 0 0 0 0;padding: 11px 0 12px 0;text-align: center'>";
                                    for (int i = 0; i < _dtGetUserFollower.Rows.Count; i++)
                                    {
                                        _html += " <div class='col-md-4' style='width: 103px'>";
                                        if (String.IsNullOrEmpty(_dtGetUserFollower.Rows[i]["User_Image"].ToString()) ||
                                            _dtGetUserFollower.Rows[i]["User_Image"] == DBNull.Value)
                                        {
                                            _html +=
                                                _html += "<a href='/profice/" +
                                                         _dtGetUserFollower.Rows[i]["UserName"] +
                                                         "' data-popover='true' data-html=true data-content='" +
                                                         _dtGetUserFollower.Rows[i]["FullName"] + "'>";
                                                     _html +=
                                                            "<img src='../img/unnamed.png' style='width: 103px;height: 103px;border: 2px solid #f2dede' class='img-rounded'/>";
                                            _html += "</a>";
                                            
                                        }
                                        else
                                        {
                                            _html += "<a href='/profice/" +
                                            _dtGetUserFollower.Rows[i]["UserName"] +
                                            "' data-popover='true' data-html=true data-content='" + _dtGetUserFollower.Rows[i]["FullName"] + "'>";
                                            _html +=
                                                "<img src='" + _dtGetUserFollower.Rows[i]["User_Image"] +
                                                "' style='width: 103px;height: 103px;border: 2px solid #f2dede' class='img-rounded'/>";
                                            _html += "</a>";
                                        }
                                        _html += "</div>";
                                    }
                        _html += "</div>";
                    _html += "</div>";
                }
            }
            return _html;
        }
        private void GetUserFollowerList()
        {
            if (Session["login"] != null && Session["FullName1"] != null && Session["FullName"] != null &&
                Session["AccountID"] != null)
            {
                var _clsGetUserFollower = new BllFollower();
                var _dtGetUserFollower = _clsGetUserFollower.GetWallFollow(int.Parse(Session["AccountID"].ToString()));
                if (_dtGetUserFollower != null && _dtGetUserFollower.Rows.Count > 0)
                {
                    ListViewWallFollwer.DataSource = _dtGetUserFollower;
                    ListViewWallFollwer.DataBind();
                }
            }
        }
        private void GetUserView(string UserName)
        {
            var _clsGetUserView = new BllUser();
            var _clsGetFollowerSendMessage = new BllFollower();
            var _dtGetUserView = _clsGetUserView.GetUserView(UserName);
            if (_dtGetUserView != null && _dtGetUserView.Rows.Count > 0)
            {
                Page.Title = _dtGetUserView.Rows[0]["FullName"].ToString();
                lbUserMain.Text = _dtGetUserView.Rows[0]["AccountID"].ToString();
                lbAccountID2.Text = _dtGetUserView.Rows[0]["AccountID"].ToString();
                if (Session["login"] != null &&
                    Session["AccountID"] != null)
                {
                    var _dtGetFollowerSendMessage =
                        _clsGetFollowerSendMessage.GetFollowerSendMessage(int.Parse(Session["AccountID"].ToString()),
                            int.Parse(lbUserMain.Text));
                    if (_dtGetFollowerSendMessage != null && _dtGetFollowerSendMessage.Rows.Count > 0)
                    {
                        btnSendMessageClick.Visible = true;
                    }
                }
            }
        }
        private void GetUserID(string UserName)
        {
            var _clsGetUserView = new BllUser();
            var _dtGetUserView = _clsGetUserView.GetUserView(UserName);
            if (_dtGetUserView != null && _dtGetUserView.Rows.Count > 0)
            {
                lbAccountID2.Text = _dtGetUserView.Rows[0]["AccountID"].ToString();
                lbFullNameMessage.Text = _dtGetUserView.Rows[0]["FullName"].ToString();
                lbMsgSendMessage.Text = "Vui lòng để lại lời nhắn cho <b>" + _dtGetUserView.Rows[0]["FullName"] + " </b>";
            }
        }
        private void GetWall(string UserName, int pageSize)
        {
            var _clsGetWall = new BllWall();
            var _dtGetWallCount = _clsGetWall.GetWallCount(UserName);
            var _dtGetWall = _clsGetWall.GetWall(UserName, pageSize);
            if (_dtGetWall != null && _dtGetWall.Rows.Count > 0)
            {
                lbIDUser.Text = _dtGetWall.Rows[0]["AccountID"].ToString();
                lbUserMain.Text = _dtGetWall.Rows[0]["AccountID"].ToString();
                ListViewAll.DataSource = _dtGetWall;
                ListViewAll.DataBind();
                ListViewAll.Visible = true;
                lbTotal.Text = _dtGetWall.Rows.Count.ToString();
                if (_dtGetWallCount != null && _dtGetWallCount.Rows.Count > 0)
                {
                    if (int.Parse(lbTotal.Text) < int.Parse(WebConfigurationManager.AppSettings["pageSizeWall"]))
                    {
                        btnViewMore.Visible = false;
                    }
                    else if (int.Parse(lbTotal.Text) == int.Parse(_dtGetWallCount.Rows[0]["Total"].ToString()))
                    {
                        btnViewMore.Visible = false;
                    }
                    else
                    {
                        btnViewMore.Visible = true;
                    }
                }
            }
            else
            {
                ListViewAll.Visible = false;
                btnViewMore.Visible = false;
            }
        }
        private void GetWallEdit(int Wall_ID)
        {
            var _clsGetWall = new BllWall();
            var _dtGetWallEdit = _clsGetWall.GetWallEdit(Wall_ID, int.Parse(lbIDUser.Text));
            if (_dtGetWallEdit != null && _dtGetWallEdit.Rows.Count > 0)
            {
                lbWallID.Text = _dtGetWallEdit.Rows[0]["Wall_ID"].ToString();
                lbWallIDDel.Text = _dtGetWallEdit.Rows[0]["Wall_ID"].ToString();
                txtTitilePostEdit.Value = _dtGetWallEdit.Rows[0]["Wall_Titile"].ToString();
                txtContentPostEdit.Value = _dtGetWallEdit.Rows[0]["Wall_Content"].ToString();
            }
        }
        private void PostMessage()
        {
            try
            {
                if (Session["login"] != null &&
                    Session["AccountID"] != null)
                {
                    var obj = new DTOTweet { AccountID = int.Parse(Session["AccountID"].ToString()), AccountID2 = int.Parse(lbAccountID2.Text), Message = txtMessage.Value };
                    BllTweet.Insert(obj);
                    _ErrorPostMessage =
                        LibAlert.Alert.AlertSucess("Bạn đã gửi tin nhắn thành công đến <b style='color:black'>" + lbFullNameMessage.Text +
                                                   "</b>");
                }
                else
                {
                    _ErrorPostMessage =
                        LibAlert.Alert.AlertError(
                            "<b>Chương trình bị ngắt quãng vì lý do an toàn</b><br/>Vui lòng thoát ra và đăng nhập lại !");
                }
            }
            catch (Exception ex)
            {
                _ErrorPostMessage =
                    LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình gửi tin nhắn <br/>" + ex.Message);
            }
        }
        private void InsertValue()
        {
            try
            {
                if (String.IsNullOrEmpty(lbIDUser.Text))
                {
                    _ErrorPost =
                        LibAlert.Alert.AlertError("Bạn không được phép đăng bài trên dòng thời gian của " +
                                                  Session["FullName1"]);
                }
                else
                {
                    var obj = new DTOWall
                    {
                        AccountID1 = int.Parse(lbIDUser.Text),
                        Wall_Titile = txTitilePost.Value,
                        Wall_Content = txtContentPost.Value,
                        Wall_Img = null
                    };
                    BllWall.Insert(obj);
                    _ErrorPost = LibAlert.Alert.AlertSucess("Cập nhật trạng thái thành công !");
                    ClearText();
                    GetWall(Request.Params["username"], int.Parse(WebConfigurationManager.AppSettings["pageSizeWall"]));
                }
            }
            catch (Exception ex)
            {
                _ErrorPost = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình đăng bài !<br/>" + ex.Message);
            }
        }
        private void UpdateValue()
        {
            try
            {
                if (String.IsNullOrEmpty(lbIDUserEdit.Text))
                {
                    _ErrorPost =
                        LibAlert.Alert.AlertError("Bạn không được phép thay đổi bài viết trên dòng thời gian của " +
                                                  Session["FullName1"]);
                }
                else
                {
                    var obj = new DTOWall
                    {
                        Wall_ID = int.Parse(lbWallID.Text),
                        AccountID1 = int.Parse(lbIDUserEdit.Text),
                        Wall_Titile = txtTitilePostEdit.Value,
                        Wall_Content = txtContentPostEdit.Value,
                        Wall_Img = null
                    };
                    BllWall.Update(obj);
                    _ErrorPostEdit = LibAlert.Alert.AlertSucess("Thay đổi trạng thái thành công !");
                    GetWall(Request.Params["username"], int.Parse(WebConfigurationManager.AppSettings["pageSizeWall"]));
                }
            }
            catch (Exception ex)
            {
                _ErrorPostEdit = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình đăng bài !<br/>" + ex.Message);
            }
        }
        private void Delete()
        {
            try
            {
                var obj = new DTOWall {AccountID1 = int.Parse(lbUserIDDel.Text), Wall_ID = int.Parse(lbWallIDDel.Text)};
                BllWall.Delete(obj);
                lbMsgDel.Text = string.Empty;
                GetWall(Request.Params["username"], int.Parse(WebConfigurationManager.AppSettings["pageSizeWall"]));
                LibWindowUI.Window.CloseWindows(Page, GetType(), "#myModalDel");
            }
            catch (Exception ex)
            {
                lbMsgDel.Text = "Có lỗi xảy ra trong quá trình xoá bài viết.<br/>" + ex.Message;
            }
        }
        private void DeleteComment()
        {
            try
            {
                var obj = new DTOWallComment { WallComment_ID = int.Parse(lbWallIDDel.Text) };
                BllWallComment.Delete(obj);
                lbMsgDel.Text = string.Empty;
                GetWall(Request.Params["username"], int.Parse(WebConfigurationManager.AppSettings["pageSizeWall"]));
                LibWindowUI.Window.CloseWindows(Page, GetType(), "#myModalDel");
            }
            catch (Exception ex)
            {
                lbMsgDel.Text = "Có lỗi xảy ra trong quá trình xoá bài viết.<br/>" + ex.Message;
            }
        }
        private bool CheckInsert(int Wall_ID, int AccountID1, string sMsg)
        {
            var check = false;
            var _clsCheck = new BllWall();
            var dtCheck = _clsCheck.GetLikeWall();
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCheck.Rows)
                {
                    if (Wall_ID == int.Parse(dr["Wall_ID"].ToString()) && AccountID1 == int.Parse(dr["AccountID1"].ToString()))
                    {
                        check = true;
                        lbMsg.Text = sMsg;
                        LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                    }
                }
            }
            return check;
        }
        private bool CheckLike(int Wall_ID, int AccountID1)
        {
            var check = false;
            var _clsCheck = new BllWall();
            var dtCheck = _clsCheck.GetCheckLike(Wall_ID, AccountID1);
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCheck.Rows)
                {
                    if (Wall_ID == int.Parse(dr["Wall_ID"].ToString()) && AccountID1 == int.Parse(dr["AccountID1"].ToString()))
                    {
                        check = true;
                    }
                }
            }
            return check;
        }
        private bool CheckUnlike(int Wall_ID, int AccountID1)
        {
            var check = false;
            var _clsCheck = new BllWall();
            var dtCheck = _clsCheck.GetLikeWall();
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCheck.Rows)
                {
                    if (Wall_ID == int.Parse(dr["Wall_ID"].ToString()) && AccountID1 == int.Parse(dr["AccountID1"].ToString()))
                    {
                        check = true;
                    }
                }
            }
            return check;
        }
        private void InsertValueComment(int Wall_ID,string Content)
        {
            try
            {
                if (Session["login"] != null &&
                    Session["AccountID"] != null)
                {
                    var obj = new DTOWallComment
                    {
                        Wall_ID = Wall_ID,
                        AccountID = int.Parse(Session["AccountID"].ToString()),
                        Content = Content
                    };
                    BllWallComment.Insert(obj);
                    //_ErrorComment = LibAlert.Alert.AlertSucess("Bạn đã bình luận thành công !");
                }
                else
                {
                    lbMsg.Text = "<b>Chương trình bị ngắt quãng vì lý do an toàn</b><br/>Vui lòng thoát ra và đăng nhập lại !";
                    LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                }
            }
            catch (Exception ex)
            {
                _ErrorComment = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình bình luận <br/>" + ex.Message);
            }
        }
        #endregion

        #region[Clear-Text]
        private void ClearText()
        {
            txTitilePost.Value = string.Empty;
            txtContentPost.Value = string.Empty;
        }
        #endregion
    }
}