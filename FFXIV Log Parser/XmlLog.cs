using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FfxivXmlLogParser
{
    class XmlLog
    {
        private const string ENTRY_TAG = "Entry";

        private string _path;
        private List<XmlLogLine> _lines = new List<XmlLogLine>();

        /// <summary>
        /// Path of the log file
        /// </summary>
        public string Path
        {
            get
            {
                return _path;
            }
        }

        /// <summary>
        /// Parsed lines of the log
        /// </summary>
        public List<XmlLogLine> Lines 
        {
            get {
                return _lines;
            }
        }
        
        /// <summary>
        /// Construct an XmlLog object containing all the conversation lines given an xml log file
        /// </summary>
        /// <param name="path">Path to the log file to parse</param>
        public XmlLog(string path)
        {
            // Save the path to provide it back later (if needed)
            _path = path;

            try
            {
                // Create an XML document and attempt to load the provided file into it
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_path);

                // Find all the entry nodes
                XmlNodeList entries = xmlDoc.GetElementsByTagName(ENTRY_TAG);
                
                // Were there any?
                if (entries == null || entries.Count < 1)
                {
                    // Either the log is empty or it wasn't a valid log file to begin with
                    return;
                }

                // Parse each entry
                foreach (XmlNode entry in entries)
                {
                    parseEntry(entry);
                }
            }
            catch (Exception e)
            {
                // If we fail... well, maybe someday we could try to figure out why
                // for now though, let's just give up
                Console.Error.WriteLine(e);
            }
        }

        private void parseEntry(XmlNode entry)
        {
            // First, do a bunch of stupid stuff to convert the int to an enum so we can pretend to be a good programmer
            int entryTypeInt = -1;
            bool parseOkay = int.TryParse(entry.Attributes[0].InnerText, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out entryTypeInt);
            if (!parseOkay)
            {
                return;
            }

            if (!Enum.IsDefined(typeof(LogType), entryTypeInt))
            {
                // Unknown type
                return;
            }
            LogType entryType = (LogType)entryTypeInt;

            // Process the entry child nodes to retrieve the line text and the timestamp children
            string line = null;
            string timestamp = null;
            foreach (XmlNode child in entry.ChildNodes)
            {
                if (child.Name == "Line")
                {
                    line = child.InnerText;
                }
                else if (child.Name == "TimeStamp")
                {
                    timestamp = child.InnerText;
                }
            }

            // Ensure it's a valid entry
            if (line == null || timestamp == null)
            {
                // *shrug*
                return;
            }

            // Create a log line object and add it to the lines of this log
            XmlLogLine parsedLine = XmlLogLine.CreateFromLine(entryType, timestamp, line);
            if (parsedLine != null)
            {
                _lines.Add(parsedLine);
            }
        }
    }
}
