namespace Knights.Challenge.Repository.Data
{
    public class KnightsChallengeDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string KnightsCollectionName { get; set; } = null!;
    }
}
