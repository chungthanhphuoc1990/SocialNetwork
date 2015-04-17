using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation.page
{
    public partial class test : Page
    {
        readonly TextBox txtName = new TextBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            var up1 = new UpdatePanel {ChildrenAsTriggers = false, UpdateMode = UpdatePanelUpdateMode.Conditional};

            var lbl = new Label();
            var btn = new Button();
            lbl.ID = "lblName";
            btn.ID = "btnSave";
            btn.Text = "Save";
            btn.Click += btn_Click;
            up1.ContentTemplateContainer.Controls.Add(lbl);
            up1.ContentTemplateContainer.Controls.Add(txtName);
            up1.ContentTemplateContainer.Controls.Add(btn);
            var trig = new AsyncPostBackTrigger {ControlID = btn.ID, EventName = "Click"};
            up1.Triggers.Add(trig);
            PlaceHolder1.Controls.Add(up1);
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            txtName.Text = "Test";
        }
    }
}