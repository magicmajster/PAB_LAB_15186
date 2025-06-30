﻿using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace WebApi.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            stopwatch.Stop();
            _logger.LogInformation($"Response: {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}