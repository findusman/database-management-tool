

--                                Procedure : sp_balanceSheet_DM_Lubricants_selection_old




--                                Procedure : sp_balanceSheet_DM_Lubricants_selection




--                                Procedure : sp_balanceSheet_DM_Lubricants_selection




--                                Procedure : sp_balanceSheet_DM_Lubricants_selection




--                                Procedure : sp_balanceSheet_DM_Lubricants_selection




create procedure  sp_balanceSheet_DM_Lubricants_selection_old

@CMP_ID as nvarchar(max) ,
@BRC_ID as nvarchar(max),
@fromdate as datetime,
@toDate as datetime 

as

--declare @CMP_ID as nvarchar(max) = '1'
--declare @BRC_ID as nvarchar(max) = '1'
--declare @fromdate as datetime = '01-01-2009'
--declare @toDate as datetime = '01-01-2019'




declare @totalharedcapital float

declare @total_calculated_NonProportional_Profit_Or_Loss as float
declare @total_Opening_NonProportional_Profit_Or_Loss as float
declare @totalCreditRetainedEarnings as float
declare @totalbalanceRetainedEarnings as float
--declare @totalRetainedEarnings as float


declare @total_NonProportional_Profit_Or_Loss as float


declare @totalLiabilities as float
declare @totalFixedAssets as float
declare @totalCurrentAssets as float
declare @totalAssets as float
declare @totalNetLiabilites as float



declare @closingGrossSales as float
declare @closingLessSalesReturn as float

declare @closingPurchases as float
declare @closingLessPurchasesReturn as float

declare @closingStocks as float

declare @space as nvarchar(max) = '          '
declare @timeStamp as nvarchar(max) --= cast( CURRENT_TIMESTAMP as nvarchar(max))




declare @AccSales as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Credit_Sales' and DEFAULT_ACCT_isDeleted = 0)
declare @AccSales_Returns as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Credit_Sales_Returns' and DEFAULT_ACCT_isDeleted = 0)
declare @AccPurchase as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Credit_Purchase' and DEFAULT_ACCT_isDeleted = 0)
declare @AccPurchase_Returns as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Credit_Purchase_Return' and DEFAULT_ACCT_isDeleted = 0)


declare @Keytotalharedcapital as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'SharedCapital' and DEFAULT_ACCT_isDeleted = 0)
declare @KeytotalRetainedEarnings as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Retained_Earnings' and DEFAULT_ACCT_isDeleted = 0)
declare @KeytotalLiabilities as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Liabilities' and DEFAULT_ACCT_isDeleted = 0)
declare @KeytotalFixedAssets as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Fixed_Assets' and DEFAULT_ACCT_isDeleted = 0)
declare @KeytotalCurrentAssets as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Current_Assets' and DEFAULT_ACCT_isDeleted = 0)
declare @KeytotalOpeningNonProportionalAccount as nvarchar(max) =  (select top(1)TBL_DEFAULT_ACCT.DEFAULT_ACCT_CODE from TBL_DEFAULT_ACCT where DEFAULT_ACCT_KEY = 'Non_Proportional_Account' and DEFAULT_ACCT_isDeleted = 0)


set @timeStamp = ( select  isnull( (max(cast( [KEY] as int ))),0) + 1 from  TBL_tmpDefaultValues)

exec sp_profitOrLoss_DM_Lubricants_selection

 @CMP_ID ,
 @BRC_ID , 
 @fromdate ,
 @toDate ,
 null 
 ,@timeStamp,
 0,1


 set @total_calculated_NonProportional_Profit_Or_Loss = (select top(1)TBL_tmpDefaultValues.Value from TBL_tmpDefaultValues where [key] = @timeStamp)



set @total_Opening_NonProportional_Profit_Or_Loss  =  isnull((select  sum(TBL_VCH_DETAILS.VCH_DETAILS_credit) from TBL_VCH_DETAILS 
																								where 
																										TBL_VCH_DETAILS.VCH_DETAILS_COA = @KeytotalOpeningNonProportionalAccount 
																										--and isnull(TBL_VCH_DETAILS.VCH_DETAILS_referenceNo,'') = isnull(@VCH_DETAILS_referenceNo,isnull(TBL_VCH_DETAILS.VCH_DETAILS_referenceNo,''))
															
																										--and TBL_VCH_DETAILS.VCH_DETAILS_date <= @toDate
																										and CMP_ID = @CMP_ID
																										and BRC_ID = @BRC_ID
																										and Is_Deleted= 0
																			 
																										),0)
