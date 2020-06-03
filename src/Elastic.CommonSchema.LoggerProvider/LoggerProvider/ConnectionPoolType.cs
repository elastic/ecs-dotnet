namespace Elastic.CommonSchema
{
    public enum ConnectionPoolType
    {
        Unknown = 0,
        SingleNode,
        Sniffing,
        Static,
        Sticky,
        StickySniffing,
        Cloud
    }
}
