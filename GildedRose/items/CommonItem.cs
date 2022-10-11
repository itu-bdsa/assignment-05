namespace GildedRose; 

public class CommonItem : Item{

    public override void UpdateQuality(){
    if(Quality==0 || Quality>49){return;}
        if(SellIn<0) Quality--;
        Quality--;
    }
    public override void UpdateSellin(){
        SellIn=SellIn-1;
    }   
}