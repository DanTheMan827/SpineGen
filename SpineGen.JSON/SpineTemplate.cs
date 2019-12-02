using Newtonsoft.Json;
using SpineGen.Interfaces;
using System.Drawing;
using System.IO;

namespace SpineGen.JSON
{
    public class SpineTemplate<T>: Spine.Template<T>
    {
        [JsonIgnore]
        public override IBitmap<T> Image { get => base.Image; set => base.Image = value; }

        [JsonConverter(typeof(RectangleConverter))]
        public override Rectangle LogoArea { get => base.LogoArea; set => base.LogoArea = value; }

        public string Name;
        public string Category;
        public bool ShouldSerializeImage() => false;
        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
        public void ToJsonFile(string filename) => File.WriteAllText(filename, ToJson());
        public static SpineTemplate<T> FromJson(IBitmap<T> image, string json)
        {
            var template = JsonConvert.DeserializeObject<SpineTemplate<T>>(json);
            template.Image = image;
            return template;
        }
        public static SpineTemplate<T> FromJsonFile(IBitmap<T> image, string filename) => FromJson(image, File.ReadAllText(filename));
        public override string ToString()
        {
            if (Name != null && Category != null)
                return $"{Category} - {Name}";

            if (Name != null)
                return Name;

            return base.ToString();
        }
    }
}
