

--                                Procedure : sp_GET_MAX




--                                Procedure : sp_GET_MAX




--                                Procedure : sp_GET_MAX




--                                Procedure : sp_GET_MAX




--                                Procedure : sp_GET_MAX




--                                Procedure : sp_GET_MAX




--                                Procedure : sp_GET_MAX





--                                Procedure : sp_GET_MAX




     CREATE procedure  [dbo].[sp_GET_MAX]
                       
				                           
          @STATUS nvarchar(50),
		  @CMP_ID nvarchar(50),
		  @BRC_ID nvarchar(50),
		  @isDeleted bit ,											   
          @Dependent_C1  int ,
          @Dependent_C2  int ,
          @Dependent_C3  int ,
          @Dependent_S1  nvarchar(50) ,
          @Dependent_S2  nvarchar(50) ,
          @Dependent_S3  nvarchar(50) 
         

   
     as  

	 		if @STATUS =  'TBL_TEST_MAIN'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( TEST_MAIN_maxID as int ))),0) + 1 from  TBL_TEST_MAIN
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		



	 		if @STATUS =  'TBL_RASHID'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( RASHID_maxID as int ))),0) + 1 from  TBL_RASHID
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		


	 		if @STATUS =  'TBL_PURCHASE_AND_RETURN_MAIN'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( PURCHASE_AND_RETURN_MAIN_maxID as int ))),0) + 1 from  TBL_PURCHASE_AND_RETURN_MAIN
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end

			if @STATUS =  'TBL_SALES_AND_RETURN_MAIN'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( SALES_AND_RETURN_MAIN_maxID as int ))),0) + 1 from  TBL_SALES_AND_RETURN_MAIN
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		


	 		if @STATUS =  'TBL_VCH_MAIN'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( VCH_maxID as int ))),0) + 1 from  TBL_VCH_MAIN
                                             
                                              where
											     TBL_VCH_MAIN.VCH_prefix = @Dependent_S1 -- this will work as prefix
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		



	 		if @STATUS =  'TBL_BRC'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( BRC_maxID as int ))),0) + 1 from  TBL_BRC
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		



	 		if @STATUS =  'TBL_CMP'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( CMP_maxID as int ))),0) + 1 from  TBL_CMP
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		



	 		if @STATUS =  'TBL_USERS'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( USERS_maxID as int ))),0) + 1 from  TBL_USERS
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		



	 	if @STATUS =  'TBL_RIGHTS_MAIN'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( RIGHTS_MAIN_maxID as int ))),0) + 1 from  TBL_RIGHTS_MAIN
                                             
                                              --where   
                                              --Isnull(CMP_ID,'')  = isnull(@CMP_ID , '')
                                              --and  Isnull(BRC_ID,'')  = isnull(@BRC_ID , '')
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end


	 if @STATUS =  'TBL_RIGHTS_TEMPLATE'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( RIGHTS_TEMPLATE_maxID as int ))),0) + 1 from  TBL_RIGHTS_TEMPLATE
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

     
	 		if @STATUS =  'TBL_FINANCIAL_YEAR'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( FINANCIAL_YEAR_maxID as int ))),0) + 1 from  TBL_FINANCIAL_YEAR
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		



	 		if @STATUS =  'TBL_TEMP_MAIN'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( TEMP_MAIN_maxID as int ))),0) + 1 from  TBL_TEMP_MAIN
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		



     		if @STATUS =  'TBL_PACKINGS_MAIN'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( PACKING_MAIN_maxID as int ))),0) + 1 from  TBL_PACKINGS_MAIN
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

     
     		if @STATUS =  'TBL_PRODUCTS'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( PRODUCT_maxID as int ))),0) + 1 from  TBL_PRODUCTS
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		


     		if @STATUS =  'TBL_SUPPLIERS'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( SUPPLIER_maxID as int ))),0) + 1 from  TBL_SUPPLIERS
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

     
     		if @STATUS =  'TBL_CUSTOMERS'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( CUSTOMER_maxID as int ))),0) + 1 from  TBL_CUSTOMERS
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

     		if @STATUS =  'TBL_VEHICLE_MAKERS'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( VEHICLE_MAKER_maxID as int ))),0) + 1 from  TBL_VEHICLE_MAKERS
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

      
      		if @STATUS =  'TBL_UNITS'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( UNIT_maxID as int ))),0) + 1 from  TBL_UNITS
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

      
      
      		if @STATUS =  'TBL_DEPARTMENTS'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( DEPARTMENT_maxID as int ))),0) + 1 from  TBL_DEPARTMENTS
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

      
     
     		if @STATUS =  'TBL_WEIGHTS'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( WEIGHTS_maxID as int ))),0) + 1 from  TBL_WEIGHTS
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

     
     		 if @STATUS =  'TBL_KEY'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( KEY_maxID as int ))),0) + 1 from  TBL_KEY
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

     
     
     		if @STATUS =  'TBL_KEYS_TYPES'
		begin

                         select cast(
                                      ( select  isnull( (max(cast( KEYS_TYPES_maxID as int ))),0) + 1 from  TBL_KEYS_TYPES
                                             
                                              where   
                                              Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
                                              and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
                                              --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
                                       ) as nvarchar
                                     )
   		
		
		end
		

     
     
  --   		 if @STATUS =  'TBL_CATEGORY2'
		--begin

  --                       select cast(
  --                                    ( select  isnull( (max(cast( CATEGORY2_maxID as int ))),0) + 1 from  TBL_CATEGORY2
                                             
  --                                            --where   
  --                                            --Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
  --                                            --and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
  --                                            --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
  --                                     ) as nvarchar
  --                                   )
   		
		
		--end
		

     

	 --		 if @STATUS =  'TBL_PRODUCTS_2'
		--begin

  --                       select cast(
  --                                    ( select  isnull( (max(cast( PRODUCTS_maxID as int ))),0) + 1 from  TBL_PRODUCTS_2
                                             
  --                                            --where   
  --                                            --Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
  --                                            --and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
  --                                            --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
  --                                     ) as nvarchar
  --                                   )
   		
		
		--end
		


     
  --   		if @STATUS =  'TABLE_ADD_STOCK'
		--begin

  --                       select cast(
  --                                    ( select  isnull( (max(cast( ADD_STOCK_maxID as int ))),0) + 1 from  TABLE_ADD_STOCK
                                             
  --                                            where   
  --                                            [USER_ID]= @Dependent_S1                                              
  --                                            --and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
  --                                            --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
  --                                     ) as nvarchar
  --                                   )
   		
		
		--end
		

     
  --  if @STATUS =  'TBL_PRODUCTS'
		--begin

  --                       select cast(
  --                                    ( select  isnull( (max(cast( PRODUCTS_maxID as int ))),0) + 1 from  TBL_PRODUCTS
                                             
  --                                            --where   
  --                                            --Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
  --                                            --and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
  --                                            --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
  --                                     ) as nvarchar
  --                                   )
   		
		
		--end
		

   
  -- 		if @STATUS =  'TBL_CATEGORY'
		--begin

  --                       select cast(
  --                                    ( select  isnull( (max(cast( CATEGORY_maxID as int ))),0) + 1 from  TBL_CATEGORY
                                             
  --                                            --where   
  --                                            --Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
  --                                            --and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
  --                                            --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
  --                                     ) as nvarchar
  --                                   )
   		
		
		--end
		

  -- 		if @STATUS =  'TBL_WEIGHT'
		--begin

  --                       select cast(
  --                                    ( select  isnull( (max(cast( WEIGHT_maxID as int ))),0) + 1 from  TBL_WEIGHT
                                             
  --                                            --where   
  --                                            --Isnull(CMP_ID,'')  = isnull((@CMP_ID) , isNull(CMP_ID,''))
  --                                            --and  Isnull(BRC_ID,'')  = isnull((@BRC_ID) , isNull(BRC_ID,''))
  --                                            --and  Is_Deleted         = isnull(@isDeleted , Is_Deleted )
  --                                     ) as nvarchar
  --                                   )
   		
		
		--end
		

   
   
    if @STATUS  = 'PerLevel' -- will select max for given level
		begin
			
			declare @maxvalue nvarchar(50)
		set @maxvalue =(select  MAX( dbo.TBL_COA.COA_UID) from dbo.TBL_COA
			
			where 
			  dbo.TBL_COA.COA_PARENTID =@Dependent_S1  and 
			isnull(CMP_ID , '') =ISNULL( @CMP_ID,ISNULL(CMP_ID,'')) and
			isnull(BRC_ID , '') =ISNULL( @BRC_ID,ISNULL(BRC_ID,'')) 
			)
			
	select  (isnull((max (CAST( RIGHT(@maxvalue,5) as int))),0) + 1 )
	 
		end

