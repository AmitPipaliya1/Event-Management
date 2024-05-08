using LIBRARY;
using MODEL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Activity
    {
        /// <summary>
        /// Name : Amit Pipaliya
        /// Date : 18-04-24
        /// This Method Use for --> Add New Activity --> Show Activity ---> Add Price 
        /// </summary>
      
        public SerializeResponse<ActivityModel> ActivityMethod(ActivityModel ActivityEntity)
        {
            InsertLog.WriteErrrorLog("BL Activity ==>  ActivityMethod  ==>  Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<ActivityModel> objResponsemessage = new SerializeResponse<ActivityModel>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();
            string query = "SP_Activity";
            try
            {
                string Con_str = Connection.ConnectionString();
                 SqlParameter prm1 = objSDP.CreateInitializedParameter("@ActivityId", DbType.Int64, ActivityEntity.ActivityId);
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@ActivityName", DbType.String, ActivityEntity.ActivityName);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@Discription", DbType.String, ActivityEntity.Discription);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@Price", DbType.String, ActivityEntity.Price);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@EventId", DbType.Int64, ActivityEntity.EventId);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@StartDate", DbType.String, ActivityEntity.StartDate);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@EndDate", DbType.String, ActivityEntity.EndDate);
                SqlParameter prm8 = objSDP.CreateInitializedParameter("@FLAG", DbType.String, ActivityEntity.FLAG);
                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8 };
                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);

                if (ActivityEntity.FLAG == "AddActivity" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<UserModel>(ds.Tables[0]);
                    objResponsemessage.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    objResponsemessage.Message = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
                }
                else if (ActivityEntity.FLAG == "ShowActivity" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<ActivityModel>(ds.Tables[0]);
                }

                else if (ActivityEntity.FLAG == "AddPrice" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
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
                InsertLog.WriteErrrorLog("BL Event ==>  EventMethod  =>  Exception" + ex.Message + ex.StackTrace);
            }
            return objResponsemessage;
        }
    }
}
