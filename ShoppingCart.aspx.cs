using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    // Page 19 // Project 3
    string ownerID;


    protected void Page_Load(object sender, EventArgs e)
    {
        // Page 19 // Project 3
        ownerID = getOwnerID.getID(Server.MapPath("~/App_Data/"));

        //-------------------------- Page 20 // project 3
        //try
        //{
        // Save session variable 
        //    Session[Session.Count.ToString()] = Request.QueryString["id"];
        //    // Display session variable
        //    for (int i = 0; i < Session.Count; i++)
        //    {
        //        Response.Write("<br />" + Session[i.ToString()]); // There was an error here on page 13 - Project 2 Instructions
        //    }
        //} ----------------------- Directions cut off here on Page 20 // project 3
        //  catch
        //{
        //    Response.Redirect("~/Default1.aspx");
        //}
        string newTempUserID = "";
        string tempUserSource = "A" + "B" + "C" + "D" + "E" + "F" + "G" + "H" + "I" + "J" + "K" + "L" + "M" + "N" + "O" + "P" + "Q" + "R" + "S" + "T" + "U" + "V" + "W" + "X" + "Y" + "Z" + "0" + "1" + "2" + "3" + "4" + "5" + "6" + "7" + "8" + "9";
        // Remove after testing 
        //Response.Write(tempUserSource + "<hr>"); 

        //------------------------------ Page 21 / project 3
        try
        {
            // Why do we use a try catch? Session will toss an error if tempUserID does not exist. 
            // thus an else can not be used in this example. 
            if (Session["tempUserID"].ToString() == "")
            {
                ;
            }
        } catch
        {
            // Create a unique temporary ID 20 characters long. Must start with a letter
            Random r = new Random();
            int index = r.Next(0, 26); // Makes sure first character is a letter 
            newTempUserID += tempUserSource.Substring(index, 1); 

            for (int i = 2; i < 21; i++)
            {
                index = r.Next(0, 36);
                // Must be += or we only capture the last letter. 
                newTempUserID += tempUserSource.Substring(index, 1);
                //Response.Write(newTempUserID + "<HR>"); //-------------- Removed on Page 22 // project 3
            }
            //-------------------- Page 23 // place it in a session variable  // project 3
            Session["tempUserID"] = newTempUserID;

            //-------------------- Page 23 // project 3
            string sqlCommand = "CREATE TABLE " + newTempUserID + " (ISBN CHAR(14))";
            myDatabaseConnection.executeSQL(sqlCommand, ref gvShoppingCart, ref lblErrorMessage); 

        }

        // Page 25 ----- lock the call to addToShopping cart with (!IsPostBack) // project 3
        if (!IsPostBack)
        {
            //------------------------- Page 23 // show session variable so we know it works 
            //Response.Write(Session["tempUserID"].ToString() + "<br/>"); // ----- Page 28 // project 3
            // Show ISBN of new selection
            //Response.Write(Request.QueryString["id"] + "<br/>"); // ------- Page 28 // project 3
            //------------------------- Page 24 // add ISBN to database table and view // project 3
            addToShoppingList(Session["tempUserID"].ToString(), Request.QueryString["id"]);
        }

        // ----------------------- Page 25 // project 3
        viewGvDisplay();
        // Page 13 // Project 4 
        loadPurchase(Request.QueryString["id"]);
    }

    // Page 13 // Project 4
    private void loadPurchase(string ISBN)
    {
        string sqlCommand;
        //throw new NotImplementedException();
        sqlCommand = "SELECT DISTINCT EMAIL FROM " + ownerID + "HISTORY WHERE ISBN = '" + ISBN + "'";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvPeopleWhoPurchasedThis, ref lblErrorMessage);

        // Page 13.... 
        sqlCommand = "SELELCT DISTINCT ISBN FROM " + ownerID + "HISTORY WHERE " + ownerID + "HISTORY.EMAIL IN (SELECT DISTINCT " + ownerID + "HISTORY.EMAIL FROM " + ownerID + "HISTORY WHERE " + ownerID + "HISTORY.ISBN = '" + ISBN + "')";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvPeopleWhoPurchasedThis, ref lblErrorMessage);

        
        sqlCommand = "SELECT * FROM " + ownerID + "BOOKS WHERE " + ownerID + "BOOKS.ISBN IN (SELECT DISTINCT ISBN FROM " + ownerID + "HISTORY WHERE " + ownerID + "HISTORY.EMAIL IN (SELECT DISTINCT " + ownerID + "HISTORY.EMAIL FROM " + ownerID + "HISTORY WHERE " + ownerID + "HISTORY.ISBN = '" + ISBN + "'))";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvPeopleWhoPurchasedThis, ref lblErrorMessage);

        sqlCommand = "SELECT * FROM " + ownerID + "BOOKS WHERE " + ownerID + "BOOKS.ISBN NOT LIKE '" + ISBN + "' AND " + ownerID + "BOOKS.ISBN IN (SELECT DISTINCT ISBN FROM " + ownerID + "HISTORY WHERE " + ownerID + "HISTORY.EMAIL IN (SELECT DISTINCT " + ownerID + "HISTORY.EMAIL FROM " + ownerID + "HISTORY WHERE " + ownerID + "HISTORY.ISBN = '" + ISBN + "'))";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvPeopleWhoPurchasedThis, ref lblErrorMessage);

        sqlCommand = "SELECT IMAGE, TITLE, AUTHOR, ISBN FROM " + ownerID + "BOOKS WHERE " + ownerID + "BOOKS.ISBN NOT LIKE '" + ISBN + "' AND " + ownerID + "BOOKS.ISBN IN (SELECT DISTINCT ISBN FROM " + ownerID + "HISTORY WHERE " + ownerID + "HISTORY.EMAIL IN (SELECT DISTINCT " + ownerID + "HISTORY.EMAIL FROM " + ownerID + "HISTORY WHERE " + ownerID + "HISTORY.ISBN = '" + ISBN + "'))";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvPeopleWhoPurchasedThis, ref lblErrorMessage); 

    }

    // Page 25 // project 3
    private void viewGvDisplay()
    {
        string sqlCommand; 

        //throw new NotImplementedException();

        try
        {
            string table1 = ownerID + "BOOKS";
            string table2 = Session["tempUserID"].ToString();
            sqlCommand = "SELECT IMAGE, AUTHOR, TITLE, " + table1 + ".ISBN from " + table1 + " INNER JOIN " + table2 + " ON " + table1 + ".ISBN = " + table2 + ".ISBN ";
            myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage); 
        }
        catch
        {
            Response.Redirect("Default1.aspx"); 
        }
    }

    // Page 24 // project 3
    private void addToShoppingList(string userID, string ISBN)
    {
        // throw new NotImplementedException();
        string sqlCommand = "INSERT INTO " + userID + " VALUES(" + ISBN + ")";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvShoppingCart, ref lblErrorMessage);
        //sqlCommand = "SELECT * FROM " + userID; //-------------- Page 29 / project 3
        //myDatabaseConnection.executeSQL(sqlCommand, ref gvShoppingCart, ref lblErrorMessage); //----------- Page 29 / project 3
    }

    protected void toBrowsing_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default1.aspx"); 
    }

    // Page 20 // project 3
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        // Page 5 ------------------------------- Project 4
        //try
        //{
        //    string sqlCommand;
        //    string table2 = Session["tempUserID"].ToString();
        //    sqlCommand = "DROP TABLE " + table2;
        //    myDatabaseConnection.executeSQL(sqlCommand, ref gvShoppingCart, ref lblErrorMessage);
        //    Session["tempUserID"] = null; 
        //} 
        //catch { }
        //Response.Redirect("Default1.aspx");
        Response.Redirect("CheckOut.aspx");
    }

    // Page 26  // project 3
    protected string FormatImageUrl(string url)
    {
        if (url != null && url.Length > 0)
            return ("~/" + url);
        else return null;
    }

    // Page 27 // project 3
    protected void gvDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Write(gvDisplay.SelectedValue.ToString());
        //------------------------------------------------- Page 27 // project 3
        string sqlCommand;
        string table1 = ownerID + "BOOKS";
        string table2 = Session["tempUserID"].ToString();

        sqlCommand = "DELETE FROM " + table2 + " WHERE ISBN = " + gvDisplay.SelectedValue;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);

        sqlCommand = "SELECT IMAGE, AUTHOR, TITLE, " + table1 + ".ISBN from " + table1 + " INNER JOIN " + table2 + " ON " + table1 + ".ISBN = " + table2 + ".ISBN ";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage); 
    }

    // Page 18
    protected void gvPeopleWhoPurchasedThis_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ShoppingCart.aspx?ID=" + gvPeopleWhoPurchasedThis.SelectedValue);
    }
}