using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace AHFramework.Service
{
    public enum ResponseCodes
    {
        OK_200 = 200,
        AUTHORIZED_201 = 201,
        NOT_FOUND_404 = 404,
        SERVER_ERROR_500 = 500,
        UNAUTHORIZED_401 = 401
    }

    public static class APIService
    {
        public static void SendData(HTTPRequestMethod method, string url, bool haveAuth = true, UnityAction<UnityWebRequest> callback = null, List<KeyValuePair<string, string>> headers = default, string body = "")
        {
            if (headers == null) headers = new List<KeyValuePair<string, string>>();

            if (haveAuth && !string.IsNullOrEmpty(JWTTokenService.AccessToken))
            {
                List<KeyValuePair<string, string>> headersLst = new List<KeyValuePair<string, string>>();
                headersLst.AddRange(headers);

                headersLst.Add(new KeyValuePair<string, string>("Authorization", JWTTokenService.AccessToken));

                HTTPService.SendData(method, url, request =>
                {
                    // Refresh Token
                    if (request.responseCode == (int)ResponseCodes.UNAUTHORIZED_401 && !string.IsNullOrEmpty(JWTTokenService.RefreshToken))
                    {
                        headersLst.Add(new KeyValuePair<string, string>("Authorization", JWTTokenService.AccessToken));
                        HTTPService.SendData(method, url, callback, headersLst.ToArray(), body);
                    }
                    else callback(request);

                }, headersLst.ToArray(), body);

            }
            else
                HTTPService.SendData(method, url, callback, headers.ToArray(), body);

        }
    }
}
