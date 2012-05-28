--SQL Server 2005 upgrade instructions from nopCommerce 1.10 to 1.11


-- new tables
if not exists (select 1 from sysobjects where id = object_id(N'[dbo].[Nop_QueuedEmail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [dbo].[Nop_QueuedEmail](
		[QueuedEmailID] [int] IDENTITY(1,1) NOT NULL,
		[Priority] [int] NOT NULL,
		[From] [nvarchar](500) NOT NULL,
		[FromName] [nvarchar](500) NOT NULL,
		[To] [nvarchar](500) NOT NULL,
		[ToName] [nvarchar](500) NOT NULL,
		[Cc] [nvarchar](500) NOT NULL,
		[Bcc] [nvarchar](500) NOT NULL,
		[Subject] [nvarchar](500) NOT NULL,
		[Body] [nvarchar](max) NOT NULL,
		[CreatedOn] [datetime] NOT NULL,	
		[SendTries] [int] NOT NULL,
		[SentOn] [datetime] NULL,
	 CONSTRAINT [PK_Nop_QueuedEmail] PRIMARY KEY CLUSTERED 
	(
		[QueuedEmailID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO










IF EXISTS (SELECT 1
           FROM   sysobjects
           WHERE  name = 'FK_Nop_ProductVariant_ProductAttribute_Mapping_Nop_ProductAttribute'
           AND parent_obj = Object_id('Nop_ProductVariant_ProductAttribute_Mapping')
           AND Objectproperty(id,N'IsForeignKey') = 1)
ALTER TABLE dbo.Nop_ProductVariant_ProductAttribute_Mapping
DROP CONSTRAINT FK_Nop_ProductVariant_ProductAttribute_Mapping_Nop_ProductAttribute
GO

ALTER TABLE [dbo].[Nop_ProductVariant_ProductAttribute_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Nop_ProductVariant_ProductAttribute_Mapping_Nop_ProductAttribute] FOREIGN KEY([ProductAttributeID])
REFERENCES [dbo].[Nop_ProductAttribute] ([ProductAttributeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO






IF EXISTS (SELECT 1
           FROM   sysobjects
           WHERE  name = 'FK_Nop_ProductVariant_Pricelist_Mapping_Nop_Pricelist'
           AND parent_obj = Object_id('Nop_ProductVariant_Pricelist_Mapping')
           AND Objectproperty(id,N'IsForeignKey') = 1)
ALTER TABLE dbo.Nop_ProductVariant_Pricelist_Mapping
DROP CONSTRAINT FK_Nop_ProductVariant_Pricelist_Mapping_Nop_Pricelist
GO

IF EXISTS (SELECT 1
           FROM   sysobjects
           WHERE  name = 'FK_Nop_ProductVariant_Pricelist_Mapping_Nop_ProductVariant'
           AND parent_obj = Object_id('Nop_ProductVariant_Pricelist_Mapping')
           AND Objectproperty(id,N'IsForeignKey') = 1)
ALTER TABLE dbo.Nop_ProductVariant_Pricelist_Mapping
DROP CONSTRAINT FK_Nop_ProductVariant_Pricelist_Mapping_Nop_ProductVariant
GO

IF OBJECT_ID(N'[dbo].[Nop_Pricelist]') IS NOT NULL
	DROP TABLE [dbo].[Nop_Pricelist]
GO

IF OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_Mapping]') IS NOT NULL
	DROP TABLE [dbo].[Nop_ProductVariant_Pricelist_Mapping]
GO



CREATE TABLE [dbo].[Nop_Pricelist](
	[PricelistID] [int] IDENTITY(1,1) NOT NULL,
	[ExportModeID] [int] NOT NULL,
	[ExportTypeID] [int] NOT NULL,
	[AffiliateID] [int] NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[ShortName] [nvarchar](20) NOT NULL,
	[PricelistGuid] [nvarchar](40) NOT NULL,
	[CacheTime] [int] NOT NULL,
	[FormatLocalization] [nvarchar](5) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[AdminNotes] [nvarchar](500) NOT NULL,
	[Header] [nvarchar](500) NOT NULL,
	[Body] [nvarchar](500) NOT NULL,
	[Footer] [nvarchar](500) NOT NULL,
	[PriceAdjustmentTypeID] [int] NOT NULL CONSTRAINT [DF_Nop_Pricelist_PriceAdjustmentTypeID]  DEFAULT ((0)),
	[PriceAdjustment] [money] NOT NULL CONSTRAINT [DF_Nop_Pricelist_PriceAdjustment]  DEFAULT ((0)),
	[OverrideIndivAdjustment] [bit] NOT NULL CONSTRAINT [DF_Nop_Pricelist_OverrideIndivAdjustment]  DEFAULT ((0)),
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Nop_Pricelist] PRIMARY KEY CLUSTERED 
(
	[PricelistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Nop_ProductVariant_Pricelist_Mapping](
	[ProductVariantPricelistID] [int] IDENTITY(1,1) NOT NULL,
	[ProductVariantID] [int] NOT NULL,
	[PricelistID] [int] NOT NULL,
	[PriceAdjustmentTypeID] [int] NOT NULL CONSTRAINT [DF_Nop_ProductVariant_Pricelist_Mapping_PriceAdjustmentTypeID]  DEFAULT ((0)),
	[PriceAdjustment] [money] NOT NULL CONSTRAINT [DF_Nop_ProductVariant_Pricelist_Mapping_PriceAdjustment]  DEFAULT ((0)),
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Nop_ProductVariant_Pricelist_Mapping] PRIMARY KEY CLUSTERED 
(
	[ProductVariantPricelistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Nop_ProductVariant_Pricelist_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Nop_ProductVariant_Pricelist_Mapping_Nop_Pricelist] FOREIGN KEY([PricelistID])
REFERENCES [dbo].[Nop_Pricelist] ([PricelistID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Nop_ProductVariant_Pricelist_Mapping] CHECK CONSTRAINT [FK_Nop_ProductVariant_Pricelist_Mapping_Nop_Pricelist]
GO
ALTER TABLE [dbo].[Nop_ProductVariant_Pricelist_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Nop_ProductVariant_Pricelist_Mapping_Nop_ProductVariant] FOREIGN KEY([ProductVariantID])
REFERENCES [dbo].[Nop_ProductVariant] ([ProductVariantId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Nop_ProductVariant_Pricelist_Mapping] CHECK CONSTRAINT [FK_Nop_ProductVariant_Pricelist_Mapping_Nop_ProductVariant]
GO






--New columns
IF NOT EXISTS (
		SELECT 1 FROM syscolumns WHERE id=object_id('[dbo].[Nop_Category]') and NAME='PageSize')
BEGIN
	ALTER TABLE [dbo].[Nop_Category] 
	ADD PageSize INT NOT NULL CONSTRAINT [DF_Nop_Category_PageSize] DEFAULT ((10))
END
GO

if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_Category]') and name='PriceRanges')
begin
	ALTER TABLE [dbo].[Nop_Category] 
	ADD PriceRanges nvarchar(400) not null CONSTRAINT [DF_Nop_Category_PriceRanges] DEFAULT ('')
End
GO


if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_Customer]') and name='IsGuest')
begin
	ALTER TABLE [dbo].[Nop_Customer] 
	ADD IsGuest bit not null CONSTRAINT [DF_Nop_Customer_IsGuest] DEFAULT ((0))
End
GO

IF NOT EXISTS (
		SELECT 1 FROM syscolumns WHERE id=object_id('[dbo].[Nop_Manufacturer]') and NAME='PageSize')
BEGIN
	ALTER TABLE [dbo].[Nop_Manufacturer] 
	ADD PageSize INT NOT NULL CONSTRAINT [DF_Nop_Manufacturer_PageSize] DEFAULT ((10))
END
GO

if not exists(select 1 from syscolumns where id=object_id('[dbo].[Nop_Manufacturer]') and name='PriceRanges')
begin
	ALTER TABLE [dbo].[Nop_Manufacturer] 
	ADD PriceRanges nvarchar(400) not null CONSTRAINT [DF_Nop_Manufacturer_PriceRanges] DEFAULT ('')
end
GO


if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_ProductVariant]') and name='ManageInventory')
begin
	ALTER TABLE [dbo].[Nop_ProductVariant] 
	ADD ManageInventory bit not null CONSTRAINT [DF_Nop_ProductVariant_ManageInventory] DEFAULT ((1))
End
GO

if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_ProductVariant]') and name='NotifyAdminForQuantityBelow')
begin
	ALTER TABLE [dbo].[Nop_ProductVariant] 
	ADD NotifyAdminForQuantityBelow int not null CONSTRAINT [DF_Nop_ProductVariant_NotifyAdminForQuantityBelow] DEFAULT ((1))
End
GO

if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_ProductVariant]') and name='OrderMinimumQuantity')
begin
	ALTER TABLE [dbo].[Nop_ProductVariant] 
	ADD OrderMinimumQuantity int not null CONSTRAINT [DF_Nop_ProductVariant_OrderMinimumQuantity] DEFAULT ((1))
End
GO


if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_ProductVariant]') and name='OrderMaximumQuantity')
begin
	ALTER TABLE [dbo].[Nop_ProductVariant] 
	ADD OrderMaximumQuantity int not null CONSTRAINT [DF_Nop_ProductVariant_OrderMaximumQuantity] DEFAULT ((10000))
End
GO

if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_ProductVariant_ProductAttribute_Mapping]') and name='AttributeControlTypeID')
begin
	ALTER TABLE [dbo].[Nop_ProductVariant_ProductAttribute_Mapping] 
	ADD AttributeControlTypeID int not null CONSTRAINT [DF_Nop_ProductVariant_ProductAttribute_Mapping_ControlTypeID] DEFAULT ((1))
End
GO

if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_ProductVariantAttributeValue]') and name='WeightAdjustment')
begin
	ALTER TABLE [dbo].[Nop_ProductVariantAttributeValue] 
	ADD WeightAdjustment decimal(18, 4) not null CONSTRAINT [DF_Nop_ProductVariantAttributeValue_WeightAdjustment] DEFAULT ((0))
End
GO

if not exists
	(select 1 from syscolumns where id=object_id('[dbo].[Nop_ProductVariantAttributeValue]') and name='IsPreSelected')
begin
	ALTER TABLE [dbo].[Nop_ProductVariantAttributeValue] 
	ADD IsPreSelected bit not null CONSTRAINT [DF_Nop_ProductVariantAttributeValue_IsPreSelected] DEFAULT ((0))
End
GO

ALTER TABLE [dbo].[Nop_ShippingByTotal]
ALTER COLUMN [From] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByTotal]
ALTER COLUMN [To] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByTotal]
ALTER COLUMN [ShippingChargePercentage] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByTotal]
ALTER COLUMN [ShippingChargeAmount] decimal(18, 2) NOT NULL
GO


