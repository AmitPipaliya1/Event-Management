using LIBRARY;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL
{
    public class Event
    {
        //---------------------- Add EVENT METHOD ---------------------------
        public SerializeResponse<EventModel> EventMethod(EventModel objEntity)
        {
            InsertLog.WriteErrrorLog("BL Event ==>  EventMethod  ==>  Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<EventModel> objResponsemessage = new SerializeResponse<EventModel>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();

            string path = AppDomain.CurrentDomain.BaseDirectory + "image\\img_" + DateTime.Now.ToString().Replace(':', '-') + ".jpg";
            if (objEntity.Image != null)
            {
                try
                {

                    if (!Directory.Exists(path.Substring(0, path.LastIndexOf('\\'))))
                    {
                        // create if Directory not exists
                        Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\')));
                    }
                    if (!File.Exists(path))
                    {
                        // create if File not exists
                        File.Create(path).Close();
                    }
                    //  convert string into image and store at path
                    File.WriteAllBytes(path, Convert.FromBase64String(objEntity.Image.Split(',')[1]));
                    objEntity.Image = path;
                }
                catch (Exception ex)
                {

                }
            }
             string query = "SP_Event";
            try
            {
                string Con_str = Connection.ConnectionString();
                SqlParameter prm1 = objSDP.CreateInitializedParameter("@EventId", DbType.Int64, objEntity.EventId);
                SqlParameter prm2 = objSDP.CreateInitializedParameter("@EventName", DbType.String, objEntity.EventName);
                SqlParameter prm3 = objSDP.CreateInitializedParameter("@Discription", DbType.String, objEntity.Discription);
                SqlParameter prm4 = objSDP.CreateInitializedParameter("@StartDate", DbType.String, objEntity.StartDate);
                SqlParameter prm5 = objSDP.CreateInitializedParameter("@EndDate", DbType.String, objEntity.EndDate);
                SqlParameter prm6 = objSDP.CreateInitializedParameter("@Image", DbType.String, objEntity.Image);
                SqlParameter prm7 = objSDP.CreateInitializedParameter("@FLAG", DbType.String, objEntity.FLAG);

                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7};

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.FLAG == "AddEvent" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<EventModel>(ds.Tables[0]);
                    objResponsemessage.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    objResponsemessage.Message = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
                }
                else if (objEntity.FLAG == "ShowEvent" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<EventModel>(ds.Tables[0]);
                }
                if (objEntity.FLAG == "PublishEvent" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
