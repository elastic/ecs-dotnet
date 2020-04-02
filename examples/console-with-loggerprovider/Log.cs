using System;
using Microsoft.Extensions.Logging;

namespace HelloElasticsearch
{
    internal static class Log
    {
        public static readonly Action<ILogger, Exception?> CriticalErrorExecuteFailed =
            LoggerMessage.Define(LogLevel.Critical,
                new EventId(9000, nameof(CriticalErrorExecuteFailed)),
                "Critical error, execute failed.");

        public static readonly Action<ILogger, int, Exception?> ErrorProcessingCustomer =
            LoggerMessage.Define<int>(LogLevel.Error,
                new EventId(5000, nameof(ErrorProcessingCustomer)),
                "Unexpected error processing customer {CustomerId}.");

        public static readonly Action<ILogger, Guid, Exception?> ProcessOrderItem =
            LoggerMessage.Define<Guid>(LogLevel.Information,
                new EventId(1000, nameof(ProcessOrderItem)),
                "Processing order item {ItemId}.");

        public static readonly Action<ILogger, byte, bool, Exception?> SignInToken =
            LoggerMessage.Define<byte, bool>(LogLevel.Trace,
                new EventId(1, nameof(SignInToken)),
                "Sign in secret token checksum {Checksum}: {Success}.");

        public static readonly Action<ILogger, int, Exception?> StartingProcessing =
            LoggerMessage.Define<int>(LogLevel.Debug,
                new EventId(6000, nameof(StartingProcessing)),
                "Starting processing of {ItemCount} items.");

        public static readonly Action<ILogger, DateTimeOffset, Exception?> WarningEndOfProcessing =
            LoggerMessage.Define<DateTimeOffset>(LogLevel.Warning,
                new EventId(4000, nameof(WarningEndOfProcessing)),
                "End of processing reached at {EndTime}.");
    }
}
