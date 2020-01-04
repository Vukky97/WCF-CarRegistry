using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference;

public partial class _Default : System.Web.UI.Page
{
    ServiceReference.MyServiceClient msc = new MyServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {   
            this.GridView.DataSource = msc.findAll().Select(p
            => new { id = p.Id, name = p.Username, pass = p.Password }).ToList();
            this.GridView.DataBind();
        }

    }
}