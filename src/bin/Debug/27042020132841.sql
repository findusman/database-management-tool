

--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_PURCHASE_AND_RETURN_MAIN_selection



--     *****************************************************************************************************************************************************************
 
 
--                             Code Type:           Store Procedure For selection
--                             Auther:              Muhammad Usman Raza Attari
--                             Developed By :       786 Software House 
 
 
--    *****************************************************************************************************************************************************************
 
     CREATE procedure  sp_TBL_PURCHASE_AND_RETURN_MAIN_selection
                                               
                                               
     @STATUS nvarchar(100),
     @CMP_ID nvarchar(100),
     @BRC_ID nvarchar(100),
	 @PURCHASE_AND_RETURN_MAIN_cashOrCredit nvarchar(60),
     @PURCHASE_AND_RETURN_MAIN_purchaseOrReturn nvarchar(60),
     @PURCHASE_AND_RETURN_MAIN_ID  nvarchar(100),
     @Is_Deleted bit
     
   
   
     AS BEGIN 
   
   if @STATUS = 'A'
        BEGIN

--		select TBL_PURCHASE_AND_RETURN_MAIN.PURCHASE_AND_RETURN_MAIN_ID, B.* from TBL_PURCHASE_AND_RETURN_MAIN

--join

--(
--select * from
--(

--select 
--sum(TBL_VCH_DETAILS.VCH_DETAILS_debit) d, 
--sum(TBL_VCH_DETAILS.VCH_DETAILS_credit) c,  
--TBL_VCH_DETAILS.VCH_DETAILS_mainID

--from TBL_VCH_DETAILS 

--group by TBL_VCH_DETAILS.VCH_DETAILS_mainID
--)A where cast(A.c as int) != cast(A.d as int) and A.VCH_DETAILS_mainID like 'PI%'
--) B on B.VCH_DETAILS_mainID = TBL_PURCHASE_AND_RETURN_MAIN.PURCHASE_AND_RETURN_MAIN_VCHID
--		and B.d > 0

       
             SELECT 
               cast(TBL_PURCHASE_AND_RETURN_MAIN.PURCHASE_AND_RETURN_MAIN_ID as int) as 'IDs'
               
               , SUPPLIER_name as 'Supplier '
               , Cast(PURCHASE_AND_RETURN_MAIN_date as nvarchar(max)) as 'Date '
               , Cast(PURCHASE_AND_RETURN_MAIN_narration as nvarchar(max)) as 'Narration '
                
                FROM TBL_PURCHASE_AND_RETURN_MAIN  join TBL_SUPPLIERS on TBL_PURCHASE_AND_RETURN_MAIN.PURCHASE_AND_RETURN_MAIN_supplierID = TBL_SUPPLIERS.SUPPLIER_ID
				                                     and TBL_PURCHASE_AND_RETURN_MAIN.Is_Deleted = TBL_SUPPLIERS.Is_Deleted
	        where  
	                   TBL_PURCHASE_AND_RETURN_MAIN.Is_Deleted         = isnull(@Is_Deleted , TBL_PURCHASE_AND_RETURN_MAIN.Is_Deleted ) 
					 and PURCHASE_AND_RETURN_MAIN_cashOrCredit  = @PURCHASE_AND_RETURN_MAIN_cashOrCredit
					 and PURCHASE_AND_RETURN_MAIN_purchaseOrReturn = @PURCHASE_AND_RETURN_MAIN_purchaseOrReturn
					 and cast(PURCHASE_AND_RETURN_MAIN_ID as int)  > 1
                     order by cast(TBL_PURCHASE_AND_RETURN_MAIN.PURCHASE_AND_RETURN_MAIN_ID as int)       

        END  

        ELSE  
          if @STATUS = 'V'
                BEGIN
               
                 SELECT TBL_PURCHASE_AND_RETURN_MAIN.*, 
				 
				 TBL_STOCKS.STOCK_maxID from TBL_PURCHASE_AND_RETURN_MAIN 
				 join TBL_STOCKS on  TBL_PURCHASE_AND_RETURN_MAIN.PURCHASE_AND_RETURN_MAIN_ID = TBL_STOCKS.STOCK_transactionID
					  and TBL_STOCKS.STOCK_transactionParentType = @PURCHASE_AND_RETURN_MAIN_purchaseOrReturn
					  and TBL_PURCHASE_AND_RETURN_MAIN.Is_Deleted = TBL_STOCKS.Is_Deleted
					  
	                where  
                             (PURCHASE_AND_RETURN_MAIN_ID = @PURCHASE_AND_RETURN_MAIN_ID
                             or PURCHASE_AND_RETURN_MAIN_VCHID = @PURCHASE_AND_RETURN_MAIN_ID)
	                     --and Isnull(CMP_ID,'')      = isnull(@CMP_ID , '') 
                      --       and Isnull(BRC_ID,'')      = isnull(@BRC_ID , '') 
                             and TBL_PURCHASE_AND_RETURN_MAIN.Is_Deleted             = isnull(@Is_Deleted , TBL_PURCHASE_AND_RETURN_MAIN.Is_Deleted )
							  and PURCHASE_AND_RETURN_MAIN_cashOrCredit  = @PURCHASE_AND_RETURN_MAIN_cashOrCredit
					          and PURCHASE_AND_RETURN_MAIN_purchaseOrReturn = @PURCHASE_AND_RETURN_MAIN_purchaseOrReturn  
    
     declare @MainID as nvarchar(200) 
