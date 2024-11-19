CREATE TABLE [dbo].[Role] (
    [RoleID]   INT          IDENTITY (821, 1) NOT NULL,
    [RoleType] VARCHAR (255) NOT NULL,  
    PRIMARY KEY CLUSTERED ([RoleID] ASC),
);   