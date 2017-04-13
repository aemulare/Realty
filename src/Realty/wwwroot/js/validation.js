$(document).ready(function () {
   $("#new_user").validate({
      rules: {
         Login: {
            required: true
         },
         Password: {
            required: true,
            minlength: 6
         },
         "Person.FirstName": {
            required: true
         },
         "Person.LastName": {
            required: true
         },
         "Person.DateOfBirth": {
            required: true
         },
         "Person.TaxId": {
            required: true
         },
         "Person.PhotoId": {
            required: true
         },
         "Person.Phone": {
            required: true
         },
         "Person.Email": {
            required: true,
            email: true
         },
         "Person.Address.CountryCode": {
            required: true
         }
      }
   });



   $("#edit_user").validate({
     rules: {
       "Person.FirstName": {
         required: true
       },
       "Person.LastName": {
         required: true
       },
       "Person.DateOfBirth": {
         required: true
       },
       "Person.TaxId": {
         required: true
       },
       "Person.PhotoId": {
         required: true
       },
       "Person.Phone": {
         required: true
       },
       "Person.Email": {
         required: true,
         email: true
       },
       "Person.Address.CountryCode": {
         required: true
       }
     }
   });



   $("#property").validate({
      rules: {
         "PropertyType.Id": {
            required: true
         },
         "PropertyStyle.Id": {
            required: true
         },
         "BasementType.Id": {
            required: true
         },
         "RoofType.Id": {
            required: true
         },
         "ParkingType.Id": {
            required: true
         },
         "HeatingType.Id": {
            required: true
         },
         "AirConditioningType.Id": {
            required: true
         },
         YearBuilt: {
            required: true,
            digits: true,
            min: 1800
         },
         FloorFootage: {
            required: true,
            number: true
         },
         LotFootage: {
            required: true,
            number: true
         },
         FloorsCount: {
            required: true,
            digits: true
         },
         BedroomsCount: {
            required: true,
            digits: true
         },
         BathroomsCount: {
            required: true,
            number: true
         },
         ParkingSpacesCount: {
            required: true,
            digits: true
         },
         MaxHoa: {
            number: true
         }
      }
   });



   $("#listing").validate({
      rules: {
         "AskingPrice": {
            required: true,
            number: true,
            min: 1
         }
      }
   });
});
