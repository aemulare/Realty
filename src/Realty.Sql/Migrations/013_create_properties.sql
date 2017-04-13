/*
  Data table definition file.
  dbo.properties
  Contains property registrations.
*/
use realty;
go

create table dbo.properties
(
  id                        int               not null primary key identity, 
  created_at                date              not null,
  owner_id                  int               not null,
  year_built                int               not null,
  address_id                int               not null,
  address_map_url           nvarchar(256)     null,

  property_type_id          int               not null,
  property_style_id         int               not null,
  basement_type_id          int               not null,
  roof_type_id              int               not null,
  parking_type_id           int               not null,
  heating_type_id           int               not null,
  air_conditioning_type_id  int               not null,

  floor_footage             numeric(18,2)     not null, 
  lot_footage               numeric(18,2)     not null, 
  floors_count              tinyint           not null,
  bedrooms_count            tinyint           not null,
  bathrooms_count           numeric(3,1)      not null,
  parking_spaces_count      int               not null,

  max_hoa                   numeric(18,2)     null,
  appliances                nvarchar(max)     null,
  amenities                 nvarchar(max)     null,
  comments                  nvarchar(max)     null,
  photo                     nvarchar(256)     null,

  foreign key (owner_id) references dbo.users (id),
  foreign key (address_id) references dbo.addresses (id),
  foreign key (property_type_id) references ref.property_types (id),
  foreign key (property_style_id) references ref.property_styles (id),
  foreign key (basement_type_id) references ref.basement_types (id),
  foreign key (roof_type_id) references ref.roof_types (id),
  foreign key (parking_type_id) references ref.parking_types (id),
  foreign key (heating_type_id) references ref.heating_types (id),
  foreign key (air_conditioning_type_id) references ref.air_conditioning_types (id)
);
go


insert into dbo.properties(
            created_at, 
            owner_id, 
            year_built, 
            address_id, 
            address_map_url, 
            property_type_id, 
            property_style_id, 
            lot_footage,
            basement_type_id, 
            roof_type_id, 
            parking_type_id, 
            parking_spaces_count, 
            heating_type_id, 
            air_conditioning_type_id, 
            floor_footage, 
            floors_count, 
            bedrooms_count, 
            bathrooms_count, 
            max_hoa, 
            appliances, 
            amenities, 
            comments, 
            photo)
  values

/*1*/ ('2014-05-10',   -- created_at
    3,               -- owner_id                      Mary Ann Jonson      (from persons table)         
    1998,            -- year_built                    1998
    1,               -- address_id                    21 Goodall street apt. 3G Staten Island NY 10305 US (from addresses table)
    'https://goo.gl/maps/qDfUVETqAm82',            -- address_map_url               none
    1,               -- property_type_id              SINGLE FAMILY        (from ref.property_types table)
    30,              -- property_style_id             DETACHED             (from ref.property_styles table)
    7000,            -- lot_footage                   7000 sq. ft
    2,               -- basement_type_id              FULLY FINISHED       (from in ref.basement_types table)
    6,               -- roof_type_id                  HIP AND VALLEY       (from ref.roof_types table)
    5,               -- parking_type_id               DETACHED GARAGE      (from ref.parking_types table)
    2,               -- parking_spaces_count          2 cars
    1,               -- heating_type_id               FORCED AIR           (from ref.heating_types table)
    4,               -- air_conditioning_type_id      DUCTLESS MINI-SPLIT  (from ref.air>conditioning_types table)
    2700,            -- floor_footage                 2700 sq. ft.     
    2,               -- floors_count                  2 floors (storeys)
    4,               -- bedrooms_count                4 beds
    3,               -- bathrooms_count               3 baths
    250,             -- max_hoa                       $250 HOA fee
    'refrigerator, microwave, gas stove, dishwasher', -- appliances
    null,            -- amenities                     none
    null,            -- comments                      none
    'h1.jpg'),       -- photo                         



	/*2*/
    /*owner: Pavel Egorov, 
    built: 2001, 
    address: 140 Pacific Ocean street off.417 Khabarovsk, Khabarovsk region, 680035 RU, 
    url: none, 
    type: CONDOMINIUM, 
    style: SINGLE LEVEL APT,
    lot footage: 0
    basement: none, 
    roof: flat, 
    parking: underground, parking spaces: 1, 
    heating: forced air, 
    conditioning: Ductless Mini-split,
    floor footage: 2700 sq ft, floors: 2, 
    bedrooms: 4, 
    bathrooms: 3, 
    max HOA: 250, 
    appliances: {refridgerator, microwave, gas stove, disheasher},
    amenities: none, 
    comments: none, 
    photo: none */
   ('2015-12-22', 4, 2001, 2, 'https://goo.gl/maps/FNTzC2hDFN72', 3, 1, 0, 2, 14, 9, 2, 1, 4, 800, 1, 2, 2, null, 'refrigerator, microwave, gas stove, dishwasher', null, null, 'h2.jpg'),


    /*3*/
    /*owner: Emily Eve Stuart, 
    built: 2016, 
    address: 40 Patrick Ln, Valhalla, NY 10595 US, 
    url: https://goo.gl/maps/8RXKVKK5r1H2, 
    type: SINGLE FAMILY, 
    style: DETACHED,
    lot footage: 6820
    basement: fully finished, 
    roof: dormer, 
    parking: detached garage, parking spaces: 2, 
    heating: forced air, 
    conditioning: central,
    floor footage: 2905 sq ft, floors: 2, 
    bedrooms: 4, 
    bathrooms: 2.5, 
    max HOA: 300, 
    appliances: {refrigerator, microwave, gas stove, dishwasher, wahser, dryer},
    amenities: Lake privileges, Playground, Club house 
    comments: Colonial style, 
    photo: none */
	('2016-07-22', 10, 2016, 9, 'https://goo.gl/maps/8RXKVKK5r1H2', 1, 30, 6820, 2, 4, 6, 2, 1, 2, 2905, 2, 4, 2.5, 300, 'refrigerator, microwave, gas stove, dishwasher, wahser, dryer', 'Lake privileges, Playground, Club house', 'Colonial style', 'propertyID_3.jpg'),

    
