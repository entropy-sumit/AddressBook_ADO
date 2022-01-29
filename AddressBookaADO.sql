create database AddressBookUsingAdo


create table AddressBookTables(
Id int identity(1,1) primary key,
FirstName varchar(255),
LastName varchar(255),
PhoneNumber varchar(21),
Address varchar(255),
City varchar(50),
State varchar(50),
ZipCode int,
Email varchar(255)
);
select * from AddressBookTables




