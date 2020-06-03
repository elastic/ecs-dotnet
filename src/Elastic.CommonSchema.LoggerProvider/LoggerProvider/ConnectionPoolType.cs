namespace Essential.LoggerProvider
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
