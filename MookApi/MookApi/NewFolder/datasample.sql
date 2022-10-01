USE [MookDB]
GO

INSERT INTO [dbo].[AspNetRoles]
           ([IsDeleted],[Name],[NormalizedName],[ConcurrencyStamp])
     VALUES
           (0,'admin','ADMIN','kldjehfkajsfgicreiucberwvuygerv'),
		    (0,'student','STUDENT','kldjehfkajsfgicreiucberwvuygerv')
GO

SELECT * FROM AspNetRoles

GO

INSERT INTO [dbo].[AspNetUsers]
           ([CreatedDate],[IsActive],[IsDeleted],[UserName],[NormalizedUserName],[Email],[NormalizedEmail],
		   [EmailConfirmed],[PasswordHash],[SecurityStamp],[ConcurrencyStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnd],[LockoutEnabled],[AccessFailedCount])
     VALUES
           ('2022-12-15',1,0,'amir','AMIR','amir@hosein.com','AMIR@HOSEIN.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09121212112',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'ali','ALI','ali@ali.com','ALI@ALI.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09399898998',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'sara','SARA','ms@sara.com','MS@SARA.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09131313113',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'zahra','ZAHRA','zahra@zhr.com','ZAHRA@ZHR.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09101010100',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'mahsa','MAHSA','mah@sa.com','MAH@SA.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09181818118',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'mahdi','MAHDI','mah@di.com','MAH@DI.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09353535335',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'ehsan','EHSAN','eh@san.com','EH@SAN.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09191919119',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'hamid','HAMID','ha@mid.com','HA@MID.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','092232323332',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'nargess','NARGESS','nar@ge.ss','NAR@GE.SS',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09252626226',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'farid','FARID','far@id.com','FAR@ID.COM',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09121212778',1,'false','2022-12-12',0,0),
		   ('2022-12-15',1,0,'kiarash','KIARASH','kia@ra.sh','KIA@RA.SH',1,'cjkhgfkcjgwcwehgrfviurhe','cfhckljavhsdjklgv','cjkwfckjghfasd','09134578987',1,'false','2022-12-12',0,0)
GO

SELECT * FROM AspNetUsers

GO
INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId],[RoleId])
     VALUES
           (1,1),(2,1),(3,2),(4,2),(5,2)

GO

SELECT * FROM AspNetUserRoles

GO

INSERT INTO [dbo].[Admins]
           ([AdminName],[UsersFkId],[AcceptedAdminID],[CreatedDate],[UpdateDate],[IsDeleted])
     VALUES
           (N'امیر',1,1,'2022-12-12','2022-12-12',0),
		   (N'علی',2,1,'2045-08-19','2045-08-23',0)


GO

SELECT * FROM Admins

GO

INSERT INTO [dbo].[Students]
           ([StudentName],[StudentSSID],[StudentUniversityID],[SpamCount],[IsSuspended],[IsRegistered]
           ,[IsBlocked],[reportPoint],[IsSpam],[usersId],[AcceptedAdminID],[CreatedDate],[UpdateDate],[IsDeleted])
     VALUES
           (N'زهرا زهرایی',  N'3516543142787',N'687968047897',2120,0,1,0,0 ,1,4, 1,'2045-04-08','2020-12-12',0),--spam
		   (N'سارا سارایی',  N'6745684586006',N'350468456464',0   ,1,1,0,0 ,0,3, 1,'2021-05-18','2020-12-12',0),--suspend
		   (N'مهسا مهسایی',  N'5435278798799',N'350465746054',0   ,0,0,0,0 ,0,5, 1,'2022-11-08','2020-12-12',0),--registered
		   (N'کیارش کیارشی', N'6354684665468',N'780674198178',0   ,0,0,0,0 ,0,11,2,'2019-12-25','2020-12-12',0),--registered
		   (N'احسان احسانی', N'3512345123134',N'896768074871',0   ,0,1,1,0 ,0,6, 2,'2000-05-11','2020-12-12',0),--blocked
		   (N'حمید حمیدی',   N'3645486453455',N'897640176534',0   ,0,1,1,0 ,0,7, 1,'2015-04-09','2020-12-12',0),--blocked
		   (N'نرگس نرگسی',   N'8956168123443',N'354678048000',10  ,0,1,0,0 ,1,8, 2,'2029-09-17','2020-12-12',0),--spam
		   (N'فرید فریدی' ,  N'7317864556654',N'874658786656',0   ,0,1,0,25,0,9, 2,'2010-01-12','2020-12-12',0)--reportpoint
