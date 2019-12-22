using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkOut : System.Web.UI.Page
{
    // Page 8 // Project 4
    string ownerID;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page 8 // Project 4
        ownerID = getOwnerID.getID(Server.MapPath("~/App_Data/"));

        // Page 7 // Project 4
        if (!IsPostBack)
        {
            lblMessage.Text = "Please enter the email address for delivery of your books.";
            txtEmail.Visible = true;
            txtEmail.Text = "";
        }
        if (IsPostBack)
        {
            lblMessage.Visible = false;
            lblMessage.Text = "";
            // Page 8 // Project 4 // maintain email address for history
            string historyEmail = txtEmail.Text; 
            // Re-populate the txtbox with the message that says these are to be sent to you.
            txtEmail.Text = "The following books will be sent to " + txtEmail.Text + " within 10 minutes.";

            // Page 6 // Project 4
            string sqlCommand;
            string table2 = Session["tempUserID"].ToString();
            sqlCommand = "SELECT * FROM " + table2;
            myDatabaseConnection.executeSQL(sqlCommand, ref gvISBN, ref lblMessage);

            // Page 10 // Project 4
            Response.Write("Your card will be charged US $" + Math.Round(Convert.ToDecimal(gvISBN.Rows.Count * 5.99), 2) + "<br/>");


            // Page 8 - 9 // Project 4 // send purchases to History 
            sqlCommand = "INSERT INTO " + ownerID + "HISTORY (EMAIL, ISBN) SELECT '" + historyEmail + "', ISBN FROM " + table2;
            //Response.Write(sqlCommand); // Make sure to delete me prior to final submission
            myDatabaseConnection.executeSQL(sqlCommand, ref gvISBN, ref lblMessage);
            // Show contents of history just for validation. TO BE REMOVED
            //sqlCommand = "SELECT * FROM " + ownerID + "HISTORY"; // ----------------- Page 8 // Project 4
            //myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblMessage);

        // Page 9 // Project 4
        try
            {
                string table1 = ownerID + "BOOKS"; 
                sqlCommand = "SELECT TITLE, AUTHOR, " + table1 + ".ISBN from " + table1 + " INNER JOIN " + table2 + " ON " + table1 + ".ISBN = " + table2 + ".ISBN ";
                myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblMessage);
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }

            btnReturn.Enabled = true;// Page 11 // project 4
        }
   
    }

    // Page 11 // Project 4
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        string sqlCommand;
        string table2 = Session["tempUserID"].ToString();
        sqlCommand = "DROP TABLE " + table2;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvISBN, ref lblMessage);
        Session["tempUserID"] = null;
        Response.Redirect("Default1.aspx"); 
    }
}