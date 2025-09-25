namespace GildedRose;

public class GildedRoseKata(IList<Item> items)
{
    private readonly List<(Item Item, ItemHandler Handler)> _itemHandlerPairs = [.. items.Zip(items.Select(ItemHandlerFactory.GetHandler))];

    public void UpdateQuality()
    {
        foreach (var (item, handler) in _itemHandlerPairs)
        {
            handler(item);
        }
    }
}
