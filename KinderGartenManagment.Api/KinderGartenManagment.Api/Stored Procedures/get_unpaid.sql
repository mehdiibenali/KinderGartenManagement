USE [KinderGartenManagmentApi]
GO
/****** Object:  StoredProcedure [dbo].[get_unpaid]    Script Date: 15/01/2021 14:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>waloubenali19951919	didou23347373
-- =============================================
ALTER PROCEDURE [dbo].[get_unpaid]
(
	@EleveIdsString NVARCHAR(500)
)
AS
BEGIN
	SET LANGUAGE us_english
	DECLARE @EleveIdsTable AS TABLE(id INT)
	DECLARE @Groupes AS TABLE(EleveId INT,Prenom NVARCHAR(500),Nom NVARCHAR(500),EnrollementId INT,EnrollementName NVARCHAR(500),Section NVARCHAR(500),EleveEnrollementId INT,DateDeDebut NVARCHAR(100),DateDeFin NVARCHAR(100),Max NVARCHAR(100),EnrollementPaid NVARCHAR(500),Paid INT NULL,ConventionName NVARCHAR(500))
	DECLARE @Enrollements AS TABLE(EleveId INT,Prenom NVARCHAR(500),Nom NVARCHAR(500),EnrollementId INT,EnrollementName NVARCHAR(500),Section NVARCHAR(500),EleveEnrollementId INT,DateDeDebut NVARCHAR(100),DateDeFin NVARCHAR(100),Max NVARCHAR(100),EnrollementPaid NVARCHAR(500),Paid INT NULL,ConventionName NVARCHAR(500))
	DECLARE @ScholarYearBeginning AS NVARCHAR(500)
	DECLARE @ScholarYearEnd AS NVARCHAR(500)
	DECLARE @CurrentScolarYear AS NVARCHAR(500)
	DECLARE @ScolarYear AS TABLE(Year NVARCHAR(500))
	DECLARE @StartYear AS NVARCHAR(500)
	DECLARE @EndYear AS NVARCHAR(500)
	INSERT INTO @EleveIdsTable	
	SELECT value 
	FROM STRING_SPLIT(@EleveIdsString,'-');

	SELECT @CurrentScolarYear = STUFF(
	(
	SELECT PARA.Value 
	FROM dbo.Parameters PARA
	WHERE PARA.Code='CurrentScolarYear')
	,1,0,'')

	INSERT INTO @ScolarYear
	SELECT value
	FROM STRING_SPLIT(@CurrentScolarYear,'-')

	SELECT @StartYear = STUFF(
	(
	SELECT TOP 1 * 
	FROM @ScolarYear)
	,1,0,'')
	SELECT @EndYear = STUFF(
	(
	SELECT *
	FROM @ScolarYear
	WHERE Year > @CurrentScolarYear),1,0,'')

	--INSER ALL THESE RESULTS IN TABLE 
	INSERT INTO @Groupes
	SELECT

		MAX(EIT.Id) AS 'EleveId',MAX(E.Prenom) AS 'Prenom',Max(E.Nom) AS 'Nom',
		 --MAX(E.Prenom),MAX(E.Nom),x
		MAX(EN.Id) AS 'EnrollementId',MAX(EN.Name) AS 'EnrollementName', 'Scolarité' AS 'Section',
		EE.Id AS 'EleveEnrollementId',
		CASE WHEN EE.DateDeDebut < Max(PE.DateDeFin)  THEN  FORMAT(Max(PE.DateDeFin),'yyyy-MM-dd')
			ELSE FORMAT(EE.DateDeDebut,'yyyy-MM-dd')
		END AS 'DateDeDebut',
		--FORMAT(EE.DateDeDebut,'yyyy-MM-dd'),
		FORMAT(EE.DateDeFin,'yyyy-MM-dd'),
		--EE.DatedeDebut,EE.DatedeFin,
		--PE.DateDeDebut,
		FORMAT(EE.DateDeFin,'yyyy-MM-dd') AS 'MAX',
		CASE 
			WHEN EE.DateDeFin=MAX(PE.DateDeFin) THEN 'True' 
			ELSE 'False'
		END AS 'EnrollementPaid',
		MAX(CF.Fee) AS 'Paid',
		MAX(C.Name) AS 'ConventionName'
	FROM @EleveIdsTable EIT
	JOIN dbo.Eleves E ON EIT.Id=E.Id
	LEFT JOIN dbo.EleveEnrollements EE ON EIT.id = EE.EleveId
	LEFT JOIN dbo.PayementEnrollements PE ON EE.Id = PE.EleveEnrollementId
	LEFT JOIN dbo.EleveParents EP ON EE.EleveId = EP.EleveId AND EP.ParentTuteur = 1
	LEFT JOIN dbo.ParentConventions PC ON EP.ParentId = PC.ParentId
	LEFT JOIN dbo.Conventions C ON PC.ConventionId = C.Id
	LEFT JOIN dbo.ConventionFees CF ON C.Id = CF.ConventionId
	JOIN dbo.Enrollements EN ON EE.EnrollementId = EN.Id
	WHERE EN.Type='Groupe'
	GROUP BY EE.Id,EE.DateDeDebut,EE.DateDeFin

	SELECT @ScholarYearBeginning = STUFF(
	(
	SELECT PARA.Value 
	FROM dbo.Parameters PARA
	WHERE PARA.Code='ScholarYearBeginning')
	,1,0,'')
	SELECT @ScholarYearEnd = STUFF(
	(
	SELECT PARA.Value 
	FROM dbo.Parameters PARA
	WHERE PARA.Code='ScholarYearEnd')
	,1,0,'')
	--CHEC FOR FRAIS D'INSCRIPTION THEN INSERT THE ROW IN THE TABLE ABOVE
	INSERT INTO @Enrollements
	SELECT DISTINCT G.EleveId AS 'EleveId' , MAX(E.Prenom) AS 'Prenom' , Max(E.Nom) AS 'Nom' , NULL AS 'EnrollementId', NULL AS 'EnrollementName' , 'Frais d''inscription' AS 'Section', NULL AS 'EleveEnrollementId' ,
	 CASE WHEN MAX(PE.DateDeFin) IS NULL THEN FORMAT(CAST(@ScholarYearBeginning+' '+CONVERT(NVARCHAR(40),DATEPART(yyyy,@StartYear))AS DATETIME),'yyyy-MM-dd')
	 ELSE FORMAT(CAST(@ScholarYearBeginning+' '+CONVERT(NVARCHAR(40),DATEPART(yyyy,MAX(PE.DateDeFin)))AS DATETIME),'yyyy-MM-dd')
	 END AS 'DateDeDebut',
	 CASE WHEN MAX(PE.DateDeFin) IS NULL THEN FORMAT(CAST(@ScholarYearEnd+' '+CONVERT(NVARCHAR(40),DATEPART(yyyy,@EndYear))AS DATETIME),'yyyy-MM-dd')
	 ELSE FORMAT(CAST(@ScholarYearEnd+' '+CONVERT(NVARCHAR(40),DATEPART(yyyy,MAX(PE.DateDeFin))+1)AS DATETIME),'yyyy-MM-dd')
	 END AS 'DateDeFin',
	 FORMAT(CAST(@ScholarYearEnd+' '+CONVERT(NVARCHAR(40),DATEPART(yyyy,MAX(PE.DateDeFin))+1)AS DATETIME),'yyyy-MM-dd') AS 'Max' ,
	  NULL AS 'EnrollementPaid', NULL AS 'Paid', NULL AS 'ConventionName'
	FROM @Groupes G
	JOIN dbo.EleveEnrollements EE ON G.EleveEnrollementId=EE.Id
	LEFT JOIN dbo.PayementEnrollements PE ON EE.EleveId = PE.EleveId 
	LEFT JOIN dbo.Eleves E ON EE.EleveId = E.Id
	WHERE PE.DateDeFin IS NULL OR G.DateDeDebut>PE.DateDeFin 
	GROUP BY G.EleveId,G.EnrollementId,G.EnrollementName,G.Section,G.EleveEnrollementId,G.DateDeDebut,G.DateDeFin,G.Max,G.EnrollementPaid 

	INSERT INTO @Enrollements
	SELECT G.*
	FROM @Groupes G
	
	INSERT INTO @Enrollements
	SELECT
	MAX(EIT.Id) AS 'EleveId', MAX(E.Prenom) AS 'Prenom', Max(E.Nom) AS 'Nom',
	 --MAX(E.Prenom),MAX(E.Nom),
	MAX(EN.Id) AS 'EnrollementId',MAX(EN.Name) AS 'EnrollementNrme', MAX(EN.Type) AS 'Section',
	EE.Id AS 'EleveEnrollementId',
	CASE WHEN EE.DateDeDebut < Max(PE.DateDeFin)  THEN  FORMAT(Max(PE.DateDeFin),'yyyy-MM-dd')
       ELSE FORMAT(EE.DateDeDebut,'yyyy-MM-dd')
    END AS 'DateDeDebut',
	--FORMAT(EE.DateDeDebut,'yyyy-MM-dd'),
	FORMAT(EE.DateDeFin,'yyyy-MM-dd'),
	--EE.DatedeDebut,EE.DatedeFin,
	--PE.DateDeDebut,
	FORMAT(EE.DateDeFin,'yyyy-MM-dd') AS 'MAX',
	CASE 
		WHEN EE.DateDeFin=MAX(PE.DateDeFin) THEN 'True' 
		ELSE 'False'
	END AS 'EnrollementPaid',
	NULL AS 'Paid',
	NULL AS 'ConventionName'
	FROM @EleveIdsTable EIT
	JOIN dbo.Eleves E ON EIT.Id=E.Id
	LEFT JOIN dbo.EleveEnrollements EE ON EIT.id = EE.EleveId
	LEFT JOIN dbo.PayementEnrollements PE ON EE.Id = PE.EleveEnrollementId
	JOIN dbo.Enrollements EN ON EE.EnrollementId = EN.Id
	WHERE EN.Type!='Groupe'
	GROUP BY EE.Id,EE.DateDeDebut,EE.DateDeFin
	SELECT E.*
	FROM @Enrollements E
END