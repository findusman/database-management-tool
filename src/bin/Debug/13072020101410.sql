

--                                Procedure : sp_TBL_STOCKS_insertion




--                                Procedure : sp_TBL_STOCKS_insertion







--     *****************************************************************************************************************************************************************
 
 
--                             Code Type:           Store Procedure For Insertion
--                             Auther:              Muhammad Usman Raza Attari
--                             Developed By :       786 Software House 
 
 
--    *****************************************************************************************************************************************************************
 
      CREATE procedure  [dbo].[sp_TBL_STOCKS_insertion]
                                               
                                               
           @CMP_ID  nvarchar(50) 
          ,@BRC_ID  nvarchar(50) 
          ,@STOCK_transactionID  nvarchar(50) 
          ,@STOCK_orderingID int 
          ,@STOCK_VCHID nvarchar(100)
          ,@STOCK_transactionParentType nvarchar(100)
          ,@STOCK_transactionChildType nvarchar(100)
          ,@STOCK_date datetime
          ,@STOCK_stockLocationID nvarchar(100)
          ,@STOCK_itemID nvarchar(100)
          ,@STOCK_salePrice float
          ,@STOCK_purchasePrice float
          ,@STOCK_saleDiscount float
          ,@STOCK_purchaseDiscount float
          ,@STOCK_unit nvarchar(100)
          ,@STOCK_QTY float
          ,@STOCK_stockAddRemoveStatus nvarchar(100)
		  ,@STOCK_maxID int 
          
          ,@Is_Deleted bit
          ,@User_ID  nvarchar(50)
          ,@Is_Last bit
		  ,@STOCK_narration nvarchar(max)
         
   
      as  
      begin
   
      declare @tmpMaxID nvarchar(50)
      
	  declare @tmpQTY1 float = 0
	  declare @tmpQTY2 float  = 0
      declare @tmpQTY3 float  = 0

	  declare @tmpQTY_For_Rate1 float = 0
	  declare @tmpQTY_For_Rate2 float  = 0
      declare @tmpQTY_For_Rate3 float  = 0



	  declare @tmpUnit1 nvarchar(200) 
	  declare @tmpUnit2 nvarchar(200)
      declare @tmpUnit3 nvarchar(200)
	  declare @tmpStockinValue float
	  declare @tmpPurchase1 float = 0
	  declare @tmpPurchase2 float  = 0
      declare @tmpPurchase3 float  = 0


	  set @tmpUnit1 = (select V_ProductWithAllPackedInfo.U1_ID from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @STOCK_itemID and Is_Deleted =0)
	  set @tmpUnit2 = (select V_ProductWithAllPackedInfo.U2_ID from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @STOCK_itemID and Is_Deleted =0)
      set @tmpUnit3 = (select V_ProductWithAllPackedInfo.U3_ID from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @STOCK_itemID and Is_Deleted =0)

	  set @tmpQTY_For_Rate1 = (select V_ProductWithAllPackedInfo.U1_QTY from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @STOCK_itemID and Is_Deleted =0)
	  set @tmpQTY_For_Rate2 = (select V_ProductWithAllPackedInfo.U2_QTY from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @STOCK_itemID and Is_Deleted =0)
      set @tmpQTY_For_Rate3 = (select V_ProductWithAllPackedInfo.U3_QTY from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @STOCK_itemID and Is_Deleted =0)



	  if @tmpUnit1 =  @STOCK_unit
	  begin
	     set @tmpQTY1 = @STOCK_QTY
	     set @tmpPurchase1 = @STOCK_purchasePrice
	     set @tmpPurchase2 = (@STOCK_purchasePrice / @tmpQTY_For_Rate2)
		 set @tmpPurchase3 = ((@STOCK_purchasePrice / @tmpQTY_For_Rate2) / @tmpQTY_For_Rate3)
		 
	 if  @STOCK_transactionParentType = 'sales'  or @STOCK_transactionParentType = 'Sales Return'
	 
					 begin
		 					set @STOCK_purchasePrice	= 
														(           select	avg(TBL_STOCKS.STOCK_purchasePrice1) from TBL_STOCKS  where 
														TBL_STOCKS.STOCK_transactionParentType = 'purchase'  
														and TBL_STOCKS.STOCK_itemID =	@STOCK_itemID)

					 end
		

	  end
		
	  else if @tmpUnit2 =  @STOCK_unit
	  begin
		
		 set @tmpQTY2 = @STOCK_QTY
	     set @tmpPurchase1 = (@STOCK_purchasePrice * @tmpQTY_For_Rate2)
	     set @tmpPurchase2 = @STOCK_purchasePrice
		 set @tmpPurchase3 = (@STOCK_purchasePrice / @tmpQTY_For_Rate3) 

		 if  @STOCK_transactionParentType = 'sales'  or @STOCK_transactionParentType = 'Sales Return'
	 
					 begin
		 					set @STOCK_purchasePrice	= 
														(           select	avg(TBL_STOCKS.STOCK_purchasePrice2) from TBL_STOCKS  where 
														TBL_STOCKS.STOCK_transactionParentType = 'purchase'  
														and TBL_STOCKS.STOCK_itemID =	@STOCK_itemID)

					 end
		

	  end
		else if @tmpUnit3 =  @STOCK_unit
	  begin

	     set @tmpQTY3 = @STOCK_QTY
		 set @tmpPurchase1 = (@STOCK_purchasePrice * @tmpQTY_For_Rate2 * @tmpQTY_For_Rate3)
	     set @tmpPurchase2 = @STOCK_purchasePrice * @tmpQTY_For_Rate3
		 set @tmpPurchase3 = @STOCK_purchasePrice 

		 if  @STOCK_transactionParentType = 'sales'  or @STOCK_transactionParentType = 'Sales Return'
	 
					 begin
		 					set @STOCK_purchasePrice	= 
														(           select	avg(TBL_STOCKS.STOCK_purchasePrice3) from TBL_STOCKS  where 
														TBL_STOCKS.STOCK_transactionParentType = 'purchase'  
														and TBL_STOCKS.STOCK_itemID =	@STOCK_itemID)

					 end
					  end


	  if @STOCK_transactionParentType = 'sales'  or @STOCK_transactionParentType = 'Sales Return'
	  begin
	  
	   set @tmpPurchase1 = 0
	     set @tmpPurchase2 = 0
		 set @tmpPurchase3 = 0

	  end



     if @STOCK_stockAddRemoveStatus = 'Add'
	     set @tmpStockinValue = @STOCK_purchasePrice * @STOCK_QTY
		    else 
		    set @tmpStockinValue =   cast(( cast((@STOCK_purchasePrice * @STOCK_QTY  ) as nvarchar)) as float) 

      
      set @tmpMaxID = cast(( select  isnull( (max(cast( STOCK_ID as int ))),0) + 1 from  TBL_STOCKS
                                              
                                          ) as nvarchar
                                         )
   
      if(@STOCK_maxID = -1)
			
			set @STOCK_maxID = cast(( select  isnull( (max(cast( STOCK_maxID as int ))),0) + 1 from  TBL_STOCKS
                                              
                                          ) as nvarchar
                                         )
   


