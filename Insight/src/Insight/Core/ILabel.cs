namespace Insight.Core.Entities
{
    public partial interface ILabel
    {
        string Id { get; }
        string Number { get; }
        string Prefix { get; }
    }
}