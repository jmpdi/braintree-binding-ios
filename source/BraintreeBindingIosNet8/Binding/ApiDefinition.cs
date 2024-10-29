#define STARTUP_CRASH_BRAINTREE_APPLE_PAY
#define STARTUP_CRASH_BRAINTREE_CARD
#define STARTUP_CRASH_BRAINTREE_PAYPAL
#define STARTUP_CRASH_BRAINTREE_VENMO

using System;
using System.Security.Cryptography;
using Foundation;
using ObjCRuntime;
using PassKit;
using AuthenticationServices;
using UIKit;
using WebKit;

namespace Braintree
{
	#region ADDITIONS

	
	//========================================================================
	//
	// ADDITIONS
	//
	//========================================================================
	
	partial interface IBTAppSwitchHandler { };
	partial interface IBTAppSwitchDelegate { };
	partial interface IBTAppSwitchDelegate { };
	partial interface IBTViewControllerPresentingDelegate { };
	partial interface IBTPayPalApprovalDelegate { };
	partial interface IBTAppContextSwitchClient { };

	delegate void GetTokenizationCompletionblock(BTPaymentMethodNonce nonce, NSError error);
	delegate void RegisterTokenizationCompleteBlock(BTAPIClient client, NSDictionary data, [BlockCallback] GetTokenizationCompletionblock subblock);
	delegate void FetchOrReturnRemoteConfigurationCompletionBlock(BTConfiguration configuration, NSError error);
	//delegate void FetchPaymentMethodNoncesCompletionBlock(NSArray<BTPaymentMethodNonce> items, NSError error);
	delegate void BTJsonCompletionBlock(BTJSON json, NSHttpUrlResponse response, NSError error);
	
	
	#endregion
	
	#region BRAINTREE CORE
	
	
	//========================================================================
	//
	// BRAINTREE CORE 
	//
	//========================================================================
	
