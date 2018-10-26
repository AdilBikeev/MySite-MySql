using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySite.Models
{
    public class SiteDb
    {
        
        public  List<Users> listUsers = null;
        public  List<Sharp> listSharp = null;
        public SiteDb()
        {
           
        }
    }
}