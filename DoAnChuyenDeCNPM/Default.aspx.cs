using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace DoAnChuyenDeCNPM
{
    public partial class _Default : System.Web.UI.Page
    {
        public static List<String> listTableName = new List<string>();
        public static List<String> listColumnName = new List<string>();
        public static List<String> listColumnNameTemp1 = new List<string>();
        public static List<String> listTableNameTemp1 = new List<string>();
        public static List<String> listTableNameTemp2 = new List<string>();

        
        protected void Page_Load(object sender, EventArgs e)
        {
          
                this.GetTableName();
             
        }

        protected void ASPxComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
        }

      
        protected void CheckBoxListColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListItem item in CheckBoxListColumn.Items)
            {
                if(item.Selected)
                {
                    if(!listColumnName.Contains(item.Text.ToString()))
                    {
                        listColumnName.Add(item.Text.ToString());
                        listTableNameTemp2.Add(item.Value.ToString());
                    }
                }
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("TenCot", Type.GetType("System.String"));
            dt.Columns.Add("TenBang", Type.GetType("System.String"));

            string[] arrTemp1 = listColumnName.ToArray();
            string[] arrTemp2 = listTableNameTemp2.ToArray();

            for(int i = 0; i < arrTemp1.GetLength(0); i++)
            {
                dt.Rows.Add();
                dt.Rows[i]["TenCot"] = arrTemp1[i];
                dt.Rows[i]["TenBang"] = arrTemp2[i];
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ButtonQuery_Click(object sender, EventArgs e)
        {
            string mess = "";
            listColumnName = new List<string>();
            foreach(ListItem item in CheckBoxListColumn.Items)
            {
                if(item.Selected)
                {
                    listColumnName.Add(item.Text.ToString());
                }
            }

            //string tableName = string.Join(", ", listTableName);
            //string columnName = string.Join(", ", listColumnName);
            //mess += "SELECT " + columnName + " FROM " + tableName;
            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    CheckBox checkBox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
            //    if (checkBox.Checked)
            //    {
            //        TextBox strBang = new TextBox();
            //        TextBox strCot = new TextBox();
            //        TextBox dieuKien = (TextBox)GridView1.Rows[i].Cells[2].FindControl("TextBoxDieuKien");
            //        if (dieuKien.Text.ToString() != "")
            //        {

            //            strBang.Text = GridView1.Rows[i].Cells[4].Text;
            //            strCot.Text = GridView1.Rows[i].Cells[3].Text;
            //            lbltxt.Text += strBang.Text + "." + strCot.Text + " " + dieuKien.Text;
            //        }
            //    }

            //}


            // string tableName = string.Join(", ", listTableName);
            List<String> listTableName1 = new List<string>();
            string columnName = "";
            lbltxt.Text = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkBox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                if (checkBox.Checked)
                {

                    listTableName1.Add(GridView1.Rows[i].Cells[4].Text.ToString());

                    if (i != 0)
                    {
                        columnName = columnName + "," + GridView1.Rows[i].Cells[3].Text.ToString();
                    }
                    else
                    {
                        columnName = columnName + GridView1.Rows[i].Cells[3].Text.ToString();
                    }

                    TextBox strBang = new TextBox();
                    TextBox strCot = new TextBox();
                    TextBox dieuKien = (TextBox)GridView1.Rows[i].Cells[2].FindControl("TextBoxDieuKien");
                    if (dieuKien.Text.ToString() != "")
                    {

                        strBang.Text = GridView1.Rows[i].Cells[4].Text;
                        strCot.Text = GridView1.Rows[i].Cells[3].Text;
                       if (lbltxt.Text == "")
                        {
                            lbltxt.Text += strBang.Text + "." + strCot.Text + " " + dieuKien.Text;
                            
                        }
                        else
                        {
                            lbltxt.Text += "and" + strBang.Text + "." + strCot.Text + " " + dieuKien.Text;
                        }
                    }
                }

            }
            
            List<String> listtableLoc = listTableName1.Distinct().ToList();

            string tableName = string.Join(", ", listtableLoc);
            if (columnName != "")
                mess += "SELECT " + columnName + " FROM " + tableName;

            //

           if (mess != "")
            {
                if (lbltxt.Text.Trim() == "")
                {
                    LabelMess.Text = mess;
                }
                else
                {
                    LabelMess.Text = mess + " WHERE " + lbltxt.Text;
                }
            }
        } 


        private void GetTableName()
        {
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ApplicationServices"].ConnectionString;
                using(SqlCommand cmd = new SqlCommand())
                {
                    string query =
                        "SELECT ROW_NUMBER() OVER (ORDER BY TABLE_NAME) AS VALUE, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'TN_CSDLPT' AND TABLE_NAME NOT LIKE 'sys%' AND TABLE_NAME NOT LIKE 'MS%'";

                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    conn.Open();
                    using(SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["TABLE_NAME"].ToString();
                            item.Value = sdr["VALUE"].ToString();
                            //CheckBoxListTable.Items.Add(item);
                            //CheckBoxListTable.AutoPostBack = true;
                            if (CheckBoxListTable.Items.Count <= 9)
                            {
                                CheckBoxListTable.Items.Add(item);
                                CheckBoxListTable.AutoPostBack = true;
                            }
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void GetColumnName(String tableName)
        {
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                using(SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" +
                        tableName +
                        "' AND COLUMN_NAME NOT LIKE 'rowguid%'";

                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    conn.Open();
                    int i = 0;
                    using(SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["COLUMN_NAME"].ToString();
                            item.Value = tableName.ToString();
                            CheckBoxListColumn.Items.Add(item);
                            CheckBoxListColumn.RepeatColumns = 5;
                            CheckBoxListColumn.AutoPostBack = true;
                            DataTable dt = new DataTable(tableName);
                            i++;
                        }

                    }
                    conn.Close();
                }
            }
        }


        protected void ASPxButton1_Click1(object sender, EventArgs e)
        {

            String query = LabelMess.Text;
            Session["query"] = query;
            Response.Redirect("Report.aspx");
            Server.Execute("Report.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

      

        protected void CheckBoxListTable_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CheckBoxListColumn.Items.Clear();
            listTableName.Clear();
            foreach (ListItem item in CheckBoxListTable.Items)
            {
                if (item.Selected)
                {
                    listTableName.Add(item.Text);
                }
            }
            for (int i = 0; i < listTableName.Count; i++)
            {
                GetColumnName(listTableName[i].ToString());
            }
            // DataTable dt = new DataTable();

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
          
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkBox.NamingContainer;
        }

        protected void checkHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkHead = (CheckBox)GridView1.HeaderRow.FindControl("checkHeader");
            foreach (GridViewRow row  in GridView1.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("CheckBox1");
                if (chkHead.Checked == true)
                {
                    chkRow.Checked = true; 
                }
                else
                {
                    chkRow.Checked = false;
                }
            }

        }
    }
}