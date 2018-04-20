using System;
namespace Salon_Pro_APP.Constants
{
    public class ApplicationConstant
    {

        #region email
        public const int EmailPort = 25;
        public const int EmailTimeout = 10000;
        public const string EmailHost = "smtp.salonmedia22.com";
        public static string EmailAddress = "app@salonmedia22.com";
        public static string EmailPassword = "#Welcome206520591@";

        public static string IPhoneFeedbackEmailSubject = "AppNameHere|iPhone|Feedback";
        public static string AndroidFeedbackEmailSubject = "AppNameHere|Android|Feedback";
        #endregion

        public static string BackgroundColor = "#f4dc42";//background color of the app


        #region URLs
        public static string Link1URL = "https://desalonpro.com/";
        public static string Link2WebUrl = "https://desalonpro.com/videos/";
        public static string Link3WebUrl = "https://desalonpro.com/classes-and-events/";
        public static string Link4WebUrl = "https://desalonpro.com/educators/";
        public static string Link5WebUrl = "https://desalonpro.com/probox/";
        public static string Link6WebUrl = "https://desalonpro.com/partners/";
        public static string Link7WebUrl = "https://desalonpro.com/wp-login.php";
        public static string Link8WebUrl = "https://desalonpro.com/wp-login.php";
        #endregion

        #region hamburger menu titles
        public static string DashboardPageMenuTitle = "Home";
        public static string Link1MenuTitle = "Link 1";
        public static string Link2MenuTitle = "Link 2";
        public static string Link3MenuTitle = "Link 3";
        public static string Link4MenuTitle = "Link 4";
        public static string Link5MenuTitle = "Link 5";
        public static string Link6MenuTitle = "Link 6";
        public static string Link7MenuTitle = "Link 7";
        public static string Link8MenuTitle = "Link 8";
        public static string LinkFeedbackMenuTitle = "Feedback";
       
        #endregion

        #region hamburger menu icons
        public static string DashboardLinkMenuIcon = "buy_de_products_menu.png";

        public static string Link1MenuIcon = "buy_de_products_menu.png";
        public static string Link2MenuIcon = "knowlage_video_menu.png";
        public static string Link3MenuIcon = "classes_events_video_menu.png";
        public static string Link4MenuIcon = "educators_home_24x24.png";
        public static string Link5MenuIcon = "pro_box_menu.png";
        public static string Link6MenuIcon = "partner_menu.png";
        public static string Link7MenuIcon = "partner_menu.png";
        public static string Link8MenuIcon = "partner_menu.png";
        public static string LinkFeedbackMenuIcon = "partner_menu.png";
        #endregion

        #region MainDashBoard images
        public static string DashboardPageBGImage = "homebackground.png";

        public static string DashboardImageHolder1 = "home_image_holder_1";
        public static string DashboardImageHolder2 = "home_image_holder_2";
        public static string DashboardImageHolder3 = "home_image_holder_3";
        public static string DashboardImageHolder4 = "home_image_holder_4";
        public static string DashboardImageHolder5 = "home_image_holder_5";
        public static string DashboardImageHolder6 = "home_image_holder_6";
        public static string DashboardImageHolder7 = "home_image_holder_6";
        public static string DashboardImageHolder8 = "home_image_holder_6";
        #endregion

        #region Feedback 
        public static string PhoneNumber = "(800) 473-2825";
        public static string FeedbackPreference = "Would you like to receive information and promotional email" +
            " messages from Great Clips? You may unsubscribe at any time";
        #endregion

    }
}
