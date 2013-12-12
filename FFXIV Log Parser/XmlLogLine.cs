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
        // Entry type for this log
        private LogType _entryType;

        // Timestamp for this line
        private string _timestamp;

        // Actor is the person performing the line - ie: the person speaking or emoting
        private string _actor;

        // The text or action being performed
        private string _line;

        // Cached copy of the result of ToString() to avoid doing the formatting each time
        protected string _toStringCache;

        public LogType EntryType
        {
            get { return _entryType; }
        }

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

        private char[] ACTOR_SEPARATOR = { ':' };

        // Only derived classes can generate log lines, but it's an abstract class anyway
        protected XmlLogLine(LogType entryType, string timestamp, string line)
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

            // Save the entry type for later
            _entryType = entryType;

            // Clear the cache, since the string "changed"
            _toStringCache = null;
        }

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
                Object[] constructorParameters = new Object[3] { (int)entryType, timestamp, line };
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
            Type[] constructorParams = new Type[3] { typeof(LogType), typeof(string), typeof(string) };

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
        public SayLogLine(LogType entryKey, string timestamp, string line)
            : base(entryKey, timestamp, line)
        {
        }

        public override string ToString()
        {
            if (_toStringCache == null)
            {
                _toStringCache = String.Format("{0} {1}: {2}", Timestamp, Actor, Line);
            }
            return _toStringCache;
        }
    }

    class TellSentLogLine : XmlLogLine
    {
        public TellSentLogLine(LogType entryKey, string timestamp, string line)
            : base(entryKey, timestamp, line)
        {
        }

        public override string ToString()
        {
            if (_toStringCache == null)
            {
                _toStringCache = String.Format("{0} >> {1}: {2}", Timestamp, Actor, Line);
            }
            return _toStringCache;
        }
    }

    class TellReceivedLogLine : XmlLogLine
    {
        public TellReceivedLogLine(LogType entryKey, string timestamp, string line)
            : base(entryKey, timestamp, line)
        {
        }

        public override string ToString()
        {
            if (_toStringCache == null)
            {
                _toStringCache = String.Format("{0} {1} >> {2}", Timestamp, Actor, Line);
            }
            return _toStringCache;
        }
    }

    class EmoteLogLine : XmlLogLine
    {
        public EmoteLogLine(LogType entryKey, string timestamp, string line)
            : base(entryKey, timestamp, line)
        {
            // Emotes include an actor when it's you, but not when it's someone else... I'm not sure it matters right now
        }

        public override string ToString()
        {
            if (_toStringCache == null)
            {
                _toStringCache = String.Format("{0} {1}", Timestamp, Line);
            }
            return _toStringCache;
        }
    }

    class FreeformEmoteLogLine : XmlLogLine
    {
        public FreeformEmoteLogLine(LogType entryKey, string timestamp, string line)
            : base(entryKey, timestamp, line)
        {
        }

        public override string ToString()
        {
            if (_toStringCache == null)
            {
                _toStringCache = String.Format("{0} {1} {2}", Timestamp, Actor, Line);
            }
            return _toStringCache;
        }
    }

    class PartyLogLine : XmlLogLine
    {
        public PartyLogLine(LogType entryKey, string timestamp, string line)
            : base(entryKey, timestamp, line)
        {
        }

        public override string ToString()
        {
            if (_toStringCache == null)
            {
                _toStringCache = String.Format("{0} ({1}) {2}", Timestamp, Actor, Line);
            }
            return _toStringCache;
        }
    }

    class LinkshellLogLine : XmlLogLine
    {
        private string _linkshell;

        public LinkshellLogLine(LogType entryKey, string timestamp, string line)
            : base(entryKey, timestamp, line)
        {
            if (entryKey == LogType.FreeCompany)
            {
                _linkshell = "FC";
            }
            else if ((int)entryKey >= (int)LogType.Linkshell1 && (int)entryKey <= (int)LogType.Linkshell8)
            {
                // linkshell number
                _linkshell = ((entryKey - (int)LogType.Linkshell1) + 1).ToString();
            }
        }

        public override string ToString()
        {
            if (_toStringCache == null)
            {
                _toStringCache = String.Format("{0} [{1}] <{2}> {3}", Timestamp, _linkshell, Actor, Line);
            }
            return _toStringCache;
        }
    }
}
