/*
  Data table definition file.
  ref.roof_types
  Contains available roof types.
*/

use realty;
go

create table ref.roof_types
(
  id      int           not null primary key identity,
  name    nvarchar(64)  not null
);
go


insert into ref.roof_types(name) values
  ('Skillion and Lean-to'),
  ('Open Gable'),
  ('Box Gable'),  
  ('Dormer'),  
  ('Hip'),  
  ('Hip and Valley'),  
  ('Gambrel'),  
  ('Mansard'),  
  ('Butterfly'), 
  ('Intersecting / Overlaid Hip'),
  ('Dutch Gable'), 
  ('Hexagonal Gazebo'),
  ('Jerkinhead'),  
  ('Flat'), 
  ('Cross Hipped'),
  ('M-shaped'),  
  ('Saltbox'),
  ('Shed'),
  ('Combination'),
  ('Pyramid Hip');
go
