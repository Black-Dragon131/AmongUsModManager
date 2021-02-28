using System.Xml.Serialization;
using System.Collections.Generic;

namespace AmongUsModManager
{
	[XmlRoot(ElementName = "mod")]
	public class Mod
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "author")]
		public string Author { get; set; }
		[XmlElement(ElementName = "preview_url")]
		public string Preview_url { get; set; }
		[XmlElement(ElementName = "download_url")]
		public string Download_url { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "github")]
		public bool Github { get; set; }
		[XmlElement(ElementName = "download_BepInEx")]
		public bool DownloadBepInEx { get; set; }
		[XmlElement(ElementName = "needs_appid")]
		public bool NeedsAppid { get; set; }
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "mods")]
	public class Mods
	{
		[XmlElement(ElementName = "mod")]
		public List<Mod> Mod { get; set; }
	}

}
