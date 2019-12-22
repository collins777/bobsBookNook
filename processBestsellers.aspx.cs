using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

public partial class processBestSellers : System.Web.UI.Page
{
    // Page 9
    string ownerID;

    protected void Page_Load(object sender, EventArgs e)
    {

        //--------------------------- Page 15
        // Page 9 
        //string uploadPath = Server.MapPath("~/App_Data/");
        //try
        //{
        //ownerID = System.IO.File.ReadAllText(uploadPath + "ownerID.txt");
        // Page 14
        //ownerID = ownerID.Replace("\r\n", "");
        //ownerID = ownerID.Trim(); 
        //Response.Write(ownerID + "<br />"); // error checking only
        //}
        //catch { }
        ownerID = getOwnerID.getID(Server.MapPath("~/App_Data/"));

        // Page 9 
        // gvCatalog
        string sqlCommand = "SELECT ISBN, TITLE, AUTHOR FROM " + ownerID + "BOOKS ORDER BY TITLE";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvCatalog, ref lblErrorMessage);

        // Page 10
        // gvBestSellers
        sqlCommand = "SELECT ISBN FROM " + ownerID + "BESTSELLER ORDER BY ISBN";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage); 
    }

    protected void btnReturnToAdmin_Click(object sender, EventArgs e)
    {
        // Page 9 
        Response.Redirect("Admin.aspx");
    }

    // Page 11 - 12
    protected void gvCatalog_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Write(gvCatalog.SelectedValue.ToString()); 
        string sqlCommand = "INSERT INTO " + ownerID + "BESTSELLER VALUES('" + gvCatalog.SelectedValue.ToString() + "')";

        //Response.Write(sqlCommand + "<br/>"); 
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage);

        sqlCommand = "SELECT ISBN FROM " + ownerID + "BESTSELLER ORDER BY ISBN";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage);
    }

    // Page 11 - 12
    protected void gvBestSellers_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sqlCommand = "DELETE FROM " + ownerID + "BESTSELLER WHERE ISBN = ('" + gvBestSellers.SelectedValue.ToString() + "')";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage);

        sqlCommand = "SELECT ISBN FROM " + ownerID + "BESTSELLER ORDER BY ISBN";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage); 
    }
}