ALTER TABLE [dbo].[Nop_ShippingByWeightAndCountry]
ALTER COLUMN [From] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByWeightAndCountry]
ALTER COLUMN [To] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByWeightAndCountry]
ALTER COLUMN [ShippingChargePercentage] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByWeightAndCountry]
ALTER COLUMN [ShippingChargeAmount] decimal(18, 2) NOT NULL
GO




ALTER TABLE [dbo].[Nop_ShippingByWeight]
ALTER COLUMN [From] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByWeight]
ALTER COLUMN [To] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByWeight]
ALTER COLUMN [ShippingChargePercentage] decimal(18, 2) NOT NULL
GO

ALTER TABLE [dbo].[Nop_ShippingByWeight]
ALTER COLUMN [ShippingChargeAmount] decimal(18, 2) NOT NULL
GO


--added new message template
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_MessageTemplate]
		WHERE [Name] = N'QuantityBelow.StoreOwnerNotification')
BEGIN
	INSERT [dbo].[Nop_MessageTemplate] ([Name])
	VALUES (N'QuantityBelow.StoreOwnerNotification')

	DECLARE @MessageTemplateID INT 
	SELECT @MessageTemplateID =	mt.MessageTemplateID FROM Nop_MessageTemplate mt
							WHERE mt.Name = 'QuantityBelow.StoreOwnerNotification' 

	IF (@MessageTemplateID > 0)
	BEGIN
		INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateID], [LanguageID], [Subject], [Body]) 
		VALUES (@MessageTemplateID, 7, N'%Store.Name%. Quantity below notification. %ProductVariant.FullProductName%', N'<p><a href="%Store.URL%">%Store.Name%</a> <br />
		<br />
		%ProductVariant.FullProductName% (ID: %ProductVariant.ID%) low quantity. <br />
		<br />
		Quantity: %ProductVariant.StockQuantity%<br /></p>')
	END
END
GO

--new settings
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Display.ShowNewsHeaderRssURL')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Display.ShowNewsHeaderRssURL', N'false', N'')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Display.ShowBlogHeaderRssURL')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Display.ShowBlogHeaderRssURL', N'false', N'')
END
GO


IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Email.AdminEmailDisplayName')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Email.AdminEmailDisplayName', N'', N'')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'SEO.Sitemaps.IncludeCategories')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'SEO.Sitemaps.IncludeCategories', N'true', N'')
END

GO
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'SEO.Sitemaps.IncludeManufacturers')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'SEO.Sitemaps.IncludeManufacturers', N'false', N'')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'SEO.Sitemaps.IncludeProducts')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'SEO.Sitemaps.IncludeProducts', N'false', N'')
END
GO


IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Display.ShowWelcomeMessageOnMainPage')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Display.ShowWelcomeMessageOnMainPage', N'true', N'Determines whether or not to show the Welcome message content on the home page.''')
END
GO
-- Removed url parameter from YourWishListURL as url now displayed as separate hyperlink control
UPDATE [dbo].[Nop_LocaleStringResource]
SET [ResourceValue] = REPLACE([ResourceValue], '{0}', '') 
WHERE [ResourceName] = N'Wishlist.YourWishlistURL'
GO


IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Media.MaximumImageSize')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Media.MaximumImageSize', N'600', N'The maximum image size that can be stored')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Media.Product.ThumbnailImageSize')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Media.Product.ThumbnailImageSize', N'125', N'The product thumbnail image size')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Media.Product.DetailImageSize')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Media.Product.DetailImageSize', N'300', N'The product detail image size')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Media.Product.VariantImageSize')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Media.Product.VariantImageSize', N'125', N'The product variant image size')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Media.Category.ThumbnailImageSize')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Media.Category.ThumbnailImageSize', N'125', N'The category thumbnail image size')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Media.Manufacturer.ThumbnailImageSize')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Media.Manufacturer.ThumbnailImageSize', N'125', N'The manufacturer thumbnail image size')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'Checkout.AnonymousCheckoutAllowed')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'Checkout.AnonymousCheckoutAllowed', N'false', N'A value indicating whether anonymous checkout is allowed')
END
GO



IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'SEO.Product.UrlRewriteFormat')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'SEO.Product.UrlRewriteFormat', N'{0}Products/{1}-{2}.aspx', N'The format for search engine friendly product urls')
END
GO
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'SEO.Category.UrlRewriteFormat')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'SEO.Category.UrlRewriteFormat', N'{0}Category/{1}-{2}.aspx', N'The format for search engine friendly category urls')
END
GO
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'SEO.Manufacturer.UrlRewriteFormat')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'SEO.Manufacturer.UrlRewriteFormat', N'{0}Manufacturer/{1}-{2}.aspx', N'The format for search engine friendly manufacturer urls')
END
GO
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'SEO.Blog.UrlRewriteFormat')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'SEO.Blog.UrlRewriteFormat', N'{0}Blog/{1}-{2}.aspx', N'The format for search engine friendly blog urls')
END
GO
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_Setting]
		WHERE [Name] = N'SEO.News.UrlRewriteFormat')
BEGIN
	INSERT [dbo].[Nop_Setting] ([Name], [Value], [Description])
	VALUES (N'SEO.News.UrlRewriteFormat', N'{0}News/{1}-{2}.aspx', N'The format for search engine friendly news urls')
END
GO












--new resource strings
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Pager.First')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Pager.First', N'First')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Pager.Last')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Pager.Last', N'Last')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Pager.Next')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Pager.Next', N'Next')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Pager.Previous')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Pager.Previous', N'Previous')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Pager.CurrentPage')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Pager.CurrentPage', N'Page {0} of {1} ({2} total)')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Search.NoResultsText')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Search.NoResultsText', N'No products were found that matched your criteria.')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'ShoppingCart.QuantityExceedsStock')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'ShoppingCart.QuantityExceedsStock', N'Your quantity exceeds stock on hand. The maximum quantity that can be added is {0}.')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Common.PriceRangeFilter')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Common.PriceRangeFilter', N'Filter by price')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Products.PriceRangeFromText')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Products.PriceRangeFromText', N'From {0}')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Common.PriceRangeFilter.Over')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Common.PriceRangeFilter.Over', N'Over {0}')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Common.PriceRangeFilter.Under')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Common.PriceRangeFilter.Under', N'Under {0}')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Products.FilterOptionsTitle')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Products.FilterOptionsTitle', N'Filter your results')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Common.PriceRangeFilterRemove')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Common.PriceRangeFilterRemove', N'Remove Filter')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'ShoppingCart.MinimumQuantity')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'ShoppingCart.MinimumQuantity', N'The minimum quantity allowed for purchase is {0}.')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'ShoppingCart.MaximumQuantity')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'ShoppingCart.MaximumQuantity', N'The maximum quantity allowed for purchase is {0}.')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'ShoppingCart.TextOptionIsRequired')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'ShoppingCart.TextOptionIsRequired', N'Text option is required. {0}.')
END
GO
IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Login.ForgotPassword')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Login.ForgotPassword', N'Forgot password?')
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM [dbo].[Nop_LocaleStringResource]
		WHERE [LanguageID]=7 and [ResourceName] = N'Checkout.OrderCompleted.Details')
BEGIN
	INSERT [dbo].[Nop_LocaleStringResource] ([LanguageID], [ResourceName], [ResourceValue])
	VALUES (7, N'Checkout.OrderCompleted.Details', N'Click here for order details.')
END
GO






























--Stored procedures
IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_CategoryInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_CategoryInsert]
GO
CREATE PROCEDURE [dbo].[Nop_CategoryInsert]
(
	@CategoryID int = NULL output,
	@Name nvarchar(400),
	@Description ntext,
	@TemplateID int,
	@MetaKeywords nvarchar(400),
	@MetaDescription nvarchar(4000),
	@MetaTitle nvarchar(400),
	@SEName nvarchar(100),
	@ParentCategoryID int,	
	@PictureID int,
	@PageSize int,
	@PriceRanges nvarchar(400),
	@Published bit,
	@Deleted bit,
	@DisplayOrder int,
	@CreatedOn datetime,
	@UpdatedOn datetime
)
AS
BEGIN
	INSERT
	INTO [Nop_Category]
	(
		[Name],
		[Description],
		TemplateID,
		MetaKeywords,
		MetaDescription,
		MetaTitle,
		SEName,
		ParentCategoryID,
		PictureID,
		PageSize,
		PriceRanges,
		Published,
		Deleted,
		DisplayOrder,
		CreatedOn,
		UpdatedOn	
	)
	VALUES
	(
		@Name,
		@Description,
		@TemplateID,
		@MetaKeywords,
		@MetaDescription,
		@MetaTitle,
		@SEName,
		@ParentCategoryID,
		@PictureID,
		@PageSize,
		@PriceRanges,
		@Published,
		@Deleted,
		@DisplayOrder,
		@CreatedOn,
		@UpdatedOn
	)

	set @CategoryID=@@identity
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_CategoryUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_CategoryUpdate]
GO
CREATE PROCEDURE [dbo].[Nop_CategoryUpdate]
(
	@CategoryID int,
	@Name nvarchar(400),
	@Description ntext,
	@TemplateID int,
	@MetaKeywords nvarchar(400),
	@MetaDescription nvarchar(4000),
	@MetaTitle nvarchar(400),
	@SEName nvarchar(100),
	@ParentCategoryID int,
	@PictureID int,
	@PageSize int,
	@PriceRanges nvarchar(400),
	@Published bit,
	@Deleted bit,
	@DisplayOrder int,
	@CreatedOn datetime,
	@UpdatedOn datetime
)
AS
BEGIN
	UPDATE [Nop_Category]
	SET
		[Name]=@Name,
		[Description]=@Description,
		TemplateID=@TemplateID,
		MetaKeywords=@MetaKeywords,
		MetaDescription=@MetaDescription,
		MetaTitle=@MetaTitle,
		SEName=@SEName,
		ParentCategoryID=@ParentCategoryID,
		PictureID=@PictureID,
		PageSize=@PageSize,
		PriceRanges=@PriceRanges,
		Published=@Published,
		Deleted=@Deleted,
		DisplayOrder=@DisplayOrder,
		CreatedOn=@CreatedOn,
		UpdatedOn=@UpdatedOn

	WHERE
		CategoryID = @CategoryID
END
GO



IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_CustomerInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_CustomerInsert]
GO
CREATE PROCEDURE [dbo].[Nop_CustomerInsert]
(
	@CustomerId int = NULL output,
	@CustomerGUID uniqueidentifier,
	@Email nvarchar(255),
	@PasswordHash nvarchar(255),
	@SaltKey nvarchar(255),
	@AffiliateID int,
	@BillingAddressID int,
	@ShippingAddressID int,
	@LastPaymentMethodID int,
	@LastAppliedCouponCode nvarchar(100),
	@LanguageID int,
	@CurrencyID int,
	@IsAdmin bit,
	@IsGuest bit,
	@Active bit,
	@Deleted bit,
	@RegistrationDate datetime
)
AS
BEGIN
	INSERT
	INTO [Nop_Customer]
	(
		CustomerGUID,
		Email,
		PasswordHash,
		SaltKey,
		AffiliateID,
		BillingAddressID,
		ShippingAddressID,
		LastPaymentMethodID,
		LastAppliedCouponCode,
		LanguageID,
		CurrencyID,
		IsAdmin,
		IsGuest,
		Active,
		Deleted,
		RegistrationDate
	)
	VALUES
	(
		@CustomerGUID,
		@Email,
		@PasswordHash,
		@SaltKey,
		@AffiliateID,
		@BillingAddressID,
		@ShippingAddressID,
		@LastPaymentMethodID,
		@LastAppliedCouponCode,
		@LanguageID,
		@CurrencyID,
		@IsAdmin,
		@IsGuest,
		@Active,
		@Deleted,
		@RegistrationDate
	)

	set @CustomerId=@@identity
