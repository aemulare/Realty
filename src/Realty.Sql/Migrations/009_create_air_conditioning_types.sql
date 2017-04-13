/*
  Data table definition file.
  ref.air_conditioning_types
  Contains available air conditioning types.
*/

use realty;
go

create table ref.air_conditioning_types
(
  id      int           not null primary key identity,
  name    nvarchar(64)  not null
);
go


insert into ref.air_conditioning_types(name) values
  ('Window'),
  ('Central'),
  ('Ductless Split'),
  ('Ductless Mini-split'),
  ('Packaged');
go
