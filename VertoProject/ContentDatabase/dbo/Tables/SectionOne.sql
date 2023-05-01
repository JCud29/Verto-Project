CREATE TABLE [dbo].[SectionOne]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [cardNumber] INT NOT NULL,
    [cardHeading] NVARCHAR(50) NULL,
    [cardBody] NVARCHAR(1000) NULL, 
    [cardButton] NVARCHAR(50) NULL
)
