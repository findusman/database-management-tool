

--                                   Table : TBL_COA


create table [TBL_COA] (  [CMP_ID] nvarchar(50)  NULL ,   [BRC_ID] nvarchar(50)  NULL ,   [COA_ID] int IDENTITY(1,1) NOT NULL ,   [COA_PARENTID] nvarchar(50)  NULL ,   [COA_UID] nvarchar(50)  NULL ,   [COA_definationPlanID] int  NULL ,   [COA_levelID] int  NULL ,   [COA_Name] nvarchar(200)  NULL ,   [COA_type] int  NULL ,   [COA_IsInventory] bit  NULL ,   [COA_IsTransaction] bit  NULL ,   [COA_nature] nvarchar(50)  NULL ,   [COA_isAddedDirectly] bit  NULL ,   [COA_isDeleted] bit  NULL ,   [User_ID] nvarchar(50)  NULL , )ALTER TABLE TBL_COA ADD CONSTRAINT PK_TBL_COA PRIMARY KEY  ([COA_ID])
