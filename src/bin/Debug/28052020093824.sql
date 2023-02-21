

--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_selection



--     *****************************************************************************************************************************************************************
 
 
--                             Code Type:           Store Procedure For selection
--                             Auther:              Muhammad Usman Raza Attari
--                             Developed By :       786 Software House 
 
 
--    *****************************************************************************************************************************************************************
 
     CREATE procedure  [dbo].[sp_TBL_SALES_AND_RETURN_MAIN_selection]
                                               
                                               
     @STATUS nvarchar(100),
     @CMP_ID nvarchar(100),
     @BRC_ID nvarchar(100),
	 @SALES_AND_RETURN_MAIN_cashOrCredit nvarchar(60),
     @SALES_AND_RETURN_MAIN_SALESOrReturn nvarchar(60),
     @SALES_AND_RETURN_MAIN_ID  nvarchar(100),
     @Is_Deleted bit
     
   
   
     AS BEGIN 
   
      if @STATUS = 'Sales Report'
        BEGIN
       
             SELECT TBL_SALES_AND_RETURN_MAIN.*,TBL_SALES_AND_RETURN_DETAILS.*,TBL_CUSTOMERS.CUSTOMER_name, TBL_PRODUCTS.PRODUCT_name from
               
                
                 TBL_SALES_AND_RETURN_MAIN  join TBL_SALES_AND_RETURN_DETAILS  on TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_ID = TBL_SALES_AND_RETURN_DETAILS.SALES_AND_RETURN_DETAILS_mainID
				                                     and TBL_SALES_AND_RETURN_MAIN.Is_Deleted = TBL_SALES_AND_RETURN_DETAILS.Is_Deleted
													 and TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_ID =  @SALES_AND_RETURN_MAIN_ID
	                                        
			                                join TBL_CUSTOMERS on TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_supplierID = TBL_CUSTOMERS.CUSTOMER_ID
				                                     and TBL_SALES_AND_RETURN_MAIN.Is_Deleted = TBL_CUSTOMERS.Is_Deleted

                                            join TBL_PRODUCTS on TBL_SALES_AND_RETURN_DETAILS.SALES_AND_RETURN_DETAILS_itemID = TBL_PRODUCTS.PRODUCT_ID
				                                     and TBL_SALES_AND_RETURN_DETAILS.Is_Deleted = TBL_PRODUCTS.Is_Deleted
			where  

	                  TBL_SALES_AND_RETURN_MAIN.Is_Deleted         = isnull(@Is_Deleted , TBL_SALES_AND_RETURN_MAIN.Is_Deleted ) 
					
                     order by SALES_AND_RETURN_DETAILS_orderingID       

        END  

   else if @STATUS = 'A'
        BEGIN
       
--	   select SALES_AND_RETURN_MAIN_ID from TBL_SALES_AND_RETURN_MAIN
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
--)A where cast(A.c as int) != cast(A.d as int) and A.VCH_DETAILS_mainID like 'SI%'
--) B on B.VCH_DETAILS_mainID = TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_VCHID
--		and B.c > 0





             SELECT 
               cast(TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_ID as int) as 'IDs'
               
               , TBL_CUSTOMERS.CUSTOMER_name as 'Customer '
               , Cast(SALES_AND_RETURN_MAIN_date as nvarchar(max)) as 'Date '
               , Cast(SALES_AND_RETURN_MAIN_narration as nvarchar(max)) as 'Narration '
			    ,Cast(SALES_AND_RETURN_MAIN_Maker as nvarchar(max)) as 'Maker '
               , Cast(SALES_AND_RETURN_MAIN_Model as nvarchar(max)) as 'Model '
               , Cast(SALES_AND_RETURN_MAIN_Mileage as nvarchar(max)) as 'Mileage '
               , Cast(SALES_AND_RETURN_MAIN_VehicleNumber as nvarchar(max)) as 'Vehicle Number '
                
                FROM TBL_SALES_AND_RETURN_MAIN  join TBL_CUSTOMERS on TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_supplierID = TBL_CUSTOMERS.CUSTOMER_ID
				                                     and TBL_SALES_AND_RETURN_MAIN.Is_Deleted = TBL_CUSTOMERS.Is_Deleted
	        where  
	                  TBL_SALES_AND_RETURN_MAIN.Is_Deleted         = isnull(@Is_Deleted , TBL_SALES_AND_RETURN_MAIN.Is_Deleted ) 
					 and SALES_AND_RETURN_MAIN_cashOrCredit  = @SALES_AND_RETURN_MAIN_cashOrCredit
					 and SALES_AND_RETURN_MAIN_SALESOrReturn = @SALES_AND_RETURN_MAIN_SALESOrReturn
                     order by  cast(TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_ID as int)      

        END  

        ELSE  
          if @STATUS = 'V'
                BEGIN
               
                 SELECT TBL_SALES_AND_RETURN_MAIN.*, 
				 
				 TBL_STOCKS.STOCK_maxID from TBL_SALES_AND_RETURN_MAIN 
				 join TBL_STOCKS on  TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_ID = TBL_STOCKS.STOCK_transactionID
					  and TBL_STOCKS.STOCK_transactionParentType = @SALES_AND_RETURN_MAIN_SALESOrReturn
					  and TBL_SALES_AND_RETURN_MAIN.Is_Deleted = TBL_STOCKS.Is_Deleted
					  
	                where  
                             (SALES_AND_RETURN_MAIN_ID = @SALES_AND_RETURN_MAIN_ID
                             or SALES_AND_RETURN_MAIN_VCHID = @SALES_AND_RETURN_MAIN_ID)
	                     --and Isnull(CMP_ID,'')      = isnull(@CMP_ID , '') 
                      --       and Isnull(BRC_ID,'')      = isnull(@BRC_ID , '') 
                             and TBL_SALES_AND_RETURN_MAIN.Is_Deleted             = isnull(@Is_Deleted , TBL_SALES_AND_RETURN_MAIN.Is_Deleted )
							  and SALES_AND_RETURN_MAIN_cashOrCredit  = @SALES_AND_RETURN_MAIN_cashOrCredit
					          and SALES_AND_RETURN_MAIN_SALESOrReturn = @SALES_AND_RETURN_MAIN_SALESOrReturn  
    
    
    declare @MainID as nvarchar(200) 
