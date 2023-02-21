

--                                Procedure : sp_TBL_VCH_MAIN_insertion




--                                Procedure : sp_TBL_VCH_MAIN_insertion







--     *****************************************************************************************************************************************************************
 
 
--                             Code Type:           Store Procedure For Insertion
--                             Auther:              Muhammad Usman Raza Attari
--                             Developed By :       786 Software House 
 
 
--    *****************************************************************************************************************************************************************
 
      CREATE procedure  [dbo].[sp_TBL_VCH_MAIN_insertion]
                                               
                                               
           @CMP_ID  nvarchar(50) 
          ,@BRC_ID  nvarchar(50) 
          ,@VCH_ID  nvarchar(50) 
          ,@VCH_narration nvarchar(max)
          ,@VCH_prefix nvarchar(60)
          ,@VCH_date datetime
          ,@VCH_transactionID nvarchar(100)
          ,@VCH_reference nvarchar(100)
          ,@VCH_chequeNo nvarchar(100)
          ,@VCH_isApproved bit
          ,@VCH_isEffectOnFinance bit
          ,@Is_Auto_Generated  bit
          ,@Is_Deleted bit
          ,@User_ID  nvarchar(50)
          
   
      as  
      begin
   
      declare @tmpVCH_ID nvarchar(50)
      declare @tmpMaxID nvarchar(50)
      declare @count int 
      
      set @tmpMaxID = cast(( select  isnull( (max(cast( VCH_maxID as int ))),0) + 1 from  TBL_VCH_MAIN
                                             where TBL_VCH_MAIN.VCH_prefix =  @VCH_prefix
                                          ) as nvarchar
                                         )
   
     
      set @tmpVCH_ID = @VCH_prefix+ '-' + (select dbo.mergeIdInFormat('000000',@tmpMaxID))
        --select  @tmpVCH_ID
   
              insert into TBL_VCH_MAIN
                     values
                     (
                        @CMP_ID  ,
                        @BRC_ID  ,
                        @tmpVCH_ID ,
                        @tmpMaxID   ,
                        @VCH_narration, 
                        @VCH_prefix, 
                        @VCH_date, 
                        @VCH_transactionID, 
                        @VCH_reference, 
                        @VCH_chequeNo, 
                        @VCH_isApproved, 
                        @VCH_isEffectOnFinance,   
                        @Is_Auto_Generated,
                        @Is_Deleted ,
                        @User_ID  
                     )
              select 'ok' , @tmpVCH_ID
     
       
        
     
    end










