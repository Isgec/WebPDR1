SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrActionResponsesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrActionResponsesSelectByID]
GO
 
CREATE PROCEDURE [dbo].[sppdrActionResponsesSelectByID]
  @LoginID NVarChar(8),
  @PDRNo Int,
  @ActionNo Int,
  @ResponseNo Int 
  AS
  SELECT
    [PDR_ActionResponses].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [PDR_Actions2].[Responsible] AS PDR_Actions2_Responsible,
    [PDR_Defects3].[AnnexurePath] AS PDR_Defects3_AnnexurePath 
  FROM [PDR_ActionResponses] 
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [PDR_ActionResponses].[RespondedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [PDR_Actions] AS [PDR_Actions2]
    ON [PDR_ActionResponses].[PDRNo] = [PDR_Actions2].[PDRNo]
    AND [PDR_ActionResponses].[ActionNo] = [PDR_Actions2].[ActionNo]
  INNER JOIN [PDR_Defects] AS [PDR_Defects3]
    ON [PDR_ActionResponses].[PDRNo] = [PDR_Defects3].[PDRNo]
  WHERE
  [PDR_ActionResponses].[PDRNo] = @PDRNo
  AND [PDR_ActionResponses].[ActionNo] = @ActionNo
  AND [PDR_ActionResponses].[ResponseNo] = @ResponseNo
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrActionResponsesSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrActionResponsesSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppdrActionResponsesSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,PDRNo Int NOT NULL
 ,ActionNo Int NOT NULL
 ,ResponseNo Int NOT NULL
  )
  INSERT INTO #PageIndex (PDRNo, ActionNo, ResponseNo)
  SELECT [PDR_ActionResponses].[PDRNo], [PDR_ActionResponses].[ActionNo], [PDR_ActionResponses].[ResponseNo] FROM [PDR_ActionResponses]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [PDR_ActionResponses].[RespondedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [PDR_Actions] AS [PDR_Actions2]
    ON [PDR_ActionResponses].[PDRNo] = [PDR_Actions2].[PDRNo]
    AND [PDR_ActionResponses].[ActionNo] = [PDR_Actions2].[ActionNo]
  INNER JOIN [PDR_Defects] AS [PDR_Defects3]
    ON [PDR_ActionResponses].[PDRNo] = [PDR_Defects3].[PDRNo]
 WHERE  
   ( 
         STR(ISNULL([PDR_ActionResponses].[PDRNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([PDR_ActionResponses].[ActionNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([PDR_ActionResponses].[ResponseNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([PDR_ActionResponses].[ResponseDescription],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PDR_ActionResponses].[RespondedBy],'')) LIKE @KeyWord1
     OR STR(ISNULL([PDR_ActionResponses].[StatusID], 0)) LIKE @KeyWord1
   ) 
  ORDER BY (Select @OrderBy)

    SET @RecordCount = @@RowCount

  SELECT
    [PDR_ActionResponses].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [PDR_Actions2].[Responsible] AS PDR_Actions2_Responsible,
    [PDR_Defects3].[AnnexurePath] AS PDR_Defects3_AnnexurePath 
  FROM [PDR_ActionResponses] 
      INNER JOIN #PageIndex
          ON [PDR_ActionResponses].[PDRNo] = #PageIndex.PDRNo
          AND [PDR_ActionResponses].[ActionNo] = #PageIndex.ActionNo
          AND [PDR_ActionResponses].[ResponseNo] = #PageIndex.ResponseNo
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [PDR_ActionResponses].[RespondedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [PDR_Actions] AS [PDR_Actions2]
    ON [PDR_ActionResponses].[PDRNo] = [PDR_Actions2].[PDRNo]
    AND [PDR_ActionResponses].[ActionNo] = [PDR_Actions2].[ActionNo]
  INNER JOIN [PDR_Defects] AS [PDR_Defects3]
    ON [PDR_ActionResponses].[PDRNo] = [PDR_Defects3].[PDRNo]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrActionResponsesSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrActionResponsesSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppdrActionResponsesSelectListFilteres]
  @Filter_PDRNo Int,
  @Filter_ActionNo Int,
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  IF (@OrderBy = '')
    SET @OrderBy = 'PDRNo, ActionNo, ResponseNo'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,PDRNo Int NOT NULL
 ,ActionNo Int NOT NULL
 ,ResponseNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL +=  'PDRNo'
  SET @LGSQL +=  ', ActionNo'
  SET @LGSQL +=  ', ResponseNo'
  SET @LGSQL +=  ')'
  SET @LGSQL +=  ' SELECT '
  SET @LGSQL +=  '[PDR_ActionResponses].[PDRNo]'
  SET @LGSQL +=  ', [PDR_ActionResponses].[ActionNo]'
  SET @LGSQL +=  ', [PDR_ActionResponses].[ResponseNo]'
  SET @LGSQL +=  ' FROM [PDR_ActionResponses] '
  SET @LGSQL +=  '  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]'
  SET @LGSQL +=  '    ON [PDR_ActionResponses].[RespondedBy] = [aspnet_users1].[LoginID]'
  SET @LGSQL +=  '  INNER JOIN [PDR_Actions] AS [PDR_Actions2]'
  SET @LGSQL +=  '    ON [PDR_ActionResponses].[PDRNo] = [PDR_Actions2].[PDRNo]'
  SET @LGSQL +=  '    AND [PDR_ActionResponses].[ActionNo] = [PDR_Actions2].[ActionNo]'
  SET @LGSQL +=  '  INNER JOIN [PDR_Defects] AS [PDR_Defects3]'
  SET @LGSQL +=  '    ON [PDR_ActionResponses].[PDRNo] = [PDR_Defects3].[PDRNo]'
  SET @LGSQL +=  '  WHERE 1 = 1 '
  IF (@Filter_PDRNo > 0) 
    SET @LGSQL +=  ' AND [PDR_ActionResponses].[PDRNo] = ' + STR(@Filter_PDRNo)
  IF (@Filter_ActionNo > 0) 
    SET @LGSQL +=  ' AND [PDR_ActionResponses].[ActionNo] = ' + STR(@Filter_ActionNo)
  SET @LGSQL +=  '  ORDER BY ' + @OrderBy
 
 
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [PDR_ActionResponses].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [PDR_Actions2].[Responsible] AS PDR_Actions2_Responsible,
    [PDR_Defects3].[AnnexurePath] AS PDR_Defects3_AnnexurePath 
  FROM [PDR_ActionResponses] 
      INNER JOIN #PageIndex
          ON [PDR_ActionResponses].[PDRNo] = #PageIndex.PDRNo
          AND [PDR_ActionResponses].[ActionNo] = #PageIndex.ActionNo
          AND [PDR_ActionResponses].[ResponseNo] = #PageIndex.ResponseNo
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [PDR_ActionResponses].[RespondedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [PDR_Actions] AS [PDR_Actions2]
    ON [PDR_ActionResponses].[PDRNo] = [PDR_Actions2].[PDRNo]
    AND [PDR_ActionResponses].[ActionNo] = [PDR_Actions2].[ActionNo]
  INNER JOIN [PDR_Defects] AS [PDR_Defects3]
    ON [PDR_ActionResponses].[PDRNo] = [PDR_Defects3].[PDRNo]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrActionResponsesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrActionResponsesInsert]
GO
 
CREATE PROCEDURE [dbo].[sppdrActionResponsesInsert]
  @PDRNo Int,
  @ActionNo Int,
  @ResponseDescription NVarChar(1000),
  @RespondedBy NVarChar(8),
  @RespondedOn DateTime,
  @StatusID Int,
  @Return_PDRNo Int = null OUTPUT, 
  @Return_ActionNo Int = null OUTPUT, 
  @Return_ResponseNo Int = null OUTPUT 
  AS
  INSERT [PDR_ActionResponses]
  (
   [PDRNo]
  ,[ActionNo]
  ,[ResponseDescription]
  ,[RespondedBy]
  ,[RespondedOn]
  ,[StatusID]
  )
  VALUES
  (
   @PDRNo
  ,@ActionNo
  ,@ResponseDescription
  ,@RespondedBy
  ,@RespondedOn
  ,@StatusID
  )
  SET @Return_PDRNo = @PDRNo
  SET @Return_ActionNo = @ActionNo
  SET @Return_ResponseNo = Scope_Identity()
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrActionResponsesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrActionResponsesUpdate]
GO
 
CREATE PROCEDURE [dbo].[sppdrActionResponsesUpdate]
  @Original_PDRNo Int, 
  @Original_ActionNo Int, 
  @Original_ResponseNo Int, 
  @PDRNo Int,
  @ActionNo Int,
  @ResponseDescription NVarChar(1000),
  @RespondedBy NVarChar(8),
  @RespondedOn DateTime,
  @StatusID Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [PDR_ActionResponses] SET 
   [PDRNo] = @PDRNo
  ,[ActionNo] = @ActionNo
  ,[ResponseDescription] = @ResponseDescription
  ,[RespondedBy] = @RespondedBy
  ,[RespondedOn] = @RespondedOn
  ,[StatusID] = @StatusID
  WHERE
  [PDRNo] = @Original_PDRNo
  AND [ActionNo] = @Original_ActionNo
  AND [ResponseNo] = @Original_ResponseNo
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrActionResponsesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrActionResponsesDelete]
GO
 
CREATE PROCEDURE [dbo].[sppdrActionResponsesDelete]
  @Original_PDRNo Int,
  @Original_ActionNo Int,
  @Original_ResponseNo Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [PDR_ActionResponses]
  WHERE
  [PDR_ActionResponses].[PDRNo] = @Original_PDRNo
  AND [PDR_ActionResponses].[ActionNo] = @Original_ActionNo
  AND [PDR_ActionResponses].[ResponseNo] = @Original_ResponseNo
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrSubmitResponseSelectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrSubmitResponseSelectList]
GO
 
CREATE PROCEDURE [dbo].[sppdrSubmitResponseSelectList]
  @LoginID NVarChar(8),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
    [PDR_Actions].* ,
    [PDR_Defects1].[AnnexurePath] AS PDR_Defects1_AnnexurePath,
    [aspnet_Users2].[UserFullName] AS aspnet_Users2_UserFullName 
  FROM [PDR_Actions] 
  INNER JOIN [PDR_Defects] AS [PDR_Defects1]
    ON [PDR_Actions].[PDRNo] = [PDR_Defects1].[PDRNo]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users2]
    ON [PDR_Actions].[Responsible] = [aspnet_users2].[LoginID]
  WHERE 1 = 1  
  ORDER BY
     CASE @OrderBy WHEN 'PDRNo' THEN [PDR_Actions].[PDRNo] END,
     CASE @OrderBy WHEN 'PDRNo DESC' THEN [PDR_Actions].[PDRNo] END DESC,
     CASE @OrderBy WHEN 'ActionNo' THEN [PDR_Actions].[ActionNo] END,
     CASE @OrderBy WHEN 'ActionNo DESC' THEN [PDR_Actions].[ActionNo] END DESC,
     CASE @OrderBy WHEN 'ActionDescription' THEN [PDR_Actions].[ActionDescription] END,
     CASE @OrderBy WHEN 'ActionDescription DESC' THEN [PDR_Actions].[ActionDescription] END DESC,
     CASE @OrderBy WHEN 'Responsible' THEN [PDR_Actions].[Responsible] END,
     CASE @OrderBy WHEN 'Responsible DESC' THEN [PDR_Actions].[Responsible] END DESC,
     CASE @OrderBy WHEN 'ResponsibleUsers' THEN [PDR_Actions].[ResponsibleUsers] END,
     CASE @OrderBy WHEN 'ResponsibleUsers DESC' THEN [PDR_Actions].[ResponsibleUsers] END DESC,
     CASE @OrderBy WHEN 'Remarks' THEN [PDR_Actions].[Remarks] END,
     CASE @OrderBy WHEN 'Remarks DESC' THEN [PDR_Actions].[Remarks] END DESC,
     CASE @OrderBy WHEN 'StatusID' THEN [PDR_Actions].[StatusID] END,
     CASE @OrderBy WHEN 'StatusID DESC' THEN [PDR_Actions].[StatusID] END DESC,
     CASE @OrderBy WHEN 'PDR_Defects1_AnnexurePath' THEN [PDR_Defects1].[AnnexurePath] END,
     CASE @OrderBy WHEN 'PDR_Defects1_AnnexurePath DESC' THEN [PDR_Defects1].[AnnexurePath] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users2_UserFullName' THEN [aspnet_Users2].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users2_UserFullName DESC' THEN [aspnet_Users2].[UserFullName] END DESC 
  SET @RecordCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrSubmitResponseAutoCompleteList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrSubmitResponseAutoCompleteList]
GO
 
CREATE PROCEDURE [dbo].[sppdrSubmitResponseAutoCompleteList]
  @LoginID NVarChar(8),
  @Prefix NVarChar(250),
  @Records Int,
  @ByCode Int 
  AS 
  BEGIN 
  DECLARE @Prefix1 VarChar(260)
  SET @Prefix1 = LOWER(@Prefix) + '%'
  DECLARE @LGSQL VarChar(8000)
  SET @LGSQL = 'SELECT TOP (' + STR(@Records) + ') ' 
  SET @LGSQL +=  ' [PDR_Actions].[Responsible]' 
  SET @LGSQL +=  ',[PDR_Actions].[PDRNo]' 
  SET @LGSQL +=  ',[PDR_Actions].[ActionNo]' 
  SET @LGSQL +=  ' FROM [PDR_Actions] ' 
  SET @LGSQL +=  ' WHERE 1 = 1 ' 
  SET @LGSQL +=  ' AND (LTRIM(STR(ISNULL([PDR_Actions].[PDRNo],0))) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL +=  ' OR LTRIM(STR(ISNULL([PDR_Actions].[ActionNo],0))) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL +=  ' OR LOWER(ISNULL([PDR_Actions].[Responsible],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL +=  ')' 
  
  EXEC (@LGSQL)
  END 
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrSubmitResponseSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrSubmitResponseSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppdrSubmitResponseSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,PDRNo Int NOT NULL
 ,ActionNo Int NOT NULL
  )
  INSERT INTO #PageIndex (PDRNo, ActionNo)
  SELECT [PDR_Actions].[PDRNo], [PDR_Actions].[ActionNo] FROM [PDR_Actions]
  INNER JOIN [PDR_Defects] AS [PDR_Defects1]
    ON [PDR_Actions].[PDRNo] = [PDR_Defects1].[PDRNo]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users2]
    ON [PDR_Actions].[Responsible] = [aspnet_users2].[LoginID]
 WHERE  
   ( 
         STR(ISNULL([PDR_Actions].[PDRNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([PDR_Actions].[ActionNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([PDR_Actions].[ActionDescription],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PDR_Actions].[Responsible],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PDR_Actions].[ResponsibleUsers],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PDR_Actions].[Remarks],'')) LIKE @KeyWord1
     OR STR(ISNULL([PDR_Actions].[StatusID], 0)) LIKE @KeyWord1
   ) 
  ORDER BY (Select @OrderBy)

    SET @RecordCount = @@RowCount

  SELECT
    [PDR_Actions].* ,
    [PDR_Defects1].[AnnexurePath] AS PDR_Defects1_AnnexurePath,
    [aspnet_Users2].[UserFullName] AS aspnet_Users2_UserFullName 
  FROM [PDR_Actions] 
      INNER JOIN #PageIndex
          ON [PDR_Actions].[PDRNo] = #PageIndex.PDRNo
          AND [PDR_Actions].[ActionNo] = #PageIndex.ActionNo
  INNER JOIN [PDR_Defects] AS [PDR_Defects1]
    ON [PDR_Actions].[PDRNo] = [PDR_Defects1].[PDRNo]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users2]
    ON [PDR_Actions].[Responsible] = [aspnet_users2].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppdrSubmitResponseSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppdrSubmitResponseSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppdrSubmitResponseSelectListFilteres]
  @Filter_PDRNo Int,
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  IF (@OrderBy = '')
    SET @OrderBy = 'PDRNo, ActionNo'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,PDRNo Int NOT NULL
 ,ActionNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL +=  'PDRNo'
  SET @LGSQL +=  ', ActionNo'
  SET @LGSQL +=  ')'
  SET @LGSQL +=  ' SELECT '
  SET @LGSQL +=  '[PDR_Actions].[PDRNo]'
  SET @LGSQL +=  ', [PDR_Actions].[ActionNo]'
  SET @LGSQL +=  ' FROM [PDR_Actions] '
  SET @LGSQL +=  '  INNER JOIN [PDR_Defects] AS [PDR_Defects1]'
  SET @LGSQL +=  '    ON [PDR_Actions].[PDRNo] = [PDR_Defects1].[PDRNo]'
  SET @LGSQL +=  '  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users2]'
  SET @LGSQL +=  '    ON [PDR_Actions].[Responsible] = [aspnet_users2].[LoginID]'
  SET @LGSQL +=  '  WHERE 1 = 1 '
  IF (@Filter_PDRNo > 0) 
    SET @LGSQL +=  ' AND [PDR_Actions].[PDRNo] = ' + STR(@Filter_PDRNo)
  SET @LGSQL +=  '  ORDER BY ' + @OrderBy
 
 
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [PDR_Actions].* ,
    [PDR_Defects1].[AnnexurePath] AS PDR_Defects1_AnnexurePath,
    [aspnet_Users2].[UserFullName] AS aspnet_Users2_UserFullName 
  FROM [PDR_Actions] 
      INNER JOIN #PageIndex
          ON [PDR_Actions].[PDRNo] = #PageIndex.PDRNo
          AND [PDR_Actions].[ActionNo] = #PageIndex.ActionNo
  INNER JOIN [PDR_Defects] AS [PDR_Defects1]
    ON [PDR_Actions].[PDRNo] = [PDR_Defects1].[PDRNo]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users2]
    ON [PDR_Actions].[Responsible] = [aspnet_users2].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
