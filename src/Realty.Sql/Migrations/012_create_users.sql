/*
  Data table definition file.
  dbo.users
  Contains the collection of all available user accounts.
*/
use realty;
go

create table dbo.users
(
  id                  int           not null  primary key identity,
  person_id           int           not null,
  [login]             nvarchar(32)  not null,
  password_digest     nvarchar(32)  not null,
  is_active           tinyint       not null  default 1,
  is_admin            tinyint       not null  default 0,
  is_realtor          tinyint       not null  default 0,

  check (is_active between 0 and 1),
  check (is_admin between 0 and 1),
  check (is_realtor between 0 and 1),

  foreign key (person_id) references dbo.persons (id)
);
go


insert into dbo.users (person_id, [login], password_digest, is_active, is_admin, is_realtor)
  values
  (1, 'admin', 'admin', 1, 1, 0),
  (2, 'realtor', 'realtor', 1, 0, 1),
  (3, 'ann', 'ann', 1, 0, 0),
  (4, 'pavel', 'pavel', 1, 0, 0),
  (5, 'william', 'william', 1, 0, 0),
  (6, 'owen', 'owen', 1, 0, 0),
  (7, 'ruslan', 'ruslan', 1, 0, 0),
  (8, 'gwen', 'gwen', 1, 0, 0),
  (9, 'kaka', 'kaka', 1, 0, 0),
  (10, 'emily', 'emily', 1, 0, 0),
  (11, 'oliver', 'realtor2', 1, 0, 1),
  (12, 'angela', 'angela', 1, 0, 0),
  (13, 'rich', 'rich', 1, 0, 0),
  (14, 'nick', 'nick', 1, 0, 0),
  (15, 'miri', 'miri', 1, 0, 0);
go
