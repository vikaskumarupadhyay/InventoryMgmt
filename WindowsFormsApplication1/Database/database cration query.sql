USE [master]
GO
/****** Object:  Database [SalesMaster]    Script Date: 8/2/2017 3:07:22 PM ******/
CREATE DATABASE [SalesMaster]
GO 
USE [SalesMaster]
GO
/****** Object:  Table [dbo].[AllPaymentDetailes]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AllPaymentDetailes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Invoiceid] [int] NULL,
	[CashAmount] [decimal](18, 2) NULL,
	[CreditDebitAmount] [decimal](18, 2) NULL,
	[CreditDebitBankName] [varchar](200) NULL,
	[CardNumber] [varchar](200) NULL,
	[CardType] [varchar](200) NULL,
	[ChequeAmonut] [decimal](18, 2) NULL,
	[ChequeBankName] [varchar](200) NULL,
	[ChequeNumber] [varchar](200) NULL,
	[ChequeDate] [date] NULL,
	[EWalletAmount] [decimal](18, 2) NULL,
	[EWalletCompanyname] [varchar](200) NULL,
	[TransactionNumber] [varchar](200) NULL,
	[TransactionDate] [date] NULL,
	[CoupanAmount] [decimal](18, 2) NULL,
	[CoupanCompanyname] [varchar](200) NULL,
	[InvoiceAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[BalanceAmount] [decimal](18, 2) NULL,
	[ReturnAmount] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[PaymentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChequePement]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChequePement](
	[Chequeid] [int] IDENTITY(1,1) NOT NULL,
	[PaymentId] [int] NULL,
	[ChequeDate] [datetime] NULL,
	[BankName] [varchar](200) NULL,
	[ChequeNo] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Chequeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompnayDetails]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CompnayDetails](
	[CompnayId] [varchar](200) NOT NULL,
	[OnerName] [varchar](200) NULL,
	[Name] [varchar](1000) NULL,
	[Address] [varchar](1000) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[Zip] [varchar](100) NULL,
	[Country] [varchar](50) NULL,
	[Email] [varchar](250) NULL,
	[WebAddress] [varchar](50) NULL,
	[Phone] [varchar](15) NULL,
	[Mobile] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[PANNO] [varchar](200) NULL,
	[Description] [varchar](500) NULL,
	[GSTNo] [varchar](100) NULL,
	[Isactive] [bit] NULL,
	[RagistrationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CompnayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompnayTex]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CompnayTex](
	[TexId] [varchar](100) NOT NULL,
	[TexName] [varchar](200) NULL,
	[TexAmount] [decimal](18, 2) NULL,
	[TexDescription] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[TexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerAccountDetails]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerAccountDetails](
	[id] [varchar](100) NULL,
	[CustId] [varchar](100) NULL,
	[CustOpeningBalance] [varchar](100) NULL,
	[CustCurrentBalance] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[custId] [varchar](100) NOT NULL,
	[CustName] [varchar](1000) NULL,
	[CustCompName] [varchar](1000) NULL,
	[CustAddress] [varchar](1000) NULL,
	[CustCity] [varchar](100) NULL,
	[CustState] [varchar](100) NULL,
	[CustZip] [varchar](100) NULL,
	[CustCountry] [varchar](50) NULL,
	[CustEmail] [varchar](250) NULL,
	[CustWebAddress] [varchar](50) NULL,
	[CustPhone] [varchar](15) NULL,
	[CustMobile] [varchar](15) NULL,
	[CustFax] [varchar](15) NULL,
	[CustDesc] [varchar](500) NULL,
	[CustPanNo] [varchar](200) NULL,
	[CustGstNo] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[custId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerOrderDelivery]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CustomerOrderDelivery](
	[Deliveryid] [int] IDENTITY(1,1) NOT NULL,
	[Orderid] [int] NULL,
	[status] [bit] NULL,
	[DeliveryDate] [datetime] NULL,
	[RefNo] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Deliveryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[customerorderdescriptions]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[customerorderdescriptions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderid] [int] NULL,
	[ItemId] [varchar](100) NULL,
	[price] [decimal](18, 2) NULL,
	[quantity] [int] NULL,
	[totalammount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerOrderInvoice]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrderInvoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[Deliveryid] [int] NULL,
	[Orderid] [int] NULL,
	[InvoiceDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemDetails]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemDetails](
	[ItemId] [varchar](100) NOT NULL,
	[ItemName] [varchar](1000) NULL,
	[ItemCompName] [varchar](1000) NULL,
	[ItemDesc] [varchar](500) NULL,
	[groupid] [varchar](10) NULL,
	[Unitid] [varchar](10) NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[ItemDetails] ADD [BarCode] [varchar](200) NULL
PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemGroup]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemGroup](
	[groupID] [varchar](10) NOT NULL,
	[groupName] [varchar](1000) NULL,
	[GroupDesc] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[groupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemPriceDetail]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemPriceDetail](
	[ItemId] [varchar](100) NULL,
	[purChasePrice] [decimal](18, 2) NULL,
	[SalesPrice] [decimal](18, 2) NULL,
	[MrpPrice] [decimal](18, 2) NULL,
	[Margin] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemQuantityDetail]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemQuantityDetail](
	[ItemId] [varchar](100) NULL,
	[OpeningQuantity] [varchar](100) NULL,
	[CurrentQuantity] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemTaxDetail]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ItemTaxDetail](
	[ItemId] [varchar](100) NULL,
	[HSN] [int] NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemUnitList]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemUnitList](
	[UnitId] [varchar](10) NOT NULL,
	[unitName] [varchar](1000) NULL,
	[unitDesc] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[orderdetails]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[orderdetails](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[custid] [varchar](100) NULL,
	[date] [datetime] NULL,
	[totalammount] [money] NULL,
	[Discount] [float] NULL,
	[Discountamount] [float] NULL,
	[Tax] [float] NULL,
	[Taxamount] [float] NULL,
	[WithautTaxamount] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payment]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[invoiceid] [int] NULL,
	[totalammount] [decimal](18, 0) NULL,
	[payammount] [decimal](18, 0) NULL,
	[Remainingammount] [decimal](18, 0) NULL,
	[paymentmode] [varchar](300) NULL,
	[paymentdate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[salesinvoice]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salesinvoice](
	[invoiceid] [int] IDENTITY(1,1) NOT NULL,
	[Delivaryid] [int] NULL,
	[Orderid] [int] NULL,
	[invoicedate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[invoiceid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[salesOrderDelivery]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[salesOrderDelivery](
	[Delivaryid] [int] IDENTITY(1,1) NOT NULL,
	[Orderid] [int] NULL,
	[status] [bit] NULL,
	[DeliveryDate] [datetime] NULL,
	[RefNo] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Delivaryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesPaymentDetailes]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[SalesPaymentDetailes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Invoiceid] [int] NULL,
	[CashAmount] [decimal](18, 2) NULL,
	[CreditDebitAmount] [decimal](18, 2) NULL,
	[CreditDebitBankName] [varchar](200) NULL,
	[CardNumber] [varchar](200) NULL,
	[CardType] [varchar](200) NULL,
	[ChequeAmonut] [decimal](18, 2) NULL,
	[ChequeBankName] [varchar](200) NULL,
	[ChequeNumber] [varchar](200) NULL,
	[ChequeDate] [date] NULL,
	[EWalletAmount] [decimal](18, 2) NULL,
	[EWalletCompanyname] [varchar](200) NULL,
	[TransactionNumber] [varchar](200) NULL,
	[TransactionDate] [date] NULL,
	[CoupanAmount] [decimal](18, 2) NULL,
	[CoupanCompanyname] [varchar](200) NULL,
	[InvoiceAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[BalanceAmount] [decimal](18, 2) NULL,
	[ReturnAmount] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[ReceiptDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorAccountDetails]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorAccountDetails](
	[id] [varchar](100) NULL,
	[venderId] [varchar](100) NULL,
	[vOpeningBalance] [decimal](18, 2) NULL,
	[vCurrentBalance] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorDetails]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorDetails](
	[venderId] [varchar](100) NOT NULL,
	[vName] [varchar](1000) NULL,
	[vCompName] [varchar](1000) NULL,
	[vAddress] [varchar](1000) NULL,
	[vCity] [varchar](100) NULL,
	[vState] [varchar](100) NULL,
	[vZip] [varchar](100) NULL,
	[vCountry] [varchar](50) NULL,
	[vEmail] [varchar](250) NULL,
	[vWebAddress] [varchar](50) NULL,
	[vPhone] [varchar](15) NULL,
	[vMobile] [varchar](15) NULL,
	[vFax] [varchar](15) NULL,
	[vDesc] [varchar](500) NULL,
	[vPanNo] [varchar](200) NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[VendorDetails] ADD [vGSTNo] [varchar](200) NULL
PRIMARY KEY CLUSTERED 
(
	[venderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorOrderDesc]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorOrderDesc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Orderid] [int] NULL,
	[ItemId] [varchar](100) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorOrderDetails]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorOrderDetails](
	[Orderid] [int] IDENTITY(1,1) NOT NULL,
	[venderId] [varchar](100) NULL,
	[OrderDate] [datetime] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 0) NULL,
	[Vat] [decimal](18, 0) NULL,
	[DisAmount] [decimal](18, 2) NULL,
	[TextTaxAmmount] [decimal](18, 2) NULL,
	[WithoutTexAmount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorPayment]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorPayment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[TotalAmount] [decimal](18, 0) NULL,
	[PayAmount] [decimal](18, 0) NULL,
	[ArrearAmount] [decimal](18, 0) NULL,
	[PaymentMode] [varchar](200) NULL,
	[PaymentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vithautrefrancereceipt]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[vithautrefrancereceipt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CustId] [varchar](100) NULL,
	[Totalammoun] [float] NULL,
	[Balanceammount] [float] NULL,
	[receiptdate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WithoutRefrencePament]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WithoutRefrencePament](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venderId] [varchar](100) NULL,
	[TotalAmount] [decimal](18, 0) NULL,
	[PayAmount] [decimal](18, 0) NULL,
	[ArrearAmount] [decimal](18, 0) NULL,
	[PaymentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[DeliveryGridview]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[DeliveryGridview]
AS
SELECT        dbo.CustomerOrderDelivery.Deliveryid, dbo.CustomerOrderDelivery.DeliveryDate, dbo.CompnayDetails.Name, dbo.CompnayDetails.Address, 
                         dbo.CompnayDetails.City, dbo.CompnayDetails.State, dbo.CompnayDetails.Zip, dbo.CompnayDetails.Country, dbo.CompnayDetails.Email, 
                         dbo.CompnayDetails.WebAddress, dbo.CompnayDetails.Phone, dbo.CompnayDetails.Mobile, dbo.CompnayDetails.Fax, dbo.CompnayDetails.PANNO, dbo.CompnayDetails.GSTNo, dbo.VendorDetails.vName, dbo.VendorDetails.vCompName, dbo.VendorDetails.vAddress, dbo.VendorDetails.vCity, 
                         dbo.VendorDetails.vState, dbo.VendorDetails.vZip, dbo.VendorDetails.vCountry, dbo.VendorDetails.vEmail, dbo.VendorDetails.vWebAddress, 
                         dbo.VendorDetails.vPhone, dbo.VendorDetails.vMobile, dbo.VendorDetails.vFax, dbo.VendorDetails.vPanNo, dbo.VendorDetails.vGstNo, dbo.VendorOrderDetails.TotalPrice, dbo.VendorOrderDetails.Discount, 
                         dbo.VendorOrderDetails.Vat, dbo.VendorOrderDetails.DisAmount, dbo.VendorOrderDetails.TextTaxAmmount, dbo.VendorOrderDetails.WithoutTexAmount, 
                         dbo.VendorOrderDesc.ItemId, dbo.VendorOrderDesc.Price, dbo.VendorOrderDesc.Quantity, dbo.VendorOrderDesc.TotalPrice AS Expr1, dbo.ItemDetails.ItemName, 
                         dbo.ItemPriceDetail.MrpPrice, dbo.ItemPriceDetail.Margin, dbo.VendorDetails.venderId, dbo.ItemDetails.ItemCompName, dbo.VendorOrderDetails.Orderid, 
                         dbo.VendorOrderDetails.OrderDate
FROM            dbo.CustomerOrderDelivery INNER JOIN
                         dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN
                         dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN
                         dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN
                         dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN
                         dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId CROSS JOIN
                         dbo.CompnayDetails


GO
/****** Object:  View [dbo].[purchesDelivery]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[purchesDelivery]
AS
SELECT        dbo.CompnayDetails.Name, dbo.CompnayDetails.Address, dbo.CompnayDetails.City, dbo.CompnayDetails.State, dbo.CompnayDetails.Zip, 
                         dbo.CompnayDetails.Country, dbo.CompnayDetails.Email, dbo.CompnayDetails.WebAddress, dbo.CompnayDetails.Phone, dbo.CompnayDetails.Mobile, 
                         dbo.CustomerOrderDelivery.Deliveryid, dbo.CustomerOrderDelivery.DeliveryDate, dbo.ItemDetails.ItemName, dbo.ItemPriceDetail.MrpPrice, 
                         dbo.VendorOrderDesc.ItemId, dbo.VendorOrderDesc.Price, dbo.VendorOrderDesc.Quantity, dbo.VendorOrderDesc.TotalPrice, dbo.VendorDetails.vName, 
                         dbo.VendorDetails.vCompName, dbo.VendorDetails.vAddress, dbo.VendorDetails.vCity, dbo.VendorDetails.vState, dbo.VendorDetails.vZip, 
                         dbo.VendorDetails.vCountry, dbo.VendorDetails.vEmail, dbo.VendorDetails.vWebAddress, dbo.VendorDetails.vPhone, dbo.VendorDetails.vMobile, 
                         dbo.VendorOrderDetails.TotalPrice AS Expr1, dbo.VendorOrderDetails.DisAmount, dbo.VendorOrderDetails.TextTaxAmmount, 
                         dbo.VendorOrderDetails.WithoutTexAmount, dbo.VendorOrderDesc.Orderid
FROM            dbo.CompnayDetails CROSS JOIN
                         dbo.ItemPriceDetail INNER JOIN
                         dbo.ItemDetails ON dbo.ItemPriceDetail.ItemId = dbo.ItemDetails.ItemId INNER JOIN
                         dbo.VendorOrderDesc ON dbo.ItemDetails.ItemId = dbo.VendorOrderDesc.ItemId INNER JOIN
                         dbo.VendorOrderDetails ON dbo.VendorOrderDesc.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN
                         dbo.CustomerOrderDelivery ON dbo.VendorOrderDetails.Orderid = dbo.CustomerOrderDelivery.Orderid INNER JOIN
                         dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId


GO
/****** Object:  View [dbo].[salesorderdelivaryreport]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[salesorderdelivaryreport]
AS
SELECT        dbo.CompnayDetails.Name, dbo.CompnayDetails.Address, dbo.CompnayDetails.City, dbo.CompnayDetails.State, dbo.CompnayDetails.Zip, 
                         dbo.CompnayDetails.Country, dbo.CompnayDetails.Email, dbo.CompnayDetails.WebAddress, dbo.CompnayDetails.Phone, dbo.CompnayDetails.Mobile, 
                         dbo.CustomerDetails.CustName, dbo.CustomerDetails.CustCompName, dbo.CustomerDetails.CustAddress, dbo.CustomerDetails.CustCity, 
                         dbo.CustomerDetails.CustState, dbo.CustomerDetails.CustZip, dbo.CustomerDetails.CustCountry, dbo.CustomerDetails.CustEmail, 
                         dbo.CustomerDetails.CustWebAddress, dbo.CustomerDetails.CustPhone, dbo.CustomerDetails.CustMobile, dbo.customerorderdescriptions.ItemId, 
                         dbo.customerorderdescriptions.price, dbo.customerorderdescriptions.quantity, 
                         dbo.customerorderdescriptions.totalammount * dbo.orderdetails.Discount / 100 AS [Discount amount], 
                         dbo.customerorderdescriptions.totalammount - dbo.customerorderdescriptions.totalammount / (1 + dbo.orderdetails.Tax / 100) AS [Tax Amount], 
                         dbo.ItemDetails.ItemName, dbo.ItemPriceDetail.MrpPrice, dbo.orderdetails.totalammount AS Expr1, dbo.orderdetails.Discount, dbo.orderdetails.Discountamount, 
                         dbo.orderdetails.Taxamount, dbo.orderdetails.Tax, dbo.orderdetails.WithautTaxamount, dbo.salesOrderDelivery.Delivaryid, dbo.salesOrderDelivery.Orderid, 
                         dbo.salesOrderDelivery.DeliveryDate, dbo.customerorderdescriptions.totalammount
FROM            dbo.salesOrderDelivery INNER JOIN
                         dbo.ItemDetails INNER JOIN
                         dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN
                         dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN
                         dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN
                         dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid CROSS JOIN
                         dbo.CompnayDetails


GO
/****** Object:  View [dbo].[salesorderreport]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[salesorderreport]
AS
SELECT        dbo.CompnayDetails.Name, dbo.CompnayDetails.Address, dbo.CompnayDetails.City, dbo.CompnayDetails.State, dbo.CompnayDetails.Zip, 
                         dbo.CompnayDetails.Country, dbo.CompnayDetails.Email, dbo.CompnayDetails.WebAddress, dbo.CompnayDetails.Phone, dbo.CompnayDetails.Mobile, 
                         dbo.CustomerDetails.CustName, dbo.CustomerDetails.CustCompName, dbo.CustomerDetails.CustAddress, dbo.CustomerDetails.CustCity, 
                         dbo.CustomerDetails.CustState, dbo.CustomerDetails.CustZip, dbo.CustomerDetails.CustCountry, dbo.CustomerDetails.CustEmail, 
                         dbo.CustomerDetails.CustWebAddress, dbo.CustomerDetails.CustPhone, dbo.CustomerDetails.CustMobile, dbo.customerorderdescriptions.orderid, 
                         dbo.customerorderdescriptions.ItemId, dbo.customerorderdescriptions.price, dbo.customerorderdescriptions.quantity, dbo.customerorderdescriptions.totalammount, 
                         dbo.ItemDetails.ItemName, dbo.ItemPriceDetail.MrpPrice, dbo.orderdetails.date, dbo.orderdetails.totalammount AS Expr1, dbo.orderdetails.Discount, 
                         dbo.orderdetails.Discountamount, dbo.orderdetails.Tax, dbo.orderdetails.Taxamount, dbo.orderdetails.WithautTaxamount, dbo.ItemDetails.ItemCompName
FROM            dbo.CompnayDetails CROSS JOIN
                         dbo.ItemDetails INNER JOIN
                         dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN
                         dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN
                         dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN
                         dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId


GO
/****** Object:  View [dbo].[searchsalesdelivary]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[searchsalesdelivary]
AS
SELECT        dbo.CompnayDetails.Name, dbo.CompnayDetails.Address, dbo.CompnayDetails.City, dbo.CompnayDetails.State, dbo.CompnayDetails.Zip, 
                         dbo.CompnayDetails.Country, dbo.CompnayDetails.Email, dbo.CompnayDetails.WebAddress, dbo.CompnayDetails.Phone, dbo.CompnayDetails.Mobile, 
                         dbo.CompnayDetails.Fax, dbo.CompnayDetails.PANNO, dbo.CompnayDetails.GSTNo, dbo.CustomerDetails.CustName, dbo.CustomerDetails.CustCompName, 
                         dbo.CustomerDetails.CustAddress, dbo.CustomerDetails.CustCity, dbo.CustomerDetails.CustState, dbo.CustomerDetails.CustZip, dbo.CustomerDetails.CustCountry, 
                         dbo.CustomerDetails.CustEmail, dbo.CustomerDetails.CustWebAddress, dbo.CustomerDetails.CustPhone, dbo.CustomerDetails.CustMobile, 
                         dbo.CustomerDetails.CustFax, dbo.CustomerDetails.CustPanNo, dbo.CustomerDetails.CustGstNo, dbo.customerorderdescriptions.ItemId, 
                         dbo.customerorderdescriptions.orderid, dbo.customerorderdescriptions.price, dbo.customerorderdescriptions.quantity, dbo.customerorderdescriptions.totalammount, 
                         dbo.ItemDetails.ItemName, dbo.ItemPriceDetail.MrpPrice, dbo.ItemPriceDetail.Margin, dbo.orderdetails.totalammount AS Expr1, dbo.orderdetails.Discount, 
                         dbo.orderdetails.Discountamount, dbo.orderdetails.Tax, dbo.orderdetails.Taxamount, dbo.orderdetails.WithautTaxamount, dbo.salesOrderDelivery.Delivaryid, 
                         dbo.salesOrderDelivery.DeliveryDate, dbo.CustomerDetails.custId, dbo.ItemDetails.ItemCompName
FROM            dbo.salesOrderDelivery INNER JOIN
                         dbo.ItemDetails INNER JOIN
                         dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN
                         dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN
                         dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN
                         dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid CROSS JOIN
                         dbo.CompnayDetails


GO
/****** Object:  View [dbo].[VwPurchesOrderDatils]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VwPurchesOrderDatils]
AS
SELECT        dbo.VendorDetails.vName, dbo.VendorDetails.vCompName, dbo.VendorDetails.vAddress, dbo.VendorDetails.vCity, dbo.VendorDetails.vState, 
                         dbo.VendorDetails.vZip, dbo.VendorDetails.vCountry, dbo.VendorDetails.vEmail, dbo.VendorDetails.vWebAddress, dbo.VendorDetails.vPhone, 
                         dbo.VendorDetails.vMobile, dbo.VendorOrderDetails.venderId, dbo.VendorOrderDetails.OrderDate, dbo.VendorOrderDesc.Orderid, dbo.VendorOrderDesc.ItemId, 
                         dbo.VendorOrderDesc.Price, dbo.VendorOrderDesc.Quantity, dbo.VendorOrderDesc.TotalPrice AS Expr1, dbo.ItemDetails.ItemName, dbo.CompnayDetails.Name, 
                         dbo.CompnayDetails.Address, dbo.CompnayDetails.City, dbo.CompnayDetails.State, dbo.CompnayDetails.Zip, dbo.CompnayDetails.Country, 
                         dbo.CompnayDetails.Email, dbo.CompnayDetails.WebAddress, dbo.CompnayDetails.Phone, dbo.CompnayDetails.Mobile, dbo.VendorOrderDetails.TotalPrice, 
                         dbo.ItemPriceDetail.MrpPrice, dbo.VendorOrderDetails.DisAmount, dbo.VendorOrderDetails.TextTaxAmmount, dbo.VendorOrderDetails.WithoutTexAmount
FROM            dbo.VendorOrderDetails INNER JOIN
                         dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN
                         dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN
                         dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN
                         dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId CROSS JOIN
                         dbo.CompnayDetails


GO
ALTER TABLE [dbo].[AllPaymentDetailes]  WITH CHECK ADD FOREIGN KEY([Invoiceid])
REFERENCES [dbo].[CustomerOrderDelivery] ([Deliveryid])
GO
ALTER TABLE [dbo].[ChequePement]  WITH CHECK ADD FOREIGN KEY([PaymentId])
REFERENCES [dbo].[VendorPayment] ([PaymentId])
GO
ALTER TABLE [dbo].[CustomerAccountDetails]  WITH CHECK ADD FOREIGN KEY([CustId])
REFERENCES [dbo].[CustomerDetails] ([custId])
GO
ALTER TABLE [dbo].[CustomerOrderDelivery]  WITH CHECK ADD FOREIGN KEY([Orderid])
REFERENCES [dbo].[VendorOrderDetails] ([Orderid])
GO
ALTER TABLE [dbo].[customerorderdescriptions]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemDetails] ([ItemId])
GO
ALTER TABLE [dbo].[customerorderdescriptions]  WITH CHECK ADD FOREIGN KEY([orderid])
REFERENCES [dbo].[orderdetails] ([orderid])
GO
ALTER TABLE [dbo].[CustomerOrderInvoice]  WITH CHECK ADD FOREIGN KEY([Deliveryid])
REFERENCES [dbo].[CustomerOrderDelivery] ([Deliveryid])
GO
ALTER TABLE [dbo].[CustomerOrderInvoice]  WITH CHECK ADD FOREIGN KEY([Orderid])
REFERENCES [dbo].[VendorOrderDetails] ([Orderid])
GO
ALTER TABLE [dbo].[ItemDetails]  WITH CHECK ADD FOREIGN KEY([groupid])
REFERENCES [dbo].[ItemGroup] ([groupID])
GO
ALTER TABLE [dbo].[ItemDetails]  WITH CHECK ADD FOREIGN KEY([Unitid])
REFERENCES [dbo].[ItemUnitList] ([UnitId])
GO
ALTER TABLE [dbo].[ItemPriceDetail]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemDetails] ([ItemId])
GO
ALTER TABLE [dbo].[ItemQuantityDetail]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemDetails] ([ItemId])
GO
ALTER TABLE [dbo].[ItemTaxDetail]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemDetails] ([ItemId])
GO
ALTER TABLE [dbo].[orderdetails]  WITH CHECK ADD FOREIGN KEY([custid])
REFERENCES [dbo].[CustomerDetails] ([custId])
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD FOREIGN KEY([invoiceid])
REFERENCES [dbo].[salesinvoice] ([invoiceid])
GO
ALTER TABLE [dbo].[salesinvoice]  WITH CHECK ADD FOREIGN KEY([Delivaryid])
REFERENCES [dbo].[salesOrderDelivery] ([Delivaryid])
GO
ALTER TABLE [dbo].[salesinvoice]  WITH CHECK ADD FOREIGN KEY([Orderid])
REFERENCES [dbo].[orderdetails] ([orderid])
GO
ALTER TABLE [dbo].[salesOrderDelivery]  WITH CHECK ADD FOREIGN KEY([Orderid])
REFERENCES [dbo].[orderdetails] ([orderid])
GO
ALTER TABLE [dbo].[SalesPaymentDetailes]  WITH CHECK ADD FOREIGN KEY([Invoiceid])
REFERENCES [dbo].[salesOrderDelivery] ([Delivaryid])
GO
ALTER TABLE [dbo].[VendorAccountDetails]  WITH CHECK ADD FOREIGN KEY([venderId])
REFERENCES [dbo].[VendorDetails] ([venderId])
GO
ALTER TABLE [dbo].[VendorOrderDesc]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemDetails] ([ItemId])
GO
ALTER TABLE [dbo].[VendorOrderDesc]  WITH CHECK ADD FOREIGN KEY([Orderid])
REFERENCES [dbo].[VendorOrderDetails] ([Orderid])
GO
ALTER TABLE [dbo].[VendorOrderDetails]  WITH CHECK ADD FOREIGN KEY([venderId])
REFERENCES [dbo].[VendorDetails] ([venderId])
GO
ALTER TABLE [dbo].[VendorPayment]  WITH CHECK ADD FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[CustomerOrderInvoice] ([InvoiceId])
GO
ALTER TABLE [dbo].[vithautrefrancereceipt]  WITH CHECK ADD FOREIGN KEY([CustId])
REFERENCES [dbo].[CustomerDetails] ([custId])
GO
ALTER TABLE [dbo].[WithoutRefrencePament]  WITH CHECK ADD FOREIGN KEY([venderId])
REFERENCES [dbo].[VendorDetails] ([venderId])
GO
/****** Object:  StoredProcedure [dbo].[GETALLDATAVENDER]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GETALLDATAVENDER]
AS
BEGIN

select  vd.venderId as [Vender Id ],vd.vName AS Name ,vd.vCompName AS [Compnay Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN NO],vd.vGSTNo as [GST NO],vd.vDesc AS Description,vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID

END
GO
/****** Object:  StoredProcedure [dbo].[GetUpdateCounterCustomer]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetUpdateCounterCustomer] 
 as
begin
select top 1 (CustID)  from dbo.CustomerDetails order by  Convert(int,SuBString( CustID,2,(len(CustID)-1))) desc 
end

GO
/****** Object:  StoredProcedure [dbo].[GetUpdateCounterGROUP]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetUpdateCounterGROUP] 
 as
begin
select top 1 (groupID)  from dbo.ItemGroup order by  Convert(int,SuBString( groupID,2,(len(groupID)-1))) desc 
end

GO
/****** Object:  StoredProcedure [dbo].[GetUpdateCounterItem]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetUpdateCounterItem] 
 as
begin
select top 1 (ItemID)  from dbo.ItemDetails order by  Convert(int,SuBString( ItemID,2,(len(ItemID)-1))) desc 
end

GO
/****** Object:  StoredProcedure [dbo].[GetUpdateCounterTAX]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetUpdateCounterTAX] 
as
begin
select top 1 (TexId)  from dbo.CompnayTex order by  Convert(int,SuBString( TexId,2,(len(TexId)-1))) desc 
end

GO
/****** Object:  StoredProcedure [dbo].[GetUpdateCounterUNIT]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetUpdateCounterUNIT] 
 as
begin
select top 1 (itemID)  from dbo.ItemDetails order by  Convert(int,SuBString( itemID,2,(len(itemID)-1))) desc 
end

GO
/****** Object:  StoredProcedure [dbo].[GetUpdateCounterVender]    Script Date: 8/2/2017 3:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetUpdateCounterVender] 
 as
begin
select top 1 (VenderID)  from dbo.VendorDetails order by  Convert(int,SuBString( venderID,2,(len(venderID)-1))) desc 
end

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[74] 4[1] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CustomerOrderDelivery"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VendorOrderDetails"
            Begin Extent = 
               Top = 6
               Left = 714
               Bottom = 135
               Right = 908
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VendorDetails"
            Begin Extent = 
               Top = 6
               Left = 483
               Bottom = 135
               Right = 676
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VendorOrderDesc"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "ItemDetails"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 267
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemPriceDetail"
            Begin Extent = 
               Top = 138
               Left = 462
               Bottom = 267
               Right = 632
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "CompnayDetails"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right =' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DeliveryGridview'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 445
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DeliveryGridview'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DeliveryGridview'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -104
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CompnayDetails"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "CustomerOrderDelivery"
            Begin Extent = 
               Top = 6
               Left = 254
               Bottom = 135
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemDetails"
            Begin Extent = 
               Top = 6
               Left = 483
               Bottom = 135
               Right = 661
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemPriceDetail"
            Begin Extent = 
               Top = 6
               Left = 699
               Bottom = 135
               Right = 869
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VendorOrderDesc"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "VendorDetails"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 267
               Right = 439
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "VendorOrderDetails"
            Begin Extent = 
               Top = 138
               Left = 477
               Bottom = 267
               Ri' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'purchesDelivery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'ght = 671
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'purchesDelivery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'purchesDelivery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -8
         Left = 0
      End
      Begin Tables = 
         Begin Table = "salesOrderDelivery"
            Begin Extent = 
               Top = 138
               Left = 475
               Bottom = 267
               Right = 645
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemDetails"
            Begin Extent = 
               Top = 6
               Left = 729
               Bottom = 135
               Right = 907
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "customerorderdescriptions"
            Begin Extent = 
               Top = 6
               Left = 521
               Bottom = 135
               Right = 691
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "ItemPriceDetail"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "orderdetails"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 267
               Right = 437
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "CustomerDetails"
            Begin Extent = 
               Top = 6
               Left = 275
               Bottom = 135
               Right = 483
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "CompnayDetails"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               R' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'salesorderdelivaryreport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'ight = 237
            End
            DisplayFlags = 280
            TopColumn = 9
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'salesorderdelivaryreport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'salesorderdelivaryreport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CompnayDetails"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "ItemDetails"
            Begin Extent = 
               Top = 6
               Left = 729
               Bottom = 135
               Right = 907
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "customerorderdescriptions"
            Begin Extent = 
               Top = 6
               Left = 521
               Bottom = 135
               Right = 691
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemPriceDetail"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "orderdetails"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 267
               Right = 437
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "CustomerDetails"
            Begin Extent = 
               Top = 6
               Left = 275
               Bottom = 135
               Right = 483
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidth' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'salesorderreport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N's = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'salesorderreport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'salesorderreport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[52] 4[10] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "salesOrderDelivery"
            Begin Extent = 
               Top = 138
               Left = 475
               Bottom = 267
               Right = 645
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemDetails"
            Begin Extent = 
               Top = 6
               Left = 729
               Bottom = 135
               Right = 907
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "customerorderdescriptions"
            Begin Extent = 
               Top = 6
               Left = 521
               Bottom = 135
               Right = 691
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "ItemPriceDetail"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "orderdetails"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 267
               Right = 437
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "CustomerDetails"
            Begin Extent = 
               Top = 6
               Left = 275
               Bottom = 135
               Right = 483
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CompnayDetails"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Rig' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'searchsalesdelivary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'ht = 237
            End
            DisplayFlags = 280
            TopColumn = 19
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'searchsalesdelivary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'searchsalesdelivary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -22
      End
      Begin Tables = 
         Begin Table = "VendorOrderDetails"
            Begin Extent = 
               Top = 0
               Left = 228
               Bottom = 129
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "VendorDetails"
            Begin Extent = 
               Top = 0
               Left = 22
               Bottom = 129
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VendorOrderDesc"
            Begin Extent = 
               Top = 0
               Left = 448
               Bottom = 129
               Right = 618
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "ItemDetails"
            Begin Extent = 
               Top = 2
               Left = 628
               Bottom = 131
               Right = 806
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemPriceDetail"
            Begin Extent = 
               Top = 132
               Left = 275
               Bottom = 261
               Right = 445
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CompnayDetails"
            Begin Extent = 
               Top = 132
               Left = 38
               Bottom = 261
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 8
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwPurchesOrderDatils'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwPurchesOrderDatils'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwPurchesOrderDatils'
GO
USE [master]
GO
ALTER DATABASE [SalesMaster] SET  READ_WRITE 
GO
