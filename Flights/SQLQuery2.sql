CREATE TABLE [dbo].[Flights] (
    [FlightID]         INT           IDENTITY (3201, 1) NOT NULL,
    [AirlineID]        INT           NOT NULL,
    [DepartureAirport] VARCHAR (255) NOT NULL,
    [ArrivalAirport]   VARCHAR (255) NOT NULL,
    [DepartureTime]    DATETIME      NOT NULL,
    [ArrivalTime]      DATETIME      NOT NULL,
    [FlightDuration]   TIME(0)      NOT NULL,
    PRIMARY KEY CLUSTERED ([FlightID] ASC),
    CONSTRAINT [FK_Airlines_Flights] FOREIGN KEY ([AirlineID]) REFERENCES [dbo].[Airlines] ([AirlineID])
);
