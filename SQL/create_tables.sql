
create table ##CS_TechnicalProfile
(
	id integer identity,
	name varchar(20) not null,
	description varchar(30) not null
)
go


insert into ##CS_TechnicalProfile (name, description) values ('Administrator', 'Admin')


create table ##CS_Modules
(
	id integer identity,
	name varchar(50) not null,
	description varchar(100) not null
)
go

insert into ##CS_Modules (name, description) values ('Profile', 'Profile Maintenance')