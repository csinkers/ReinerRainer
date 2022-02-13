<Query Kind="Program">
  <Reference Relative="..\..\build\UAlbion\bin\Debug\net6.0\SerdesNet.dll">C:\Depot\bb\ualbion\build\UAlbion\bin\Debug\net6.0\SerdesNet.dll</Reference>
  <Reference Relative="..\..\build\UAlbion\bin\Debug\net6.0\UAlbion.Api.dll">C:\Depot\bb\ualbion\build\UAlbion\bin\Debug\net6.0\UAlbion.Api.dll</Reference>
  <Reference Relative="..\..\build\UAlbion\bin\Debug\net6.0\UAlbion.Base.dll">C:\Depot\bb\ualbion\build\UAlbion\bin\Debug\net6.0\UAlbion.Base.dll</Reference>
  <Reference Relative="..\..\build\UAlbion\bin\Debug\net6.0\UAlbion.Config.dll">C:\Depot\bb\ualbion\build\UAlbion\bin\Debug\net6.0\UAlbion.Config.dll</Reference>
  <Reference Relative="..\..\build\UAlbion\bin\Debug\net6.0\UAlbion.Core.dll">C:\Depot\bb\ualbion\build\UAlbion\bin\Debug\net6.0\UAlbion.Core.dll</Reference>
  <Reference Relative="..\..\build\UAlbion\bin\Debug\net6.0\UAlbion.dll">C:\Depot\bb\ualbion\build\UAlbion\bin\Debug\net6.0\UAlbion.dll</Reference>
  <Reference Relative="..\..\build\UAlbion\bin\Debug\net6.0\UAlbion.Formats.dll">C:\Depot\bb\ualbion\build\UAlbion\bin\Debug\net6.0\UAlbion.Formats.dll</Reference>
  <Reference Relative="..\..\build\UAlbion\bin\Debug\net6.0\UAlbion.Game.dll">C:\Depot\bb\ualbion\build\UAlbion\bin\Debug\net6.0\UAlbion.Game.dll</Reference>
  <Namespace>UAlbion</Namespace>
  <Namespace>UAlbion.Api</Namespace>
  <Namespace>UAlbion.Api.Visual</Namespace>
  <Namespace>UAlbion.Config</Namespace>
  <Namespace>UAlbion.Formats</Namespace>
  <Namespace>UAlbion.Formats.Assets</Namespace>
  <Namespace>UAlbion.Formats.Assets.Labyrinth</Namespace>
  <Namespace>UAlbion.Formats.Assets.Maps</Namespace>
  <Namespace>UAlbion.Game</Namespace>
  <Namespace>UAlbion.Game.Assets</Namespace>
  <RemoveNamespace>System.Collections</RemoveNamespace>
  <RemoveNamespace>System.Data</RemoveNamespace>
  <RemoveNamespace>System.Diagnostics</RemoveNamespace>
  <RemoveNamespace>System.Linq.Expressions</RemoveNamespace>
  <RemoveNamespace>System.Reflection</RemoveNamespace>
  <RemoveNamespace>System.Text</RemoveNamespace>
  <RemoveNamespace>System.Threading</RemoveNamespace>
  <RemoveNamespace>System.Transactions</RemoveNamespace>
  <RemoveNamespace>System.Xml</RemoveNamespace>
  <RemoveNamespace>System.Xml.Linq</RemoveNamespace>
  <RemoveNamespace>System.Xml.XPath</RemoveNamespace>
  <RuntimeVersion>6.0</RuntimeVersion>
</Query>

readonly AssetType[] TypesToConvert = new[] { 
	AssetType.EventText,
	AssetType.MapText,
	AssetType.Labyrinth,
	AssetType.Map,
	AssetType.Monster,
	AssetType.Npc,
	AssetType.Party,
	AssetType.LargePartyGraphics,
	AssetType.SmallPartyGraphics,
	AssetType.Portrait,
	AssetType.FullBodyPicture,
	AssetType.Word,
	AssetType.TacticalIcon,
};

