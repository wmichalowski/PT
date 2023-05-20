CREATE TABLE [dbo].[Event_RentsReturns] (
    [RentReturnId] INT        NOT NULL,
    [BookId]       NCHAR (10) NOT NULL,
    [EmployeeId]   INT        NOT NULL,
    [ReaderId]     INT        NOT NULL,
    [Timestamp]    DATETIME   NOT NULL,
    [Rent/Return]  NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([RentReturnId] ASC),
    CONSTRAINT [RentsReturns_Readers_fk] FOREIGN KEY ([ReaderId]) REFERENCES [dbo].[Readers] ([ReaderId]),
    CONSTRAINT [FK_Event_RentsReturns_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]),
    CONSTRAINT [FK_Event_RentsReturns_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([EmployeeId])
);