set @MainID = ( SELECT  top(1)TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_ID from TBL_SALES_AND_RETURN_MAIN
					  
	                where  
                             (SALES_AND_RETURN_MAIN_ID = @SALES_AND_RETURN_MAIN_ID
                             or SALES_AND_RETURN_MAIN_VCHID = @SALES_AND_RETURN_MAIN_ID)
                             and TBL_SALES_AND_RETURN_MAIN.Is_Deleted             = isnull(@Is_Deleted , TBL_SALES_AND_RETURN_MAIN.Is_Deleted )
							  and SALES_AND_RETURN_MAIN_cashOrCredit  = @SALES_AND_RETURN_MAIN_cashOrCredit
					          and SALES_AND_RETURN_MAIN_SALESOrReturn = @SALES_AND_RETURN_MAIN_SALESOrReturn)




    
    
                 SELECT 
				 
				  
				 
				        substring(TBL_PRODUCTS.PRODUCT_COA,7,8)  as A_SALES_AND_RETURN_DETAILS_itemCOA  , 
						
						 TBL_PRODUCTS.PRODUCT_name A_SALES_AND_RETURN_DETAILS_itemName , 
						 SALES_AND_RETURN_DETAILS_itemID as A_SALES_AND_RETURN_DETAILS_itemCode ,

						    TBL_UNITS.UNIT_name as SALES_AND_RETURN_DETAILS_itemUnit,
						 SALES_AND_RETURN_DETAILS_itemUnit as A_SALES_AND_RETURN_DETAILS_itemUnitCode, 
						 SALES_AND_RETURN_DETAILS_costPrice,
						 SALES_AND_RETURN_DETAILS_SALESPrice,
						 SALES_AND_RETURN_DETAILS_QTY,
						 SALES_AND_RETURN_DETAILS_total
				 
				 FROM 
				 TBL_SALES_AND_RETURN_DETAILS join TBL_PRODUCTS
				 on TBL_SALES_AND_RETURN_DETAILS.SALES_AND_RETURN_DETAILS_itemID = TBL_PRODUCTS.PRODUCT_ID
				 join  TBL_UNITS   
				 on TBL_SALES_AND_RETURN_DETAILS.SALES_AND_RETURN_DETAILS_itemUnit  =   TBL_UNITS.UNIT_ID
				  
	                where  
                             SALES_AND_RETURN_DETAILS_mainID = @MainID--@SALES_AND_RETURN_MAIN_ID
	                     
                             and TBL_SALES_AND_RETURN_DETAILS.Is_Deleted             = isnull(@Is_Deleted , TBL_SALES_AND_RETURN_DETAILS.Is_Deleted )  
                             order by SALES_AND_RETURN_DETAILS_orderingID     

                END 
                  
                ELSE  
                  if @STATUS = 'L'
                        BEGIN
                       
                         SELECT SALES_AND_RETURN_MAIN_ID  FROM TBL_SALES_AND_RETURN_MAIN 
	                        where  
                                     Isnull(CMP_ID,'')      = isnull(@CMP_ID , '') 
                                     and Isnull(BRC_ID,'')  = isnull(@BRC_ID , '') 
                                     and Is_Deleted         = isnull(@Is_Deleted , Is_Deleted )   
									  and SALES_AND_RETURN_MAIN_cashOrCredit  = @SALES_AND_RETURN_MAIN_cashOrCredit
					 and SALES_AND_RETURN_MAIN_SALESOrReturn = @SALES_AND_RETURN_MAIN_SALESOrReturn     
					                 order by  cast(TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_ID as int)      

                        END    
		ELSE  
                  if @STATUS = 'G'
                        BEGIN
                       
                         SELECT 
						 
						 '' A_SALES_AND_RETURN_DETAILS_itemCOA  , 
						 '' A_SALES_AND_RETURN_DETAILS_itemName , 
						 '' A_SALES_AND_RETURN_DETAILS_itemCode ,

						 SALES_AND_RETURN_DETAILS_itemUnit,
						 '' A_SALES_AND_RETURN_DETAILS_itemUnitCode, 

						 SALES_AND_RETURN_DETAILS_costPrice,
						 SALES_AND_RETURN_DETAILS_SALESPrice,
						 
						 SALES_AND_RETURN_DETAILS_QTY,
						 SALES_AND_RETURN_DETAILS_total
						  
						 
						 FROM TBL_SALES_AND_RETURN_DETAILS 
	                        where  
                                            SALES_AND_RETURN_DETAILS_ID = '-1'

                        END   
 
     END

















