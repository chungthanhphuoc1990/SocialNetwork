using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Configuration;
using AjaxControlToolkit;
using LibBusinessLayer;
using LibDataLayer;
using System.Web;
using System.Web.UI.HtmlControls;
namespace Presentation.modules
{
    public partial class plugin_profice : System.Web.UI.UserControl
    {
        #region[Define]
        protected string _htmlFullName = string.Empty;
        protected string _htmlAvatarMain = string.Empty;
        protected string _Error = string.Empty;
        protected string UploadFolderPath = WebConfigurationManager.AppSettings["FolderRootUpload"];
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCountry();
                GetLanguages();
                if (Session["login"] == null && Session["UserName"] == null)
                {
                    if (Request.Params["username"] != null)
                    {
                        if (!IsPostBack)
                        {
                            GetUserView(Request.Params["username"]);
                            btnSigin.Visible = false;
                            ((HtmlAnchor)Page.Master.FindControl("btnAbout")).Attributes["class"] = "navbar-brand";
                        }
                    }
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                    Response.Cache.SetNoStore();
                }
                else
                {
                    if ((bool)Session["login"] == false)
                    {
                        if (Request.Params["username"] != null)
                        {
                            if (!IsPostBack)
                            {
                                GetUserView(Request.Params["username"]);
                                btnSigin.Visible = false;
                                ((HtmlAnchor)Page.Master.FindControl("btnAbout")).Attributes["class"] = "navbar-brand";
                            }
                        }
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                        Response.Cache.SetNoStore();
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            GetUserView(Request.Params["username"]);
                            ((HtmlAnchor)Page.Master.FindControl("btnAbout")).Attributes["class"] = "navbar-brand";
                            if (lbID.Text == Session["AccountID"].ToString())
                            {
                                
                                btnSigin.Visible = true;
                                txtFullName.Attributes.Remove("Disabled");
                                txtEmail.Attributes.Remove("Disabled");
                                txtCellPhone.Attributes.Remove("Disabled");
                                txtBirthday.Attributes.Remove("Disabled");
                                rdMade.Enabled = true;
                                rdFeMade.Enabled = true;
                                drCountry.Enabled = true;
                                drLanguage.Enabled = true;
                                AsyncFileUpload1.Enabled = true;
                            }
                            else
                            {
                                btnSigin.Visible = false;
                                txtFullName.Attributes.Add("Disabled", "");
                                txtEmail.Attributes.Add("Disabled", "");
                                txtCellPhone.Attributes.Add("Disabled", "");
                                txtBirthday.Attributes.Add("Disabled", "");
                                rdMade.Enabled = false;
                                rdFeMade.Enabled = false;
                                drCountry.Enabled = false;
                                drLanguage.Enabled = false;
                                AsyncFileUpload1.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFullName.Value))
            {
                _Error = LibAlert.Alert.AlertError("Vui lòng điền vào tên đầy đủ của bạn !");
            }
            else if (String.IsNullOrEmpty(txtEmail.Value))
            {
                _Error = LibAlert.Alert.AlertError("Vui lòng điền vào Email của bạn !");
            }
            else if (String.IsNullOrEmpty(txtBirthday.Value))
            {
                _Error = LibAlert.Alert.AlertError("Vui lòng điền vào ngày tháng năm sinh của bạn !");
            }
            else if (drCountry.SelectedValue == "-1")
            {
                _Error = LibAlert.Alert.AlertError("Vui lòng chọn quốc gia của bạn của bạn !");
            }
            else if (drLanguage.SelectedValue == "-1")
            {
                _Error = LibAlert.Alert.AlertError("Vui lòng chọn ngôn ngữ của bạn của bạn !");
            }
            else if (String.IsNullOrEmpty(txtCellPhone.Value))
            {
                _Error = LibAlert.Alert.AlertError("Vui lòng điền vào điện thoại của bạn !");
            }
            else if (txtCellPhone.Value.Length > 11)
            {
                _Error = LibAlert.Alert.AlertError("Điện thoại phải từ 6 tới 11 số !");
            }
            else
            {
                UpdateValue();
            }
        }
        #endregion