END
GO



IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_CustomerUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_CustomerUpdate]
GO
CREATE PROCEDURE [dbo].[Nop_CustomerUpdate]
(
	@CustomerId int,
	@CustomerGUID uniqueidentifier,
	@Email nvarchar(255),
	@PasswordHash nvarchar(255),
	@SaltKey nvarchar(255),
	@AffiliateID int,
	@BillingAddressID int,
	@ShippingAddressID int,
	@LastPaymentMethodID int,
	@LastAppliedCouponCode nvarchar(100),
	@LanguageID int,
	@CurrencyID int,
	@IsAdmin bit,
	@IsGuest bit,
	@Active bit,
	@Deleted bit,
	@RegistrationDate datetime
)
AS
BEGIN

	UPDATE [Nop_Customer]
	SET
		CustomerGUID=@CustomerGUID,
		Email=@Email,
		PasswordHash=@PasswordHash,
		SaltKey=@SaltKey,
		AffiliateID=@AffiliateID,
		BillingAddressID=@BillingAddressID,
		ShippingAddressID=@ShippingAddressID,
		LastPaymentMethodID=@LastPaymentMethodID,
		LastAppliedCouponCode=@LastAppliedCouponCode,
		LanguageID=@LanguageID,
		CurrencyID=@CurrencyID,
		IsAdmin=@IsAdmin,
		IsGuest=@IsGuest,
		Active=@Active,
		Deleted=@Deleted,
		RegistrationDate=@RegistrationDate
	WHERE
		[CustomerId] = @CustomerId

END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ManufacturerInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ManufacturerInsert]
GO
CREATE PROCEDURE [dbo].[Nop_ManufacturerInsert]
(
	@ManufacturerID int = NULL output,
	@Name nvarchar(400),
	@Description ntext,
	@TemplateID int,
	@MetaKeywords nvarchar(400),
	@MetaDescription nvarchar(4000),
	@MetaTitle nvarchar(400),
	@SEName nvarchar(100),
	@PictureID int,
	@PageSize int,
	@PriceRanges nvarchar(400),
	@Published bit,
	@Deleted bit,
	@DisplayOrder int,
	@CreatedOn datetime,
	@UpdatedOn datetime
)
AS
BEGIN
	INSERT
	INTO [Nop_Manufacturer]
	(
		[Name],
		[Description],
		TemplateID,
		MetaKeywords,
		MetaDescription,
		MetaTitle,
		SEName,
		PictureID,
		PageSize,
		PriceRanges,
		Published,
		Deleted,
		DisplayOrder,
		CreatedOn,
		UpdatedOn	
	)
	VALUES
	(
		@Name,
		@Description,
		@TemplateID,
		@MetaKeywords,
		@MetaDescription,
		@MetaTitle,
		@SEName,
		@PictureID,
		@PageSize,
		@PriceRanges,
		@Published,
		@Deleted,
		@DisplayOrder,
		@CreatedOn,
		@UpdatedOn
	)

	set @ManufacturerID=@@identity
END
GO
IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ManufacturerUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ManufacturerUpdate]
GO
CREATE PROCEDURE [dbo].[Nop_ManufacturerUpdate]
(
	@ManufacturerID int,
	@Name nvarchar(400),
	@Description ntext,
	@TemplateID int,
	@MetaKeywords nvarchar(400),
	@MetaDescription nvarchar(4000),
	@MetaTitle nvarchar(400),
	@SEName nvarchar(100),
	@PictureID int,
	@PageSize int,
	@PriceRanges nvarchar(400),
	@Published bit,
	@Deleted bit,
	@DisplayOrder int,
	@CreatedOn datetime,
	@UpdatedOn datetime
)
AS
BEGIN
	UPDATE [Nop_Manufacturer]
	SET
		[Name]=@Name,
		[Description]=@Description,
		TemplateID=@TemplateID,
		MetaKeywords=@MetaKeywords,
		MetaDescription=@MetaDescription,
		MetaTitle=@MetaTitle,
		SEName=@SEName,
		PictureID=@PictureID,
		PageSize=@PageSize,
		PriceRanges=@PriceRanges,
		Published=@Published,
		Deleted=@Deleted,
		DisplayOrder=@DisplayOrder,
		CreatedOn=@CreatedOn,
		UpdatedOn=@UpdatedOn

	WHERE
		ManufacturerID = @ManufacturerID
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductLoadAllPaged]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductLoadAllPaged]
GO
CREATE PROCEDURE [dbo].[Nop_ProductLoadAllPaged]
(
	@CategoryID			int,
	@ManufacturerID		int,
	@FeaturedProducts	bit = null,	--0 featured only , 1 not featured only, null - load all products
	@PriceMin			money = null,
	@PriceMax			money = null,
	@Keywords			nvarchar(MAX),	
	@SearchDescriptions bit = 0,
	@ShowHidden			bit,
	@PageIndex			int = 0, 
	@PageSize			int = 2147483644,
	@TotalRecords		int = null OUTPUT
)
AS
BEGIN
	
	SET @Keywords = isnull(@Keywords, '')
	SET @Keywords = '%' + rtrim(ltrim(@Keywords)) + '%'

	SET @PriceMin = isnull(@PriceMin, 0)
	SET @PriceMax = isnull(@PriceMax, 2147483644)

	--display order
	CREATE TABLE #DisplayOrder
	(
		ProductID int not null PRIMARY KEY,
		DisplayOrder int not null
	)	

	IF @CategoryID IS NOT NULL AND @CategoryID > 0
		BEGIN
			INSERT #DisplayOrder 
			SELECT pcm.ProductID, pcm.DisplayOrder 
			FROM [Nop_Product_Category_Mapping] pcm WHERE pcm.CategoryID = @CategoryID
		END
    ELSE IF @ManufacturerID IS NOT NULL AND @ManufacturerID > 0
		BEGIN
			INSERT #DisplayOrder 
			SELECT pmm.ProductID, pmm.Displayorder 
			FROM [Nop_Product_Manufacturer_Mapping] pmm WHERE pmm.ManufacturerID = @ManufacturerID
		END
	ELSE
		BEGIN
			INSERT #DisplayOrder 
			SELECT p.ProductID, 1 
			FROM [Nop_Product] p
			ORDER BY p.[Name]
		END


	--paging
	DECLARE @PageLowerBound int
	DECLARE @PageUpperBound int
	DECLARE @RowsToReturn int
	DECLARE @TotalThreads int
	
	SET @RowsToReturn = @PageSize * (@PageIndex + 1)	
	SET @PageLowerBound = @PageSize * @PageIndex
	SET @PageUpperBound = @PageLowerBound + @PageSize + 1
	
	CREATE TABLE #PageIndex 
	(
		IndexID int IDENTITY (1, 1) NOT NULL,
		ProductID int NOT NULL,
		DisplayOrder int NOT NULL,
	)

	INSERT INTO #PageIndex (ProductID, DisplayOrder)
	SELECT DISTINCT
		p.ProductID, do.DisplayOrder
	FROM Nop_Product p with (NOLOCK) 
	LEFT OUTER JOIN Nop_Product_Category_Mapping pcm with (NOLOCK) ON p.ProductID=pcm.ProductID
	LEFT OUTER JOIN Nop_Product_Manufacturer_Mapping pmm with (NOLOCK) ON p.ProductID=pmm.ProductID
	LEFT OUTER JOIN Nop_ProductVariant pv with (NOLOCK) ON p.ProductID = pv.ProductID        
	JOIN #DisplayOrder do on p.ProductID = do.ProductID 
	WHERE 
		(
			(
				p.Published = 1 OR @ShowHidden = 1
			)
		AND 
			(
				pv.Published = 1 or @ShowHidden = 1
			)
		AND 
			(
				p.Deleted=0
			)
		AND (
				@CategoryID IS NULL OR @CategoryID=0
				OR (pcm.CategoryID=@CategoryID AND (@FeaturedProducts IS NULL OR pcm.IsFeaturedProduct=@FeaturedProducts))
			)
		AND (
				@ManufacturerID IS NULL OR @ManufacturerID=0
				OR (pmm.ManufacturerID=@ManufacturerID AND (@FeaturedProducts IS NULL OR pmm.IsFeaturedProduct=@FeaturedProducts))
			)
		AND (
				pv.Price BETWEEN @PriceMin AND @PriceMax
			)
		AND	(
				patindex(@Keywords, isnull(p.name, '')) > 0
				or patindex(@Keywords, isnull(pv.name, '')) > 0
				or patindex(@Keywords, isnull(pv.sku , '')) > 0
				or (@SearchDescriptions = 1 and patindex(@Keywords, isnull(p.ShortDescription, '')) > 0)
				or (@SearchDescriptions = 1 and patindex(@Keywords, isnull(p.FullDescription, '')) > 0)
				or (@SearchDescriptions = 1 and patindex(@Keywords, isnull(pv.Description, '')) > 0)
			)
		)
	ORDER BY do.DisplayOrder

	SET @TotalRecords = @@rowcount	
	SET ROWCOUNT @RowsToReturn
	
	SELECT  
		p.*
	FROM
		#PageIndex [pi]
		INNER JOIN Nop_Product p on p.ProductID = [pi].ProductID
	WHERE
		[pi].IndexID > @PageLowerBound AND 
		[pi].IndexID < @PageUpperBound
	ORDER BY
		IndexID
	
	SET ROWCOUNT 0

	DROP TABLE #PageIndex