/*4*/('2016-05-11',   -- created_at
    13,               -- owner_id           Richard Stevenson                          
    2005,             -- year_built                    
    10,               -- address_id         2419 Windrow Dr. Princeton                    
    'https://goo.gl/maps/dzuptqZ3q6A2',            
    3,               -- property_type_id    Condo            
    33,              -- property_style_id               
    0,               -- lot_footage                   
    1,               -- basement_type_id             
    14,               -- roof_type_id                 
    9,               -- parking_type_id              
    1,               -- parking_spaces_count         
    2,               -- heating_type_id              
    2,               -- air_conditioning_type_id     
    650,            -- floor_footage                
    1,               -- floors_count                  
    1,               -- bedrooms_count               
    1,               -- bathrooms_count              
    100,             -- max_hoa                     
    'refrigerator, microwave, gas stove', -- appliances
    null,            -- amenities                     none
    null,            -- comments                      none
    'h3.jpg'),       -- photo   
    
    
    
/*5*/('2015-03-27',   -- created_at
    14,               -- owner_id           Nick Sommers                          
    1999,             -- year_built                    
    13,               -- address_id         221 Monahan Ave, Staten Island NY                    
    'https://goo.gl/maps/LLP84akMsk12',            
    2,               -- property_type_id    Multy Family            
    25,              -- property_style_id               
    8165,            -- lot_footage                   
    3,               -- basement_type_id             
    3,               -- roof_type_id                 
    2,               -- parking_type_id              
    2,               -- parking_spaces_count         
    1,               -- heating_type_id              
    4,               -- air_conditioning_type_id     
    3200,            -- floor_footage                
    2,               -- floors_count                  
    4,               -- bedrooms_count               
    4,               -- bathrooms_count              
    230,             -- max_hoa                     
    'microwave, gas stove', -- appliances
    null,            -- amenities                     none
    null,            -- comments                      none
    'h4.jpg'),       -- photo    
    
    
/*6*/('2016-02-06',   -- created_at
    15,               -- owner_id           Miriam kaganovich                          
    2001,             -- year_built                    
    14,               -- address_id         444 Klondike Ave, Staten Island NY                    
    'https://goo.gl/maps/WsExJgLYBeS2',            
    2,               -- property_type_id    Multi Family            
    25,              -- property_style_id   duplex Sid by Side              
    7450,            -- lot_footage                   
    3,               -- basement_type_id             
    3,               -- roof_type_id                 
    4,               -- parking_type_id              
    4,               -- parking_spaces_count         
    1,               -- heating_type_id              
    4,               -- air_conditioning_type_id     
    3620,            -- floor_footage                
    2,               -- floors_count                  
    6,               -- bedrooms_count               
    6,               -- bathrooms_count              
    375,             -- max_hoa                     
    'refrigerator, microwave, gas stove, dishwasher', -- appliances
    null,            -- amenities                     none
    null,            -- comments                      none
    'h5.jpg');       -- photo                                                                  
go
