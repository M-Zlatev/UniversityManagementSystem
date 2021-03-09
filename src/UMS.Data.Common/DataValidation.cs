namespace UMS.Data.Common
{
    public static class DataValidation
    {
        public static class Faculty
        {
            public const int MaxNameLength = 70;
            public const int MaxDescriptionLength = 1000;
            public const int MinPhoneNumberLength = 4;
            public const int MaxPhoneNumberLength = 25;
            public const int MinEmailAddressLength = 3;
            public const int MaxEmailAdressLength = 100;
            public const int MinFaxNumberLength = 5;
            public const int MaxFaxNumberLength = 15;
        }

        public static class Department
        {
            public const int MaxNameLength = 60;
            public const int MaxDescriptionLength = 1000;
            public const int MinPhoneNumberLength = 4;
            public const int MaxPhoneNumberLength = 25;
            public const int MinEmailAddressLength = 3;
            public const int MaxEmailAdressLength = 100;
            public const int MinFaxNumberLength = 5;
            public const int MaxFaxNumberLength = 15;
        }

        public static class Major
        {
            public const int MaxNameLength = 50;
            public const int MaxDescriptionLength = 800;
            public const int MinRangeInYears = 1;
            public const int MaxRangeInYears = 10;
        }

        public static class Course
        {
            public const int MaxNameLength = 50;
            public const int MaxDescriptionLength = 800;
            public const int MinPrice = 100;
            public const int MaxPrice = 1000;
            public const int MinGrade = 2;
            public const int MaxGrade = 6;
        }

        public static class Teacher
        {
            public const int MaxNameLength = 50;
            public const int MinPhoneNumberLength = 4;
            public const int MaxPhoneNumberLength = 20;
            public const int MinEmailAddressLength = 3;
            public const int MaxEmailAdressLength = 100;
        }

        public static class Student
        {
            public const int MaxNameLength = 50;
            public const int MinUCNLength = 10;
            public const int MaxUCNLength = 10;
            public const int MinPhoneNumberLength = 4;
            public const int MaxPhoneNumberLength = 20;
            public const int MinEmailAddressLength = 3;
            public const int MaxEmailAdressLength = 100;
            public const string UCNErrorMessage = "This field must contains 10 digits";
            public const string DisplayName = "Uniform civil number";
        }

        public static class Address
        {
            public const int MinStreetNameLength = 1;
            public const int MaxStreetNameLength = 100;
            public const int MinDistrictNameLength = 1;
            public const int MaxDistrictNameLength = 70;
            public const int MinTownNameLength = 1;
            public const int MaxTownNameLength = 85;
            public const int MinCountryNameLength = 4;
            public const int MaxCountryNameLength = 56;
            public const int MinPostalCodeLength = 2;
            public const int MaxPostalCodeLength = 12;
        }

        public static class Homework
        {
            public const int MaxContentLength = 1000;
        }

        public static class Resource
        {
            public const int MaxNameLength = 40;
        }
    }
}
