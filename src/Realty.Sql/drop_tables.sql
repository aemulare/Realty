use realty
go

if object_id('dbo.sales', 'U') is not null
  drop table dbo.sales;

if object_id('dbo.offers', 'U') is not null
  drop table dbo.offers;

if object_id('dbo.listings', 'U') is not null
  drop table dbo.listings;

if object_id('dbo.properties', 'U') is not null
  drop table dbo.properties;

if object_id('dbo.users', 'U') is not null
  drop table dbo.users;

if object_id('dbo.persons', 'U') is not null
  drop table dbo.persons;

if object_id('dbo.addresses', 'U') is not null
  drop table dbo.addresses;

if object_id('ref.air_conditioning_types', 'U') is not null
  drop table ref.air_conditioning_types

if object_id('ref.heating_types', 'U') is not null
  drop table ref.heating_types

if object_id('ref.roof_types', 'U') is not null
  drop table ref.roof_types;

if object_id('ref.parking_types', 'U') is not null
  drop table ref.parking_types;

if object_id('ref.basement_types', 'U') is not null
  drop table ref.basement_types;

if object_id('ref.property_styles', 'U') is not null
  drop table ref.property_styles;

if object_id('ref.property_types', 'U') is not null
  drop table ref.property_types;

if object_id('ref.countries', 'U') is not null
  drop table ref.countries;
go

if object_id('dbo.schemaVersions', 'U') is not null
  drop table dbo.schemaVersions;
go
