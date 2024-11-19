CREATE TABLE [dbo].[FlightCrew] (
    [TeamID]   INT IDENTITY (958, 1) NOT NULL,
    [WorkerID] INT NOT NULL,
    [RoleID]   INT NOT NULL,
    [FlightID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([TeamID] ASC),
    CONSTRAINT [FK_FlightCrew_Roles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([RoleID])
);