/*
DB_DatabaseDesignChallenge의 배포 스크립트

이 코드는 도구를 사용하여 생성되었습니다.
파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
변경 내용이 손실됩니다.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_DatabaseDesignChallenge"
:setvar DefaultFilePrefix "DB_DatabaseDesignChallenge"
:setvar DefaultDataPath "C:\Users\kangup\AppData\Local\Microsoft\VisualStudio\SSDT\DatabaseDesignChallenge"
:setvar DefaultLogPath "C:\Users\kangup\AppData\Local\Microsoft\VisualStudio\SSDT\DatabaseDesignChallenge"

GO
:on error exit
GO
/*
SQLCMD 모드가 지원되지 않으면 SQLCMD 모드를 검색하고 스크립트를 실행하지 않습니다.
SQLCMD 모드를 설정한 후에 이 스크립트를 다시 사용하려면 다음을 실행합니다.
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'이 스크립트를 실행하려면 SQLCMD 모드를 사용하도록 설정해야 합니다.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367)) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'키가 8b03a9d9-6afb-4f10-be08-c6cceab5af0e인 이름 바꾸기 리팩터링 작업을 건너뜁니다. 요소 [dbo].[Person].[Family](SqlSimpleColumn)의 이름이 FamilyId(으)로 바뀌지 않습니다.';


GO
PRINT N'키가 e1788a07-c54a-4297-9fa6-180a27d613c4인 이름 바꾸기 리팩터링 작업을 건너뜁니다. 요소 [dbo].[Person].[Present](SqlSimpleColumn)의 이름이 PresentId(으)로 바뀌지 않습니다.';


GO
PRINT N'[dbo].[Person]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Person] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [FamilyId]  INT           NULL,
    [Adress]    NVARCHAR (50) NULL,
    [PresentId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[Present]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Present] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [Cost] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[FK_Person_Present]을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Person] WITH NOCHECK
    ADD CONSTRAINT [FK_Person_Present] FOREIGN KEY ([PresentId]) REFERENCES [dbo].[Present] ([Id]);


GO
PRINT N'[dbo].[spPerson_GetPeople]을(를) 만드는 중...';


GO
CREATE PROCEDURE [dbo].[spPerson_GetPeople]
	
AS
Begin

	SELECT *
	From dbo.Person
	
End
GO
PRINT N'[dbo].[spPerson_GetPersonNoPresent]을(를) 만드는 중...';


GO
CREATE PROCEDURE [dbo].[spPerson_GetPersonNoPresent]
	
AS
Begin

	SELECT *
	From dbo.Person
	Where Person.PresentId = null

End
GO
-- 배포된 트랜잭션 로그를 사용하여 대상 서버를 업데이트하는 리팩터링 단계

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8b03a9d9-6afb-4f10-be08-c6cceab5af0e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8b03a9d9-6afb-4f10-be08-c6cceab5af0e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e1788a07-c54a-4297-9fa6-180a27d613c4')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e1788a07-c54a-4297-9fa6-180a27d613c4')

GO

GO
PRINT N'새로 만든 제약 조건에 대해 기존 데이터를 검사하는 중입니다.';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Person] WITH CHECK CHECK CONSTRAINT [FK_Person_Present];


GO
PRINT N'업데이트가 완료되었습니다.';


GO
