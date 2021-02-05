﻿using System;

namespace TavSystem.Framework
{
    public class SiteSettings
    {
        public ConnectionStrings connectionStrings { get; set; }
        public Logging logging { get; set; }
        public string AllowedHosts { get; set; }
        public class ConnectionStrings
        {
            public string DefaultConnection { get; set; }
        }
        public class Logging
        {
            public LogLevel LogLevel { get; set; }
        }
        public class LogLevel
        {
            public string Default { get; set; }
            public string Microsoft { get; set; }
        }
    }
}
