
using CoreLocation;
using Foundation;
using UIKit;
using BaiduPush.iOS;

namespace BaiduPush.iOS
{
 

[Static]
//[Verify(ConstantsInterfaceAssociation)]
partial interface Constants
{
    // extern NSString *const BPushRequestErrorCodeKey;
    [Field("BPushRequestErrorCodeKey", "__Internal")]
    NSString BPushRequestErrorCodeKey { get; }

    // extern NSString *const BPushRequestErrorMsgKey;
    [Field("BPushRequestErrorMsgKey", "__Internal")]
    NSString BPushRequestErrorMsgKey { get; }

    // extern NSString *const BPushRequestRequestIdKey;
    [Field("BPushRequestRequestIdKey", "__Internal")]
    NSString BPushRequestRequestIdKey { get; }

    // extern NSString *const BPushRequestAppIdKey;
    [Field("BPushRequestAppIdKey", "__Internal")]
    NSString BPushRequestAppIdKey { get; }

    // extern NSString *const BPushRequestUserIdKey;
    [Field("BPushRequestUserIdKey", "__Internal")]
    NSString BPushRequestUserIdKey { get; }

    // extern NSString *const BPushRequestChannelIdKey;
    [Field("BPushRequestChannelIdKey", "__Internal")]
    NSString BPushRequestChannelIdKey { get; }

    // extern NSString *const BPushRequestResponseParamsKey;
    [Field("BPushRequestResponseParamsKey", "__Internal")]
    NSString BPushRequestResponseParamsKey { get; }

    // extern NSString *const BPushRequestMethodBind;
    [Field("BPushRequestMethodBind", "__Internal")]
    NSString BPushRequestMethodBind { get; }

    // extern NSString *const BPushRequestMethodUnbind;
    [Field("BPushRequestMethodUnbind", "__Internal")]
    NSString BPushRequestMethodUnbind { get; }

    // extern NSString *const BPushRequestMethodSetTag;
    [Field("BPushRequestMethodSetTag", "__Internal")]
    NSString BPushRequestMethodSetTag { get; }

    // extern NSString *const BPushRequestMethodDelTag;
    [Field("BPushRequestMethodDelTag", "__Internal")]
    NSString BPushRequestMethodDelTag { get; }

    // extern NSString *const BPushRequestMethodListTag;
    [Field("BPushRequestMethodListTag", "__Internal")]
    NSString BPushRequestMethodListTag { get; }
}

// typedef void (^BPushCallBack)(id, NSError *);
delegate void BPushCallBack(NSObject arg0, NSError arg1);

// @interface BPush : NSObject
[BaseType(typeof(NSObject))]
interface BPush
{
    // +(void)registerChannel:(NSDictionary *)launchOptions apiKey:(NSString *)apikey pushMode:(BPushMode)mode withFirstAction:(NSString *)rightAction withSecondAction:(NSString *)leftAction withCategory:(NSString *)category useBehaviorTextInput:(BOOL)behaviorTextInput isDebug:(BOOL)isdebug;
    [Static]
    [Export("registerChannel:apiKey:pushMode:withFirstAction:withSecondAction:withCategory:useBehaviorTextInput:isDebug:")]
    void RegisterChannel(NSDictionary launchOptions, string apikey, BPushMode mode, string rightAction, string leftAction, string category, bool behaviorTextInput, bool isdebug);

    // +(void)registerDeviceToken:(NSData *)deviceToken;
    [Static]
    [Export("registerDeviceToken:")]
    void RegisterDeviceToken(NSData deviceToken);

    // +(void)setAccessToken:(NSString *)token;
    [Static]
    [Export("setAccessToken:")]
    void SetAccessToken(string token);

    // +(void)disableLbs;
    [Static]
    [Export("disableLbs")]
    void DisableLbs();

    // +(void)uploadBPushCrashLog;
    [Static]
    [Export("uploadBPushCrashLog")]
    void UploadBPushCrashLog();

    // +(void)bindChannelWithCompleteHandler:(BPushCallBack)handler;
    [Static]
    [Export("bindChannelWithCompleteHandler:")]
    void BindChannelWithCompleteHandler(BPushCallBack handler);

    // +(void)unbindChannelWithCompleteHandler:(BPushCallBack)handler;
    [Static]
    [Export("unbindChannelWithCompleteHandler:")]
    void UnbindChannelWithCompleteHandler(BPushCallBack handler);