const UAlbion.Base.SmallNpc          SmallNpcId = UAlbion.Base.SmallNpc.Man;
const UAlbion.Base.LargeNpc          LargeNpcId = UAlbion.Base.LargeNpc.Rainer;
const UAlbion.Base.MonsterGraphics MonsterGfxId = UAlbion.Base.MonsterGraphics.Security;
const UAlbion.Base.DungeonObject   DungeonObjId = UAlbion.Base.DungeonObject.Security;
const UAlbion.Base.Portrait     PartyPortraitId = UAlbion.Base.Portrait.Rainer;
const UAlbion.Base.Portrait       NpcPortraitId = UAlbion.Base.Portrait.RainerHofstedt;

void Main()
{
	const string destMod = "ReinerRainer";
	var scriptDir = Path.GetDirectoryName(Util.CurrentQueryPath); // should be something like .../mods/ReinerRainer
	var baseDir = Path.GetDirectoryName(Path.GetDirectoryName(scriptDir));

	var disk = new FileSystem();
	disk.CurrentDirectory = baseDir;
	AssetSystem.LoadEvents();
	var baseExchange = AssetSystem.SetupSimple(disk, AssetMapping.Global, new[] { "Base" });
	var assets = baseExchange.Resolve<IAssetManager>();
	var rainerSheet = assets.LoadSheet(UAlbion.Base.PartyMember.Rainer);
	var securitySheet = assets.LoadSheet(UAlbion.Base.Monster.Secu1);
	var partyPortrait = assets.LoadTexture(PartyPortraitId);
	var npcPortrait = assets.LoadTexture(NpcPortraitId);
	var largePartyGfx = assets.LoadTexture(UAlbion.Base.LargePartyMember.Rainer);
	var smallPartyGfx = assets.LoadTexture(UAlbion.Base.SmallPartyMember.Rainer);
	var fullBody = assets.LoadTexture(UAlbion.Base.FullBodyPicture.Rainer);
	var dungeonObj = assets.LoadTexture(DungeonObjId);
	var tacticalGfx = assets.LoadTexture(UAlbion.Base.TacticalGraphics.Rainer);

	var extraIds = new[]
	{
		((SpriteId)SmallNpcId).ToString(),
		((SpecialId)UAlbion.Base.Special.Words1).ToString(),
		((SpecialId)UAlbion.Base.Special.Words2).ToString(),
		((SpecialId)UAlbion.Base.Special.Words3).ToString(),
		((SpriteId)LargeNpcId).ToString(),
	};

	var humanoidSmall = new[] {
		UAlbion.Base.SmallNpc.Iskai,
		UAlbion.Base.SmallNpc.Iskai2,
		UAlbion.Base.SmallNpc.OldMan,
		UAlbion.Base.SmallNpc.Man,
		UAlbion.Base.SmallNpc.Woman,
		UAlbion.Base.SmallNpc.Woman2,
		UAlbion.Base.SmallNpc.Woman3,
		UAlbion.Base.SmallNpc.Woman4,
		UAlbion.Base.SmallNpc.Man2,
		UAlbion.Base.SmallNpc.Man3,
		UAlbion.Base.SmallNpc.Man4,
		UAlbion.Base.SmallNpc.Man5,
		UAlbion.Base.SmallNpc.Man6,
		UAlbion.Base.SmallNpc.Krondir,
		UAlbion.Base.SmallNpc.Krondir2,
		UAlbion.Base.SmallNpc.EvilKangaroo,
		UAlbion.Base.SmallNpc.PeskyWasp,
		UAlbion.Base.SmallNpc.Man7,
		UAlbion.Base.SmallNpc.FloatingHand,
	}.Select(x => (SpriteId)x).ToArray();

	object Convert(AssetId id, object asset)
	{
		if (asset == null)
			return null;
		
		if (asset is BaseMapData map)
		{
			foreach (var npc in map.Npcs)
			{
				switch (map.MapType)
				{
					case MapType.TwoDOutdoors:
						if (humanoidSmall.Contains(npc.SpriteOrGroup))
							npc.SpriteOrGroup = (SpriteId)SmallNpcId;
						break;
					case MapType.TwoD:
						npc.SpriteOrGroup = (SpriteId)LargeNpcId;
						break;
				}
			}

			return map;
		}

		if (asset is ListStringCollection stringList)
			return new ListStringCollection(stringList.Select(ProcessString).ToList());
		
		if (asset is LabyrinthData lab)
		{
			foreach(var obj in lab.Objects)
			{
				var (enumType, num) = AssetMapping.Global.IdToEnum(obj.SpriteId);
				if (enumType != typeof(UAlbion.Base.DungeonObject))
					continue;

				if (MonsterObjects.Contains((UAlbion.Base.DungeonObject)num))
				{
					obj.SpriteId = DungeonObjId;
					obj.Width  = (ushort)dungeonObj.Regions[0].Width;
					obj.Height = (ushort)dungeonObj.Regions[0].Height;
					obj.MapWidth = (ushort)(obj.Width * 2);
					obj.MapHeight = (ushort)(obj.Height * 2);
					obj.FrameCount = (byte)dungeonObj.Regions.Count;
				}
			}
			return lab;
		}
		
		if (asset is CharacterSheet sheet)
		{
			if (id == (AssetId)(MonsterId)UAlbion.Base.Monster.ServiceRobot) return asset;

			if (sheet.Type == CharacterType.Party)
				return rainerSheet;

			sheet.EnglishName = "Rainer";
			sheet.GermanName = "Rainer";
			sheet.Gender = Gender.Male;
			sheet.PortraitId = sheet.Type == CharacterType.Party ? PartyPortraitId : NpcPortraitId;
			
			if (sheet.Type == CharacterType.Monster)
			{
				sheet.Attributes.CopyFrom(rainerSheet.Attributes);
				sheet.Combat.CopyFrom(rainerSheet.Combat);
				sheet.Magic.CopyFrom(rainerSheet.Magic);
				sheet.Skills.CopyFrom(rainerSheet.Skills);
				sheet.Morale = rainerSheet.Morale;
				sheet.Monster.CopyFrom(securitySheet.Monster);
				sheet.MonsterGfxId = MonsterGfxId;
			}
			return sheet;
		}
		
		if (asset is ITexture)
		{
			if (id.Type == AssetType.Portrait)
				return (id.Id < 11) ? partyPortrait : npcPortrait;
			if (id.Type == AssetType.LargePartyGraphics)
				return largePartyGfx;
			if (id.Type == AssetType.SmallPartyGraphics)
				return smallPartyGfx;
			if (id.Type == AssetType.FullBodyPicture)
				return fullBody;
			if (id.Type == AssetType.LargeNpcGraphics)
				return largePartyGfx;
			if (id.Type == AssetType.TacticalIcon && id.Id < 8)
				return tacticalGfx;
			if (id == (AssetId)(SpriteId)SmallNpcId)
				return assets.LoadTexture(UAlbion.Base.SmallPartyMember.Rainer);
			
			if (id == (AssetId)(SpriteId)MonsterGfxId)
			{
				// TODO
			}
			
			if (id == (AssetId)(SpriteId)DungeonObjId)
			{
				// TODO
			}

			return asset;
		}
		
		$"Unhandled type: {id} is a {asset?.GetType().Name}".Dump();
		return asset;
	}

	var converter = new AssetConverter(AssetMapping.Global, disk, new FormatJsonUtil(), new[] { "Base" }, destMod);
	converter.Convert(null, TypesToConvert.ToHashSet(), null, Convert);
	converter.Convert(extraIds, null, null, Convert);

	// Need to do SYSTEXTS specially
	FixSysText(Path.Combine(scriptDir, "Albion", "CD", "XLDLIBS", "ENGLISH", "SYSTEXTS"));
	FixSysText(Path.Combine(scriptDir, "Albion", "CD", "XLDLIBS", "GERMAN", "SYSTEXTS"));
	FixSysText(Path.Combine(scriptDir, "Albion", "CD", "XLDLIBS", "FRENCH", "SYSTEXTS"));
	
	// Copy 'initial' files
	var cdInitial = Path.Combine(scriptDir, "Albion", "CD", "XLDLIBS", "INITIAL");
	var diskInitial = Path.Combine(scriptDir, "Albion", "XLDLIBS", "INITIAL");
	if (Directory.Exists(cdInitial) && Directory.Exists(diskInitial))
		foreach (var file in Directory.EnumerateFiles(cdInitial).Select(Path.GetFileName))
			File.Copy(Path.Combine(cdInitial, file), Path.Combine(diskInitial, file), true);
	
	Console.WriteLine("Done");
}

