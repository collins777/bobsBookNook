using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

/// <summary>
/// Summary description for getOwnerId
/// </summary>
public class getOwnerID
{
    public getOwnerID()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // Page 14 - 15
    public static string getID(string uploadPath)
    {
        string ownerID; 

        try
        {
            ownerID = System.IO.File.ReadAllText(uploadPath + "ownerID.txt");
            ownerID = ownerID.Replace("\r\n", "");
            return (ownerID); 
        }
        catch { return (""); }
    }
}