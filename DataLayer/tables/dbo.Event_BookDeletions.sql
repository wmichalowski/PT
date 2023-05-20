CREATE TABLE [dbo].[Event_BookDeletions] (
    [BookDeletionId] INT        NOT NULL,
    [BookId]         NCHAR (10) NOT NULL,
    [EmployeeId]     INT        NOT NULL,
    [Timestamp]      DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([BookDeletionId] ASC),
    CONSTRAINT [FK_Event_BookDeletions_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]),
    CONSTRAINT [FK_Event_BookDeletions_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([EmployeeId])
);

