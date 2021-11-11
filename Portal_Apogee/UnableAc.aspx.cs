using System;

namespace Portal_Apogee
{
    public partial class UnableAc : System.Web.UI.Page
    {
        AccessCode ac = new AccessCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = ac.LlenarDG("select * from accesscode where used = 1").Tables[0];
            GridView1.DataBind();

        }
    }
}