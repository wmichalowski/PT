CREATE TABLE [dbo].[Books] (
    [BookId]    NCHAR (10) NOT NULL,
    [Title]     NTEXT      NOT NULL,
    [Author]    NTEXT      NOT NULL,
    [Publisher] NTEXT      NOT NULL,
    [Category]  NTEXT      NOT NULL,
    [Available] BIT        NOT NULL,
    PRIMARY KEY CLUSTERED ([BookId] ASC)
);