GO

SELECT * FROM Students

GO

INSERT INTO [dbo].[Books]
           ([BookName],[BookPagesCount],[BookRating],[publisher],[Author],[BookRatingCount]
           ,[BookDescription],[IsAvailable],[IsDamaged],[AcceptedAdminID],[CreatedDate],[UpdateDate],[IsDeleted])
     VALUES
		   (N'سیلماریلیون',125,0,N'فروشگاه آخرین کتاب',N'تالکین',0
		   ,N'یکی از مهمترین کتابهای تاریخ بشریت',1,0,1,'2012-05-05','2012-04-05',0),
           (N'دروس بی مزه',328,0,N'دانشکده فنی مهندسی',N'جمعی از اساتید',1200
		   ,N'این کتاب درباره ی دروسی است که اساتید تدریس می کنند',1,0,1,'2012-04-05','2012-04-05',0),
		   (N'مهندسی نرم افزار',351,0,N'فروشگاه شهر کتاب',N'نوید نویدی',0
		   ,N'از دروس دانشگاهی مخصوص رشته های مهندسی',1,0,1,'2012-04-05','2015-09-21',0),
		   (N'فیزیک هالیدی',789,0,N'کتاب های شهر',N'دیوید هالیدی',0
		   ,N'دروس پایه ی فیزیک عمومی که عموما بچه ها پاس نمیکنند',1,0,1,'2018-06-18','2018-06-18',0),
		   (N'بیشعوری',100,0,N'انتشارات دانشجویان جوان دانشکده فنی مهندسی ',N'خاویر کرمنت',1200
		   ,N'بهتره بخونید شاید براتون مفید شد',1,0,1,'2022-03-25','2017-10-02',0),
		   (N'غورباقه ات را قورت بده',687,0,N'دانشکده فنی مهندسی',N'جمعی از اساتید',0
		   ,N'حتما نویسنده دلیل خوبی برای این اسم داشته',1,0,1,'2021-12-09','2018-06-18',0),
		   (N'میکروکنترلر',53,0,N'کتاب های شهر',N'محمد فریدونی',31
		   ,N'از مجموعه کتاب های ترکیب جذابیت با کابوس',1,0,1,'2016-01-30','2012-04-05',0),
		   (N'چگونه استاد راهنما شویم',122,0,N'استاد یار',N'ویکتور هوگو',80
		   ,N'مخصوص اساتید',1,0,1,'2007-03-28','2020-02-21',0),
		   (N'حسن کچل',198,0,N'استاد یار',N'چارلز دیکنز',96
		   ,N'کتابی مفید برای مدیران برتر',1,0,1,'2000-08-01','2012-05-05',0),
		   (N'سیستم عامل',212,0,N'کتابهای شرق',N'یوبابا',360
		   ,N'نسخه تک جلدی از مجموعه دروس بی مزه',1,0,1,'2001-09-12','2012-04-05',0),
		   (N'Advanced English Grammar',313,0,N'کتابهای شهر',N'James Mark',548
		   ,N'English grammar advanced lavel of dificulity',1,0,1,'2005-04-17','2020-02-21',0),
		   (N'وصایای امام',200,0,N'فروشگاه وصایا',N'امام',10
		   ,N'درباره امام و وصایاش',1,0,1,'2020-02-21','2012-04-05',0),
		   (N'نبرد من',600,0,N'شهر کتاب',N'آدولف هیتلر',0
		   ,N'هیتلر و نبردش و قصه هاش و بلاه بلاه',1,0,1,'2019-03-15','2012-04-05',0),
		   (N'دنیای خالی از قهرمان',704,0,N'نشر کتاب',N'براندون مول',0
		   ,N'یک کتاب فانتزی برپایه ی رویا و خیالات و موهومات',1,0,1,'2014-11-09','2017-10-02',0),
		   (N'در جست و جوی معما',996,0,N'نشر کتاب',N'سیدنی شلدون',0
		   ,N'یک کتاب پلیسی - تخیلی ',1,0,1,'2017-10-02','2018-06-18',0),
		   (N'هری پاتر',254,0,N'شهر کتاب',N'رولینگ',897
		   ,N'یه بچه مدرسه ای که قهرمانان منفی داستان رو به راحتی می کشه',1,0,1,'2012-04-07','2020-02-21',0),
		   (N'آشفتگی',254,0,N'شهر کتاب',N'توماس برنهارد',897
		   ,N'یکی از جذاب ترین کتابهایی که نمیدونم موضوعش چیه و صرفا برای پر کردن دیتا در دیتابیس آوردم',1,0,1,'2012-04-07','2020-02-21',0)
