USE [KinderGartenManagmentApi]
GO
/****** Object:  StoredProcedure [dbo].[get_eleves_by_enrollement]    Script Date: 15/01/2021 14:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[get_eleves_by_enrollement]
	-- Add the parameters for the stored procedure here
		@Month INT,
		@Year INT,
		@EnrollementID INT
AS
BEGIN

	SELECT	E.*
	FROM EleveEnrollements EE
	JOIN Eleves E ON EE.EleveId = E.Id
	WHERE	EE.EnrollementId=@EnrollementID
			AND YEAR(EE.DateDeDebut)<=@Year
			AND MONTH(EE.DateDeDebut)<=@Month
			AND YEAR(EE.DateDeFin)>=@Year
			AND MONTH(EE.DateDeFin)<=@Month
END