void FixSysText(string path)
{
	if (!File.Exists(path))
		return;
	
	var text = File.ReadAllText(path);
	if (!text.Contains("Tom")) return;
	
	var modified = ProcessString(text);
	File.WriteAllText(path, modified);
}

static string[] _firstNames = {
	"Agida", "Akiir", "Akira", "Alice", "Aliis", "Althea", "Amine", "Anngret", "Anne", "Aretha", "Argim", "Arrim", "Arthor", "Aurino", 
	"Bagga", "Bennos", "Bero", "Bewir", "Birin", "Birrh", "Bradir",	"Bragona", "Branagh", "Brann", "Brid", 
	"Cairnain", "Captain", "Cera", "Christine", "Colonel", "Coskon", "Cuarnainn", 
	"Darios", "Dolo", "Dranbar", "Drannagh", "Drirr", 
	"Edjirr", 
	"Fasiir", "Ferina", "Firina", "Fradh", "Frinja", "Frinos", 
	"Gard", "Garris", "Gerwad", "Giria", "Giuseppe", "Gridri", "Griibo", 
	"Hanii", "Harriet", "Herbert", "Herras", "Huo",
	"Irkith",
	"Jalia", "Janiis", "Jeros", "Jikraii", "Jila", "Jiris", "Joe", "John", "Jonatharh", "Jonathahr" /*typo shows up twice in FR*/,
	"Kapitän", "Kariah", "Khunagh", "Klirna", "Konny", "Kontos", "Kossea", "Krai", "Kriis", "Krinn", "Kryte", "Kyla", 
	"Laila", "Larina", "Leitos", "Llanaer", 
	"Maire", "Makaio", "Mellthas", "Melthar", "Merdger", "Michelle", "Morpatt", "Mykonou", 
	"Nadje", "Nadri", "Ned", "Nelly", "Nemos", "Nisrii", "Nodd",
	"Ohl", "Oibelos", "Osini", "Otikro", "Ouktero",
	"Pardhainn", "Peleitos", "Perron", "Posch",
	"Rabir", "Rainer", "Ramina", "Rejira", "Rhain", "Rhuainaigh", "Rhunagh", "Rifrako", "Riko", "Riolea", "Robert", "Roves",
	"Sarena", "Sarrin", "Siobhan", "Sira", "Snird", "Snoopy", "Sojekos", "Srelan", "Stiriik", "Synja",
	"Tamno", "Tharnos", "Tom", "Tori", "Torko", 
	"Viri", "Vrik", "Vris", 
	"Wania", "Winion", 
	"Zebenno", "Zeibe", "Zerruma", "Zirna", "Zirr",
	
	// names that are substrings of others need to come after them to avoid premature replacement
	"Chris", "Khunag",
};

