using Discord;

namespace Sushi.Utils
{
    internal class Logger
    {
        private struct LogLevel
        {
            public const string Reset = "\x1b[0m";
            public const string Bold = "\x1b[1m";
            public const string Dim = "\x1b[2m";

            public struct Foreground
            {
                public const string Error = "\x1b[31m";
                public const string Debug = "\x1b[32m";
                public const string Warning = "\x1b[33m";
                public const string Info = "\x1b[34m";
                public const string Raw = "\x1b[37m";
            }

        }

        public static async Task ClientLog(LogMessage message)
        {
            var severity = message.Severity switch
            {
                LogSeverity.Critical => LogLevel.Foreground.Error + LogLevel.Bold + "CRITICAL" + LogLevel.Reset,
                LogSeverity.Error => LogLevel.Foreground.Error + "ERROR" + LogLevel.Reset,
                LogSeverity.Warning => LogLevel.Foreground.Warning + "WARNING" + LogLevel.Reset,
                LogSeverity.Info => LogLevel.Foreground.Info + "INFO" + LogLevel.Reset,
                LogSeverity.Verbose => LogLevel.Foreground.Raw + "RAW" + LogLevel.Reset,
                LogSeverity.Debug => LogLevel.Foreground.Debug + "DEBUG" + LogLevel.Reset,
                _ => throw new ArgumentOutOfRangeException()
            };

            string time = DateTime.Now.ToString("HH:mm:ss");

            Console.WriteLine($"{LogLevel.Dim}{time}{LogLevel.Reset}    [{severity}:{message.Source}]   {message.Message}");

            await Task.CompletedTask;
        }
    }
}
