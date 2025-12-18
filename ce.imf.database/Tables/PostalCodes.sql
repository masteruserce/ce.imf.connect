CREATE TABLE [dbo].[PostalCode](
	[Id] [bigint] NOT NULL,
	[CircleName] [nvarchar](50) NOT NULL,
	[RegionName] [nvarchar](50) NOT NULL,
	[DivisionName] [nvarchar](50) NOT NULL,
	[OfficeName] [nvarchar](50) NOT NULL,
	[PinCOde] [int] NOT NULL,
	[OfficeType] [nvarchar](50) NOT NULL,
	[Delivery] [nvarchar](50) NOT NULL,
	[District] [nvarchar](50) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
	[Latitude] [nvarchar](50) NULL,
	[Longitude] [nvarchar](50) NULL,
 CONSTRAINT [PK_PostalCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]