    // +(void)setTag:(NSString *)tag withCompleteHandler:(BPushCallBack)handler;
    [Static]
    [Export("setTag:withCompleteHandler:")]
    void SetTag(string tag, BPushCallBack handler);

    // +(void)setTags:(NSArray *)tags withCompleteHandler:(BPushCallBack)handler;
    [Static]
    [Export("setTags:withCompleteHandler:")]
    //[Verify(StronglyTypedNSArray)]
    void SetTags(NSObject[] tags, BPushCallBack handler);

    // +(void)delTag:(NSString *)tag withCompleteHandler:(BPushCallBack)handler;
    [Static]
    [Export("delTag:withCompleteHandler:")]
    void DelTag(string tag, BPushCallBack handler);

    // +(void)delTags:(NSArray *)tags withCompleteHandler:(BPushCallBack)handler;
    [Static]
    [Export("delTags:withCompleteHandler:")]
    //[Verify(StronglyTypedNSArray)]
    void DelTags(NSObject[] tags, BPushCallBack handler);

    // +(void)listTagsWithCompleteHandler:(BPushCallBack)handler;
    [Static]
    [Export("listTagsWithCompleteHandler:")]
    void ListTagsWithCompleteHandler(BPushCallBack handler);

    // +(void)handleNotification:(NSDictionary *)userInfo;
    [Static]
    [Export("handleNotification:")]
    void HandleNotification(NSDictionary userInfo);

    // +(void)statsGrayInterface:(BOOL)isOpen withAppGroupName:(NSString *)appGroupName withAPPid:(NSString *)appid;
    [Static]
    [Export("statsGrayInterface:withAppGroupName:withAPPid:")]
    void StatsGrayInterface(bool isOpen, string appGroupName, string appid);

    // +(NSString *)getChannelId;
    [Static]
    [Export("getChannelId")]
    //[Verify(MethodToProperty)]
    string ChannelId { get; }

    // +(NSString *)getUserId;
    [Static]
    [Export("getUserId")]
    //[Verify(MethodToProperty)]
    string UserId { get; }

    // +(NSString *)getAppId;
    [Static]
    [Export("getAppId")]
    //[Verify(MethodToProperty)]
    string AppId { get; }

    // +(void)localNotification:(NSDate *)date alertBody:(NSString *)body badge:(int)bage withFirstAction:(NSString *)rightAction withSecondAction:(NSString *)leftAction userInfo:(NSDictionary *)userInfo soundName:(NSString *)soundName region:(CLRegion *)region regionTriggersOnce:(BOOL)regionTriggersOnce category:(NSString *)category useBehaviorTextInput:(BOOL)behaviorTextInput;
    [Static]
    [Export("localNotification:alertBody:badge:withFirstAction:withSecondAction:userInfo:soundName:region:regionTriggersOnce:category:useBehaviorTextInput:")]
    void LocalNotification(NSDate date, string body, int bage, string rightAction, string leftAction, NSDictionary userInfo, string soundName, CLRegion region, bool regionTriggersOnce, string category, bool behaviorTextInput);

    // +(void)showLocalNotificationAtFront:(UILocalNotification *)notification identifierKey:(NSString *)notificationKey;
    [Static]
    [Export("showLocalNotificationAtFront:identifierKey:")]
    void ShowLocalNotificationAtFront(UILocalNotification notification, string notificationKey);

    // +(void)deleteLocalNotificationWithIdentifierKey:(NSString *)notificationKey;
    [Static]
    [Export("deleteLocalNotificationWithIdentifierKey:")]
    void DeleteLocalNotificationWithIdentifierKey(string notificationKey);

    // +(void)deleteLocalNotification:(UILocalNotification *)localNotification;
    [Static]
    [Export("deleteLocalNotification:")]
    void DeleteLocalNotification(UILocalNotification localNotification);

    // +(NSArray *)findLocalNotificationWithIdentifier:(NSString *)notificationKey;
    [Static]
    [Export("findLocalNotificationWithIdentifier:")]
    //[Verify(StronglyTypedNSArray)]
    NSObject[] FindLocalNotificationWithIdentifier(string notificationKey);

    // +(void)clearAllLocalNotifications;
    [Static]
    [Export("clearAllLocalNotifications")]
    void ClearAllLocalNotifications();
}
}
