using medrecs.data.Core;

namespace medrecs.data
{
    public class Reference : RecordEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReferenceType { get; set; }
        public string Url { get; set; }
    }
}