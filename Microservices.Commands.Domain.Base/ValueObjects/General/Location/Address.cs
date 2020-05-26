using Microservices.Commands.Domain.Base.ValueObjects.General.Location.Cities;
using Microservices.Commands.Domain.Base.ValueObjects.General.Location.ZipCodes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.Commands.Domain.Base.ValueObjects.General.Location
{
    [ComplexType]
    public sealed class Address : ValueObject
    {
        public const short ComplementMaxLength = 120;
        public const short NeighborhoodMaxLength = 60;
        public const short StreetMaxLength = 120;

        public Address(string neighborhood, ZipCode zipCode, City city, string complement, string street, string number)
        {
            SetNeighborhood(neighborhood);
            SetZipCode(zipCode);
            SetCity(city);
            SetComplement(complement);
            SetStreet(street);
            SetNumber(number);
        }

        public Address()
        {
        }

        public City City { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string Number { get; private set; }
        public string Street { get; private set; }
        public ZipCode ZipCode { get; private set; }

        public void SetCity(City city)
        {
            if (city is null)
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.Address_City_Empty);
                return;
            }

            if (!city.IsValid())
            {
                Notification.AddError(city.Notification);
                return;
            }

            City = city;
        }

        public void SetComplement(string complement)
        {
            if (string.IsNullOrWhiteSpace(complement))
            {
                Complement = null;
                return;
            }

            if (complement.Length > ComplementMaxLength)
            {
                Notification.AddError(string.Format(DomainGeneralValueObjectsNotificationMessages.Address_Complement_MaxLengthOverflow, ComplementMaxLength));
                return;
            }

            Complement = complement;
        }

        public void SetNeighborhood(string neighborhood)
        {
            if (string.IsNullOrWhiteSpace(neighborhood))
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.Address_Neighborhood_Empty);
                return;
            }

            if (neighborhood.Length > NeighborhoodMaxLength)
            {
                Notification.AddError(string.Format(DomainGeneralValueObjectsNotificationMessages.Address_Neighborhood_MaxLengthOverflow, NeighborhoodMaxLength));
                return;
            }

            Neighborhood = neighborhood;
        }

        public void SetNumber(string number) => Number = number;

        public void SetStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.Address_Street_Empty);
                return;
            }

            Street = street;
        }

        public void SetZipCode(ZipCode zipCode)
        {
            if (zipCode is null)
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.Address_ZipCode_Empty);
                return;
            }

            if (!zipCode.IsValid())
            {
                Notification.AddError(zipCode.Notification);
                return;
            }

            ZipCode = zipCode;
        }

        public override string ToString() => $"{Street}, {Number} - {Neighborhood}, {City.Name}/{City.State.Initials}";

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return Number;
            yield return Complement;
            yield return Neighborhood;
            yield return City;
            yield return ZipCode;
        }
    }
}