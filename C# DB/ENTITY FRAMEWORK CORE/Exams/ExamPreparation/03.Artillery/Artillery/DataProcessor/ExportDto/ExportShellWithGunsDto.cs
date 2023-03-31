using Newtonsoft.Json;

namespace Artillery.DataProcessor.ExportDto
{
    public class ExportShellWithGunsDto
    {
        public double ShellWeight { get; set; }

        public string Caliber { get; set; } = null!;

        [JsonProperty("Guns")]
        public ExportShellGunDto[] Guns { get; set; }
    }
}
