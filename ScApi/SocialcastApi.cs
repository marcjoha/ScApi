﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using RestSharp;
using ScApi.Data;

namespace ScApi
{
    public class SocialcastApi
    {
        private readonly string _communityUrl;
        private readonly string _email;
        private readonly SecureString _password;

        /// <summary>
        ///     Initializes the Socialcast proxy object by securely storing the credentials.
        /// </summary>
        /// <param name="communityUrl">The URL to the Socialcast community, e.g. https://demo.socialcast.com</param>
        /// <param name="email">The email used for signing into Socialcast</param>
        /// <param name="password">The password used for signing Socialcast</param>
        public SocialcastApi(string communityUrl, string email, SecureString password)
        {
            _communityUrl = communityUrl;
            _email = email;
            _password = password;
        }

        /// <summary>
        ///     Overloaded constructor taking the password as a regular string
        /// </summary>
        /// <param name="communityUrl">The URL to the Socialcast community, e.g. https://demo.socialcast.com</param>
        /// <param name="email">The email used for signing into Socialcast</param>
        /// <param name="password">The password used for signing Socialcast</param>
        public SocialcastApi(string communityUrl, string email, string password)
            : this(communityUrl, email, ToSecureString(password))
        {
        }

        /// <summary>
        ///     A user can be a member of several communities. This method returns the one particular community that matches the community against which the service call was made.
        /// </summary>
        /// <returns></returns>
        public Community GetCommunity()
        {
            List<Community> authorizedCommunities = GetCommunities();
            return authorizedCommunities.Find(x => x.Domain.Equals(new Uri(_communityUrl).Host));
        }

        /// <summary>
        ///     A user can be a member of several communities. This method queries Socialcast for all communities which the user is authorized for.
        /// </summary>
        /// <returns>A list of all communities available for the querying user</returns>
        public List<Community> GetCommunities()
        {
            var client = new RestClient(_communityUrl);
            var request = new RestRequest("api/authentication", Method.POST) {RootElement = "communities"};
            request.AddParameter("email", _email);
            request.AddParameter("password", ToInsecureString(_password));

            IRestResponse<List<Community>> response = client.Execute<List<Community>>(request);

            if (response.StatusCode == HttpStatusCode.OK && response.Data != null)
            {
                return response.Data;
            }

            return new List<Community>();
        }

        /// <summary>
        ///     A "stream" is a list of messages that a user is subscribed to, e.g. the home stream or the company stream.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public List<Message> GetStream(string resource)
        {
            var request = new RestRequest(resource) {RootElement = "messages"};
            return Execute<List<Message>>(request);
        }

        private T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = _communityUrl;
            client.Authenticator = new HttpBasicAuthenticator(_email, ToInsecureString(_password));

            IRestResponse<T> response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data;
        }

        /// <summary>
        ///     If this proxy object was initialized referencing a plain text password, this class stores the password securely
        /// </summary>
        /// <param name="input">A string that needs to be stored securely</param>
        /// <returns>A SecureString</returns>
        public static SecureString ToSecureString(string input)
        {
            var secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        /// <summary>
        ///     Passwords are stored in a SecretString up until the moment they are sent to the Socialcast service in a POSTed header. For that purpose, this method converts a SecretString to a normal string.
        /// </summary>
        /// <param name="input">A secret string, e.g. a password</param>
        /// <returns>The string in plain text</returns>
        private static string ToInsecureString(SecureString input)
        {
            string returnValue;
            IntPtr ptr = Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(ptr);
            }
            return returnValue;
        }
    }
}