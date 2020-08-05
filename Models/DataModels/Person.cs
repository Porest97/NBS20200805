using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBS.Models.DataModels
{
    public class Person
    {
        public int Id { get; set; }

        // Person Setting props!
        [Display(Name = "Role")]
        public int? PersonRoleId { get; set; }
        [Display(Name = "Role")]
        [ForeignKey("PersonRoleId")]
        public PersonRole PersonRole { get; set; }

        [Display(Name = "Status")]
        public int? PersonStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("PersonStatusId")]
        public PersonStatus PersonStatus { get; set; }

        [Display(Name = "Person Type")]
        public int? PersonTypeId { get; set; }
        [Display(Name = "Person Type")]
        [ForeignKey("PersonTypeId")]
        public PersonType PersonType { get; set; }

        // Person Org props !
        [Display(Name = "Company")]
        public int? CompanyId { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }


        //Person Personalia !
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get { return string.Format("{0} {1} ", FirstName, LastName); } }

        //CName = Contact Name with Phonenumbers attached !
        public string CName { get { return string.Format("{0} {1} ", FullName, Ssn); } }

        [Display(Name = "Streetaddress")]
        public string StreetAddress { get; set; }

        [Display(Name = "Postalcode")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Address")]
        public string Address { get { return string.Format("{0} {1} {2}", StreetAddress, ZipCode, City); } }

        [Display(Name = "SSN")]
        public string Ssn { get; set; }

        [Display(Name = "Telefonnummer1")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Telefonnummer2")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber2 { get; set; }

        [Display(Name = "Phone #")]
        public string PhoneNumbers { get { return string.Format("{0} {1} ", PhoneNumber1, PhoneNumber2); } }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Person Accounts !
        [Display(Name = "Accounts")]
        public int? PersonAccountsId { get; set; }
        [Display(Name = "Accounts")]
        [ForeignKey("PersonAccountsId")]
        public PersonAccounts PersonAccounts { get; set; }
    }

    //Roles, Statuses and Types !

    public class PersonRole
    {
        public int Id { get; set; }

        [Display(Name = "Role")]
        public string PersonRoleName { get; set; }
    }

    public class PersonStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string PersonStatusName { get; set; }
    }

    public class PersonType
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string PersonTypeName { get; set; }
    }

    //Person Accounts !

    public class PersonAccounts
    {
        public int Id { get; set; }
        // Person Accounts !
        [Display(Name = "Swish #")]
        [DataType(DataType.PhoneNumber)]
        public string SwishNumber { get; set; }

        [Display(Name = "Bank #")]
        public string BankAccount { get; set; }

        [Display(Name = "Bank")]
        public string BankName { get; set; }

        [Display(Name = "Swish# and Bank#")]
        public string PaymentDetails { get { return string.Format("{0} {1} {2} {3}", "Swish#", SwishNumber, "Bank#", BankAccount); } }

    }

}