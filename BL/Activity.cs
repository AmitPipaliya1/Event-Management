using LIBRARY;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Activity
    {
        //---------------------- Add ACTIVITY METHOD ---------------------------
        public SerializeResponse<ActivityModel> ActivityMethod(ActivityModel objEntity)
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
                SqlParameter prm1 = objSDP.CreateInitializedParameter("@ActivityId", DbType.Int64, objEntity.ActivityId);
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@ActivityName", DbType.String, objEntity.ActivityName);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@Discription", DbType.String, objEntity.Discription);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@Price", DbType.String, objEntity.Price);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@EventId", DbType.Int64, objEntity.EventId);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@StartDate", DbType.String, objEntity.StartDate);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@EndDate", DbType.String, objEntity.EndDate);
                SqlParameter prm8 = objSDP.CreateInitializedParameter("@FLAG", DbType.String, objEntity.FLAG);

                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8 };
                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.FLAG == "AddActivity" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<UserModel>(ds.Tables[0]);
                    objResponsemessage.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    objResponsemessage.Message = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
                }
                else if (objEntity.FLAG == "ShowActivity" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<ActivityModel>(ds.Tables[0]);
                }

                else if (objEntity.FLAG == "AddPrice" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
                InsertLog.WriteErrrorLog("BL Event ==>  EventMethod  =>  Exception" + ex.Message + ex.StackTrace);
            }
            return objResponsemessage;
        }
    }
}
