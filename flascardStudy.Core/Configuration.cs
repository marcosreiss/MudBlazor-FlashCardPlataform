namespace flascardStudy.Core
{
    public static class Configuration
    {
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 10;
        public const int DefaultStatusCode = 200;

        public static string BackendUrl { get; set; } = "http://localhost:5182";
        public static string FrontendUrl { get; set;} = "http://localhost:5236";
    }
}
