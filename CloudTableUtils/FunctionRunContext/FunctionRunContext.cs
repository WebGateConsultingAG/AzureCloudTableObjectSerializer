using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebGate.Azure.Functions.Utils {
    public abstract class FunctionRunContext : IFunctionRunContext {
        protected HttpRequest _request;
        protected ILogger _logger;
        protected string _userId;
        protected bool _authenticated = false;
        protected bool _isDev = false;
        protected IEnumerable<string> _roles;

        public string GetEnvironmentVariable(string name) {
            return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }

        public ILogger GetLogger() {
            return _logger;
        }

        public async Task<T> GetPayLoad<T>() {
            if (_request != null) {
                string requestBody = await new StreamReader(_request.Body).ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(requestBody);
            } else {
                throw new NullReferenceException();
            }
        }

        public string GetUserId() {
            return _userId;
        }

        public bool IsAuthenticated() {
            return _authenticated;
        }

        public bool IsDev() {
            return _isDev;
        }

        public bool IsInAtLeastOneRole(params string[] rolesToCheck) {
            return _roles.Intersect(rolesToCheck).Count() > 0;
        }

        public bool IsInAllRoles(params string[] rolesToCheck) {
            return _roles.Intersect(rolesToCheck).Count() == rolesToCheck.Count();
        }

        public void LogDebug(string msg) {
            _logger.LogDebug(msg);
        }

        public void LogError(string msg) {
            _logger.LogError(msg);
        }

        public void LogError(Exception e, string msg) {
            _logger.LogError(e, msg);
        }

        public void LogInformation(string msg) {
            _logger.LogInformation(msg);
        }

        public void LogWarning(string msg) {
            _logger.LogWarning(msg);
        }
    }
}