END

GO




IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductSearch]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductSearch]
GO



IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_ProductAttribute_MappingInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_ProductAttribute_MappingInsert]
GO

CREATE PROCEDURE [dbo].[Nop_ProductVariant_ProductAttribute_MappingInsert]
(
	@ProductVariantAttributeID int = NULL output,
	@ProductVariantID int,
	@ProductAttributeID int,
	@IsRequired bit,
	@AttributeControlTypeID int,
	@DisplayOrder int
)
AS
BEGIN
	INSERT
	INTO [Nop_ProductVariant_ProductAttribute_Mapping]
	(
		ProductVariantID,
		ProductAttributeID,
		IsRequired,
		AttributeControlTypeID,
		DisplayOrder
	)
	VALUES
	(
		@ProductVariantID,
		@ProductAttributeID,
		@IsRequired,
		@AttributeControlTypeID,
		@DisplayOrder
	)

	set @ProductVariantAttributeID=@@identity
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_ProductAttribute_MappingUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_ProductAttribute_MappingUpdate]
GO
CREATE PROCEDURE [dbo].[Nop_ProductVariant_ProductAttribute_MappingUpdate]
(
	@ProductVariantAttributeID int,
	@ProductVariantID int,
	@ProductAttributeID int,
	@IsRequired bit,
	@AttributeControlTypeID int,
	@DisplayOrder int
)
AS
BEGIN

	UPDATE [Nop_ProductVariant_ProductAttribute_Mapping]
	SET
		ProductVariantID=@ProductVariantID,
		ProductAttributeID=@ProductAttributeID,
		IsRequired=@IsRequired,
		AttributeControlTypeID=@AttributeControlTypeID,
		DisplayOrder=@DisplayOrder
	WHERE
		ProductVariantAttributeID = @ProductVariantAttributeID
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariantAttributeValueInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariantAttributeValueInsert]
GO

CREATE PROCEDURE [dbo].[Nop_ProductVariantAttributeValueInsert]
(
	@ProductVariantAttributeValueID int = NULL output,
	@ProductVariantAttributeID int,
	@Name nvarchar (100),
	@PriceAdjustment money,
	@WeightAdjustment decimal(18, 4),
	@IsPreSelected bit,
	@DisplayOrder int
)
AS
BEGIN
	INSERT
	INTO [Nop_ProductVariantAttributeValue]
	(
		[ProductVariantAttributeID],
		[Name],
		[PriceAdjustment],
		[WeightAdjustment],
		[IsPreSelected],
		[DisplayOrder]
	)
	VALUES
	(
		@ProductVariantAttributeID,
		@Name,
		@PriceAdjustment,
		@WeightAdjustment,
		@IsPreSelected,
		@DisplayOrder
	)

	set @ProductVariantAttributeValueID=@@identity
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariantAttributeValueUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariantAttributeValueUpdate]
GO
CREATE PROCEDURE [dbo].[Nop_ProductVariantAttributeValueUpdate]
(
	@ProductVariantAttributeValueID int,
	@ProductVariantAttributeID int,
	@Name nvarchar (100),
	@PriceAdjustment money,
	@WeightAdjustment decimal(18, 4),
	@IsPreSelected bit,
	@DisplayOrder int
)
AS
BEGIN

	UPDATE [Nop_ProductVariantAttributeValue]
	SET
		ProductVariantAttributeID=@ProductVariantAttributeID,
		[Name]=@Name,
		PriceAdjustment=@PriceAdjustment,
		WeightAdjustment=@WeightAdjustment,
		IsPreSelected=@IsPreSelected,
		DisplayOrder=@DisplayOrder
	WHERE
		ProductVariantAttributeValueID = @ProductVariantAttributeValueID
END
GO



IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariantInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariantInsert]
GO