        #region[Method]
        private void GetUserView(string UserName)
        {
            var _clsGetUserView = new BllUser();
            var _dtGetUserView = _clsGetUserView.GetUserView(UserName);
            if (_dtGetUserView != null && _dtGetUserView.Rows.Count > 0)
            {
                Page.Title = _dtGetUserView.Rows[0]["FullName"].ToString();
                _htmlFullName = _dtGetUserView.Rows[0]["FullName"].ToString();
                lbID.Text = _dtGetUserView.Rows[0]["AccountID"].ToString();
                if (String.IsNullOrEmpty(_dtGetUserView.Rows[0]["User_Image"].ToString()) ||
                    _dtGetUserView.Rows[0]["User_Image"] == DBNull.Value)
                {
                    _htmlAvatarMain = "../img/unnamed.png";
                }
                else
                {
                    _htmlAvatarMain = _dtGetUserView.Rows[0]["User_Image"].ToString();
                }
                txtFullName.Attributes.Add("Disabled", "");
                txtEmail.Attributes.Add("Disabled", "");
                txtCellPhone.Attributes.Add("Disabled", "");
                txtBirthday.Attributes.Add("Disabled", "");
                rdMade.Enabled = false;
                rdFeMade.Enabled = false;
                drCountry.Enabled = false;
                drLanguage.Enabled = false;
                AsyncFileUpload1.Enabled = false;
                lbID.Text = _dtGetUserView.Rows[0]["AccountID"].ToString();
                txtFullName.Value = _dtGetUserView.Rows[0]["FullName"].ToString();
                txtEmail.Value = _dtGetUserView.Rows[0]["Email"].ToString();
                txtCellPhone.Value = _dtGetUserView.Rows[0]["CellPhone"].ToString();
                txtBirthday.Value = _dtGetUserView.Rows[0]["Birthday"].ToString();
                if (String.IsNullOrEmpty(_dtGetUserView.Rows[0]["DateBegin"].ToString())
                    || _dtGetUserView.Rows[0]["DateBegin"] == DBNull.Value)
                {
                    lbDateBegin.Text = DateTime.Now.ToString();
                }
                else
                {
                    lbDateBegin.Text = _dtGetUserView.Rows[0]["DateBegin"].ToString();
                }
                if (String.IsNullOrEmpty(_dtGetUserView.Rows[0]["User_Image"].ToString())
                    || _dtGetUserView.Rows[0]["User_Image"] == DBNull.Value)
                {
                    lbPathImg.Text = string.Empty;
                }
                else
                {
                    lbPathImg.Text = _dtGetUserView.Rows[0]["User_Image"].ToString();
                }
                if (_dtGetUserView.Rows[0]["Gender"].ToString() == "Nam")
                {
                    rdMade.Checked = true;
                    rdFeMade.Checked = false;
                }
                else
                {
                    rdMade.Checked = false;
                    rdFeMade.Checked = true;
                }
                if (String.IsNullOrEmpty(_dtGetUserView.Rows[0]["Country_ID"].ToString()) ||
                    _dtGetUserView.Rows[0]["Country_ID"] == DBNull.Value)
                {
                    drCountry.SelectedIndex = -1;
                }
                else
                {
                    drCountry.SelectedValue = _dtGetUserView.Rows[0]["Country_ID"].ToString();
                }
                if (String.IsNullOrEmpty(_dtGetUserView.Rows[0]["Language_ID"].ToString()) ||
                    _dtGetUserView.Rows[0]["Language_ID"] == DBNull.Value)
                {
                    drLanguage.SelectedIndex = -1;
                }
                else
                {
                    drLanguage.SelectedValue = _dtGetUserView.Rows[0]["Language_ID"].ToString();
                }
            }
        }
        private void GetUserEdit()
        {
            var _clsGetUser = new BllUser();
            if (Session["login"] != null && Session["UserName"] != null && Session["AccountID"] != null)
            {
                var _dtGetUser = _clsGetUser.GetUserEdit(int.Parse(Session["AccountID"].ToString()));
                if (_dtGetUser != null && _dtGetUser.Rows.Count > 0)
                {
                    lbID.Text = _dtGetUser.Rows[0]["AccountID"].ToString();
                    txtFullName.Value = _dtGetUser.Rows[0]["FullName"].ToString();
                    txtEmail.Value = _dtGetUser.Rows[0]["Email"].ToString();
                    txtCellPhone.Value = _dtGetUser.Rows[0]["CellPhone"].ToString();
                    txtBirthday.Value = _dtGetUser.Rows[0]["Birthday"].ToString();
                    if (String.IsNullOrEmpty(_dtGetUser.Rows[0]["DateBegin"].ToString())
                        || _dtGetUser.Rows[0]["DateBegin"] == DBNull.Value)
                    {
                        lbDateBegin.Text = DateTime.Now.ToString();
                    }
                    else
                    {
                        lbDateBegin.Text = _dtGetUser.Rows[0]["DateBegin"].ToString();
                    }
                    if (String.IsNullOrEmpty(_dtGetUser.Rows[0]["User_Image"].ToString())
                        || _dtGetUser.Rows[0]["User_Image"] == DBNull.Value)
                    {
                        lbPathImg.Text = string.Empty;
                    }
                    else
                    {
                        lbPathImg.Text = _dtGetUser.Rows[0]["User_Image"].ToString();
                    }
                    if (_dtGetUser.Rows[0]["Gender"].ToString() == "Nam")
                    {
                        rdMade.Checked = true;
                        rdFeMade.Checked = false;
                    }
                    else
                    {
                        rdMade.Checked = false;
                        rdFeMade.Checked = true;
                    }
                    if (String.IsNullOrEmpty(_dtGetUser.Rows[0]["Country_ID"].ToString()) ||
                        _dtGetUser.Rows[0]["Country_ID"] == DBNull.Value)
                    {
                        drCountry.SelectedIndex = -1;
                    }
                    else
                    {
                        drCountry.SelectedValue = _dtGetUser.Rows[0]["Country_ID"].ToString();
                    }
                    if (String.IsNullOrEmpty(_dtGetUser.Rows[0]["Language_ID"].ToString()) ||
                        _dtGetUser.Rows[0]["Language_ID"] == DBNull.Value)
                    {
                        drLanguage.SelectedIndex = -1;
                    }
                    else
                    {
                        drLanguage.SelectedValue = _dtGetUser.Rows[0]["Language_ID"].ToString();
                    }
                }
            }
            
        }
        private void GetCountry()
        {
            var _clsGetCountry = new BllConutry();
            var _dtGetCountry = _clsGetCountry.GetConutry(string.Empty);
            if (_dtGetCountry != null && _dtGetCountry.Rows.Count > 0)
            {
                drCountry.DataSource = _dtGetCountry;
                drCountry.DataTextField = "Country_Name";
                drCountry.DataValueField = "Country_ID";
                drCountry.DataBind();
            }
        }
        private void GetLanguages()
        {
            var _clsGetLanguages = new BllLang();
            var _dtGetLanguages = _clsGetLanguages.GetLanguage(string.Empty);
            if (_dtGetLanguages != null && _dtGetLanguages.Rows.Count > 0)
            {
                drLanguage.DataSource = _dtGetLanguages;
                drLanguage.DataTextField = "Languages_Name";
                drLanguage.DataValueField = "Language_ID";
                drLanguage.DataBind();
            }
        }
        private bool CheckInsert()
        {
            var check = false;
            var _clsCheck = new BllUser();
            var dtCheck = _clsCheck.GetUser(string.Empty);
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCheck.Rows)
                {
                    if (lbID.Text != dr["AccountID"].ToString())
                    {
                        if (txtFullName.Value == dr["FullName"].ToString())
                        {
                            check = true;
                            _Error =
                                LibAlert.Alert.AlertError("Tên đầy đủ này đã tồn tại.Vui lòng chọn tên đăng nhập khác !");
                        }
                        else if (txtEmail.Value == dr["Email"].ToString())
                        {
                            check = true;
                            _Error =
                                LibAlert.Alert.AlertError("Email này đã tồn tại.Vui lòng chọn Email !");
                        }
                    }
                }
            }
            return check;
        }
        private void UpdateValue()
        {
            try
            {
                if (!CheckInsert())
                {
                    if (Session["login"] != null && Session["UserName"] != null && Session["AccountID"] != null)
                    {
                        var obj = new DTOUser
                        {
                            AccountID = int.Parse(Session["AccountID"].ToString()),
                            Email = txtEmail.Value,
                            FullName = txtFullName.Value,
                            CellPhone = txtCellPhone.Value,
                            Group_Id = null,
                            Gender = rdMade.Checked ? "Nam" : "Nữ",
                            Birthday = DateTime.Parse(txtBirthday.Value),
                            Country_ID = int.Parse(drCountry.SelectedValue),
                            Language_ID = int.Parse(drLanguage.SelectedValue),
                            DateBegin = DateTime.Parse(lbDateBegin.Text),
                        };
                        BllUser.Update(obj);
                        _Error = LibAlert.Alert.AlertSucess("Chúc mừng ! Bạn đã cập nhật thành công tài khoản !");
                        GetUserEdit();
                    }
                }
            }
            catch (Exception ex)
            {
                _Error = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình cập nhật" + "<br/>" + ex.Message);
            }
        }
        private void UpdateValueImg(string path)
        {
            try
            {
                if (!CheckInsert())
                {
                    var obj = new DTOUser
                    {
                        AccountID = int.Parse(lbID.Text),
                        User_Image = String.IsNullOrEmpty(path) ? "../img/unnamed.png" : path,
                    };
                    BllUser.UpdateAvatar(obj);
                    _Error = LibAlert.Alert.AlertSucess("Chúc mừng ! Bạn đã cập nhật thành công tài khoản !");
                    GetUserEdit();
                }
            }
            catch (Exception ex)
            {
                _Error = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình cập nhật" + "<br/>" + ex.Message);
            }
        }
        #endregion

        #region[Upload-Ajax]
        //protected void AjaxFileUploadEvent(object sender, AjaxFileUploadEventArgs e)
        //{
        //    string filename = System.IO.Path.GetFileName(e.FileName);
        //    const string strUploadPath = "~/Upload/";
        //    AjaxFileUpload11.SaveAs(Server.MapPath(strUploadPath) + filename);
        //}
        protected void FileUploadComplete(object sender, AsyncFileUploadEventArgs e)
        {
            
            if (Session["login"] != null && Session["UserName"] != null)
            {
                if ((bool)Session["login"])
                {
                    if (!Directory.Exists(UploadFolderPath + Session["FullName1"]))
                    {
                        string path = Server.MapPath(UploadFolderPath + Session["FullName1"] + "");
                        Directory.CreateDirectory(path);
                        string filename = Path.GetFileName(AsyncFileUpload1.FileName);
                        AsyncFileUpload1.SaveAs(Server.MapPath(UploadFolderPath) + Session["FullName1"] + "/" + filename);
                        UpdateValueImg(UploadFolderPath + Session["FullName1"] + "/" + filename);
                    }
                    else
                    {
                        string filename = Path.GetFileName(AsyncFileUpload1.FileName);
                        AsyncFileUpload1.SaveAs(Server.MapPath(UploadFolderPath) + Session["FullName1"] + "/" + filename);
                        UpdateValueImg(UploadFolderPath + Session["FullName1"] + "/" + filename);
                    }
                }
            }
        }
        #endregion
    }
}