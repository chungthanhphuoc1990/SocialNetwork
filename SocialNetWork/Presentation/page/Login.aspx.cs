using System;
using System.Data;
using System.Web;
using System.Web.Configuration;
using LibBusinessLayer;
using LibDataLayer;

namespace Presentation.page
{
    public partial class Login : System.Web.UI.Page
    {
        #region[Define]
        protected string _Error = string.Empty;
        protected string _ErrorLogin = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            formLoginPage.Action = Request.RawUrl;
            if (!IsPostBack)
            {
                GetCountry();
                GetLanguages();
                txtUserNameLogin.Focus();
                var cookie = Request.Cookies["login"];
                if (Session["login"] != null)
                {
                    if ((bool)(Session["login"]))
                    {
                        Response.Redirect(@"/");
                    }
                }
                if (cookie != null)
                {
                    Response.Redirect(@"/");
                }
            }
        }
        protected void btnSigin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Value))
            {
                _Error = LibAlert.Alert.AlertError("Vui lòng điền vào tên đăng nhập của bạn !");
            }
            else if (txtUserName.Value.Length < 6)
            {
                _Error = LibAlert.Alert.AlertError("Tên đăng nhập phải từ 6 ký tự trở lên !");
            }
            else if (String.IsNullOrEmpty(txtFullName.Value))
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
            else if (String.IsNullOrEmpty(txtPassword.Value))
            {
                _Error = LibAlert.Alert.AlertError("Vui lòng điền vào mật khẩu của bạn của bạn của bạn !");
            }
            else if (txtPassword.Value.Length < 6)
            {
                _Error = LibAlert.Alert.AlertError("Mật khẩu phải từ 6 ký tự trở lên !");
            }
            else
            {
                InsertValue();
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserNameLogin.Value))
            {
                _ErrorLogin = LibAlert.Alert.AlertError("Vui lòng điền vào tên đăng nhập hoặc Email của bạn !");
            }
            else if (String.IsNullOrEmpty(txtPasswordLogin.Value))
            {
                _ErrorLogin = LibAlert.Alert.AlertError("Vui lòng điền vào tên mật khẩu của bạn !");
            }
            else
            {
                CheckLogin();
            }
        }
        #endregion

        #region[Method]
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
        private void CheckLogin()
        {
            var _clsGetUserLogin = new BllUser();
            var cookie = new HttpCookie("login");
            string strsession = LibHasCode.Encode.EncodePassword(txtPasswordLogin.Value);
            var _dtGetUserLogin = _clsGetUserLogin.GetUserLogin(txtUserNameLogin.Value, strsession);
            if (_dtGetUserLogin != null && _dtGetUserLogin.Rows.Count > 0)
            {
                if (txtUserNameLogin.Value.Trim() == _dtGetUserLogin.Rows[0]["UserName"].ToString() &&
                    strsession.Trim().ToUpper() == _dtGetUserLogin.Rows[0]["Password"].ToString() ||
                    txtUserNameLogin.Value.Trim() == _dtGetUserLogin.Rows[0]["Email"].ToString() &&
                    strsession.Trim().ToUpper() == _dtGetUserLogin.Rows[0]["Password"].ToString())
                {
                    if (chkRemember.Checked)
                    {
                        Session["login"] = true;
                        Session["UserName"] = txtUserNameLogin.Value;
                        Session["AccountID"] = _dtGetUserLogin.Rows[0]["AccountID"].ToString();
                        Session["Group_Id"] = _dtGetUserLogin.Rows[0]["Group_Id"].ToString();
                        Session["Lock"] = _dtGetUserLogin.Rows[0]["Lock"].ToString();
                        Session["FullName"] = _dtGetUserLogin.Rows[0]["FullName"].ToString();
                        Session["FullName1"] = _dtGetUserLogin.Rows[0]["UserName"].ToString();

                        cookie["UserName"] = Session["UserName"].ToString();
                        cookie["AccountID"] = Session["AccountID"].ToString();
                        cookie["Group_Id"] = Session["Group_Id"].ToString();
                        cookie["Lock"] = Session["Lock"].ToString();
                        cookie["FullName"] = Session["FullName"].ToString();
                        cookie["FullName1"] = Session["FullName1"].ToString();

                        cookie.Expires = DateTime.Now.AddDays(double.Parse(WebConfigurationManager.AppSettings["TimeOut"]));
                        Response.Cookies.Add(cookie);
                        Response.Redirect("/");
                    }
                    else
                    {
                        Session["login"] = true;
                        Session["UserName"] = txtUserNameLogin.Value;
                        Session["AccountID"] = _dtGetUserLogin.Rows[0]["AccountID"].ToString();
                        Session["Group_Id"] = _dtGetUserLogin.Rows[0]["Group_Id"].ToString();
                        Session["Lock"] = _dtGetUserLogin.Rows[0]["Lock"].ToString();
                        Session["FullName"] = _dtGetUserLogin.Rows[0]["FullName"].ToString();
                        Session["FullName1"] = _dtGetUserLogin.Rows[0]["UserName"].ToString();
                        Response.Redirect("/");
                    }
                }
                else
                {
                    _ErrorLogin = LibAlert.Alert.AlertError("Tên đăng nhập,tài khoản không chính xác hoặc đã bị khoá !");
                    Session["login"] = false;
                    Session.RemoveAll();
                    Session.Abandon();

                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                    //Response.Redirect("/login-page/");
                }
            }
            else
            {
                _ErrorLogin = LibAlert.Alert.AlertError("Tên đăng nhập,tài khoản không chính xác hoặc đã bị khoá !");
                Session["login"] = false;
                Session.RemoveAll();
                Session.Abandon();

                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                //Response.Redirect("/login-page/");
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
                    if (txtUserName.Value == dr["UserName"].ToString())
                    {
                        check = true;
                        _Error =
                            LibAlert.Alert.AlertError("Tên đăng nhập này đã tồn tại.Vui lòng chọn tên đăng nhập khác !");
                    }
                    else if (txtEmail.Value == dr["Email"].ToString())
                    {
                        check = true;
                        _Error =
                            LibAlert.Alert.AlertError("Email này đã tồn tại.Vui lòng chọn Email !");
                    }
                }
            }
            return check;
        }
        private void InsertValue()
        {
            try
            {
                if (!CheckInsert())
                {
                    var obj = new DTOUser
                    {
                        Email = txtEmail.Value,
                        FullName = txtFullName.Value,
                        Password = LibHasCode.Encode.EncodePassword(txtPassword.Value),
                        UserName = txtUserName.Value,
                        Group_Id = null,
                        Gender = rdMade.Checked ? "Nam" : "Nữ",
                        Birthday = DateTime.Parse(txtBirthday.Value),
                        Country_ID = int.Parse(drCountry.SelectedValue),
                        Language_ID = int.Parse(drLanguage.SelectedValue),
                        User_Image = "../img/unnamed.png",
                        DateBegin = DateTime.Now
                    };
                    BllUser.Insert(obj);
                    _Error = LibAlert.Alert.AlertSucess("Chúc mừng ! Bạn đã đăng ký thành công tài khoản !");
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                _Error = LibAlert.Alert.AlertError("Có lỗi xảy ra trong quá trình đăng ký" + "<br/>" + ex.Message);
            }
        }
        #endregion

        #region[Clear-Text]
        private void ClearText()
        {
            txtUserName.Value = string.Empty;
            txtFullName.Value = string.Empty;
            txtEmail.Value = string.Empty;
            txtBirthday.Value = string.Empty;
            rdMade.Checked = true;
            drCountry.SelectedIndex = -1;
            drLanguage.SelectedIndex = -1;
            txtPassword.Value = string.Empty;
        }
        #endregion
    }
}