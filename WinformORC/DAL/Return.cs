using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public  class Return
    {
        private Int64  _log_id;
        private int _words_result_num;
        private List<words_result> _words_result;

        public Int64 log_id
        {
            set { _log_id = value; }
            get { return _log_id; }
        }
        public int words_result_num
        {
            set { _words_result_num = value; }
            get { return _words_result_num; }
        }
        public List<words_result> words_result
        {
            get { return _words_result; }
            set { _words_result = value; }
        }
    }
    public class words_result
    {
        private string _words;
        public string words
        {
            set { _words = value; }
            get { return _words; }
        }
    }
}
