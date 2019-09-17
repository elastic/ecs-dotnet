using Nest;

namespace ElasticCommonSchema
{
    public static class ElasticClientExtensions
    {
        public static ECSNamespace ECS(this ElasticClient client)
        {
            return new ECSNamespace(client);
        }
    }
}