CREATE PROCEDURE [dbo].[Nop_ProductVariantInsert]
(
    @ProductVariantID int = NULL output,
    @ProductId int,
    @Name nvarchar(400),
    @SKU nvarchar (400),
    @Description nvarchar(4000),
    @AdminComment nvarchar(4000),
    @ManufacturerPartNumber nvarchar(100),
    @IsDownload bit,
    @DownloadID int,
    @IsShipEnabled bit,
    @IsFreeShipping bit,
    @IsTaxExempt bit,
    @TaxCategoryID int,
	@ManageInventory bit,
    @StockQuantity int,
    @MinStockQuantity int,
    @LowStockActivityID int,
	@NotifyAdminForQuantityBelow int,
	@OrderMinimumQuantity int,
	@OrderMaximumQuantity int,
    @WarehouseId int,
    @DisableBuyButton int,
    @RequiresTextOption bit,
    @TextOptionPrompt nvarchar(400),
    @Price money,
    @OldPrice money,
    @Weight float,
    @Length decimal(18, 4),
    @Width decimal(18, 4),
    @Height decimal(18, 4),
    @PictureID int,
    @Published bit,
    @Deleted bit,
    @DisplayOrder int,
    @CreatedOn datetime,
    @UpdatedOn datetime
)
AS
BEGIN
    INSERT
    INTO [Nop_ProductVariant]
    (
        ProductId,
        [Name],
        SKU,
        [Description],
        AdminComment,
        ManufacturerPartNumber,
        IsDownload,
        DownloadID,
        IsShipEnabled,
        IsFreeShipping,
        IsTaxExempt,
        TaxCategoryID,
		ManageInventory,
        StockQuantity,
        MinStockQuantity,
        LowStockActivityID,
		NotifyAdminForQuantityBelow,
		OrderMinimumQuantity,
		OrderMaximumQuantity,
        WarehouseId,
        DisableBuyButton,
        RequiresTextOption,
        TextOptionPrompt,
        Price,
        OldPrice,
        Weight,
        [Length],
        Width,
        Height,
        PictureID,
        Published,
        Deleted,
        DisplayOrder,
        CreatedOn,
        UpdatedOn
    )
    VALUES
    (
        @ProductId,
        @Name,
        @SKU,
        @Description,
        @AdminComment,
        @ManufacturerPartNumber,
        @IsDownload,
        @DownloadID,
        @IsShipEnabled,
        @IsFreeShipping,
        @IsTaxExempt,
        @TaxCategoryID,
		@ManageInventory,
        @StockQuantity,
        @MinStockQuantity,
        @LowStockActivityID,
		@NotifyAdminForQuantityBelow,
		@OrderMinimumQuantity,
		@OrderMaximumQuantity,
        @WarehouseId,
        @DisableBuyButton,
        @RequiresTextOption,
        @TextOptionPrompt,
        @Price,
        @OldPrice,
        @Weight,
        @Length,
        @Width,
        @Height,
        @PictureID,
        @Published,
        @Deleted,
        @DisplayOrder,
        @CreatedOn,
        @UpdatedOn
    )

    set @ProductVariantID=@@identity
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariantUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariantUpdate]
GO

CREATE PROCEDURE [dbo].[Nop_ProductVariantUpdate]
(
	@ProductVariantID int,
	@ProductId int,
	@Name nvarchar(400),
	@SKU nvarchar (400),
	@Description nvarchar(4000),
	@AdminComment nvarchar(4000),
	@ManufacturerPartNumber nvarchar(100),
	@IsDownload bit,
	@DownloadID int,
	@IsShipEnabled bit,
	@IsFreeShipping bit,
	@IsTaxExempt bit,
	@TaxCategoryID int,
	@ManageInventory bit,
	@StockQuantity int,
	@MinStockQuantity int,
	@LowStockActivityID int,
	@NotifyAdminForQuantityBelow int,
	@OrderMinimumQuantity int,
	@OrderMaximumQuantity int,
	@WarehouseId int,
	@DisableBuyButton bit,
	@RequiresTextOption bit,
	@TextOptionPrompt nvarchar(400),
	@Price money,
	@OldPrice money,
	@Weight float,
	@Length decimal(18, 4),
	@Width decimal(18, 4),
	@Height decimal(18, 4),
	@PictureID int, 
	@Published bit,
	@Deleted bit,
	@DisplayOrder int,
	@CreatedOn datetime,
	@UpdatedOn datetime
)
AS
BEGIN
	UPDATE [Nop_ProductVariant]
	SET
		ProductId=@ProductId,
		[Name]=@Name,
		[SKU]=@SKU,
		[Description]=@Description,
		AdminComment=@AdminComment,
		ManufacturerPartNumber=@ManufacturerPartNumber,
		IsDownload=@IsDownload,
		DownloadID=@DownloadID,
		IsShipEnabled=@IsShipEnabled,
		IsFreeShipping=@IsFreeShipping,
		IsTaxExempt=@IsTaxExempt,
		TaxCategoryID=@TaxCategoryID,
		ManageInventory=@ManageInventory,
		StockQuantity=@StockQuantity,
		MinStockQuantity=@MinStockQuantity,
		LowStockActivityID=@LowStockActivityID,
		NotifyAdminForQuantityBelow=@NotifyAdminForQuantityBelow,
		OrderMinimumQuantity=@OrderMinimumQuantity,
		OrderMaximumQuantity=@OrderMaximumQuantity,
		WarehouseId=@WarehouseId,
		DisableBuyButton=@DisableBuyButton,
		RequiresTextOption=@RequiresTextOption,
		TextOptionPrompt=@TextOptionPrompt,
		Price=@Price,
		OldPrice=@OldPrice,
		Weight=@Weight,
		[Length]=@Length,
		Width=@Width,
		Height=@Height,
		PictureID=@PictureID,
		Published=@Published,
		Deleted=@Deleted,
		DisplayOrder=@DisplayOrder,
		CreatedOn=@CreatedOn,
		UpdatedOn=@UpdatedOn
	WHERE
		ProductVariantID = @ProductVariantID
END
GO




IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_MappingDelete]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingDelete]
GO
CREATE PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingDelete]
(
	@ProductVariantPricelistID int
)
AS
BEGIN
	DELETE 
	FROM [dbo].[Nop_ProductVariant_Pricelist_Mapping]
	WHERE
		[ProductVariantPricelistID] = @ProductVariantPricelistID
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_MappingDeleteByProductVariantIDAndPricelistID]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingDeleteByProductVariantIDAndPricelistID]
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_MappingInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingInsert]
GO
CREATE PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingInsert]
(
	@ProductVariantID int,
	@PricelistID int,
	@PriceAdjustmentTypeID int,
	@PriceAdjustment money,
	@UpdatedOn datetime,
	@ProductVariantPricelistID int OUTPUT
)
AS
BEGIN
	INSERT INTO [dbo].[Nop_ProductVariant_Pricelist_Mapping] 
	(
		[ProductVariantID],
		[PricelistID],
		[PriceAdjustmentTypeID],
		[PriceAdjustment],
		[UpdatedOn]
	) 
	VALUES 
	(
		@ProductVariantID,
		@PricelistID,
		@PriceAdjustmentTypeID,
		@PriceAdjustment,
		@UpdatedOn
	)

	SET @ProductVariantPricelistID = SCOPE_IDENTITY()
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_MappingLoadAll]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingLoadAll]
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_MappingLoadByPricelistID]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingLoadByPricelistID]
GO
IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariantLoadByPricelistID]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariantLoadByPricelistID]
GO

