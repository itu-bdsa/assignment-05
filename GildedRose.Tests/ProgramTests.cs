using System.Collections.Generic;
using System.IO;
using GildedRose;

namespace GildedRose.Tests;

public class ProgramTests
{
    Program program;

    public ProgramTests()
    {
        program = new Program();
        program.Items = new List<Item>
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
                                          };

    }

    [Fact]
    public void Test_OriginalOutput_ToActualOutput()
    {
        //Expected
        string expected = File.ReadAllText(@"../../../expectedoutput.txt");


        //Actual
        string actual = File.ReadAllText(@"../../../actualoutput.txt");

        //test
        actual.Should().BeEquivalentTo(expected);



    }


    [Theory]
    [InlineData(0, 9)]
    [InlineData(1, 1)]
    [InlineData(2, 4)]
    [InlineData(3, 0)]
    [InlineData(4, -1)]
    [InlineData(5, 14)]
    [InlineData(6, 9)]
    [InlineData(7, 4)]
    [InlineData(8, 2)]
    public void SellIn_ForGivenItems_AfterOneUpdateMethodCall(int indexOfItem, int ExpectedSellIn)
    {
        // Given
        var testItem = program.Items[indexOfItem];

        // When
        program.UpdateQuality();

        // Then
        testItem.SellIn.Should().Be(ExpectedSellIn);

    }

    [Theory]
    [InlineData(0, 19)]
    [InlineData(1, 1)]
    [InlineData(2, 6)]
    [InlineData(3, 80)]
    [InlineData(4, 80)]
    [InlineData(5, 21)]
    [InlineData(6, 50)]
    [InlineData(7, 50)]
    [InlineData(8, 5)]
    public void Quality_ForGivenItems_AfterOneUpdateMethodCall(int indexOfItem, int ExpectedQuality)
    {
        // Given
        var testItem = program.Items[indexOfItem];

        // When
        program.UpdateQuality();

        // Then
        testItem.Quality.Should().Be(ExpectedQuality);

    }

}