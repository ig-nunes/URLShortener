namespace URLShortener.Dados.Models
{
    public class Url
    {
        public Url()
        {
            
        }
        public int Id { get; set; }
        public string LUrl { get; set; }
        public string SUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public int ExpirationPeriod { get; set; }

        public bool IsExpired
        {
            get { return DateTime.Now > CreationDate.AddSeconds(ExpirationPeriod); }
        }

        public int TimeRemainingInSeconds()
        {
            if (IsExpired)
            {
                return 0;
            }
            else
            {
                var timeRemaining = CreationDate.AddSeconds(ExpirationPeriod) - DateTime.Now;
                return (int)timeRemaining.TotalSeconds;
            }
            
        }

    }
}