set @totalCreditRetainedEarnings  =  isnull((select  sum(TBL_VCH_DETAILS.VCH_DETAILS_credit) from TBL_VCH_DETAILS 
																								where 
																										substring (TBL_VCH_DETAILS.VCH_DETAILS_COA,0,9) = substring (@KeytotalRetainedEarnings,0,9) 
																										--and isnull(TBL_VCH_DETAILS.VCH_DETAILS_referenceNo,'') = isnull(@VCH_DETAILS_referenceNo,isnull(TBL_VCH_DETAILS.VCH_DETAILS_referenceNo,''))
															
																										and TBL_VCH_DETAILS.VCH_DETAILS_date <= @toDate
																										and CMP_ID = @CMP_ID
																										and BRC_ID = @BRC_ID
																										and Is_Deleted= 0
																			 
																										),0)


set @totalbalanceRetainedEarnings = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (@KeytotalRetainedEarnings,0,9), @fromdate,@toDate,null, 0,0))



set @total_NonProportional_Profit_Or_Loss = @total_Opening_NonProportional_Profit_Or_Loss +
											@total_calculated_NonProportional_Profit_Or_Loss -
											@totalCreditRetainedEarnings

set @totalharedcapital = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (@Keytotalharedcapital,0,9), @fromdate,@toDate,null, 0,0))
set @totalLiabilities = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (@KeytotalLiabilities,0,3), @fromdate,@toDate,null, 0,0))
set @totalFixedAssets = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (@KeytotalFixedAssets,0,6), @fromdate,@toDate,null, 0,0))
set @totalCurrentAssets = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (@KeytotalCurrentAssets,0,6), @fromdate,@toDate,null, 0,0))
--set @totalCurrentRetainedEarnings = (select dbo.getCOASumInDates(@CMP_ID, @BRC_ID , substring (@KeytotalCurrentAssets,0,6), @fromdate,@toDate,null, 0))



--set @totalRetainedEarnings = @totalOpeningRetainedEarnings --+ @totalCurrentRetainedEarnings

-- set @totalNonProportionalAccount = @totalCalculatedNonProportionalAccount + @totalOpeningNonProportionalAccount - @totalRetainedEarnings


set @closingGrossSales = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , @AccSales, @fromdate,@toDate,null,1,1))
set @closingLessSalesReturn = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , @AccSales_Returns, @fromdate,@toDate,null,1,1))

set @closingPurchases = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , @AccPurchase, @fromdate, @toDate, null, 1,0))
set @closingLessPurchasesReturn = (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , @AccPurchase_Returns, @fromdate, @toDate,  null,  1,0))


set @closingStocks = @closingPurchases + @closingLessSalesReturn - @closingGrossSales - @closingLessPurchasesReturn

set @totalAssets = @totalFixedAssets + @totalCurrentAssets + @closingStocks
set @totalNetLiabilites =  @total_NonProportional_Profit_Or_Loss + @totalbalanceRetainedEarnings  + @totalLiabilities

--select --@closingPurchases 'closingPurchases', @closingLessPurchasesReturn'closingLessPurchasesReturn', @closingGrossSales'closingGrossSales', @closingLessSalesReturn'closingLessSalesReturn', @closingStocks '@closingStocks', 

--@totalAssets  '@totalAssets', @totalNetLiabilites '@totalNetLiabilites', @totalharedcapital'@totalharedcapital' , @totalRetainedEarnings'@totalRetainedEarnings',
--@totalLiabilities '@totalLiabilities', @totalFixedAssets'@totalFixedAssets' ,@totalCurrentAssets '@totalCurrentAssets'