CREATE PROCEDURE [dbo].[Nop_ProductVariantLoadByPricelistID]
(
	@PricelistID int
)
AS
BEGIN
	SELECT pv.*
	FROM
		[dbo].[Nop_ProductVariant] pv
		INNER JOIN [dbo].[Nop_ProductVariant_Pricelist_Mapping] plm
		ON pv.ProductVariantID = plm.ProductVariantID
	WHERE
		plm.[PricelistID] = @PricelistID
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_MappingLoadByPrimaryKey]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingLoadByPrimaryKey]
GO
CREATE PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingLoadByPrimaryKey]
(
	@ProductVariantPricelistID int
)
AS
BEGIN
	SELECT *
	FROM
		[dbo].[Nop_ProductVariant_Pricelist_Mapping]
	WHERE
		[ProductVariantPricelistID] = @ProductVariantPricelistID
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_MappingLoadByProductVariantIDAndPricelistID]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingLoadByProductVariantIDAndPricelistID]
GO
CREATE PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingLoadByProductVariantIDAndPricelistID]
(
	@ProductVariantID int, 
	@PricelistID int
)
AS
BEGIN
	SELECT *
	FROM
		[dbo].[Nop_ProductVariant_Pricelist_Mapping]
	WHERE
		[ProductVariantID] = @ProductVariantID
		AND
		[PricelistID] = @PricelistID
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ProductVariant_Pricelist_MappingUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingUpdate]
GO
CREATE PROCEDURE [dbo].[Nop_ProductVariant_Pricelist_MappingUpdate]
(
	@ProductVariantPricelistID int,
	@ProductVariantID int,
	@PricelistID int,
	@PriceAdjustmentTypeID int,
	@PriceAdjustment money,
	@UpdatedOn datetime
)
AS
BEGIN
	UPDATE [dbo].[Nop_ProductVariant_Pricelist_Mapping] 
	SET
		[ProductVariantID] = @ProductVariantID,
		[PricelistID] = @PricelistID,
		[PriceAdjustmentTypeID] = @PriceAdjustmentTypeID,
		[PriceAdjustment] = @PriceAdjustment,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[ProductVariantPricelistID] = @ProductVariantPricelistID
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_PricelistInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_PricelistInsert]
GO
CREATE PROCEDURE [dbo].[Nop_PricelistInsert]
(
	@ExportModeID int,
	@ExportTypeID int,
	@AffiliateID int,
	@DisplayName nvarchar(100),
	@ShortName nvarchar(20),
	@PricelistGuid nvarchar(40),
	@CacheTime int,
	@FormatLocalization nvarchar(5),
	@Description nvarchar(500),
	@AdminNotes nvarchar(500),
	@Header nvarchar(500),
	@Body nvarchar(500),
	@Footer nvarchar(500),
	@PriceAdjustmentTypeID int,
	@PriceAdjustment money,
	@OverrideIndivAdjustment bit,
	@CreatedOn datetime,
	@UpdatedOn datetime,
	@PricelistID int OUTPUT
)
AS
BEGIN
	INSERT 
	INTO [dbo].[Nop_Pricelist] 
	(
		[ExportModeID],
		[ExportTypeID],
		[AffiliateID],
		[DisplayName],
		[ShortName],
		[PricelistGuid],
		[CacheTime],
		[FormatLocalization],
		[Description],
		[AdminNotes],
		[Header],
		[Body],
		[Footer],
		[PriceAdjustmentTypeID],
		[PriceAdjustment],
		[OverrideIndivAdjustment],
		[CreatedOn],
		[UpdatedOn]
	) 
	VALUES 
	(
		@ExportModeID,
		@ExportTypeID,
		@AffiliateID,
		@DisplayName,
		@ShortName,
		@PricelistGuid,
		@CacheTime,
		@FormatLocalization,
		@Description,
		@AdminNotes,
		@Header,
		@Body,
		@Footer,
		@PriceAdjustmentTypeID,
		@PriceAdjustment,
		@OverrideIndivAdjustment,
		@CreatedOn,
		@UpdatedOn
	)

	SET @PricelistID = SCOPE_IDENTITY()
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_PricelistLoadAll]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_PricelistLoadAll]
GO
CREATE PROCEDURE [dbo].[Nop_PricelistLoadAll]
AS
BEGIN
	SELECT
		 *
	FROM
		[dbo].[Nop_Pricelist]
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_PricelistLoadByGuid]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_PricelistLoadByGuid]
GO
CREATE PROCEDURE [dbo].[Nop_PricelistLoadByGuid]
(
	@PricelistGuid nvarchar(40)
)
AS
BEGIN
	SELECT *
	FROM
		[dbo].[Nop_Pricelist]
	WHERE
		[PricelistGuid] = @PricelistGuid
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_PricelistLoadByPrimaryKey]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_PricelistLoadByPrimaryKey]
GO
CREATE PROCEDURE [dbo].[Nop_PricelistLoadByPrimaryKey]
(
	@PricelistID int
)
AS
BEGIN
	SELECT *
	FROM
		[dbo].[Nop_Pricelist]
	WHERE
		[PricelistID] = @PricelistID
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_PricelistLoadByProductVariantID]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_PricelistLoadByProductVariantID]
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_PricelistUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_PricelistUpdate]
GO
CREATE PROCEDURE [dbo].[Nop_PricelistUpdate]
(
	@PricelistID int,
	@ExportModeID int,
	@ExportTypeID int,
	@AffiliateID int,
	@DisplayName nvarchar(100),
	@ShortName nvarchar(20),
	@PricelistGuid nvarchar(40),
	@CacheTime int,
	@FormatLocalization nvarchar(5),
	@Description nvarchar(500),
	@AdminNotes nvarchar(500),
	@Header nvarchar(500),
	@Body nvarchar(500),
	@Footer nvarchar(500),
	@PriceAdjustmentTypeID int,
	@PriceAdjustment money,
	@OverrideIndivAdjustment bit,
	@CreatedOn datetime,
	@UpdatedOn datetime
)
AS
BEGIN
	UPDATE [dbo].[Nop_Pricelist] 
	SET
		[ExportModeID] = @ExportModeID,
		[ExportTypeID] = @ExportTypeID,
		[AffiliateID] = @AffiliateID,
		[DisplayName] = @DisplayName,
		[ShortName] = @ShortName,
		[PricelistGuid] = @PricelistGuid,
		[CacheTime] = @CacheTime,
		[FormatLocalization] = @FormatLocalization,
		[Description] = @Description,
		[AdminNotes] = @AdminNotes,
		[Header] = @Header,
		[Body] = @Body,
		[Footer] = @Footer,
		[PriceAdjustmentTypeID] = @PriceAdjustmentTypeID,
		[PriceAdjustment] = @PriceAdjustment,
		[OverrideIndivAdjustment] = @OverrideIndivAdjustment,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[PricelistID] = @PricelistID
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_QueuedEmailDelete]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_QueuedEmailDelete]
GO
CREATE PROCEDURE [dbo].[Nop_QueuedEmailDelete]
(
	@QueuedEmailID int
)
AS
BEGIN
	SET NOCOUNT ON
	DELETE
	FROM [Nop_QueuedEmail]
	WHERE
		[QueuedEmailID] = @QueuedEmailID
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_QueuedEmailInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_QueuedEmailInsert]
GO
CREATE PROCEDURE [dbo].[Nop_QueuedEmailInsert]
(
	@QueuedEmailID int = NULL output,
	@Priority int,
	@From nvarchar(500),
	@FromName nvarchar(500),
	@To nvarchar(500),
	@ToName nvarchar(500),
	@Cc nvarchar(500),
	@Bcc nvarchar(500),
	@Subject nvarchar(500),
	@Body nvarchar(MAX),
	@CreatedOn datetime,
	@SendTries int,
	@SentOn datetime
)
AS
BEGIN
	INSERT
	INTO [Nop_QueuedEmail]
	(
		[Priority],
		[From],
		[FromName],
		[To],
		[ToName],
		[Cc],
		[Bcc],
		[Subject],
		[Body],
		[CreatedOn],
		[SendTries],
		[SentOn]
	)
	VALUES
	(
		@Priority,
		@From,
		@FromName,
		@To,
		@ToName,
		@Cc,
		@Bcc,
		@Subject,
		@Body,
		@CreatedOn,
		@SendTries,
		@SentOn
	)

	set @QueuedEmailID=@@identity
END
GO



IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_QueuedEmailLoadAll]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_QueuedEmailLoadAll]
GO
CREATE PROCEDURE [dbo].[Nop_QueuedEmailLoadAll]
	@QueuedEmailCount int,
	@LoadNotSentItemsOnly bit,
	@MaxSendTries int
AS
BEGIN
	IF (@QueuedEmailCount > 0)
	SET ROWCOUNT @QueuedEmailCount

	SELECT *
	FROM [Nop_QueuedEmail]
	WHERE ((@LoadNotSentItemsOnly IS NULL OR @LoadNotSentItemsOnly=0) OR (SentOn IS NULL))
			AND SendTries < @MaxSendTries
