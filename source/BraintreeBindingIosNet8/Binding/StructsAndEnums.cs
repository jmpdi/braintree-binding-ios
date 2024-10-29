using ObjCRuntime;

namespace Braintree
{
	[Native]
	public enum BTAPIClientHTTPService : long
	{
		Gateway = 0,
		GraphQLAPI = 1,
		PayPalAPI = 2
	}

	[Native]
	public enum BTCardNetwork : long
	{
		Unknown = 0,
		Amex = 1,
		DinersClub = 2,
		Discover = 3,
		MasterCard = 4,
		Visa = 5,
		Jcb = 6,
		Laser = 7,
		Maestro = 8,
		UnionPay = 9,
		Hiper = 10,
		Hipercard = 11,
		Solo = 12,
		Switch = 13,
		UkMaestro = 14
	}

	[Native]
	public enum BTClientMetadataIntegration : long
	{
		Custom = 0,
		DropIn = 1
	}

	[Native]
	public enum BTClientMetadataSource : long
	{
		Unknown = 0,
		PayPalApp = 1,
		PayPalBrowser = 2,
		VenmoApp = 3,
		Form = 4
	}	
	
	[Native]
	public enum BTPayPalLineItemKind : long
	{
		Debit = 0,
		Credit = 1
	}

	[Native]
	public enum BTPayPalLineItemUPCType : long
	{
		None = 0,
		UpcA = 1,
		UpcB = 2,
		UpcC = 3,
		UpcD = 4,
		UpcE = 5,
		Upc2 = 6,
		Upc5 = 7
	}

	[Native]
	public enum BTPayPalLocaleCode : long
	{
		None = 0,
		Da_DK = 1,
		De_DE = 2,
		En_AU = 3,
		En_GB = 4,
		En_US = 5,
		Es_ES = 6,
		Es_XC = 7,
		Fr_CA = 8,
		Fr_FR = 9,
		Fr_XC = 10,
		Id_ID = 11,
		It_IT = 12,
		Ja_JP = 13,
		Ko_KR = 14,
		Nl_NL = 15,
		No_NO = 16,
		Pl_PL = 17,
		Pt_BR = 18,
		Pt_PT = 19,
		Ru_RU = 20,
		Sv_SE = 21,
		Th_TH = 22,
		Tr_TR = 23,
		Zh_CN = 24,
		Zh_HK = 25,
		Zh_TW = 26,
		Zh_XC = 27
	}

	[Native]
	public enum BTPayPalPaymentType : long
	{
		Checkout = 0,
		Vault = 1
	}

	[Native]
	public enum BTPayPalRequestIntent : long
	{
		Authorize = 0,
		Sale = 1,
		Order = 2
	}

	[Native]
	public enum BTPayPalRequestLandingPageType : long
	{
		None = 0,
		Login = 1,
		Billing = 2
	}

	[Native]
	public enum BTPayPalRequestUserAction : long
	{
		None = 0,
		PayNow = 1
	}	
	
	[Native]
	public enum BTVenmoLineItemKind : long
	{
		Debit = 0,
		Credit = 1
	}

	[Native]
	public enum BTVenmoPaymentMethodUsage : long
	{
		MultiUse = 0,
		SingleUse = 1
	}
	
}