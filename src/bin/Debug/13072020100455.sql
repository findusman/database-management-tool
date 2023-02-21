

--                                Procedure : sp_TBL_SALES_AND_RETURN_DETAILS_insertion








      CREATE procedure  [dbo].[sp_TBL_SALES_AND_RETURN_DETAILS_insertion]
                                               
                                               
          @CMP_ID  nvarchar(50) 
          ,@BRC_ID  nvarchar(50) 
          ,@SALES_AND_RETURN_DETAILS_mainID  nvarchar(50) 
          ,@SALES_AND_RETURN_DETAILS_orderingID int 
          ,@SALES_AND_RETURN_DETAILS_itemID nvarchar(100)
          ,@SALES_AND_RETURN_DETAILS_itemUnit nvarchar(100)
          ,@SALES_AND_RETURN_DETAILS_SALESPrice float
		  ,@SALES_AND_RETURN_DETAILS_costPrice float
          ,@SALES_AND_RETURN_DETAILS_QTY float
          ,@SALES_AND_RETURN_DETAILS_total float
          ,@Is_Deleted bit
          ,@User_ID  nvarchar(50)
          
   
      as  
      begin
   
      declare @tmpUnit1 nvarchar(200) 
	  declare @tmpUnit2 nvarchar(200)
      declare @tmpUnit3 nvarchar(200)
      set @tmpUnit1 = (select V_ProductWithAllPackedInfo.U1_ID from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @SALES_AND_RETURN_DETAILS_itemID and Is_Deleted =0)
	  set @tmpUnit2 = (select V_ProductWithAllPackedInfo.U2_ID from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @SALES_AND_RETURN_DETAILS_itemID and Is_Deleted =0)
      set @tmpUnit3 = (select V_ProductWithAllPackedInfo.U3_ID from V_ProductWithAllPackedInfo where V_ProductWithAllPackedInfo.PRODUCT_ID = @SALES_AND_RETURN_DETAILS_itemID and Is_Deleted =0)



	    if @tmpUnit1 =  @SALES_AND_RETURN_DETAILS_itemUnit
	    begin
	     
				set @SALES_AND_RETURN_DETAILS_costPrice	= 
							            (           select	avg(TBL_STOCKS.STOCK_purchasePrice1) from TBL_STOCKS  where 
										TBL_STOCKS.STOCK_transactionParentType = 'purchase'  
										and TBL_STOCKS.STOCK_itemID =	@SALES_AND_RETURN_DETAILS_itemID)


	  end
		else if @tmpUnit2 =  @SALES_AND_RETURN_DETAILS_itemUnit
	    begin
	     
				set @SALES_AND_RETURN_DETAILS_costPrice	= 
							            (           select	avg(TBL_STOCKS.STOCK_purchasePrice2) from TBL_STOCKS  where 
										TBL_STOCKS.STOCK_transactionParentType = 'purchase'  
										and TBL_STOCKS.STOCK_itemID =	@SALES_AND_RETURN_DETAILS_itemID)


	  end
	  else if @tmpUnit3 =  @SALES_AND_RETURN_DETAILS_itemUnit
	    begin
	     
				set @SALES_AND_RETURN_DETAILS_costPrice	= 
							            (           select	avg(TBL_STOCKS.STOCK_purchasePrice3) from TBL_STOCKS  where 
										TBL_STOCKS.STOCK_transactionParentType = 'purchase'  
										and TBL_STOCKS.STOCK_itemID =	@SALES_AND_RETURN_DETAILS_itemID)


	  end
	 
	 


  


      declare @tmpMaxID nvarchar(50)
      
      
      set @tmpMaxID = cast(( select  isnull( (max(cast( SALES_AND_RETURN_DETAILS_ID as int ))),0) + 1 from  TBL_SALES_AND_RETURN_DETAILS
                                              
                                          ) as nvarchar
                                         )
   
if @SALES_AND_RETURN_DETAILS_orderingID = 0
   begin
		delete from TBL_SALES_AND_RETURN_DETAILS
		where        
                      Is_Deleted  = 0
					  and  (TBL_SALES_AND_RETURN_DETAILS.SALES_AND_RETURN_DETAILS_mainID = @SALES_AND_RETURN_DETAILS_mainID
                             or TBL_SALES_AND_RETURN_DETAILS.SALES_AND_RETURN_DETAILS_mainID = @SALES_AND_RETURN_DETAILS_mainID)
					  

  end


   
              insert into TBL_SALES_AND_RETURN_DETAILS
                     values
                     (
                        @CMP_ID  ,
                        @BRC_ID  ,
                        @tmpMaxID  ,
                        @SALES_AND_RETURN_DETAILS_mainID  ,
			            @SALES_AND_RETURN_DETAILS_orderingID, 
                        @SALES_AND_RETURN_DETAILS_itemID, 
                        @SALES_AND_RETURN_DETAILS_itemUnit, 
                        @SALES_AND_RETURN_DETAILS_costPrice,
						@SALES_AND_RETURN_DETAILS_SALESPrice,
						@SALES_AND_RETURN_DETAILS_QTY, 
                        @SALES_AND_RETURN_DETAILS_total,                          
                        @Is_Deleted ,
                        @User_ID  
                     )
              select 'ok' , @tmpMaxID  
     
     
     
    end














