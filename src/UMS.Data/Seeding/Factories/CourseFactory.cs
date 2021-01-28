namespace UMS.Data.Seeding.Factories
{
    using System.Collections;
    using System.Collections.Generic;

    using static SeedingConstants.CourseSeedingConstants;

    public class CourseFactory : IFactory
    {
        public ICollection CreateEntities()
        {
            var courses = new List<(string Name, int CourseId, int MajorId)>
            {
                // Major of Fine Arts
                (ArtHistory.Name, ArtHistory.CourseId, ArtHistory.MajorId),
            };

            return courses;
        }
    }
}
