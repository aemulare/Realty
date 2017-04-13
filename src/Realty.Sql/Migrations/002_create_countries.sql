﻿/*
  Data table definition file.
  ref.countries
  Contains the collection of all available contries.
*/

use realty;
go

create table ref.countries
(
  id    int           not null  primary key identity,
  code  nchar(2)      not null  unique,
  name  nvarchar(256) not null
);
go


insert into ref.countries (code, name) values
( 'AF', 'Afghanistan' ),
( 'AL', 'Albania' ),
( 'DZ', 'Algeria' ),
( 'AS', 'American Samoa' ),
( 'AD', 'Andorra' ),
( 'AO', 'Angola' ),
( 'AI', 'Anguilla' ),
( 'AG', 'Antigua and Barbuda' ),
( 'AR', 'Argentina' ),
( 'AM', 'Armenia' ),
( 'AW', 'Aruba' ),
( 'AU', 'Australia' ),
( 'AT', 'Austria' ),
( 'AZ', 'Azerbaijan' ),
( 'BS', 'Bahamas' ),
( 'BH', 'Bahrain' ),
( 'BD', 'Bangladesh' ),
( 'BB', 'Barbados' ),
( 'BY', 'Belarus' ),
( 'BE', 'Belgium' ),
( 'BZ', 'Belize' ),
( 'BJ', 'Benin' ),
( 'BM', 'Bermuda' ),
( 'BT', 'Bhutan' ),
( 'BO', 'Bolivia' ),
( 'BA', 'Bosnia and Herzegovina' ),
( 'BW', 'Botswana' ),
( 'BV', 'Bouvet Island' ),
( 'BR', 'Brazil' ),
( 'BN', 'Brunei Darussalam' ),
( 'BG', 'Bulgaria' ),
( 'BF', 'Burkina Faso' ),
( 'BI', 'Burundi' ),
( 'KH', 'Cambodia' ),
( 'CM', 'Cameroon' ),
( 'CA', 'Canada' ),
( 'CV', 'Cape Verde' ),
( 'KY', 'Cayman Islands' ),
( 'CF', 'Central African Republic' ),
( 'TD', 'Chad' ),
( 'CL', 'Chile' ),
( 'CN', 'China' ),
( 'CX', 'Christmas Island' ),
( 'CC', 'Cocos (Keeling) Islands' ),
( 'CO', 'Colombia' ),
( 'KM', 'Comoros' ),
( 'CG', 'Congo' ),
( 'CD', 'Congo, the Democratic Republic of the' ),
( 'CK', 'Cook Islands' ),
( 'CR', 'Costa Rica' ),
( 'CI', 'Cote d''Ivoire' ),
( 'HR', 'Croatia' ),
( 'CU', 'Cuba' ),
( 'CW', 'Curacao' ),
( 'CY', 'Cyprus' ),
( 'CZ', 'Czech Republic' ),
( 'DK', 'Denmark' ),
( 'DJ', 'Djibouti' ),
( 'DM', 'Dominica' ),
( 'DO', 'Dominican Republic' ),
( 'EC', 'Ecuador' ),
( 'EG', 'Egypt' ),
( 'SV', 'El Salvador' ),
( 'GQ', 'Equatorial Guinea' ),
( 'ER', 'Eritrea' ),
( 'EE', 'Estonia' ),
( 'ET', 'Ethiopia' ),
( 'FO', 'Faroe Islands' ),
( 'FJ', 'Fiji' ),
( 'FI', 'Finland' ),
( 'FR', 'France' ),
( 'GF', 'French Guiana' ),
( 'PF', 'French Polynesia' ),
( 'GA', 'Gabon' ),
( 'GM', 'Gambia' ),
( 'GE', 'Georgia' ),
( 'DE', 'Germany' ),
( 'GH', 'Ghana' ),
( 'GR', 'Greece' ),
( 'GD', 'Grenada' ),
( 'GP', 'Guadeloupe' ),
( 'GU', 'Guam' ),
( 'GT', 'Guatemala' ),
( 'GN', 'Guinea' ),
( 'GW', 'Guinea-Bissau' ),
( 'GY', 'Guyana' ),
( 'HT', 'Haiti' ),
( 'HM', 'Heard Island and McDonald Islands' ),
( 'VA', 'Holy See (Vatican City State)' ),
( 'HN', 'Honduras' ),
( 'HK', 'Hong Kong' ),
( 'HU', 'Hungary' ),
( 'IS', 'Iceland' ),
( 'IN', 'India' ),
( 'ID', 'Indonesia' ),
( 'IR', 'Iran, Islamic Republic of' ),
( 'IQ', 'Iraq' ),
( 'IE', 'Ireland' ),
( 'IL', 'Israel' ),
( 'IT', 'Italy' ),
( 'JM', 'Jamaica' ),
( 'JP', 'Japan' ),
( 'JO', 'Jordan' ),
( 'KZ', 'Kazakhstan' ),
( 'KE', 'Kenya' ),
( 'KI', 'Kiribati' ),
( 'KP', 'Korea, Democratic People''s Republic of' ),
( 'KR', 'Korea, Republic of' ),
( 'KW', 'Kuwait' ),
( 'KG', 'Kyrgyzstan' ),
( 'LA', 'Lao People''s Democratic Republic' ),
( 'LV', 'Latvia' ),
( 'LB', 'Lebanon' ),
( 'LS', 'Lesotho' ),
( 'LR', 'Liberia' ),
( 'LY', 'Libyan Arab Jamahiriya' ),
( 'LI', 'Liechtenstein' ),
( 'LT', 'Lithuania' ),
( 'LU', 'Luxembourg' ),
( 'MO', 'Macao' ),
( 'MK', 'Macedonia, the Former Yugoslav Republic of' ),
( 'MG', 'Madagascar' ),
( 'MW', 'Malawi' ),
( 'MY', 'Malaysia' ),
( 'MV', 'Maldives' ),
( 'ML', 'Mali' ),
( 'MT', 'Malta' ),
( 'MH', 'Marshall Islands' ),
( 'MQ', 'Martinique' ),
( 'MR', 'Mauritania' ),
( 'MU', 'Mauritius' ),
( 'YT', 'Mayotte' ),
( 'MX', 'Mexico' ),
( 'FM', 'Micronesia, Federated States of' ),
( 'MD', 'Moldova, Republic of' ),
( 'MC', 'Monaco' ),
( 'MN', 'Mongolia' ),
( 'ME', 'Montenegro' ),
( 'MS', 'Montserrat' ),
( 'MA', 'Morocco' ),
( 'MZ', 'Mozambique' ),
( 'MM', 'Myanmar' ),
( 'NA', 'Namibia' ),
( 'NR', 'Nauru' ),
( 'NP', 'Nepal' ),
( 'NL', 'Netherlands' ),
( 'AN', 'Netherlands Antilles' ),
( 'NC', 'New Caledonia' ),
( 'NZ', 'New Zealand' ),
( 'NI', 'Nicaragua' ),
( 'NE', 'Niger' ),
( 'NG', 'Nigeria' ),
( 'NU', 'Niue' ),
( 'NF', 'Norfolk Island' ),
( 'MP', 'Northern Mariana Islands' ),
( 'NO', 'Norway' ),
( 'OM', 'Oman' ),
( 'PK', 'Pakistan' ),
( 'PW', 'Palau' ),
( 'PA', 'Panama' ),
( 'PG', 'Papua New Guinea' ),
( 'PY', 'Paraguay' ),
( 'PE', 'Peru' ),
( 'PH', 'Philippines' ),
( 'PN', 'Pitcairn' ),
( 'PL', 'Poland' ),
( 'PT', 'Portugal' ),
( 'QA', 'Qatar' ),
( 'RE', 'Reunion' ),
( 'RO', 'Romania' ),
( 'RU', 'Russian Federation' ),
( 'RW', 'Rwanda' ),
( 'SH', 'Saint Helena' ),
( 'KN', 'Saint Kitts and Nevis' ),
( 'LC', 'Saint Lucia' ),
( 'PM', 'Saint Pierre and Miquelon' ),
( 'VC', 'Saint Vincent and the Grenadines' ),
( 'WS', 'Samoa' ),
( 'SM', 'San Marino' ),
( 'ST', 'Sao Tome and Principe' ),
( 'SA', 'Saudi Arabia' ),
( 'SN', 'Senegal' ),
( 'RS', 'Serbia' ),
( 'SC', 'Seychelles' ),
( 'SL', 'Sierra Leone' ),
( 'SG', 'Singapore' ),
( 'SK', 'Slovakia' ),
( 'SI', 'Slovenia' ),
( 'SB', 'Solomon Islands' ),
( 'SO', 'Somalia' ),
( 'ZA', 'South Africa' ),
( 'GS', 'South Georgia and the South Sandwich Islands' ),
( 'ES', 'Spain' ),
( 'LK', 'Sri Lanka' ),
( 'SD', 'Sudan' ),
( 'SR', 'Suriname' ),
( 'SJ', 'Svalbard and Jan Mayen' ),
( 'SZ', 'Swaziland' ),
( 'SE', 'Sweden' ),
( 'CH', 'Switzerland' ),
( 'SY', 'Syrian Arab Republic' ),
( 'TW', 'Taiwan' ),
( 'TJ', 'Tajikistan' ),
( 'TZ', 'Tanzania, United Republic of' ),
( 'TH', 'Thailand' ),
( 'TG', 'Togo' ),
( 'TK', 'Tokelau' ),
( 'TO', 'Tonga' ),
( 'TT', 'Trinidad and Tobago' ),
( 'TN', 'Tunisia' ),
( 'TR', 'Turkey' ),
( 'TM', 'Turkmenistan' ),
( 'TC', 'Turks and Caicos Islands' ),
( 'TV', 'Tuvalu' ),
( 'UG', 'Uganda' ),
( 'UA', 'Ukraine' ),
( 'AE', 'United Arab Emirates' ),
( 'UK', 'United Kingdom' ),
( 'US', 'United States' ),
( 'UY', 'Uruguay' ),
( 'UZ', 'Uzbekistan' ),
( 'VU', 'Vanuatu' ),
( 'VE', 'Venezuela' ),
( 'VN', 'Viet Nam' ),
( 'VI', 'Virgin Islands, U.S.' ),
( 'VG', 'Virgin Islands, British' ),
( 'WF', 'Wallis and Futuna' ),
( 'EH', 'Western Sahara' ),
( 'YE', 'Yemen' ),
( 'ZM', 'Zambia' ),
( 'ZW', 'Zimbabwe' );
go
