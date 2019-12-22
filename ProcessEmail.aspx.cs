using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Page 6 // Project 5
using System.IO;
using System.Data.SqlClient;
using System.Data; 

/// <summary>
/// ///////////////////////// VIEW LINE 104
/// </summary>
public partial class ProcessEmail : System.Web.UI.Page
{

  
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page 7 // Project 5
        try
        {
            var data = File.ReadAllText(Server.MapPath("~/App_Data/ownerID.txt"));
            txtOwnerID.Text = data.ToString().Trim(); 
        } // end try 
        catch
        {
            Response.Redirect("Login.aspx"); 
        }

        string fileName = Server.MapPath("~/img") + "\\BookInventory.xml"; 

        try
        {
            if (File.Exists(fileName))
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (sr.Peek() >= 0)
                    {
                        string lineIn = sr.ReadLine();
                        lineIn = lineIn.Trim().ToUpper(); 
                        if (lineIn.StartsWith("<TITLE>") || lineIn.StartsWith("<AUTHOR>") || lineIn.StartsWith("<IMAGE>"))
                        {
                            lineIn = stripTags(lineIn);
                            lstRawXML.Items.Add(lineIn);
                        } 
                    }
                }
        }
        catch (Exception f)
        {
            Console.WriteLine("The process failed: {0}", f.ToString());
        }

    }

    // Page 7 // Project 5 
    private string stripTags(string field)
    {
        //throw new NotImplementedException();

        // remove first closing tag
        int x = field.IndexOf(">");
        field = field.Substring(x + 1);

        // remove second tag
        x = field.LastIndexOf("<");
        field = field.Substring(0, x);

        return (field);
    }

    // Page 6 // Project 5
    protected void btnBackToAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");  
    }

    // Page 8 // Project 5
    protected void btnGo_Click(object sender, EventArgs e)
    {
        string sqlCommand, author, title, image; 

        while (lstRawXML.Items.Count > 0)
        {
            title = lstRawXML.Items[0].ToString();
            lstRawXML.Items.RemoveAt(0);

            author = lstRawXML.Items[0].ToString();
            lstRawXML.Items.RemoveAt(0);

            image = lstRawXML.Items[0].ToString();
            lstRawXML.Items.RemoveAt(0);

            // add the new record to lstEmail 
            lstEmail.Items.Add(title + ":" + author + ":" + image);

            // look for users
            sqlCommand = "SELECT DISTINCT " + txtOwnerID.Text + "HISTORY.EMAIL FROM " + txtOwnerID.Text + "HISTORY WHERE " + txtOwnerID.Text + "HISTORY.ISBN IN (SELECT DISTINCT " + txtOwnerID.Text + "BOOKS.ISBN FROM " + txtOwnerID.Text + "BOOKS WHERE " + txtOwnerID.Text + "BOOKS.AUTHOR = '" + author + "')";
            fillListBox(sqlCommand, lstEmail, txtOwnerID.Text + "HISTORY", "EMAIL");

            btnStep2.Enabled = true;
            btnGo.Enabled = false; // Maybe change the text of btnGo to "Make XML"
        }
    }

    // Page 9 // Project 5
   void fillListBox (string sqlCommand, ListBox listBox, string tableName, string field)
    {
        DataRow dr;
        DataTable dt = new DataTable(); 

        try
        {
            // Open Data Connection 
            myDatabaseConnection.myConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, myDatabaseConnection.myConnection);
            da.Fill(dt); 

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                listBox.Items.Add(dr[field].ToString()); 
            }
            listBox.SelectedIndex = 0;
        }
        catch (Exception ex) { lblErrorMessage.Text = ex.ToString(); }

        try
        {
            // Close Data Connection
            myDatabaseConnection.myConnection.Close(); 
        }
        catch (Exception ex) { lblErrorMessage.Text = ex.ToString(); }
    }

    // Page 11 // Project 5
    protected void btnStep2_Click(object sender, EventArgs e)
    {
        string[] record = null;

        // throw new NotImplementedException(); 

        // Clear lstRawXML
        lstRawXML.Items.Clear();

        // Add the first two lines of the XML file 
        lstRawXML.Items.Add("<? xml version = \"1.0\" encoding = \"utf-8\" ?>");
        lstRawXML.Items.Add("<EMAIL>");

        // Process each record in the dropdown list
        while (lstEmail.Items.Count > 0)
        {
            if (lstEmail.Items[0].ToString().Contains(":"))
            {
                // get and parse title, author, image
                record = lstEmail.Items[0].ToString().Split(':');
            } 
            else
            {
                lstRawXML.Items.Add("<RECORD>");
                lstRawXML.Items.Add("<AUTHOR>" + record[1] + "</AUTHOR>");
                lstRawXML.Items.Add("<TITLE>" + record[0] + "</TITLE>");
                lstRawXML.Items.Add("<IMAGEURL>" + record[2] + "</IMAGEURL>");
                lstRawXML.Items.Add("<ADDRESS>" + lstEmail.Items[0].ToString() + "</ADDRESS>");
                lstRawXML.Items.Add("</RECORD>"); 
            }

            // Remove the first element within the dropdown list 
            lstEmail.Items.RemoveAt(0); 
        }
        // When down, add the closing </EMAIL> tag
        lstRawXML.Items.Add("</EMAIL>"); 
    }
}