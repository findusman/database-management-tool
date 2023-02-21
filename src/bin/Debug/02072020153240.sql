

--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_updation




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_updation




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_updation




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_updation





--     *****************************************************************************************************************************************************************
 
 
--                             Code Type:           Store Procedure For updation
--                             Auther:              Muhammad Usman Raza Attari
--                             Developed By :       786 Software House 
 
 
--    *****************************************************************************************************************************************************************
 
      CREATE procedure  [dbo].[sp_TBL_SALES_AND_RETURN_MAIN_updation]
                                               
                                               
           @CMP_ID  nvarchar(50) 
          ,@BRC_ID  nvarchar(50) 
          ,@SALES_AND_RETURN_MAIN_ID  nvarchar(50) 
          ,@SALES_AND_RETURN_MAIN_supplierID nvarchar(max)
          ,@SALES_AND_RETURN_MAIN_VCHID nvarchar(100)
          ,@SALES_AND_RETURN_MAIN_cashOrCredit nvarchar(100)
          ,@SALES_AND_RETURN_MAIN_SALESOrReturn nvarchar(100)
          ,@SALES_AND_RETURN_MAIN_date datetime
          ,@SALES_AND_RETURN_MAIN_totalAmount float
          ,@SALES_AND_RETURN_MAIN_totalPayableAmount float
          ,@SALES_AND_RETURN_MAIN_discountAmount float
          ,@SALES_AND_RETURN_MAIN_paidAmount float
          ,@SALES_AND_RETURN_MAIN_reference nvarchar(max)
          ,@SALES_AND_RETURN_MAIN_narration nvarchar(max)
          ,@SALES_AND_RETURN_MAIN_Maker nvarchar(max)
          ,@SALES_AND_RETURN_MAIN_Model nvarchar(max)
          ,@SALES_AND_RETURN_MAIN_Mileage nvarchar(max)
          ,@SALES_AND_RETURN_MAIN_VehicleNumber nvarchar(max)
          ,@Is_Auto_Generated  bit
          ,@Is_Deleted bit
          ,@User_ID  nvarchar(50)
          
      as  
      begin
   
   
      update TBL_SALES_AND_RETURN_MAIN
      set                     

      
                SALES_AND_RETURN_MAIN_supplierID = @SALES_AND_RETURN_MAIN_supplierID,
                SALES_AND_RETURN_MAIN_VCHID = @SALES_AND_RETURN_MAIN_VCHID,
                SALES_AND_RETURN_MAIN_cashOrCredit = @SALES_AND_RETURN_MAIN_cashOrCredit,
                SALES_AND_RETURN_MAIN_SALESOrReturn = @SALES_AND_RETURN_MAIN_SALESOrReturn,
                SALES_AND_RETURN_MAIN_date = @SALES_AND_RETURN_MAIN_date,
                SALES_AND_RETURN_MAIN_totalAmount = @SALES_AND_RETURN_MAIN_totalAmount,
                SALES_AND_RETURN_MAIN_totalPayableAmount = @SALES_AND_RETURN_MAIN_totalPayableAmount,
                SALES_AND_RETURN_MAIN_discountAmount = @SALES_AND_RETURN_MAIN_discountAmount,
                SALES_AND_RETURN_MAIN_paidAmount = @SALES_AND_RETURN_MAIN_paidAmount,
                SALES_AND_RETURN_MAIN_reference = @SALES_AND_RETURN_MAIN_reference,
                        SALES_AND_RETURN_MAIN_narration = @SALES_AND_RETURN_MAIN_narration 
						,SALES_AND_RETURN_MAIN_Maker =@SALES_AND_RETURN_MAIN_Maker
          ,SALES_AND_RETURN_MAIN_Model = @SALES_AND_RETURN_MAIN_Model
          ,SALES_AND_RETURN_MAIN_Mileage = @SALES_AND_RETURN_MAIN_Mileage
          ,SALES_AND_RETURN_MAIN_VehicleNumber  = @SALES_AND_RETURN_MAIN_VehicleNumber                   
                
      where
      SALES_AND_RETURN_MAIN_ID=  @SALES_AND_RETURN_MAIN_ID
      
			    and Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                             and Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                             
			     and  Is_Deleted         = isnull(@Is_Deleted , Is_Deleted ) 
                        
      select 'ok' , @SALES_AND_RETURN_MAIN_ID
     
       
      
     
    end












