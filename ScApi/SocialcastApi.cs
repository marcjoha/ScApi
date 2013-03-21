using System;
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

        #region Constructors

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

        #endregion

        #region Settings

        public void SetIgnoreSslErrors()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
        }

        #endregion

        #region Public methods

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
            var request = new RestRequest("api/authentication.json", Method.POST) {RootElement = "communities"};
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
        ///     Gets all messages in a particular stream a user subscribes to.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resultsPerPage"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public List<Message> GetStream(int id, int resultsPerPage = 20, int pageNumber = 1)
        {
            var request = new RestRequest("api/streams/{id}/messages.json") {RootElement = "messages"};
            request.AddUrlSegment("id", id.ToString());

            request.AddParameter("per_page", resultsPerPage);
            request.AddParameter("page", pageNumber);
            
            return Execute<List<Message>>(request);
        }

        /// <summary>
        ///     Gets a list of all streams a user is subscribed to.
        /// </summary>
        /// <returns></returns>
        public List<Stream> GetStreams()
        {
            var request = new RestRequest("api/streams.json") {RootElement = "streams"};
            return Execute<List<Stream>>(request);
        }

        /// <summary>
        ///     Gets a list of all groups the user is subscribed to.
        /// </summary>
        /// <returns></returns>
        public List<GroupMemberships> GetGroups()
        {
            var request = new RestRequest("api/group_memberships.json") {RootElement = "group_memberships"};
            return Execute<List<GroupMemberships>>(request);
        }

        /// <summary>
        ///     Gets a list of all groups available in the community.
        /// </summary>
        /// <returns></returns>
        public List<Group> GetAllGroups()
        {
            var request = new RestRequest("api/groups.json") {RootElement = "groups"};
            return Execute<List<Group>>(request);
        }

        #endregion

        #region Internal helpers

        /// <summary>
        ///     Executes an arbitrary request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
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
        ///     If this proxy object was initialized referencing a plain text password, this class stores the password securely.
        /// </summary>
        /// <param name="input">A string that needs to be stored securely</param>
        /// <returns>A SecureString</returns>
        private static SecureString ToSecureString(string input)
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

        #endregion
    }
}