ORDER BY Priority desc, CreatedOn ASC
	SET ROWCOUNT 0
END
GO



IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_QueuedEmailLoadByPrimaryKey]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_QueuedEmailLoadByPrimaryKey]
GO
CREATE PROCEDURE [dbo].[Nop_QueuedEmailLoadByPrimaryKey]
(
	@QueuedEmailID int
)
AS
BEGIN
SET NOCOUNT ON
SELECT
*
FROM [Nop_QueuedEmail]
WHERE
	QueuedEmailID=@QueuedEmailID
END
GO







IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_QueuedEmailUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Nop_QueuedEmailUpdate]
GO
CREATE PROCEDURE [dbo].[Nop_QueuedEmailUpdate]
(
	@QueuedEmailID int,
	@Priority int,
	@From nvarchar(500),
	@FromName nvarchar(500),
	@To nvarchar(500),
	@ToName nvarchar(500),
	@Cc nvarchar(500),
	@Bcc nvarchar(500),
	@Subject nvarchar(500),
	@Body nvarchar(MAX),
	@CreatedOn datetime,
	@SendTries int,
	@SentOn datetime
)
AS
BEGIN
UPDATE [Nop_QueuedEmail]
SET
	[Priority]=@Priority,
	[From]=@From,
	[FromName]=@FromName,
	[To]=@To,
	[ToName]=@ToName,
	[Cc]=@Cc,
	[Bcc]=@Bcc,
	[Subject]=@Subject,
	[Body]=@Body,
	[CreatedOn]=@CreatedOn,
	[SendTries]=@SendTries,
	[SentOn]=@SentOn
WHERE
	QueuedEmailID= @QueuedEmailID

END
GO





IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ShippingByTotalInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[Nop_ShippingByTotalInsert]
END
GO
CREATE PROCEDURE [dbo].[Nop_ShippingByTotalInsert]
(
	@ShippingByTotalID int = NULL output,
	@ShippingMethodID int,
	@From decimal(18, 2),
	@To decimal(18, 2),
	@UsePercentage bit,
	@ShippingChargePercentage decimal(18, 2),
	@ShippingChargeAmount decimal(18, 2)
)
AS
BEGIN
	INSERT
	INTO [Nop_ShippingByTotal]
	(
		ShippingMethodID,
		[From],
		[To],
		UsePercentage,
		ShippingChargePercentage,
		ShippingChargeAmount
	)
	VALUES
	(
		@ShippingMethodID,
		@From,
		@To,
		@UsePercentage,
		@ShippingChargePercentage,
		@ShippingChargeAmount
	)

	set @ShippingByTotalID=@@identity
END
GO


IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ShippingByTotalUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[Nop_ShippingByTotalUpdate]
END
GO
CREATE PROCEDURE [dbo].[Nop_ShippingByTotalUpdate]
(
	@ShippingByTotalID int,
	@ShippingMethodID int,
	@From decimal(18, 2),
	@To decimal(18, 2),
	@UsePercentage bit,
	@ShippingChargePercentage decimal(18, 2),
	@ShippingChargeAmount decimal(18, 2)
)
AS
BEGIN
	UPDATE [Nop_ShippingByTotal]
	SET
		ShippingMethodID=@ShippingMethodID,
		[From]=@From,
		[To]=@To,
		UsePercentage=@UsePercentage,
		ShippingChargePercentage=@ShippingChargePercentage,
		ShippingChargeAmount=@ShippingChargeAmount
	WHERE
		ShippingByTotalID = @ShippingByTotalID
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ShippingByWeightAndCountryInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[Nop_ShippingByWeightAndCountryInsert]
END
GO
CREATE PROCEDURE [dbo].[Nop_ShippingByWeightAndCountryInsert]
(
	@ShippingByWeightAndCountryID int = NULL output,
	@ShippingMethodID int,
	@CountryID int,
	@From decimal(18, 2),
	@To decimal(18, 2),
	@UsePercentage bit,
	@ShippingChargePercentage decimal(18, 2),
	@ShippingChargeAmount decimal(18, 2)
)
AS
BEGIN
	INSERT
	INTO [Nop_ShippingByWeightAndCountry]
	(
		ShippingMethodID,
		CountryID,
		[From],
		[To],
		UsePercentage,
		ShippingChargePercentage,
		ShippingChargeAmount
	)
	VALUES
	(
		@ShippingMethodID,
		@CountryID,
		@From,
		@To,
		@UsePercentage,
		@ShippingChargePercentage,
		@ShippingChargeAmount
	)

	set @ShippingByWeightAndCountryID=@@identity
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ShippingByWeightAndCountryUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[Nop_ShippingByWeightAndCountryUpdate]
END
GO
CREATE PROCEDURE [dbo].[Nop_ShippingByWeightAndCountryUpdate]
(
	@ShippingByWeightAndCountryID int,
	@ShippingMethodID int,
	@CountryID int,
	@From decimal(18, 2),
	@To decimal(18, 2),
	@UsePercentage bit,
	@ShippingChargePercentage decimal(18, 2),
	@ShippingChargeAmount decimal(18, 2)
)
AS
BEGIN
	UPDATE [Nop_ShippingByWeightAndCountry]
	SET
		ShippingMethodID=@ShippingMethodID,
		CountryID=@CountryID,
		[From]=@From,
		[To]=@To,
		UsePercentage=@UsePercentage,
		ShippingChargePercentage=@ShippingChargePercentage,
		ShippingChargeAmount=@ShippingChargeAmount
	WHERE
		ShippingByWeightAndCountryID = @ShippingByWeightAndCountryID
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ShippingByWeightInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[Nop_ShippingByWeightInsert]
END
GO
CREATE PROCEDURE [dbo].[Nop_ShippingByWeightInsert]
(
	@ShippingByWeightID int = NULL output,
	@ShippingMethodID int,
	@From decimal(18, 2),
	@To decimal(18, 2),
	@UsePercentage bit,
	@ShippingChargePercentage decimal(18, 2),
	@ShippingChargeAmount decimal(18, 2)
)
AS
BEGIN
	INSERT
	INTO [Nop_ShippingByWeight]
	(
		ShippingMethodID,
		[From],
		[To],
		UsePercentage,
		ShippingChargePercentage,
		ShippingChargeAmount
	)
	VALUES
	(
		@ShippingMethodID,
		@From,
		@To,
		@UsePercentage,
		@ShippingChargePercentage,
		@ShippingChargeAmount
	)

	set @ShippingByWeightID=@@identity
END
GO

IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = OBJECT_ID(N'[dbo].[Nop_ShippingByWeightUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[Nop_ShippingByWeightUpdate]
END
GO
CREATE PROCEDURE [dbo].[Nop_ShippingByWeightUpdate]
(
	@ShippingByWeightID int,
	@ShippingMethodID int,
	@From decimal(18, 2),
	@To decimal(18, 2),
	@UsePercentage bit,
	@ShippingChargePercentage decimal(18, 2),
	@ShippingChargeAmount decimal(18, 2)
)
AS
BEGIN
	UPDATE [Nop_ShippingByWeight]
	SET
		ShippingMethodID=@ShippingMethodID,
		[From]=@From,
		[To]=@To,
		UsePercentage=@UsePercentage,
		ShippingChargePercentage=@ShippingChargePercentage,
		ShippingChargeAmount=@ShippingChargeAmount
	WHERE
		ShippingByWeightID = @ShippingByWeightID
END
GO

