using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FfxivXmlLogParser
{
    class XmlLogLine
    {
        private LogType _logType;
        private string _timestamp;
        private string _line;

        public LogType LogType
        {
            get { return _logType; }
        }

        public string Timestamp
        {
            get { return _timestamp; }
        }

        public string Line
        {
            get { return _line; }
        }

        public XmlLogLine(LogType type, string timestamp, string line)
        {
            // If a line has a target in it, there's metadata embedded inside in the form of [010101...]targetName - remove it
            if (line.IndexOf("[010101") > 0)
            {
                line = Regex.Replace(line, "[[]010101[0-9a-fA-F]*[]]", "");
            }
            if (line.IndexOf("[CF0101") > 0)
            {
                line = Regex.Replace(line, "[[]CF0101[0-9a-fA-F]*[]]", "");
            }

            _logType = type;
            _timestamp = timestamp;
            _line = line;
        }

        public string Formatted
        {
            get
            {
                // Prefix for each message
                string prefix = null;

                // For now, just process certain types
                switch (_logType)
                {
                    case LogType.Say:
                        prefix = "";
                        break;
                    case LogType.TellReceived:
                    case LogType.TellSent:
                        prefix = "(tell)";
                        break;
                    case LogType.Party:
                        prefix = "(party)";
                        break;
                    case LogType.Linkshell1:
                        prefix = "(ls1)";
                        break;
                    case LogType.Linkshell2:
                        prefix = "(ls2)";
                        break;
                    case LogType.Linkshell3:
                        prefix = "(ls3)";
                        break;
                    case LogType.Linkshell4:
                        prefix = "(ls4)";
                        break;
                    case LogType.Linkshell5:
                        prefix = "(ls5)";
                        break;
                    case LogType.Linkshell6:
                        prefix = "(ls6)";
                        break;
                    case LogType.Linkshell7:
                        prefix = "(ls7)";
                        break;
                    case LogType.Linkshell8:
                        prefix = "(ls8)";
                        break;
                    case LogType.FreeCompany:
                        prefix = "(FreeCompany)";
                        break;
                    case LogType.EmoteFreeform:
                    case LogType.Emote:
                        prefix = "*";
                        break;
                }

                return String.Format("{0} {1} {2}", _timestamp, prefix, _line);
            }
        }
    }

    class XmlLog
    {
        private string _path;
        private List<XmlLogLine> _lines = new List<XmlLogLine>();

        public string Path
        {
            get
            {
                return _path;
            }
        }

        public List<XmlLogLine> Lines 
        {
            get {
                return _lines;
            }
        }
        

        public XmlLog(string path)
        {
            // Save the path for no good reason
            _path = path;

            try
            {
                XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
                xmlDoc.Load(_path);

                XmlNodeList entries = xmlDoc.GetElementsByTagName("Entry");
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

        void parseEntry(XmlNode entry)
        {
            // First, do a bunch of stupid stuff to convert the int to an enum so we can pretend to be a good programmer
            int entryTypeInt = -1;
            bool parseOkay = int.TryParse(entry.Attributes[0].InnerText, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out entryTypeInt);
            if (!parseOkay)
            {
                return;
            }

            LogType entryType = LogType.Unknown;
            entryType = LogTypeFromInt(entryTypeInt);

            // If the log type is unknown, stop now
            if (entryType == LogType.Unknown)
            {
                return;
            }

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
            _lines.Add(new XmlLogLine(entryType, timestamp, line));
        }

        public LogType LogTypeFromInt(int intType)
        {
            if (typeof(LogType).IsEnumDefined(intType))
            {
                return (LogType)intType;
            }
            else
            {
                return LogType.Unknown;
            }
        }
    }

    public enum LogType
    {
        Say = 0x0A,
        TellSent = 0x0C,
        TellReceived = 0x0D,
        Party = 0x0E,
        EmoteFreeform = 0x1C,
        Emote = 0x1D,
        Linkshell1 = 0x10,
        Linkshell2 = 0x11,
        Linkshell3 = 0x12,
        Linkshell4 = 0x13,
        Linkshell5 = 0x14,
        Linkshell6 = 0x15,
        Linkshell7 = 0x16,
        Linkshell8 = 0x17,
        FreeCompany = 0x18,
        Unknown = 0xffff
    };
}
