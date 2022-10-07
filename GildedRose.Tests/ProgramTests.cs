using System.Reflection;
using GildedRose;
namespace GildedRose.Tests;



public class ProgramTests
{

    [Fact]
    public void UpdateQualityDecrementsNormalItem()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        var item = new Item { Name = "Sword of Stormwind", SellIn = 10, Quality = 1 };
        program.Items.Add(item);

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Sword of Stormwind");
        program.Items[0].SellIn.Should().Be(9);
        program.Items[0].Quality.Should().Be(0);
    }

    // Aged Cheese Test
    [Fact]
    public void AgedBrieIncreaseInQuality()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        program.Items.Add(new Item { Name = "Aged Brie", SellIn = 10, Quality = 4 });

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Aged Brie");
        program.Items[0].SellIn.Should().Be(9);
        program.Items[0].Quality.Should().Be(5);
    }

    [Fact]
    public void AgedBrieSellIn0QualityIncreaseTwiceAsFast()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        program.Items.Add(new Item { Name = "Aged Brie", SellIn = 0, Quality = 4 });

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Aged Brie");
        program.Items[0].SellIn.Should().Be(-1);
        program.Items[0].Quality.Should().Be(6);
    }

    [Fact]
    public void AgedBrieQualityDoesNotIncreaseWhen()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        program.Items.Add(new Item { Name = "Aged Brie", SellIn = -4, Quality = 51 });

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Aged Brie");
        program.Items[0].SellIn.Should().Be(-5);
        program.Items[0].Quality.Should().Be(51);
    }

    [Fact]
    public void AgedBrieShouldNotGoAboveQuality50()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        program.Items.Add(new Item { Name = "Aged Brie", SellIn = -4, Quality = 49 });

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Aged Brie");
        program.Items[0].SellIn.Should().Be(-5);
        program.Items[0].Quality.Should().Be(50);
    }

    /*
    [Fact]
    public void Main_when_run_prints_Hello_World()
    {
        // Arrange
        using var writer = new StringWriter();
        Console.SetOut(writer);
        var outputFile = File.OpenText("../../../../output.txt").ReadToEnd().TrimEnd();

         // Act
        var program = Assembly.Load(nameof(GildedRose));
        program.EntryPoint?.Invoke(null, new[] { Array.Empty<string>() });

        // Assert
        var output = writer.GetStringBuilder().ToString().TrimEnd();
        output.Should().Be(outputFile);
    }
    */
}