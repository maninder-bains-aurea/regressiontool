Drop table RegressionFiles;
Drop table RegressionStatus;
Drop table Regression_ASP_TP;
Drop table Regression;
Drop table LoginUser;


CREATE TABLE [dbo].[LoginUser]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] NCHAR(200) NOT NULL, 
    [Password] NCHAR(200) NOT NULL
)

CREATE TABLE [dbo].[RegressionStatus]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StatusType] INT NOT NULL, 
    [Description] NCHAR(100) NOT NULL    
)

CREATE TABLE [dbo].[Regression]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[UserId] INT NOT NULL, 
    [MapName] NCHAR(200) NULL, 
    [StatusId] INT NULL,
	constraint fk_regression_statusid foreign key (StatusId) references RegressionStatus (Id),
	constraint fk_regression_userid foreign key (userid) references LoginUser (Id)
)

CREATE TABLE [dbo].[Regression_ASP_TP]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [RegressionId] INT NOT NULL, 
    [Asp_tpId] INT NOT NULL, 
    [Asp_tpCode] NCHAR(100) NOT NULL, 
    [StatusId] INT NOT NULL,
	constraint fk_regression_asp_tp_statusid foreign key (StatusId) references RegressionStatus (Id),
	constraint fk_regression_asp_tp_regressionid foreign key (RegressionID) references Regression (Id)
)


CREATE TABLE [dbo].[RegressionFiles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Regression_ASP_TPID] INT NOT NULL, 
    [PresTranslatedFilename] NCHAR(200) NOT NULL, 
    [PostTranslatedFilename ] NCHAR(200) NOT NULL, 
    [LocalLoationPreTranslatedFile] NCHAR(200) NOT NULL, 
    [LocalLoationPostTranslatedFile] NCHAR(200) NOT NULL, 
    [StatusId] INT NOT NULL	,
	constraint fk_regressionfiles_statusid foreign key (StatusId) references RegressionStatus (Id),
	constraint fk_regressionfiles_regression_asp_tpid foreign key (Regression_ASP_TPID) references Regression_ASP_TP (Id)
)






insert into LoginUser values(1,'maninder','passwd');

insert into RegressionStatus  values(1,1,'In Progress');
insert into RegressionStatus  values(2,1,'Completed');

insert into RegressionStatus values(3,2,'Needs Download');
insert into RegressionStatus values (4,2,'Downloading');
insert into RegressionStatus values(5,2,'Downloaded');
insert into RegressionStatus values(6,2,'Need Dropping');
insert into RegressionStatus values(7,2,'Dropped');
insert into RegressionStatus values(8,2,'Translated');

insert into RegressionStatus values(9,3,'Not Calculated');
insert into RegressionStatus values(10,3,'Calculated');

insert into Regression values (1,1,'OECP8104010V40_PGE_GIS',1);
insert into Regression values (2,1,'OECP8104010V40_PGE_GIS',2);

insert into Regression_ASP_TP values(1,1,19990,'COMCA006912877',10);
insert into Regression_ASP_TP values(2,1,20020,'CO3CA006912877',10);
insert into Regression_ASP_TP values(3,2,38356,'CONMIMICHCONG1ENRO',10);

insert into RegressionFiles values(4,2,'ECPTXPIPE__820_EAM__20130318123054.txt.pgp.DT42015164.decr.adc','EAMTX007929441_106643215_109216476_','D:\','D:\',8);
insert into RegressionFiles values(5,2,'ECPTXPIPE__820_EAM__20130313123422.txt.pgp.DT41937084.decr.adc','EAMTX007929441_106409405_108842174_','D:\','D:\',8);
insert into RegressionFiles values(6,2,'ECPTXPIPE__820_EAM__20130301113853.txt.pgp.DT41733237.decr.adc','EAMTX007929441_105804011_107848439_','D:\','D:\',8);


insert into RegressionFiles values(1,3,'ECPMIGASABP_201610031139_839329158_122843381_814.out.DT69474977.mrst','CONMIMICHCONG1ENRO_186536862_22737837_','D:\','D:\',8);
insert into RegressionFiles values(2,3,'ECPMIGASABP_201609270912_839329158_122843381_814.out.DT69379737.mrst','CONMIMICHCONG1ENRO_186263748_22299478_','D:\','D:\',8);
insert into RegressionFiles values(3,3,'ECPMIGASABP_201609220508_839329158_122843381_814.out.DT69300783.mrst','CONMIMICHCONG1ENRO_186028667_21925250_','D:\','D:\',8);

insert into RegressionFiles values(7,2,'ECPNOTXPIPE__20130418111526-ESONORTH2-ESOSTHNTX-1270439.FF.v1.6.1270439.DT42571779.decr.adc','CO3CA006912877_108296615_111883534_','D:\','D:\',8);
insert into RegressionFiles values(8,2,'ECPNOTXPIPE__20130418111526-ESONORTH2-ESOSTHNTX-1270439.FF.v1.6.1270439.DT42571779.decr.adc','CO3CA006912877_108296615_111883534_','D:\','D:\',8);
insert into RegressionFiles values(9,2,'ECPNOTXPIPE__20130418093027-ESONORTH2-ESOSTHNTX-1270205.FF.v1.6.1270205.DT42569183.decr.adc','CO3CA006912877_108288634_111871817_','D:\','D:\',8);




