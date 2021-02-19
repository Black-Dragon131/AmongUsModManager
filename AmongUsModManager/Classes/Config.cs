using System.Xml.Serialization;
using System.Collections.Generic;
namespace AmongUsModManager
{
	[XmlRoot(ElementName = "installedMod")]
	public class InstalledMod
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "preview_url")]
		public string Preview_url { get; set; }
		[XmlElement(ElementName = "location")]
		public string Location { get; set; }
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
		[XmlElement(ElementName = "creationDate")]
		public string CreationDate { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }

	}

	[XmlRoot(ElementName = "installedMods")]
	public class InstalledMods
	{
		[XmlElement(ElementName = "installedMod")]
		public List<InstalledMod> InstalledMod { get; set; }
	}

	[XmlRoot(ElementName = "config")]
	public class Config
	{
		[XmlElement(ElementName = "amongUsPath")]
		public string AmongUsPath { get; set; }
		[XmlElement(ElementName = "checkModUpdates")]
		public bool CheckModUpdates { get; set; }
		[XmlElement(ElementName = "checkAummUpdates")]
		public bool CheckAummUpdates { get; set; }
		[XmlElement(ElementName = "installedMods")]
		public InstalledMods InstalledMods { get; set; }
	}

}
