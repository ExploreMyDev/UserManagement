CREATE TABLE [dbo].[User] (
    [UserID]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (200) NULL,
    [DateOfBirth] DATE          NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

