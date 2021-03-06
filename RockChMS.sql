USE [IgniteChMS]
GO
/****** Object:  Table [dbo].[cmsSite]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cmsSite]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cmsSite](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Theme] [varchar](100) NULL,
	[DefaultPageId] [int] NULL,
 CONSTRAINT [PK_cmsSite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cmsSiteDomain]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cmsSiteDomain]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cmsSiteDomain](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[SiteId] [int] NOT NULL,
	[Domain] [varchar](200) NOT NULL,
 CONSTRAINT [PK_cmsSiteDomain] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cmsPage]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cmsPage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cmsPage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[ParentPageId] [int] NULL,
	[SiteId] [int] NULL,
	[Layout] [varchar](100) NULL,
	[Order] [int] NOT NULL,
	[OutputCacheDuration] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_cmsPage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cmsPageRoute]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cmsPageRoute]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cmsPageRoute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[PageId] [int] NOT NULL,
	[Route] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_cmsPageRoute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[membershipPerson]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[membershipPerson]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[membershipPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[NickName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_membershipPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[groupsRole]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupsRole]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groupsRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Order] [int] NULL,
 CONSTRAINT [PK_groupsRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[groupsGroupType]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupsGroupType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groupsGroupType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_groupsType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[coreFieldType]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coreFieldType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[coreFieldType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Assembly] [varchar](100) NOT NULL,
	[Class] [varchar](100) NOT NULL,
 CONSTRAINT [PK_coreFieldType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[coreEntityChange]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coreEntityChange]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[coreEntityChange](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[ChangeSet] [uniqueidentifier] NOT NULL,
	[ChangeType] [varchar](10) NOT NULL,
	[EntityType] [varchar](100) NOT NULL,
	[EntityId] [int] NOT NULL,
	[Property] [varchar](100) NOT NULL,
	[OriginalValue] [nvarchar](max) NULL,
	[CurrentValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_coreEntityChange] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cmsBlock]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cmsBlock]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cmsBlock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[Path] [varchar](200) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_cmsBlock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cmsPageBlock]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cmsPageBlock]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cmsPageBlock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[PageId] [int] NOT NULL,
	[BlockId] [int] NOT NULL,
	[Zone] [varchar](100) NOT NULL,
	[Order] [int] NOT NULL,
	[OutputCacheDuration] [int] NOT NULL,
 CONSTRAINT [PK_cmsPageBlock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cmsLayoutBlock]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cmsLayoutBlock]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cmsLayoutBlock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [int] NOT NULL,
	[BlockId] [int] NOT NULL,
	[Layout] [varchar](100) NOT NULL,
	[Zone] [varchar](100) NULL,
	[Order] [int] NOT NULL,
	[OutputCacheDuration] [int] NOT NULL,
 CONSTRAINT [PK_cmsLayoutBlock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[coreAttributeType]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coreAttributeType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[coreAttributeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[FieldTypeId] [int] NOT NULL,
	[FieldTypeQualifier] [varchar](100) NULL,
	[Entity] [varchar](50) NOT NULL,
	[EntityQualifier] [varchar](50) NULL,
	[EntityQualifierId] [int] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Order] [int] NOT NULL,
	[GridColumn] [bit] NOT NULL,
	[MultipleValues] [bit] NOT NULL,
 CONSTRAINT [PK_coreAttributeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[groupsGroup]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupsGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groupsGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[ParentGroupId] [int] NULL,
	[GroupTypeId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_groupsGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[groupsGroupTypeAssociation]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeAssociation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groupsGroupTypeAssociation](
	[ParentGroupTypeId] [int] NOT NULL,
	[ChildGroupTypeId] [int] NOT NULL,
 CONSTRAINT [PK_groupsGroupTypeAssociation] PRIMARY KEY CLUSTERED 
(
	[ParentGroupTypeId] ASC,
	[ChildGroupTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[coreDefinedType]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coreDefinedType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[coreDefinedType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[FieldTypeId] [int] NULL,
	[Order] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_coreDefinedType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[groupsGroupTypeRole]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeRole]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groupsGroupTypeRole](
	[GroupTypeId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_groupsTypeRoles] PRIMARY KEY CLUSTERED 
(
	[GroupTypeId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[groupsGroupTypeAssociationV]    Script Date: 02/01/2011 07:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeAssociationV]'))
EXEC dbo.sp_executesql @statement = N'-- This view is required because Entity Framework has a bug
-- that does not allow you to specify the correct column names
-- on a many-to-many relationship with a self-referencing table.
create VIEW [dbo].[groupsGroupTypeAssociationV]

AS
	
	SELECT 
		ParentGroupTypeId as GroupTypeId,
		ChildGroupTypeId as GroupTypeId1
	FROM
		groupsGroupTypeAssociation
'
GO
/****** Object:  Table [dbo].[groupsMember]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupsMember]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groupsMember](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[GroupId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_groupsMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[coreAttributeValue]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coreAttributeValue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[coreAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[AttributeTypeId] [int] NOT NULL,
	[EntityId] [int] NOT NULL,
	[Value] [nvarchar](max) NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_coreAttributeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[coreDefinedValue]    Script Date: 02/01/2011 07:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coreDefinedValue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[coreDefinedValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[DefinedTypeId] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_coreDefinedValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Default [DF_cmsBlock_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsBlock_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsBlock]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsBlock_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsBlock] ADD  CONSTRAINT [DF_cmsBlock_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_cmsBlock_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsBlock_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsBlock]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsBlock_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsBlock] ADD  CONSTRAINT [DF_cmsBlock_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_cmsLayoutBlock_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsLayoutBlock_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsLayoutBlock]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsLayoutBlock_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsLayoutBlock] ADD  CONSTRAINT [DF_cmsLayoutBlock_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_cmsLayoutBlock_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsLayoutBlock_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsLayoutBlock]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsLayoutBlock_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsLayoutBlock] ADD  CONSTRAINT [DF_cmsLayoutBlock_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_cmsLayoutBlock_CacheDuration]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsLayoutBlock_CacheDuration]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsLayoutBlock]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsLayoutBlock_CacheDuration]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsLayoutBlock] ADD  CONSTRAINT [DF_cmsLayoutBlock_CacheDuration]  DEFAULT ((0)) FOR [OutputCacheDuration]
END


End
GO
/****** Object:  Default [DF_cmsPage_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsPage_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPage]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsPage_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsPage] ADD  CONSTRAINT [DF_cmsPage_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_cmsPage_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsPage_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPage]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsPage_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsPage] ADD  CONSTRAINT [DF_cmsPage_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_cmsPage_CacheDuration]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsPage_CacheDuration]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPage]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsPage_CacheDuration]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsPage] ADD  CONSTRAINT [DF_cmsPage_CacheDuration]  DEFAULT ((0)) FOR [OutputCacheDuration]
END


End
GO
/****** Object:  Default [DF_cmsPageBlock_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsPageBlock_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageBlock]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsPageBlock_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsPageBlock] ADD  CONSTRAINT [DF_cmsPageBlock_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_cmsPageBlock_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsPageBlock_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageBlock]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsPageBlock_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsPageBlock] ADD  CONSTRAINT [DF_cmsPageBlock_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_cmsPageBlock_CacheDuration]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsPageBlock_CacheDuration]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageBlock]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsPageBlock_CacheDuration]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsPageBlock] ADD  CONSTRAINT [DF_cmsPageBlock_CacheDuration]  DEFAULT ((0)) FOR [OutputCacheDuration]
END


End
GO
/****** Object:  Default [DF_cmsPageRoute_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsPageRoute_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageRoute]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsPageRoute_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsPageRoute] ADD  CONSTRAINT [DF_cmsPageRoute_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_cmsPageRoute_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsPageRoute_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageRoute]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsPageRoute_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsPageRoute] ADD  CONSTRAINT [DF_cmsPageRoute_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_cmsSite_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsSite_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsSite]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsSite_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsSite] ADD  CONSTRAINT [DF_cmsSite_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_cmsSite_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsSite_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsSite]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsSite_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsSite] ADD  CONSTRAINT [DF_cmsSite_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_cmsSiteDomain_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsSiteDomain_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsSiteDomain]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsSiteDomain_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsSiteDomain] ADD  CONSTRAINT [DF_cmsSiteDomain_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_cmsSiteDomain_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cmsSiteDomain_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsSiteDomain]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cmsSiteDomain_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cmsSiteDomain] ADD  CONSTRAINT [DF_cmsSiteDomain_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_coreAttributeType_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreAttributeType_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreAttributeType_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreAttributeType] ADD  CONSTRAINT [DF_coreAttributeType_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_coreAttributeType_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreAttributeType_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreAttributeType_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreAttributeType] ADD  CONSTRAINT [DF_coreAttributeType_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_coreAttributeType_GridColumn]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreAttributeType_GridColumn]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreAttributeType_GridColumn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreAttributeType] ADD  CONSTRAINT [DF_coreAttributeType_GridColumn]  DEFAULT ((0)) FOR [GridColumn]
END


End
GO
/****** Object:  Default [DF_coreAttributeType_MultipleValues]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreAttributeType_MultipleValues]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreAttributeType_MultipleValues]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreAttributeType] ADD  CONSTRAINT [DF_coreAttributeType_MultipleValues]  DEFAULT ((0)) FOR [MultipleValues]
END


End
GO
/****** Object:  Default [DF_coreAttributeValue_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreAttributeValue_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeValue]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreAttributeValue_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreAttributeValue] ADD  CONSTRAINT [DF_coreAttributeValue_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_coreAttributeValue_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreAttributeValue_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeValue]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreAttributeValue_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreAttributeValue] ADD  CONSTRAINT [DF_coreAttributeValue_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_coreDefinedType_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreDefinedType_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreDefinedType_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreDefinedType] ADD  CONSTRAINT [DF_coreDefinedType_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_coreDefinedType_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreDefinedType_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreDefinedType_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreDefinedType] ADD  CONSTRAINT [DF_coreDefinedType_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_coreDefinedType_Order]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreDefinedType_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreDefinedType_Order]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreDefinedType] ADD  CONSTRAINT [DF_coreDefinedType_Order]  DEFAULT ((0)) FOR [Order]
END


End
GO
/****** Object:  Default [DF_coreDefinedValue_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreDefinedValue_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedValue]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreDefinedValue_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreDefinedValue] ADD  CONSTRAINT [DF_coreDefinedValue_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_coreDefinedValue_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreDefinedValue_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedValue]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreDefinedValue_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreDefinedValue] ADD  CONSTRAINT [DF_coreDefinedValue_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_coreDefinedValue_Order]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreDefinedValue_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedValue]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreDefinedValue_Order]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreDefinedValue] ADD  CONSTRAINT [DF_coreDefinedValue_Order]  DEFAULT ((0)) FOR [Order]
END


End
GO
/****** Object:  Default [DF_coreEntityChange_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_coreEntityChange_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreEntityChange]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_coreEntityChange_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreEntityChange] ADD  CONSTRAINT [DF_coreEntityChange_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_systemFieldType_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_systemFieldType_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreFieldType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_systemFieldType_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreFieldType] ADD  CONSTRAINT [DF_systemFieldType_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_systemFieldType_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_systemFieldType_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreFieldType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_systemFieldType_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[coreFieldType] ADD  CONSTRAINT [DF_systemFieldType_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_groupGroup_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_groupGroup_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroup]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_groupGroup_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[groupsGroup] ADD  CONSTRAINT [DF_groupGroup_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_groupsGroup_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_groupsGroup_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroup]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_groupsGroup_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[groupsGroup] ADD  CONSTRAINT [DF_groupsGroup_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_groupType_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_groupType_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_groupType_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[groupsGroupType] ADD  CONSTRAINT [DF_groupType_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_groupsGroupType_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_groupsGroupType_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_groupsGroupType_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[groupsGroupType] ADD  CONSTRAINT [DF_groupsGroupType_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_groupMember_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_groupMember_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsMember]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_groupMember_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[groupsMember] ADD  CONSTRAINT [DF_groupMember_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_groupsMember_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_groupsMember_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsMember]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_groupsMember_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[groupsMember] ADD  CONSTRAINT [DF_groupsMember_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_groupRole_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_groupRole_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsRole]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_groupRole_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[groupsRole] ADD  CONSTRAINT [DF_groupRole_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_groupsRole_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_groupsRole_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsRole]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_groupsRole_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[groupsRole] ADD  CONSTRAINT [DF_groupsRole_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  Default [DF_membershipPerson_Guid]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_membershipPerson_Guid]') AND parent_object_id = OBJECT_ID(N'[dbo].[membershipPerson]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_membershipPerson_Guid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[membershipPerson] ADD  CONSTRAINT [DF_membershipPerson_Guid]  DEFAULT (newid()) FOR [Guid]
END


End
GO
/****** Object:  Default [DF_membershipPerson_System]    Script Date: 02/01/2011 07:08:53 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_membershipPerson_System]') AND parent_object_id = OBJECT_ID(N'[dbo].[membershipPerson]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_membershipPerson_System]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[membershipPerson] ADD  CONSTRAINT [DF_membershipPerson_System]  DEFAULT ((0)) FOR [System]
END


End
GO
/****** Object:  ForeignKey [FK_cmsLayoutBlock_cmsBlock]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsLayoutBlock_cmsBlock]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsLayoutBlock]'))
ALTER TABLE [dbo].[cmsLayoutBlock]  WITH CHECK ADD  CONSTRAINT [FK_cmsLayoutBlock_cmsBlock] FOREIGN KEY([BlockId])
REFERENCES [dbo].[cmsBlock] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsLayoutBlock_cmsBlock]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsLayoutBlock]'))
ALTER TABLE [dbo].[cmsLayoutBlock] CHECK CONSTRAINT [FK_cmsLayoutBlock_cmsBlock]
GO
/****** Object:  ForeignKey [FK_cmsPage_cmsPage]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPage_cmsPage]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPage]'))
ALTER TABLE [dbo].[cmsPage]  WITH CHECK ADD  CONSTRAINT [FK_cmsPage_cmsPage] FOREIGN KEY([ParentPageId])
REFERENCES [dbo].[cmsPage] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPage_cmsPage]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPage]'))
ALTER TABLE [dbo].[cmsPage] CHECK CONSTRAINT [FK_cmsPage_cmsPage]
GO
/****** Object:  ForeignKey [FK_cmsPage_cmsSite]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPage_cmsSite]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPage]'))
ALTER TABLE [dbo].[cmsPage]  WITH CHECK ADD  CONSTRAINT [FK_cmsPage_cmsSite] FOREIGN KEY([SiteId])
REFERENCES [dbo].[cmsSite] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPage_cmsSite]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPage]'))
ALTER TABLE [dbo].[cmsPage] CHECK CONSTRAINT [FK_cmsPage_cmsSite]
GO
/****** Object:  ForeignKey [FK_cmsPageBlock_cmsBlock]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPageBlock_cmsBlock]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageBlock]'))
ALTER TABLE [dbo].[cmsPageBlock]  WITH CHECK ADD  CONSTRAINT [FK_cmsPageBlock_cmsBlock] FOREIGN KEY([BlockId])
REFERENCES [dbo].[cmsBlock] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPageBlock_cmsBlock]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageBlock]'))
ALTER TABLE [dbo].[cmsPageBlock] CHECK CONSTRAINT [FK_cmsPageBlock_cmsBlock]
GO
/****** Object:  ForeignKey [FK_cmsPageBlock_cmsPage]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPageBlock_cmsPage]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageBlock]'))
ALTER TABLE [dbo].[cmsPageBlock]  WITH CHECK ADD  CONSTRAINT [FK_cmsPageBlock_cmsPage] FOREIGN KEY([PageId])
REFERENCES [dbo].[cmsPage] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPageBlock_cmsPage]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageBlock]'))
ALTER TABLE [dbo].[cmsPageBlock] CHECK CONSTRAINT [FK_cmsPageBlock_cmsPage]
GO
/****** Object:  ForeignKey [FK_cmsPageRoute_cmsPage]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPageRoute_cmsPage]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageRoute]'))
ALTER TABLE [dbo].[cmsPageRoute]  WITH CHECK ADD  CONSTRAINT [FK_cmsPageRoute_cmsPage] FOREIGN KEY([PageId])
REFERENCES [dbo].[cmsPage] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsPageRoute_cmsPage]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsPageRoute]'))
ALTER TABLE [dbo].[cmsPageRoute] CHECK CONSTRAINT [FK_cmsPageRoute_cmsPage]
GO
/****** Object:  ForeignKey [FK_cmsSite_cmsPage]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsSite_cmsPage]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsSite]'))
ALTER TABLE [dbo].[cmsSite]  WITH CHECK ADD  CONSTRAINT [FK_cmsSite_cmsPage] FOREIGN KEY([DefaultPageId])
REFERENCES [dbo].[cmsPage] ([Id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsSite_cmsPage]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsSite]'))
ALTER TABLE [dbo].[cmsSite] CHECK CONSTRAINT [FK_cmsSite_cmsPage]
GO
/****** Object:  ForeignKey [FK_cmsSiteDomain_cmsSite]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsSiteDomain_cmsSite]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsSiteDomain]'))
ALTER TABLE [dbo].[cmsSiteDomain]  WITH CHECK ADD  CONSTRAINT [FK_cmsSiteDomain_cmsSite] FOREIGN KEY([SiteId])
REFERENCES [dbo].[cmsSite] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cmsSiteDomain_cmsSite]') AND parent_object_id = OBJECT_ID(N'[dbo].[cmsSiteDomain]'))
ALTER TABLE [dbo].[cmsSiteDomain] CHECK CONSTRAINT [FK_cmsSiteDomain_cmsSite]
GO
/****** Object:  ForeignKey [FK_coreAttributeType_coreFieldType]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_coreAttributeType_coreFieldType]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeType]'))
ALTER TABLE [dbo].[coreAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_coreAttributeType_coreFieldType] FOREIGN KEY([FieldTypeId])
REFERENCES [dbo].[coreFieldType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_coreAttributeType_coreFieldType]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeType]'))
ALTER TABLE [dbo].[coreAttributeType] CHECK CONSTRAINT [FK_coreAttributeType_coreFieldType]
GO
/****** Object:  ForeignKey [FK_coreAttributeValue_coreAttributeType]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_coreAttributeValue_coreAttributeType]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeValue]'))
ALTER TABLE [dbo].[coreAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_coreAttributeValue_coreAttributeType] FOREIGN KEY([AttributeTypeId])
REFERENCES [dbo].[coreAttributeType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_coreAttributeValue_coreAttributeType]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreAttributeValue]'))
ALTER TABLE [dbo].[coreAttributeValue] CHECK CONSTRAINT [FK_coreAttributeValue_coreAttributeType]
GO
/****** Object:  ForeignKey [FK_coreDefinedType_coreFieldType]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_coreDefinedType_coreFieldType]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedType]'))
ALTER TABLE [dbo].[coreDefinedType]  WITH CHECK ADD  CONSTRAINT [FK_coreDefinedType_coreFieldType] FOREIGN KEY([FieldTypeId])
REFERENCES [dbo].[coreFieldType] ([Id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_coreDefinedType_coreFieldType]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedType]'))
ALTER TABLE [dbo].[coreDefinedType] CHECK CONSTRAINT [FK_coreDefinedType_coreFieldType]
GO
/****** Object:  ForeignKey [FK_coreDefinedValue_coreDefinedType]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_coreDefinedValue_coreDefinedType]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedValue]'))
ALTER TABLE [dbo].[coreDefinedValue]  WITH CHECK ADD  CONSTRAINT [FK_coreDefinedValue_coreDefinedType] FOREIGN KEY([DefinedTypeId])
REFERENCES [dbo].[coreDefinedType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_coreDefinedValue_coreDefinedType]') AND parent_object_id = OBJECT_ID(N'[dbo].[coreDefinedValue]'))
ALTER TABLE [dbo].[coreDefinedValue] CHECK CONSTRAINT [FK_coreDefinedValue_coreDefinedType]
GO
/****** Object:  ForeignKey [FK_groupsGroup_groupsGroup]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroup_groupsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroup]'))
ALTER TABLE [dbo].[groupsGroup]  WITH CHECK ADD  CONSTRAINT [FK_groupsGroup_groupsGroup] FOREIGN KEY([ParentGroupId])
REFERENCES [dbo].[groupsGroup] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroup_groupsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroup]'))
ALTER TABLE [dbo].[groupsGroup] CHECK CONSTRAINT [FK_groupsGroup_groupsGroup]
GO
/****** Object:  ForeignKey [FK_groupsGroup_groupsGroupType]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroup_groupsGroupType]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroup]'))
ALTER TABLE [dbo].[groupsGroup]  WITH CHECK ADD  CONSTRAINT [FK_groupsGroup_groupsGroupType] FOREIGN KEY([GroupTypeId])
REFERENCES [dbo].[groupsGroupType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroup_groupsGroupType]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroup]'))
ALTER TABLE [dbo].[groupsGroup] CHECK CONSTRAINT [FK_groupsGroup_groupsGroupType]
GO
/****** Object:  ForeignKey [FK_groupsGroupTypeAssociation_groupsGroupType]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroupTypeAssociation_groupsGroupType]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeAssociation]'))
ALTER TABLE [dbo].[groupsGroupTypeAssociation]  WITH CHECK ADD  CONSTRAINT [FK_groupsGroupTypeAssociation_groupsGroupType] FOREIGN KEY([ParentGroupTypeId])
REFERENCES [dbo].[groupsGroupType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroupTypeAssociation_groupsGroupType]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeAssociation]'))
ALTER TABLE [dbo].[groupsGroupTypeAssociation] CHECK CONSTRAINT [FK_groupsGroupTypeAssociation_groupsGroupType]
GO
/****** Object:  ForeignKey [FK_groupsGroupTypeAssociation_groupsGroupType1]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroupTypeAssociation_groupsGroupType1]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeAssociation]'))
ALTER TABLE [dbo].[groupsGroupTypeAssociation]  WITH CHECK ADD  CONSTRAINT [FK_groupsGroupTypeAssociation_groupsGroupType1] FOREIGN KEY([ChildGroupTypeId])
REFERENCES [dbo].[groupsGroupType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroupTypeAssociation_groupsGroupType1]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeAssociation]'))
ALTER TABLE [dbo].[groupsGroupTypeAssociation] CHECK CONSTRAINT [FK_groupsGroupTypeAssociation_groupsGroupType1]
GO
/****** Object:  ForeignKey [FK_groupsGroupTypeRole_groupsGroupType]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroupTypeRole_groupsGroupType]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeRole]'))
ALTER TABLE [dbo].[groupsGroupTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_groupsGroupTypeRole_groupsGroupType] FOREIGN KEY([GroupTypeId])
REFERENCES [dbo].[groupsGroupType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroupTypeRole_groupsGroupType]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeRole]'))
ALTER TABLE [dbo].[groupsGroupTypeRole] CHECK CONSTRAINT [FK_groupsGroupTypeRole_groupsGroupType]
GO
/****** Object:  ForeignKey [FK_groupsGroupTypeRole_groupsRole]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroupTypeRole_groupsRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeRole]'))
ALTER TABLE [dbo].[groupsGroupTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_groupsGroupTypeRole_groupsRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[groupsRole] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsGroupTypeRole_groupsRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsGroupTypeRole]'))
ALTER TABLE [dbo].[groupsGroupTypeRole] CHECK CONSTRAINT [FK_groupsGroupTypeRole_groupsRole]
GO
/****** Object:  ForeignKey [FK_groupsMember_groupsGroup]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsMember_groupsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsMember]'))
ALTER TABLE [dbo].[groupsMember]  WITH CHECK ADD  CONSTRAINT [FK_groupsMember_groupsGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[groupsGroup] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsMember_groupsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsMember]'))
ALTER TABLE [dbo].[groupsMember] CHECK CONSTRAINT [FK_groupsMember_groupsGroup]
GO
/****** Object:  ForeignKey [FK_groupsMember_groupsRole]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsMember_groupsRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsMember]'))
ALTER TABLE [dbo].[groupsMember]  WITH CHECK ADD  CONSTRAINT [FK_groupsMember_groupsRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[groupsRole] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsMember_groupsRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsMember]'))
ALTER TABLE [dbo].[groupsMember] CHECK CONSTRAINT [FK_groupsMember_groupsRole]
GO
/****** Object:  ForeignKey [FK_groupsMember_membershipPerson]    Script Date: 02/01/2011 07:08:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsMember_membershipPerson]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsMember]'))
ALTER TABLE [dbo].[groupsMember]  WITH CHECK ADD  CONSTRAINT [FK_groupsMember_membershipPerson] FOREIGN KEY([PersonId])
REFERENCES [dbo].[membershipPerson] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_groupsMember_membershipPerson]') AND parent_object_id = OBJECT_ID(N'[dbo].[groupsMember]'))
ALTER TABLE [dbo].[groupsMember] CHECK CONSTRAINT [FK_groupsMember_membershipPerson]
GO
