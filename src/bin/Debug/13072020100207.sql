

--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_insertion




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_insertion




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_insertion







--     *****************************************************************************************************************************************************************
 
 
--                             Code Type:           Store Procedure For Insertion
--                             Auther:              Muhammad Usman Raza Attari
--                             Developed By :       786 Software House 
 
 
--    *****************************************************************************************************************************************************************
 
      CREATE procedure  [dbo].[sp_TBL_SALES_AND_RETURN_MAIN_insertion]
                                               
                                               
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
   
      declare @tmpSALES_AND_RETURN_MAIN_ID nvarchar(50)
      declare @tmpMaxID nvarchar(50)
      declare @count int 
      
      set @tmpMaxID = cast(( select  isnull( (max(cast( SALES_AND_RETURN_MAIN_maxID as int ))),0) + 1 from  TBL_SALES_AND_RETURN_MAIN
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@Is_Deleted , Is_Deleted )
                                          ) as nvarchar
                                         )
   
      if @Is_Auto_Generated = 1
        begin
             
             set @tmpSALES_AND_RETURN_MAIN_ID = @tmpMaxID
         
        end   
           else if @Is_Auto_Generated = 0
			   begin
    			  
			         set @tmpSALES_AND_RETURN_MAIN_ID = @SALES_AND_RETURN_MAIN_ID
    			
			   end 
          
      set @count = ( select count(SALES_AND_RETURN_MAIN_ID) from TBL_SALES_AND_RETURN_MAIN
                            where   
                                  SALES_AND_RETURN_MAIN_ID= @tmpSALES_AND_RETURN_MAIN_ID
                                  and  Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                  and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                  and  Is_Deleted         = isnull(@Is_Deleted , Is_Deleted )
                    )  
     
    
      if @count = 0
   
         begin
   
              insert into TBL_SALES_AND_RETURN_MAIN
                     values
                     (
                        @CMP_ID  ,
                        @BRC_ID  ,
                        @tmpSALES_AND_RETURN_MAIN_ID  ,
                        @tmpMaxID   ,
                        @SALES_AND_RETURN_MAIN_supplierID, 
                        @SALES_AND_RETURN_MAIN_VCHID, 
                        @SALES_AND_RETURN_MAIN_cashOrCredit, 
                        @SALES_AND_RETURN_MAIN_SALESOrReturn, 
                        @SALES_AND_RETURN_MAIN_date, 
                        @SALES_AND_RETURN_MAIN_totalAmount, 
                        @SALES_AND_RETURN_MAIN_totalPayableAmount, 
                        @SALES_AND_RETURN_MAIN_discountAmount, 
                        @SALES_AND_RETURN_MAIN_paidAmount, 
                        @SALES_AND_RETURN_MAIN_reference, 
                        @SALES_AND_RETURN_MAIN_narration,
						@SALES_AND_RETURN_MAIN_Maker
          ,@SALES_AND_RETURN_MAIN_Model 
          ,@SALES_AND_RETURN_MAIN_Mileage
          ,@SALES_AND_RETURN_MAIN_VehicleNumber, 
                        @Is_Auto_Generated,
                        @Is_Deleted ,
                        @User_ID  
                     )
              select 'ok' , @tmpSALES_AND_RETURN_MAIN_ID
     
       end
         else
             begin
     
                  select (select dbo.Errors.value from dbo.Errors where [key] = 'AE') , 'N'
     
             end
     
    end











