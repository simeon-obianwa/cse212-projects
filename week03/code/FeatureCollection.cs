public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new List<Feature>();
}

public class Feature
{
    public FeatureProperties Properties { get; set; }   // no '?'
}

public class FeatureProperties
{
    public string Place { get; set; }                   // no '?'
    public double? Mag { get; set; }                    // keep: value-type nullable is always fine
}