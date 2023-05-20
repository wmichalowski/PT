CREATE TABLE [dbo].[Employees] (
    [EmployeeId]  INT   NOT NULL,
    [Name]        NTEXT NOT NULL,
    [Surname]     NTEXT NOT NULL,
    [Address]     NTEXT NOT NULL,
    [PhoneNumber] TEXT  NULL,
    [Email]       TEXT  NULL,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

