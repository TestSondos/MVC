namespace ConsoleApplication
{
    public class Weight : RecordEntity
    {
        public double Value { get; set; }
    }

    public class Temperature : RecordEntity
    {
        public double Value { get; set; }
    }

    public class Pulse : RecordEntity
    {
        public int Value { get; set; }
    }

    public class RespiratoryRate : RecordEntity
    {
        public int Value { get; set; }
    }

    public class Reference : RecordEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReferenceType { get; set; }
        public string Url { get; set; }
    }

    public class BloodPressure : RecordEntity
    {
        public int Systolic { get; set; }
        public int Diastolic { get; set; }

        public string Category
        {
            // ref: http://www.heart.org/HEARTORG/Conditions/HighBloodPressure/AboutHighBloodPressure/Understanding-Blood-Pressure-Readings_UCM_301764_Article.jsp#.V0uoqZF97IU
            get { return string.Empty; }
        }

    }
}