GO

SELECT * FROM Books

GO

INSERT INTO [dbo].[Comments]
           ([FatherID],[CommentHeader],[CommentContent],[CommentLike],[CommentDislike],[CommentFlag]
		   ,[IsAdminAccepted],[StudentID],[BookID],[AcceptedAdminID],[CreatedDate],[UpdateDate],[IsDeleted])
     VALUES
           (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0),
		   (0,N'آشغال به تمام معنا',N'نویسنده ی بی مغز با کتاب احمقانه اش بهتره بره بمیره',0,0,1,1,7,16,1,'2019-12-25','2020-12-25',0),--flagged
		   (0,N'^%#&^%#&%^',N'بهتره توی مغز نویسنده اش &^$)^&$* &*$*&$',0,0,1,1,3,16,1,'2006-05-09','2022-04-03',1),--flagged, deleted
		   (0,N'به زور',N'مجبور نبودم نمیخوندمش این چیه اخه',0,0,1,1,3,10,1,'2014-05-09','2016-12-25',0),--flagged
		   (0,N'مزخرف ترین کتاب دانشگاهی قرن',N'',0,0,1,1,7,10,1,'2022-06-01','2022-06-01',0),--flagged
		   (0,N'خسته کننده',N'نه نتها مطالب جالبی نداشت، بلکه نویسنده گند زده بود به تصورات ما درباره سیستم عامل',0,0,1,1,3,10,1,'2018-11-17','2020-12-25',0),--flagged
		   (0,N'بچه گانه',N'این کتاب رو یا بچه میخونه یا احمق',0,0,1,1,3,16,1,'1995-12-20','2020-12-25',0),--flagged
		   (0,N'آشغال',N'باید نویسنده اش رو از سقف آویزون کرد',0,0,1,1,7,16,1,'2015-02-22','2020-12-25',1),--flagged, deleted
		   (0,N'گیج کننده',N'این کتابو کاش میتونستم آتیش بزنم',0,0,1,1,7,10,1,'2018-03-30','2020-12-25',1),--flagged, deleted
		   (0,N'نویسنده دیوانه',N'',0,0,1,1,3,16,1,'2020-12-19','2000-01-25',1),--flagged, deleted
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,1,1,3,16,1,'2002-12-25','2020-12-25',1),--flagged, deleted
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0),
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0),
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0),
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0),
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0),
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0),
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0),
		   (0,N'کتاب عالی',N'بهترین کتاب دنیا',0,0,0,1,3,1,1,'2020-12-25','2020-12-25',0)

GO

INSERT INTO [dbo].[RequestHeader]
           ([RequestAcceptedDate],[IsAccepted],[RequestFinishedDate],[IsDelayed],[DelayDays],[RequestDecription],[StudentID],[AcceptedAdminID],[CreatedDate],[UpdateDate],[IsDeleted])
     VALUES
           (null,0,null,0,null,null,5,null,'2012-05-12','2012-05-12',0),
		   (null,0,null,0,null,null,1,null,'2019-11-08','2019-11-08',0)
GO

INSERT INTO [dbo].[RequestDetails]
           ([RequestDetailDescription],[IsDamaged],[IsLost],[BookID],[RequestHeaderID],[AcceptedAdminID],[CreatedDate],[UpdateDate],[IsDeleted])
     VALUES
           (null,0,0,1,1,null,'2015-05-12','2015-05-12',0),
		   (null,0,0,2,1,null,'2015-05-12','2015-05-12',0),
		   (null,0,0,3,1,null,'2015-05-12','2015-05-12',0),
		   (null,0,0,4,1,null,'2015-05-12','2015-05-12',0),
		   (null,0,0,5,2,null,'2015-05-12','2015-05-12',0),
		   (null,0,0,6,2,null,'2015-05-12','2015-05-12',0),
		   (null,0,0,7,2,null,'2015-05-12','2015-05-12',0),
		   (null,0,0,8,2,null,'2015-05-12','2015-05-12',0),
		   (null,0,0,9,2,null,'2015-05-12','2015-05-12',0)
