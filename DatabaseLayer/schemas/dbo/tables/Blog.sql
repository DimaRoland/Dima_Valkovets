CREATE TABLE [dbo].[MyBlog]
(
    [Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY ,
    [Title] nvarchar(max),
    [Description] nvarchar(max),
    [Posted] datetime
)

