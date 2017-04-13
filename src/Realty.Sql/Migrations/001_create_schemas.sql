/*
  Creates DB schemas.
*/

use realty;
go

if not exists (select * from sys.schemas where name = 'ref')
  exec('create schema ref');
go
