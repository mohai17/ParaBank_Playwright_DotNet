using System;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace ProjectLoggerUtil;

public static class LoggerUtil
{
    private static Serilog.Core.Logger? _logger;
    public static void Init(
        string logFilePath = "Logs/app.log",
        LogEventLevel minimumLevel = LogEventLevel.Information)
    {
        if (_logger != null)
        {
            return;
        }

        _logger = new LoggerConfiguration()
            .MinimumLevel.Is(minimumLevel)
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(logFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                shared: true)
            .CreateLogger();

        Log.Logger = _logger;
    }

    public static void Info(string message) => _logger?.Information(message);

    public static void Warn(string message) => _logger?.Warning(message);

    public static void Error(string message, Exception? ex = null)
    {
        if (ex != null)
            _logger?.Error(ex, message);
        else
            _logger?.Error(message);
    }
    public static void Debug(string message) => _logger?.Debug(message);

    public static void CloseAndFlush()
    {
        Log.CloseAndFlush();
        _logger = null;
    }
}