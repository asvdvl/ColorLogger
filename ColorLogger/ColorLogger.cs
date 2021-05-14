using System;
using System.Collections.Generic;

namespace ColorLogger
{
    public static class ColorLogger
    {
        public enum LogLevel
        {
            Debug,
            Information,
            Warning,
            Error,
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

        private static readonly Dictionary<LogLevel, FBColors> ColorAndLogRelation = new Dictionary<LogLevel, FBColors>     //LogLevel, ForegroundColor
        {
            { LogLevel.Debug, new FBColors(ConsoleColor.Gray, ConsoleColor.Black) },
            { LogLevel.Information, new FBColors(ConsoleColor.White, ConsoleColor.Black)},
            { LogLevel.Warning, new FBColors(ConsoleColor.Yellow, ConsoleColor.Black)},
            { LogLevel.Error, new FBColors(ConsoleColor.Red, ConsoleColor.Black)},
            { LogLevel.Critical, new FBColors(ConsoleColor.Red, ConsoleColor.White)}
        };

        private static readonly Dictionary<LogLevel, string> LogAndShortnameRelation = new Dictionary<LogLevel, string>     //LogLevel, ForegroundColor
        {
            { LogLevel.Debug, "Debug" },
            { LogLevel.Information, "Info" },
            { LogLevel.Warning, "Warn" },
            { LogLevel.Error, "Err" },
            { LogLevel.Critical, "Crit" }
        };

        static string getLevelName(LogLevel logLevel, bool needPrefix, bool shortPrefix)
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

        public static void Log(LogLevel logLevel, string text, bool prefix = true, bool shortPrefix = true)
        {
            ColorAndLogRelation.TryGetValue(logLevel, out FBColors colors);
            ;
            ConsoleColor savedFColor = Console.ForegroundColor;
            ConsoleColor savedBColor = Console.BackgroundColor;

            Console.ForegroundColor = colors.ForegroundColor;
            Console.BackgroundColor = colors.BackgroundColor;

            Console.WriteLine($"{getLevelName(logLevel, prefix, shortPrefix)}{text}");

            Console.ForegroundColor = savedFColor;
            Console.BackgroundColor = savedBColor;
        }

        
        /// <summary>
        /// Log with info level
        /// </summary>
        /// <param name="text">Text to log</param>
        public static void Log(string text)
        {
            Log(LogLevel.Information, text);
        }
    }
}