static string[] _surnames = {
	"Ashley",
	"Beegle", "Bergmann-Lampe", "Bergmann- Lampe", "Bernard", "Brandt",
	"Dorbeck", "Driscoll",
	"Frill",
	"Gates",
	"Hupka VI",
	"Jagoda",
	"Laton",
	"McDermott", "Mitsamati",
	"Paul", "Piscator", "Priver",
	"Qennikos",
	"Shaw",
	"Takashi",
	"Wong Gang", "Wrinn",
};

static Regex BuildFirstNameRegex(string[] names) => new Regex($"({string.Join("|", names)})", RegexOptions.Compiled);
Regex FirstNameRegex = BuildFirstNameRegex(_firstNames);
Regex SurnameRegex = BuildFirstNameRegex(_surnames);

string ProcessString(string s)
{
	if (string.IsNullOrEmpty(s)) return s;
	s = FirstNameRegex.Replace(s, "Rainer");
	s = SurnameRegex.Replace(s, "Hofstedt");
	
	return s
		.Replace("girlfriend", "\"girlfriend\"")
		.Replace("Dr..coll", "H..fstadt")
		.Replace("Sebainah", "Ur-Rainer")
		.Replace("Rainer-Hofstedt", "Rainer Hofstedt")
		.Replace("DDT", "HHH")
		.Replace("Doimlr-Daithasu-Thompson", "Hofstat-Hovsteed-Hoofstad")
		;
}

