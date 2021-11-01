using UnityEngine;

namespace AHFramework.Service
{
    public static class JWTTokenService
    {
        // Access Token
        private const string accessTokenKEY = "JWT_ACCESS_TOKEN";
        public static void SetAccessToken(string token) => PlayerPrefs.SetString(accessTokenKEY, token);
        public static string AccessToken => PlayerPrefs.GetString(accessTokenKEY, "");

        // Refresh Token
        private const string refreshTokenKEY = "JWT_REFRESH_TOKEN";
        public static void SetRefreshToken(string token) => PlayerPrefs.SetString(refreshTokenKEY, token);
        public static string RefreshToken => PlayerPrefs.GetString(refreshTokenKEY, "");
    }

}