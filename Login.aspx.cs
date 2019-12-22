using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using System.IO; // Page 7 - last line

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  
    }

 

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Page 11 
        // use a boolean flag to indicate errors
        bool okFlag = true; 
        // make sure ownerID is entered twice in the form 
        if ((txtOwnerID.Text == "") || (txtOwnerID0.Text == ""))
        {
            okFlag = false;
            txtOwnerID.Text = "";
            txtOwnerID0.Text = "";
            txtOwnerID.Focus(); 
        }
        // make sure ownerIDs match 
        if (txtOwnerID.Text != txtOwnerID0.Text)
        {
            okFlag = false;
            txtOwnerID.Text = "";
            txtOwnerID0.Text = "";
            txtOwnerID.Focus();
        }
        // if ownerID does not end with underscore, simply add it 
        if (!txtOwnerID.Text.EndsWith("_"))
        {
            txtOwnerID.Text += "_"; 
        }
        // Check okFlag for 'permission' to go back to Admin
        if (okFlag)
        {
            // This is the originl code to write the file and move to Admin 
            using (StreamWriter _writeFile = new StreamWriter(Server.MapPath("~/App_Data/ownerID.txt"), false))
            {
                _writeFile.WriteLine(txtOwnerID.Text); // Write the file 
                Response.Redirect("Admin.aspx");
            }
        } // end of if(okFlag) 

      
    }
}