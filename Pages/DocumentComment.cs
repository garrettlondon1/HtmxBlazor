using System.Text.Json.Serialization;

namespace HtmxDotnet.Pages
{
    public class DocumentComment
    {
        [JsonIgnore]
        public new Guid Id { get; set; }
        public string bodyValue { get; set; }

        [JsonPropertyName("@context")]
        public List<string> context { get; set; } = new();
        public string type { get; set; }
        [JsonPropertyName("id")]
        public string AdobeId { get; set; }
        public string motivation { get; set; }
        public Target? target { get; set; }
        public Stylesheet? stylesheet { get; set; }
        public Creator? creator { get; set; }
        public DateTimeOffset created { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset modified { get; set; } = DateTimeOffset.UtcNow;
    }

    public class Selector
    {
        public Node node { get; set; }
        public List<double> quadPoints { get; set; }
        public double opacity { get; set; }
        public string subtype { get; set; }
        public List<double> boundingBox { get; set; }
        public List<List<double>> inkList { get; set; }
        public string strokeColor { get; set; }
        public int strokeWidth { get; set; }
        public string type { get; set; }

        public string styleClass { get; set; }
    }

    public class Target
    {
        public string source { get; set; }
        public Selector selector { get; set; }
    }


    public class Creator
    {
        [JsonPropertyName("id")]
        public string email { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Node
    {
        public int index { get; set; }
    }

    public class RootAnnotation
    {
        public string type { get; set; }
        public DocumentComment data { get; set; }

    }

    public class Stylesheet
    {
        public string type { get; set; }
        public string value { get; set; }
    }
}
