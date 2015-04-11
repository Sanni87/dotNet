using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatter.Interface
{
    interface IFormatter
    {
        /// <summary>
        /// Indents the incoming string
        /// </summary>
        /// <param name="text">Text to be indented</param>
        /// <returns>string indented, or null if error.</returns>
        string FormatString(string text);

        /// <summary>
        /// Indents the content of a file
        /// </summary>
        /// <param name="path">path and name of the file to be indented</param>
        /// <returns>
        /// 1: Ok
        /// 0: Cannot Indent
        /// -1: An Error ocurred
        /// </returns>
        int FormatFile(string path);


        /// <summary>
        /// Gets the Message of the last Error
        /// </summary>
        String ErrorMessage { get; }

        /// <summary>
        /// Gets the StackTrace of the last Error
        /// </summary>
        String ErrorStackTrace { get; }
    }
}
