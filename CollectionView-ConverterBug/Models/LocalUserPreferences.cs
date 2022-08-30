namespace CollectionView_BugRepro.Models
{
    public class LocalUserPreferences
    {
        public enum DistanceUnit
        {
            Yards,
            Meters
        }

        public DistanceUnit UserDistanceUnit
        {
            get => (DistanceUnit)Preferences.Get("UserDistanceUnit", (int)DistanceUnit.Yards);
            set => Preferences.Set("UserDistanceUnit", (int)value); 
        }

        public LocalUserPreferences() { }

        public void ClearPreferences()
        {
            Preferences.Clear();
        }

    }
}
