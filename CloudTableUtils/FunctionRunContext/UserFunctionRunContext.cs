using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebGate.Azure.Functions.Utils {
    public class UserFunctionRunContext : FunctionRunContext {
        public UserFunctionRunContext(HttpRequest request, ILogger logger, ClaimsPrincipal principal) {
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

                _authenticated = true;
                _roles = new List<string>() { "admin" };
            } else {
                string userId = principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
                if (!String.IsNullOrEmpty(userId)) {
                    _userId = userId;
                    _authenticated = true;
                }
                _roles = principal.Claims.Where(e => e.Type == "roles").Select(e => e.Value);
            }
        }
    }
}