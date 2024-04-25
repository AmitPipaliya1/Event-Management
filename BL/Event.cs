using LIBRARY;
using MODEL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BL
{
    public class Event
    {

        /// <summary>
        /// Name : Amit Pipaliya
        /// Date : 18-04-24
        /// This Method Use for --> Add New Event --> Show Event --> Show Publish Event ---> Publish Event 
        /// </summary>
        public SerializeResponse<EventModel> EventMethod(EventModel objEntity)
        {
            InsertLog.WriteErrrorLog("BL Event ==>  EventMethod  ==>  Started");
            ConvertDataTable bl = new ConvertDataTable();
            SerializeResponse<EventModel> objResponsemessage = new SerializeResponse<EventModel>();

            DataSet ds = new DataSet();
            SqlDataProvider objSDP = new SqlDataProvider();


            //convert base64 string into image and save into storage and return path

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
                    InsertLog.WriteErrrorLog("StringConvert => imgToString => Exception" + ex.Message + ex.StackTrace);
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

                SqlParameter[] Sqlpara = { prm1, prm2, prm3, prm4, prm5, prm6, prm7 };

                ds = SqlHelper.ExecuteDataset(Con_str, query, Sqlpara);
                if (objEntity.FLAG == "AddEvent" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<EventModel>(ds.Tables[0]);
                    objResponsemessage.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    objResponsemessage.Message = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
                }
                else if (objEntity.FLAG == "ShowPublishEvent" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<EventModel>(ds.Tables[0]);
                    foreach (var item in objResponsemessage.ArrayOfResponse)
                    {
                        string base64ImageRepresentation = null;
                        try
                        {
                            // create byte array
                            byte[] imageArray = System.IO.File.ReadAllBytes(item.Image);
                            // convert byte array into base64 string
                            base64ImageRepresentation = Convert.ToBase64String(imageArray);
                            item.Image = base64ImageRepresentation;
                        }
                        catch (Exception ex)
                        {
                            InsertLog.WriteErrrorLog("StringConvert => StringToImage => Exception" + ex.Message + ex.StackTrace);
                        }
                    }
                }
                else if (objEntity.FLAG == "ShowEvent" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    // Convert path into base64 string 
                    objResponsemessage.ArrayOfResponse = bl.ListConvertDataTable<EventModel>(ds.Tables[0]);
                    foreach (var item in objResponsemessage.ArrayOfResponse)
                    {
                        string base64ImageRepresentation = null;
                        try
                        {
                            // create byte array
                            byte[] imageArray = System.IO.File.ReadAllBytes(item.Image);
                            // convert byte array into base64 string
                            base64ImageRepresentation = Convert.ToBase64String(imageArray);
                            item.Image = base64ImageRepresentation;
                        }
                        catch (Exception ex)
                        {
                            InsertLog.WriteErrrorLog("StringConvert => StringToImage => Exception" + ex.Message + ex.StackTrace);
                        }
                    }
                }
                if (objEntity.FLAG == "PublishEvent" && ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
                objResponsemessage.Message = "500|Exception Occurred";
                InsertLog.WriteErrrorLog("BL Event ==>  EventMethod  =>  Exception" + ex.Message + ex.StackTrace);
            }
            return objResponsemessage;
        }
    }
}
