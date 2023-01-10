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
            bool _isDev = String.IsNullOrEmpty(GetEnvironmentVariable("IS_NOT_DEV"));

            if (env == "Development" && _isDev) {

                string envUserId = GetEnvironmentVariable("DEV_USER_ID");
                string rolesByEnvironment = GetEnvironmentVariable("DEV_USER_ROLES");
                if (String.IsNullOrEmpty(envUserId)) {
                    _userId = "LocalDev";
                } else {
                    _userId = envUserId;
                }
                _authenticated = true;
                string[] allRoles = rolesByEnvironment != null ? rolesByEnvironment.Split(",") : new string[]{"admin"};
                _roles = new List<string>(allRoles);
            } else {
                string userId = principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
                if (!String.IsNullOrEmpty(userId)) {
                    _userId = userId;
                    _authenticated = true;
                }
                _upn= principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn")?.Value;
                _roles = principal.Claims.Where(e => e.Type == "roles").Select(e => e.Value);
            }
        }
    }
}