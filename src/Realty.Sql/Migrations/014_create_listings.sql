/*
  Data table definition file.
  dbo.listings
  Contains available property listings.
*/
use realty;
go

create table dbo.listings
(
  id                  int             not null  primary key identity,
  purpose             tinyint         not null  default 0,
  listing_status      tinyint         not null  default 0,
  property_id         int             not null,
  realtor_id          int             not null,
  asking_price        numeric(18,2)   not null,
  status_changed_at   datetime        not null,
  created_at          datetime        not null,
  completed_at        datetime        null,
  comments            nvarchar(max)   null,

  -- FOR_SALE, FOR_RENT
  check (purpose between 0 and 1),

  -- INITIAL, IN_PROGRESS, HOLD, COMPLETED, CANCELLED
  check (listing_status between 0 and 4),

  foreign key (property_id) references dbo.properties (id),
  foreign key (realtor_id) references dbo.users (id)
);
go


insert into dbo.listings(purpose, listing_status, property_id, realtor_id, asking_price, created_at, status_changed_at, completed_at, comments)
  values
 /*1*/(0, 3, 1, 2, 1250000, '2016-11-24 17:40', '2016-12-10 11:40', null, null),
 /*2*/(1, 3, 2, 2, 2500, '2016-11-24 17:41', '2016-11-24 17:41', null, null),
 /*3*/(0, 0, 3, 2, 1450000, '2016-08-10 14:35', '2016-08-10 14:35', null, null),
 /*4*/(1, 1, 4, 11, 1560, '2016-12-03 16:10', '2016-12-06 12:30', null, null),
 /*5*/(0, 1, 5, 11, 1425000, '2016-12-01 10:05', '2016-12-01 10:05', null, null),
 /*6*/(0, 1, 6, 11, 1500000, '2016-12-01 11:25', '2016-12-05 09:15', null, null);
go