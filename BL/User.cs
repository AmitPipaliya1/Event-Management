using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using LIBRARY;

namespace BL
{
    public class User
    {
        //---------------------- USER CREAT AND LOGIN METHOD ---------------------------
        public SerializeResponse<UserModel> UserMethod(UserModel objEntity)
        {
            InsertLog.WriteErrrorLog("InsertUserBL  ==>  UserCreation  ==>  Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<UserModel> objResponsemessage = new SerializeResponse<UserModel>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();
            string query = "SP_User";
            try
            {
                string Con_str = Connection.ConnectionString();
                SqlParameter prm1 = objSDP.CreateInitializedParameter("@UserId", DbType.Int64, objEntity.UserId);
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@Name", DbType.String, objEntity.Name);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@EmailId", DbType.String, objEntity.EmailId);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@Password", DbType.String, objEntity.Password);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@MobileNo", DbType.String, objEntity.MobileNo);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@Address", DbType.String, objEntity.Address);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@FLAG", DbType.String, objEntity.FLAG);

                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6 , prm7 };

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.FLAG == "UserRegister" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<UserModel>(ds.Tables[0]);
                    objResponsemessage.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    objResponsemessage.Message = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
                }
                else if (objEntity.FLAG == "UserLogin" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<UserModel>(ds.Tables[0]);
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
                InsertLog.WriteErrrorLog("InsertUserBL  =>  UserCreation  =>  Exception" + ex.Message + ex.StackTrace);
            }
            return objResponsemessage;
        }
    }
}