set @MainID = ( SELECT  top(1)TBL_PURCHASE_AND_RETURN_MAIN.PURCHASE_AND_RETURN_MAIN_ID from TBL_PURCHASE_AND_RETURN_MAIN
					  
	                where  
                             (PURCHASE_AND_RETURN_MAIN_ID = @PURCHASE_AND_RETURN_MAIN_ID
                             or PURCHASE_AND_RETURN_MAIN_VCHID = @PURCHASE_AND_RETURN_MAIN_ID)
                             and TBL_PURCHASE_AND_RETURN_MAIN.Is_Deleted             = isnull(@Is_Deleted , TBL_PURCHASE_AND_RETURN_MAIN.Is_Deleted )
							  and PURCHASE_AND_RETURN_MAIN_cashOrCredit  = @PURCHASE_AND_RETURN_MAIN_cashOrCredit
					          and PURCHASE_AND_RETURN_MAIN_purchaseOrReturn = @PURCHASE_AND_RETURN_MAIN_purchaseOrReturn)


    
    
                 SELECT 
				 
				  
				 
				        substring(TBL_PRODUCTS.PRODUCT_COA,7,8)  as A_PURCHASE_AND_RETURN_DETAILS_itemCOA  , 
						
						 TBL_PRODUCTS.PRODUCT_name A_PURCHASE_AND_RETURN_DETAILS_itemName , 
						 PURCHASE_AND_RETURN_DETAILS_itemID as A_PURCHASE_AND_RETURN_DETAILS_itemCode ,

						    TBL_UNITS.UNIT_name as PURCHASE_AND_RETURN_DETAILS_itemUnit,
						 PURCHASE_AND_RETURN_DETAILS_itemUnit as A_PURCHASE_AND_RETURN_DETAILS_itemUnitCode, 

						 PURCHASE_AND_RETURN_DETAILS_purchasePrice,
						 PURCHASE_AND_RETURN_DETAILS_QTY,
						 PURCHASE_AND_RETURN_DETAILS_total
				 
				 FROM 
				 PURCHASE_AND_RETURN_DETAILS join TBL_PRODUCTS
				 on PURCHASE_AND_RETURN_DETAILS.PURCHASE_AND_RETURN_DETAILS_itemID = TBL_PRODUCTS.PRODUCT_ID
				 join  TBL_UNITS   
				 on PURCHASE_AND_RETURN_DETAILS.PURCHASE_AND_RETURN_DETAILS_itemUnit  =   TBL_UNITS.UNIT_ID
				  
	                where  
                             PURCHASE_AND_RETURN_DETAILS_mainID = @MainID-- @PURCHASE_AND_RETURN_MAIN_ID
	                     
                             and PURCHASE_AND_RETURN_DETAILS.Is_Deleted             = isnull(@Is_Deleted , PURCHASE_AND_RETURN_DETAILS.Is_Deleted )  
                             order by PURCHASE_AND_RETURN_DETAILS_orderingID     

                END 
                  
                ELSE  
                  if @STATUS = 'L'
                        BEGIN
                       
                         SELECT PURCHASE_AND_RETURN_MAIN_ID , PURCHASE_AND_RETURN_MAIN_ID FROM TBL_PURCHASE_AND_RETURN_MAIN 
	                        where  
                                     Isnull(CMP_ID,'')      = isnull(@CMP_ID , '') 
                                     and Isnull(BRC_ID,'')  = isnull(@BRC_ID , '') 
                                     and Is_Deleted         = isnull(@Is_Deleted , Is_Deleted )   
									  and PURCHASE_AND_RETURN_MAIN_cashOrCredit  = @PURCHASE_AND_RETURN_MAIN_cashOrCredit
					 and PURCHASE_AND_RETURN_MAIN_purchaseOrReturn = @PURCHASE_AND_RETURN_MAIN_purchaseOrReturn     

                        END    
		ELSE  
                  if @STATUS = 'G'
                        BEGIN
                       
                         SELECT 
						 
						 '' A_PURCHASE_AND_RETURN_DETAILS_itemCOA  , 
						 '' A_PURCHASE_AND_RETURN_DETAILS_itemName , 
						 '' A_PURCHASE_AND_RETURN_DETAILS_itemCode ,

						 PURCHASE_AND_RETURN_DETAILS_itemUnit,
						 '' A_PURCHASE_AND_RETURN_DETAILS_itemUnitCode, 

						 PURCHASE_AND_RETURN_DETAILS_purchasePrice,
						 PURCHASE_AND_RETURN_DETAILS_QTY,
						 PURCHASE_AND_RETURN_DETAILS_total
						  
						 
						 FROM PURCHASE_AND_RETURN_DETAILS 
	                        where  
                                            PURCHASE_AND_RETURN_DETAILS_ID = '-1'

                        END   
 
     END