GO
SELECT * FROM AspNetUsers
SELECT * FROM AspNetRoles
SELECT * FROM Admins
SELECT * FROM Students
SELECT * FROM Books
SELECT * FROM Comments
SELECT * FROM RequestHeader
SELECT * FROM RequestDetails

GO

INSERT INTO [dbo].[RequestHeader]
           ([RequestAcceptedDate],[IsAccepted],[RequestFinishedDate],[IsDelayed],[DelayDays]
           ,[RequestDecription],[StudentID],[AcceptedAdminID],[CreatedDate],[UpdateDate],[IsDeleted])
     VALUES
           ('2015-05-15',0,null,0,null,null,3,1,'2018-11-09','2012-01-05',0),--new
		   ('2019-07-25',0,null,0,null,null,2,1,'2005-05-15','2005-05-11',0),--new
		   ('2012-05-11',0,null,0,null,null,2,1,'2002-07-18','2002-02-09',0),--new
		   ('2011-09-25',0,null,0,null,null,3,1,'2022-11-20','2022-03-18',0),--new
		   ('2015-05-15',0,null,0,null,null,5,1,'2018-11-09','2012-01-05',0),--new
		   ('2019-07-25',0,null,0,null,null,5,1,'2005-05-15','2005-05-11',0),--new
		   ('2012-05-11',0,null,0,null,null,5,1,'2002-07-18','2002-02-09',0),--new
		   ('2011-09-25',0,null,0,null,null,5,1,'2022-11-20','2022-03-18',0),--new
		   ('2019-10-11',1,'2012-02-02',1,1,null,6,1,'2014-04-02','2014-05-02',0),--delayed
		   ('2003-03-20',1,'2012-02-02',1,3,null,3,1,'2000-11-01','2000-04-01',0),--delayed
		   ('2003-03-20',1,'2012-02-02',1,80,null,3,1,'2000-11-01','2000-04-01',0),--delayed
		   ('2019-10-11',1,'2012-02-02',1,256,null,6,1,'2014-04-02','2014-05-02',0),--delayed
		   ('2003-03-20',1,'2012-02-02',1,1,null,3,1,'2000-11-01','2000-04-01',0),--delayed
		   ('2003-03-20',1,'2012-02-02',1,12,null,7,1,'2000-11-01','2000-04-01',0),--delayed
		   ('2003-03-20',1,null,0,null,null,2,1,'2000-11-01','2000-04-01',0),
		   ('2003-03-20',1,null,0,null,null,3,1,'2000-11-01','2000-04-01',0)

GO

SELECT * FROM [RequestHeader] 

GO

