using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace HrSystem
{
    public class ServerHelper
    {
        public string Server;
        public string DataBase;
        public string Uid;
        public string Pwd;
        public string Type;
        public string Address;
        public ServerHelper(string type, string server, string address, string database, string uid, string pwd)
        {
            Type = type;
            Server = server;
            Address = address;
            DataBase = database;
            Uid = uid;
            Pwd = pwd;
        }
        public SqlConnection SqlGetConn()
        {
            string LCS = "Server={0};DataBase={1};Uid={2};Pwd={3}";
            string ConnString = String.Format(LCS, Server, DataBase, Uid, Pwd);
            SqlConnection Conn = new SqlConnection(ConnString);
           
            return Conn;
        }
        public OleDbConnection AccessGetConn()
        {
            string LCS = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}";
            string ConnString = String.Format(LCS, Address);
            OleDbConnection Conn = new OleDbConnection(ConnString);
            return Conn;
        }
        public List<LoginObject> SelectUsername()
        {
            List<LoginObject> list = new List<LoginObject>();
            string sql = "select Username, Password, Competence  from UserName";
            if (Type == "Sql")
            {
                SqlConnection Conn = SqlGetConn();
                SqlCommand cmd = new SqlCommand(sql, Conn);
                Conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    list.Add(new LoginObject(Reader["Username"].ToString(), Reader["Password"].ToString(), Reader["Competence"].ToString()));
                }
                Conn.Close();
            }
            else
            {
                OleDbConnection Conn = AccessGetConn();
                OleDbCommand cmd = new OleDbCommand(sql, Conn);
                Conn.Open();
                OleDbDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    list.Add(new LoginObject(Reader["Username"].ToString(), Reader["Password"].ToString(), Reader["Competence"].ToString()));
                }
                Conn.Close();
            }
            return list;
        }
        public DataSet BindData(string sql)
        {
            DataSet ds = new DataSet();
            if (Type == "Access")
            {
                OleDbDataAdapter Oda = new OleDbDataAdapter(sql, AccessGetConn());
                Oda.Fill(ds);
            }
            else
            {
                SqlDataAdapter Sda = new SqlDataAdapter(sql, SqlGetConn());
                Sda.Fill(ds);
            }
            return ds;
        }
        public void Data(string sql)
        {
            if (Type == "Access")
            {
                OleDbConnection Conn = AccessGetConn();
                OleDbCommand cmd = new OleDbCommand(sql, Conn);
                Conn.Open();
                int i = (int)cmd.ExecuteNonQuery();
                Conn.Close();
            }
            else
            {
                SqlConnection Conn = SqlGetConn();
                SqlCommand cmd = new SqlCommand(sql, Conn);
                Conn.Open();
                int i = (int)cmd.ExecuteNonQuery();
                Conn.Close();
            }
        }
        public int Line(string Data)
        {
            string sql = "select * from " + Data;
            int i = 0;
            if (Type == "Access")
            {
                OleDbConnection Conn = AccessGetConn();
                OleDbCommand cmd = new OleDbCommand(sql, Conn);
                Conn.Open();
                i = (int)cmd.ExecuteNonQuery();
                Conn.Close();
            }
            else
            {
                SqlConnection Conn = SqlGetConn();
                SqlCommand cmd = new SqlCommand(sql, Conn);
                Conn.Open();
                i = (int)cmd.ExecuteNonQuery();
                Conn.Close();
            }
            return i;
        }
    }
}
