// Using your UI namespace

//using KidsGame.UI;


namespace AHEFramework.UI
{
    public class ConfigPages
    {
        public static string GetPathByType(System.Type type)
        {
            // Pages
            string address = GetPagesPath(type);
            if (!string.IsNullOrEmpty(address)) return address;

            // Overlay Pages
            address = GetOverlayPagesPath(type);
            if (!string.IsNullOrEmpty(address)) return address;

            // PopUps
            address = GetPopUpsPath(type);
            if (!string.IsNullOrEmpty(address)) return address;

            // Overlay PopUps
            address = GetOverlayPopUpsPath(type);
            if (!string.IsNullOrEmpty(address)) return address;

            return null;
        }

        public static string GetPagesPath(System.Type type)
        {
            string address = "";

            // PAGE ADDRESS

            address +=
                //                         PREFAB NAMES  
                //type == typeof(HomePage) ? "HomePage" :
                //type == typeof(HUDPage) ? "HUDPage" :
                //type == typeof(ShopPage) ? "ShopPage" :
                "";

             return (!string.IsNullOrEmpty(address) ? "UI/Pages/":"") + address;
        }

        public static string GetOverlayPagesPath(System.Type type)
        {
            string address = "";

            // POPUPS ADDRESS
            address +=
             //                     PREFAB NAMES  
             //type == typeof(PopUp) ? "PopUp" :
             "";

            return (!string.IsNullOrEmpty(address) ? "UI/OverlayPages/" : "") + address;
        }

        public static string GetPopUpsPath(System.Type type)
        {
            string address = "";

            // OVERLAY_PAGE ADDRESS

            address +=
             //                         PREFAB NAMES  
//             type == typeof(AuthTypePopUp) ? "AuthTypePopUp" :
//             type == typeof(AuthPhoneNumPopUp) ? "AuthPhoneNumPopUp" :
//             type == typeof(AuthLoginPopUp) ? "AuthLoginPopUp" :
//             type == typeof(AuthGuestLoginPopUp) ? "AuthGuestLoginPopUp" :
//             type == typeof(RulesPopUp) ? "RulesPopUp" : 
//             type == typeof(PopUp) ? "PopUp" :
//             type == typeof(ChangeBackgroundPopUp) ? "ChangeBackgroundPopUp" :
//             type == typeof(SettingsPopUp) ? "SettingsPopUp" :
//             type == typeof(FreeCoinPopUp) ? "FreeCoinPopUp" :
//             type == typeof(EditProfilePopUp) ? "EditProfilePopUp" :
                "";

            return (!string.IsNullOrEmpty(address) ? "UI/PopUps/" : "") + address;
        }

        public static string GetOverlayPopUpsPath(System.Type type)
        {
            string address = "";

            // OVERLAY_POPUPS ADDRESS
            address +=
             //                            PREFAB NAMES  
             //type == typeof(LoadingPage) ? "Loading" :
             "";

            return (!string.IsNullOrEmpty(address) ? "UI/OverlayPopUps/" : "") + address;
        }
    }
}