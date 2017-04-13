/*
  Data table definition file.
  ref.property_types
  Contains available property types.
*/

use realty;
go

create table ref.property_types
(
  id      int           not null primary key identity,
  name    nvarchar(64)  not null
);
go


insert into ref.property_types(name) values
  ('Single Family'),
  ('Multi Family'),
  ('Condominium'),
  ('Cooperative'),
  ('Townhome'),
  ('Lot/Land'),
  ('Mobile/Manufactured'),
  ('Recreational'),
  ('Other');
go
