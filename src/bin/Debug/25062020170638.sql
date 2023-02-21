

--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_deletion




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_deletion




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_deletion




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_deletion




--                                Procedure : sp_TBL_SALES_AND_RETURN_MAIN_deletion



--     *****************************************************************************************************************************************************************
 
 
--                             Code Type:           Store Procedure For Deletion
--                             Auther:              Muhammad Usman Raza Attari
--                             Developed By :       786 Software House 
 
 
--    *****************************************************************************************************************************************************************
 
     CREATE procedure  sp_TBL_SALES_AND_RETURN_MAIN_deletion
                                               
                                               
     @STATUS nvarchar(100),
     @CMP_ID nvarchar(100),
     @BRC_ID nvarchar(100),
     @SALES_AND_RETURN_MAIN_ID  nvarchar(100)
     
     
   
   
     AS BEGIN 
   
    
          if @STATUS = 'D'
                BEGIN
               

			    declare @VCH_ID  nvarchar(max)
				 set @VCH_ID = (select top(1)SALES_AND_RETURN_MAIN_VCHID from TBL_SALES_AND_RETURN_MAIN 
						where
						TBL_SALES_AND_RETURN_MAIN.SALES_AND_RETURN_MAIN_ID =  @SALES_AND_RETURN_MAIN_ID
						    and Isnull(CMP_ID,'')      = isnull(@CMP_ID , '')
                            and Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
							and Is_Deleted = 0
							   )






                 delete from TBL_SALES_AND_RETURN_MAIN 
                
	                where  
                             SALES_AND_RETURN_MAIN_ID = @SALES_AND_RETURN_MAIN_ID
	                           
    
                 delete from TBL_SALES_AND_RETURN_DETAILS
                 
	                where  
                             SALES_AND_RETURN_DETAILS_mainID = @SALES_AND_RETURN_MAIN_ID
	                
				
				 delete from TBL_STOCKS

                
	                where  
                             TBL_STOCKS.STOCK_VCHID = @VCH_ID
	                 
				delete from TBL_VCH_MAIN

                
	                where  
                             TBL_VCH_MAIN.VCH_ID = @VCH_ID
	                 
				delete from TBL_VCH_DETAILS

							
								where  
										 TBL_VCH_DETAILS.VCH_DETAILS_mainID = @VCH_ID
							 


                             select 'ok' , @SALES_AND_RETURN_MAIN_ID
                   


                              
							  
							       

                END 
                
 
     END





