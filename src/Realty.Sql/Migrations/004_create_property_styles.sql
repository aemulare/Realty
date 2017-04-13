/*
  Data table definition file.
  ref.property_styles
  Contains available property styles.
*/

use realty;
go

create table ref.property_styles
(
  id      int           not null primary key identity,
  name    nvarchar(64)  not null
);
go


insert into ref.property_styles(name) values
  ('Not Applicable'),
  ('Single Level Apartment'),
  ('Multi Level Apartment'),
  ('Back Split'),
  ('Bi-Level'),
  ('Bungalow'),
  ('Hillside Bungalow'),
  ('Raised Bungalow'),
  ('Bungalow Semi'),
  ('Penthouse'),
  ('Stacked Townhouse'),
  ('Studio Suite'),
  ('Villa'),
  ('2 Level Split'),
  ('3 Level Split'),
  ('4 Level Split'),
  ('5 Level Split'),
  ('Double Wide Mobile Home'),
  ('Single Wide Mobile Home'),
  ('Modular Home'),
  ('1 and Half Storey'),
  ('2 Storey'),
  ('2 and Half Storey'),
  ('3 Storey'),
  ('Duplex Side-by-Side'),
  ('Duplex Up-and-Down'),
  ('Half Duplex'),
  ('Triplex'),
  ('Quadruplex'),
  ('Detached'),
  ('Attached'),
  ('Semi-attached'),
  ('Apartment Lowrise'),
  ('Apartment Highrise'),
  ('Parking stall')
go
