﻿using System.Text;

namespace GildedRose.Tests;

public class ApprovalTest
{
    [Fact]
    public Task Foo()
    {
        Item[] items = [new Item(Name: "foo", SellIn: 0, Quality: 0)];
        var app = new GildedRoseKata(items);
        app.UpdateQuality();

        return Verifier.Verify(items);
    }

    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        Program.Main(["30"]);
        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
}