	// @interface BTAPIClient : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore11BTAPIClient")]
	[DisableDefaultCtor]
	interface BTAPIClient
	{
		// -(instancetype _Nullable)initWithAuthorization:(NSString * _Nonnull)authorization __attribute__((objc_designated_initializer));
		[Export ("initWithAuthorization:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string authorization);

		// -(void)fetchOrReturnRemoteConfiguration:(void (^ _Nonnull)(BTConfiguration * _Nullable, NSError * _Nullable))completion;
		[Export ("fetchOrReturnRemoteConfiguration:")]
		void FetchOrReturnRemoteConfiguration (Action<BTConfiguration, NSError> completion);

		// -(void)fetchPaymentMethodNonces:(void (^ _Nonnull)(NSArray<BTPaymentMethodNonce *> * _Nullable, NSError * _Nullable))completion;
		[Export ("fetchPaymentMethodNonces:")]
		void FetchPaymentMethodNonces (Action<NSArray<BTPaymentMethodNonce>, NSError> completion);

		// -(void)fetchPaymentMethodNonces:(BOOL)defaultFirst completion:(void (^ _Nonnull)(NSArray<BTPaymentMethodNonce *> * _Nullable, NSError * _Nullable))completion;
		[Export ("fetchPaymentMethodNonces:completion:")]
		void FetchPaymentMethodNonces (bool defaultFirst, Action<NSArray<BTPaymentMethodNonce>, NSError> completion);
	
		// -(void)POST:(NSString * _Nonnull)path parameters:(NSDictionary<NSString *,id> * _Nullable)parameters httpType:(enum BTAPIClientHTTPService)httpType completion:(void (^ _Nonnull)(BTJSON * _Nullable, NSHTTPURLResponse * _Nullable, NSError * _Nullable))completion;
		[Export ("POST:parameters:httpType:completion:")]
		void POST (string path, [NullAllowed] NSDictionary<NSString, NSObject> parameters, BTAPIClientHTTPService httpType, [NullAllowed][BlockCallback] BTJsonCompletionBlock completionBlock);
	}

	// @protocol BTAppContextSwitchClient
	/*
	  Check whether adding [Model] to this declaration is appropriate.
	  [Model] is used to generate a C# class that implements this protocol,
	  and might be useful for protocols that consumers are supposed to implement,
	  since consumers can subclass the generated class instead of implementing
	  the generated interface. If consumers are not supposed to implement this
	  protocol, then [Model] is redundant and will generate code that will never
	  be used.
	*/
	[BaseType (typeof(NSObject))]
	[Protocol (Name = "_TtP13BraintreeCore24BTAppContextSwitchClient_")]
	interface BTAppContextSwitchClient
	{
		// @required +(BOOL)canHandleReturnURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
		[Static, Abstract]
		[Export ("canHandleReturnURL:")]
		bool CanHandleReturnURL (NSUrl url);

		// @required +(void)handleReturnURL:(NSURL * _Nonnull)url;
		[Static, Abstract]
		[Export ("handleReturnURL:")]
		void HandleReturnURL (NSUrl url);
	}

	// @interface BTAppContextSwitcher : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore20BTAppContextSwitcher")]
	interface BTAppContextSwitcher
	{
		// @property (readonly, nonatomic, strong, class) BTAppContextSwitcher * _Nonnull sharedInstance;
		[Static]
		[Export ("sharedInstance", ArgumentSemantic.Strong)]
		BTAppContextSwitcher SharedInstance { get; }

		// @property (copy, nonatomic) NSString * _Nonnull returnURLScheme;
		[Export ("returnURLScheme")]
		string ReturnURLScheme { get; set; }

		// -(BOOL)handleOpenURLContext:(UIOpenURLContext * _Nonnull)context;
		[Export ("handleOpenURLContext:")]
		bool HandleOpenURLContext (UIOpenUrlContext context);

		// -(BOOL)handleOpenURL:(NSURL * _Nonnull)url;
		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

		// -(void)registerAppContextSwitchClient:(Class<BTAppContextSwitchClient> _Nonnull)client;
		[Export ("registerAppContextSwitchClient:")]
		void RegisterAppContextSwitchClient (BTAppContextSwitchClient client);
	}

	// @interface BTBinData : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore9BTBinData")]
	[DisableDefaultCtor]
	interface BTBinData
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull prepaid;
		[Export ("prepaid")]
		string Prepaid { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull healthcare;
		[Export ("healthcare")]
		string Healthcare { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull debit;
		[Export ("debit")]
		string Debit { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull durbinRegulated;
		[Export ("durbinRegulated")]
		string DurbinRegulated { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull commercial;
		[Export ("commercial")]
		string Commercial { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull payroll;
		[Export ("payroll")]
		string Payroll { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull issuingBank;
		[Export ("issuingBank")]
		string IssuingBank { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull countryOfIssuance;
		[Export ("countryOfIssuance")]
		string CountryOfIssuance { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull productID;
		[Export ("productID")]
		string ProductID { get; }

		// -(instancetype _Nonnull)initWithJSON:(BTJSON * _Nullable)json __attribute__((objc_designated_initializer));
		[Export ("initWithJSON:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] BTJSON json);
	}

	// @interface BTClientToken : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore13BTClientToken")]
	[DisableDefaultCtor]
	interface BTClientToken : INSCoding, INSCopying
	{
		// @property (readonly, nonatomic, strong) BTJSON * _Nonnull json;
		[Export ("json", ArgumentSemantic.Strong)]
		BTJSON Json { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull bearer;
		[Export ("bearer")]
		string Bearer { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nonnull configURL;
		[Export ("configURL", ArgumentSemantic.Copy)]
		NSUrl ConfigURL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull originalValue;
		[Export ("originalValue")]
		string OriginalValue { get; }

		// -(instancetype _Nullable)initWithClientToken:(NSString * _Nonnull)clientToken error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithClientToken:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string clientToken, [NullAllowed] out NSError error);

		// // -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
		// [Export ("encodeWithCoder:")]
		// void EncodeWithCoder (NSCoder coder);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder;
		// [Export ("initWithCoder:")]
		// NativeHandle Constructor (NSCoder coder);

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result("")));
		// [Export ("copyWithZone:")]
		// unsafe NSObject CopyWithZone ([NullAllowed] NSZone zone);

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface BTConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore15BTConfiguration")]
	[DisableDefaultCtor]
	interface BTConfiguration
	{
		// @property (readonly, nonatomic, strong) BTJSON * _Nullable json;
		[NullAllowed, Export ("json", ArgumentSemantic.Strong)]
		BTJSON Json { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable environment;
		[NullAllowed, Export ("environment")]
		string Environment { get; }

		// @property (nonatomic) BOOL isFromCache;
		[Export ("isFromCache")]
		bool IsFromCache { get; set; }

		// -(instancetype _Nonnull)initWithJSON:(BTJSON * _Nullable)json __attribute__((objc_designated_initializer));
		[Export ("initWithJSON:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] BTJSON json);
	}

	// @interface BTCoreConstants : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore15BTCoreConstants")]
	interface BTCoreConstants
	{
		// @property (copy, nonatomic, class) NSString * _Nonnull braintreeSDKVersion;
		[Static]
		[Export ("braintreeSDKVersion")]
		string BraintreeSDKVersion { get; set; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull callbackURLScheme;
		[Static]
		[Export ("callbackURLScheme")]
		string CallbackURLScheme { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull venmoURLScheme;
		[Static]
		[Export ("venmoURLScheme")]
		string VenmoURLScheme { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull payPalURLScheme;
		[Static]
		[Export ("payPalURLScheme")]
		string PayPalURLScheme { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull httpErrorDomain;
		[Static]
		[Export ("httpErrorDomain")]
		string HttpErrorDomain { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull urlResponseKey;
		[Static]
		[Export ("urlResponseKey")]
		string UrlResponseKey { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull jsonResponseBodyKey;
		[Static]
		[Export ("jsonResponseBodyKey")]
		string JsonResponseBodyKey { get; }
	}

	// @interface BTJSON : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore6BTJSON")]
	interface BTJSON
	{
		// -(instancetype _Nonnull)initWithValue:(id _Nullable)value;
		[Export ("initWithValue:")]
		NativeHandle Constructor ([NullAllowed] NSObject value);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data;
		[Export ("initWithData:")]
		NativeHandle Constructor (NSData data);

		// @property (readonly, nonatomic) BOOL isString;
		[Export ("isString")]
		bool IsString { get; }

		// @property (readonly, nonatomic) BOOL isBool;
		[Export ("isBool")]
		bool IsBool { get; }

		// @property (readonly, nonatomic) BOOL isNumber;
		[Export ("isNumber")]
		bool IsNumber { get; }

		// @property (readonly, nonatomic) BOOL isArray;
		[Export ("isArray")]
		bool IsArray { get; }

		// @property (readonly, nonatomic) BOOL isObject;
		[Export ("isObject")]
		bool IsObject { get; }

		// @property (readonly, nonatomic) BOOL isError;
		[Export ("isError")]
		bool IsError { get; }

		// @property (readonly, nonatomic) BOOL isTrue;
		[Export ("isTrue")]
		bool IsTrue { get; }

		// @property (readonly, nonatomic) BOOL isFalse;
		[Export ("isFalse")]
		bool IsFalse { get; }

		// @property (readonly, nonatomic) BOOL isNull;
		[Export ("isNull")]
		bool IsNull { get; }

		// -(BTJSON * _Nonnull)objectAtIndexedSubscript:(NSInteger)index __attribute__((warn_unused_result("")));
		[Export ("objectAtIndexedSubscript:")]
		BTJSON ObjectAtIndexedSubscript (nint index);

		// -(BTJSON * _Nonnull)objectForKeyedSubscript:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
		[Export ("objectForKeyedSubscript:")]
		BTJSON ObjectForKeyedSubscript (string key);

		// -(NSError * _Nullable)asError __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("asError")]
		//[Verify (MethodToProperty)]
		NSError AsError { get; }

		// -(NSString * _Nullable)asString __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("asString")]
		//[Verify (MethodToProperty)]
		string AsString { get; }

		// -(NSArray<BTJSON *> * _Nullable)asArray __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("asArray")]
		//[Verify (MethodToProperty)]
		BTJSON[] AsArray { get; }

		// -(NSNumber * _Nullable)asNumber __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("asNumber")]
		//[Verify (MethodToProperty)]
		NSNumber AsNumber { get; }

		// -(NSURL * _Nullable)asURL __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("asURL")]
		//[Verify (MethodToProperty)]
		NSUrl AsURL { get; }

		// -(NSArray<NSString *> * _Nullable)asStringArray __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("asStringArray")]
		//[Verify (MethodToProperty)]
		string[] AsStringArray { get; }

		// -(NSDictionary * _Nullable)asDictionary __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("asDictionary")]
		//[Verify (MethodToProperty)]
		NSDictionary AsDictionary { get; }

		// -(NSInteger)asIntegerOrZero __attribute__((warn_unused_result("")));
		[Export ("asIntegerOrZero")]
		//[Verify (MethodToProperty)]
		nint AsIntegerOrZero { get; }

		// -(NSInteger)asEnum:(NSDictionary<NSString *,id> * _Nonnull)mapping orDefault:(NSInteger)orDefault __attribute__((warn_unused_result("")));
		[Export ("asEnum:orDefault:")]
		nint AsEnum (NSDictionary<NSString, NSObject> mapping, nint orDefault);

		// -(BTPostalAddress * _Nullable)asAddress __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("asAddress")]
		//[Verify (MethodToProperty)]
		BTPostalAddress AsAddress { get; }
	}

	// @interface BTLogLevelDescription : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore21BTLogLevelDescription")]
	interface BTLogLevelDescription
	{
	}

	// @interface BTPaymentMethodNonce : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore20BTPaymentMethodNonce")]
	[DisableDefaultCtor]
	interface BTPaymentMethodNonce
		: INativeObject
	{
		// @property (copy, nonatomic) NSString * _Nonnull nonce;
		[Export ("nonce")]
		string Nonce { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; set; }

		// @property (nonatomic) BOOL isDefault;
		[Export ("isDefault")]
		bool IsDefault { get; set; }

		// -(instancetype _Nonnull)initWithNonce:(NSString * _Nonnull)nonce __attribute__((objc_designated_initializer));
		[Export ("initWithNonce:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string nonce);

		// -(instancetype _Nonnull)initWithNonce:(NSString * _Nonnull)nonce type:(NSString * _Nonnull)type __attribute__((objc_designated_initializer));
		[Export ("initWithNonce:type:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string nonce, string type);

		// -(instancetype _Nonnull)initWithNonce:(NSString * _Nonnull)nonce type:(NSString * _Nonnull)type isDefault:(BOOL)isDefault __attribute__((objc_designated_initializer));
		[Export ("initWithNonce:type:isDefault:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string nonce, string type, bool isDefault);
	}

	// @interface BTPaymentMethodNonceParser : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore26BTPaymentMethodNonceParser")]
	interface BTPaymentMethodNonceParser
	{
		// @property (readonly, nonatomic, strong, class) BTPaymentMethodNonceParser * _Nonnull sharedParser;
		[Static]
		[Export ("sharedParser", ArgumentSemantic.Strong)]
		BTPaymentMethodNonceParser SharedParser { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull allTypes;
		[Export ("allTypes", ArgumentSemantic.Copy)]
		string[] AllTypes { get; }

		// -(BOOL)isTypeAvailable:(NSString * _Nonnull)type __attribute__((warn_unused_result("")));
		[Export ("isTypeAvailable:")]
		bool IsTypeAvailable (string type);

		// -(void)registerType:(NSString * _Nullable)type withParsingBlock:(BTPaymentMethodNonce * _Nullable (^ _Nonnull)(BTJSON * _Nullable))withParsingBlock;
		[Export ("registerType:withParsingBlock:")]
		void RegisterType ([NullAllowed] string type, Func<BTJSON, BTPaymentMethodNonce> withParsingBlock);

		// -(BTPaymentMethodNonce * _Nullable)parseJSON:(BTJSON * _Nullable)json withParsingBlockForType:(NSString * _Nullable)type __attribute__((warn_unused_result("")));
		[Export ("parseJSON:withParsingBlockForType:")]
		[return: NullAllowed]
		BTPaymentMethodNonce ParseJSON ([NullAllowed] BTJSON json, [NullAllowed] string type);
	}

	// @interface BTPostalAddress : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore15BTPostalAddress")]
	interface BTPostalAddress
	{
		// @property (copy, nonatomic) NSString * _Nullable recipientName;
		[NullAllowed, Export ("recipientName")]
		string RecipientName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable streetAddress;
		[NullAllowed, Export ("streetAddress")]
		string StreetAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extendedAddress;
		[NullAllowed, Export ("extendedAddress")]
		string ExtendedAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable locality;
		[NullAllowed, Export ("locality")]
		string Locality { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable countryCodeAlpha2;
		[NullAllowed, Export ("countryCodeAlpha2")]
		string CountryCodeAlpha2 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable region;
		[NullAllowed, Export ("region")]
		string Region { get; set; }
	}

	// @interface BTURLUtils : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore10BTURLUtils")]
	interface BTURLUtils
	{
	}

	// @interface BTWebAuthenticationSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore26BTWebAuthenticationSession")]
	interface BTWebAuthenticationSession
	{
	}

	// @interface BTWebAuthenticationSessionClient : NSObject <ASWebAuthenticationPresentationContextProviding>
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCore32BTWebAuthenticationSessionClient")]
	interface BTWebAuthenticationSessionClient : IASWebAuthenticationPresentationContextProviding
	{
		// // -(ASPresentationAnchor _Nonnull)presentationAnchorForWebAuthenticationSession:(ASWebAuthenticationSession * _Nonnull)session __attribute__((warn_unused_result("")));
		// [Export ("presentationAnchorForWebAuthenticationSession:")]
		// UIWindow PresentationAnchorForWebAuthenticationSession (ASWebAuthenticationSession session);
	}
	

	#endregion
	
	#region BRAINTREE AMERICAN EXPRESS	
	
	
	//========================================================================
	//
	// BRAINTREE AMERICAN EXPRESS 
	//
	//========================================================================
	
	// @interface BTAmericanExpressClient : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC24BraintreeAmericanExpress23BTAmericanExpressClient")]
	[DisableDefaultCtor]
	interface BTAmericanExpressClient
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BTAPIClient apiClient);

		// -(void)getRewardsBalanceForNonce:(NSString * _Nonnull)nonce currencyIsoCode:(NSString * _Nonnull)currencyISOCode completion:(void (^ _Nonnull)(BTAmericanExpressRewardsBalance * _Nullable, NSError * _Nullable))completion;
		[Export ("getRewardsBalanceForNonce:currencyIsoCode:completion:")]
		void GetRewardsBalanceForNonce (string nonce, string currencyISOCode, Action<BTAmericanExpressRewardsBalance, NSError> completion);
	}

	// @interface BTAmericanExpressRewardsBalance : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC24BraintreeAmericanExpress31BTAmericanExpressRewardsBalance")]
	[DisableDefaultCtor]
	interface BTAmericanExpressRewardsBalance
	{
		// @property (copy, nonatomic) NSString * _Nullable errorCode;
		[NullAllowed, Export ("errorCode")]
		string ErrorCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable errorMessage;
		[NullAllowed, Export ("errorMessage")]
		string ErrorMessage { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable conversionRate;
		[NullAllowed, Export ("conversionRate")]
		string ConversionRate { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currencyAmount;
		[NullAllowed, Export ("currencyAmount")]
		string CurrencyAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currencyIsoCode;
		[NullAllowed, Export ("currencyIsoCode")]
		string CurrencyIsoCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable requestID;
		[NullAllowed, Export ("requestID")]
		string RequestID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable rewardsAmount;
		[NullAllowed, Export ("rewardsAmount")]
		string RewardsAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable rewardsUnit;
		[NullAllowed, Export ("rewardsUnit")]
		string RewardsUnit { get; set; }
	}
	
	
	#endregion

	#region BRAINTREE APPLE PAY
	
	
	//========================================================================
	//
	// BRAINTREE APPLE PAY 
	//
	//========================================================================
	
	// @interface BTApplePayCardNonce : BTPaymentMethodNonce
#if STARTUP_CRASH_BRAINTREE_APPLE_PAY	
	[BaseType (typeof(BTPaymentMethodNonce), Name = "_TtC17BraintreeApplePay19BTApplePayCardNonce")]
#endif
	interface BTApplePayCardNonce
	{
		// @property (readonly, nonatomic, strong) BTBinData * _Nonnull binData;
		[Export ("binData", ArgumentSemantic.Strong)]
		BTBinData BinData { get; }
	}
	
	// @interface BTApplePayClient : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC17BraintreeApplePay16BTApplePayClient")]
	[DisableDefaultCtor]
	interface BTApplePayClient
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BTAPIClient apiClient);

		// -(void)makePaymentRequest:(void (^ _Nonnull)(PKPaymentRequest * _Nullable, NSError * _Nullable))completion;
		[Export ("makePaymentRequest:")]
		void MakePaymentRequest (Action<PKPaymentRequest, NSError> completion);
		
#if STARTUP_CRASH_BRAINTREE_APPLE_PAY
		// -(void)tokenizeApplePayPayment:(PKPayment * _Nonnull)payment completion:(void (^ _Nonnull)(BTApplePayCardNonce * _Nullable, NSError * _Nullable))completion;
		[Export ("tokenizeApplePayPayment:completion:")]
		void TokenizeApplePayPayment (PKPayment payment, Action<BTApplePayCardNonce, NSError> completion);
#endif
	}
	
	
	#endregion

	#region BRAINTREE CARD
	
	
	//========================================================================
	//
	// BRAINTREE CARD 
	//
	//========================================================================
	
	// @interface BTAuthenticationInsight : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCard23BTAuthenticationInsight")]
	[DisableDefaultCtor]
	interface BTAuthenticationInsight
	{
		// @property (copy, nonatomic) NSString * _Nullable regulationEnvironment;
		[NullAllowed, Export ("regulationEnvironment")]
		string RegulationEnvironment { get; set; }
	}

	// @interface BTCard : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCard6BTCard")]
	interface BTCard
	{
		// @property (copy, nonatomic) NSString * _Nullable number;
		[NullAllowed, Export ("number")]
		string Number { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable expirationMonth;
		[NullAllowed, Export ("expirationMonth")]
		string ExpirationMonth { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable expirationYear;
		[NullAllowed, Export ("expirationYear")]
		string ExpirationYear { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cvv;
		[NullAllowed, Export ("cvv")]
		string Cvv { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cardholderName;
		[NullAllowed, Export ("cardholderName")]
		string CardholderName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName")]
		string FirstName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName")]
		string LastName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable company;
		[NullAllowed, Export ("company")]
		string Company { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable streetAddress;
		[NullAllowed, Export ("streetAddress")]
		string StreetAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extendedAddress;
		[NullAllowed, Export ("extendedAddress")]
		string ExtendedAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable locality;
		[NullAllowed, Export ("locality")]
		string Locality { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable region;
		[NullAllowed, Export ("region")]
		string Region { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable countryName;
		[NullAllowed, Export ("countryName")]
		string CountryName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable countryCodeAlpha2;
		[NullAllowed, Export ("countryCodeAlpha2")]
		string CountryCodeAlpha2 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable countryCodeAlpha3;
		[NullAllowed, Export ("countryCodeAlpha3")]
		string CountryCodeAlpha3 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable countryCodeNumeric;
		[NullAllowed, Export ("countryCodeNumeric")]
		string CountryCodeNumeric { get; set; }

		// @property (nonatomic) BOOL shouldValidate;
		[Export ("shouldValidate")]
		bool ShouldValidate { get; set; }

		// @property (nonatomic) BOOL authenticationInsightRequested;
		[Export ("authenticationInsightRequested")]
		bool AuthenticationInsightRequested { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable merchantAccountID;
		[NullAllowed, Export ("merchantAccountID")]
		string MerchantAccountID { get; set; }
	}

	// @interface BTCardClient : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCard12BTCardClient")]
	[DisableDefaultCtor]
	interface BTCardClient
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BTAPIClient apiClient);

#if STARTUP_CRASH_BRAINTREE_CARD
		// -(void)tokenizeCard:(BTCard * _Nonnull)card completion:(void (^ _Nonnull)(BTCardNonce * _Nullable, NSError * _Nullable))completion;
		[Export ("tokenizeCard:completion:")]
		void TokenizeCard (BTCard card, Action<BTCardNonce, NSError> completion);
#endif
		
	}
	
	// @interface BTCardNonce : BTPaymentMethodNonce
#if STARTUP_CRASH_BRAINTREE_CARD	
	[BaseType (typeof(BTPaymentMethodNonce), Name = "_TtC13BraintreeCard11BTCardNonce")]
#endif	
	interface BTCardNonce
	{
		// @property (nonatomic) enum BTCardNetwork cardNetwork;
		[Export ("cardNetwork", ArgumentSemantic.Assign)]
		BTCardNetwork CardNetwork { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable expirationMonth;
		[NullAllowed, Export ("expirationMonth")]
		string ExpirationMonth { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable expirationYear;
		[NullAllowed, Export ("expirationYear")]
		string ExpirationYear { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cardholderName;
		[NullAllowed, Export ("cardholderName")]
		string CardholderName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lastTwo;
		[NullAllowed, Export ("lastTwo")]
		string LastTwo { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lastFour;
		[NullAllowed, Export ("lastFour")]
		string LastFour { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable bin;
		[NullAllowed, Export ("bin")]
		string Bin { get; set; }

		// @property (nonatomic, strong) BTBinData * _Nonnull binData;
		[Export ("binData", ArgumentSemantic.Strong)]
		BTBinData BinData { get; set; }

		// @property (nonatomic, strong) BTThreeDSecureInfo * _Nonnull threeDSecureInfo;
		[Export ("threeDSecureInfo", ArgumentSemantic.Strong)]
		BTThreeDSecureInfo ThreeDSecureInfo { get; set; }

		// @property (nonatomic, strong) BTAuthenticationInsight * _Nullable authenticationInsight;
		[NullAllowed, Export ("authenticationInsight", ArgumentSemantic.Strong)]
		BTAuthenticationInsight AuthenticationInsight { get; set; }

		// -(instancetype _Nonnull)initWithJSON:(BTJSON * _Nullable)cardJSON;
		[Export ("initWithJSON:")]
		NativeHandle Constructor ([NullAllowed] BTJSON cardJSON);
	}
	
	// @interface BTCardRequest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCard13BTCardRequest")]
	[DisableDefaultCtor]
	interface BTCardRequest
	{
		// @property (nonatomic, strong) BTCard * _Nonnull card;
		[Export ("card", ArgumentSemantic.Strong)]
		BTCard Card { get; set; }

		// -(instancetype _Nonnull)initWithCard:(BTCard * _Nonnull)card __attribute__((objc_designated_initializer));
		[Export ("initWithCard:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BTCard card);
	}

	// @interface BTThreeDSecureInfo : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13BraintreeCard18BTThreeDSecureInfo")]
	[DisableDefaultCtor]
	interface BTThreeDSecureInfo
	{
		// @property (copy, nonatomic) NSString * _Nullable acsTransactionID;
		[NullAllowed, Export ("acsTransactionID")]
		string AcsTransactionID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable authenticationTransactionStatus;
		[NullAllowed, Export ("authenticationTransactionStatus")]
		string AuthenticationTransactionStatus { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable authenticationTransactionStatusReason;
		[NullAllowed, Export ("authenticationTransactionStatusReason")]
		string AuthenticationTransactionStatusReason { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cavv;
		[NullAllowed, Export ("cavv")]
		string Cavv { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable dsTransactionID;
		[NullAllowed, Export ("dsTransactionID")]
		string DsTransactionID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable eciFlag;
		[NullAllowed, Export ("eciFlag")]
		string EciFlag { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable enrolled;
		[NullAllowed, Export ("enrolled")]
		string Enrolled { get; set; }

		// @property (nonatomic) BOOL liabilityShifted;
		[Export ("liabilityShifted")]
		bool LiabilityShifted { get; set; }

		// @property (nonatomic) BOOL liabilityShiftPossible;
		[Export ("liabilityShiftPossible")]
		bool LiabilityShiftPossible { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lookupTransactionStatus;
		[NullAllowed, Export ("lookupTransactionStatus")]
		string LookupTransactionStatus { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lookupTransactionStatusReason;
		[NullAllowed, Export ("lookupTransactionStatusReason")]
		string LookupTransactionStatusReason { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable paresStatus;
		[NullAllowed, Export ("paresStatus")]
		string ParesStatus { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable status;
		[NullAllowed, Export ("status")]
		string Status { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable threeDSecureAuthenticationID;
		[NullAllowed, Export ("threeDSecureAuthenticationID")]
		string ThreeDSecureAuthenticationID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable threeDSecureServerTransactionID;
		[NullAllowed, Export ("threeDSecureServerTransactionID")]
		string ThreeDSecureServerTransactionID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable threeDSecureVersion;
		[NullAllowed, Export ("threeDSecureVersion")]
		string ThreeDSecureVersion { get; set; }

		// @property (nonatomic) BOOL wasVerified;
		[Export ("wasVerified")]
		bool WasVerified { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable xid;
		[NullAllowed, Export ("xid")]
		string Xid { get; set; }
	}
	
	
	#endregion	
	
	#region BRAINTREE DATA COLLECTOR
	
	
	//========================================================================
	//
	// BRAINTREE DATA COLLECTOR 
	//
	//========================================================================
	
	// @interface BTDataCollector : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC22BraintreeDataCollector15BTDataCollector")]
	[DisableDefaultCtor]
	interface BTDataCollector
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BTAPIClient apiClient);

		// -(NSString * _Nonnull)clientMetadataID:(NSString * _Nullable)pairingID __attribute__((warn_unused_result("")));
		[Export ("clientMetadataID:")]
		string ClientMetadataID ([NullAllowed] string pairingID);

		// -(void)collectDeviceData:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completion;
		[Export ("collectDeviceData:")]
		void CollectDeviceData (Action<NSString, NSError> completion);
	}
	
	
	#endregion
	
	#region BRAINTREE PAYPAL	
	//========================================================================
	//
	// BRAINTREE PAYPAL 
	//
	//========================================================================

	// @interface BTPayPalAccountNonce : BTPaymentMethodNonce
#if STARTUP_CRASH_BRAINTREE_PAYPAL
	[BaseType (typeof(BTPaymentMethodNonce), Name = "_TtC15BraintreePayPal20BTPayPalAccountNonce")]
#endif	
	interface BTPayPalAccountNonce
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName")]
		string LastName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export ("phone")]
		string Phone { get; }

		// @property (readonly, nonatomic, strong) BTPostalAddress * _Nullable billingAddress;
		[NullAllowed, Export ("billingAddress", ArgumentSemantic.Strong)]
		BTPostalAddress BillingAddress { get; }

		// @property (readonly, nonatomic, strong) BTPostalAddress * _Nullable shippingAddress;
		[NullAllowed, Export ("shippingAddress", ArgumentSemantic.Strong)]
		BTPostalAddress ShippingAddress { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable clientMetadataID;
		[NullAllowed, Export ("clientMetadataID")]
		string ClientMetadataID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable payerID;
		[NullAllowed, Export ("payerID")]
		string PayerID { get; }

		// @property (readonly, nonatomic, strong) BTPayPalCreditFinancing * _Nullable creditFinancing;
		[NullAllowed, Export ("creditFinancing", ArgumentSemantic.Strong)]
		BTPayPalCreditFinancing CreditFinancing { get; }
	}
	
	// @interface BTPayPalRequest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC15BraintreePayPal15BTPayPalRequest")]
	[DisableDefaultCtor]
	interface BTPayPalRequest
	{
		// @property (nonatomic) BOOL isShippingAddressRequired;
		[Export ("isShippingAddressRequired")]
		bool IsShippingAddressRequired { get; set; }

		// @property (nonatomic) BOOL isShippingAddressEditable;
		[Export ("isShippingAddressEditable")]
		bool IsShippingAddressEditable { get; set; }

		// @property (nonatomic) enum BTPayPalLocaleCode localeCode;
		[Export ("localeCode", ArgumentSemantic.Assign)]
		BTPayPalLocaleCode LocaleCode { get; set; }

		// @property (nonatomic, strong) BTPostalAddress * _Nullable shippingAddressOverride;
		[NullAllowed, Export ("shippingAddressOverride", ArgumentSemantic.Strong)]
		BTPostalAddress ShippingAddressOverride { get; set; }

		// @property (nonatomic) enum BTPayPalRequestLandingPageType landingPageType;
		[Export ("landingPageType", ArgumentSemantic.Assign)]
		BTPayPalRequestLandingPageType LandingPageType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable merchantAccountID;
		[NullAllowed, Export ("merchantAccountID")]
		string MerchantAccountID { get; set; }

		// @property (copy, nonatomic) NSArray<BTPayPalLineItem *> * _Nullable lineItems;
		[NullAllowed, Export ("lineItems", ArgumentSemantic.Copy)]
		BTPayPalLineItem[] LineItems { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable billingAgreementDescription;
		[NullAllowed, Export ("billingAgreementDescription")]
		string BillingAgreementDescription { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable riskCorrelationID;
		[NullAllowed, Export ("riskCorrelationID")]
		string RiskCorrelationID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull hermesPath;
		[Export ("hermesPath")]
		string HermesPath { get; set; }

		// @property (nonatomic) enum BTPayPalPaymentType paymentType;
		[Export ("paymentType", ArgumentSemantic.Assign)]
		BTPayPalPaymentType PaymentType { get; set; }

		// -(NSDictionary<NSString *,id> * _Nonnull)parametersWith:(BTConfiguration * _Nonnull)configuration universalLink:(NSURL * _Nullable)universalLink isPayPalAppInstalled:(BOOL)isPayPalAppInstalled __attribute__((warn_unused_result("")));
		[Export ("parametersWith:universalLink:isPayPalAppInstalled:")]
		NSDictionary<NSString, NSObject> ParametersWith (BTConfiguration configuration, [NullAllowed] NSUrl universalLink, bool isPayPalAppInstalled);
	}
	
	// @interface BTPayPalCheckoutRequest : BTPayPalRequest
	[BaseType (typeof(BTPayPalRequest), Name = "_TtC15BraintreePayPal23BTPayPalCheckoutRequest")]
	interface BTPayPalCheckoutRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull amount;
		[Export ("amount")]
		string Amount { get; set; }

		// @property (nonatomic) enum BTPayPalRequestIntent intent;
		[Export ("intent", ArgumentSemantic.Assign)]
		BTPayPalRequestIntent Intent { get; set; }

		// @property (nonatomic) enum BTPayPalRequestUserAction userAction;
		[Export ("userAction", ArgumentSemantic.Assign)]
		BTPayPalRequestUserAction UserAction { get; set; }

		// @property (nonatomic) BOOL offerPayLater;
		[Export ("offerPayLater")]
		bool OfferPayLater { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currencyCode;
		[NullAllowed, Export ("currencyCode")]
		string CurrencyCode { get; set; }

		// @property (nonatomic) BOOL requestBillingAgreement;
		[Export ("requestBillingAgreement")]
		bool RequestBillingAgreement { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable userAuthenticationEmail;
		[NullAllowed, Export ("userAuthenticationEmail")]
		string UserAuthenticationEmail { get; set; }

		// -(instancetype _Nonnull)initWithAmount:(NSString * _Nonnull)amount intent:(enum BTPayPalRequestIntent)intent userAction:(enum BTPayPalRequestUserAction)userAction offerPayLater:(BOOL)offerPayLater currencyCode:(NSString * _Nullable)currencyCode requestBillingAgreement:(BOOL)requestBillingAgreement __attribute__((objc_designated_initializer));
		[Export ("initWithAmount:intent:userAction:offerPayLater:currencyCode:requestBillingAgreement:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string amount, BTPayPalRequestIntent intent, BTPayPalRequestUserAction userAction, bool offerPayLater, [NullAllowed] string currencyCode, bool requestBillingAgreement);

		// -(NSDictionary<NSString *,id> * _Nonnull)parametersWith:(BTConfiguration * _Nonnull)configuration universalLink:(NSURL * _Nullable)universalLink isPayPalAppInstalled:(BOOL)isPayPalAppInstalled __attribute__((warn_unused_result("")));
		[Export ("parametersWith:universalLink:isPayPalAppInstalled:")]
		NSDictionary<NSString, NSObject> ParametersWith (BTConfiguration configuration, [NullAllowed] NSUrl universalLink, bool isPayPalAppInstalled);
	}
	
#if STARTUP_CRASH_BRAINTREE_PAYPAL
	// @interface BTPayPalClient : BTWebAuthenticationSessionClient
	[BaseType (typeof(BTWebAuthenticationSessionClient), Name = "_TtC15BraintreePayPal14BTPayPalClient")]
	[DisableDefaultCtor]
	interface BTPayPalClient
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BTAPIClient apiClient);

		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient universalLink:(NSURL * _Nonnull)universalLink;
		[Export ("initWithAPIClient:universalLink:")]
		NativeHandle Constructor (BTAPIClient apiClient, NSUrl universalLink);

		// -(void)tokenizeWithVaultRequest:(BTPayPalVaultRequest * _Nonnull)request completion:(void (^ _Nonnull)(BTPayPalAccountNonce * _Nullable, NSError * _Nullable))completion;
		[Export ("tokenizeWithVaultRequest:completion:")]
		void TokenizeWithVaultRequest (BTPayPalVaultRequest request, Action<BTPayPalAccountNonce, NSError> completion);

		// -(void)tokenizeWithCheckoutRequest:(BTPayPalCheckoutRequest * _Nonnull)request completion:(void (^ _Nonnull)(BTPayPalAccountNonce * _Nullable, NSError * _Nullable))completion;
		[Export ("tokenizeWithCheckoutRequest:completion:")]
		void TokenizeWithCheckoutRequest (BTPayPalCheckoutRequest request, Action<BTPayPalAccountNonce, NSError> completion);
	}
#endif
	
	
	// @interface BTPayPalCreditFinancing : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC15BraintreePayPal23BTPayPalCreditFinancing")]
	[DisableDefaultCtor]
	interface BTPayPalCreditFinancing
	{
		// @property (readonly, nonatomic) BOOL cardAmountImmutable;
		[Export ("cardAmountImmutable")]
		bool CardAmountImmutable { get; }

		// @property (readonly, nonatomic, strong) BTPayPalCreditFinancingAmount * _Nullable monthlyPayment;
		[NullAllowed, Export ("monthlyPayment", ArgumentSemantic.Strong)]
		BTPayPalCreditFinancingAmount MonthlyPayment { get; }

		// @property (readonly, nonatomic) BOOL payerAcceptance;
		[Export ("payerAcceptance")]
		bool PayerAcceptance { get; }

		// @property (readonly, nonatomic) NSInteger term;
		[Export ("term")]
		nint Term { get; }

		// @property (readonly, nonatomic, strong) BTPayPalCreditFinancingAmount * _Nullable totalCost;
		[NullAllowed, Export ("totalCost", ArgumentSemantic.Strong)]
		BTPayPalCreditFinancingAmount TotalCost { get; }

		// @property (readonly, nonatomic, strong) BTPayPalCreditFinancingAmount * _Nullable totalInterest;
		[NullAllowed, Export ("totalInterest", ArgumentSemantic.Strong)]
		BTPayPalCreditFinancingAmount TotalInterest { get; }
	}

	// @interface BTPayPalCreditFinancingAmount : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC15BraintreePayPal29BTPayPalCreditFinancingAmount")]
	[DisableDefaultCtor]
	interface BTPayPalCreditFinancingAmount
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull currency;
		[Export ("currency")]
		string Currency { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull value;
		[Export ("value")]
		string Value { get; }
	}
	
	// @interface BTPayPalLineItem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC15BraintreePayPal16BTPayPalLineItem")]
	[DisableDefaultCtor]
	interface BTPayPalLineItem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull quantity;
		[Export ("quantity")]
		string Quantity { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull unitAmount;
		[Export ("unitAmount")]
		string UnitAmount { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum BTPayPalLineItemKind kind;
		[Export ("kind")]
		BTPayPalLineItemKind Kind { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable unitTaxAmount;
		[NullAllowed, Export ("unitTaxAmount")]
		string UnitTaxAmount { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable itemDescription;
		[NullAllowed, Export ("itemDescription")]
		string ItemDescription { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed, Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable productCode;
		[NullAllowed, Export ("productCode")]
		string ProductCode { get; }

		// @property (copy, nonatomic) NSURL * _Nullable imageURL;
		[NullAllowed, Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageURL { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable upcCode;
		[NullAllowed, Export ("upcCode")]
		string UpcCode { get; set; }

		// @property (nonatomic) enum BTPayPalLineItemUPCType upcType;
		[Export ("upcType", ArgumentSemantic.Assign)]
		BTPayPalLineItemUPCType UpcType { get; set; }

		// -(instancetype _Nonnull)initWithQuantity:(NSString * _Nonnull)quantity unitAmount:(NSString * _Nonnull)unitAmount name:(NSString * _Nonnull)name kind:(enum BTPayPalLineItemKind)kind __attribute__((objc_designated_initializer));
		[Export ("initWithQuantity:unitAmount:name:kind:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string quantity, string unitAmount, string name, BTPayPalLineItemKind kind);
	}
	
	// @interface BTPayPalVaultBaseRequest : BTPayPalRequest
	[BaseType (typeof(BTPayPalRequest), Name = "_TtC15BraintreePayPal24BTPayPalVaultBaseRequest")]
	interface BTPayPalVaultBaseRequest
	{
		// @property (nonatomic) BOOL offerCredit;
		[Export ("offerCredit")]
		bool OfferCredit { get; set; }

		// -(instancetype _Nonnull)initWithOfferCredit:(BOOL)offerCredit __attribute__((objc_designated_initializer));
		[Export ("initWithOfferCredit:")]
		[DesignatedInitializer]
		NativeHandle Constructor (bool offerCredit);

		// -(NSDictionary<NSString *,id> * _Nonnull)parametersWith:(BTConfiguration * _Nonnull)configuration universalLink:(NSURL * _Nullable)universalLink isPayPalAppInstalled:(BOOL)isPayPalAppInstalled __attribute__((warn_unused_result("")));
		[Export ("parametersWith:universalLink:isPayPalAppInstalled:")]
		NSDictionary<NSString, NSObject> ParametersWith (BTConfiguration configuration, [NullAllowed] NSUrl universalLink, bool isPayPalAppInstalled);
	}

	// @interface BTPayPalVaultRequest : BTPayPalVaultBaseRequest
	[BaseType (typeof(BTPayPalVaultBaseRequest), Name = "_TtC15BraintreePayPal20BTPayPalVaultRequest")]
	interface BTPayPalVaultRequest
	{
		// @property (copy, nonatomic) NSString * _Nullable userAuthenticationEmail;
		[NullAllowed, Export ("userAuthenticationEmail")]
		string UserAuthenticationEmail { get; set; }

		// -(instancetype _Nonnull)initWithUserAuthenticationEmail:(NSString * _Nonnull)userAuthenticationEmail enablePayPalAppSwitch:(BOOL)enablePayPalAppSwitch offerCredit:(BOOL)offerCredit;
		[Export ("initWithUserAuthenticationEmail:enablePayPalAppSwitch:offerCredit:")]
		NativeHandle Constructor (string userAuthenticationEmail, bool enablePayPalAppSwitch, bool offerCredit);

		// -(instancetype _Nonnull)initWithOfferCredit:(BOOL)offerCredit userAuthenticationEmail:(NSString * _Nullable)userAuthenticationEmail __attribute__((objc_designated_initializer));
		[Export ("initWithOfferCredit:userAuthenticationEmail:")]
		[DesignatedInitializer]
		NativeHandle Constructor (bool offerCredit, [NullAllowed] string userAuthenticationEmail);

		// -(NSDictionary<NSString *,id> * _Nonnull)parametersWith:(BTConfiguration * _Nonnull)configuration universalLink:(NSURL * _Nullable)universalLink isPayPalAppInstalled:(BOOL)isPayPalAppInstalled __attribute__((warn_unused_result("")));
		[Export ("parametersWith:universalLink:isPayPalAppInstalled:")]
		NSDictionary<NSString, NSObject> ParametersWith (BTConfiguration configuration, [NullAllowed] NSUrl universalLink, bool isPayPalAppInstalled);
	}	
	
	
	#endregion

	#region BRAINTREE VENMO

	
	//========================================================================
	//
	// BRAINTREE VENMO 
	//
	//========================================================================
	
	// @interface BTVenmoAccountNonce : BTPaymentMethodNonce
#if STARTUP_CRASH_BRAINTREE_VENMO
	[BaseType (typeof(BTPaymentMethodNonce), Name = "_TtC14BraintreeVenmo19BTVenmoAccountNonce")]
#endif	
	[DisableDefaultCtor]
	interface BTVenmoAccountNonce
	{
		// @property (copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable externalID;
		[NullAllowed, Export ("externalID")]
		string ExternalID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName")]
		string FirstName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName")]
		string LastName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phoneNumber;
		[NullAllowed, Export ("phoneNumber")]
		string PhoneNumber { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export ("username")]
		string Username { get; set; }

		// @property (nonatomic, strong) BTPostalAddress * _Nullable billingAddress;
		[NullAllowed, Export ("billingAddress", ArgumentSemantic.Strong)]
		BTPostalAddress BillingAddress { get; set; }

		// @property (nonatomic, strong) BTPostalAddress * _Nullable shippingAddress;
		[NullAllowed, Export ("shippingAddress", ArgumentSemantic.Strong)]
		BTPostalAddress ShippingAddress { get; set; }
	}
	
	// @interface BTVenmoClient : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC14BraintreeVenmo13BTVenmoClient")]
	[DisableDefaultCtor]
	interface BTVenmoClient
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BTAPIClient apiClient);

#if STARTUP_CRASH_BRAINTREE_VENMO		
		// -(void)tokenizeWithVenmoRequest:(BTVenmoRequest * _Nonnull)request completion:(void (^ _Nonnull)(BTVenmoAccountNonce * _Nullable, NSError * _Nullable))completion;
		[Export ("tokenizeWithVenmoRequest:completion:")]
		void TokenizeWithVenmoRequest (BTVenmoRequest request, Action<BTVenmoAccountNonce, NSError> completion);
#endif
		// -(BOOL)isVenmoAppInstalled __attribute__((warn_unused_result("")));
		[Export ("isVenmoAppInstalled")]
		//[Verify (MethodToProperty)]
		bool IsVenmoAppInstalled { get; }

		// -(void)openVenmoAppPageInAppStore;
		[Export ("openVenmoAppPageInAppStore")]
		void OpenVenmoAppPageInAppStore ();
	}
	
	// @interface BTVenmoLineItem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC14BraintreeVenmo15BTVenmoLineItem")]
	[DisableDefaultCtor]
	interface BTVenmoLineItem
	{
		// @property (nonatomic) NSInteger quantity;
		[Export ("quantity")]
		nint Quantity { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull unitAmount;
		[Export ("unitAmount")]
		string UnitAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; set; }

		// @property (nonatomic) enum BTVenmoLineItemKind kind;
		[Export ("kind", ArgumentSemantic.Assign)]
		BTVenmoLineItemKind Kind { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable unitTaxAmount;
		[NullAllowed, Export ("unitTaxAmount")]
		string UnitTaxAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable itemDescription;
		[NullAllowed, Export ("itemDescription")]
		string ItemDescription { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable productCode;
		[NullAllowed, Export ("productCode")]
		string ProductCode { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed, Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; set; }

		// -(instancetype _Nonnull)initWithQuantity:(NSInteger)quantity unitAmount:(NSString * _Nonnull)unitAmount name:(NSString * _Nonnull)name kind:(enum BTVenmoLineItemKind)kind __attribute__((objc_designated_initializer));
		[Export ("initWithQuantity:unitAmount:name:kind:")]
		[DesignatedInitializer]
		NativeHandle Constructor (nint quantity, string unitAmount, string name, BTVenmoLineItemKind kind);
	}

	// @interface BTVenmoRequest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC14BraintreeVenmo14BTVenmoRequest")]
	[DisableDefaultCtor]
	interface BTVenmoRequest
	{
		// @property (copy, nonatomic) NSString * _Nullable profileID;
		[NullAllowed, Export ("profileID")]
		string ProfileID { get; set; }

		// @property (nonatomic) BOOL vault;
		[Export ("vault")]
		bool Vault { get; set; }

		// @property (nonatomic) enum BTVenmoPaymentMethodUsage paymentMethodUsage;
		[Export ("paymentMethodUsage", ArgumentSemantic.Assign)]
		BTVenmoPaymentMethodUsage PaymentMethodUsage { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; set; }

		// @property (nonatomic) BOOL collectCustomerBillingAddress;
		[Export ("collectCustomerBillingAddress")]
		bool CollectCustomerBillingAddress { get; set; }

		// @property (nonatomic) BOOL collectCustomerShippingAddress;
		[Export ("collectCustomerShippingAddress")]
		bool CollectCustomerShippingAddress { get; set; }

		// @property (nonatomic) BOOL isFinalAmount;
		[Export ("isFinalAmount")]
		bool IsFinalAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable subTotalAmount;
		[NullAllowed, Export ("subTotalAmount")]
		string SubTotalAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable discountAmount;
		[NullAllowed, Export ("discountAmount")]
		string DiscountAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable taxAmount;
		[NullAllowed, Export ("taxAmount")]
		string TaxAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable shippingAmount;
		[NullAllowed, Export ("shippingAmount")]
		string ShippingAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable totalAmount;
		[NullAllowed, Export ("totalAmount")]
		string TotalAmount { get; set; }

		// @property (copy, nonatomic) NSArray<BTVenmoLineItem *> * _Nullable lineItems;
		[NullAllowed, Export ("lineItems", ArgumentSemantic.Copy)]
		BTVenmoLineItem[] LineItems { get; set; }

		// @property (nonatomic) BOOL fallbackToWeb;
		[Export ("fallbackToWeb")]
		bool FallbackToWeb { get; set; }

		// -(instancetype _Nonnull)initWithPaymentMethodUsage:(enum BTVenmoPaymentMethodUsage)paymentMethodUsage __attribute__((objc_designated_initializer));
		[Export ("initWithPaymentMethodUsage:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BTVenmoPaymentMethodUsage paymentMethodUsage);
	}
	
	#endregion
}