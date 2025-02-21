USE [CustomerDB]
GO
/****** Object:  StoredProcedure [dbo].[customerDetails]    Script Date: 17-02-2025 12:06:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[customerDetails]
    @Mode VARCHAR(50)='',
	@Name varchar(90)='',
	@CustomerCode int=0,
	@Address varchar(max)='',
	@Email varchar(90)='',
	@MobileNo varchar(90)='',
	@GeoLocation varchar(90)='',
	@Error_id varchar(10) output
AS
BEGIN
    IF @Mode = 'RetrieveCustomers'
    BEGIN
       select * from CustomerMaster where Status is NULL 
    END
	else IF @Mode = 'EditCustomer'
    BEGIN
      UPDATE CustomerMaster 
    SET 
        Name = @Name,
        Address = @Address,
        Email = @Email,
        MobileNo = @MobileNo,
        GeoLocation = @GeoLocation
    WHERE CustomerCode = @CustomerCode;
	set @Error_id = '3'
	END

	else IF @Mode = 'DeleteCustomer'
    BEGIN
      UPDATE CustomerMaster 
    SET Status='D'        
    WHERE CustomerCode = @CustomerCode;
	set @Error_id = '4'
	END

	else IF @Mode = 'InsertCustomer'
    BEGIN
      Insert CustomerMaster (Name, Address, Email, MobileNo, GeoLocation)
	  values(@Name, @Address, @Email, @MobileNo, @GeoLocation)
	set @Error_id = '5'
	END

	else if @Mode='GetCustomerByCode'
	begin
	       select * from CustomerMaster where CustomerCode = @CustomerCode and Status is NULL 
	end

END