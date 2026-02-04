namespace InfinityFit.Models
{
    public static class VoucherTemplates
    {
        public static readonly List<(string Name, string Description)> Templates = new()
        {
            ("10% Museum Discount", "Get 10% off entry to the museum"),
            ("15% Landmark Discount", "Get 15% off at a tourist landmark"),
            ("20% Restaurant Discount", "Get 20% off at a partner restaurant"),
            ("25% Guided Tour Discount", "Get 25% off a guided city tour"),
            ("30% Adventure Park Discount", "Get 30% off at the adventure park"),
            ("35% Adventure Park Discount", "Get 35% off at the adventure park"),
            ("40% Accommodation Discount", "Get 40% off at a partner accommodation")
        };
    }
}
