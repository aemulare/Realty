/*
  Data table definition file.
  ref.parking_types
  Contains available parking types.
*/

use realty;
go

create table ref.parking_types
(
  id      int           not null primary key identity,
  name    nvarchar(64)  not null
);
go


insert into ref.parking_types(name) values
  ('On-Street'),
  ('Off Street'),
  ('Breezeway'),
  ('Carport'),
  ('Detached Garage'),
  ('Attached Garage') ,
  ('Indoor'),
  ('Parkade'),
  ('Underground'),
  ('Outdoor Stall'),
  ('Parking Pad')
go