if @STOCK_orderingID = 0
   begin
		delete from TBL_STOCKS
		where        
                      Is_Deleted  = 0
					  and STOCK_transactionID = @STOCK_transactionID
					  and STOCK_transactionParentType = @STOCK_transactionParentType

  end


   
              insert into TBL_STOCKS
                     values
                     (
                        @CMP_ID  ,
                        @BRC_ID  ,
                        @tmpMaxID  ,
                        @STOCK_transactionID  ,
			            @STOCK_orderingID, 
                        @STOCK_VCHID, 
                        @STOCK_transactionParentType, 
                        @STOCK_transactionChildType, 
                        @STOCK_date, 
                        @STOCK_stockLocationID, 
                        @STOCK_itemID, 
                        @STOCK_salePrice, 
                        @STOCK_purchasePrice,
						@tmpStockinValue, 
                        @STOCK_saleDiscount, 
                        @STOCK_purchaseDiscount, 
                        @STOCK_unit, 
                        @STOCK_QTY, 
                        @STOCK_stockAddRemoveStatus,
						@STOCK_maxID,    
						@tmpQTY1,
						@tmpQTY2,
						@tmpQTY3,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						@STOCK_narration,
						@Is_Deleted ,
                        @User_ID  ,
						@tmpPurchase1,
						@tmpPurchase2,
						@tmpPurchase3
                     )



					update TBL_STOCKS set 
							TBL_STOCKS.STOCK_isCLosing_Updated = 0
							where 
							TBL_STOCKS.STOCK_itemID = @STOCK_itemID
							and TBL_STOCKS.Is_Deleted = 0




		

     select 'ok' , @STOCK_maxID  
     
	 if @Is_Last = 1
				exec sp_TBL_STOCKS_getNonClosedStock_selection
     
     
    end
























