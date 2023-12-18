using System.Text.Json.Serialization;

namespace StarWars.ViewModels.StarshipViewModel;

public class EditorStarshipViewModel
{
        public int UserId { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string cost_in_credits { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string cargo_capacity { get; set; }
        public string starship_class { get; set; }
}