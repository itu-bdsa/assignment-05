namespace GildedRose.Tests;

public class ProgramTests
{

    private List<Item> items;
    public ProgramTests() {

        var app = new GildedRose.Program();
        app.Items = new List<Item> { new Item { Name = "Vest", SellIn = 10, Quality = 20 },
                                     new Item { Name = "Jacket", SellIn = 0, Quality = 10},
                                     new Item { Name = "Poor Jacket", SellIn = 0, Quality = 1},
                                     new Item { Name = "Aged Brie", SellIn = 5, Quality = 47},
                                     new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                     new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 30},
                                     new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30},
                                     new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30},
                                     new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 30},
                                     new Item { Name = "Conjured", SellIn = 10, Quality = 30} };

        app.UpdateQuality();
        app.UpdateQuality();
        app.UpdateQuality();
        app.UpdateQuality();
        app.UpdateQuality();
        items = app.Items.ToList();

    }

    
    [Fact]
    public void Program_Output_Is_Correct_Output() {
        
        using var writer = new StringWriter();
        Console.SetOut(writer);

        var program = Assembly.Load(nameof(GildedRose));
        program.EntryPoint?.Invoke(null, new[] { Array.Empty<string>() });

        var output = writer.GetStringBuilder().ToString().TrimEnd();     
        var outputFile = File.ReadAllText(@"../../../output.txt");

        output.Should().Be(outputFile);
    }
    

    [Fact]
    public void Vest_Quality_Is_15_After_5_Days() {

        items[0].Quality.Should().Be(15);

    }

    [Fact]
    public void Vest_SellIn_Is_5_After_5_Days() {

        items[0].SellIn.Should().Be(5);

    }

    [Fact]
    public void Jacket_Quality_Is_0_After_5_Days() {

    
        items[1].Quality.Should().Be(0);

    }

    [Fact]
    public void Poor_Jacket_Quality_Is_0_After_5_Days() {

    
        items[2].Quality.Should().Be(0);

    }

    [Fact]
    public void Aged_Brie_Quality_Is_50_After_5_Days() {

    
        items[3].Quality.Should().Be(50);

    }

    [Fact]
    public void Sulfuras_Doesnt_Change() {

    
        items[4].Quality.Should().Be(80);

    }

    [Fact]
    public void Backstage_Pass_Increase_To_35() {

    
        items[5].Quality.Should().Be(35);

    }

    [Fact]
    public void Backstage_Pass_Increase_To_40() {

        items[6].Quality.Should().Be(40);

    }

    [Fact]
    public void Backstage_Pass_Increase_To_45() {

    
        items[7].Quality.Should().Be(45);

    }

    [Fact]
    public void Backstage_Pass_Quality_Becomes_0() {

        items[8].Quality.Should().Be(0);

    }

    [Fact]
    public void Conjured_Quality_Becomes_20() {

        items[9].Quality.Should().Be(20);

    }

}