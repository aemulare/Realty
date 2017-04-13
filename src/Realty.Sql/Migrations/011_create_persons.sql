/*
  Data table definition file.
  dbo.persons
  Contains user personal info.
*/

use realty;
go

create table dbo.persons
(
  id                  int           not null  primary key identity,
  first_name          nvarchar(32)  not null,
  middle_name         nvarchar(32)  null,
  last_name           nvarchar(32)  not null,
  dob                 date          not null,
  tax_id              nvarchar(64)  not null,
  photo_id            nvarchar(64)  not null,
  company_name        nvarchar(64)  null,
  occupation          nvarchar(64)  null,
  phone_number        nvarchar(32)  not null,
  fax_number          nvarchar(32)  null,
  email               nvarchar(64)  not null,
  address_id          int           not null,
  photo               nvarchar(256) null,

  check (dob > '18700101'),

  foreign key (address_id) references dbo.addresses (id)
);
go



insert into dbo.persons (first_name, middle_name, last_name, dob, tax_id, photo_id, company_name, occupation, 
phone_number, fax_number, email, address_id, photo)
          
values
    /*1*/ ('Jesse',                 -- first_name 
     'Garrison',                    -- middle_name
     'Brenton',                     -- last_name
     '1973-02-14',                  -- dob (date of birth) 
     'EIN 173-85-5632',             -- tax_id (EIN - Employer Identification Number)
     'driver license 3485761',      -- photo_id 
     'Realty Inc',                  -- company_name
     'admin',                       -- occupation
     '1 (347) 243-8573',            -- phone_number
     '1 (347) 723-1428',            -- fax_number
     'jesse.brenton@realty.com',    -- email 
     4,                             -- address_id   40 Fulton street 5th floor, New York, NY 10038, US
     'a1.jpg'),						-- avatar picture

/*2*/('Irene', 'Sophia', 'Emerson', '1973-02-14', 'EIN 173-85-5632', 'driver license 2736512', 'Realty Inc', 'realtor',
     '1 (347) 467-4733', '1 (347) 723-1428', 'irene.emerson@realty.com', 4, 'a3.jpg'),

/*3*/('Ann', 'Mary', 'Jonson', '1975-10-12', 'SSN 102-85-7321', 'driver license 123856934', null, null,
     '1 (646) 329-7532', null, 'maryann@gmail.com', 1, 'a10.jpg'),

/*4*/('Pavel', null, 'Egorov', '1965-04-23', 'VATIN 283657235645', 'passport 4608082405', null, null,
     '8 (909) 764-0532', null, 'pasha@mail.ru', 2, 'a2.jpg'),

/*5*/('William', 'Jacob', 'Tremblay', '1983-07-19', 'BN/NE 738220046563829', 'driver license 3846725', 'Barrick Gold Corporation', 'CEO',
     '1 (416) 861-9911', '+1 (416) 861-2492', 'william.tremblay@barrick.com', 3, 'a4.jpg'),

/*6*/('Owen', 'Kenneth', 'Baker', '1979-12-30', 'SSN 043-67-6431', 'driver license VN23756683', null, null,
     '1 (646) 353-7645', null, 'owen.baker@gmail.com', 5, 'a7.jpg'),

/*7*/('Ruslan', null, 'Romanov', '1981-03-18', 'SSN 321-12-6545', 'driver license VN23235323', null, null,
     '1 (646) 324-6799', null, 'ruslan@gmail.com', 6, 'a18.jpg'),

/*8*/('Gwen', 'Ruta', 'Emerald', '1988-07-23', 'SSN 043-02-9021', 'driver license N44364623', null, null,
     '1 (646) 224-4367', null, 'emerald@gmail.com', 7, 'a11.jpg'),

/*9*/('Ekaterina', null, 'Pruss', '1980-02-09', 'VATIN 283643235611', 'passport 4604322423', null, null,
     '8 (909) 353-0521', null, 'pruss@mail.ru', 8, 'a9.png'),
     
/*10*/('Emily', 'Eve', 'Stuart', '1989-08-26', 'SSN 341-76-3412', 'driver license 756290199', null, null,
     '1 (317) 321-3452', null, 'emily.stuart@yahoo.com', 9, 'a12.jpg'),
     
/*11*/('Oliver', 'Jacob', 'Dennison', '1973-01-08', 'SSN 432-45-3453', 'driver license 754646352', 'Realty Inc', 'realtor',
      '1 (347) 467-4299', '1 (347) 723-1428', 'oliver.dennison@realty.com', 4, 'a13.jpg'),
      
/*12*/('Angela', 'Rose', 'Winters', '1988-12-19', 'SSN 664-45-9301', 'driver license 674382931', null, null,
      '1 (242) 573-0123', null, 'angela@ymail.com', 11, 'a14.jpg'),
      
/*13*/('Richard', 'Andrew', 'Stevenson', '1969-03-12', 'SSN 131-53-0012', 'driver license 234567892', null, null,
      '1 (542) 673-6578', null, 'rich.stevenson@hotmail.com', 12, 'a15.jpg'),
      
/*14*/('Nick', null, 'Sommers', '1972-04-23', 'SSN 883-01-9938', 'driver license VM634799211', null, null,
      '1 (312) 732-2472', null, 'n.sommers@mail.com', 13, 'a16.jpg'),
      
/*15*/('Miriam', null, 'Kaganivich', '1968-08-29', 'SSN 937-01-3291', 'driver license RT8437651221', null, null,
      '1 (646) 291-3459', null, 'miriam@gmail.com', 14, 'a17.jpg');
 
go


-- VATIN - value added tax identification number; en.wikipedia.org/wiki/VAT_identification_number
-- EIN - Employer Identification Number
-- SSN - Social Security Number
