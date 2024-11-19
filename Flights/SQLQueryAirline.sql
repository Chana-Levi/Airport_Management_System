CREATE TABLE [dbo].[Workers] (
    [WorkerID]         INT           NOT NULL,
    [LastName]         VARCHAR (255) NOT NULL,
    [FirstName]        VARCHAR (255) NOT NULL,
    [Role]             VARCHAR (255) NOT NULL,
    [ContactInfo]      VARCHAR (255) NOT NULL,
    [DateOfEmployment] DATE          NOT NULL,
    [AirlineID]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkerID] ASC),
    CONSTRAINT [FK_Airlines_Workers] FOREIGN KEY ([AirlineID]) REFERENCES [dbo].[Airlines] ([AirlineID])   
);