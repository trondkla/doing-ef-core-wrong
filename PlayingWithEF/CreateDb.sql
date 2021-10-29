

CREATE TABLE [dbo].[PersonInstances](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_PersonInstances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Blobs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonInstanceId] [bigint] NOT NULL,
 CONSTRAINT [PK_Blobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Blobs]  WITH CHECK ADD  CONSTRAINT [FK_Blobs_PersonInstances_PersonInstanceId] FOREIGN KEY([PersonInstanceId])
REFERENCES [dbo].[PersonInstances] ([Id])
GO

ALTER TABLE [dbo].[Blobs] CHECK CONSTRAINT [FK_Blobs_PersonInstances_PersonInstanceId]

GO


  INSERT INTO [dbo].[PersonInstances]
  (Name)
  VALUES
  ('1'),('2')

GO 

  INSERT INTO [dbo].[Blobs]
  (PersonInstanceId)
  VALUES 
  (1),
  (2)