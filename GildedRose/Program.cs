using System;
using System.Collections.Generic;

namespace GildedRose;

public class Program {
    public IList<Item>? Items;
    public static void Main(string[] args){
        System.Console.WriteLine("OMGHAI!");

        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            }

        };

        for (var i = 0; i < 31; i++) {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < app.Items.Count; j++) {
                Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }

    internal int increase(int start, int add = 1){
        return Math.Min(50, start+add);
    }

    internal int decrease(int start, int remove = 1) {
        return Math.Max(0, start-remove);
    }


    public void UpdateQuality(){
        foreach (Item item in Items!) {
            if (item.Name == "Sulfuras, Hand of Ragnaros") {
                continue;
            }
  
            if (item.Name == "Aged Brie") {
                updateBrie(item);
                condition(item);
                continue;
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert") {
                updateBackstage(item);
                condition(item);
                continue;
            }

            if (!(item.Name == "Sulfuras, Hand of Ragnaros") 
                && !(item.Name == "Backstage passes to a TAFKAL80ETC concert")
                && !(item.Name == "Aged Brie")
                && !(item.Name!.Contains("Conjured", StringComparison.OrdinalIgnoreCase))){
                updateItem(item);
                condition(item);
                continue;
            }

            if (item.Name!.Contains("Conjured", StringComparison.OrdinalIgnoreCase)) {
                updateItem(item, 2);
                condition(item);
                continue;
            }
        }
    }
    

    internal void updateItem(Item item, int number = 1) {
        item.Quality = decrease(item.Quality, number);
        item.SellIn--;
        if(expired(item.SellIn)){
            item.Quality = decrease(item.Quality, number);
        }
    }

    internal void updateBrie(Item item) {
        item.Quality = increase(item.Quality);
        item.SellIn--;
        if(expired(item.SellIn)){
            item.Quality = increase(item.Quality);
        }
    }

    internal void updateBackstage(Item item) {
        if(item.SellIn >= 11){
            item.Quality = increase(item.Quality, 1);
        }
        if(item.SellIn is >= 6 and <= 10){
            item.Quality = increase(item.Quality, 2);
        }
        if(item.SellIn is >= 0 and <= 5){
            item.Quality = increase(item.Quality, 3);
        }

        item.SellIn--;

        if(expired(item.SellIn)) {
            item.Quality = 0;
        }
    }

    internal void condition(Item item) {
        item.Quality = increase(item.Quality, 0);
        item.Quality = decrease(item.Quality, 0);
    }

    internal bool expired(int sellIn) {
        return sellIn < 0;
    }
}
public class Item {
    public string? Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}
