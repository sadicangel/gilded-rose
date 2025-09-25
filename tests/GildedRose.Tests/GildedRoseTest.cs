namespace GildedRose.Tests;

public class GildedRoseTest
{
    [Fact]
    public void Foo()
    {
        IList<Item> items = [new Item(Name: "foo", SellIn: 0, Quality: 1)];
        var app = new GildedRoseKata(items);
        app.UpdateQuality();
        Assert.Equal("foo", items[0].Name);
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }
}
