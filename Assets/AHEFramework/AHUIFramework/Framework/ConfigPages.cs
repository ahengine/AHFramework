// Using your UI namespace

//using KidsGame.UI;


namespace AHEFramework.UIFramework
{
    public static class ConfigPages
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


        // ----------------------------PAGE ADDRESS----------------------------------------------------
        public static string GetPagesPath(System.Type type)
        {
            string address = "";

            address +=
                //                         PREFAB NAMES  
                //type == typeof(HomePage) ? "HomePage" :
                "";

             return (!string.IsNullOrEmpty(address) ? "UI/Pages/":"") + address;
        }

         
        // ----------------------------POPUPS ADDRESS----------------------------------------------------
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


        // ----------------------------OVERLAY PAGE ADDRESS----------------------------------------------------
        public static string GetPopUpsPath(System.Type type)
        {
            string address = "";

            // OVERLAY_PAGE ADDRESS

            address +=
             //                         PREFAB NAMES  
//             type == typeof(AuthTypePopUp) ? "AuthTypePopUp" :

                "";

            return (!string.IsNullOrEmpty(address) ? "UI/PopUps/" : "") + address;
        }


        // ----------------------------OVERLAY POPUPS ADDRESS----------------------------------------------------
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