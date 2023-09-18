namespace Pets.WebApi.Urls
{
    /// <summary>
    /// Urls
    /// </summary>
    public static class PetControllerUrls
    {
        /// <summary>
        /// Const
        /// </summary>
        public const string GetAll = "get-all";

        /// <summary>
        /// Const
        /// </summary>
        public const string GetById = "get-by-id/{id:guid}";

        /// <summary>
        /// Const
        /// </summary>
        public const string Create = "create";

        /// <summary>
        /// Const
        /// </summary>
        public const string Update = "update";

        /// <summary>
        /// Const
        /// </summary>
        public const string Delete = "delete/{id}";
    }
}