; with tbl_liability as (

select ROW_NUMBER() over (order by A.OrderID_Liability ) as ID_Libility, * from (

select 1 OrderID_Liability, 'SingleValue' ColorStatus1_Libilities, 'SharedCapital' ColorStatus2_Libilities, 'Shared Capital' Name_Liability, @totalharedcapital Amout_Liability
union all
select 2 OrderID,'SingleValue' ColorStatus1, 'NonProportionalProfitOrLoss' ColorStatus2, 'Profit Or Loss' Name, @total_NonProportional_Profit_Or_Loss Amout
union all
(select 3 OrderID,'Transaction' ColorStatus1, 'RetainedEarning' ColorStatus2, @space +TBL_COA.COA_Name Name, 
(select dbo.getCOASumInDates(@CMP_ID, @BRC_ID , TBL_COA.COA_UID, @fromdate,@toDate,null, 0)) Amout 
	   
				from TBL_COA 
								
				where substring (TBL_COA.COA_UID,0,9) = substring (@KeytotalRetainedEarnings,0,9)
						  and dbo.getCOASumInDates(@CMP_ID, @BRC_ID , TBL_COA.COA_UID, @fromdate,@toDate,null, 0) >0

					  and isnull(dbo.TBL_COA.CMP_ID, '') = isnull(@CMP_ID,'')
				  AND isnull(dbo.TBL_COA.BRC_ID, '') = isnull(@BRC_ID,'')
					  and TBL_COA.COA_isDeleted = 0
)
union all
select 4 OrderID,'Space' ColorStatus1, '' ColorStatus2, '' Name, null Amout

union all
select 5 OrderID,'Heading'  Amout, 'Liability' ColorStatus2, 'Liabilities' Name, null Amout
union all
(select 7 OrderID,'Transaction' ColorStatus1, 'Liabilities' ColorStatus2, @space +TBL_COA.COA_Name Name, 
(select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (TBL_COA.COA_UID,0,9), @fromdate,@toDate,null, 0,0)) Amout 
	   
				from TBL_COA join TBL_ACC_PLAN_DEF on TBL_ACC_PLAN_DEF.TBL_ACC_PLAN_DEF_ID = TBL_COA.COA_definationPlanID
								
				where substring (TBL_COA.COA_UID,0,3) = substring (@KeytotalLiabilities,0,3)
						  and dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (TBL_COA.COA_UID,0,9), @fromdate,@toDate,null, 0,0) >0
and TBL_ACC_PLAN_DEF.TBL_ACC_PLAN_DEF_levelNo =3
					  and isnull(dbo.TBL_COA.CMP_ID, '') = isnull(@CMP_ID,'')
				  AND isnull(dbo.TBL_COA.BRC_ID, '') = isnull(@BRC_ID,'')
					  and TBL_COA.COA_isDeleted = 0
)

union all
select 9 OrderID,'Total'  Amout, 'TotalLiability' ColorStatus2, 'Total Liabilities' Name, @totalLiabilities Amout
union all
select 10 OrderID,'Total'  Amout, 'TotalNetLiability' ColorStatus2, 'Total Net Liabilities' Name, @totalNetLiabilites Amout

)A)

, tbl_Assets as
(

select ROW_NUMBER() over (order by A.OrderID_Assets ) as ID_Assets, * from (

---- Closing Stock
select 1 OrderID_Assets,'Heading'  ColorStatus1_Assets, 'ClosingStock' ColorStatus2_Assets, 'Closing Stock' Name_Assets, 0 Amout_Assets
union all


(select 3 OrderID,'Transaction' ColorStatus1, 'ClosingStock' ColorStatus2, 

@space +TBL_DEPARTMENTS.DEPARTMENT_name Name, 
((select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , @AccPurchase, @fromdate,@toDate,TBL_DEPARTMENTS.DEPARTMENT_ID,1,0)) 
+ (select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , @AccSales_Returns, @fromdate,@toDate,TBL_DEPARTMENTS.DEPARTMENT_ID,1,1)) 
-(select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , @AccSales, @fromdate,@toDate,TBL_DEPARTMENTS.DEPARTMENT_ID,1,1)) 
-(select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , @AccPurchase_Returns, @fromdate,@toDate,TBL_DEPARTMENTS.DEPARTMENT_ID,1,0)) 
) Amout 
	   
				from TBL_DEPARTMENTS where 

							DEPARTMENT_isParent = 1
							and isnull(dbo.TBL_DEPARTMENTS.CMP_ID, '') = isnull(@CMP_ID,'')
							AND isnull(dbo.TBL_DEPARTMENTS.BRC_ID, '') = isnull(@BRC_ID,'')
							and TBL_DEPARTMENTS.Is_Deleted = 0


)


union all

select 5 OrderID,'Total'  Amout, 'TotalClosingStock' ColorStatus2, 'Total Closing Stock' Name, @closingStocks Amout
union all

