using Formatter.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatter.Instances
{
    public class JsonFormatter : IFormatter
    {
        private Exception _LastException;

        public string FormatString(string text)
        {
            throw new NotImplementedException();
        }

        public int FormatFile(string path)
        {
            throw new NotImplementedException();
        }

        public string ErrorMessage
        {
            get
            {
                if (this._LastException == null)
                {
                    return "";
                }
                else
                {
                    return this._LastException.Message;
                }
            }
        }

        public string ErrorStackTrace
        {
            get
            {
                if (this._LastException == null)
                {
                    return "";
                }
                else
                {
                    return this._LastException.StackTrace;
                }
            }
        }
    }
}