static HashSet<UAlbion.Base.DungeonObject> MonsterObjects = new[] {
	UAlbion.Base.DungeonObject.Iskai, UAlbion.Base.DungeonObject.Iskai2, UAlbion.Base.DungeonObject.Iskai3, UAlbion.Base.DungeonObject.Iskai4, UAlbion.Base.DungeonObject.Iskai5, UAlbion.Base.DungeonObject.Iskai6, UAlbion.Base.DungeonObject.Iskai7, UAlbion.Base.DungeonObject.Iskai8,
	UAlbion.Base.DungeonObject.IskaiStatic, UAlbion.Base.DungeonObject.IskaiStatic2, UAlbion.Base.DungeonObject.IskaiStatic3, UAlbion.Base.DungeonObject.IskaiStatic4, UAlbion.Base.DungeonObject.IskaiStatic5, UAlbion.Base.DungeonObject.IskaiStatic6, UAlbion.Base.DungeonObject.IskaiStatic7, UAlbion.Base.DungeonObject.IskaiStatic8,
	UAlbion.Base.DungeonObject.Iskai9, UAlbion.Base.DungeonObject.Iskai10, UAlbion.Base.DungeonObject.Iskai11, UAlbion.Base.DungeonObject.Iskai12, UAlbion.Base.DungeonObject.Iskai13, UAlbion.Base.DungeonObject.Iskai14, UAlbion.Base.DungeonObject.Iskai15, UAlbion.Base.DungeonObject.Iskai16,
	UAlbion.Base.DungeonObject.Iskai17, UAlbion.Base.DungeonObject.Celt, UAlbion.Base.DungeonObject.Celt2, UAlbion.Base.DungeonObject.Celt3, UAlbion.Base.DungeonObject.Celt4, UAlbion.Base.DungeonObject.FatCelt, UAlbion.Base.DungeonObject.Celt5, UAlbion.Base.DungeonObject.Celt6,
	UAlbion.Base.DungeonObject.Celt7, UAlbion.Base.DungeonObject.BeardyCelt, UAlbion.Base.DungeonObject.Celt8, UAlbion.Base.DungeonObject.Celt9, UAlbion.Base.DungeonObject.Krondir, UAlbion.Base.DungeonObject.Krondir2, UAlbion.Base.DungeonObject.EvilKangaroo, UAlbion.Base.DungeonObject.IllManneredMoleRat,
	UAlbion.Base.DungeonObject.EvilKangaroo2, UAlbion.Base.DungeonObject.Krondir3, UAlbion.Base.DungeonObject.PeskyWasp, UAlbion.Base.DungeonObject.Iskai18, UAlbion.Base.DungeonObject.Celt10, UAlbion.Base.DungeonObject.Celt11, UAlbion.Base.DungeonObject.BeardyCelt2, UAlbion.Base.DungeonObject.Demon,
	UAlbion.Base.DungeonObject.PeskyWasp2, UAlbion.Base.DungeonObject.PeskyWasp3, UAlbion.Base.DungeonObject.PeskyWasp4, UAlbion.Base.DungeonObject.FloatingHand, UAlbion.Base.DungeonObject.IllTemperedMoleRat, UAlbion.Base.DungeonObject.Demon2, UAlbion.Base.DungeonObject.AngryCloud, UAlbion.Base.DungeonObject.Krondir4,
	UAlbion.Base.DungeonObject.Raptor, UAlbion.Base.DungeonObject.Wizard, UAlbion.Base.DungeonObject.FloatingHand2, UAlbion.Base.DungeonObject.Zombie, UAlbion.Base.DungeonObject.Chest3, UAlbion.Base.DungeonObject.Zombie2, UAlbion.Base.DungeonObject.AngryCloud2, UAlbion.Base.DungeonObject.Spidermajigger,
	UAlbion.Base.DungeonObject.Security, UAlbion.Base.DungeonObject.Security2, UAlbion.Base.DungeonObject.Celt12, UAlbion.Base.DungeonObject.MutedPuppyDog, UAlbion.Base.DungeonObject.IllTemperedMoleRat2, UAlbion.Base.DungeonObject.Raptor2, UAlbion.Base.DungeonObject.Spidermajigger2,
}.ToHashSet();
