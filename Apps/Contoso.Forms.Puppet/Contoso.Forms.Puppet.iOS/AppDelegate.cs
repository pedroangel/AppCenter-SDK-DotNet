﻿using Foundation;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics.iOS.Bindings;
using Microsoft.Azure.Mobile.Distribute.iOS.Bindings;
using UIKit;

namespace Contoso.Forms.Puppet.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Xamarin.Forms.Forms.Init();
            MSAnalytics.SetDelegate(new AnalyticsDelegate());
            LoadApplication(new App());
            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            MSDistribute.OpenUrl(url);

            return true;
        }
    }

    public class AnalyticsDelegate : MSAnalyticsDelegate
    {
        public override void WillSendEventLog(MSAnalytics analytics, MSEventLog eventLog)
        {
            MobileCenterLog.Debug(App.LogTag, "Will send event");
        }

        public override void DidSucceedSendingEventLog(MSAnalytics analytics, MSEventLog eventLog)
        {
            MobileCenterLog.Debug(App.LogTag, "Did send event");
        }

        public override void DidFailSendingEventLog(MSAnalytics analytics, MSEventLog eventLog, NSError error)
        {
            MobileCenterLog.Debug(App.LogTag, "Failed to send event with error: " + error);
        }
    }
}