INSERT INTO [dbo].[RequestDetails]
           ([RequestDetailDescription]
           ,[IsDamaged]
           ,[IsLost]
           ,[BookID]
           ,[RequestHeaderID]
           ,[AcceptedAdminID]
           ,[CreatedDate]
           ,[UpdateDate]
           ,[IsDeleted])
     VALUES
           (null,null,null,2 ,1,null,'2015-05-15','2015-05-15',0),
		   (null,null,null,2 ,1,null,'2019-07-25','2019-07-25',0),
		   (null,null,null,3 ,2,null,'2012-05-11','2012-05-11',0),
		   (null,null,null,4 ,4,null,'2011-09-25','2011-09-25',0),
		   (null,null,null,5 ,8,null,'2015-05-15','2015-05-15',0),
		   (null,null,null,6 ,8,null,'2019-07-25','2019-07-25',0),
		   (null,null,null,7 ,8,null,'2012-05-11','2012-05-11',0),
		   (null,null,null,8 ,8,null,'2011-09-25','2011-09-25',0),
		   (null,null,null,9 ,4,null,'2019-10-11','2019-10-11',0),
		   (null,null,null,10,4,null,'2003-03-20','2003-03-20',0),
		   (null,null,null,11,1,null,'2003-03-20','2003-03-20',0),
		   (null,null,null,11,2,null,'2019-10-11','2019-10-11',0),
		   (null,null,null,12,6,null,'2003-03-20','2003-03-20',0),
		   (null,null,null,13,6,null,'2019-07-25','2003-03-20',0),
		   (null,null,null,14,6,null,'2012-05-11','2003-03-20',0),
		   (null,null,null,15,9,null,'2011-09-25','2003-03-20',0),
		   (null,null,null,16,9,null,'2015-05-15','2015-05-15',0),
		   (null,null,null,17,9,null,'2019-07-25','2015-05-15',0),
		   (null,null,null,2 ,2,null,'2012-05-11','2015-05-15',0),
		   (null,null,null,2 ,2,null,'2011-09-25','2019-07-25',0),
		   (null,null,null,3 ,2,null,'2019-07-25','2012-05-11',0),
		   (null,null,null,4 ,15,null,'2012-05-11','2011-09-25',0),
		   (null,null,null,5 ,15,null,'2011-09-25','2015-05-15',0),
		   (null,null,null,6 ,15,null,'2015-05-15','2019-07-25',0),
		   (null,null,null,7 ,15,null,'2019-07-25','2012-05-11',0),
		   (null,null,null,8 ,16,null,'2012-05-11','2011-09-25',0),
		   (null,null,null,9 ,16,null,'2011-09-25','2019-07-25',0),
		   (null,null,null,10,16,null,'2019-10-11','2015-05-15',0),
		   (null,null,null,11,16,null,'2003-03-20','2018-11-09',0),
		   (null,null,null,11,14,null,'2003-03-20','2005-05-15',0),
		   (null,null,null,12,14,null,'2019-10-11','2002-07-18',0),
		   (null,null,null,13,14,null,'2003-03-20','2022-11-20',0),
		   (null,null,null,14,13,null,'2019-07-25','2018-11-09',0),
		   (null,null,null,15,13,null,'2015-05-15','2005-05-15',0),
		   (null,null,null,16,13,null,'2018-11-09','2002-07-18',0),
		   (null,null,null,2 ,12,null,'2015-05-15','2015-05-15',0),
		   (null,null,null,2 ,12,null,'2019-07-25','2019-07-25',0),
		   (null,null,null,3 ,2,null,'2012-05-11','2012-05-11',0),
		   (null,null,null,4 ,12,null,'2011-09-25','2011-09-25',0),
		   (null,null,null,5 ,12,null,'2015-05-15','2015-05-15',0),
		   (null,null,null,6 ,11,null,'2019-07-25','2019-07-25',0),
		   (null,null,null,7 ,11,null,'2012-05-11','2012-05-11',0),
		   (null,null,null,8 ,11,null,'2011-09-25','2011-09-25',0),
		   (null,null,null,9 ,11,null,'2019-10-11','2019-10-11',0),
		   (null,null,null,10,10,null,'2003-03-20','2003-03-20',0),
		   (null,null,null,11,10,null,'2003-03-20','2003-03-20',0),
		   (null,null,null,11,10,null,'2019-10-11','2019-10-11',0),
		   (null,null,null,12,4,null,'2003-03-20','2003-03-20',0),
		   (null,null,null,13,4,null,'2019-07-25','2003-03-20',0),
		   (null,null,null,14,4,null,'2012-05-11','2003-03-20',0),
		   (null,null,null,15,5,null,'2011-09-25','2003-03-20',0),
		   (null,null,null,16,5,null,'2015-05-15','2015-05-15',0),
		   (null,null,null,17,5,null,'2019-07-25','2015-05-15',0),
		   (null,null,null,2 ,2,null,'2012-05-11','2015-05-15',0),
		   (null,null,null,2 ,2,null,'2011-09-25','2019-07-25',0),
		   (null,null,null,3 ,6,null,'2019-07-25','2012-05-11',0),
		   (null,null,null,4 ,6,null,'2012-05-11','2011-09-25',0),
		   (null,null,null,5 ,6,null,'2011-09-25','2015-05-15',0),
		   (null,null,null,6 ,6,null,'2015-05-15','2019-07-25',0),
		   (null,null,null,7 ,6,null,'2019-07-25','2012-05-11',0),
		   (null,null,null,8 ,3,null,'2012-05-11','2011-09-25',0),
		   (null,null,null,9 ,3,null,'2011-09-25','2019-07-25',0),
		   (null,null,null,10,3,null,'2019-10-11','2015-05-15',0),
		   (null,null,null,11,3,null,'2003-03-20','2018-11-09',0),
		   (null,null,null,11,3,null,'2003-03-20','2005-05-15',0),
		   (null,null,null,12,3,null,'2019-10-11','2002-07-18',0),
		   (null,null,null,13,3,null,'2003-03-20','2022-11-20',0),
		   (null,null,null,14,1,null,'2019-07-25','2018-11-09',0),
		   (null,null,null,15,1,null,'2015-05-15','2005-05-15',0),
		   (null,null,null,16,1,null,'2018-11-09','2002-07-18',0)

GO

SELECT * FROM [RequestDetails]