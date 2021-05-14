using System;
using System.Collections.Generic;

namespace ColorLogger
{
    /// <summary>
    /// Static class for 
    /// </summary>
    public static class ColorLogger
    {
        /// <summary>
        /// enumeration with different log levels
        /// </summary>
        public enum LogLevel
        {
            /// <summary>
            /// Foreground color - Gray,
            /// Background color - Black
            /// </summary>
            Debug,
            /// <summary>
            /// Foreground color - White,
            /// Background color - Black
            /// </summary>
            Information,
            /// <summary>
            /// Foreground color - Yellow,
            /// Background color - Black
            /// </summary>
            Warning,
            /// <summary>
            /// Foreground color - Red,
            /// Background color - Black
            /// </summary>
            Error,
            /// <summary>
            /// Foreground color - Red,
            /// Background color - White
            /// </summary>
            Critical
        }

        struct FBColors
        {
            public ConsoleColor ForegroundColor;
            public ConsoleColor BackgroundColor;

            public FBColors(ConsoleColor FColor, ConsoleColor BColor)
            {
                ForegroundColor = FColor;
                BackgroundColor = BColor;
            }
        }

        private static readonly Dictionary<LogLevel, FBColors> ColorAndLogRelation = new Dictionary<LogLevel, FBColors>     //LogLevel, Colors
        {
            { LogLevel.Debug, new FBColors(ConsoleColor.Gray, ConsoleColor.Black) },
            { LogLevel.Information, new FBColors(ConsoleColor.White, ConsoleColor.Black)},
            { LogLevel.Warning, new FBColors(ConsoleColor.Yellow, ConsoleColor.Black)},
            { LogLevel.Error, new FBColors(ConsoleColor.Red, ConsoleColor.Black)},
            { LogLevel.Critical, new FBColors(ConsoleColor.Red, ConsoleColor.White)}
        };

        private static readonly Dictionary<LogLevel, string> LogAndShortnameRelation = new Dictionary<LogLevel, string>     //LogLevel, Shortname
        {
            { LogLevel.Debug, "Debug" },
            { LogLevel.Information, "Info" },
            { LogLevel.Warning, "Warn" },
            { LogLevel.Error, "Err" },
            { LogLevel.Critical, "Crit" }
        };

        static string GetLevelName(LogLevel logLevel, bool needPrefix, bool shortPrefix)
        {
            if (needPrefix)
            {
                if (shortPrefix)
                {
                    LogAndShortnameRelation.TryGetValue(logLevel, out string prefix);
                    return "[" + prefix.ToUpper() + "] ";
                }
                else
                {
                    return "[" + logLevel.ToString().ToUpper() + "] ";
                }
            }
            return "";
        }


        /// <summary>
        /// Log with additional parameters 
        /// </summary>
        /// <param name="logLevel">Level of log</param>
        /// <param name="text">Logging text</param>
        /// <param name="prefix">Inserting an index</param>
        /// <param name="shortPrefix">Use a shortened prefix. e.g. Info without Information</param>
        public static void Log(LogLevel logLevel, string text, bool prefix = true, bool shortPrefix = true)
        {
            ColorAndLogRelation.TryGetValue(logLevel, out FBColors colors);

            ConsoleColor savedFColor = Console.ForegroundColor;
            ConsoleColor savedBColor = Console.BackgroundColor;

            Console.ForegroundColor = colors.ForegroundColor;
            Console.BackgroundColor = colors.BackgroundColor;

            Console.WriteLine($"{GetLevelName(logLevel, prefix, shortPrefix)}{text}");

            Console.ForegroundColor = savedFColor;
            Console.BackgroundColor = savedBColor;
        }


        /// <summary>
        /// Log with info level
        /// </summary>
        /// <param name="text">Logging text</param>
        public static void Log(string text)
        {
            Log(LogLevel.Information, text);
        }
    }
}
