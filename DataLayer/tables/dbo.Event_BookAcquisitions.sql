CREATE TABLE [dbo].[Event_BookAcquisitions] (
    [AcquisitionId] INT        NOT NULL,
    [BookId]        NCHAR (10) NOT NULL,
    [EmployeeId]    INT        NOT NULL,
    [ReaderId]      INT        NOT NULL,
    [SupplierId]    INT        NOT NULL,
    [Timestamp]     DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([AcquisitionId] ASC),
    CONSTRAINT [FK_Event_BookAcquisitions_Readers] FOREIGN KEY ([ReaderId]) REFERENCES [dbo].[Readers] ([ReaderId]),
    CONSTRAINT [FK_Event_BookAcquisitions_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]),
    CONSTRAINT [FK_Event_BookAcquisitions_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([EmployeeId]),
    CONSTRAINT [FK_Event_BookAcquisitions_Suppliers] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([SupplierId])
);

