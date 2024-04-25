using System;
using System.Collections.Generic;

namespace LIBRARY
{
    public class SerializeResponse<T>
    {
        private Int64 _NoOfPages;
        private Int64 _CurrentPage;
        private List<T> _ArrayOfResponse;
        private List<T> __ArrayOfResponse2;
        private List<T> __ArrayOfResponse3;
        private string _Message;
        private Int32 _ID;
        public SerializeResponse()
        {
            _NoOfPages = 0;
            _CurrentPage = 0;
            _ID = 0;
            _ArrayOfResponse = new List<T>();
            __ArrayOfResponse2 = new List<T>();
            __ArrayOfResponse3 = new List<T>();
        }

        public Int64 NoOfPages
        {
            get { return _NoOfPages; }
            set { _NoOfPages = value; }
        }

        public Int64 CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }
        public List<T> ArrayOfResponse
        {
            get { return _ArrayOfResponse; }
            set { _ArrayOfResponse = value; }
        }
        public List<T> ArrayOfResponse2
        {
            get { return __ArrayOfResponse2; }
            set { __ArrayOfResponse2 = value; }
        }
        public List<T> ArrayOfResponse3
        {
            get { return __ArrayOfResponse3; }
            set { __ArrayOfResponse3 = value; }
        }
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
