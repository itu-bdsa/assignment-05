namespace GildedRose.Tests;

public class ProgramTests
{
    IList<Item> items;
    public ProgramTests(){
        items = new List<Item>();
    }

    [Fact]
    public void Quality_Should_Decrease_by_1_PerDay()
    {
        items = new List<Item>{
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(19);

    }

    [Fact]
    public void Quality_Should_Decrease_by_2_PerDay_after_SellIn()
    {
        items = new List<Item>{
            new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 }
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(18);

    }

    [Fact]
    public void Quality_never_neg()
    {
        items = new List<Item>{
            new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 1 } //quality 'should' decrease by 2 bc sellin = 0
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void Quality_never_over_50()
    {
        items = new List<Item>{
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 },
            new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 8,
                    Quality = 50
                }
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(50);
        items[1].Quality.Should().Be(50);
        
    }

    [Fact]
    public void Brie_Quality_Should_Increase_2_after_SellIn()
    {
        items = new List<Item>{
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 }
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(12);

    }

    [Fact]
    public void Backstagepass_value_increase_2_When9DaysTillConcert()
    {
        items = new List<Item>{
            new Item {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 22
                }
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(24);

    }

    [Fact]
    public void Sulfura_never_changes()
    {
        items = new List<Item>{
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(80);
        items[0].SellIn.Should().Be(0);
    }


    [Fact]
    public void Conjured_Quality_Decrease_2_perday()
    {
        throw new NotImplementedException();
    }

}