if @STATUS  = 'PerLevelCAT' -- will select max for given level
		begin
		
			declare @id nvarchar(50)
		set @id =(select  MAX( dbo.TBL_COA.COA_UID) from dbo.TBL_COA
			
			where 
			  TBL_COA.COA_PARENTID =@Dependent_S1  and 
		  	isnull(CMP_ID , '') =ISNULL( @CMP_ID,ISNULL(CMP_ID,'')) and
			isnull(BRC_ID , '') =ISNULL( @BRC_ID,ISNULL(BRC_ID,'')) 
			)
	
	declare  @level nvarchar(50) =  RIGHT(@id,8)
 		 declare @level2 nvarchar (50) = left(@level,2)
 		declare  @max int =  CAST((@level2)as int)+1
         declare  @max_length int = len(@max)
 
        declare  @zeros nvarchar(50)  = ''
          declare @i nvarchar(50) = 1 
         while @i <= (2- @max_length)
     begin
     	set @zeros = @zeros + '0'
    	set @i = @i + 1
    
		end
		 select ISNULL( @zeros + CAST((@max)as nvarchar),1)  
end



	
     

		
 
 

   

		

	
		
	

	
	
	
	

		else if @STATUS  = 'PerLevel1' -- will select max for given level
		begin
	
		select (isnull( (max(cast( TBL_COA.COA_levelID as int ))),0) + 1) from TBL_COA 
			where 
			isnull(CMP_ID , '') =ISNULL( @CMP_ID,ISNULL(CMP_ID,'')) and
			isnull(BRC_ID , '') =ISNULL( @BRC_ID,ISNULL(BRC_ID,'')) and
			TBL_COA.COA_isDeleted = isnull((@isDeleted) , TBL_COA.COA_isDeleted) and
    
			TBL_COA.COA_PARENTID =@Dependent_S1 
			
	
		end

		
		







