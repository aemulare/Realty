//=================================================================================================
// Class Person
// Person model.
//=================================================================================================
using System;
using System.Linq;

namespace Realty.Models
{
   /// <summary>
   /// Person model.
   /// </summary>
   public class Person : PersistentEntity
   {
      #region Private members

      private string photo;

      #endregion

      #region Public properties

      /// <summary>
      /// First name.
      /// </summary>
      public string FirstName { get; set; }

      /// <summary>
      /// Middle name.
      /// </summary>
      public string MiddleName { get; set; }

      /// <summary>
      /// Last name.
      /// </summary>
      public string LastName { get; set; }

      /// <summary>
      /// Full name.
      /// </summary>
      public string FullName => $"{LastName}, {FirstName}";

      /// <summary>
      /// A person name as combined first and last name.
      /// </summary>
      public string ReversedFullName => $"{FirstName} {LastName}";

      /// <summary>
      /// Date of birth.
      /// </summary>
      public DateTime? DateOfBirth { get; set; }

      /// <summary>
      /// Tax ID document name and number.
      /// </summary>
      public string TaxId { get; set; }

      /// <summary>
      /// Photo ID document name (passport, driver license, etc.) and number.
      /// </summary>
      public string PhotoId { get; set; }

      /// <summary>
      /// Company name (for persons who represents company as buyer/seller).
      /// </summary>
      public string Company { get; set; }

      /// <summary>
      /// Occupation of a person who represents company.
      /// </summary>
      public string Occupation { get; set; }

      /// <summary>
      /// Contact phone number.
      /// </summary>
      public string Phone { get; set; }

      /// <summary>
      /// Contact fax number.
      /// </summary>
      public string Fax { get; set; }

      /// <summary>
      /// Contact email.
      /// </summary>
      public string Email { get; set; }

      /// <summary>
      /// Address.
      /// </summary>
      public Address Address { get; private set; } = new Address();

      /// <summary>
      /// Property photo.
      /// Represents a file name containing the property photo.
      /// </summary>
      public string Photo
      {
         get { return this.photo ?? "default_person.png"; }
         set { this.photo = value; }
      }

      #endregion

      #region Public methods

      /// <summary>
      /// A person string representation.
      /// </summary>
      public override string ToString() => string.Join(", ",
         new[]{ ReversedFullName, Company, Occupation }.Where(item => !string.IsNullOrWhiteSpace(item)));

      #endregion

      #region Internal properties

      /// <summary>
      /// Updates properties of the given person from the specified person instance.
      /// </summary>
      /// <param name="person">Person instance</param>
      internal void UpdateProperties(Person person)
      {
         FirstName = person.FirstName;
         MiddleName = person.MiddleName;
         LastName = person.LastName;
         DateOfBirth = person.DateOfBirth;
         TaxId = person.TaxId;
         PhotoId = person.PhotoId;
         Company = person.Company;
         Occupation = person.Occupation;
         Phone = person.Phone;
         Fax = person.Fax;
         Email = person.Email;
         Address.UpdateProperties(person.Address);
         Photo = person.Photo;
      }

      #endregion
   }
}
