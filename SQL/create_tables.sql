
create table ##CS_TechnicalProfile
(
	id integer identity,
	name varchar(20) not null,
	description varchar(30) not null
)
go


insert into ##CS_TechnicalProfile (name, description) values ('Administrator', 'Admin')

