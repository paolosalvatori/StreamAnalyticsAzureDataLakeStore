IF OBJECT_ID('Events') > 0 DROP TABLE Events
GO
CREATE TABLE Events
(
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](64) NOT NULL,
	[Building] [nvarchar](64) NOT NULL,
	[AverageValue] [float] NOT NULL,
	[EventCount] [int] NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	CONSTRAINT [PK_X_Events] PRIMARY KEY CLUSTERED 
	(
		[RowId] ASC
	)
)
GO
SELECT * FROM Events
GO