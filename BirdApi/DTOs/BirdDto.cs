namespace BirdApi.DTOs
{
    public class BirdDto
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Binomial_name { get; set; }
        public string Conservation_status { get; set; }

        public int sightingsTotal { get; set; } = 0;
    }
}
