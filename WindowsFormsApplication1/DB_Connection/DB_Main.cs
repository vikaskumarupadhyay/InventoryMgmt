using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


    class DB_Main
    {

        public int saveDetails(string InsertQuery)
        {
            int insertedRows = 0;
            try
            {
                SqlConnection con = openConnection();
                if (con.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(InsertQuery, con);
                    insertedRows = cmd.ExecuteNonQuery();
                    closeConnection(con);
                }

            }
            catch (Exception ex)
            {

            } return insertedRows;
        }

        public string getUniqueID(string TableName) 
        {
            string ColumnId = "";
            try
            {
                ColumnId = getUniqueIDFromDb(TableName);
                
                if (ColumnId == "Error")
                {

                }
                else if (ColumnId == "" || ColumnId == null || ColumnId.ToUpper() =="NULL")
                {
                    ColumnId = TableName.Substring(0, 1) + "0001";
                }
                else
                {
                    ColumnId = ColumnId[0].ToString() + (Convert.ToInt32(ColumnId.Substring(1))+1).ToString();
                }
            }
            catch (Exception ex)
            {
                ColumnId = "ERROR";
            }
            
            return ColumnId;
        }

        private string getUniqueIDFromDb(string TableName) 
        {
            string Value = "";
            string ProcedureName = "GetUpdateCounter";//Item
            ProcedureName = getProcedureName(TableName, ProcedureName);
            try 
            {
                SqlConnection con = openConnection();
                if (con != null) 
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = ProcedureName;
                    cmd.Connection = con;
                    SqlDataReader dr= cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        Value = dr.GetString(0);
                    }
                    closeConnection(con);
                }
            }
            catch (Exception ex)
            {
                Value = "Error";
            }
            return Value;
        }

        public int saveDetails(string InsertQuery1, string InsertQuery2)
        {
            int insertedRows = 0;
            SqlTransaction trans = null;
            try
            {
                SqlConnection con = openConnection();

                //trans.Connection = con;
                trans = con.BeginTransaction();

                if (con.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(InsertQuery1, con, trans);
                    insertedRows = cmd.ExecuteNonQuery();
                    if (insertedRows < 1)
                    {
                        trans.Rollback();
                    }
                    else
                    {
                        cmd = new SqlCommand(InsertQuery2, con, trans);
                        insertedRows = cmd.ExecuteNonQuery();
                        if (insertedRows > 0)
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }

                    closeConnection(con);
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
           
            return insertedRows;
        }

              


        public int saveDetails(string InsertQuery1, string InsertQuery2, string InsertQuery3)
        {
            int insertedRows = 0;
            SqlTransaction trans = null;
            try
            {
                SqlConnection con = openConnection();

                //trans.Connection = con;
                trans = con.BeginTransaction();

                if (con.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(InsertQuery1, con, trans);
                    insertedRows = cmd.ExecuteNonQuery();
                    if (insertedRows < 1)
                    {
                        trans.Rollback();
                    }
                    else
                    {
                        cmd = new SqlCommand(InsertQuery2, con, trans);
                        insertedRows = cmd.ExecuteNonQuery();
                        if (insertedRows > 0)
                        {
                            cmd = new SqlCommand(InsertQuery3, con, trans);
                            insertedRows = cmd.ExecuteNonQuery();
                            if (insertedRows > 0)
                            {
                                trans.Commit();
                            }
                            else 
                            {
                                trans.Rollback();
                            }
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }

                    closeConnection(con);
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
           
            return insertedRows;
        }

        public int saveDetails(List<string> insertquerycollection)
        {
            int insertrows = 0;
            SqlTransaction trans = null;
            try
            {
                SqlConnection con = openConnection();
                trans = con.BeginTransaction();
                bool success = true;
                foreach (string sqlquery in insertquerycollection)
                {
                    SqlCommand cmd = new SqlCommand(sqlquery, con, trans);
                    insertrows = cmd.ExecuteNonQuery();
                    if (insertrows < 1)
                    {
                        success = false;
                        break;
                    }
                }
                if (success)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
                closeConnection(con);
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
            return insertrows;
        }
        public SqlConnection openConnection()
        {
            SqlConnection con = new SqlConnection();

            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            con.ConnectionString = ConnectionString;
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {

            }
            return con;
        }


        public void closeConnection(SqlConnection con)
        {
            
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private string getProcedureName(string TableName,string ProcedureName) 
        {
           // string ProcedureName = "GETALLDATA";//Item
                                     //VENDOR
            if (TableName != null && TableName != "")
            {
                if (TableName.ToUpper().Contains("ITEM"))
                {
                    ProcedureName = ProcedureName + "ITEM";
                }
                else if (TableName.ToUpper().Contains("CUST"))
                {
                    ProcedureName = ProcedureName + "CUSTOMER";
                }
                else if (TableName.ToUpper().Contains("VENDOR"))
                {
                    ProcedureName = ProcedureName + "VENDER";
                }
                else if (TableName.ToUpper().Contains("GROUP"))
                {
                    ProcedureName = ProcedureName + "GROUP";
                }
                else if (TableName.ToUpper().Contains("UNIT"))
                {
                    ProcedureName = ProcedureName + "UNIT";
                }
            }
            return ProcedureName;
        }

                
        public int updateDetails(string updateCommand1,string updateCommand2)
        {
            int rowUpdated = 0;
            SqlTransaction trans = null;
            try
            {
                SqlConnection con = openConnection();

                //trans.Connection = con;
                trans = con.BeginTransaction();

                if (con.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(updateCommand1, con, trans);
                    rowUpdated = cmd.ExecuteNonQuery();
                    if (rowUpdated < 1)
                    {
                        trans.Rollback();
                    }
                    else
                    {
                        cmd = new SqlCommand(updateCommand2, con, trans);
                        rowUpdated = cmd.ExecuteNonQuery();
                        if (rowUpdated > 0)
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                    closeConnection(con);

                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
            } 
            return rowUpdated;
        }


        public DataTable getDataBoundToComboBox(string SelectCommand) 
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = openConnection();
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SelectCommand;
                    cmd.Connection = con;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    closeConnection(con);
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }


        public DataTable getDetails(string TableName) 
        {
            DataTable dt = new DataTable();
            try 
            {
                string ProcedureName = "GETALLDATA";//Item
                ProcedureName = getProcedureName(TableName, ProcedureName);
                SqlConnection con = openConnection();
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = ProcedureName;
                    cmd.Connection = con;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    closeConnection(con);
                }

            }
            catch (Exception ex)
            {
            
            }
            return dt;
        }


        public DataTable getDetailByQuery(string Query) 
        {
            DataTable dt = new DataTable();
            try
            {
                //string ProcedureName = "GETALLDATA";//Item
                //ProcedureName = getProcedureName(TableName, ProcedureName);
                SqlConnection con = openConnection();
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Query;
                    cmd.Connection = con;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    closeConnection(con);
                }

            }
            catch (Exception ex)
            {

            }
            return dt;
        }


        public string getId(string Table)
        {
            string Id = getUniqueID(Table);
            if (!Id.Contains("ERROR"))
            {
                if (Id.Length == 2)
                {
                    Id = Id[0].ToString() + "000" + Id[1].ToString();
                }
                else if (Id.Length == 3)
                {
                    Id = Id[0].ToString() + "00" + Id.Substring(1);
                }
                else if (Id.Length == 4)
                {
                    Id = Id[0].ToString() + "0" + Id.Substring(1);
                }
            }
            return Id;
        }
    }

