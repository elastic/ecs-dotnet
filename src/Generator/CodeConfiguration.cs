using System.IO;

namespace Generator
{
    public static class CodeConfiguration
    {
        private static string _root;

        private static string Root
        {
            get
            {
                if (_root != null) return _root;

                var currentDirectory = Directory.GetCurrentDirectory();
                var directoryInfo = new DirectoryInfo(currentDirectory);

                var runningAsDnx =
                    directoryInfo.Name == "Generator" &&
                    directoryInfo.Parent != null &&
                    directoryInfo.Parent.Name == "ECS";

                _root = runningAsDnx ? "" : @"..\..\..\..\";
                return _root;
            }
        }

        public static string SpecificationFolder { get; } = $@"{Root}Specification\";
        public static string ViewFolder { get; } = $@"{Root}Generator\Views\";
        public static string ElasticCommonSchemaGeneratedFolder { get; } = $@"{Root}Elastic.CommonSchema\";
        public static string ElasticCommonSchemaNESTGeneratedFolder { get; } = $@"{Root}Elastic.CommonSchemaNEST\";
    }
}