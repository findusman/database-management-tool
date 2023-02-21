

--                                Procedure : sp_AuditTrial_DM




--                                Procedure : sp_AuditTrial_DM




CREATE procedure  sp_AuditTrial_DM

@CMP_ID as nvarchar(max) ,
@BRC_ID as nvarchar(max),
@fromdate as datetime,
@toDate as datetime 

as

--declare @CMP_ID as nvarchar(max) = '1'
--declare @BRC_ID as nvarchar(max) = '1'
--declare @fromdate as datetime = '01-01-2013'
--declare @toDate as datetime = '01-01-2017' 


select * from 

(


select 

TBL_VCH_MAIN.VCH_ID,
'TransactioID' = '',
TBL_VCH_DETAILS.VCH_DETAILS_COA,
TBL_COA.COA_Name,
TBL_VCH_DETAILS.VCH_DETAILS_date,

'NarationType' =  (select PREFIX_name from TBL_PREFIX where TBL_PREFIX.PREFIX_key = TBL_VCH_MAIN.VCH_prefix),
TBL_VCH_MAIN.VCH_narration,

TBL_VCH_DETAILS.VCH_DETAILS_debit,
TBL_VCH_DETAILS.VCH_DETAILS_credit




 from TBL_VCH_DETAILS join TBL_VCH_MAIN 
  on TBL_VCH_MAIN.VCH_ID = TBL_VCH_DETAILS.VCH_DETAILS_mainID
 
  join TBL_COA
  on TBL_COA.COA_UID = TBL_VCH_DETAILS.VCH_DETAILS_COA 
 
  --select * from TBL_VCH_DETAILS



  union all
  
  
  select 

V_TBL_VCH_DETAILS_stock.VCH_ID,
V_TBL_VCH_DETAILS_stock.TransactioID,
V_TBL_VCH_DETAILS_stock.VCH_DETAILS_COA,
V_TBL_VCH_DETAILS_stock.PRODUCT_name,
V_TBL_VCH_DETAILS_stock.VCH_DETAILS_date,

V_TBL_VCH_DETAILS_stock.TransactionType,
V_TBL_VCH_DETAILS_stock.VCH_narration,

V_TBL_VCH_DETAILS_stock.VCH_DETAILS_debit,
V_TBL_VCH_DETAILS_stock.VCH_DETAILS_credit




 from V_TBL_VCH_DETAILS_stock 

 
 )A where 

 A.VCH_DETAILS_date >= @fromdate
 and A.VCH_DETAILS_date <= @todate

  --select * from TBL_VCH_DETAILS

  --select * from TBL_STOCKS





