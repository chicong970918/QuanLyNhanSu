using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.IO;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Management.Smo;

namespace HRM.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    ///  17/05/22
    /// PC
    public class DBConnectionBLL
    {
        public DataTable LayDataSource()
        {
            SqlDataSourceEnumerator thehien = SqlDataSourceEnumerator.Instance;
            return thehien.GetDataSources();
        }

        public string[] LayDataSource1()
        {
            DataTable bang = LayDataSource();
            List<string> ls = new List<string>();
            foreach (DataRow r in bang.Rows)
            {
                if (r["InstanceName"] != DBNull.Value)
                    ls.Add(String.Format(@"{0}\{1}", r["ServerName"], r["InstanceName"]));
                else
                    ls.Add((string)r["ServerName"]);
            }
            return ls.ToArray();
        }

        public string[] GetDatabaseName(string pSever, string user, string pass)
        {
            List<string> ls = new List<string>();

            Microsoft.SqlServer.Management.Common.ServerConnection serverConnection = new Microsoft.SqlServer.Management.Common.ServerConnection();

            serverConnection.ServerInstance = pSever;

            serverConnection.LoginSecure = true;

            serverConnection.LoginSecure = false;

            serverConnection.Login = user;

            serverConnection.Password = pass;

            Server server = new Server(serverConnection);

            try
            {
                foreach (Database db in server.Databases)
                {
                    ls.Add(db.Name);
                }
            }
            catch
            {

            }

            return ls.ToArray();
        }

        public void Write(string s)
        {
            string conn = string.Empty;
            conn += ("<?xml version=" + '"' + "1.0" + '"' + "?>") + "\r\n"
                + "<configuration>" + "\r\n"
              + "<configSections>" + "\r\n"
              + "<sectionGroup name=" + '"' + "applicationSettings" + '"' + " type=" + '"' + "System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" + '"' + '>' + "\r\n"
              + "<section name=" + '"' + "HRM.Properties.Settings" + '"' + " type=" + '"' + "System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" + '"' + " requirePermission=" + '"' + "false" + '"' + " />" + "\r\n"
              + "</sectionGroup>" + "\r\n"
              + " </configSections>" + "\r\n"
              + " <startup>" + "\r\n"
              + "<supportedRuntime version=" + '"' + "v4.0" + '"' + " sku=" + '"' + ".NETFramework,Version=v4.0" + '"' + "/>" + "\r\n"
              + "</startup>" + "\r\n"
              + " <connectionStrings>" + "\r\n"
              + "<add name=" + '"' + "HRM.Entities.Properties.Settings.HRMQUANLYNHANSUConnectionString" + '"' + "\r\n"
              + " connectionString=" + '"'
              + s + '"' + "\r\n"
              + " providerName=" + '"' + "System.Data.SqlClient" + '"' + " />" + "\r\n"
              + " </connectionStrings>" + "\r\n"
              + "</configuration>";

            FileInfo myfile = new FileInfo("HRM.exe.config");
            StreamWriter tex = myfile.CreateText();

            // tex.Write(tex.NewLine);
            tex.Write(conn);
            tex.Close();


            //  string s = sss + "s";
            // doc file
            //try
            //{
            //    //StreamReader Re = File.OpenText("HRM.exe.config");
            //    //string input = null;
            //    //while ((input = Re.ReadLine()) != null)
            //    //{
            //    //    Console.WriteLine(input);
            //    //}

            //    //Re.Close();
            //}
            //catch
            //{
            //    //Ghi file
            //    FileInfo myfile = new FileInfo("HRM.exe.config");
            //    StreamWriter tex = myfile.CreateText();

            //    tex.Write(tex.NewLine);
            //    tex.WriteLine(sss);
            //    tex.Close();
            //}
            //  Console.ReadKey();
        }
    }
}
