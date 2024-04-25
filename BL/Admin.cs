using LIBRARY;
using MODEL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace BL
{
    public class Admin
    {

        /// <summary>
        /// Name : Amit Pipaliya
        /// Date : 18-04-24
        /// This Method Use  For Admin Login 
        /// </summary>
        public SerializeResponse<AdminModel> AdminMethod(AdminModel objEntity)
        {
            InsertLog.WriteErrrorLog("Admin Login BL  ==>  Admin Login  ==>  Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<AdminModel> objResponsemessage = new SerializeResponse<AdminModel>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();
            string query = "SP_Admin";
            try
            {
                string Con_str = Connection.ConnectionString();
                SqlParameter prm1 = objSDP.CreateInitializedParameter("@AdminId", DbType.Int64, objEntity.AdminId);
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@AdminName", DbType.String, objEntity.AdminName);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@EmailId", DbType.String, objEntity.EmailId);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@Password", DbType.String, objEntity.Password);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@MobileNo", DbType.String, objEntity.MobileNo);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@Address", DbType.String, objEntity.Address);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@FLAG", DbType.String, objEntity.FLAG);

                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7 };

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.FLAG == "AdminLogin" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objResponsemessage.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    objResponsemessage.Message = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
                }
                else if (ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count == 0)
                {
                    objResponsemessage.Message = "400|No Data Found";
                }
            }
            catch (Exception ex)
            {
                objResponsemessage.Message = "500|Exception Occurred";
                InsertLog.WriteErrrorLog("Admin Login BL  ==>  Admin Login  =>  Exception" + ex.Message + ex.StackTrace);
            }
            return objResponsemessage;
        }
    }
}