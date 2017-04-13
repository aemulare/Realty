/*
  Data table definition file.
  dbo.sales
  Contains sales.
*/

use realty;
go

create table dbo.sales
(
  id            int             not null  primary key identity,
  sold_at       datetime        not null,
  offer_id      int             not null, 
  realtor_fee   numeric(18,2)   not null,

  foreign key (offer_id) references dbo.offers (id)
);


insert into dbo.sales(sold_at, offer_id, realtor_fee)
  values
 ('2016-12-01 14:00', 4, 135000),
 ('2016-11-29 15:30', 6, 2500);
go