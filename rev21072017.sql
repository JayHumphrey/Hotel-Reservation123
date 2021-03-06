USE [OnlineHotelReservation]
GO
/****** Object:  StoredProcedure [dbo].[ADMIN_PROFILE_AdminSignUp]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ADMIN_PROFILE_AdminSignUp]
	@UserID uniqueidentifier
	,@PassWord nchar(8)
	,@FirstName nchar(10)
	,@LastName nchar(10)
	,@PhoneNo nchar(11)
	,@Email nchar(30)

AS
BEGIN
	INSERT INTO ADMIN_PROFILE
	([USER_ID]
     ,[PASSWORD]
     ,[FIRST_NAME]
     ,[LAST_NAME]
     ,[PHONE_NO]
     ,[EMAIL]
     ,[STATUS]
	)
	VALUES
	(
	 @UserID 
	,@PassWord 
	,@FirstName 
	,@LastName
	,@PhoneNo 
	,@Email 
	,'ADMIN'
	)
END

GO
/****** Object:  StoredProcedure [dbo].[ADMIN_PROFILE_Details]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ADMIN_PROFILE_Details]
	@UserId uniqueidentifier
AS
BEGIN
	SELECT a.USER_ID
	      ,a.FIRST_NAME
	      ,a.LAST_NAME
		  ,a.EMAIL
		  ,a.PHONE_NO
		  ,a.PASSWORD
		  
	FROM ADMIN_PROFILE a
	WHERE a.USER_ID = @UserId;

END

GO
/****** Object:  StoredProcedure [dbo].[ADMIN_PROFILE_Edit]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ADMIN_PROFILE_Edit]
	@UserID uniqueidentifier
	,@FirstName nchar(10)
	,@LastName nchar(10)
	,@Phone_No nchar(11)
	,@Email nvarchar(30)
	,@PassWord nchar(8)
	

AS
BEGIN

UPDATE ADMIN_PROFILE
SET
    [FIRST_NAME] = @FirstName
	,[LAST_NAME] = @LastName
	,[PHONE_NO] = @Phone_No
	,[EMAIL] = @Email
	,[PASSWORD] = @PassWord

WHERE
     [USER_ID] = @UserID;
	
END

GO
/****** Object:  StoredProcedure [dbo].[ADMIN_PROFILE_LogIn]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ADMIN_PROFILE_LogIn]
	@Email nvarchar(30)
    ,@PassWord nchar(8)

AS
BEGIN
    SELECT a.USER_ID
	      ,a.FIRST_NAME
	      ,a.LAST_NAME
		  ,a.EMAIL
		  ,a.PHONE_NO
		  ,a.PASSWORD
		  ,a.STATUS
	FROM ADMIN_PROFILE a
	WHERE a.EMAIL = @Email
	AND   a.PASSWORD = @PassWord;
END

GO
/****** Object:  StoredProcedure [dbo].[BILL_PAYMENT_Details]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BILL_PAYMENT_Details]
    @PaymentID uniqueidentifier
	,@CustID uniqueidentifier
	,@TotalAmount numeric(18,0)
	,@Advance numeric(18,0)
	,@Balance numeric(18,0)
	,@reservationID uniqueidentifier
AS
BEGIN
   INSERT INTO BILL_PAYMENT
	([PAYMENT_ID]
     ,[CUST_ID]
     ,[TOTAL_AMOUNT]
     ,[ADVANCE]
     ,[BALANCE]
	 ,[RESERVE_ID]
	)
	VALUES
	(
	 @PaymentID
	,@CustID
	,@TotalAmount
	,@Advance
	,@Balance
	,@reservationID
	)
	
END

GO
/****** Object:  StoredProcedure [dbo].[BILL_PAYMENT_info]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BILL_PAYMENT_info]
 @ReservationID uniqueidentifier
,@CustID uniqueidentifier
AS
BEGIN
	SELECT R.RESERVE_ID
	  ,R.CUST_ID
	  ,A.ROOM_PRICE
	  FROM RESERVATION R
INNER JOIN ROOM_DETAILS D
ON R.ROOM_ID = D.ROOM_ID
INNER JOIN ROOM_TYPE_INFO A
ON A.ROOM_TYPE = D.ROOM_TYPE
WHERE R.RESERVE_ID = @ReservationID
AND R.CUST_ID = @CustID;
END

GO
/****** Object:  StoredProcedure [dbo].[CUSTOMER_PROFILE_CustomerSignUp]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CUSTOMER_PROFILE_CustomerSignUp] 
	@Cust_ID uniqueidentifier
	, @FirstName nchar(20)
	, @LastName nchar(20)
	, @Address nchar(50)
	, @Email nchar(20)
	,@Phone nvarchar(11)
	,@Gender nchar(7)
	,@PassWord nvarchar(10)
	
AS
BEGIN
	INSERT INTO CUSTOMER_PROFILE
	([CUST_ID]
	,[FIRST_NAME]
	,[LAST_NAME]
	,[ADDRESS]
	,[EMAIL]
	,[PHONE_NO]
	,[GENDER]
	,[STATUS]
	,[PASSWORD]
	)
	Values
	(
	 @Cust_ID
	,@FirstName
	,@LastName
	,@Address
	,@Email
	,@Phone
	,@Gender
	,'ACTIVE'
	,@PassWord
	)
END

GO
/****** Object:  StoredProcedure [dbo].[CUSTOMER_PROFILE_Details]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CUSTOMER_PROFILE_Details]
	@CustID uniqueidentifier
AS
BEGIN
	SELECT c.CUST_ID
	       ,c.FIRST_NAME
		   ,c.LAST_NAME
		   ,c.GENDER
		   ,c.ADDRESS
		   ,c.PHONE_NO
		   ,c.EMAIL
		   ,c.PASSWORD
		  
	FROM CUSTOMER_PROFILE c
	WHERE c.CUST_ID = @CustID;
END

GO
/****** Object:  StoredProcedure [dbo].[CUSTOMER_PROFILE_Edit]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CUSTOMER_PROFILE_Edit]
	@CustID uniqueidentifier
	,@FirstName nchar(20)
	,@LastName nchar(20)
	,@Gender nchar(7)
	,@Address nchar(50)
	,@Email nchar(20)
	,@PhNO  nvarchar(11)
	,@PassWord nvarchar(10)
AS
BEGIN
	UPDATE CUSTOMER_PROFILE
SET
    [FIRST_NAME] = @FirstName
	,[LAST_NAME] = @LastName
	,[GENDER] = @Gender
	,[ADDRESS] = @Address
	,[EMAIL] = @Email
	,[PHONE_NO] = @PhNO
	,[PASSWORD] = @PassWord

WHERE
     [CUST_ID] = @CustID;
END

GO
/****** Object:  StoredProcedure [dbo].[CUSTOMER_PROFILE_LogIn]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CUSTOMER_PROFILE_LogIn] 
	@Email nchar(20)
    ,@PassWord nvarchar(10)
AS
BEGIN
   SELECT 
        c.CUST_ID
	    ,c.FIRST_NAME
		,c.LAST_NAME
		,c.ADDRESS
		,c.EMAIL
		,c.PHONE_NO
		,c.GENDER
		,c.PASSWORD
		,c.STATUS
	FROM CUSTOMER_PROFILE c
	WHERE c.EMAIL = @Email
	AND   c.PASSWORD = @PassWord;
	
END

GO
/****** Object:  StoredProcedure [dbo].[MY_RESRVATIONS_Details]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MY_RESRVATIONS_Details]
	@CustID uniqueidentifier
AS
BEGIN
	SELECT R.RESERVE_ID
	  ,R.CUST_ID
	  ,R.ARRIVAL_DATE
	  ,R.DEPARTURE_DATE
	  ,R.ROOM_ID
	  ,A.ROOM_TYPE
	  ,A.DESCRIPTION
	  ,A.ROOM_PRICE
	  ,A.MAX_GUEST
	  ,A.DISCOUNT
	  ,B.ADVANCE

	  FROM RESERVATION R
INNER JOIN ROOM_DETAILS D
ON R.ROOM_ID = D.ROOM_ID
INNER JOIN ROOM_TYPE_INFO A
ON A.ROOM_TYPE = D.ROOM_TYPE
INNER JOIN BILL_PAYMENT B
ON B.RESERVE_ID = R.RESERVE_ID
WHERE R.CUST_ID = @CustID;
END

GO
/****** Object:  StoredProcedure [dbo].[RESERVATION_booking]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RESERVATION_booking]
  @ReserveID uniqueidentifier
  ,@CustID uniqueidentifier
  ,@ArrivalDate datetime
  ,@Departure datetime
  ,@RoomID nvarchar(10)
AS
BEGIN
     INSERT INTO RESERVATION
	([RESERVE_ID]
     ,[CUST_ID]
     ,[ARRIVAL_DATE]
     ,[DEPARTURE_DATE]
     ,[ROOM_ID]
     ,[BOOKING_STATUS]
	)
	VALUES
	(
	 @ReserveID 
	,@CustID 
	,@ArrivalDate 
	,@Departure
	,@RoomID 
	,'DRAFT'
	)
	
END

GO
/****** Object:  StoredProcedure [dbo].[RESERVE_ROOM_details]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RESERVE_ROOM_details]
   @ReservationID uniqueidentifier
   ,@CustID uniqueidentifier
AS
BEGIN
	SELECT R.RESERVE_ID
	  ,R.CUST_ID
	  ,R.ARRIVAL_DATE
      ,R.DEPARTURE_DATE
	  ,D.ROOM_TYPE
	  ,A.DESCRIPTION
	  ,A.MAX_GUEST
	  ,A.ROOM_PRICE
	  ,A.DISCOUNT
	  FROM RESERVATION R
INNER JOIN ROOM_DETAILS D
ON R.ROOM_ID = D.ROOM_ID
INNER JOIN ROOM_TYPE_INFO A
ON A.ROOM_TYPE = D.ROOM_TYPE
WHERE R.RESERVE_ID = @ReservationID
AND R.CUST_ID = @CustID;
END

GO
/****** Object:  StoredProcedure [dbo].[RoomsForPublicView]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RoomsForPublicView]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT c.ROOM_ID
	      ,a.ROOM_TYPE
		  ,a.DESCRIPTION
		  ,a.MAX_GUEST
		  ,a.DISCOUNT
		  ,a.ROOM_PRICE
		  ,c.TOTAL_ROOMS
		  ,c.STATUS
    FROM ROOM_TYPE_INFO a
    INNER JOIN ROOM_DETAILS c
    ON a.ROOM_TYPE = c.ROOM_TYPE;	   
END

GO
/****** Object:  StoredProcedure [dbo].[SEARCH]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SEARCH]
     @ArrivalDate datetime
	 ,@DepartureDate datetime
AS
BEGIN
	SELECT D.ROOM_ID
	  , A.ROOM_TYPE
	  ,A.DESCRIPTION
	  ,A.MAX_GUEST
	  ,A.DISCOUNT
	  ,D.TOTAL_ROOMS
	  ,A.ROOM_PRICE
       FROM ROOM_TYPE_INFO a
       INNER JOIN ROOM_DETAILS D
       ON a.ROOM_TYPE = D.ROOM_TYPE
	   WHERE  D.ROOM_ID IN (select c.ROOM_ID
FROM RESERVATION R 
FULL JOIN ROOM_DETAILS c
ON R.ARRIVAL_DATE  NOT BETWEEN (@ArrivalDate) AND (@DepartureDate) 
AND R.DEPARTURE_DATE  NOT BETWEEN (@ArrivalDate) AND (@DepartureDate) 
WHERE  C.ROOM_ID IN (SELECT C.ROOM_ID FROM  ROOM_DETAILS C
WHERE (select COUNT(*) from RESERVATION R 
WHERE R.ARRIVAL_DATE BETWEEN (@ArrivalDate) AND (@DepartureDate) 
AND R.DEPARTURE_DATE BETWEEN (@ArrivalDate) AND (@DepartureDate)
AND R.BOOKING_STATUS = 'ACTIVE') < C.TOTAL_ROOMS AND C.TOTAL_ROOMS > 0
AND C.STATUS = 'ACTIVE' ));
END

GO
/****** Object:  Table [dbo].[ADMIN_PROFILE]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN_PROFILE](
	[USER_ID] [uniqueidentifier] NOT NULL,
	[PASSWORD] [nchar](8) NOT NULL,
	[FIRST_NAME] [nchar](10) NOT NULL,
	[LAST_NAME] [nchar](10) NOT NULL,
	[PHONE_NO] [nchar](11) NOT NULL,
	[EMAIL] [nvarchar](30) NOT NULL,
	[STATUS] [nchar](5) NOT NULL,
 CONSTRAINT [PK_ADMIN_PROFILE] PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC,
	[EMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BILL_PAYMENT]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILL_PAYMENT](
	[PAYMENT_ID] [uniqueidentifier] NOT NULL,
	[CUST_ID] [uniqueidentifier] NOT NULL,
	[TOTAL_AMOUNT] [numeric](18, 0) NOT NULL,
	[ADVANCE] [numeric](18, 0) NULL,
	[BALANCE] [numeric](18, 0) NULL,
	[RESERVE_ID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_BILL_PAYMENT] PRIMARY KEY CLUSTERED 
(
	[PAYMENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CUSTOMER_PROFILE]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER_PROFILE](
	[CUST_ID] [uniqueidentifier] NOT NULL,
	[FIRST_NAME] [nchar](20) NOT NULL,
	[LAST_NAME] [nchar](20) NOT NULL,
	[ADDRESS] [nchar](50) NOT NULL,
	[EMAIL] [nchar](20) NOT NULL,
	[PHONE_NO] [nvarchar](11) NOT NULL,
	[GENDER] [nchar](7) NOT NULL,
	[STATUS] [nchar](10) NULL,
	[PASSWORD] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_CUSTOMER_PROFILE] PRIMARY KEY CLUSTERED 
(
	[CUST_ID] ASC,
	[EMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RESERVATION]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVATION](
	[RESERVE_ID] [uniqueidentifier] NOT NULL,
	[PAYMENT_ID] [uniqueidentifier] NULL,
	[CUST_ID] [uniqueidentifier] NOT NULL,
	[ARRIVAL_DATE] [datetime] NOT NULL,
	[DEPARTURE_DATE] [datetime] NOT NULL,
	[BOOKING_STATUS] [nvarchar](10) NOT NULL,
	[ROOM_ID] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_RESERVATION] PRIMARY KEY CLUSTERED 
(
	[RESERVE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ROOM_DETAILS]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROOM_DETAILS](
	[ROOM_ID] [nvarchar](10) NOT NULL,
	[ROOM_TYPE] [nvarchar](10) NOT NULL,
	[TOTAL_ROOMS] [numeric](18, 0) NOT NULL,
	[STATUS] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_ROOM_DETAILS] PRIMARY KEY CLUSTERED 
(
	[ROOM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ROOM_TYPE_INFO]    Script Date: 7/21/2017 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROOM_TYPE_INFO](
	[ROOM_TYPE] [nvarchar](10) NOT NULL,
	[ROOM_PRICE] [numeric](18, 0) NOT NULL,
	[DESCRIPTION] [nvarchar](50) NOT NULL,
	[MAX_GUEST] [numeric](18, 0) NOT NULL,
	[DISCOUNT] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ROOM_TYPE_INFO] PRIMARY KEY CLUSTERED 
(
	[ROOM_TYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'fc043a53-d67c-434a-846f-2c46f2272ed4', N'1       ', N'new       ', N'test      ', N'01245578520', N'test1234@gmail.com            ', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'253aaf94-8361-48af-8321-33f59b6569dc', N'1       ', N'Rusdana   ', N'esha      ', N'rusdana2109', N'rusdana2109@gmai', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'0fd9777e-cd16-42d0-b562-476f90442678', N'1       ', N'testnew   ', N'nafees    ', N'0147895525 ', N'testnafees@gmail.com          ', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'9df16b86-be73-4cc4-b19e-8122d14b2d73', N'1       ', N'testAdmin ', N'new       ', N'01789075352', N'test@gmail.com                ', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'59a6292b-d354-4d61-a440-82b4caea7209', N'1       ', N'test      ', N'test      ', N'0123456789 ', N'test12@hotmail.com            ', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'e0dbfb80-d316-466b-91a5-95a9069f8e7a', N'1       ', N'test      ', N'new       ', N'123456     ', N'test1@hotmail.com             ', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'cb58dcf4-5280-4ea4-969e-ad6a6d24f228', N'1       ', N'test123   ', N'Again     ', N'test012@gma', N'test012@gmail.com', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'2c92d287-f301-4499-99aa-aeb875d9d57c', N'1       ', N'admin     ', N'nafees123 ', N'01234567891', N'adminafees@gmail.com          ', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'1e502496-f3a4-4540-bb79-d6dfbd9a2568', N'1       ', N'Admin     ', N'258       ', N'017894568  ', N'admin24@gmail.co', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'12f5383a-71db-4b97-ad7b-df93a47f2d34', N'1       ', N'Admin     ', N'syeda     ', N'01789075352', N'admin123@gmail.c', N'ADMIN')
INSERT [dbo].[ADMIN_PROFILE] ([USER_ID], [PASSWORD], [FIRST_NAME], [LAST_NAME], [PHONE_NO], [EMAIL], [STATUS]) VALUES (N'30900448-8f68-46fc-9436-f42a3d481c35', N'1       ', N'nafees    ', N'admin     ', N'0123456789 ', N'adminafees012@gmail.com', N'ADMIN')
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'e8a1465a-adb5-4d58-a013-1555fa0f99a8', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(7000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(5000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'e34061a5-5db1-4834-9442-1eae18e95c94', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(7000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(5000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'2aac9314-c48c-48a5-8d93-22c3a5b342c0', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(7000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(5000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'f188af30-d664-4f9e-b69b-35f10b8075a6', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(7000 AS Numeric(18, 0)), CAST(5000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'64456a4a-fac6-44a6-a756-44aa12b0c4e8', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(22000 AS Numeric(18, 0)), CAST(10000 AS Numeric(18, 0)), CAST(12000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'1f3aeec1-4c5c-4472-a0de-5bca9401bbe2', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(7000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(5000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'3a83fa1a-838b-404b-8e51-a2e4bad64f0f', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0 AS Numeric(18, 0)), CAST(11000 AS Numeric(18, 0)), CAST(11000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'fb45f2a2-fd7e-4ce2-bdde-b3c0d4ae497a', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(-2000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'a2bb1f0f-07dd-40a9-b9c8-b7a4233bd9af', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(22000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(20000 AS Numeric(18, 0)), N'737367d6-0797-40c4-8e73-38d1be1e87ca')
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'd4424323-998a-4ec9-92f8-c73659939e91', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0 AS Numeric(18, 0)), CAST(11000 AS Numeric(18, 0)), CAST(11000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'f71a2f26-c6e5-4c6f-9599-cb55726c8c7a', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(-2000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'd4d4c2a5-0208-4e8d-a1c2-e7e25aa49a69', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(7000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(5000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'1bc299f7-d9aa-4738-a59d-ec0461f20550', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(7000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(5000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[BILL_PAYMENT] ([PAYMENT_ID], [CUST_ID], [TOTAL_AMOUNT], [ADVANCE], [BALANCE], [RESERVE_ID]) VALUES (N'91f60499-6936-4e9e-94f1-f29590804583', N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(7000 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(5000 AS Numeric(18, 0)), NULL)
INSERT [dbo].[CUSTOMER_PROFILE] ([CUST_ID], [FIRST_NAME], [LAST_NAME], [ADDRESS], [EMAIL], [PHONE_NO], [GENDER], [STATUS], [PASSWORD]) VALUES (N'48f770f5-a2b6-4a44-ad5d-16ac759ca08f', N'syeda               ', N'esha                ', N'rayer bazar                                       ', N'rusdana2101@mail.com', N'01234587898', N'female ', N'ACTIVE    ', N'123')
INSERT [dbo].[CUSTOMER_PROFILE] ([CUST_ID], [FIRST_NAME], [LAST_NAME], [ADDRESS], [EMAIL], [PHONE_NO], [GENDER], [STATUS], [PASSWORD]) VALUES (N'c1075302-9392-4387-8b4a-3765d84680a7', N'Nafees              ', N'Salman khan         ', N'puran dhaka                                       ', N'nfs123@gmail.com    ', N'01785245888', N'male   ', N'ACTIVE    ', N'1234')
INSERT [dbo].[CUSTOMER_PROFILE] ([CUST_ID], [FIRST_NAME], [LAST_NAME], [ADDRESS], [EMAIL], [PHONE_NO], [GENDER], [STATUS], [PASSWORD]) VALUES (N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', N'usernew             ', N'123                 ', N'dhaka                                             ', N'user123@gmail.com   ', N'01789075352', N'female ', N'ACTIVE    ', N'1')
INSERT [dbo].[CUSTOMER_PROFILE] ([CUST_ID], [FIRST_NAME], [LAST_NAME], [ADDRESS], [EMAIL], [PHONE_NO], [GENDER], [STATUS], [PASSWORD]) VALUES (N'423f5f27-bc50-47a5-adb8-5f69259e7ffd', N'user                ', N'zamal               ', N'dhaka                                             ', N'zamal123@gmail.com  ', N'017852369', N'male   ', N'ACTIVE    ', N'1')
INSERT [dbo].[CUSTOMER_PROFILE] ([CUST_ID], [FIRST_NAME], [LAST_NAME], [ADDRESS], [EMAIL], [PHONE_NO], [GENDER], [STATUS], [PASSWORD]) VALUES (N'9ec8098b-4c17-4a11-9463-852ac2f59850', N'abc                 ', N'esha                ', N'canada                                            ', N'talha2101@gmail.com ', N'01234587898', N'female ', N'ACTIVE    ', N'1')
INSERT [dbo].[CUSTOMER_PROFILE] ([CUST_ID], [FIRST_NAME], [LAST_NAME], [ADDRESS], [EMAIL], [PHONE_NO], [GENDER], [STATUS], [PASSWORD]) VALUES (N'35f14a75-e7ef-421e-8f59-a751c6ba1d10', N'Syed                ', N'sarwar hossain      ', N'dhaka                                             ', N'sarwar123@gmail.com ', N'01746999148', N'Male   ', N'ACTIVE    ', N'1')
INSERT [dbo].[CUSTOMER_PROFILE] ([CUST_ID], [FIRST_NAME], [LAST_NAME], [ADDRESS], [EMAIL], [PHONE_NO], [GENDER], [STATUS], [PASSWORD]) VALUES (N'4b6fad33-f449-4d4e-96fa-b5e1626a007a', N'test                ', N'323                 ', N'dhaka                                             ', N'test323@gmail.com   ', N'01789075352', N'female ', N'ACTIVE    ', N'1')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'a3d6d2b4-60a7-4fb0-b66d-0b718c7a629d', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'4ce880d5-c7ff-4e6b-ae07-1e37cb7dbe50', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7D000000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'509eac88-5ad2-4bf9-949d-2bdf37412be2', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7EA00000000 AS DateTime), CAST(0x0000A7ED00000000 AS DateTime), N'DRAFT', N'111')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'737367d6-0797-40c4-8e73-38d1be1e87ca', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7EA00000000 AS DateTime), CAST(0x0000A80900000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'4c147030-cb27-4ba5-adf7-58ef6855f915', NULL, N'48f770f5-a2b6-4a44-ad5d-16ac759ca08f', CAST(0x0000A7F500000000 AS DateTime), CAST(0x0000A7FC00000000 AS DateTime), N'DRAFT', N'555')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'00da8d45-d91a-4f3a-91d8-5b2d5790a518', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'5edc9449-8686-40a8-b974-612c20e434eb', NULL, N'c1075302-9392-4387-8b4a-3765d84680a7', CAST(0x0000A80600000000 AS DateTime), CAST(0x0000A84300000000 AS DateTime), N'ACTIVE', N'111')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'e4c8ac71-2e24-4e16-8133-66e950cbeb72', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'37ed24ed-7717-49c4-97ef-677e3278a432', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7D000000000 AS DateTime), N'DRAFT', N'556')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'b89c2bd9-60e6-41fc-99c5-7570e01fff19', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CD00000000 AS DateTime), CAST(0x0000A7D000000000 AS DateTime), N'DRAFT', N'111')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'f0f31083-80b0-4470-aca7-9aeabe9a5065', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7D000000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'11e5c7b3-8c91-446c-8efa-a51c19a10eec', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'0ad962d7-a0ba-4408-ac07-cd45855804df', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'3f4170fe-0088-4684-bf8f-cec53533beed', NULL, N'c1075302-9392-4387-8b4a-3765d84680a7', CAST(0x0000A7CC00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'ACTIVE', N'111')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'04135598-e638-447b-87ce-d1dc0f949f31', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CE00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'47d4b881-8188-4208-93db-d77a71b36801', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'95006225-74a4-45db-9872-deb39b9c92b0', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7D000000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'0acd56c8-2435-4158-83d1-e1cdb8d1c47a', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7C900000000 AS DateTime), CAST(0x0000A7CB00000000 AS DateTime), N'DRAFT', N'111')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'97dc6573-c387-4c5e-aeb0-e3d6eed8ff8b', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'556')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'6c0ce40e-2c1a-45f2-953d-e71b58e2d376', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'a7e47147-b401-415a-bbb8-f629d4c0783d', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'556')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'a969f789-14cc-4e68-a9a2-fc23db265523', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CD00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'fd7e8e44-8e55-44db-b89a-fcdaf5d25be1', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CF00000000 AS DateTime), N'DRAFT', N'556')
INSERT [dbo].[RESERVATION] ([RESERVE_ID], [PAYMENT_ID], [CUST_ID], [ARRIVAL_DATE], [DEPARTURE_DATE], [BOOKING_STATUS], [ROOM_ID]) VALUES (N'e6ff5683-8f38-47a4-af81-ff40ad8014d7', NULL, N'e28bd9c1-f35e-4ad2-b019-44b0f1f7e0e1', CAST(0x0000A7CB00000000 AS DateTime), CAST(0x0000A7CF00000000 AS DateTime), N'DRAFT', N'666')
INSERT [dbo].[ROOM_DETAILS] ([ROOM_ID], [ROOM_TYPE], [TOTAL_ROOMS], [STATUS]) VALUES (N'111', N'Double', CAST(8 AS Numeric(18, 0)), N'ACTIVE')
INSERT [dbo].[ROOM_DETAILS] ([ROOM_ID], [ROOM_TYPE], [TOTAL_ROOMS], [STATUS]) VALUES (N'213', N'Single', CAST(0 AS Numeric(18, 0)), N'ACTIVE')
INSERT [dbo].[ROOM_DETAILS] ([ROOM_ID], [ROOM_TYPE], [TOTAL_ROOMS], [STATUS]) VALUES (N'555', N'SUPERIOR', CAST(0 AS Numeric(18, 0)), N'ACTIVE')
INSERT [dbo].[ROOM_DETAILS] ([ROOM_ID], [ROOM_TYPE], [TOTAL_ROOMS], [STATUS]) VALUES (N'556', N'SEA VIEW', CAST(10 AS Numeric(18, 0)), N'ACTIVE')
INSERT [dbo].[ROOM_DETAILS] ([ROOM_ID], [ROOM_TYPE], [TOTAL_ROOMS], [STATUS]) VALUES (N'666', N'VIP', CAST(5 AS Numeric(18, 0)), N'ACTIVE')
INSERT [dbo].[ROOM_DETAILS] ([ROOM_ID], [ROOM_TYPE], [TOTAL_ROOMS], [STATUS]) VALUES (N'777', N'Suit', CAST(2 AS Numeric(18, 0)), N'ACTIVE')
INSERT [dbo].[ROOM_TYPE_INFO] ([ROOM_TYPE], [ROOM_PRICE], [DESCRIPTION], [MAX_GUEST], [DISCOUNT]) VALUES (N'Double', CAST(7000 AS Numeric(18, 0)), N'Two Single beds', CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[ROOM_TYPE_INFO] ([ROOM_TYPE], [ROOM_PRICE], [DESCRIPTION], [MAX_GUEST], [DISCOUNT]) VALUES (N'SEA VIEW ', CAST(14000 AS Numeric(18, 0)), N'ONE KING SIZE BED', CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[ROOM_TYPE_INFO] ([ROOM_TYPE], [ROOM_PRICE], [DESCRIPTION], [MAX_GUEST], [DISCOUNT]) VALUES (N'Single', CAST(5000 AS Numeric(18, 0)), N'One king size bed', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[ROOM_TYPE_INFO] ([ROOM_TYPE], [ROOM_PRICE], [DESCRIPTION], [MAX_GUEST], [DISCOUNT]) VALUES (N'Suit', CAST(10000 AS Numeric(18, 0)), N'A big master bed ', CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[ROOM_TYPE_INFO] ([ROOM_TYPE], [ROOM_PRICE], [DESCRIPTION], [MAX_GUEST], [DISCOUNT]) VALUES (N'SUPERIOR', CAST(12000 AS Numeric(18, 0)), N'Two bedroom', CAST(4 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[ROOM_TYPE_INFO] ([ROOM_TYPE], [ROOM_PRICE], [DESCRIPTION], [MAX_GUEST], [DISCOUNT]) VALUES (N'VIP', CAST(22000 AS Numeric(18, 0)), N'SUIT', CAST(4 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
ALTER TABLE [dbo].[ROOM_DETAILS]  WITH CHECK ADD  CONSTRAINT [FK_ROOM_DETAILS_ROOM_TYPE_INFO] FOREIGN KEY([ROOM_TYPE])
REFERENCES [dbo].[ROOM_TYPE_INFO] ([ROOM_TYPE])
GO
ALTER TABLE [dbo].[ROOM_DETAILS] CHECK CONSTRAINT [FK_ROOM_DETAILS_ROOM_TYPE_INFO]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INSERT ADMIN INFORMATIONS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_PROFILE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'USER BILL PAYMENT INFO ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL_PAYMENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CUSTOMER INFORMATION ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CUSTOMER_PROFILE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EACH ROOM TYPE INFOMORMATIONS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ROOM_TYPE_INFO'
GO
