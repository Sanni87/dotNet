using Formatter.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formatter.Instances
{
    public class XmlFormatter : IFormatter
    {
        private Exception _LastException;

        /// <summary>
        /// Indents the incoming XML string
        /// </summary>
        /// <param name="text">Text to be indented</param>
        /// <returns>Nex string indented</returns>
        public string FormatString(string text)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(text);
                StringBuilder sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "  ";
                settings.NewLineChars = "\r\n";
                settings.NewLineHandling = NewLineHandling.Replace;
                using (XmlWriter writer = XmlWriter.Create(sb, settings))
                {
                    doc.Save(writer);
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                this._LastException = e;
                return null;
            }
        }

        /// <summary>
        /// Indents the content of a XML file
        /// </summary>
        /// <param name="path">path and name of the file to be indented</param>
        /// <returns>
        /// 1: Ok
        /// 0: Cannot Indent
        /// -1: An Error ocurred
        /// </returns>
        public int FormatFile(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                StringBuilder sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "  ";
                settings.NewLineChars = "\r\n";
                settings.NewLineHandling = NewLineHandling.Replace;
                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    doc.Save(writer);
                }
                return 1;
            }
            catch (Exception e)
            {
                this._LastException = e;
                return -1;
            }
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
