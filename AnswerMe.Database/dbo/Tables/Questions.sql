CREATE TABLE [dbo].[Questions] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [QuestionText] VARCHAR (MAX) NULL,
    [DateUpdated]  DATETIME      NOT NULL,
    [Answered]     BIT           DEFAULT 0 NOT NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([ID] ASC)
);





