using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebGate.Azure.Functions.Utils {
    public interface IFunctionRunContext {

        /// <summary>
        /// Returns the payload of the request as T
        /// </summary>
        /// <typeparam name="T">The type of the payload</typeparam>
        /// <returns></returns>
        Task<T> GetPayLoad<T>();

        /// <summary>
        /// Returns true if the user is authenticated, false if not
        /// </summary>
        /// <returns></returns>
        public bool IsAuthenticated();

        /// <summary>
        /// Returns true if the user is a member of one or mor of the specified roles
        /// </summary>
        /// <param name="rolesToCheck">The allowed roles</param>
        /// <returns></returns>
        public bool IsInAtLeastOneRole(params string[] rolesToCheck);

        /// <summary>
        /// Returns true if the API is running in a development environment
        /// </summary>
        /// <returns>A boolean indicating the environment</returns>
        public bool IsDev();

        /// <summary>
        /// Returns the userId relevant in the current context. Usually this is the id of the user currently accessing the application,
        /// but if the application is not acting in a user context, this may not be the case.
        /// </summary>
        /// <remarks>IMPORTANT: Manually setting the user id may result in UNFORSEEABLE PROBLEMS! Please make sure that EVERYTHING in the call chain is doing what you want it to do!</remarks>
        /// <returns>A string containing a userId</returns>
        public string GetUserId();

        /// <summary>
        /// Returns the upn of the user in the current context. Usually this is the email adress of the user currently accessing the application,
        /// but if the application is not acting in a user context, this may not be the case.
        /// </summary>
        /// <remarks>IMPORTANT: Manually setting the user id may result in UNFORSEEABLE PROBLEMS! Please make sure that EVERYTHING in the call chain is doing what you want it to do!</remarks>
        /// <returns>A string containing a userId</returns>
        public string GetUPN();

        /// <summary>
        /// Logs a message at debug level
        /// </summary>
        /// <param name="msg">The message to log</param>
        public void LogDebug(string msg);

        /// <summary>
        /// Logs a message at information level
        /// </summary>
        /// <param name="msg">The message to log</param>
        public void LogInformation(string msg);

        /// <summary>
        /// Logs a message at warning level
        /// </summary>
        /// <param name="msg">The message to log</param>
        public void LogWarning(string msg);

        /// <summary>
        /// Logs a message at error level
        /// </summary>
        /// <param name="msg">The message to log</param>
        public void LogError(string msg);

        /// <summary>
        /// Logs an exception and a message
        /// </summary>
        /// <param name="e">The exception to log</param>
        /// <param name="msg">The message to log</param>
        public void LogError(Exception e, string msg);

        /// <summary>
        /// Returns an ILogger instance
        /// </summary>
        /// <remarks>Use dedicated Log-functions if possible</remarks>
        /// <returns>An ILogger instance</returns>
        public ILogger GetLogger();

        /// <summary>
        /// Returns the value of the specified environment variable
        /// </summary>
        /// <param name="name">The name of the environment variable</param>
        /// <returns>The value of the specified environment variable</returns>
        public string GetEnvironmentVariable(string name);
    }
}