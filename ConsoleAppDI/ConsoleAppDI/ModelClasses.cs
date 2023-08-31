public class Pokemon
{
    public string Name { get; set; }
    public List<TypeEntry> Types { get; set; } = new List<TypeEntry>();
}

public class TypeEntry
{
    public NamedApiResource Type { get; set; }
}

public class TypeEffectiveness
{
    public List<NamedApiResource> DoubleDamageTo { get; set; } = new List<NamedApiResource>();
    public List<NamedApiResource> HalfDamageTo { get; set; } = new List<NamedApiResource>();
    public List<NamedApiResource> NoDamageTo { get; set; } = new List<NamedApiResource>();
    public List<NamedApiResource> DoubleDamageFrom { get; set; } = new List<NamedApiResource>();
    public List<NamedApiResource> HalfDamageFrom { get; set; } = new List<NamedApiResource>();
    public List<NamedApiResource> NoDamageFrom { get; set; } = new List<NamedApiResource>();
}

public class NamedApiResource
{
    public string Name { get; set; }
    public string Url { get; set; }
}

