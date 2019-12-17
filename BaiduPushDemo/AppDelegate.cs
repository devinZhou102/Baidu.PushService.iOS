using System;
using System.Diagnostics;
using System.Text;
using BaiduPush.iOS;
using Foundation;
using UIKit;

namespace BaiduPushDemo
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {

        const string ApiKey = "your api key";

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Debug.WriteLine("=== FinishedLaunching ===");
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            RegisterForRemoteNotifications();
            if (launchOptions == null)
            {
                //注册apns远程推送
                launchOptions = new NSDictionary();
            }
            BPush.RegisterChannel(launchOptions, ApiKey, BPushMode.Development, "open", "close", "test", false, true);
            return true;
        }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            Debug.WriteLine("=== GetConfiguration ===");
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }

        [Export("application:didReceiveRemoteNotification:")]
        public void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {

            Debug.WriteLine("=== ReceivedRemoteNotification ===");
        }


        [Export("application:didRegisterUserNotificationSettings:")]
        public void DidRegisterUserNotificationSettings(UIApplication application, UIUserNotificationSettings notificationSettings)
        {
            application.RegisterForRemoteNotifications();
        }

        [Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
        public void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            Debug.WriteLine("=== RegisteredForRemoteNotifications ===");
            byte[] dataBytes = new byte[deviceToken.Length];
            System.Runtime.InteropServices.Marshal.Copy(deviceToken.Bytes, dataBytes, 0, Convert.ToInt32(deviceToken.Length));
            StringBuilder builder = new StringBuilder();
            foreach (var b in dataBytes)
            {
                builder.AppendFormat("{0:X2}", b);
            }
            var token = builder.ToString();

            BPush.RegisterDeviceToken(deviceToken);
            BPush.BindChannelWithCompleteHandler(new BPushCallBack(BindChannel));

            void BindChannel(NSObject result, NSError error)
            {
                if (error != null) return;
                if (result != null)
                {

                    // 确认绑定成功
                    var c = result.ValueForKey(new NSString("error_code"));
                    if (c is NSNumber ic && ic.Int32Value != 0) return;
                    var channelId = BPush.ChannelId;

                    BPush.ListTagsWithCompleteHandler(ListTags);

                    void ListTags(NSObject nsresult, NSError nserror)
                    {

                    }

                    BPush.SetTag("tag", SetTag);

                    void SetTag(NSObject nsresult, NSError nserror)
                    {

                    }

                }

            }
        }



        [Export("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
        public void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {

        }

        public void RegisterForRemoteNotifications()
        {

            Debug.WriteLine("=== RegisterForRemoteNotifications 123412341234123 ===");
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                       UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                       new NSSet());
                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }
        }
    }
}

