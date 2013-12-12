using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

namespace FfxivXmlLogParser
{
    /// <summary>
    /// Supported log message types
    /// </summary>
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

    abstract class XmlLogLine
    {
        // Timestamp for this line
        private string _timestamp;

        // Actor is the person performing the line - ie: the person speaking or emoting
        private string _actor;

        // The text or action being performed
        private string _line;

        protected string Timestamp
        {
            get { return _timestamp; }
        }

        protected string Actor
        {
            get { return _actor; }
        }

        protected string Line
        {
            get { return _line; }
        }

        public string Format()
        {
            return doFormat();
        }

        private char[] ACTOR_SEPARATOR = { ':' };

        // Only derived classes can generate log lines, but it's an abstract class anyway
        protected XmlLogLine(string timestamp, string line)
        {
            if (timestamp == null || line == null)
            {
                throw new ArgumentNullException("Timestamp and line must not be null");
            }

            // Save the timestamp
            _timestamp = timestamp;

            // Split the line into actor/text
            string[] parts = line.Split(ACTOR_SEPARATOR, 2);

            // I don't think this can happen, but still
            if (parts == null || parts.Length < 1)
            {
                throw new ArgumentNullException(String.Format("Text was not properly formatted: {0}", line));
            }
            else if (parts.Length == 1)
            {
                // I guess there's no actor in this case?
                _actor = null;
                _line = removeTargetMetaData(line);
            }
            else
            {
                // Actor is the first part, line second
                _actor = parts[0];
                _line = removeTargetMetaData(parts[1]);
            }
        }

        // Each type of log line will implement this properly for their own formatting
        protected abstract string doFormat();

        /// <summary>
        /// Helper method to clean off targetting metadata from a log line -- this may not be good later, as we may want to
        /// do something with it, but for now it just makes the logs ugly.
        /// </summary>
        /// <param name="line">Text that may contain target metadata</param>
        /// <returns>Text without target metadata</returns>
        protected string removeTargetMetaData(string line)
        {
            // If a line has a target in it, there's metadata embedded inside in the form of [010101...]targetName[CF0101...] - remove it
            if (line.IndexOf("[010101") > 0)
            {
                line = Regex.Replace(line, "[[]010101[0-9a-fA-F]*[]]", "");
            }
            if (line.IndexOf("[CF0101") > 0)
            {
                line = Regex.Replace(line, "[[]CF0101[0-9a-fA-F]*[]]", "");
            }
            return line;
        }

        // This is the way we map from the int type to the constructor we need to call
        static Dictionary<LogType, ConstructorInfo> _EntryTypeToLogType;

        public static XmlLogLine CreateFromLine(LogType entryType, string timestamp, string line)
        {
            if (_EntryTypeToLogType.ContainsKey(entryType))
            {
                // Try and get the constructor info from our dictionary
                ConstructorInfo constructorInfo = _EntryTypeToLogType[entryType];

                // Create the parameters
                Object[] constructorParameters = new Object[3]{(int)entryType, timestamp, line};
                return (XmlLogLine)constructorInfo.Invoke(constructorParameters);
            }
            else
            {
                // Unknown log type - nothing to create
                return null;
            }
        }

        static XmlLogLine()
        {
            // Create our dictionary
            _EntryTypeToLogType = new Dictionary<LogType, ConstructorInfo>();

            // All the constructors have the same parameters - int, string, string
            Type[] constructorParams = new Type[3]{typeof(int), typeof(string), typeof(string)};

            // Init the mapping
            _EntryTypeToLogType.Add(LogType.Say, typeof(SayLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.TellReceived, typeof(TellReceivedLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.TellSent, typeof(TellSentLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Party, typeof(PartyLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Emote, typeof(EmoteLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.EmoteFreeform, typeof(FreeformEmoteLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.FreeCompany, typeof(LinkshellLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Linkshell1, typeof(LinkshellLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Linkshell2, typeof(LinkshellLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Linkshell3, typeof(LinkshellLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Linkshell4, typeof(LinkshellLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Linkshell5, typeof(LinkshellLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Linkshell6, typeof(LinkshellLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Linkshell7, typeof(LinkshellLogLine).GetConstructor(constructorParams));
            _EntryTypeToLogType.Add(LogType.Linkshell8, typeof(LinkshellLogLine).GetConstructor(constructorParams));
        }
    }

    class SayLogLine : XmlLogLine
    {
        public SayLogLine(int entryKey, string timestamp, string line)
            : base(timestamp, line)
        {
        }

        override protected string doFormat()
        {
            return String.Format("{0} {1}: {2}", Timestamp, Actor, Line);
        }
    }

    class TellSentLogLine : XmlLogLine
    {
        public TellSentLogLine(int entryKey, string timestamp, string line)
            : base(timestamp, line)
        {
        }

        override protected string doFormat()
        {
            return String.Format("{0} >> {1}: {2}", Timestamp, Actor, Line);
        }
    }

    class TellReceivedLogLine : XmlLogLine
    {
        public TellReceivedLogLine(int entryKey, string timestamp, string line)
            : base(timestamp, line)
        {
        }

        override protected string doFormat()
        {
            return String.Format("{0} {1} >> {2}", Timestamp, Actor, Line);
        }
    }

    class EmoteLogLine : XmlLogLine
    {
        public EmoteLogLine(int entryKey, string timestamp, string line)
            : base(timestamp, line)
        {
            // Emotes include an actor when it's you, but not when it's someone else... I'm not sure it matters right now
        }

        override protected string doFormat()
        {
            return String.Format("{0} {1}", Timestamp, Line);
        }
    }

    class FreeformEmoteLogLine : XmlLogLine
    {
        public FreeformEmoteLogLine(int entryKey, string timestamp, string line)
            : base(timestamp, line)
        {
        }

        override protected string doFormat()
        {
            return String.Format("{0} {1} {2}", Timestamp, Actor, Line);
        }
    }

    class PartyLogLine : XmlLogLine
    {
        public PartyLogLine(int entryKey, string timestamp, string line)
            : base(timestamp, line)
        {
        }

        override protected string doFormat()
        {
            return String.Format("{0} ({1}) {2}", Timestamp, Actor, Line);
        }
    }

    class LinkshellLogLine : XmlLogLine
    {
        private string _linkshell;

        public LinkshellLogLine(int entryKey, string timestamp, string line)
            : base(timestamp, line)
        {
            if (entryKey == (int)LogType.FreeCompany)
            {
                _linkshell = "FC";
            }
            else if (entryKey >= (int)LogType.Linkshell1 && entryKey <= (int)LogType.Linkshell8)
            {
                // linkshell number
                _linkshell = ((entryKey - (int)LogType.Linkshell1) + 1).ToString();
            }
        }

        override protected string doFormat()
        {
            return String.Format("{0} [{1}] <{2}> {3}", Timestamp, _linkshell, Actor, Line);
        }
    }
}
