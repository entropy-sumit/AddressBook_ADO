create database AddressBookUsingAdo


create table AddressBookTables(
Id int identity(1,1) primary key,
FirstName varchar(255),
LastName varchar(255),
PhoneNumber varchar(21),
Address varchar(255),
City varchar(50),
State varchar(50),
ZipCode varchar(24),
Email varchar(255)
);
select * from AddressBookTables


insert into AddressBookTables(FirstName,LastName,PhoneNumber,Address,City,State,ZipCode,Email)
values('Sum','Raw','78787889','hapyind','mumbai','maharastra','256451','sumraw@gmail.com')

Create procedure [dbo].[AddressBookSystemProcedure]
(

	@FirstName	varchar(150),		
	@LastName	varchar(150),	
	@Address	varchar(150),		
	@City	varchar(150),	
	@State	varchar(150),	
	@ZipCode	varchar(6),
    @PhoneNumber varchar(10),
	@Email	varchar(150)	
)	

	as begin
	Insert into AddressBookTables values(@FirstName,@LastName,@Address,@City,@State,@ZipCode,@PhoneNumber,@Email);
	End




