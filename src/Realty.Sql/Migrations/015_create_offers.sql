/*
  Data table definition file.
  dbo.offers
  Contains offers.
*/

use realty;
go

create table dbo.offers
(
  id              int             not null  primary key identity,
  offer_status    tinyint         not null  default 0,
  listing_id      int             not null,
  buyer_id        int             not null,
  offer_price     numeric(18,2)   not null,

  created_at      datetime        not null,
  expired_at      datetime        not null,
  completed_at    datetime        null,

  -- ACTIVE, ACCEPTED, CANCELLED
  check (offer_status between 0 and 2),
  check (completed_at > created_at),
  check (expired_at > created_at),

  foreign key (listing_id) references dbo.listings (id),
  foreign key (buyer_id) references dbo.users (id)
);
go

insert into dbo.offers(offer_status, listing_id, buyer_id, offer_price, created_at, expired_at, completed_at)
  values
/*1*/ (2, 1, 4, 1300000, '2016-11-26 15:20', '2016-12-06 15:20', null),
/*2*/ (2, 1, 5, 1200000, '2016-11-26 10:00', '2016-12-06 10:00', null),
/*3*/ (2, 1, 6, 1250000, '2016-11-25 13:20', '2016-12-05 13:20', null),
/*4*/ (1, 1, 7, 1350000, '2016-11-25 11:30', '2016-12-05 11:30', '2016-12-01 14:00'),
/*5*/ (2, 2, 8, 2480, '2016-11-25 12:40', '2016-12-05 12:40', null),
/*6*/ (1, 2, 9, 2500, '2016-11-25 14:50', '2016-12-05 14:50', null),
/*7*/ (0, 4, 12, 1560, '2016-12-06 12:30', '2016-12-12 12:30', null),
/*8*/ (0, 5, 1, 1400000, '2016-12-10 11:40', '2016-12-20 11:40', null),
/*8*/ (0, 6, 3, 1500000, '2016-12-05 09:15', '2016-12-15 09:15', null);
go