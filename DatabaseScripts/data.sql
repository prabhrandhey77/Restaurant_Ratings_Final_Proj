SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([Id], [Email], [Name]) VALUES (1, N'jack@gmail.com', N'Jack Ryan')
INSERT INTO [dbo].[Customer] ([Id], [Email], [Name]) VALUES (2, N'kevin@gmail.com', N'Kevin Nash')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Restaurant] ON
INSERT INTO [dbo].[Restaurant] ([Id], [RegistredName], [Since], [Address], [Description]) VALUES (1, N'Dine More Restaurant', N'2020-10-01 00:00:00', N'240 Queen Street, Auckland 1010', NULL)
INSERT INTO [dbo].[Restaurant] ([Id], [RegistredName], [Since], [Address], [Description]) VALUES (2, N'Good Food Restaurant', N'2020-10-01 00:00:00', N'150 Victoria Street, Auckland 1010', NULL)
SET IDENTITY_INSERT [dbo].[Restaurant] OFF
SET IDENTITY_INSERT [dbo].[Rating] ON
INSERT INTO [dbo].[Rating] ([Id], [CustomerId], [RestaurantId], [RatingValue], [Comment]) VALUES (1, 1, 2, CAST(5.00 AS Decimal(18, 2)), N'Excellent service and great food')
INSERT INTO [dbo].[Rating] ([Id], [CustomerId], [RestaurantId], [RatingValue], [Comment]) VALUES (2, 1, 1, CAST(4.00 AS Decimal(18, 2)), N'Great service . Food is good but limited options')
INSERT INTO [dbo].[Rating] ([Id], [CustomerId], [RestaurantId], [RatingValue], [Comment]) VALUES (3, 2, 2, CAST(4.00 AS Decimal(18, 2)), N'Overall good however the service is inconsistent some times')
INSERT INTO [dbo].[Rating] ([Id], [CustomerId], [RestaurantId], [RatingValue], [Comment]) VALUES (4, 2, 1, CAST(3.00 AS Decimal(18, 2)), N'Food is good. Not satisfied with the service as its too slow')
SET IDENTITY_INSERT [dbo].[Rating] OFF
