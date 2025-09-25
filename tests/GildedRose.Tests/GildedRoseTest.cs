namespace GildedRose.Tests;

public class GildedRoseTest
{
    [Fact]
    public void Foo()
    {
        IList<Item> items = [new Item(Name: "foo", SellIn: 0, Quality: 0)];
        var app = new GildedRoseKata(items);
        app.UpdateQuality();
        Assert.Equal("fixme", items[0].Name);
    }
}
