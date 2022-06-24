using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace UpdateCategoryPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string strConn=ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            string strSQL="Update Categories set Picture=@Picture where CategoryID=@CategoryID";

            SqlConnection conn=new SqlConnection(strConn);
            SqlCommand cmd=new SqlCommand(strSQL, conn);
            cmd.CommandType=CommandType.Text;

            //Update Categories
            SqlParameter pCategoryID=new SqlParameter("@CategoryID", SqlDbType.Int);
            pCategoryID.Direction=ParameterDirection.Input;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pPicture=new SqlParameter("@Picture", SqlDbType.Image);
            pPicture.Direction=ParameterDirection.Input;
            cmd.Parameters.Add(pPicture);

            int i=1;
            conn.Open();
            DirectoryInfo dir=new DirectoryInfo("../../Motors");
            foreach (FileInfo fi  in dir.GetFiles("*.jpg"))
            {
                FileStream fs=new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                byte[] buf=new byte[fs.Length];
                fs.Read(buf, 0, (int)fs.Length);
                fs.Close();
                pPicture.Value=buf;
                pCategoryID.Value=i++;
                cmd.ExecuteNonQuery();
            }
            cmd.Dispose();

            //Update Employees
            string strSQL1 = "Update Employees set Photo=@Photo where EmployeeID=@EmployeeID";
            SqlCommand cmd1 = new SqlCommand(strSQL1, conn);
            cmd1.CommandType = CommandType.Text;

            SqlParameter pEmployeeID = new SqlParameter("@EmployeeID", SqlDbType.Int);
            pEmployeeID.Direction = ParameterDirection.Input;
            cmd1.Parameters.Add(pEmployeeID);

            SqlParameter pPhoto = new SqlParameter("@Photo", SqlDbType.Image);
            pPhoto.Direction = ParameterDirection.Input;
            cmd1.Parameters.Add(pPhoto);

            i = 1;
            DirectoryInfo dir1 = new DirectoryInfo("../../Photos");
            foreach (FileInfo fi in dir1.GetFiles("*.jpg"))
            {
                FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                byte[] buf = new byte[fs.Length];
                fs.Read(buf, 0, (int)fs.Length);
                fs.Close();
                pPhoto.Value = buf;
                pEmployeeID.Value = i;
                cmd1.ExecuteNonQuery();
                i += 1;
            }
            cmd1.Dispose();

            MessageBox.Show("更新成功!");
            conn.Close();
            conn.Dispose();
        }
    }
}