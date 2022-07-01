using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebGate.Azure.Functions.Utils {
    public class AppFunctionRunContext : FunctionRunContext {
        public AppFunctionRunContext(ILogger logger, string userId = "AppId", HttpRequest request = null) {
            _request = request;
            _logger = logger;

            string env = GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT");

            if (env == "Development") {
                _isDev = String.IsNullOrEmpty(GetEnvironmentVariable("IS_NOT_DEV"));

                string envUserId = GetEnvironmentVariable("DEV_USER_ID");
                if (String.IsNullOrEmpty(envUserId)) {
                    _userId = "LocalDev";
                } else {
                    _userId = envUserId;
                }
            }

            _authenticated = true;
            _roles = new List<string>() { "admin" };
        }
    }
}