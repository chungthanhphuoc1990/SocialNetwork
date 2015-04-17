using System;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibBusinessLayer;

namespace Presentation.modules
{
    public partial class plugin_center : UserControl
    {
        #region[Define]
        protected string _Error = string.Empty;
        protected string _htmlComment = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNews(int.Parse(WebConfigurationManager.AppSettings["pageSize"]));
            }
        }
        protected void ListViewAll_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Comment_lst")
                {
                    LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModalComment");
                }
                //var SenderId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                //var lb_lst_like = ((Label)e.Item.FindControl("lb_lst_like"));
                //if (e.CommandName == "Like_lst")
                //{
                //    if (!CheckInsert(int.Parse(SenderId), "192.168.1.1", "Bạn không thể Like hai lần trên cùng một mẫu tin !"))
                //    {
                //        var obj = new DTOLikes { ID_News = int.Parse(SenderId), Likes = int.Parse(lb_lst_like.Text) + 1, IP_User = "192.168.1.1" };
                //        BllGetNews.Like(obj);
                //        GetNews();
                //    }
                //}
                //if (e.CommandName == "Unlike_lst")
                //{
                //    if (int.Parse(lb_lst_like.Text) == 0)
                //    {
                //        lbMsg.Text = "Số lượt thích hiện tại là 0.Bạn không thể bỏ thích";
                //        LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                //    }
                //    else
                //    {
                //        if (CheckUnlike(int.Parse(SenderId), "192.168.1.1"))
                //        {
                //            var obj = new DTOLikes
                //            {
                //                ID_News = int.Parse(SenderId),
                //                Likes = int.Parse(lb_lst_like.Text) - 1,
                //                IP_User = "192.168.1.1"
                //            };
                //            BllGetNews.UnLike(obj);
                //            GetNews();
                //        }
                //        else
                //        {
                //            lbMsg.Text = "Bạn không thể bỏ Like hai lần trên cùng một mẫu tin !";
                //            LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                _Error = LibAlert.Alert.AlertError(ex.Message);
            }
        }
        protected void ListViewAll_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //var _clsGetComment = new BLLComment();
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    var lbID = (Label)e.Item.FindControl("lbID");
            //    var _dtGetComment = _clsGetComment.GetComment(int.Parse(lbID.Text));
            //    if (_dtGetComment != null && _dtGetComment.Rows.Count > 0)
            //    {
            //        _htmlComment += "<ul class='chat'>";
            //        for (int i = 0; i < _dtGetComment.Rows.Count; i++)
            //        {
                        
            //            _htmlComment += "<li class='left clearfix'>";
            //            _htmlComment += "<span class='chat-img pull-left'>";
            //            _htmlComment += "<img src='../img/unnamed.png' alt='User Avatar' class='img-circle' />";
                        
            //            _htmlComment += "</span>";
            //            _htmlComment += "<div class='chat-body clearfix'>";
            //            _htmlComment += "<div class='header' style='color: #000080;font-weight: bold'>";
            //            _htmlComment += "User Comment";
            //            _htmlComment += "</div>";
            //            _htmlComment +=
            //                "<p><small class='text-muted'><i class='fa fa-clock-o'></i> 11 hours ago via Twitter</small></p>";
            //            _htmlComment += "<p>";
            //            _htmlComment += _dtGetComment.Rows[i]["Comment_Content"];
            //            _htmlComment += "</p>";
            //            _htmlComment += "</div>";
            //            _htmlComment += "</li>";
            //        }
            //        _htmlComment += "</ul>";
            //    }
            //}
        }
        protected void btnViewMore_Click(object sender, EventArgs e)
        {
            GetNews(int.Parse(lbTotal.Text) + 10);
            ScriptManager.RegisterStartupScript(UpdatePanelViewMore, UpdatePanelViewMore.GetType(), "scrollToDiv()", "scrollToDiv();", true);
        }
        #endregion

        #region[Method]
        private void GetNews(int pageSize)
        {
            var _clsGetNews = new BllGetNews();
            var _dtGetNewsCount = _clsGetNews.GetNewsCount();
            var _dtGetNews = _clsGetNews.GetNews(string.Empty, pageSize);
            if (_dtGetNews != null && _dtGetNews.Rows.Count > 0)
            {
                ListViewAll.DataSource = _dtGetNews;
                ListViewAll.DataBind();
                ListViewAll.Visible = true;
                lbTotal.Text = _dtGetNews.Rows.Count.ToString();
                if (_dtGetNewsCount != null && _dtGetNewsCount.Rows.Count > 0)
                {
                    if (int.Parse(lbTotal.Text) == int.Parse(_dtGetNewsCount.Rows[0]["Total"].ToString()))
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
        private bool CheckInsert(int ID_News, string IP_User, string sMsg)
        {
            var check = false;
            var _clsCheck = new BllGetNews();
            var dtCheck = _clsCheck.GetLike();
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCheck.Rows)
                {
                    if (ID_News == int.Parse(dr["ID_News"].ToString()) && IP_User == dr["IP_User"].ToString())
                    {
                        check = true;
                        lbMsg.Text = sMsg;
                        LibWindowUI.Window.OpenWindows(Page, GetType(), "#myModal");
                    }
                }
            }
            return check;
        }
        private bool CheckUnlike(int ID_News, string IP_User)
        {
            var check = false;
            var _clsCheck = new BllGetNews();
            var dtCheck = _clsCheck.GetLike();
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCheck.Rows)
                {
                    if (ID_News == int.Parse(dr["ID_News"].ToString()) && IP_User == dr["IP_User"].ToString())
                    {
                        check = true;
                    }
                }
            }
            return check;
        }
        #endregion
    }
}