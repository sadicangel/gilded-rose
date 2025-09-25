namespace GildedRose;

public delegate void ItemHandler(Item item);

public static class ItemHandlerFactory
{
    private static readonly ItemHandler s_agedBrieHandler = item => UpdateQuality(item, 1);

    private static readonly ItemHandler s_backstagePassHandler = item =>
    {
        if (item.SellIn > 10)
        {
            UpdateQuality(item, 1);
        }
        else if (item.SellIn > 5)
        {
            UpdateQuality(item, 2);
        }
        else if (item.SellIn > 0)
        {
            UpdateQuality(item, 3);
        }
        else
        {
            item.Quality = 0;
            item.SellIn -= 1;
        }
    };

    private static readonly ItemHandler s_legendaryItemHandler = item => { };

    private static readonly ItemHandler s_conjuredItemHandler = item => UpdateQuality(item, -2);

    private static readonly ItemHandler s_regularItemHandler = item => UpdateQuality(item, -1);

    private static void UpdateQuality(Item item, int amount)
    {
        if (item.SellIn <= 0)
        {
            amount *= 2;
        }
        var quality = item.Quality + amount;
        item.Quality = int.Clamp(quality, 0, 50);
        item.SellIn -= 1;
    }

    public static ItemHandler GetHandler(Item item) => item.Name switch
    {
        "Aged Brie" => s_agedBrieHandler,
        "Backstage passes to a TAFKAL80ETC concert" => s_backstagePassHandler,
        "Sulfuras, Hand of Ragnaros" => s_legendaryItemHandler,
        _ when item.Name.StartsWith("Conjured") => s_conjuredItemHandler,
        _ => s_regularItemHandler,
    };
}
