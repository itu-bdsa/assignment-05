namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void Day_0_Has_Correct_Values()
    {
        using var writer = new StringWriter();
        Console.SetOut(writer);

        var program = Assembly.Load(nameof(GildedRose));
        program.EntryPoint?.Invoke(null, new[] { Array.Empty<string>() });

        var start = 1;
        var end = 12;
        var outputString = "";

        var output = writer.GetStringBuilder().ToString().TrimEnd().Split(Environment.NewLine);     

        for (var i = start; i < end; i++) {
            outputString = outputString + output[i];
        }

        outputString.Should().Be("-------- day 0 --------name, sellIn, quality+5 Dexterity Vest, 10, 20Aged Brie, 2, 0Elixir of the Mongoose, 5, 7Sulfuras, Hand of Ragnaros, 0, 80Sulfuras, Hand of Ragnaros, -1, 80Backstage passes to a TAFKAL80ETC concert, 15, 20Backstage passes to a TAFKAL80ETC concert, 10, 49Backstage passes to a TAFKAL80ETC concert, 5, 49Conjured Mana Cake, 3, 6");

    }

    [Fact]
    public void Day_1_Has_Correct_Values()
    {
        using var writer = new StringWriter();
        Console.SetOut(writer);

        var program = Assembly.Load(nameof(GildedRose));
        program.EntryPoint?.Invoke(null, new[] { Array.Empty<string>() });

        var start = 13;
        var end = 24;
        var outputString = "";

        var output = writer.GetStringBuilder().ToString().TrimEnd().Split(Environment.NewLine);     

        for (var i = start; i < end; i++) {
                outputString = outputString + output[i];
            }


        outputString.Should().Be("-------- day 3 --------name, sellIn, quality+5 Dexterity Vest, 7, 17Aged Brie, -1, 3Elixir of the Mongoose, 2, 4Sulfuras, Hand of Ragnaros, -3, 20Sulfuras, Hand of Ragnaros, -4, 20Backstage passes to a TAFKAL80ETC concert, 12, 23Backstage passes to a TAFKAL80ETC concert, 7, 55Backstage passes to a TAFKAL80ETC concert, 2, 58Conjured Mana Cake, 0, 3");

    }

    [Fact]
    public void Day_3_Has_Correct_Values()
    {
        using var writer = new StringWriter();
        Console.SetOut(writer);

        var program = Assembly.Load(nameof(GildedRose));
        program.EntryPoint?.Invoke(null, new[] { Array.Empty<string>() });

        var start = 37;
        var end = 48;
        var outputString = "";

        var output = writer.GetStringBuilder().ToString().TrimEnd().Split(Environment.NewLine);     

        for (var i = start; i < end; i++) {
                outputString = outputString + output[i];
            }


        outputString.Should().Be("-------- day 3 --------name, sellIn, quality+5 Dexterity Vest, 7, 17Aged Brie, -1, 3Elixir of the Mongoose, 2, 4Sulfuras, Hand of Ragnaros, -3, 20Sulfuras, Hand of Ragnaros, -4, 20Backstage passes to a TAFKAL80ETC concert, 12, 23Backstage passes to a TAFKAL80ETC concert, 7, 55Backstage passes to a TAFKAL80ETC concert, 2, 58Conjured Mana Cake, 0, 3");

    }

    [Fact]
    public void Given_Items_Should_Update_Quality_And_SellIn_3_Times(){

        var app = new GildedRose.Program()
                          {
                              Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

                          };

        app.UpdateQuality();
        app.UpdateQuality();
        app.UpdateQuality();


        var itemsResult = new List<Item>();
        itemsResult.AddRange(new Item[] {
                new Item { Name = "+5 Dexterity Vest", SellIn = 7, Quality = 17 },
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 4 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 2, Quality = 4 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 12,
                    Quality = 23
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 7,
                    Quality = 50
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 2,
                    Quality = 50
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 3 }});




        app.Items.Should().BeEquivalentTo(itemsResult);

    }

    /*
    [Fact]
    public void Given_Items_If_Correct_Quaility_Return_True(){
    IList<Item> Items;
    Items = new List<Item>
        {
        new Item { Name = "+5 Dexterity Vest", SellIn = 12, Quality = 15 },
        new Item { Name = "Aged Brie", SellIn = 5, Quality = 2 },
        new Item { Name = "Elixir of the Mongoose", SellIn = 7, Quality = 7 },
        new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 },
        new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 30
                }
        };
    }
    */
    

}