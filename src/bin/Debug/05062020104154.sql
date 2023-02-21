

--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection




--                                Procedure : sp_TBL_PRODUCTS_selection



--     *****************************************************************************************************************************************************************
 
 
--                             Code Type:           Store Procedure For selection
--                             Auther:              Muhammad Usman Raza Attari
--                             Developed By :       786 Software House 
 
 
--    *****************************************************************************************************************************************************************
 
     CREATE procedure  sp_TBL_PRODUCTS_selection
                                               
                                               
     @STATUS nvarchar(100),
     @CMP_ID nvarchar(100),
     @BRC_ID nvarchar(100),
     @PRODUCT_ID  nvarchar(100),
     @Is_Deleted bit
     
   
   
     AS BEGIN 
   
   if @STATUS = 'A'
        BEGIN
       
         SELECT 
               TBL_PRODUCTS.PRODUCT_ID as 'IDs'
               
               , Cast(PRODUCT_name as nvarchar(max)) as 'Name '
               , TBL_PACKINGS_MAIN.PACKING_MAIN_name as 'Packing '
               , Cast(PRODUCT_defaultLevel as nvarchar(max)) as 'Default Level '
               , TBL_DEPARTMENTS.DEPARTMENT_name  as 'Department '
			   , PRODUCT_COA  as 'COA '
               , Cast(PRODUCT_saleRate as nvarchar(max)) as 'Sale Rate '
               , Cast(PRODUCT_purchaseRate as nvarchar(max)) as 'Purchase Rate '
               , Cast(PRODUCT_isService as nvarchar(max)) as 'Is Barcode'
			   , Cast(PRODUCT_barCode as nvarchar(max)) as 'BarCode '
               
                
                FROM TBL_PRODUCTS  join TBL_PACKINGS_MAIN on TBL_PRODUCTS.PRODUCT_packing = TBL_PACKINGS_MAIN.PACKING_MAIN_ID
				                        and TBL_PRODUCTS.Is_Deleted = TBL_PACKINGS_MAIN.Is_Deleted
				                   join TBL_DEPARTMENTS on TBL_PRODUCTS.PRODUCT_department = TBL_DEPARTMENTS.DEPARTMENT_ID
				                        and TBL_PRODUCTS.Is_Deleted = TBL_DEPARTMENTS.Is_Deleted     
	        where  
	            
                      TBL_PRODUCTS.Is_Deleted         = isnull(@Is_Deleted , TBL_PRODUCTS.Is_Deleted )   
                     order by PRODUCT_maxID     

        END  

        ELSE  
          if @STATUS = 'V'
                BEGIN
               
                 SELECT * FROM TBL_PRODUCTS 
	                where  
                             PRODUCT_ID = @PRODUCT_ID
	                     and Isnull(CMP_ID,'')      = isnull((@CMP_ID) , isNull(CMP_ID,'')) 
                             and Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                             and Is_Deleted         = isnull(@Is_Deleted , Is_Deleted )        

                END 
                  
                ELSE  
                  if @STATUS = 'L'
                        BEGIN
                       select
                         PRODUCT_ID , 
						 substring(PRODUCT_COA,7,8) PRODUCT_COA,
						 PRODUCT_name,
						 TBL_DEPARTMENTS.DEPARTMENT_name 'Departments',
						 TBL_DEPARTMENTS.DEPARTMENT_ID
						 FROM TBL_PRODUCTS join TBL_DEPARTMENTS 
						 on  TBL_DEPARTMENTS.DEPARTMENT_ID = TBL_PRODUCTS.PRODUCT_department
						 and TBL_DEPARTMENTS.Is_Deleted = TBL_PRODUCTS.Is_Deleted
	                        where  
                                     Isnull(TBL_PRODUCTS.CMP_ID,'')      = isnull((@CMP_ID) , isNull(TBL_PRODUCTS.CMP_ID,'')) 
                                     and Isnull(TBL_PRODUCTS.BRC_ID,'')  = isnull((@BRC_ID) , isNull(TBL_PRODUCTS.BRC_ID,''))
                                     and TBL_PRODUCTS.Is_Deleted         = isnull(@Is_Deleted , TBL_PRODUCTS.Is_Deleted )
                                     order by PRODUCT_maxID        

                        END    
						ELSE  
                  if @STATUS = 'Single Product Info For Transaction Against Product ID'
                        BEGIN
                       
                         SELECT 
						 *
						 FROM V_ProductWithAllPackedInfo 
	                        where  
							         PRODUCT_ID = @PRODUCT_ID 
                                     and Isnull(CMP_ID,'')      = isnull(@CMP_ID ,'') 
                                     and Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                     and Is_Deleted         = isnull(@Is_Deleted , Is_Deleted )
                                         

                        END    
 
             ELSE  
                  if @STATUS = 'Single Product Info For Transaction Against Product Barcode'
                        BEGIN
                       
                         SELECT 
						 *
						 FROM V_ProductWithAllPackedInfo 
	                        where  
							         PRODUCT_barCode = @PRODUCT_ID 
                                     and Isnull(CMP_ID,'')      = isnull(@CMP_ID ,'') 
                                     and Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                     and Is_Deleted         = isnull(@Is_Deleted , Is_Deleted )
                                         

                        END

						ELSE  
                  if @STATUS = 'Product Cost Rate History'
                        BEGIN
                       
                        	select 

							TBL_STOCKS.STOCK_ID,
									TBL_STOCKS.STOCK_transactionID 'Transaction ID', 
									TBL_STOCKS.STOCK_unit,
									TBL_UNITS.UNIT_name, 
									STOCK_purchasePrice 'Costs', 
									STOCK_QTY 'QTYs'
									from 
									TBL_STOCKS  join TBL_UNITS on TBL_STOCKS.STOCK_unit = TBL_UNITS.UNIT_ID and TBL_STOCKS.Is_Deleted = TBL_UNITS.Is_Deleted
                                     		 where 
											   TBL_STOCKS.STOCK_transactionParentType = 'Purchase'
											   and TBL_STOCKS.STOCK_itemID = @PRODUCT_ID 
                                               and Isnull(TBL_STOCKS.CMP_ID,'')      = isnull(@CMP_ID ,'') 
                                               and Isnull(TBL_STOCKS.BRC_ID,'')  = isnull(@BRC_ID , '')
                                               and TBL_STOCKS.Is_Deleted         = isnull(@Is_Deleted , TBL_STOCKS.Is_Deleted )
											 order by TBL_STOCKS.STOCK_date, TBL_STOCKS.STOCK_maxID , TBL_STOCKS.STOCK_orderingID
                                         

                        END






					


     END










