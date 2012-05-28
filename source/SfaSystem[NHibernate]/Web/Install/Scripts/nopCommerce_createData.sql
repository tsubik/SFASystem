SET IDENTITY_INSERT [dbo].[Nop_ShippingMethod] ON
INSERT [dbo].[Nop_ShippingMethod] ([ShippingMethodID], [Name], [Description], [DisplayOrder]) VALUES (1, N'By Ground', N'Compared to other shipping methods, like by flight or over seas, ground shipping is carried out closer to the earth', 1)
INSERT [dbo].[Nop_ShippingMethod] ([ShippingMethodID], [Name], [Description], [DisplayOrder]) VALUES (3, N'By Air', N'The one day air shipping', 3)
SET IDENTITY_INSERT [dbo].[Nop_ShippingMethod] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_TaxProvider] ON
INSERT [dbo].[Nop_TaxProvider] ([TaxProviderID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (3, N'No tax', N'', N'', N'NopSolutions.NopCommerce.Tax.FreeTaxProvider, Nop.Tax.FreeTaxProvider', 1)
INSERT [dbo].[Nop_TaxProvider] ([TaxProviderID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (6, N'Tax By Country & State', N'', N'Tax\General\ConfigureTax.ascx', N'NopSolutions.NopCommerce.Tax.GeneralTaxProvider, Nop.Tax.GeneralTaxProvider', 2)
INSERT [dbo].[Nop_TaxProvider] ([TaxProviderID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (7, N'Strike Iron Basic (US and CA Only)', N'', N'Tax\StrikeIron\ConfigureTax.ascx', N'NopSolutions.NopCommerce.Tax.StrikeIronTaxProvider, Nop.Tax.StrikeIron', 2)
SET IDENTITY_INSERT [dbo].[Nop_TaxProvider] OFF
GO


INSERT [dbo].[Nop_LogType] ([LogTypeID], [Name]) VALUES (0, N'Unknown')
INSERT [dbo].[Nop_LogType] ([LogTypeID], [Name]) VALUES (1, N'Customer Error')
INSERT [dbo].[Nop_LogType] ([LogTypeID], [Name]) VALUES (2, N'Mail Error')
INSERT [dbo].[Nop_LogType] ([LogTypeID], [Name]) VALUES (3, N'Order Error')
INSERT [dbo].[Nop_LogType] ([LogTypeID], [Name]) VALUES (4, N'Administration Area')
INSERT [dbo].[Nop_LogType] ([LogTypeID], [Name]) VALUES (5, N'Common Error')
INSERT [dbo].[Nop_LogType] ([LogTypeID], [Name]) VALUES (6, N'Shipping Errror')
INSERT [dbo].[Nop_LogType] ([LogTypeID], [Name]) VALUES (7, N'Tax Error')
GO


SET IDENTITY_INSERT [dbo].[Nop_TaxCategory] ON
INSERT [dbo].[Nop_TaxCategory] ([TaxCategoryID], [Name], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (1, N'Electronics & Software', 2, CAST(0x00009AEF001EEEC1 AS DateTime), CAST(0x00009BE300DCBA2A AS DateTime))
INSERT [dbo].[Nop_TaxCategory] ([TaxCategoryID], [Name], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (4, N'Downloadable Products', 5, CAST(0x00009AF601564486 AS DateTime), CAST(0x00009B2200ECEEED AS DateTime))
INSERT [dbo].[Nop_TaxCategory] ([TaxCategoryID], [Name], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (6, N'Books', 1, CAST(0x00009B2200E8511C AS DateTime), CAST(0x00009B2200E8511C AS DateTime))
INSERT [dbo].[Nop_TaxCategory] ([TaxCategoryID], [Name], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (8, N'Jewelry', 5, CAST(0x00009BE20146BB8E AS DateTime), CAST(0x00009BE20146BB8E AS DateTime))
INSERT [dbo].[Nop_TaxCategory] ([TaxCategoryID], [Name], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (9, N'Apparel & Shoes', 8, CAST(0x00009BE20188BBF9 AS DateTime), CAST(0x00009BE20188BBF9 AS DateTime))
SET IDENTITY_INSERT [dbo].[Nop_TaxCategory] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_CreditCardType] ON
INSERT [dbo].[Nop_CreditCardType] ([CreditCardTypeID], [Name], [SystemKeyword], [DisplayOrder], [Deleted]) VALUES (1, N'Visa', N'Visa', 1, 0)
INSERT [dbo].[Nop_CreditCardType] ([CreditCardTypeID], [Name], [SystemKeyword], [DisplayOrder], [Deleted]) VALUES (2, N'Master Card', N'MasterCard', 2, 0)
INSERT [dbo].[Nop_CreditCardType] ([CreditCardTypeID], [Name], [SystemKeyword], [DisplayOrder], [Deleted]) VALUES (4, N'American Express', N'AmericanExpress', 3, 0)
INSERT [dbo].[Nop_CreditCardType] ([CreditCardTypeID], [Name], [SystemKeyword], [DisplayOrder], [Deleted]) VALUES (6, N'Discover', N'Discover', 4, 0)
SET IDENTITY_INSERT [dbo].[Nop_CreditCardType] OFF
GO


INSERT [dbo].[Nop_ShoppingCartType] ([ShoppingCartTypeID], [Name]) VALUES (1, N'Shopping Cart')
INSERT [dbo].[Nop_ShoppingCartType] ([ShoppingCartTypeID], [Name]) VALUES (2, N'Wishlist')
GO


SET IDENTITY_INSERT [dbo].[Nop_MessageTemplate] ON
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (6, N'OrderCompleted.CustomerNotification')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (8, N'OrderShipped.CustomerNotification')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (9, N'OrderPlaced.StoreOwnerNotification')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (11, N'Customer.WelcomeMessage')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (13, N'Customer.EmailValidationMessage')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (14, N'Customer.PasswordRecovery')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (17, N'Service.EmailAFriend')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (18, N'OrderPlaced.CustomerNotification')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (19, N'OrderCancelled.CustomerNotification')
INSERT [dbo].[Nop_MessageTemplate] ([MessageTemplateID], [Name]) VALUES (21, N'QuantityBelow.StoreOwnerNotification')
SET IDENTITY_INSERT [dbo].[Nop_MessageTemplate] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_Setting] ON
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (1, N'Customer.RegistrationEmailValidation', N'false', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (5, N'Shipping.ShippingRateComputationMethod.ActiveID', N'8', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (10, N'Currency.PrimaryExchangeRateCurrency', N'7', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (11, N'Currency.PrimaryStoreCurrency', N'1', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (13, N'Display.ShowNewsOnMainPage', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (14, N'Display.MainPageNewsCount', N'3', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (15, N'PaymentMethod.PaypalStandard.UseSandbox', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (16, N'PaymentMethod.PaypalStandard.BusinessEmail', N'test@test.com', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (17, N'PaymentMethod.PaypalStandard.PTIIdentityToken', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (18, N'PaymentMethod.Manual.TransactionMode', N'Pending', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (19, N'PaymentMethod.PaypalDirect.UseSandbox', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (20, N'PaymentMethod.PaypalDirect.APIAccountName', N'', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (21, N'PaymentMethod.PaypalDirect.APIAccountPassword', N'', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (24, N'PaymentMethod.PaypalDirect.Signature', N'', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (25, N'Email.AdminEmailAddress', N'test@mail.com', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (26, N'Email.AdminEmailHost', N'smtp.mail.com', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (27, N'Email.AdminEmailPort', N'25', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (28, N'Email.AdminEmailUser', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (29, N'Email.AdminEmailPassword', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (30, N'Email.AdminEmailEnableSsl', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (31, N'Email.AdminEmailUseDefaultCredentials', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (33, N'Display.RecentlyViewedProductCount', N'10', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (36, N'PaymentMethod.TwoCheckout.VendorID', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (37, N'PaymentMethod.TwoCheckout.UseSandbox', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (39, N'Common.StoreName', N'Your store name', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (42, N'Common.StoreURL', N'http://www.youstore.com', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (43, N'SEO.DefaultTitle', N'Your store name', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (44, N'SEO.DefaultMetaDescription', N'Your store meta description', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (45, N'SEO.DefaultMetaKeywords', N'Your store meta keywords', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (46, N'Display.ShowPollsOnMainPage', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (47, N'PaymentMethod.AuthorizeNET.TransactionMode', N'Authorize', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (48, N'PaymentMethod.AuthorizeNET.UseSandbox', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (49, N'PaymentMethod.AuthorizeNET.TransactionKey', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (50, N'PaymentMethod.AuthorizeNET.LoginID', N'456', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (51, N'PaymentMethod.PaypalExpress.TransactionMode', N'Authorize', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (52, N'PaymentMethod.PaypalExpress.UseSandbox', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (53, N'PaymentMethod.PaypalExpress.APIAccountName', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (54, N'PaymentMethod.PaypalExpress.APIAccountPassword', N'456', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (55, N'PaymentMethod.PaypalExpress.Signature', N'789', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (56, N'PaymentMethod.PaypalDirect.TransactionMode', N'Authorize', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (57, N'PaymentMethod.eWay.UseSandbox', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (58, N'PaymentMethod.eWay.TestCustomerID', N'87654321', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (59, N'PaymentMethod.eWay.LiveCustomerID', N'', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (60, N'Common.EnableCompareProducts', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (62, N'PaymentMethod.Moneybookers.PayToEmail', N'name@yourStore.com', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (63, N'Shipping.FreeShippingOverX.Enabled', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (64, N'Shipping.FreeShippingOverX.Value', N'10000.00', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (65, N'Common.StoreClosed', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (66, N'Common.BaseWeightIn', N'3', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (67, N'Common.BaseDimensionIn', N'1', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (68, N'Common.EnableEmailAFirend', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (71, N'Common.LoginCaptchaImageEnabled', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (72, N'Common.RegisterCaptchaImageEnabled', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (73, N'Common.EnableWishlist', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (74, N'Common.EnableBlog', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (75, N'PaymentMethod.Worldpay.InstanceID', N'1234', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (76, N'PaymentMethod.Worldpay.CallbackPassword', N'1234567', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (77, N'ShippingRateComputationMethod.USPS.URL', N'http://production.shippingapis.com/ShippingAPI.dll', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (78, N'ShippingRateComputationMethod.USPS.Username', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (79, N'ShippingRateComputationMethod.USPS.Password', N'456', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (80, N'ShippingRateComputationMethod.USPS.AdditionalHandlingCharge', N'0', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (81, N'ShippingRateComputationMethod.UPS.URL', N'https://www.ups.com/ups.app/xml/Rate', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (82, N'ShippingRateComputationMethod.UPS.Username', N'Username1', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (83, N'ShippingRateComputationMethod.UPS.Password', N'Password1', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (84, N'ShippingRateComputationMethod.UPS.AdditionalHandlingCharge', N'0', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (85, N'ShippingRateComputationMethod.UPS.CustomerClassification', N'Retail', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (86, N'ShippingRateComputationMethod.UPS.PickupType', N'OneTimePickup', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (87, N'ShippingRateComputationMethod.UPS.PackagingType', N'ExpressBox', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (88, N'ShippingRateComputationMethod.UPS.AccessKey', N'AccessKey1', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (89, N'SEO.IncludeStoreNameInTitle', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (90, N'Security.EncryptionPrivateKey', N'1234567890123451', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (92, N'ShippingRateComputationMethod.USPS.DefaultShippedFromZipPostalCode', N'10022', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (93, N'ShippingRateComputationMethod.UPS.DefaultShippedFromCountryID', N'1', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (94, N'ShippingRateComputationMethod.UPS.DefaultShippedFromZipPostalCode', N'10001', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (95, N'Display.ShowCategoriesOnMainPage', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (96, N'Tax.TaxProvider.ActiveID', N'6', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (98, N'Tax.TaxProvider.StrikeIron.UserID', N'test@test.com', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (99, N'Tax.TaxProvider.StrikeIron.Password', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (100, N'Common.SharedSSL', N'', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (101, N'Common.UseSSL', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (102, N'PaymentMethod.Worldpay.UseSandbox', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (103, N'PaymentMethod.GoogleCheckout.TransactionMode', N'Authorize', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (105, N'Localization.DefaultLanguageID', N'7', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (108, N'Localization.DefaultAdminLanguageID', N'7', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (111, N'Common.CurrentVersion', N'1.11', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (112, N'PaymentMethod.PayFlowPro.TransactionMode', N'AuthorizeAndCapture', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (113, N'PaymentMethod.PayFlowPro.UseSandbox', N'True', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (114, N'PaymentMethod.PayFlowPro.User', N'1', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (115, N'PaymentMethod.PayFlowPro.Vendor', N'2', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (116, N'PaymentMethod.PayFlowPro.Partner', N'3', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (117, N'PaymentMethod.PayFlowPro.Password', N'4', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (118, N'PaymentMethod.CashOnDelivery.Info', N'<p>In cases where an order is placed, an authorized representative will contact you, personally or over telephone, to confirm the order.<br />
After the order is confirmed, it will be processed.<br />
Orders once confirmed, cannot be cancelled.</p>
<p>P.S. You can edit this text from admin panel.</p>', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (119, N'PaymentMethod.Check.Info', N'<p>Mail Personal or Business Check, Cashier''s Check or money order to:</p>
<p><br />
<b>NOP SOLUTIONS</b> <br />
<b>your address here,</b> <br />
<b>New York, NY 10001 </b> <br />
<b>USA</b></p>
<p>Notice that if you pay by Personal or Business Check, your order may be held for up to 10 days after we receive your check to allow enough time for the check to clear.  If you want us to ship faster upon receipt of your payment, then we recommend your send a money order or Cashier''s check.</p>
<p>P.S. You can edit this text from admin panel.</p>', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (120, N'PaymentMethod.PSIGate.UseSandbox', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (121, N'PaymentMethod.PSIGate.StoreID', N'', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (122, N'PaymentMethod.PSIGate.Passphrase', N'', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (123, N'PaymentMethod.CDGcommerce.RestrictKey', N'123', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (124, N'PaymentMethod.CDGcommerce.LoginID', N'456', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (126, N'Display.ShowNewsHeaderRssURL', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (127, N'Display.ShowBlogHeaderRssURL', N'False', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (128, N'Display.ShowWelcomeMessageOnMainPage', N'True', N'Determines whether or not to show the Welcome message content on the home page.''')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (129, N'Email.AdminEmailDisplayName', N'', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (130, N'Checkout.AnonymousCheckoutAllowed', N'false', N'A value indicating whether anonymous checkout is allowed')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (131, N'Media.MaximumImageSize', N'600', N'The maximum image size that can be stored')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (132, N'Media.Product.ThumbnailImageSize', N'125', N'The product thumbnail image size')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (133, N'Media.Product.DetailImageSize', N'300', N'The product detail image size')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (134, N'Media.Category.ThumbnailImageSize', N'125', N'The category thumbnail image size')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (135, N'Media.Manufacturer.ThumbnailImageSize', N'125', N'The manufacturer thumbnail image size')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (136, N'Media.Product.VariantImageSize', N'125', N'The product variant image size')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (137, N'SEO.Sitemaps.IncludeCategories', N'true', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (138, N'SEO.Sitemaps.IncludeManufacturers', N'false', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (139, N'SEO.Sitemaps.IncludeProducts', N'false', N'')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (140, N'SEO.Product.UrlRewriteFormat', N'{0}Products/{1}-{2}.aspx', N'The format for search engine friendly product urls')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (141, N'SEO.Category.UrlRewriteFormat', N'{0}Category/{1}-{2}.aspx', N'The format for search engine friendly category urls')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (142, N'SEO.Manufacturer.UrlRewriteFormat', N'{0}Manufacturer/{1}-{2}.aspx', N'The format for search engine friendly manufacturer urls')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (143, N'SEO.Blog.UrlRewriteFormat', N'{0}Blog/{1}-{2}.aspx', N'The format for search engine friendly blog urls')
INSERT [dbo].[Nop_Setting] ([SettingID], [Name], [Value], [Description]) VALUES (144, N'SEO.News.UrlRewriteFormat', N'{0}News/{1}-{2}.aspx', N'The format for search engine friendly news urls')
SET IDENTITY_INSERT [dbo].[Nop_Setting] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_PaymentMethod] ON
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (1, N'Manual Processing', N'Credit Card', N'', N'Payment\Manual\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\Manual\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.Manual.ManualPaymentProcessor, Nop.Payment.Manual', N'', 1, 1)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (2, N'PayPal Standard', N'PayPal Standard', N'', N'Payment\PayPalStandard\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\PayPalStandard\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.PayPal.PayPalStandardPaymentProcessor, Nop.Payment.PayPal', N'', 0, 32)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (7, N'PayPal Direct', N'Credit Card', N'', N'Payment\PayPalDirect\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\PayPalDirect\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.PayPal.PayPalDirectPaymentProcessor, Nop.Payment.PayPal', N'', 0, 3)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (8, N'2Checkout', N'2Checkout', N'', N'Payment\TwoCheckout\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\TwoCheckout\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.TwoCheckout.TwoCheckoutPaymentProcessor, Nop.Payment.TwoCheckout', N'', 0, 30)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (9, N'Authorize.NET', N'Credit Card', N'', N'Payment\AuthorizeNET\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\AuthorizeNET\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.AuthorizeNET.AuthorizeNetPaymentProcessor, Nop.Payment.AuthorizeNet', N'', 0, 2)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (10, N'PayPal Express', N'PayPal Express', N'', N'Payment\PayPalExpress\ConfigurePaymentMethod.ascx', N'', N'NopSolutions.NopCommerce.Payment.Methods.PayPal.PayPalExpressPaymentProcessor, Nop.Payment.PayPal', N'PayPalExpress', 0, 33)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (11, N'eWay', N'Credit Card', N'', N'Payment\eWay\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\eWay\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.eWay.eWayPaymentProcessor, Nop.Payment.eWay', N'', 0, 5)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (12, N'Moneybookers', N'Moneybookers', N'', N'Payment\Moneybookers\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\Moneybookers\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.Moneybookers.MoneybookersPaymentProcessor, Nop.Payment.Moneybookers', N'', 0, 31)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (13, N'Worldpay', N'Worldpay', N'', N'Payment\Worldpay\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\Worldpay\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.Worldpay.WorldpayPaymentProcessor, Nop.Payment.Worldpay', N'', 0, 35)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (14, N'Google Checkout (beta)', N'Google Checkout', N'', N'Payment\GoogleCheckout\ConfigurePaymentMethod.ascx', N'', N'NopSolutions.NopCommerce.Payment.Methods.GoogleCheckout.GoogleCheckoutPaymentProcessor, Nop.Payment.GoogleCheckout', N'GoogleCheckout', 0, 34)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (15, N'Cash On Delivery', N'Cash On Delivery', N'', N'Payment\CashOnDelivery\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\CashOnDelivery\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.CashOnDelivery.CashOnDeliveryPaymentProcessor, Nop.Payment.CashOnDelivery', N'', 1, 70)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (16, N'PayFlow Pro (beta)', N'Credit Card', N'', N'Payment\PayFlowPro\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\PayFlowPro\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.PayFlowPro.PayFlowProPaymentProcessor,Nop.Payment.PayFlowPro', N'', 0, 4)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (17, N'Check / Money Order', N'Check / Money Order', N'', N'Payment\Check\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\Check\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.Check.CheckPaymentProcessor, Nop.Payment.Check', N'', 1, 80)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (18, N'Purchase Order', N'Purchase Order', N'', N'Payment\PurchaseOrder\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\PurchaseOrder\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.PurchaseOrder.PurchaseOrderPaymentProcessor, Nop.Payment.PurchaseOrder', N'', 1, 60)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (19, N'PSI Gate', N'Credit Card', N'', N'Payment\PSIGate\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\PSIGate\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.PSIGate.PSIGatePaymentProcessor, Nop.Payment.PSIGate', N'', 0, 6)
INSERT [dbo].[Nop_PaymentMethod] ([PaymentMethodID], [Name], [VisibleName], [Description], [ConfigureTemplatePath], [UserTemplatePath], [ClassName], [SystemKeyword], [IsActive], [DisplayOrder]) VALUES (20, N'CDG Commerce', N'Credit Card', N'', N'Payment\CDGCommerce\ConfigurePaymentMethod.ascx', N'~\Templates\Payment\CDGCommerce\PaymentModule.ascx', N'NopSolutions.NopCommerce.Payment.Methods.CDGcommerce.CDGcommercePaymentProcessor, Nop.Payment.CDGCommerce', N'', 0, 7)
SET IDENTITY_INSERT [dbo].[Nop_PaymentMethod] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_ProductTemplate] ON
INSERT [dbo].[Nop_ProductTemplate] ([ProductTemplateId], [Name], [TemplatePath], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (4, N'Variants in Grid', N'Templates\Products\VariantsInGrid.ascx', 1, CAST(0x00009B5A00DABF44 AS DateTime), CAST(0x00009B5A00DBC82F AS DateTime))
SET IDENTITY_INSERT [dbo].[Nop_ProductTemplate] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_ProductType] ON
INSERT [dbo].[Nop_ProductType] ([ProductTypeID], [Name], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (1, N'Standard Product', 1, CAST(0x00009AEF0011AC99 AS DateTime), CAST(0x00009AEF0011AC99 AS DateTime))
SET IDENTITY_INSERT [dbo].[Nop_ProductType] OFF
GO


INSERT [dbo].[Nop_PaymentStatus] ([PaymentStatusID], [Name]) VALUES (10, N'Pending')
INSERT [dbo].[Nop_PaymentStatus] ([PaymentStatusID], [Name]) VALUES (20, N'Authorized')
INSERT [dbo].[Nop_PaymentStatus] ([PaymentStatusID], [Name]) VALUES (30, N'Paid')
GO


INSERT [dbo].[Nop_OrderStatus] ([OrderStatusID], [Name]) VALUES (10, N'Pending')
INSERT [dbo].[Nop_OrderStatus] ([OrderStatusID], [Name]) VALUES (20, N'Processing')
INSERT [dbo].[Nop_OrderStatus] ([OrderStatusID], [Name]) VALUES (30, N'Complete')
INSERT [dbo].[Nop_OrderStatus] ([OrderStatusID], [Name]) VALUES (40, N'Cancelled')
GO


SET IDENTITY_INSERT [dbo].[Nop_ManufacturerTemplate] ON
INSERT [dbo].[Nop_ManufacturerTemplate] ([ManufacturerTemplateId], [Name], [TemplatePath], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (1, N'Products In Grid', N'~\Templates\Manufacturers\ProductsInGrid.ascx', 1, CAST(0x00009AEF00125991 AS DateTime), CAST(0x00009B1F00C1A7F2 AS DateTime))
SET IDENTITY_INSERT [dbo].[Nop_ManufacturerTemplate] OFF
GO


INSERT [dbo].[Nop_DiscountType] ([DiscountTypeID], [Name]) VALUES (1, N'Assigned to whole order')
INSERT [dbo].[Nop_DiscountType] ([DiscountTypeID], [Name]) VALUES (2, N'Assigned to product variants (SKUs)')
GO

SET IDENTITY_INSERT [dbo].[Nop_CategoryTemplate] ON
INSERT [dbo].[Nop_CategoryTemplate] ([CategoryTemplateId], [Name], [TemplatePath], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (1, N'Products in Lines 2', N'~\Templates\Categories\ProductsInLines2.ascx', 10, CAST(0x00009AEE016985AF AS DateTime), CAST(0x00009BA4010A60D2 AS DateTime))
INSERT [dbo].[Nop_CategoryTemplate] ([CategoryTemplateId], [Name], [TemplatePath], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (3, N'Products in Grid', N'~\Templates\Categories\ProductsInGrid.ascx', 5, CAST(0x00009AEE01698E58 AS DateTime), CAST(0x00009BA4010A7B84 AS DateTime))
INSERT [dbo].[Nop_CategoryTemplate] ([CategoryTemplateId], [Name], [TemplatePath], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (5, N'Products in Lines 1', N'~\Templates\Categories\ProductsInLines1.ascx', 1, CAST(0x00009BA200261B13 AS DateTime), CAST(0x00009BA4010A507D AS DateTime))
SET IDENTITY_INSERT [dbo].[Nop_CategoryTemplate] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_Country] ON
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (1, N'United States', 1, 1, 1, N'US', N'USA', 840, 1, 1)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (2, N'Canada', 1, 1, 1, N'CA', N'CAN', 124, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (3, N'Argentina', 1, 1, 1, N'AR', N'ARG', 32, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (4, N'Armenia', 1, 1, 1, N'AM', N'ARM', 51, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (5, N'Aruba', 1, 1, 1, N'AW', N'ABW', 533, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (6, N'Australia', 1, 1, 1, N'AU', N'AUS', 36, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (7, N'Austria', 1, 1, 1, N'AT', N'AUT', 40, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (8, N'Azerbaijan', 1, 1, 1, N'AZ', N'AZE', 31, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (9, N'Bahamas', 1, 1, 1, N'BS', N'BHS', 44, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (10, N'Bangladesh', 1, 1, 1, N'BD', N'BGD', 50, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (11, N'Belarus', 1, 1, 1, N'BY', N'BLR', 112, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (12, N'Belgium', 1, 1, 1, N'BE', N'BEL', 56, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (13, N'Belize', 1, 1, 1, N'BZ', N'BLZ', 84, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (14, N'Bermuda', 1, 1, 1, N'BM', N'BMU', 60, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (15, N'Bolivia', 1, 1, 1, N'BO', N'BOL', 68, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (16, N'Bosnia and Herzegowina', 1, 1, 1, N'BA', N'BIH', 70, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (17, N'Brazil', 1, 1, 1, N'BR', N'BRA', 76, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (18, N'Bulgaria', 1, 1, 1, N'BG', N'BGR', 100, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (19, N'Cayman Islands', 1, 1, 1, N'KY', N'CYM', 136, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (20, N'Chile', 1, 1, 1, N'CL', N'CHL', 152, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (21, N'China', 1, 1, 1, N'CN', N'CHN', 156, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (22, N'Colombia', 1, 1, 1, N'CO', N'COL', 170, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (23, N'Costa Rica', 1, 1, 1, N'CR', N'CRI', 188, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (24, N'Croatia (local Name: Hrvatska)', 1, 1, 1, N'HR', N'HRV', 191, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (25, N'Cuba', 1, 1, 1, N'CU', N'CUB', 192, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (26, N'Cyprus', 1, 1, 1, N'CY', N'CYP', 196, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (27, N'Czech Republic', 1, 1, 1, N'CZ', N'CZE', 203, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (28, N'Denmark', 1, 1, 1, N'DK', N'DNK', 208, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (29, N'Dominican Republic', 1, 1, 1, N'DO', N'DOM', 214, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (30, N'Ecuador', 1, 1, 1, N'EC', N'ECU', 218, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (31, N'Egypt', 1, 1, 1, N'EG', N'EGY', 818, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (32, N'Finland', 1, 1, 1, N'FI', N'FIN', 246, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (33, N'France', 1, 1, 1, N'FR', N'FRA', 250, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (34, N'Georgia', 1, 1, 1, N'GE', N'GEO', 268, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (35, N'Germany', 1, 1, 1, N'DE', N'DEU', 276, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (36, N'Gibraltar', 1, 1, 1, N'GI', N'GIB', 292, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (37, N'Greece', 1, 1, 1, N'GR', N'GRC', 300, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (38, N'Guatemala', 1, 1, 1, N'GT', N'GTM', 320, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (39, N'Hong Kong', 1, 1, 1, N'HK', N'HKG', 344, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (40, N'Hungary', 1, 1, 1, N'HU', N'HUN', 348, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (41, N'India', 1, 1, 1, N'IN', N'IND', 356, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (42, N'Indonesia', 1, 1, 1, N'ID', N'IDN', 360, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (43, N'Ireland', 1, 1, 1, N'IE', N'IRL', 372, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (44, N'Israel', 1, 1, 1, N'IL', N'ISR', 376, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (45, N'Italy', 1, 1, 1, N'IT', N'ITA', 380, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (46, N'Jamaica', 1, 1, 1, N'JM', N'JAM', 388, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (47, N'Japan', 1, 1, 1, N'JP', N'JPN', 392, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (48, N'Jordan', 1, 1, 1, N'JO', N'JOR', 400, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (49, N'Kazakhstan', 1, 1, 1, N'KZ', N'KAZ', 398, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (50, N'Korea, Democratic People''s Republic of', 1, 1, 1, N'KP', N'PRK', 408, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (51, N'Kuwait', 1, 1, 1, N'KW', N'KWT', 414, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (52, N'Malaysia', 1, 1, 1, N'MY', N'MYS', 458, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (53, N'Mexico', 1, 1, 1, N'MX', N'MEX', 484, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (54, N'Netherlands', 1, 1, 1, N'NL', N'NLD', 528, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (55, N'New Zealand', 1, 1, 1, N'NZ', N'NZL', 554, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (56, N'Norway', 1, 1, 1, N'NO', N'NOR', 578, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (57, N'Pakistan', 1, 1, 1, N'PK', N'PAK', 586, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (58, N'Paraguay', 1, 1, 1, N'PY', N'PRY', 600, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (59, N'Peru', 1, 1, 1, N'PE', N'PER', 604, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (60, N'Philippines', 1, 1, 1, N'PH', N'PHL', 608, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (61, N'Poland', 1, 1, 1, N'PL', N'POL', 616, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (62, N'Portugal', 1, 1, 1, N'PT', N'PRT', 620, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (63, N'Puerto Rico', 1, 1, 1, N'PR', N'PRI', 630, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (64, N'Qatar', 1, 1, 1, N'QA', N'QAT', 634, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (65, N'Romania', 1, 1, 1, N'RO', N'ROM', 642, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (66, N'Russia', 1, 1, 1, N'RU', N'RUS', 643, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (67, N'Saudi Arabia', 1, 1, 1, N'SA', N'SAU', 682, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (68, N'Singapore', 1, 1, 1, N'SG', N'SGP', 702, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (69, N'Slovakia (Slovak Republic)', 1, 1, 1, N'SK', N'SVK', 703, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (70, N'Slovenia', 1, 1, 1, N'SI', N'SVN', 705, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (71, N'South Africa', 1, 1, 1, N'ZA', N'ZAF', 710, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (72, N'Spain', 1, 1, 1, N'ES', N'ESP', 724, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (73, N'Sweden', 1, 1, 1, N'SE', N'SWE', 752, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (74, N'Switzerland', 1, 1, 1, N'CH', N'CHE', 756, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (75, N'Taiwan', 1, 1, 1, N'TW', N'TWN', 158, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (76, N'Thailand', 1, 1, 1, N'TH', N'THA', 764, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (77, N'Turkey', 1, 1, 1, N'TR', N'TUR', 792, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (78, N'Ukraine', 1, 1, 1, N'UA', N'UKR', 804, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (79, N'United Arab Emirates', 1, 1, 1, N'AE', N'ARE', 784, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (80, N'United Kingdom', 1, 1, 1, N'GB', N'GBR', 826, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (81, N'United States minor outlying islands', 1, 1, 1, N'UM', N'UMI', 581, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (82, N'Uruguay', 1, 1, 1, N'UY', N'URY', 858, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (83, N'Uzbekistan', 1, 1, 1, N'UZ', N'UZB', 860, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (84, N'Venezuela', 1, 1, 1, N'VE', N'VEN', 862, 1, 2)
INSERT [dbo].[Nop_Country] ([CountryID], [Name], [AllowsRegistration], [AllowsBilling], [AllowsShipping], [TwoLetterISOCode], [ThreeLetterISOCode], [NumericISOCode], [Published], [DisplayOrder]) VALUES (85, N'Yugoslavia', 1, 1, 1, N'YU', N'YUG', 891, 1, 2)
SET IDENTITY_INSERT [dbo].[Nop_Country] OFF
GO

INSERT [dbo].[Nop_DiscountRequirement] ([DiscountRequirementID], [Name]) VALUES (1, N'None')
INSERT [dbo].[Nop_DiscountRequirement] ([DiscountRequirementID], [Name]) VALUES (2, N'Must be assigned to customer role')
GO

INSERT [dbo].[Nop_ShippingStatus] ([ShippingStatusID], [Name]) VALUES (10, N'Shipping not required')
INSERT [dbo].[Nop_ShippingStatus] ([ShippingStatusID], [Name]) VALUES (20, N'Not yet shipped')
INSERT [dbo].[Nop_ShippingStatus] ([ShippingStatusID], [Name]) VALUES (30, N'Shipped')
GO

SET IDENTITY_INSERT [dbo].[Nop_MeasureDimension] ON
INSERT [dbo].[Nop_MeasureDimension] ([MeasureDimensionID], [Name], [SystemKeyword], [DisplayOrder]) VALUES (1, N'inch(es)', N'inches', 1)
INSERT [dbo].[Nop_MeasureDimension] ([MeasureDimensionID], [Name], [SystemKeyword], [DisplayOrder]) VALUES (2, N'feet(s)', N'feets', 2)
INSERT [dbo].[Nop_MeasureDimension] ([MeasureDimensionID], [Name], [SystemKeyword], [DisplayOrder]) VALUES (4, N'meter(s)', N'meters', 3)
SET IDENTITY_INSERT [dbo].[Nop_MeasureDimension] OFF
GO

SET IDENTITY_INSERT [dbo].[Nop_Customer] ON
INSERT [dbo].[Nop_Customer] ([CustomerID], [CustomerGUID], [Email], [PasswordHash], [SaltKey], [AffiliateID], [BillingAddressID], [ShippingAddressID], [LastPaymentMethodID], [LastAppliedCouponCode], [LanguageID], [CurrencyID], [IsAdmin], [Active], [Deleted], [RegistrationDate], [IsGuest]) VALUES (37, N'18c4f7dc-2964-41db-9611-8a313bf672d3', N'admin@yourstore.com', N'14F009DDBEF203EDC2124D54FA6D325E16E36D77', N'vw7zHZI=', 0, 0, 0, 0, N'', 7, 1, 1, 1, 0, CAST(0x00009B3600C2192F AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Nop_Customer] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_MeasureWeight] ON
INSERT [dbo].[Nop_MeasureWeight] ([MeasureWeightID], [Name], [SystemKeyword], [DisplayOrder]) VALUES (2, N'ounce(s)', N'ounce', 1)
INSERT [dbo].[Nop_MeasureWeight] ([MeasureWeightID], [Name], [SystemKeyword], [DisplayOrder]) VALUES (3, N'lb(s)', N'lb', 2)
INSERT [dbo].[Nop_MeasureWeight] ([MeasureWeightID], [Name], [SystemKeyword], [DisplayOrder]) VALUES (4, N'kg(s)', N'kg', 3)
SET IDENTITY_INSERT [dbo].[Nop_MeasureWeight] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_ShippingRateComputationMethod] ON
INSERT [dbo].[Nop_ShippingRateComputationMethod] ([ShippingRateComputationMethodID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (6, N'Shipping By Order Total', N'', N'Shipping\ShippingByTotalConfigure\ConfigureShipping.ascx', N'NopSolutions.NopCommerce.Shipping.Methods.ShippingByTotalCM.ShippingByTotalComputationMethod, Nop.Shipping.ShippingByTotal', 2)
INSERT [dbo].[Nop_ShippingRateComputationMethod] ([ShippingRateComputationMethodID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (7, N'Free Shipping', N'All orders have free shipping', N'', N'NopSolutions.NopCommerce.Shipping.Methods.FreeShippingCM.FreeShippingComputationMethod, Nop.Shipping.FreeShipping', 1)
INSERT [dbo].[Nop_ShippingRateComputationMethod] ([ShippingRateComputationMethodID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (8, N'Shipping By Order Weight', N'', N'Shipping\ShippingByWeightConfigure\ConfigureShipping.ascx', N'NopSolutions.NopCommerce.Shipping.Methods.ShippingByWeightCM.ShippingByWeightComputationMethod, Nop.Shipping.ShippingByWeight', 3)
INSERT [dbo].[Nop_ShippingRateComputationMethod] ([ShippingRateComputationMethodID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (9, N'Shipping By Country & Order Weight', N'', N'Shipping\ShippingByWeightAndCountryConfigure\ConfigureShipping.ascx', N'NopSolutions.NopCommerce.Shipping.Methods.ShippingByWeightAndCountryCM.ShippingByWeightAndCountryComputationMethod, Nop.Shipping.ShippingByWeightAndCountry', 4)
INSERT [dbo].[Nop_ShippingRateComputationMethod] ([ShippingRateComputationMethodID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (10, N'USPS (US Postal Service)', N'', N'Shipping\USPSConfigure\ConfigureShipping.ascx', N'NopSolutions.NopCommerce.Shipping.Methods.USPS.USPSComputationMethod, Nop.Shipping.USPS', 9)
INSERT [dbo].[Nop_ShippingRateComputationMethod] ([ShippingRateComputationMethodID], [Name], [Description], [ConfigureTemplatePath], [ClassName], [DisplayOrder]) VALUES (11, N'UPS (United Parcel Service) - Beta', N'', N'Shipping\UPSConfigure\ConfigureShipping.ascx', N'NopSolutions.NopCommerce.Shipping.Methods.UPS.UPSComputationMethod, Nop.Shipping.UPS', 10)
SET IDENTITY_INSERT [dbo].[Nop_ShippingRateComputationMethod] OFF
GO

INSERT [dbo].[Nop_LowStockActivity] ([LowStockActivityID], [Name]) VALUES (0, N'Nothing')
INSERT [dbo].[Nop_LowStockActivity] ([LowStockActivityID], [Name]) VALUES (1, N'Disable buy button')
INSERT [dbo].[Nop_LowStockActivity] ([LowStockActivityID], [Name]) VALUES (2, N'Unpublish')
GO


SET IDENTITY_INSERT [dbo].[Nop_Currency] ON
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (1, N'US Dollar', N'USD', N'en-US', CAST(1.269 AS Decimal(18, 3)), N'', 1, 1, CAST(0x00009AB000C959F7 AS DateTime), CAST(0x00009B96014297C2 AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (2, N'Australian Dollar', N'AUD', N'en-AU', CAST(1.627 AS Decimal(18, 3)), N'', 0, 2, CAST(0x00009AB000C959FC AS DateTime), CAST(0x00009B3D0117F458 AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (4, N'British Pound', N'GBP', N'en-GB', CAST(0.781 AS Decimal(18, 3)), N'', 1, 3, CAST(0x00009AB000C959FC AS DateTime), CAST(0x00009B9601429AA0 AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (5, N'Canadian Dollar', N'CAD', N'en-CA', CAST(1.600 AS Decimal(18, 3)), N'', 0, 4, CAST(0x00009AB000C959FC AS DateTime), CAST(0x00009B3D0117E88D AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (6, N'Chinese Yuan Renminbi', N'CNY', N'zh-CN', CAST(10.798 AS Decimal(18, 3)), N'', 0, 5, CAST(0x00009AB000C959FC AS DateTime), CAST(0x00009B3D0117E266 AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (7, N'Euro', N'EUR', N'', CAST(1.000 AS Decimal(18, 3)), N'€#,###.00', 1, 2, CAST(0x00009AB000C959FC AS DateTime), CAST(0x00009BB8011603A7 AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (8, N'Hong Kong Dollar', N'HKD', N'zh-HK', CAST(12.170 AS Decimal(18, 3)), N'', 0, 7, CAST(0x00009AB000C95A00 AS DateTime), CAST(0x00009B3D0117DE5F AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (9, N'Japanese Yen', N'JPY', N'ja-JP', CAST(162.000 AS Decimal(18, 3)), N'', 0, 8, CAST(0x00009AB000C95A00 AS DateTime), CAST(0x00009B3D0117DB0E AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (12, N'Russian Rouble', N'RUB', N'ru-RU', CAST(34.724 AS Decimal(18, 3)), N'', 0, 9, CAST(0x00009AB000C95A00 AS DateTime), CAST(0x00009BD300EC5AEF AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (14, N'Swedish Krona', N'SEK', N'sv-SE', CAST(9.995 AS Decimal(18, 3)), N'', 0, 10, CAST(0x00009AB000C95A00 AS DateTime), CAST(0x00009B5500F9DBF3 AS DateTime))
INSERT [dbo].[Nop_Currency] ([CurrencyID], [Name], [CurrencyCode], [DisplayLocale], [Rate], [CustomFormatting], [Published], [DisplayOrder], [CreatedOn], [UpdatedOn]) VALUES (16, N'Romanian Leu', N'RON', N'ro-RO', CAST(3.000 AS Decimal(18, 3)), N'', 0, 13, CAST(0x00009BA40176106C AS DateTime), CAST(0x00009BA40176106C AS DateTime))
SET IDENTITY_INSERT [dbo].[Nop_Currency] OFF
GO

SET IDENTITY_INSERT [dbo].[Nop_Language] ON
INSERT [dbo].[Nop_Language] ([LanguageId], [Name], [LanguageCulture], [Published], [DisplayOrder]) VALUES (7, N'English', N'en-US', 1, 1)
SET IDENTITY_INSERT [dbo].[Nop_Language] OFF
GO



SET IDENTITY_INSERT [dbo].[Nop_StateProvince] ON
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (1, 1, N'Alabama', N'AL', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (2, 1, N'Alaska', N'AK', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (3, 1, N'American Samoa', N'AS', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (4, 1, N'AA (Armed Forces Americas)', N'AA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (5, 1, N'AE (Armed Forces Europe)', N'AE', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (6, 1, N'AP (Armed Forces Pacific)', N'AP', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (7, 1, N'Arizona', N'AZ', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (8, 1, N'Arkansas', N'AR', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (9, 1, N'California', N'CA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (10, 1, N'Colorado', N'CO', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (11, 1, N'Connecticut', N'CT', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (12, 1, N'Delaware', N'DE', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (13, 1, N'District of Columbia', N'DC', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (14, 1, N'Federated States of Micronesia', N'FM', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (15, 1, N'Florida', N'FL', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (16, 1, N'Georgia', N'GA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (17, 1, N'Guam', N'GU', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (18, 1, N'Hawaii', N'HI', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (19, 1, N'Idaho', N'ID', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (20, 1, N'Illinois', N'IL', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (21, 1, N'Indiana', N'IN', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (22, 1, N'Iowa', N'IA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (23, 1, N'Kansas', N'KS', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (24, 1, N'Kentucky', N'KY', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (25, 1, N'Louisiana', N'LA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (26, 1, N'Maine', N'ME', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (27, 1, N'Marshall Islands', N'MH', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (28, 1, N'Maryland', N'MD', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (29, 1, N'Massachusetts', N'MA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (30, 1, N'Michigan', N'MI', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (31, 1, N'Minnesota', N'MN', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (32, 1, N'Mississippi', N'MS', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (33, 1, N'Missouri', N'MO', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (34, 1, N'Montana', N'MT', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (35, 1, N'Northern Mariana Islands', N'MP', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (36, 1, N'Nebraska', N'NE', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (37, 1, N'Nevada', N'NV', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (38, 1, N'New Hampshire', N'NH', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (39, 1, N'New Jersey', N'NJ', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (40, 1, N'New Mexico', N'NM', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (41, 1, N'New York', N'NY', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (42, 1, N'North Carolina', N'NC', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (43, 1, N'North Dakota', N'ND', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (44, 1, N'Ohio', N'OH', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (45, 1, N'Oklahoma', N'OK', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (46, 1, N'Oregon', N'OR', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (47, 1, N'Palau', N'PW', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (48, 1, N'Pennsylvania', N'PA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (49, 1, N'Puerto Rico', N'PR', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (50, 1, N'Rhode Island', N'RI', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (51, 1, N'South Carolina', N'SC', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (52, 1, N'South Dakota', N'SD', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (53, 1, N'Tennessee', N'TN', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (54, 1, N'Texas', N'TX', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (55, 1, N'Utah', N'UT', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (56, 1, N'Vermont', N'VT', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (57, 1, N'Virgin Islands', N'VI', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (58, 1, N'Virginia', N'VA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (59, 1, N'Washington', N'WA', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (60, 1, N'West Virginia', N'WV', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (61, 1, N'Wisconsin', N'WI', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (62, 1, N'Wyoming', N'WY', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (63, 2, N'Alberta', N'AB', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (64, 2, N'British Columbia', N'BC', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (65, 2, N'Manitoba', N'MB', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (66, 2, N'New Brunswick', N'NB', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (67, 2, N'Newfoundland and Labrador', N'NL', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (68, 2, N'Northwest Territories', N'NT', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (69, 2, N'Nova Scotia', N'NS', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (70, 2, N'Nunavut', N'NU', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (71, 2, N'Ontario', N'ON', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (72, 2, N'Prince Edward Island', N'PE', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (73, 2, N'Quebec', N'QC', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (74, 2, N'Saskatchewan', N'SK', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (75, 2, N'Yukon Territory', N'YU', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (81, 80, N'Alderney', N'ALD', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (82, 80, N'County Antrim', N'ATM', 2)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (83, 80, N'County Armagh', N'ARM', 3)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (84, 80, N'Avon', N'AVN', 4)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (85, 80, N'Bedfordshire', N'BFD', 5)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (86, 80, N'Berkshire', N'BRK', 6)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (87, 80, N'Borders', N'BDS', 7)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (88, 80, N'Buckinghamshire', N'BUX', 8)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (89, 80, N'Cambridgeshire', N'CBE', 9)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (90, 80, N'Central', N'CTR', 10)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (91, 80, N'Cheshire', N'CHS', 11)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (92, 80, N'Cleveland', N'CVE', 12)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (93, 80, N'Clwyd', N'CLD', 13)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (94, 80, N'Cornwall', N'CNL', 14)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (95, 80, N'Cumbria', N'CBA', 15)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (96, 80, N'Derbyshire', N'DYS', 16)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (97, 80, N'Devon', N'DVN', 17)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (98, 80, N'Dorse', N'DOR', 18)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (99, 80, N'County Down', N'DWN', 19)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (100, 80, N'Dumfries and Galloway', N'DGL', 20)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (101, 80, N'County Durham', N'DHM', 21)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (102, 80, N'Dyfed', N'DFD', 22)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (103, 80, N'Essex', N'ESX', 23)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (104, 80, N'County Fermanagh', N'FMH', 24)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (105, 80, N'Fife', N'FFE', 25)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (106, 80, N'Mid Glamorgan', N'GNM', 26)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (107, 80, N'South Glamorgan', N'GNS', 27)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (108, 80, N'West Glamorgan', N'GNW', 28)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (109, 80, N'Gloucester', N'GLR', 29)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (110, 80, N'Grampian', N'GRN', 30)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (111, 80, N'Guernsey', N'GUR', 31)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (112, 80, N'Gwent', N'GWT', 32)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (113, 80, N'Gwynedd', N'GDD', 33)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (114, 80, N'Hampshire', N'HPH', 34)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (115, 80, N'Hereford and Worcester', N'HWR', 35)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (116, 80, N'Hertfordshire', N'HFD', 36)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (117, 80, N'Highlands', N'HLD', 37)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (118, 80, N'Humberside', N'HBS', 38)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (119, 80, N'Isle of Man', N'IOM', 39)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (120, 80, N'Isle of Wight', N'IOW', 40)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (121, 80, N'Jersey', N'JER', 41)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (122, 80, N'Kent', N'KNT', 42)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (123, 80, N'Lancashire', N'LNH', 43)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (124, 80, N'Leicestershire', N'LEC', 44)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (125, 80, N'Lincolnshire', N'LCN', 45)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (126, 80, N'Greater London', N'LDN', 46)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (127, 80, N'County Londonderry ', N'LDR', 47)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (128, 80, N'Lothian', N'LTH', 48)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (129, 80, N'Greater Manchester', N'MCH', 49)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (130, 80, N'Merseyside', N'MSY', 50)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (131, 80, N'Norfolk', N'NOR', 51)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (132, 80, N'Northamptonshire', N'NHM', 52)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (133, 80, N'Northumberland', N'NLD', 53)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (134, 80, N'Nottinghamshire', N'NOT', 54)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (135, 80, N'Orkney', N'ORK', 55)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (136, 80, N'Oxfordshire', N'OFE', 56)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (137, 80, N'Powys', N'PWS', 57)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (138, 80, N'Shropshire', N'SPE', 58)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (139, 80, N'Sark', N'SRK', 59)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (140, 80, N'Shetland', N'SLD', 60)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (141, 80, N'Somerset', N'SOM', 61)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (142, 80, N'Staffordshire', N'SFD', 62)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (143, 80, N'Strathclyde', N'SCD', 63)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (144, 80, N'Suffolk', N'SFK', 64)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (145, 80, N'Surrey', N'SRY', 65)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (146, 80, N'East Sussex', N'SXE', 66)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (147, 80, N'West Sussex', N'SXW', 67)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (148, 80, N'Tayside', N'TYS', 68)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (149, 80, N'Tyne and Wear', N'TWR', 69)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (150, 80, N'County Tyrone', N'TYR', 70)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (151, 80, N'Warwickshire', N'WKS', 71)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (152, 80, N'Western Isles', N'WIL', 72)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (153, 80, N'West Midlands', N'WMD', 73)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (154, 80, N'Wiltshire', N'WLT', 74)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (155, 80, N'North Yorkshire', N'YSN', 75)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (156, 80, N'South Yorkshire', N'YSS', 76)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (157, 80, N'West Yorkshire', N'YSW', 77)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (159, 65, N'Alba', N'AB', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (160, 65, N'Arad', N'AD', 2)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (161, 65, N'Arges', N'AG', 3)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (162, 65, N'Bacau', N'BC', 4)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (163, 65, N'Bihor', N'BH', 5)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (164, 65, N'Bistrita-Nasaud', N'BN', 6)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (165, 65, N'Botosani', N'BT', 7)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (166, 65, N'Brasov', N'BV', 8)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (167, 65, N'Braila', N'BR', 9)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (168, 65, N'Bucuresti', N'B', 10)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (169, 65, N'Buzau', N'BZ', 11)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (170, 65, N'Caras Severin', N'CS', 12)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (171, 65, N'Calarasi', N'CL', 13)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (172, 65, N'Cluj', N'CJ', 14)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (173, 65, N'Constanta', N'CT', 15)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (174, 65, N'Covasna', N'CV', 16)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (175, 65, N'Dambovita', N'DB', 17)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (176, 65, N'Dolj', N'DJ', 18)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (177, 65, N'Galati', N'GL', 19)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (178, 65, N'Giurgiu', N'GR', 20)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (179, 65, N'Gorj', N'GJ', 21)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (180, 65, N'Harghita', N'HG', 22)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (181, 65, N'Hunedoara', N'HD', 23)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (182, 65, N'Ialomita', N'IL', 24)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (183, 65, N'Iasi', N'IS', 25)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (184, 65, N'Ilfov', N'IF', 26)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (185, 65, N'Maramures', N'MM', 27)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (186, 65, N'Mehedinti', N'MH', 28)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (187, 65, N'Mures', N'MS', 29)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (188, 65, N'Neamt', N'NT', 30)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (189, 65, N'Olt', N'OT', 31)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (190, 65, N'Prahova', N'PH', 32)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (191, 65, N'Satu Mare', N'SM', 33)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (192, 65, N'Salaj', N'SJ', 34)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (193, 65, N'Sibiu', N'SB', 35)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (194, 65, N'Suceava', N'SV', 36)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (195, 65, N'Teleorman', N'TR', 37)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (196, 65, N'Timis', N'TM', 38)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (197, 65, N'Tulcea', N'TL', 39)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (198, 65, N'Vaslui', N'VS', 40)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (199, 65, N'Valcea', N'VL', 41)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (200, 65, N'Vrancea', N'VN', 42)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (201, 35, N'Baden-Wurttemberg', N'BW', 1)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (202, 35, N'Bavaria', N'BY', 2)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (203, 35, N'Berlin', N'BE', 3)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (204, 35, N'Brandenburg', N'BR', 4)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (205, 35, N'Bremen', N'HB', 5)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (206, 35, N'Hamburg', N'HH', 6)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (207, 35, N'Hesse', N'HE', 7)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (208, 35, N'Mecklenburg-West Pomerania', N'MV', 8)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (209, 35, N'Lower Saxony', N'NI', 9)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (210, 35, N'North Rhine-Westphalia ', N'NW', 10)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (211, 35, N'Rhineland-Palatinate', N'RP', 11)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (212, 35, N'Saarland', N'SL', 12)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (213, 35, N'Saxony', N'SN', 13)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (214, 35, N'Saxony-Anhalt ', N'ST', 14)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (215, 35, N'Schleswig-Holstein', N'SH', 15)
INSERT [dbo].[Nop_StateProvince] ([StateProvinceID], [CountryID], [Name], [Abbreviation], [DisplayOrder]) VALUES (216, 35, N'Thuringia', N'TH', 16)
SET IDENTITY_INSERT [dbo].[Nop_StateProvince] OFF
GO




SET IDENTITY_INSERT [dbo].[Nop_MessageTemplateLocalized] ON
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (114, 13, 7, N'Email validation message isn''t implemented yet', N'Email validation message isn''t implemented yet')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (115, 14, 7, N'%Store.Name%. Password recovery', N'<a href="%Store.URL%"> %Store.Name%</a>
<br>
<br>
To change your password <a href="%Store.URL%/PasswordRecovery.aspx?PRT=%Customer.PasswordRecoveryToken%&Email=%Customer.Email%">click here</a>. 

<br>
<br>
%Store.Name%')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (116, 11, 7, N'Welcome to %Store.Name%', N'We welcome you to <a href="%Store.URL%"> %Store.Name%</a>.<br>
<br>
You can now take part in the various services we have to offer you. Some of these services include:<br>
<br>
Permanent Cart - Any products added to your online cart remain there until you remove them, or check them out.<br>
Address Book - We can now deliver your products to another address other than yours! This is perfect to send birthday gifts direct to the birthday-person themselves.<br>
Order History - View your history of purchases that you have made with us.<br>
Products Reviews - Share your opinions on products with our other customers.<br>

<br>
For help with any of our online services, please email the store-owner: <a href="mailto:%Store.Email%">%Store.Email%</a>.<br>
<br>
Note: This email address was given to us by one of our customers. If you did not signup to be a member, please send an email to <a href="mailto:%Store.Email%">%Store.Email%</a>.<br>
<br>
<br>')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (117, 19, 7, N'%Store.Name%. Your order cancelled', N'<p><a href="%Store.URL%">%Store.Name%</a> <br />
<br />
Hello %Order.CustomerFullName%, <br />
Your order has been cancelled. Below is the summary of the order. <br />
<br />
Order Number: %Order.OrderNumber%<br />
Order Details: <a target="_blank" href="%Order.OrderURLForCustomer%">%Order.OrderURLForCustomer%</a><br />
Date Ordered: %Order.CreatedOn%<br />
<br />
<br />
<br />
Billing Address<br />
%Order.BillingFirstName% %Order.BillingLastName%<br />
%Order.BillingAddress1%<br />
%Order.BillingCity% %Order.BillingZipPostalCode%<br />
%Order.BillingStateProvince% %Order.BillingCountry%<br />
<br />
<br />
<br />
Shipping Address<br />
%Order.ShippingFirstName% %Order.ShippingLastName%<br />
%Order.ShippingAddress1%<br />
%Order.ShippingCity% %Order.ShippingZipPostalCode%<br />
%Order.ShippingStateProvince% %Order.ShippingCountry%<br />
<br />
Shipping Method: %Order.ShippingMethod% </p>')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (118, 6, 7, N'%Store.Name%. Your order completed', N'<p><a href="%Store.URL%">%Store.Name%</a> <br />
<br />
Hello %Order.CustomerFullName%, <br />
Your order has been completed. Below is the summary of the order. <br />
<br />
Order Number: %Order.OrderNumber%<br />
Order Details: <a target="_blank" href="%Order.OrderURLForCustomer%">%Order.OrderURLForCustomer%</a><br />
Date Ordered: %Order.CreatedOn%<br />
<br />
<br />
<br />
Billing Address<br />
%Order.BillingFirstName% %Order.BillingLastName%<br />
%Order.BillingAddress1%<br />
%Order.BillingCity% %Order.BillingZipPostalCode%<br />
%Order.BillingStateProvince% %Order.BillingCountry%<br />
<br />
<br />
<br />
Shipping Address<br />
%Order.ShippingFirstName% %Order.ShippingLastName%<br />
%Order.ShippingAddress1%<br />
%Order.ShippingCity% %Order.ShippingZipPostalCode%<br />
%Order.ShippingStateProvince% %Order.ShippingCountry%<br />
<br />
Shipping Method: %Order.ShippingMethod% </p>')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (119, 18, 7, N'Order receipt from %Store.Name%. ', N'<p><a href="%Store.URL%">%Store.Name%</a> <br />
<br />
Hello %Order.CustomerFullName%, <br />
Thanks for buying from <a href="%Store.URL%">%Store.Name%</a>. Below is the summary of the order. <br />
<br />
Order Number: %Order.OrderNumber%<br />
Order Details: <a target="_blank" href="%Order.OrderURLForCustomer%">%Order.OrderURLForCustomer%</a><br />
Date Ordered: %Order.CreatedOn%<br />
<br />
<br />
<br />
Billing Address<br />
%Order.BillingFirstName% %Order.BillingLastName%<br />
%Order.BillingAddress1%<br />
%Order.BillingCity% %Order.BillingZipPostalCode%<br />
%Order.BillingStateProvince% %Order.BillingCountry%<br />
<br />
<br />
<br />
Shipping Address<br />
%Order.ShippingFirstName% %Order.ShippingLastName%<br />
%Order.ShippingAddress1%<br />
%Order.ShippingCity% %Order.ShippingZipPostalCode%<br />
%Order.ShippingStateProvince% %Order.ShippingCountry%<br />
<br />
Shipping Method: %Order.ShippingMethod% </p>')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (120, 9, 7, N'%Store.Name%. Purchase Receipt for Order #%Order.OrderNumber%', N'<p><a href="%Store.URL%">%Store.Name%</a> <br />
<br />
%Order.CustomerFullName% (%Order.CustomerEmail%) has just placed an order from your store. Below is the summary of the order. <br />
<br />
Order Number: %Order.OrderNumber%<br />
Date Ordered: %Order.CreatedOn%<br />
<br />
<br />
<br />
Billing Address<br />
%Order.BillingFirstName% %Order.BillingLastName%<br />
%Order.BillingAddress1%<br />
%Order.BillingCity% %Order.BillingZipPostalCode%<br />
%Order.BillingStateProvince% %Order.BillingCountry%<br />
<br />
<br />
<br />
Shipping Address<br />
%Order.ShippingFirstName% %Order.ShippingLastName%<br />
%Order.ShippingAddress1%<br />
%Order.ShippingCity% %Order.ShippingZipPostalCode%<br />
%Order.ShippingStateProvince% %Order.ShippingCountry%<br />
<br />
Shipping Method: %Order.ShippingMethod%</p>')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (121, 8, 7, N'Your order from %Store.Name% has been shipped.', N'<p><a href="%Store.URL%"> %Store.Name%</a> <br />
<br />
Hello %Order.CustomerFullName%!, <br />
Good news! You order has been shipped. <br />
Order Number: %Order.OrderNumber%<br />
Order Details: <a href="%Order.OrderURLForCustomer%" target="_blank">%Order.OrderURLForCustomer%</a><br />
Date Ordered: %Order.CreatedOn%<br />
<br />
<br />
<br />
Billing Address<br />
%Order.BillingFirstName% %Order.BillingLastName%<br />
%Order.BillingAddress1%<br />
%Order.BillingCity% %Order.BillingZipPostalCode%<br />
%Order.BillingStateProvince% %Order.BillingCountry%<br />
<br />
<br />
<br />
Shipping Address<br />
%Order.ShippingFirstName% %Order.ShippingLastName%<br />
%Order.ShippingAddress1%<br />
%Order.ShippingCity% %Order.ShippingZipPostalCode%<br />
%Order.ShippingStateProvince% %Order.ShippingCountry%<br />
<br />
Shipping Method: %Order.ShippingMethod% </p>')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (122, 17, 7, N'%Store.Name%. Referred Item', N'<p><a href="%Store.URL%"> %Store.Name%</a> <br />
<br />
%Customer.Email% was shopping on %Store.Name% and wanted to share the following item with you. <br />
<br />
<b><a target="_blank" href="%Product.ProductURLForCustomer%">%Product.Name%</a></b> <br />
%Product.ShortDescription% <br />
<br />
For more info click <a target="_blank" href="%Product.ProductURLForCustomer%">here</a> <br />
<br />
<br />
%EmailAFriend.PersonalMessage%<br />
<br />
%Store.Name%</p>')
INSERT [dbo].[Nop_MessageTemplateLocalized] ([MessageTemplateLocalizedID], [MessageTemplateID], [LanguageID], [Subject], [Body]) VALUES (213, 21, 7, N'%Store.Name%. Quantity below notification. %ProductVariant.FullProductName%', N'<p><a href="%Store.URL%">%Store.Name%</a> <br />
	<br />
	%ProductVariant.FullProductName% (ID: %ProductVariant.ID%) low quantity. <br />
	<br />
	Quantity: %ProductVariant.StockQuantity%<br /></p>')
SET IDENTITY_INSERT [dbo].[Nop_MessageTemplateLocalized] OFF
GO




SET IDENTITY_INSERT [dbo].[Nop_Address] ON
INSERT [dbo].[Nop_Address] ([AddressId], [CustomerID], [IsBillingAddress], [FirstName], [LastName], [PhoneNumber], [Email], [FaxNumber], [Company], [Address1], [Address2], [City], [StateProvinceID], [ZipPostalCode], [CountryID], [CreatedOn]) VALUES (77, 37, 0, N'Andrei', N'Mazoulnitsyn', N'+7 9038281433', N'am@nopCommerce.com', N'', N'Nop Solutions', N'1-ya Portovaya, 21, 164', N'', N'Yaroslavl', 0, N'150022', 66, CAST(0x00009BE3014ADFF5 AS DateTime))
INSERT [dbo].[Nop_Address] ([AddressId], [CustomerID], [IsBillingAddress], [FirstName], [LastName], [PhoneNumber], [Email], [FaxNumber], [Company], [Address1], [Address2], [City], [StateProvinceID], [ZipPostalCode], [CountryID], [CreatedOn]) VALUES (78, 37, 1, N'Andrei', N'Mazoulnitsyn', N'+7 9038281433', N'am@nopCommerce.com', N'', N'Nop Solutions', N'1-ya Portovaya, 21, 164', N'', N'Yaroslavl', 0, N'150022', 66, CAST(0x00009BE3014AED91 AS DateTime))
SET IDENTITY_INSERT [dbo].[Nop_Address] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_CustomerAttribute] ON
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (181, 37, N'Gender', N'M')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (182, 37, N'FirstName', N'John')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (183, 37, N'LastName', N'Smith')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (184, 37, N'DateOfBirth', N'<?xml version="1.0" encoding="utf-16"?>
<dateTime>1983-02-18T00:00:00</dateTime>')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (185, 37, N'Company', N'nopCommerce.com')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (186, 37, N'StreetAddress', N'21 West 52nd Street')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (187, 37, N'StreetAddress2', N'')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (188, 37, N'ZipPostalCode', N'10021')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (189, 37, N'City', N'New York')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (190, 37, N'PhoneNumber', N'12345678')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (192, 37, N'CountryID', N'1')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (193, 37, N'StateProvinceID', N'41')
INSERT [dbo].[Nop_CustomerAttribute] ([CustomerAttributeId], [CustomerId], [Key], [Value]) VALUES (311, 37, N'Newsletter', N'True')
SET IDENTITY_INSERT [dbo].[Nop_CustomerAttribute] OFF
GO


SET IDENTITY_INSERT [dbo].[Nop_LocaleStringResource] ON
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3818, 7, N'Account.AddBillingAddress', N'Add billing address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3819, 7, N'Account.AddShippingAddress', N'Add shipping address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3820, 7, N'Account.Administration', N'Administration')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3821, 7, N'Account.BillingAddressBookEntries', N'Billing Address Book Entries')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3822, 7, N'Account.ChangePassword', N'Change Password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3823, 7, N'Account.ChangePasswordButton', N'Change password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3824, 7, N'Account.City', N'City')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3825, 7, N'Account.CityIsRequired', N'City is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3826, 7, N'Account.CompanyDetails', N'Company Details')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3827, 7, N'Account.CompanyName', N'Company Name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3828, 7, N'Account.ConfirmPasswordIsRequired', N'Confirm password is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3829, 7, N'Account.Country', N'Country')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3830, 7, N'Account.CustomerAddresses', N'Customer Addresses')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3831, 7, N'Account.CustomerInfo', N'Customer Info')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3832, 7, N'Account.CustomerOrders', N'Customer Orders')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3833, 7, N'Account.DateOfBirth', N'Date of Birth')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3834, 7, N'Account.E-Mail', N'E-Mail')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3835, 7, N'Account.EnteredPasswordsDoNotMatch', N'Entered passwords do not match')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3836, 7, N'Account.FaxNumber', N'Fax Number')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3837, 7, N'Account.FirstName', N'First Name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3838, 7, N'Account.FirstNameIsRequired', N'First name is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3839, 7, N'Account.Gender', N'Gender')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3840, 7, N'Account.GenderFemale', N'Female')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3841, 7, N'Account.GenderMale', N'Male')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3842, 7, N'Account.LastName', N'Last Name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3843, 7, N'Account.LastNameIsRequired', N'Last name is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3844, 7, N'Account.Login', N'Log in')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3845, 7, N'Account.Logout', N'Log out')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3846, 7, N'Account.MyAccount', N'My account')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3847, 7, N'Account.NewPassword', N'Password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3848, 7, N'Account.NewPasswordConfirmation', N'New Password Confirmation')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3849, 7, N'Account.NewPasswordIsRequired', N'New password is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3850, 7, N'Account.Newsletter', N'I would like to receive newsletters')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3851, 7, N'Account.OldPassword', N'Old Password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3852, 7, N'Account.OldPasswordIsRequired', N'Old password is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3853, 7, N'Account.Options', N'Options')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3854, 7, N'Account.OrderDate', N'Order Date')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3855, 7, N'Account.OrderNumber', N'Order Number')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3856, 7, N'Account.OrderTotal', N'Order Total')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3857, 7, N'Account.Password', N'Password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3858, 7, N'Account.PasswordConfirmation', N'Password Confirmation')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3859, 7, N'Account.PasswordHasBeenChanged', N'Your password has been changed')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3860, 7, N'Account.PasswordRecovery.EmailHasBeenSent', N'Email with instructions has been sent to you.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3861, 7, N'Account.PasswordRecovery.EnterNewPassword', N'Enter new password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3862, 7, N'Account.PasswordRecovery.NewPasswordSubmit', N'Submit')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3863, 7, N'Account.PasswordRecovery.RecoverButton', N'Recover')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3864, 7, N'Account.PasswordWasChanged', N'Password was changed')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3865, 7, N'Account.PhoneNumberIsRequired', N'Telephone Number is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3866, 7, N'Account.PostCode', N'Post Code')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3867, 7, N'Account.Register', N'Register')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3868, 7, N'Account.RegisterContinueButton', N'Continue')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3869, 7, N'Account.RegisterNextStepButton', N'Register')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3870, 7, N'Account.Registration', N'Registration')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3871, 7, N'Account.RegistrationCompleted', N'Your registration completed')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3872, 7, N'Account.ResetYourPassword', N'Reset your password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3873, 7, N'Account.Save', N'Save')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3874, 7, N'Account.ShippingAddressBookEntries', N'Shipping Address Book Entries')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3875, 7, N'Account.ShoppingCart', N'Shopping Cart')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3876, 7, N'Account.StateProvince', N'State/Province')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3877, 7, N'Account.StreetAddress', N'Street Address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3878, 7, N'Account.StreetAddress2', N'Street Address 2')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3879, 7, N'Account.StreetAddressIsRequired', N'Street address is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3880, 7, N'Account.TelephoneNumber', N'Telephone Number')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3881, 7, N'Account.WrongEmailFormat', N'Wrong email format')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3882, 7, N'Account.YourAddress', N'Your Address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3883, 7, N'Account.YourContactInformation', N'Your Contact Information')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3884, 7, N'Account.YourPassword', N'Your Password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3885, 7, N'Account.YourPersonalDetails', N'Your Personal Details')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3886, 7, N'Account.ZipPostalCodeIsRequired', N'Zip / Postal code is required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3887, 7, N'Address.AddAddress', N'Add address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3888, 7, N'Address.Address1', N'Address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3889, 7, N'Address.Address2', N'Address 2')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3890, 7, N'Address.City', N'City')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3891, 7, N'Address.Company', N'Company')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3892, 7, N'Address.Country', N'Country')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3893, 7, N'Address.Delete', N'Delete')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3894, 7, N'Address.Edit', N'Edit')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3895, 7, N'Address.Email', N'Email')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3896, 7, N'Address.Fax', N'Fax')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3897, 7, N'Address.FaxNumber', N'Fax number')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3898, 7, N'Address.FirstName', N'First name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3899, 7, N'Address.LastName', N'Last name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3900, 7, N'Address.NewAddressTitle', N'New Address Book Entry')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3901, 7, N'Address.Phone', N'Phone')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3902, 7, N'Address.PhoneNumber', N'Phone number')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3903, 7, N'Address.StateProvince', N'State / province')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3904, 7, N'Address.StateProvinceNonUS', N'Other (Non US)')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3905, 7, N'Address.UpdateAddress', N'Update address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3906, 7, N'Address.UpdateAddressTitle', N'Update Address Book Entry')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3907, 7, N'Address.ZipPostalCode', N'Zip / postal code')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3908, 7, N'Blog.Blog', N'Blog')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3909, 7, N'Blog.CommentCreatedOn', N'Created on')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3910, 7, N'Blog.CommentFrom', N'From')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3911, 7, N'Blog.Comments', N'Comments')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3912, 7, N'Blog.CommentsLink', N'Comments ({0:d})')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3913, 7, N'Blog.CommentText', N'Comment text')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3914, 7, N'Blog.LeaveYourComment', N'Leave your comment')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3915, 7, N'Blog.NewCommentButton', N'New comment')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3916, 7, N'Breadcrumb.Top', N'Top')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3917, 7, N'Captcha.EnterTheCode', N'Enter the code shown above:')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3918, 7, N'Captcha.Incorrect', N'Incorrect, try again.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3919, 7, N'Category.Categories', N'Categories')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3920, 7, N'Checkout.BillingAddress', N'Billing address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3921, 7, N'Checkout.BillingAddressTheSameAsShippingAddress', N'Use the same as shipping address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3922, 7, N'Checkout.BillingToThisAddress', N'Billing to this address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3923, 7, N'Checkout.ConfirmButton', N'Confirm')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3924, 7, N'Checkout.ConfirmYourOrder', N'Confirm your order')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3925, 7, N'Checkout.Continue', N'Continue')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3926, 7, N'Checkout.EnterBillingAddress', N'Enter billing address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3927, 7, N'Checkout.EnterShippingAddress', N'Enter shipping address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3928, 7, N'Checkout.NextButton', N'Next')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3929, 7, N'Checkout.NoPaymentMethods', N'No payment methods available')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3930, 7, N'Checkout.OrderNumber', N'Order number')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3931, 7, N'Checkout.OrderSummary', N'Order summary')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3932, 7, N'Checkout.OrEnterNewAddress', N'Or enter new address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3933, 7, N'Checkout.PaymentInfo', N'Payment Info')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3934, 7, N'Checkout.SelectBillingAddress', N'Select billing address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3935, 7, N'Checkout.SelectPaymentMethod', N'Select Payment Method')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3936, 7, N'Checkout.SelectShippingAddress', N'Select shipping address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3937, 7, N'Checkout.SelectShippingMethod', N'Select Shipping Method')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3938, 7, N'Checkout.ShippingAddress', N'Shipping address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3939, 7, N'Checkout.ShippingIsNotAllowed', N'Shipping is not allowed')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3940, 7, N'Checkout.ShipToThisAddress', N'Ship to this address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3941, 7, N'Checkout.ThankYou', N'Thank you')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3942, 7, N'Checkout.YourOrderHasBeenSuccessfullyProcessed', N'Your order has been successfully processed!')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3943, 7, N'Common.Details', N'Details')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3944, 7, N'Common.No', N'No')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3945, 7, N'Common.Yes', N'Yes')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3946, 7, N'ContactUs.ContactUs', N'Contact Us')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3947, 7, N'ContactUs.ContactUsButton', N'Submit')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3948, 7, N'ContactUs.E-MailAddress', N'E-Mail Address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3949, 7, N'ContactUs.Enquiry', N'Enquiry')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3950, 7, N'ContactUs.FullName', N'Full Name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3951, 7, N'ContactUs.YourEnquiryHasBeenSent', N'Your enquiry has been successfully sent to the store owner.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3952, 7, N'Content.ConditionsOfUse', N'Conditions of Use')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3953, 7, N'Content.HomePage', N'Home page')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3954, 7, N'Content.Information', N'Information')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3955, 7, N'Content.PrivacyNotice', N'Privacy Notice')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3956, 7, N'Content.Shipping&Returns', N'Shipping & Returns')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3957, 7, N'Customer.NotRegistered', N'Not registered')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3958, 7, N'Login.E-MailAddress', N'E-Mail Address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3959, 7, N'Login.FailureText', N'Your login attempt was not successful. Please try again.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3960, 7, N'Login.LoginButton', N'Log in')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3961, 7, N'Login.NewCustomer', N'New Customer')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3962, 7, N'Login.NewCustomerText', N'By creating an account at nopCommerce you will be able to shop faster, be up to date on an orders status, and keep track of the orders you have previously made.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3963, 7, N'Login.Password', N'Password')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3964, 7, N'Login.RememberMe', N'Remember me')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3965, 7, N'Login.ReturningCustomer', N'Returning Customer')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3966, 7, N'Login.Welcome', N'Welcome, Please Sign In!')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3967, 7, N'Manufacturer.Manufacturers', N'Manufacturers')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3968, 7, N'MoneybookersPaymentModule.Message', N'You will be redirected to Moneybookers site to complete the order.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3969, 7, N'News.CommentCreatedOn', N'Created on')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3970, 7, N'News.CommentFrom', N'From')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3971, 7, N'News.Comments', N'Comments')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3972, 7, N'News.CommentText', N'Comment')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3973, 7, N'News.CommentTitle', N'Comment title')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3974, 7, N'News.LeaveYourComment', N'Leave your comment')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3975, 7, N'News.MoreInfo', N'details')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3976, 7, N'News.NewCommentButton', N'New comment')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3977, 7, N'News.News', N'News')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3978, 7, N'Order.BillingAddress', N'Billing Address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3979, 7, N'Order.BillingInformation', N'Billing Information')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3980, 7, N'Order.Download', N'Download')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3981, 7, N'Order.Email', N'Email')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3982, 7, N'Order.Fax', N'Fax')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3983, 7, N'Order.NotYetShipped', N'Not yet')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3984, 7, N'Order.Order#', N'Order #')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3985, 7, N'Order.OrderDate', N'Order Date')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3986, 7, N'Order.OrderInformation', N'Order information')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3987, 7, N'Order.OrderStatus', N'Order Status:')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3988, 7, N'Order.OrderTotal', N'Order Total')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3989, 7, N'Order.PaymentMethod', N'Payment Method')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3990, 7, N'Order.Phone', N'Phone')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3991, 7, N'Order.Product(s)', N'Product(s)')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3992, 7, N'Order.ProductsGrid.Download', N'Download')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3993, 7, N'Order.ProductsGrid.Name', N'Name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3994, 7, N'Order.ProductsGrid.Price', N'Price')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3995, 7, N'Order.ProductsGrid.Quantity', N'Quantity')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3996, 7, N'Order.ShippedOn', N'Shipped On')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3997, 7, N'Order.Shipping', N'Shipping')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3998, 7, N'Order.ShippingAddress', N'Shipping Address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (3999, 7, N'Order.ShippingMethod', N'Shipping Method')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4000, 7, N'Order.Sub-Total', N'Sub-Total')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4001, 7, N'Order.Tax', N'Tax')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4002, 7, N'Order.Weight', N'Weight')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4003, 7, N'Payment.CardCode', N'Card code')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4004, 7, N'Payment.CardholderName', N'Cardholder name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4005, 7, N'Payment.CardNumber', N'Card number')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4006, 7, N'Payment.ExpirationDate', N'Expiration date')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4007, 7, N'Payment.PONumber', N'PO Number')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4008, 7, N'Payment.SelectCreditCard', N'Select credit card')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4009, 7, N'PayPalStandardPaymentModule.Message', N'You will be redirected to PayPal site to complete the order.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4010, 7, N'Polls.SelectAnOption', N'Select an option.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4011, 7, N'Polls.SubmitVoteRecordButton', N'Vote')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4012, 7, N'Polls.TodaysPoll', N'Today''s Poll')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4013, 7, N'Polls.TotalVotes', N'{0:d} votes...')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4014, 7, N'Polls.votes', N'votes')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4015, 7, N'Products.AddToCart', N'Add to cart')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4016, 7, N'Products.AddToCompareList', N'Add to compare list')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4017, 7, N'Products.CompareProducts', N'Compare products')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4018, 7, N'Products.CompareProductsClearList', N'Clear list')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4019, 7, N'Products.CompareProductsList', N'Compare products list')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4020, 7, N'Products.CompareProductsPrice', N'Price')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4021, 7, N'Products.CompareProductsRemoveFromList', N'Remove')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4022, 7, N'Products.CurrentRating', N'Current rating is {0}. Total votes {1}.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4023, 7, N'Products.DiscountAmount', N'Discount:')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4024, 7, N'Products.EmailAFriend', N'Email a friend')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4025, 7, N'Products.EmailAFriend.PersonalMessage', N'Personal Message')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4026, 7, N'Products.EmailAFriend.YourEmailAddress', N'Your Email address')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4027, 7, N'Products.EmailAFriend.YourMessageHasBeenSent', N'Your message has been sent.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4028, 7, N'Products.EmailAFriendButton', N'Send email')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4029, 7, N'Products.EnterQuantity', N'Enter quantity')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4030, 7, N'Products.FeaturedProducts', N'Featured products')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4031, 7, N'Products.FinalPriceWithDiscount', N'Your price:')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4032, 7, N'Products.FinalPriceWithoutDiscount', N'Price:')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4033, 7, N'Products.FriendEmail', N'Friend''s Email')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4034, 7, N'Products.NewProducts', N'New products')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4035, 7, N'Products.OldPrice', N'Old price:')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4036, 7, N'Products.OnlyRegisteredUsersCanEmailAFriend', N'Only registered customers can use email a friend feature')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4037, 7, N'Products.OnlyRegisteredUsersCanRating', N'Only registered users can rating')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4038, 7, N'Products.OnlyRegisteredUsersCanWriteReviews', N'Only registered users can write reviews')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4039, 7, N'Products.ProductDetails', N'Details')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4040, 7, N'Products.ProductReviewCreatedOn', N'Created on')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4041, 7, N'Products.ProductReviewFrom', N'From')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4042, 7, N'Products.ProductReviews', N'Product reviews')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4043, 7, N'Products.ProductSpecs', N'Product Specifications')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4044, 7, N'Products.QuantityRange', N'The value must be from 1 to 9999')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4045, 7, N'Products.RatingWillBeUpdatedVerySoon', N'Thank you. Rating will be updated very soon.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4046, 7, N'Products.RecentlyViewedProducts', N'Recently viewed products')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4047, 7, N'Products.RelatedProducts', N'Related products')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4048, 7, N'Products.ReviewButton', N'Review')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4049, 7, N'Products.ReviewText', N'Review text')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4050, 7, N'Products.ReviewTitle', N'Review title')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4051, 7, N'Products.SelectAttribute', N'[Please select {0}]')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4052, 7, N'Products.WasThisReviewHelpful?', N'Was this review helpful?')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4053, 7, N'Products.WriteReview', N'Write review')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4054, 7, N'Products.WriteReview.Rating', N'Rating')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4055, 7, N'Products.WriteReview.RatingBad', N'Bad')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4056, 7, N'Products.WriteReview.RatingExcellent', N'Excellent')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4057, 7, N'Products.You''llSeeYourProductReviewAfterApprovingByStoreAdministrator', N'You''ll see your product review after approving by store administrator.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4058, 7, N'Search.ProductsGrid.Name', N'Name')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4059, 7, N'Search.Search', N'Search')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4060, 7, N'Search.SearchButton', N'Search')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4061, 7, N'Search.SearchInProductDescriptions', N'Search In Product Descriptions')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4062, 7, N'Search.SearchTermCouldNotBeEmpty', N'Search term could not be empty')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4063, 7, N'Search.SearchTermMinimumLengthIs3Characters', N'Search term minimum length is 3 characters')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4064, 7, N'ShoppingCart.ApplyCouponCode', N'Apply coupon code')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4065, 7, N'ShoppingCart.CalculatedDuringCheckout', N'Calculated during checkout')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4066, 7, N'ShoppingCart.CartIsEmpty', N'Your Shopping Cart is empty!')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4067, 7, N'ShoppingCart.Checkout', N'Checkout')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4068, 7, N'ShoppingCart.ContinueShopping', N'Continue')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4069, 7, N'ShoppingCart.CouponCode', N'Coupon code:')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4070, 7, N'ShoppingCart.ItemTotal', N'Total')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4071, 7, N'ShoppingCart.ItemYouSave', N'You save:')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4072, 7, N'ShoppingCart.OrderTotal', N'Total')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4073, 7, N'ShoppingCart.Product(s)', N'Product(s)')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4074, 7, N'ShoppingCart.Quantity', N'Qty.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4075, 7, N'ShoppingCart.Remove', N'Remove')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4076, 7, N'ShoppingCart.SelectAttribute', N'Please select {0}')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4077, 7, N'ShoppingCart.Shipping', N'Shipping')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4078, 7, N'ShoppingCart.ShippingNotRequired', N'Not required')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4079, 7, N'ShoppingCart.Sub-Total', N'Sub-Total')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4080, 7, N'ShoppingCart.Sub-TotalDiscount', N'Discount')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4081, 7, N'ShoppingCart.Tax', N'Tax')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4082, 7, N'ShoppingCart.UpdateCart', N'Update cart')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4083, 7, N'TwoCheckoutPaymentModule.Message', N'You will be redirected to 2Checkout site to complete the order.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4084, 7, N'Wishlist.AddToWishlist', N'Add to wishlist')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4085, 7, N'Wishlist.ItemTotal', N'Total')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4086, 7, N'Wishlist.Product(s)', N'Product(s)')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4087, 7, N'Wishlist.Quantity', N'Qty.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4088, 7, N'Wishlist.Remove', N'Remove')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4089, 7, N'Wishlist.UpdateWishlist', N'Update wishlist')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4090, 7, N'Wishlist.Wishlist', N'Wishlist')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4091, 7, N'Wishlist.WishlistIsEmpty', N'Wishlist is empty!')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4092, 7, N'Wishlist.WishlistOf', N'Wishlist of {0} ({1})')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4093, 7, N'Wishlist.YourWishlist', N'Your wishlist')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4094, 7, N'Wishlist.YourWishlistURL', N'Your wishlist URL for sharing: ')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (4095, 7, N'WorldpayPaymentModule.Message', N'You will be redirected to Worldpay site to complete the order.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6876, 7, N'Pager.First', N'First')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6877, 7, N'Pager.Last', N'Last')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6878, 7, N'Pager.Next', N'Next')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6879, 7, N'Pager.Previous', N'Previous')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6880, 7, N'Pager.CurrentPage', N'Page {0} of {1} ({2} total)')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6881, 7, N'Search.NoResultsText', N'No products were found that matched your criteria.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6882, 7, N'Common.PriceRangeFilter', N'Filter by price')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6883, 7, N'Products.PriceRangeFromText', N'From {0}')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6884, 7, N'Common.PriceRangeFilter.Under', N'Under {0}')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6887, 7, N'Common.PriceRangeFilter.Over', N'Over {0}')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6889, 7, N'ShoppingCart.MinimumQuantity', N'The minimum quantity allowed for purchase is {0}.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6891, 7, N'ShoppingCart.MaximumQuantity', N'The maximum quantity allowed for purchase is {0}.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6893, 7, N'ShoppingCart.TextOptionIsRequired', N'Text option is required. {0}')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6894, 7, N'Products.FilterOptionsTitle', N'Filter your results')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6895, 7, N'Common.PriceRangeFilterRemove', N'Remove Filter')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6896, 7, N'ShoppingCart.QuantityExceedsStock', N'Your quantity exceeds stock on hand. The maximum quantity that can be added is {0}.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6897, 7, N'Checkout.OrderCompleted.Details', N'Click here for order details.')
INSERT [dbo].[Nop_LocaleStringResource] ([LocaleStringResourceID], [LanguageID], [ResourceName], [ResourceValue]) VALUES (6898, 7, N'Login.ForgotPassword', N'Forgot password?')
SET IDENTITY_INSERT [dbo].[Nop_LocaleStringResource] OFF
GO