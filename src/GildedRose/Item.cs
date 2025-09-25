namespace GildedRose;

public record Item(string Name, int SellIn, int Quality)
{
    public int SellIn { get; set; } = SellIn;
    public int Quality { get; set; } = Quality;
}
