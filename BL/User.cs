using LIBRARY;
using MODEL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class User
    {

        /// <summary>
        /// Name : Amit Pipaliya
        /// Date : 18-04-24
        /// This Method Use For --> User Registration  --> User Login  
        /// </summary>
        public SerializeResponse<UserModel> UserMethod(UserModel UserEntity)
        {
            InsertLog.WriteErrrorLog("InsertUserBL  ==>  UserCreation  ==>  Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<UserModel> objResponsemessage = new SerializeResponse<UserModel>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();
            string query = "SP_User";
            if (UserEntity.FLAG == "UserRegister" || UserEntity.FLAG == "UserLogin") {
              UserEntity.Password = PswdEncryptDecrypt.EncodePasswordToBase64(UserEntity.Password);          
            }
            try
            {
                string Con_str = Connection.ConnectionString();
                SqlParameter prm1 = objSDP.CreateInitializedParameter("@UserId", DbType.Int64, UserEntity.UserId);
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@Name", DbType.String, UserEntity.Name);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@EmailId", DbType.String, UserEntity.EmailId);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@Password", DbType.String, UserEntity.Password);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@MobileNo", DbType.String, UserEntity.MobileNo);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@Address", DbType.String, UserEntity.Address);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@FLAG", DbType.String, UserEntity.FLAG);

                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7 };

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (UserEntity.FLAG == "UserRegister" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<UserModel>(ds.Tables[0]);
                    objResponsemessage.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    objResponsemessage.Message = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
                }
                else if (UserEntity.FLAG == "UserLogin" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {                    
                    //objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<UserModel>(ds.Tables[0]);
                    objResponsemessage.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    objResponsemessage.Message = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
                }
                else if (ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count == 0)
                {
                    objResponsemessage.Message = "No Data Found";
                    objResponsemessage.ID = 400;
                }
            }
            catch (Exception ex)
            {
                objResponsemessage.Message = "Exception Occurred";
                objResponsemessage.ID = 500;
                InsertLog.WriteErrrorLog("InsertUserBL  =>  UserCreation  =>  Exception" + ex.Message + ex.StackTrace);
            }
            return objResponsemessage;
        }
    }
}
