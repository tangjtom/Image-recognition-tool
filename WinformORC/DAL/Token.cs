using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Token
    {
        private string _access_token;
        private string _session_key;
        private string _scope;
        private string _refresh_token;
        private string _session_secret;
        private int _expires_in;

        public string access_token
        {
            set { _access_token = value; }
            get { return _access_token; }
        }
        public string session_key
        {
            set { _session_key = value; }
            get { return _session_key; }
        }
        public string scope
        {
            set { _scope = value; }
            get { return _scope; }
        }
        public string refresh_token
        {
            set { _refresh_token = value;}
            get { return _refresh_token; }
        }
        public string session_secret
        {
            set { _session_secret = value; }
            get { return _session_secret; }
        }
        public int expires_in
        {
            set { _expires_in = value; }
            get { return _expires_in; }
        }
    }
}
