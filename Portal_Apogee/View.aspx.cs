using System;

namespace Portal_Apogee
{
    public partial class View : System.Web.UI.Page
    {
        AccessCode ac = new AccessCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            //datagrid1.DataSource = ac.LlenarDG("select * from accesscode").Tables[0];
            //datagrid1.DataBind();

        }
    }
}