select 5 OrderID,'Space' ColorStatus1, '' ColorStatus2, '' Name, null Amout
union all
-- Fixed Assets
select 6 OrderID_Assets,'Heading'  ColorStatus1_Assets, 'FixedAssets' ColorStatus2_Assets, 'Fixed Assets' Name_Assets, null Amout_Assets
union all


(select 7 OrderID,'Transaction' ColorStatus1, 'FixedAssets' ColorStatus2, @space +TBL_COA.COA_Name Name, 
(select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (TBL_COA.COA_UID,0,9), @fromdate,@toDate,null, 0,0)) Amout 
	   
				from TBL_COA join TBL_ACC_PLAN_DEF on TBL_ACC_PLAN_DEF.TBL_ACC_PLAN_DEF_ID = TBL_COA.COA_definationPlanID
								
				where substring (TBL_COA.COA_UID,0,6) = substring (@KeytotalFixedAssets,0,6)
						  and dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (TBL_COA.COA_UID,0,9), @fromdate,@toDate,null, 0,0) >0
						  and TBL_ACC_PLAN_DEF.TBL_ACC_PLAN_DEF_levelNo =3
					  and isnull(dbo.TBL_COA.CMP_ID, '') = isnull(@CMP_ID,'')
				  AND isnull(dbo.TBL_COA.BRC_ID, '') = isnull(@BRC_ID,'')
					  and TBL_COA.COA_isDeleted = 0
)
union all

select 9 OrderID,'Total'  Amout, 'TotalFixedAssets' ColorStatus2, 'Total Fixed Assets' Name, @totalFixedAssets Amout
union all
select 9 OrderID,'Space' ColorStatus1, '' ColorStatus2, '' Name, null Amout
union all
-- Current Assets

select 10 OrderID_Assets,'Heading'  ColorStatus1_Assets, 'CurrentAssets' ColorStatus2_Assets, 'Current Assets' Name_Assets, null Amout_Assets
union all


(select 12 OrderID,'Transaction' ColorStatus1, 'CurrentAssets' ColorStatus2, @space +TBL_COA.COA_Name Name, 
(select dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (TBL_COA.COA_UID,0,9), @fromdate,@toDate,null, 0,0)) Amout 
	   
				from TBL_COA join TBL_ACC_PLAN_DEF on TBL_ACC_PLAN_DEF.TBL_ACC_PLAN_DEF_ID = TBL_COA.COA_definationPlanID
								
				where substring (TBL_COA.COA_UID,0,6) = substring (@KeytotalCurrentAssets,0,6)
						  and dbo.getCOAClosingBalance(@CMP_ID, @BRC_ID , substring (TBL_COA.COA_UID,0,9), @fromdate,@toDate,null, 0,0) >0
						  and TBL_ACC_PLAN_DEF.TBL_ACC_PLAN_DEF_levelNo =3
					  and isnull(dbo.TBL_COA.CMP_ID, '') = isnull(@CMP_ID,'')
				  AND isnull(dbo.TBL_COA.BRC_ID, '') = isnull(@BRC_ID,'')
					  and TBL_COA.COA_isDeleted = 0
)
union all

select 14 OrderID,'Total'  Amout, 'TotalCurrentAssets' ColorStatus2, 'Total Current Assets' Name, @totalCurrentAssets Amout


union all
select 15 OrderID,'Total'  Amout, 'TotalNetAssets' ColorStatus2, 'Total Net Assets' Name, @totalAssets Amout
)A

)
 select 
 
 tbl_liability.ColorStatus1_Libilities,
 tbl_liability.ColorStatus2_Libilities,
 tbl_liability.Name_Liability,
 tbl_liability.Amout_Liability,
tbl_Assets.ColorStatus1_Assets,
 tbl_Assets.ColorStatus2_Assets,
 tbl_Assets.Name_Assets,
 tbl_Assets.Amout_Assets
 
 from tbl_liability full join tbl_Assets  
 on tbl_liability.ID_Libility = tbl_Assets.ID_Assets


--select * from getClosingBalanceForMultiAccounts 
--(
--1 ,
--1 ,  
--'02', 
--'01-01-2009', 
--'01-01-2019'
--)































--;with t1 as
--(
--select '1' ID, 'Usman' Name
--union all
--select '2' ID, 'Usma2' Name
--) , 
--t2 as
--(
--select '1' ID, 'Usma3' Name
--union all
--select '2' ID, 'Usma4' Name
--) 
--select * from t1 join t2 on t1.ID = t2.ID




