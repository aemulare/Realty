/*
  Data table definition file.
  ref.basement_types
  Contains available basement types.
*/

use realty;
go

create table ref.basement_types
(
  id      int           not null primary key identity,
  name    nvarchar(64)  not null
);
go


insert into ref.basement_types(name) values
  ('No Basement'),
  ('Fully Finished'),
  ('Partly Finished'),
  ('Unfinished'),
  ('Remodelled'),
  ('Suite');
go
