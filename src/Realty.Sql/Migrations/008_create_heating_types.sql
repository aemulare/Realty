/*
  Data table definition file.
  ref.heating_types
  Contains available heating types.
*/

use realty;
go

create table ref.heating_types
(
  id      int           not null primary key identity,
  name    nvarchar(64)  not null
);
go


insert into ref.heating_types(name) values
  ('Forced Air'),
  ('Radiant'),
  ('Hydronic'),
  ('Steam Radiant'),
  ('Geothermal'),
  ('Wood Stoves'),
  ('Fan Coils'),
  ('Gravity'),
  ('Boilers');
go
