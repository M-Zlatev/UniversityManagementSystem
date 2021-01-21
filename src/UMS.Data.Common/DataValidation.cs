namespace UMS.Data.Common
{
    public static class DataValidation
    {
        public static class Faculty
        {
            public const int MaxNameLength = 70;
            public const int MaxDescriptionLength = 400;
        }

        public static class Department
        {
            public const int MaxNameLength = 60;
            public const int MaxDescriptionLength = 300;
        }

        public static class Major
        {
            public const int MaxNameLength = 50;
            public const int MaxDescriptionLength = 250;
        }

        public static class Course
        {
            public const int MaxNameLength = 50;
            public const int MaxDescriptionLength = 200;
            public const int MinPrice = 100;
            public const int MaxPrice = 1000;
        }

        public static class Teacher
        {
            public const int MaxNameLength = 50;
            public const int MaxPhoneNumberLength = 20;
        }

        public static class Student
        {
            public const int MaxNameLength = 50;
            public const int MaxUCNLength = 10;
            public const int MaxPhoneNumberLength = 20;
        }

        public static class Address
        {
            public const int MaxStreetNameLength = 100;
            public const int MaxTownNameLength = 85;
            public const int MaxCountryNameLength = 56;
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
