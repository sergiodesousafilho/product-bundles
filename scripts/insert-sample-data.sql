USE [product_bundles]
GO
SET IDENTITY_INSERT [dbo].[Bundle] ON 
GO
INSERT [dbo].[Bundle] ([Id], [Name], [Description]) VALUES (5, N'Wheel', N'Bicycle wheel')
GO
INSERT [dbo].[Bundle] ([Id], [Name], [Description]) VALUES (6, N'Bicycle', N'Human-powered vehicle for one person')
GO
SET IDENTITY_INSERT [dbo].[Bundle] OFF
GO
SET IDENTITY_INSERT [dbo].[BundleRelation] ON 
GO
INSERT [dbo].[BundleRelation] ([Id], [Amount], [ParentBundleId], [ChildBundleId]) VALUES (1, 2, 6, 5)
GO
SET IDENTITY_INSERT [dbo].[BundleRelation] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Name], [Amount]) VALUES (1, N'Break', 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Amount]) VALUES (2, N'Hub', 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Amount]) VALUES (3, N'Spoke', 120)
GO
INSERT [dbo].[Product] ([Id], [Name], [Amount]) VALUES (4, N'Rim', 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Amount]) VALUES (5, N'Saddle', 2)
GO
INSERT [dbo].[Product] ([Id], [Name], [Amount]) VALUES (6, N'Frame', 2)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[BundleProduct] ON 
GO
INSERT [dbo].[BundleProduct] ([Id], [BundleId], [ProductId], [Amount]) VALUES (9, 5, 4, 1)
GO
INSERT [dbo].[BundleProduct] ([Id], [BundleId], [ProductId], [Amount]) VALUES (10, 5, 2, 1)
GO
INSERT [dbo].[BundleProduct] ([Id], [BundleId], [ProductId], [Amount]) VALUES (11, 5, 3, 30)
GO
INSERT [dbo].[BundleProduct] ([Id], [BundleId], [ProductId], [Amount]) VALUES (12, 6, 1, 2)
GO
INSERT [dbo].[BundleProduct] ([Id], [BundleId], [ProductId], [Amount]) VALUES (13, 6, 5, 1)
GO
INSERT [dbo].[BundleProduct] ([Id], [BundleId], [ProductId], [Amount]) VALUES (14, 6, 6, 1)
GO
SET IDENTITY_INSERT [dbo].[BundleProduct] OFF
GO
