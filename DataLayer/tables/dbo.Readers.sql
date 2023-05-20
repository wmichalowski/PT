CREATE TABLE [dbo].[Readers] (
    [ReaderId]    INT   NOT NULL,
    [Name]        NTEXT NOT NULL,
    [Surname]     NTEXT NOT NULL,
    [Address]     NTEXT NOT NULL,
    [PhoneNumber] TEXT  NULL,
    [Email]       TEXT  NULL,
    PRIMARY KEY CLUSTERED ([ReaderId] ASC)
);

