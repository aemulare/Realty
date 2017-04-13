/*
  Data table definition file.
  dbo.addresses
  Contains addresses.
*/

use realty;
go

create table dbo.addresses
(
  id                  int           not null primary key identity,
  street_address_1    nvarchar(64)  null,
  street_address_2    nvarchar(64)  null,
  city                nvarchar(64)  null,
  us_state            nchar(2)      null,
  region              nvarchar(64)  null, 
  postal_code         nvarchar(16)  null,
  country_code        nchar(2)      not null  default 'US',

  foreign key (country_code) references ref.countries (code)
);
go


insert into dbo.addresses(street_address_1, street_address_2, city, us_state, region, postal_code, country_code)
  values
 /*1*/ ('21 Goodall street', 'apt. 3G', 'Staten Island', 'NY', null, '10305', 'US'),
 /*2*/ ('140 Pacific Ocean street', 'apt. 417', 'Khabarovsk', null, 'Khabarovsk region', '680035', 'RU'),
 /*3*/ ('1 Austin Terrace', null, 'Toronto', null, 'Ontario', 'M5R 1X8', 'CA'),
 /*4*/ ('40 Fulton street', '5th floor', 'New York', 'NY', null, '10038', 'US'),
 /*5*/ ('26 Guilford street', null, 'Staten Island', 'NY', null, '10308', 'US'),
 /*6*/ ('101 Madison Ave', 'apt. 604', 'New York', 'NY', null, '10032', 'US'),
 /*7*/ ('101 Madison Ave', 'apt. 523', 'New York', 'NY', null, '10032', 'US'),
 /*8*/ ('10 Rudnevka street', 'apt. 12', 'Khabarovsk', null, 'Khabarovsk region', '680035', 'RU'),
 /*9*/ ('40 Patrick Ln', null, 'Valhalla', 'NY', null, '10595', 'US'),
 /*10*/ ('2419 Windrow Drive', 'apt. 3F', 'Princeton', 'NJ', null, '08540', 'US'),
 /*11*/ ('121 Moore St', null, 'Princeton', 'NJ', null, '08540', 'US'),
 /*12*/ ('9 Linden Ln', null, 'Plainsboro Township', 'NJ', null, '08536', 'US'),
 /*13*/ ('221 Monahan Ave', null, 'Staten Island', 'NY', null, '10314', 'US'),
 /*14*/ ('444 Klondike Ave', null, 'Staten Island', 'NY', null, '10314', 'US'); 
go
