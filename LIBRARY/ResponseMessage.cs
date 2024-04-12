using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY
{
    public class ResponseMessage
    {
        int _code;
        string _Message;
        string _status;
        int _Id;
        string _content;
        string _reference_id;
        /// <summary>
        /// Returns the Reference No Generated for Mortgage Loan Application on submission
        /// </summary>
        string _Refference_No;
        public ResponseMessage()
        {
            _code = 0;
            _Message = string.Empty;
            _Id = 0;
            _Refference_No = "";
        }
        public int code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        public int ID
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }
        public string reference_id
        {
            get { return _reference_id; }
            set { _reference_id = value; }
        }
        /// <summary>
        /// Returns the Reference No Generated for Mortgage Loan Application on submission
        /// </summary>
        public string Refference_No
        {
            get { return _Refference_No; }
            set { _Refference_No = value; }
        }
        public string data { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
