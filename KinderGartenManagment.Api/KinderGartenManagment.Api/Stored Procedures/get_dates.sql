USE [KinderGartenManagmentApi]
GO
/****** Object:  StoredProcedure [dbo].[get_dates]    Script Date: 15/01/2021 14:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[get_dates] 
	-- Add the parameters for the stored procedure here
	@Month INT, 
	@Year INT
AS
BEGIN
	SET LANGUAGE English
	;WITH N(N)AS 
	(SELECT 1 FROM(VALUES(1),(1),(1),(1),(1),(1))M(N)),
	tally(N)AS(SELECT ROW_NUMBER()OVER(ORDER BY N.N)FROM N,N a)

	SELECT FORMAT(datefromparts(@year,@month,N),'dddd') AS DAY,datefromparts(@year,@month,N) Date FROM tally
	WHERE N <= day(EOMONTH(datefromparts(@year,@Month,1)))

END
